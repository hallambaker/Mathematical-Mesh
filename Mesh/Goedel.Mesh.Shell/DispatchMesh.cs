using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using Goedel.Utilities;
using Goedel.Mesh.Client;
using Goedel.IO;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Mesh;
using Goedel.Protocol;

namespace Goedel.Mesh.Shell {
    public partial class Shell {


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MeshCreate(MeshCreate Options) {
            var account = Options.NewAccountID.Value;

            using (var contextMesh = MeshMachine.CreateMesh("main")) {

                if (account != null) {
                    var contextAccount = contextMesh.CreateAccount(account);
                    }

                return new ResultMasterCreate() {
                    Success = true,
                    ProfileMaster = contextMesh.ProfileMesh,
                    CatalogEntryDevice = contextMesh.CatalogEntryDevice,
                    MeshUDF = contextMesh.ProfileMesh.UDF,
                    DeviceUDF = contextMesh.CatalogEntryDevice.UDF
                    };

                }


            throw new NYI();
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MeshEscrow(MeshEscrow Options) {
            throw new NYI();
            //using (var contextDevice = GetContextDevice(Options)) {
            //    var file = Options.File.Value ?? contextDevice.ProfileMaster.UDF+".escrow";


            //    (var escrow, var shares) = contextDevice.Escrow(3, 2);
            //    escrow.ToFile(file);
            //    var textShares = new List<string>();
            //    foreach (var share in shares) {
            //        textShares.Add(share.UDFKey);
            //        }

            //    return new ResultEscrow() {
            //        Success = true,
            //        Shares = textShares,
            //        Filename = file
            //        };
            //    }
            }

        void AddIfPresent(List<string> Keys, String Parameter) {
            if (Parameter.Value != null) {
                Keys.Add(Parameter.Value);
                }
            }

        
        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MeshRecover(MeshRecover Options) {
            var file = Options.File.Value;
            using (var contextDevice = GetContextDevice(Options)) {
                // Read the escrow data from file


                var recoverShares = new List<string>();
                AddIfPresent(recoverShares, Options.Share1);
                AddIfPresent(recoverShares, Options.Share2);
                AddIfPresent(recoverShares, Options.Share3);
                AddIfPresent(recoverShares, Options.Share4);

                AddIfPresent(recoverShares, Options.Share5);
                AddIfPresent(recoverShares, Options.Share6);
                AddIfPresent(recoverShares, Options.Share7);
                AddIfPresent(recoverShares, Options.Share8);
                var secret = new Secret(recoverShares);

                DareEnvelope Escrow=null;
                if (file != null) {
                    using (var inputStream = file.OpenFileRead()) {
                        using (var reader = new JSONBCDReader(inputStream)) {
                            Escrow = DareEnvelope.FromJSON(reader, false);

                            }
                        }

                    }
                throw new NYI();
                //if (Options.Verify.Value) {
                //    var escrowedKeySet = contextDevice.RecoverKeySet(Escrow, secret);

                //    var EncryptUDF = new List<string>();
                //    if (escrowedKeySet.MasterEscrowKeys != null) {
                //        foreach (var key in escrowedKeySet.MasterEscrowKeys) {
                //            EncryptUDF.Add(key.KeyPair.UDF);
                //            }
                //        }

                //    string SignUDF = null;
                //    if (escrowedKeySet.MasterSignatureKey != null) {
                //        SignUDF = escrowedKeySet.MasterSignatureKey.KeyPair.UDF;
                //        }

                //    return new ResultRecover() {
                //        SignUDF = SignUDF,
                //        EncryptUDF = EncryptUDF
                //        };
                //    }



                //var DeviceAdminRecovered = contextDevice.Recover(Escrow, secret);
                //return new ResultRecover() {
                //    Success = false
                //    };
                }
            }


        public override ShellResult MeshList(MeshList Options) {
            //var profiles = CatalogHost.GetProfiles();
            //var accounts = CatalogHost.GetAccountDescriptions();
            throw new NYI();
            //var catalogEntryDevices = CatalogHost.GetCatalogEntryDevices();
            //return new ResultList() {
            //    CatalogEntryDevices = catalogEntryDevices
            //    };

            }

        public override ShellResult MeshGet(MeshGet Options) {
            using (var contextDevice = GetContextDevice(Options)) {
                // pull the Catalog Host

                // list out all the data for the default profile and connection state

                throw new NYI();
                }
            }

        #region // Import and export of profiles - punt on this for now



        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MeshExport(MeshExport Options) {
            // pull the Catalog Host

            // dump the default profile to a file

            throw new NYI();
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult MeshImport(MeshImport Options) {
            // pull the Catalog Host

            // add the profile to the catalog

            throw new NYI();
            }
        #endregion
        }
    }
