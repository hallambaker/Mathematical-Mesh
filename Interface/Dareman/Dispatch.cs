using System;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Command;
using Goedel.IO;
using Goedel.Mesh;
using Goedel.Mesh.Portal.Client;
using Goedel.Recrypt;

//using Goedel.Confirm;
using Goedel.Recrypt.Client;
using Goedel.Mesh.Platform.Windows;
using Goedel.Cryptography;

namespace Goedel.Mesh.DareMan {

    public partial class Shell : _Shell {

        static MeshMachine MeshMachine;     // The actual machine details

        SessionPersonal SessionPersonal = MeshMachine?.Personal;    // Always the default profile.



        static void Main (string[] Args) {
            var CLI = new CommandLineInterpreter();
            var Dispatch = new Shell();
            CLI.MainMethod(Dispatch, Args);
            }


        public Shell () {

            
            MeshRecrypt.Initialize();
            

            //MeshConfirm.Initialize();

            Mesh.Initialize(true);

            MeshMachine = MeshMachine.Current;
            

            
            }


        public override void Erase(Erase Options) => MeshMachine.EraseTest(); // remove previous test data

        /// <summary>
        /// Register a new account.
        /// </summary>
        /// <param name="Options"></param>
        public override void Register (Register Options) {
            var AccountID = Options.AccountID.Value;

            var DeviceRegistration = MeshMachine.GetDevice(DeviceNew: true,
                    DeviceID: "Default", DeviceDescription: "A test device");

            var PersonalProfile1 = new PersonalProfile(DeviceRegistration.DeviceProfile);

            var MeshClient = new MeshClient(AccountID);
            var SessionPersonal = MeshMachine.CreateAccount(AccountID, PersonalProfile1, MeshClient);

            var RecryptProfile = new RecryptProfile(SessionPersonal.PersonalProfile, AccountID);

            // Add all devices as administrator devices
            foreach (var Device in SessionPersonal.PersonalProfile.Devices) {
                RecryptProfile.AddDevice(Device.DeviceProfile, true);
                }

            var SessionRecrypt = new SessionRecrypt(SessionPersonal, RecryptProfile);

            SessionAccount.Create(SessionPersonal, AccountID,
                new List<string> { AccountID },
                new List<SignedApplicationProfile> { RecryptProfile.SignedApplicationProfile });

            }


        

        /// <summary>
        /// Create a Recryption Group
        /// </summary>
        /// <param name="Options">Command line options</param>
        public override void Create (Create Options) {
            // Process the command line data
            var GroupID = Options.GroupID.Value;
            SessionPersonal = MeshMachine.GetPersonal("alice@cryptomesh.org");

            var RecryptSession = SessionPersonal.SessionRecryption();
            var Group = RecryptSession.CreateGroup(GroupID);
            }

        /// <summary>
        /// Add a member to a recryption group
        /// </summary>
        /// <param name="Options">Command line options</param>
        public override void Add (Add Options) {
            // Process the command line data
            var GroupID = Options.GroupID.Value;
            var AccountID = Options.AccountID.Value;
            SessionPersonal = MeshMachine.GetPersonal("alice@cryptomesh.org");

            var RecryptSession = SessionPersonal.SessionRecryption();
            var Group = RecryptSession.GetRecryptionGroup(GroupID);
            RecryptSession.AddMember(Group, AccountID);
            }

        /// <summary>
        /// Remove a member from a recryption group
        /// </summary>
        /// <param name="Options">Command line options</param>
        public override void Delete (Delete Options) {
            // Process the command line data
            var GroupID = Options.GroupID.Value;
            var AccountID = Options.AccountID.Value;

            var RecryptSession = SessionPersonal.SessionRecryption();
            var Group = RecryptSession.GetRecryptionGroup(GroupID);
            RecryptSession.RemoveMember(Group, AccountID);
            }

        /// <summary>
        /// Encrypt a file to a recryption group
        /// </summary>
        /// <param name="Options">Command line options</param>
        public override void Encrypt (Encrypt Options) {
            // Process the command line data,
            var InputFile = Options.Input.Value;
            var OutputFile = FileTools.DefaultFile(Options.Output.Value, Options.Input.Value, "dare");
            var Group = Options.Group.Value;

            var RecryptionKey = SessionPersonal.GetEncryptionKey(Group);
            RecryptionKey.Encrypt(InputFile, OutputFile);
            }

        /// <summary>
        /// Decrypt a file using decryption and/or recryption keys available to the user.
        /// </summary>
        /// <param name="Options">Command line options</param>
        public override void Decrypt (Decrypt Options) {
            // Process the command line data,
            var InputFile = Options.Input.Value;
            var OutputFile = Options.Output.Value;

            SessionPersonal = MeshMachine.GetPersonal("bob@cryptomesh.org");
            SessionPersonal.DecryptDARE(InputFile, OutputFile);
            }


        /// <summary>
        /// Decrypt a file using decryption and/or recryption keys available to the user.
        /// </summary>
        /// <param name="Options">Command line options</param>
        public override void Recrypt (Recrypt Options) {
            // Process the command line data,
            var InputFile = Options.Input.Value;
            var OutputFile = Options.Output.Value;

            try {
                SessionPersonal = MeshMachine.GetPersonal("bob@cryptomesh.org");
                SessionPersonal.RecryptDARE(InputFile, OutputFile);
                }
            catch {

                Console.WriteLine("Could not find decryption key");
                }

            }

        }

    }
