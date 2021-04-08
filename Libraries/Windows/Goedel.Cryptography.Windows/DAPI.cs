using System;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using Goedel.Utilities;

#pragma warning disable IDE1006

namespace Goedel.Cryptography.Windows {

    /// <summary>
    /// Provide access to the Windows Data Protection API. This binds data to the user's
    /// public key so that th user's password is required to unlock it.
    /// </summary>
    public class DPAPI {

        // Wrapper for DPAPI CryptProtectData function.
        [DllImport("crypt32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool CryptProtectData(ref DATA_BLOB pPlainText,
                                        string szDescription,
                                    ref DATA_BLOB pEntropy,
                                        IntPtr pReserved,
                                    ref CRYPTPROTECT_PROMPTSTRUCT pPrompt,
                                        int dwFlags,
                                    ref DATA_BLOB pCipherText);

        // Wrapper for DPAPI CryptUnprotectData function.
        [DllImport("crypt32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool CryptUnprotectData(ref DATA_BLOB pCipherText,
                                    ref string pszDescription,
                                    ref DATA_BLOB pEntropy,
                                        IntPtr pReserved,
                                    ref CRYPTPROTECT_PROMPTSTRUCT pPrompt,
                                        int dwFlags,
                                    ref DATA_BLOB pPlainText);

        // BLOB structure used to pass data to DPAPI functions.
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct DATA_BLOB {
            public int cbData;
            public IntPtr pbData;
            }


        static DATA_BLOB MakeBlob(byte[] data) {

            int cbData;
            IntPtr pbData;

            data ??= Array.Empty<byte>(); // Sanity check, null to empty array

            cbData = data.Length;
            pbData = Marshal.AllocHGlobal(data.Length);
            //Assert.False(pbData == IntPtr.Zero, InsufficientMemory.Throw);
            Marshal.Copy(data, 0, pbData, data.Length);

            return new DATA_BLOB() {
                cbData = cbData,
                pbData = pbData
                };
            }

        static void Free(DATA_BLOB Blob) {
            if (Blob.pbData != IntPtr.Zero) {
                Marshal.FreeHGlobal(Blob.pbData);
                }
            }

        static byte[] GetBytes(DATA_BLOB Blob) {
            byte[] Result = new byte[Blob.cbData];
            Marshal.Copy(Blob.pbData, Result, 0, Blob.cbData);

            return Result;
            }

        // Prompt structure to be used for required parameters.
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct CRYPTPROTECT_PROMPTSTRUCT {
            public int cbSize;
            public int dwPromptFlags;
            public IntPtr hwndApp;
            public string szPrompt;
            }

        // Null values
        static IntPtr NullPtr = ((IntPtr)((int)(0)));
        static DATA_BLOB NullBlob = new();
        //readonly byte[] EmptyBytes = new byte[0];

        // DPAPI key initialization flags.
        private const int CRYPTPROTECT_UI_FORBIDDEN = 0x1;
        private const int CRYPTPROTECT_LOCAL_MACHINE = 0x4;

        /// <summary>The key type</summary>
        public enum KeyType {
            /// <summary>Key is bound to user</summary>
            UserKey = 1,
            /// <summary>Key is bound to machine</summary>
            MachineKey = 2
            };

        /// <summary>
        /// Encrypt data using DAPI
        /// </summary>
        /// <param name="KeyType">The Key type, user or machine</param>
        /// <param name="PlainTextBytes">The data to be encrypted</param>
        /// <param name="EntropyBytes">Additional Key material used to salt the key</param>
        /// <param name="Description">Description of the stored data</param>
        /// <returns>The encrypted data.</returns>
        public static byte[] Encrypt(byte[] PlainTextBytes,
                                KeyType KeyType = KeyType.UserKey,
                                string Description = null,
                                byte[] EntropyBytes = null
                                ) {

            // Sanitize inputs
            PlainTextBytes ??= Array.Empty<byte>();
            EntropyBytes ??= Array.Empty<byte>();
            Description ??= "";

            // Create native structures
            DATA_BLOB CipherTextBlob = new DATA_BLOB();
            DATA_BLOB PlainTextBlob = NullBlob;
            DATA_BLOB EntropyBlob = NullBlob;

            CRYPTPROTECT_PROMPTSTRUCT prompt = new CRYPTPROTECT_PROMPTSTRUCT() {
                cbSize = Marshal.SizeOf(typeof(CRYPTPROTECT_PROMPTSTRUCT)),
                dwPromptFlags = 0,
                hwndApp = NullPtr,
                szPrompt = null
                };

            try {
                PlainTextBlob = MakeBlob(PlainTextBytes);
                EntropyBlob = MakeBlob(EntropyBytes);

                int flags = CRYPTPROTECT_UI_FORBIDDEN;

                if (KeyType == KeyType.MachineKey) {
                    flags |= CRYPTPROTECT_LOCAL_MACHINE;
                    }

                bool success = CryptProtectData(ref PlainTextBlob,
                                                    Description,
                                                ref EntropyBlob,
                                                    IntPtr.Zero,
                                                ref prompt,
                                                    flags,
                                                ref CipherTextBlob);

                // Do Windows32 style exception check
                if (!success) {
                    int errCode = Marshal.GetLastWin32Error();
                    throw new Exception("CryptProtectData failed.", new Win32Exception(errCode));
                    }
                return GetBytes(CipherTextBlob);
                }
            catch (Exception ex) {
                throw new EncryptionFailed("DPAPI was unable to encrypt data.", ex);
                }

            finally {
                Free(PlainTextBlob);
                Free(CipherTextBlob);
                Free(EntropyBlob);
                }
            }

        /// <summary>
        /// Decrypt data stored using the Data Protection API
        /// </summary>
        /// <param name="CipherTextBytes">The encrypted data</param>
        /// <param name="Description">Description of the encrypted data</param>
        /// <param name="EntropyBytes">Additional Key material</param>
        /// <returns>The decrypted data.</returns>
        public static byte[] Decrypt(byte[] CipherTextBytes,
                                out string Description,
                                byte[] EntropyBytes = null) {

            DATA_BLOB CipherTextBlob = NullBlob;
            DATA_BLOB EntropyBlob = NullBlob;
            DATA_BLOB PlainTextBlob = new DATA_BLOB();

            CRYPTPROTECT_PROMPTSTRUCT Prompt = new CRYPTPROTECT_PROMPTSTRUCT() {
                cbSize = Marshal.SizeOf(typeof(CRYPTPROTECT_PROMPTSTRUCT)),
                dwPromptFlags = 0,
                hwndApp = NullPtr,
                szPrompt = null
                };

            // Initialize description string.
            Description = "";

            try {
                CipherTextBlob = MakeBlob(CipherTextBytes);
                EntropyBlob = MakeBlob(EntropyBytes);

                int flags = CRYPTPROTECT_UI_FORBIDDEN;

                bool success = CryptUnprotectData(ref CipherTextBlob,
                                                  ref Description,
                                                  ref EntropyBlob,
                                                      IntPtr.Zero,
                                                  ref Prompt,
                                                      flags,
                                                  ref PlainTextBlob);

                // Win32 style exception handling
                if (!success) {
                    int errCode = Marshal.GetLastWin32Error();
                    throw new Exception(
                        "CryptUnprotectData failed.", new Win32Exception(errCode));
                    }

                return GetBytes(PlainTextBlob);
                }
            catch (Exception ex) {
                throw new DecryptionFailed("DPAPI was unable to decrypt data.", ex);
                }

            finally {
                Free(PlainTextBlob);
                Free(CipherTextBlob);
                Free(EntropyBlob);
                }
            }
        }

    }