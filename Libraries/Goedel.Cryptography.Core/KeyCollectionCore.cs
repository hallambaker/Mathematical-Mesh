using Goedel.Cryptography.Jose;
using Goedel.Cryptography.PKIX;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Utilities;

using System;
using System.IO;




namespace Goedel.Cryptography.Core {




    public class KeyCollectionCore : KeyCollection {
        const string WindowsMeshKeys = @"Mesh\Keys";
        const string WindowsMeshProfiles = @"Mesh\Profiles";
        const string LinuxMeshKeys = @".Mesh/Keys";
        const string LinuxMeshProfiles = @".Mesh/Profiles";

        static string _DirectoryKeys;
        static string _DirectoryMesh;

        public virtual string DirectoryKeys => _DirectoryKeys;
        public virtual string DirectoryMesh => _DirectoryMesh;
        //</summary>    @"~\.Mesh\Keys\";


        static KeyCollectionCore() {
            var platform = Environment.OSVersion.Platform;

            switch (platform) {
                case PlatformID.Unix: {
                    SetPlatformUnix();
                    break;
                    }
                case PlatformID.Win32NT: {
                    SetPlatformWindows();
                    break;
                    }
                case PlatformID.MacOSX: {
                    SetPlatformUnix();
                    break;
                    }
                }


            }


        static void SetPlatformWindows() {
            var appsRoot = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _DirectoryKeys = Path.Combine(appsRoot, WindowsMeshKeys);
            _DirectoryMesh = Path.Combine(appsRoot, WindowsMeshProfiles);
            }

        static void SetPlatformUnix() {
            var userRoot = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            _DirectoryKeys = Path.Combine(userRoot, LinuxMeshKeys);
            _DirectoryMesh = Path.Combine(userRoot, LinuxMeshProfiles);
            }


        public override void Persist(string udf, IPKIXPrivateKey privateKey, bool exportable) {
            var fileName = Path.Combine(DirectoryKeys, udf);

            // keys are persisted as plaintext for now.

            var joseKey = Key.Factory(privateKey);
            joseKey.Exportable = exportable;
            var plaintext = joseKey.ToJson(true);

            Directory.CreateDirectory(DirectoryKeys);
            fileName.WriteFileNew(plaintext);


            }

        public override void Persist(string udf, IJson joseKey, bool exportable) {
            var fileName = Path.Combine(DirectoryKeys, udf);

            joseKey.Exportable = exportable;
            var plaintext = joseKey.ToJson(true);

            Directory.CreateDirectory(DirectoryKeys);
            fileName.WriteFileNew(plaintext);


            }

        public override IJson LocatePrivateKey(string udf) {

            var fileName = Path.Combine(DirectoryKeys, udf);

            try {

                fileName.OpenReadToEnd(out var data);
                return Key.FromJSON(data.JSONReader(), true);
                }
            catch {
                throw new NYI();
                }
            }

        public override KeyPair LocatePrivateKeyPair(string udf) {

            var fileName = Path.Combine(DirectoryKeys, udf);

            try {

                fileName.OpenReadToEnd(out var data);
                var key = Key.FromJSON(data.JSONReader(), true);
                return key.GetKeyPair(key.Exportable ? KeySecurity.Exportable : KeySecurity.Bound, this);
                }
            catch {
                return base.LocatePrivateKeyPair(udf);
                }
            }

        }



    }



