using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RGiesecke.DllExport;
using System.Runtime.InteropServices;
using Goedel.Utilities;

using Goedel.Mesh.Portal.Client;
using Goedel.Recrypt;
using Goedel.Recrypt.Client;
using Goedel.Mesh.Platform.Windows;

namespace MeshMananaged {

    /// <summary>
    /// Interface to Mesh Decryption Functions. Note that the project settings currently
    /// only cause the interop interface to be created, they do not cause the dll to
    /// be registered as that requires administrative privileges.
    /// 
    /// https://docs.microsoft.com/en-us/dotnet/framework/interop/how-to-register-primary-interop-assemblies
    /// </summary>
    public class Interface {
        static MeshMachine MeshMachine;
        static SessionPersonal MeshSessionPersonal = null;

        /// <summary>
        /// One time initialization.
        /// </summary>
        static Interface () {
            MeshMachine = new MeshMachineWindows();

            // Get the default Mesh profile.
            MeshSessionPersonal = MeshMachine.Personal;

            MeshRecrypt.Initialize();
            }


        static byte ToLower (byte In) => (In < 0x41 | In > 0x5a) ? In : (byte)(In + 0x20); 

        /// <summary>
        /// Read the input container and decrypt it using local keys (if found). Then
        /// return the decrypted data and the content type.
        /// </summary>
        /// <param name="InputData"></param>
        /// <param name="OutputData"></param>
        /// <param name="ContentType"></param>
        static void DecryptManaged (
            byte[] InputData,
            out byte[] OutputData,
            out string ContentType) {

            ContentType = "text/html";
            OutputData = new byte[InputData.Length];
            for (var i = 0; i < InputData.Length; i++) {
                OutputData[i] = ToLower(InputData[i]);
                }

            //MeshSessionPersonal.DecryptDARE(InputData, out OutputData, out ContentType);
            }


        // Non COM interface

        /// <summary>
        /// Decrypt an encrypted container.
        /// </summary>
        /// <param name="InputArray">The container data.</param>
        /// <param name="InputLength">The container data length.</param>
        /// <param name="OutputArray">The decrypted content data. The caller must free this data using
        /// a call to the unmanaged free data routine.</param>
        /// <param name="OutputLength">The decrypted content length.</param>
        /// <param name="ContentType">A null terminated string specifying the content type if known,
        /// otherwise null</param>
        [DllExport(ExportName = "Decrypt", CallingConvention = CallingConvention.StdCall)]
        static void DecryptUnmanaged (
                IntPtr InputArray,
                int InputLength,
                out IntPtr OutputArray,
                out int OutputLength,
                out IntPtr ContentType) {

            // The input data
            var Input = InputArray.ToManagedByte(InputLength);
            DecryptManaged(Input, out var OutputManaged, out var ContentTypeManaged);

            // Convert to unmanaged
            OutputArray = OutputManaged.ToUnmanaged();
            OutputLength = OutputManaged.Length;

            ContentType = ContentTypeManaged.ToUnmanaged();
            }



        }
    }
