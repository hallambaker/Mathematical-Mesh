//   Copyright © 2015 by Comodo Group Inc.
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
//  
//  
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Mesh.Server;

namespace Goedel.Mesh.Platform.Linux {


    /// <summary>
    /// Describes the registration of as profile on as machine. This includes
    /// the fingerprint, the cached profile data and the list of portal entries
    /// to which the profile is bound.
    /// </summary>
    public partial class RegistrationPersonalLinux : RegistrationPersonal {


        /// <summary>
        /// The profile fingerprint
        /// </summary>
        public override string UDF { get => SignedPersonalProfile?.UDF;  } 

        /// <summary>
        /// Profiles associated with this account in chronological order.
        /// </summary>
        public override SortedList<DateTime, SignedProfile> Profiles { get; set; }


        /// <summary>
        /// List of the accounts through which the profile is registered.
        /// </summary>
        public override PortalCollection Portals { get; }

        /// <summary>
        /// Fetch the latest version of the profile version
        /// </summary>
        public override void GetFromPortal() {
            var NewPersonal = MeshClient.GetPersonalProfile();
            // NYI: Here should check to see which is more recent.
            SignedPersonalProfile = NewPersonal;
            }

        public string Archive { get; set; }


        DateTime? WasMadeDefault = null;

        /// <summary>
        /// Read a personal registration from a file
        /// </summary>
        /// <param name="UDF">File fingerprint</param>
        /// <param name="File">Filename on local machine</param>
        public RegistrationPersonalLinux (RegistrationMachine Machine, 
                        string File, IEnumerable<string> Portals = null) {

            RegistrationMachine = Machine;
            var Serialization = SerializationPersonal.FromFile(File);
            WasMadeDefault = Serialization.Default;
            RegistrationMachineLinux.SetDefaultPersonal(this, Serialization.Default);
            SignedPersonalProfile = Serialization.Profile;
            this.Portals = new PortalCollectionLinux(Serialization.Portals);
            }


        public RegistrationMachineLinux RegistrationMachineLinux {
            get => RegistrationMachine as RegistrationMachineLinux;
            }

        /// <summary>The abstract machine a profile registration is attached to</summary>
        public override RegistrationMachine RegistrationMachine { get; set; }

        /// <summary>
        /// Register a personal profile in the Windows registry
        /// </summary>
        /// <param name="Profile">The personal profile</param>
        /// <param name="Portals">The list of portals.</param>
        public RegistrationPersonalLinux (SignedPersonalProfile Profile, 
                        RegistrationMachine Machine,
                        IEnumerable<string> Portals = null) {
            SignedPersonalProfile = Profile;
            RegistrationMachine = Machine;
            this.Portals = new PortalCollectionLinux(Portals);
            WriteToLocal();
            RegistrationMachine.Personal = RegistrationMachine.Personal ?? this;
            }


        /// <summary>
        /// Add a portal to this registration. The portal account must have been 
        /// created previously. Only the local portal is written to.
        /// </summary>
        /// <param name="AccountID"></param>
        /// <param name="MeshClient"></param>
        public override void AddPortal(string AccountID, MeshClient MeshClient = null, bool Create = false) {
            Portals.Add(AccountID);
            WriteToLocal();
            }


        /// <summary>Update portal entries.</summary>
        public override void WriteToPortal() {
            var PersonalProfile = SignedPersonalProfile.PersonalProfile;
            PersonalProfile.Sign();
            SignedPersonalProfile = PersonalProfile.SignedPersonalProfile;
            WriteToLocal();
            MeshClient.Publish(SignedPersonalProfile);
            }

        /// <summary>
        /// Write values to file
        /// </summary>
        /// <param name="Default">If true, mark as the default device profile.</param>
        public override void WriteToLocal (bool Default = true) {
            var FileName = RegistrationMachineLinux.FilePersonalProfile(UDF);
            Directory.CreateDirectory(RegistrationMachineLinux.RootDirectory);
            var Serialization = Serialize();
            File.WriteAllText(FileName, Serialization.ToString());
            }

        /// <summary>
        /// Make this the default personal profile for future operations.
        /// </summary>
        /// <param name="Force"></param>
        public override void MakeDefault () {
            WasMadeDefault = DateTime.Now;
            }
        }

    }
