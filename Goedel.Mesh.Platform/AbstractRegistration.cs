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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Goedel.Utilities;
using Goedel.Mesh;

namespace Goedel.Mesh.Platform {

    /// <summary>
    /// Describe the means by which a registration is made.
    /// </summary>
    public enum RegistrationType {
        /// <summary>
        /// Data is stored in a Windows registry key
        /// </summary>
        Registry,

        /// <summary>
        /// Data is stored in a file in the ~/.mmm directory.
        /// </summary>
        File,

        /// <summary>
        /// Data was previously registered but has been deleted.
        /// </summary>
        Removed
        }



    /// <summary>
    /// Describes a set of registered profiles on a particular machine, usually the
    /// current machine.
    /// </summary>
    public abstract class RegistrationMachine : Registration {

        static RegistrationMachine _Current;

        /// <summary>
        /// The a dictionary of personal profiles indexed by fingerprint.
        /// </summary>
        public abstract Dictionary<string, RegistrationPersonal> PersonalProfilesUDF { get; }

        /// <summary>
        /// The a dictionary of personal profiles indexed by portal account.
        /// </summary>
        public abstract Dictionary<string, RegistrationPersonal> PersonalProfilesPortal { get; } 


        /// <summary>
        /// A dictionary of application profiles indexed by fingerprint.
        /// </summary>
        public abstract Dictionary<string, RegistrationApplication> ApplicationProfiles { get; } 


        /// <summary>
        /// A dictionary of default application profiles indexed by application identifier;
        /// </summary>
        public abstract Dictionary<string, string> ApplicationProfilesDefault { get; } 

        /// <summary>
        /// A dictionary of device profiles indexed by fingerprint.
        /// </summary>
        public abstract Dictionary<string, RegistrationDevice> DeviceProfiles { get; } 


        /// <summary>The fingerprint of the device</summary>
        public override string UDF {
            get { return Device?.UDF; }
            }


        // The default profile
        public virtual RegistrationPersonal Personal { get; set; }

        // The default device
        public virtual RegistrationDevice Device {get; set;}

        /// <summary>
        /// The registration on the current machine. This will be read from either
        /// the Windows registry (Windows) or the ~/.mmm directory (OSX, Linux).
        /// </summary>
        public static RegistrationMachine Current { get; set; }

        /// <summary>
        /// Write out the configuration to the current machine.
        /// </summary>
        public abstract void Write();

        /// <summary>
        /// Erase the (test) configuration data on the current machine.
        /// </summary>
        public abstract void Erase();


        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        /// <param name="SignedProfile">Profile to add.</param>
        /// <returns>Registration for the created profile.</returns>
        public abstract RegistrationDevice Add(SignedDeviceProfile SignedProfile);



        /// <summary>
        /// Bind the associated profile to the machine store.
        /// </summary>
        /// <param name="SignedProfile">Profile to add.</param>
        /// <param name="Portals">Portals to bind the profile to.</param>
        /// <returns>Registration for the created profile.</returns>
        public abstract RegistrationPersonal Add(SignedPersonalProfile SignedProfile, 
            List<string> Portals);

        /// <summary>
        /// Bind the associated profile to the machine store.
        /// </summary>
        /// <param name="SignedProfile">Profile to add.</param>
        /// <param name="Portals">Portals to bind the profile to.</param>
        /// <returns>Registration for the created profile.</returns>
        public virtual RegistrationPersonal Add(SignedPersonalProfile SignedProfile, string Portal) {
            var Portals = new List<string>() { Portal };
            return Add(SignedProfile, Portals);

            }


        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        /// <param name="SignedProfile">Profile to add.</param>
        /// <returns>Registration for the created profile.</returns>
        public abstract RegistrationApplication Add(SignedApplicationProfile SignedProfile);

        /// <summary>
        /// Locate a device profile by identifier
        /// </summary>
        /// <param name="RegistrationDevice">The returned profile.</param>
        /// <param name="ID">UDF fingerprint of the profile or short form ID</param>
        /// <returns>True if the profile is found, otherwise false.</returns>
        public abstract bool Find(string ID, out RegistrationDevice RegistrationDevice);

        /// <summary>
        /// Locate a device profile by identifier
        /// </summary>
        /// <param name="RegistrationDevice">The returned profile.</param>
        /// <param name="ID">UDF fingerprint of the profile or short form ID</param>
        /// <returns>True if the profile is found, otherwise false.</returns>
        public abstract bool Find(string ID, out RegistrationApplication RegistrationApplication);

        /// <summary>
        /// Locate a device profile by identifier
        /// </summary>
        /// <param name="RegistrationDevice">The returned profile.</param>
        /// <param name="ID">UDF fingerprint of the profile or short form ID</param>
        /// <returns>True if the profile is found, otherwise false.</returns>
        public abstract bool Find(string ID, out RegistrationPersonal RegistrationPersonal);

        }



    /// <summary>
    /// Describes a registration
    /// </summary>
    public abstract partial class Registration {

        /// <summary>
        /// The profile fingerprint
        /// </summary>
        public abstract string UDF { get; }

        /// <summary>
        /// The location of the registration.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The type of registration (i.e. Registry or file)
        /// </summary>
        public RegistrationType Type { get; set; }

        /// <summary>
        /// Fetch the latest version of the profile version
        /// </summary>
        public abstract void Refresh();

        /// <summary>
        /// Delete the associated profile from the registry
        /// </summary>
        public virtual void Delete() { }

        /// <summary>
        /// Update the associated profile in the registry
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// Write data to the registry.
        /// </summary>
        public virtual void ToRegistry() {
            throw new NYI("Write data to registry");
            }


        }





    /// <summary>
    /// Class to track the portal collection. Implements Add, Remove and 
    /// IEnumerable interfaces (enabling foreach to be used);
    /// </summary>
    public abstract class PortalCollection : IEnumerable {
        SortedSet<string> Collection = new SortedSet<string>();

        /// <summary>
        /// The Default portal
        /// </summary>
        public virtual string Default {
            get; set;
            }

        /// <summary>
        /// Create empty list
        /// </summary>
        /// <param name="Portals"></param>
        public PortalCollection() {
            }

        /// <summary>
        /// Create from an initialized list of portals. This mechanism simply
        /// adds the portal to the collection, it does not cause it to be
        /// registered.
        /// </summary>
        /// <param name="Portals"></param>
        public PortalCollection(IEnumerable<string> Portals) {
            Default = null;
            if (Portals != null) {
                foreach (var Portal in Portals) {
                    Default = Default ?? Portal;
                    Collection.Add(Portal);
                    }
                }
            }

        /// <summary>
        /// Add a portal to the collection
        /// </summary>
        /// <param name="Portal"></param>
        public virtual void Add(string Portal) {
            Collection.Add(Portal);
            }

        /// <summary>
        /// Remove a portal from the collection, return false if not found
        /// </summary>
        /// <param name="Portal"></param>
        /// <returns></returns>
        public virtual bool Remove(string Portal) {
            return Collection.Remove(Portal);
            }

        /// <summary>
        /// Return the portal collection as a list
        /// </summary>
        /// <returns></returns>
        public virtual List<string> ToList () {
            return Collection.ToList();
            }

        /// <summary>
        /// Return the portal collection as a list
        /// </summary>
        /// <returns></returns>
        public virtual string[] ToArray() {
            return Collection.ToArray();
            }

        // Implementation for the GetEnumerator method.
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
            }

        public SortedSet<string>.Enumerator GetEnumerator() {
            return Collection.GetEnumerator();
            }

        }

    }
