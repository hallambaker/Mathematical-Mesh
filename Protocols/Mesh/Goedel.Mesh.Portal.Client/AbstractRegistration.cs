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
using Goedel.Mesh.Portal;

namespace Goedel.Mesh.Portal.Client {

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
    public abstract class MeshMachine : Registration {

        /// <summary>List of pending connection requests.</summary>
        public List<ConnectStartRequest> ConnectStartRequests = new List<ConnectStartRequest>();

        /// <summary>
        /// The a dictionary of personal profiles indexed by fingerprint.
        /// </summary>
        public abstract Dictionary<string, SessionPersonal> PersonalProfilesUDF { get; }

        /// <summary>
        /// The a dictionary of personal profiles indexed by portal account.
        /// </summary>
        public abstract Dictionary<string, SessionPersonal> PersonalProfilesPortal { get; } 


        /// <summary>
        /// A dictionary of application profiles indexed by fingerprint.
        /// </summary>
        public abstract Dictionary<string, SessionApplication> ApplicationProfiles { get; } 


        /// <summary>
        /// A dictionary of default application profiles indexed by application identifier;
        /// </summary>
        public abstract Dictionary<string, string> ApplicationProfilesDefault { get; } 

        /// <summary>
        /// A dictionary of device profiles indexed by fingerprint.
        /// </summary>
        public abstract Dictionary<string, RegistrationDevice> DeviceProfiles { get; } 


        /// <summary>The fingerprint of the device</summary>
        public override string UDF  => Device?.UDF;


        /// <summary>The default profile</summary>
        public virtual SessionPersonal Personal { get; set; }


        /// <summary>The default device</summary>
        public virtual RegistrationDevice Device {get; set;}

        /// <summary>
        /// The registration on the current machine. This will be read from either
        /// the Windows registry (Windows) or the ~/.mmm directory (OSX, Linux).
        /// </summary>
        public static MeshMachine Current { get; set; }

        /// <summary>
        /// Erase the (test) configuration data on the current machine.
        /// </summary>
        public abstract void Erase();

        /// <summary>
        /// Reload configuration data from the current machine persistent store.
        /// </summary>
        public abstract void Reload ();

        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        /// <param name="SignedProfile">Profile to add.</param>
        /// <returns>Registration for the created profile.</returns>
        public abstract RegistrationDevice Add(SignedDeviceProfile SignedProfile);

        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        /// <param name="SignedProfile">Profile to add.</param>
        /// <param name="Request">The connection start request.</param>
        /// <returns>Registration for the created profile.</returns>
        public virtual SessionPersonal Add (SignedPersonalProfile SignedProfile,
                ConnectStartRequest Request) {
            ConnectStartRequests.Add(Request);
            return Add(SignedProfile);
            }

        /// <summary>
        /// Bind the associated profile to the machine store.
        /// </summary>
        /// <param name="SignedProfile">Profile to add.</param>
        /// <returns>Registration for the created profile.</returns>
        public abstract SessionPersonal Add(SignedPersonalProfile SignedProfile);

        /// <summary>
        /// Add the associated profile to the machine store.
        /// </summary>
        /// <param name="ApplicationProfile">Profile to add.</param>
        /// <returns>Registration for the created profile.</returns>
        public abstract SessionApplication Add(ApplicationProfile ApplicationProfile);

        /// <summary>
        /// Locate a device profile by identifier
        /// </summary>
        /// <param name="RegistrationDevice">The returned profile.</param>
        /// <param name="ID">UDF fingerprint of the profile or short form ID</param>
        /// <returns>True if the profile is found, otherwise false.</returns>
        public abstract bool Find(string ID, out RegistrationDevice RegistrationDevice);

        /// <summary>
        /// Locate an application profile by identifier
        /// </summary>
        /// <param name="RegistrationApplication">The returned profile.</param>
        /// <param name="ID">UDF fingerprint of the profile or short form ID</param>
        /// <returns>True if the profile is found, otherwise false.</returns>
        public abstract bool Find(string ID, out SessionApplication RegistrationApplication);

        /// <summary>
        /// Locate a personal profile by identifier
        /// </summary>
        /// <param name="RegistrationPersonal">The returned profile.</param>
        /// <param name="ID">UDF fingerprint of the profile or short form ID</param>
        /// <returns>True if the profile is found, otherwise false.</returns>
        public abstract bool Find(string ID, out SessionPersonal RegistrationPersonal);




        /// <summary>
        /// Find an application profile of a given type.
        /// </summary>
        /// <param name="Type">The type of profile to find.</param>
        /// <param name="PortalAddress">The portal address to fetch the profile from.</param>
        /// <param name="UDF">The profile fingerprint.</param>
        /// <param name="ShortId">The profile short name.</param>
        /// <param name="RegistrationApplication">The returned profile.</param>
        /// <returns>True if a matching profile is found, otherwise, false.</returns>
        public bool Find (
                    out SessionApplication RegistrationApplication,
                    string Type,
                    string PortalAddress = null,
                    string UDF = null,
                    string ShortId = null) {

            // If an application matches by UDF then it is the result, return it.
            if (UDF != null && ApplicationProfiles.TryGetValue(UDF, out RegistrationApplication)) {
                return true;
                }

            // NYI: ignore short names for the time being.

            // Return the default profile for this application type
            // Hack: ignores the Personal Profile value.
            if (Type != null && ApplicationProfilesDefault.TryGetValue(Type, out UDF)) {
                if (ApplicationProfiles.TryGetValue(UDF, out RegistrationApplication)) {
                    return true;
                    }
                }

            RegistrationApplication = null;
            return false;
            }


        }



    /// <summary>
    /// Describes a registration
    /// </summary>
    public abstract partial class Registration {

        ///// <summary>
        ///// The catalog this registration is attached to.
        ///// </summary>
        //public virtual MeshCatalog MeshCatalog { get; }

        /// <summary>The abstract machine a profile registration is attached to</summary>
        public abstract MeshMachine MeshMachine { get; set; }

        /// <summary>
        /// The registered signed profile.
        /// </summary>
        public abstract SignedProfile SignedProfile { get; }

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
        /// Make this the default registration for its type
        /// </summary>
        public abstract void MakeDefault ();

        /// <summary>
        /// Delete the associated profile from the registry
        /// </summary>
        public virtual void Delete() { }

        /// <summary>
        /// Write data to the local machine.
        /// </summary>
        /// <param name="Default">If true, make this the default.</param>        
        public virtual void WriteToLocal(bool Default = true) {
            }



        /// <summary>
        /// Write out the configuration to the portal and the current machine
        /// </summary>
        /// <param name="Default">If true, make this the default.</param>
        public abstract void Write(bool Default = true);

        /// <summary>
        /// Read the configuration from the portal using the current machine as backup
        /// </summary>
        public abstract void Read();

        }


    /// <summary>
    /// Describes a registration
    /// </summary>
    public abstract partial class PortalRegistration : Registration {

        /// <summary>
        /// List of the accounts through which the profile is registered.
        /// </summary>
        public abstract PortalCollection Portals { get; }


        /// <summary>
        /// Client which may be used to interact with the portal on which this
        /// profile is registered.
        /// </summary>
        public abstract MeshClient MeshClient {get; set;
            }


        /// <summary>
        /// Fetch the latest version of the profile version
        /// </summary>
        public abstract void GetFromPortal();

        /// <summary>Update remote and persistence store</summary>
        public virtual void WriteToPortal() {
            MeshClient.Publish(SignedProfile);
            }

        /// <summary>
        /// Write out the configuration to the portal and the current machine
        /// </summary>
        /// <param name="Default">If true, make this the default.</param>
        public override void Write(bool Default = true) {
            WriteToLocal(Default); // NYI flag to record if a pending update should be pushed out
            WriteToPortal();
            }

        /// <summary>
        /// Read the configuration from the portal using the current machine as backup
        /// </summary>
        public override void Read() {
            throw new NYI();
            }

        }


    /// <summary>
    /// Class to track the portal collection. Implements Add, Remove and 
    /// IEnumerable interfaces (enabling foreach to be used);
    /// </summary>
    public class PortalCollection : IEnumerable {
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
        public PortalCollection () {
            }

        /// <summary>
        /// Create from an initialized list of portals. This mechanism simply
        /// adds the portal to the collection, it does not cause it to be
        /// registered.
        /// </summary>
        /// <param name="Portals">Initialized list of portal addresses</param>
        public PortalCollection (IEnumerable<string> Portals) {
            Default = null;
            if (Portals != null) {
                foreach (var Portal in Portals) {
                    Default = Default ?? Portal;
                    Collection.Add(Portal);
                    }
                }
            }

        /// <summary>
        /// Create from an initialized list of portals. This mechanism simply
        /// adds the portal to the collection, it does not cause it to be
        /// registered.
        /// </summary>
        /// <param name="Portals">Initialized list of portal descriptions.</param>
        public PortalCollection (IEnumerable<SerializationPortal> Portals) {
            Default = null;
            if (Portals != null) {
                foreach (var Portal in Portals) {
                    Default = Default ?? Portal.Address;
                    Collection.Add(Portal.Address);
                    }
                }
            }



        /// <summary>
        /// Add a portal to the collection
        /// </summary>
        /// <param name="Portal">The portal to add.</param>
        public virtual void Add (string Portal) {
            Collection.Add(Portal);
            Default = Default ?? Portal; // Hack: Does not currently support multiple portals.
            }

        /// <summary>
        /// Remove a portal address from the collection, return false if not found
        /// </summary>
        /// <param name="Portal">The portal address to remove.</param>
        /// <returns>True if the portal was found, otherwise false.</returns>
        public virtual bool Remove (string Portal) {
            return Collection.Remove(Portal);
            }

        /// <summary>
        /// Return the portal collection as a list
        /// </summary>
        /// <returns>The list of portals.</returns>
        public virtual List<string> ToList () {
            return Collection.ToList();
            }

        /// <summary>
        /// Return the portal collection as an array
        /// </summary>
        /// <returns>The array of portals.</returns>
        public virtual string[] ToArray () {
            return Collection.ToArray();
            }

        // Implementation for the GetEnumerator method.
        IEnumerator IEnumerable.GetEnumerator () {
            return GetEnumerator();
            }

        /// <summary>Enumerator method.</summary>
        /// <returns>The enumerator.</returns>
        public SortedSet<string>.Enumerator GetEnumerator () {
            return Collection.GetEnumerator();
            }

        /// <summary>Serialize the registration to a portal</summary>
        /// <returns>The list of serialized portal entries.</returns>
        public List<SerializationPortal> Serialize () {
            var Result = new List<SerializationPortal>();
            foreach (var Portal in Collection) {
                var Entry = new SerializationPortal() {
                    Address = Portal
                    };
                Result.Add(Entry);
                }
            return Result;

            }

        }

    }
