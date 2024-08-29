#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion
using System.Runtime.InteropServices;
using System.Text;

namespace Goedel.Cryptography.Windows;

/// <summary>Key container class. This makes use of windows specific platform
/// encryption to bind keys to the user's log in password in a transparent fashion.</summary>
public class KeyContainer {

    //static long CRYPT_MACHINE_KEYSET = 0x20;
    static readonly long CRYPT_VERIFYCONTEXT = 0xF0000000;
    static readonly uint CRYPT_FIRST = 1;
    static readonly uint CRYPT_NEXT = 2;

    static readonly uint PROV_RSA_FULL = 1;
    static readonly uint PP_ENUMCONTAINERS = 2;

    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    static extern bool CryptGetProvParam(
       IntPtr hProv,
       uint dwParam,
       [MarshalAs(UnmanagedType.LPStr)] StringBuilder pbData,
       ref uint dwDataLen,
       uint dwFlags);

    [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool CryptAcquireContext(
        ref IntPtr hProv,
        string pszContainer,
        string pszProvider,
        uint dwProvType,
        uint dwFlags);

    [DllImport("advapi32.dll", EntryPoint = "CryptReleaseContext", CharSet = CharSet.Unicode, SetLastError = true)]
    static extern bool CryptReleaseContext(
       IntPtr hProv,
       Int32 dwFlags);

    /// <summary>
    /// Get the set of key container names.
    /// </summary>
    /// <returns>The set of container names.</returns>
    public static IEnumerable<string> GetKeyContainerNames() {
        var keyContainerNameList = new List<string>();

        IntPtr hProv = IntPtr.Zero;
        //uint flags = (uint)(CRYPT_MACHINE_KEYSET | CRYPT_VERIFYCONTEXT);
        uint flags = (uint)(CRYPT_VERIFYCONTEXT);

        if (CryptAcquireContext(ref hProv, null, null, PROV_RSA_FULL, flags) == false) {
            throw new Exception("CryptAcquireContext");
            }

        uint bufferLength = 2048;
        StringBuilder stringBuilder = new((int)bufferLength);
        if (CryptGetProvParam(hProv, PP_ENUMCONTAINERS, stringBuilder, ref bufferLength, CRYPT_FIRST) == false) {
            return keyContainerNameList;
            }

        keyContainerNameList.Add(stringBuilder.ToString());

        while (CryptGetProvParam(hProv, PP_ENUMCONTAINERS, stringBuilder, ref bufferLength, CRYPT_NEXT)) {
            keyContainerNameList.Add(stringBuilder.ToString());
            }

        if (hProv != IntPtr.Zero) {
            CryptReleaseContext(hProv, 0);
            }

        return keyContainerNameList;
        }

    /// <summary>Erase all test data from the system. Use with care!</summary>
    public static void EraseTest() {
        if (!KeyPair.TestMode) {
            var Keys = KeyContainer.GetKeyContainerNames();
            var Prefix = Goedel.Cryptography.Standard.ContainerFramework.PrefixTest;
            foreach (var Key in Keys) {
                if (Key.StartsWith(Prefix)) {
                    //Delete(Key);
                    }
                }
            }
        }

    /// <summary>Delete the specified key</summary>
    /// <param name="Key">Key to delete.</param>
    void Delete(string Key) {
        this.Future();

        try {
            var CSP = new CspParameters() {
                KeyContainerName = Key
                };
            var RSA = new RSACryptoServiceProvider(CSP) {
                PersistKeyInCsp = false
                };
            }
        catch {

            }
        }

    }
