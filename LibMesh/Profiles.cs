using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Registry;
using Goedel.Persistence;
using Goedel.LibCrypto;
using Goedel.LibCrypto.PKIX;
using Goedel.Debug;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh {

    /// <summary>
    /// Index term for retrieving mesh profiles.
    /// </summary>
    public class MeshIndexTerm {

        /// <summary>
        /// Prefix for unique ID terms
        /// </summary>
        public const string UniqueID = "UniqueID";

        /// <summary>
        /// Prefix for user profile terms.
        /// </summary>
        public const string KeyUserProfile = "UserProfile";
        
        /// <summary>
        /// Persistence store where terms are to be interned.
        /// </summary>
        public PersistenceStore PersistenceStore;

        /// <summary>
        /// Index of objects by unique ID
        /// </summary>
        public PersistenceIndex IndexUniqueID;

        /// <summary>
        /// Index of objects by account name.
        /// </summary>
        public PersistenceIndex UserProfilesByAccount;

        /// <summary>
        /// Construct a new index term for the specified persistence store.
        /// </summary>
        /// <param name="PersistenceStore"></param>
        public MeshIndexTerm(PersistenceStore PersistenceStore) {
            this.PersistenceStore = PersistenceStore;
            UserProfilesByAccount = PersistenceStore.GetIndex(KeyUserProfile);
            IndexUniqueID = PersistenceStore.GetIndex(UniqueID);
            }

        /// <summary>
        /// Set index terms for a unique identifier.
        /// </summary>
        /// <param name="KeyDatas"></param>
        /// <param name="ID"></param>
        public static void SetUnique(List<IndexTerm> KeyDatas, string ID) {
            }

        }

    /// <summary>
    /// Base class for all profiles.
    /// </summary>
    public partial class Profile {

        /// <summary>
        /// List of all the index terms this profile can be retrieved through.
        /// </summary>
        public List<IndexTerm> IndexTerms {
            get { return GetIndex(); }
            }

        /// <summary>
        /// Get the unique identifier for this object.
        /// </summary>
        public string UniqueID {
            get { return Identifier; }
            }

        /// <summary>
        /// Get a list of indexes for this profile.
        /// </summary>
        /// <returns></returns>
        public virtual List<IndexTerm> GetIndex() {
            List<IndexTerm> Result = new List<IndexTerm>();

            Result.Add(new IndexTerm(MeshIndexTerm.UniqueID, UniqueID)); // as uniqueID
            Result.Add(new IndexTerm(Tag(), Identifier)); // as profile type

            return Result;
            }

        /// <summary>
        /// Every profile has a unique UDF identifier.
        /// </summary>
        public virtual string UDF {
            get { return null; }
            }


        /// <summary>
        /// Prepare the profile for export.
        /// </summary>
        public virtual void Package() {
            // Do nothing.
            }


        /// <summary>
        /// Unpack the profile and signed sub profiles.
        /// </summary>
        public virtual void Unpack() {
            // Do nothing.
            }

        }

    public partial class ApplicationProfileEntry {

        /// <summary>
        /// The application profile object this entry belongs to.
        /// </summary>
        public ApplicationProfile ApplicationProfile;

        /// <summary>
        /// Create a new entry for the specified profile.
        /// </summary>
        /// <param name="ApplicationProfile">Profile to link to.</param>
        public ApplicationProfileEntry(ApplicationProfile ApplicationProfile) {

            Identifier = ApplicationProfile.Identifier;
            Type = ApplicationProfile.Tag();
            this.ApplicationProfile = ApplicationProfile;
            }

        }


    public partial class ApplicationProfile : Profile {

        /// <summary>
        /// The personal profile to which this is attached.
        /// </summary>
        protected PersonalProfile PersonalProfile;

        /// <summary>
        /// This application profile's entry in the parent personal profile.
        /// </summary>
        protected ApplicationProfileEntry ApplicationProfileEntry;

        /// <summary>
        /// Return a signed version of this profile.
        /// </summary>
        public SignedApplicationProfile Signed {
            get {
                return new SignedApplicationProfile(this);
                }
            }

        /// <summary>
        /// Return the private data of this profile as raw data bytes.
        /// </summary>
        protected virtual byte[] GetPrivateData {
            get { return null;  }
            }


        /// <summary>
        /// Create a new application profile and add it to the UserProfile.
        /// </summary>
        /// <param name="PersonalProfile">The personal profile to attach to.</param>
        /// <param name="Type">Application type</param>
        /// <param name="Tag">Friendly name</param>
        public ApplicationProfile(PersonalProfile PersonalProfile, 
                    string Type, string Tag) {
            this.PersonalProfile = PersonalProfile;

            Identifier = Goedel.LibCrypto.UDF.Random ();

            ApplicationProfileEntry = new ApplicationProfileEntry(this);
            ApplicationProfileEntry.Friendly = Tag;

            // Create admin entry for this device

            ApplicationProfileEntry.SignID = new List<string> ();
            ApplicationProfileEntry.SignID.Add(PersonalProfile.SignedDeviceProfile.Identifier);


            ApplicationProfileEntry.DecryptID = new List<string>();
            ApplicationProfileEntry.DecryptID.Add(PersonalProfile.SignedDeviceProfile.Identifier);


            //// Add this application into the set.
            if (PersonalProfile.Applications == null) {
                PersonalProfile.Applications = new List<ApplicationProfileEntry>();
                }
            PersonalProfile.Applications.Add(ApplicationProfileEntry);
            }




        /// <summary>
        /// Connect an application profile read from store to a PersonalProfile object.
        /// </summary>
        /// <param name="PersonalProfile"></param>
        public void Link (PersonalProfile PersonalProfile) {
            this.PersonalProfile = PersonalProfile;

            ApplicationProfileEntry = PersonalProfile.GetApplicationEntry(Identifier);
            if (ApplicationProfileEntry == null) throw new Throw("Not found");

            ApplicationProfileEntry.ApplicationProfile = this;
            }

        /// <summary>
        /// Locate a signature key known to this device that 
        /// is authorized to sign this profile.
        /// </summary>
        /// <returns>An authorized key pair.</returns>
        public KeyPair GetSignatureKey() {
            // Check that the device is allowed to sign
            if (!CanSign(PersonalProfile.SignedDeviceProfile)) return null;

            var DeviceProfile = PersonalProfile.SignedDeviceProfile.Data;

            var Result = KeyPair.FindLocal(DeviceProfile.DeviceSignatureKey.UDF);
            return Result;
            }

        /// <summary>
        /// Determine if the specified key is allowed to sign this profile.
        /// </summary>
        /// <param name="SignedDeviceProfile"></param>
        /// <returns>True if signing is authorized, otherwise false.</returns>
        public bool CanSign (SignedDeviceProfile SignedDeviceProfile) {
            if (ApplicationProfileEntry == null) throw new Throw("Broken");
            if (ApplicationProfileEntry.SignID == null) throw new Throw("Broken");
            if (SignedDeviceProfile == null) throw new Throw("Broken");

            foreach (var Entry in ApplicationProfileEntry.SignID) {
                if (SignedDeviceProfile.Identifier == Entry) {
                    return true;
                    }
                }

            return false;
            }

        /// <summary>
        /// Add the specified device to the application profile.
        /// </summary>
        /// <param name="DeviceProfile"></param>
        public virtual void AddDevice(SignedDeviceProfile DeviceProfile) {
            Debug.Trace.TBS("Should check to see if there is already a device entry and remove it.");
            var DeviceEntry = MakeEntry(DeviceProfile);

            Entries = Entries == null ? new List<DeviceEntry>() : Entries;
            Entries.Add(DeviceEntry);
            }

        /// <summary>
        /// Encrypt the private data and create a decryption key for each device.
        /// </summary>
        public virtual void EncryptPrivate() {
            if (ApplicationProfileEntry == null) throw new Throw("Broken");
            if (ApplicationProfileEntry.DecryptID == null) throw new Throw("Broken");

            EncryptedData = new JoseWebEncryption(GetPrivateData);

            foreach (var Recipient in ApplicationProfileEntry.DecryptID) {
                // extract the device profile from the personal profile
                var SignedDeviceProfile = PersonalProfile.GetDeviceProfile(Recipient);
                var DeviceProfile = SignedDeviceProfile.Data;
                var EncryptionKey = DeviceProfile.DeviceEncryptiontionKey;

                // create a recipient entry

                EncryptedData.Add(EncryptionKey.KeyPair);
                }
            Trace.NYI("Add entry here for the escrow key for this application");

            }


        /// <summary>
        /// Decrypt the private data portion of the profile.
        /// </summary>
        /// <returns></returns>
        public virtual byte[] DecryptPrivate() {
            var SignedDeviceProfile = PersonalProfile.SignedDeviceProfile;
            var DeviceProfile = SignedDeviceProfile.Data;
            var EncryptionKey = DeviceProfile.DeviceEncryptiontionKey;

            Trace.NYI("Decrypt data");

            if (ApplicationProfileEntry == null) throw new Throw("Broken");
            if (ApplicationProfileEntry.DecryptID == null) throw new Throw("Broken");

            var Result = EncryptedData.Decrypt(EncryptionKey.KeyPair);

            return Result;
            }





        /// <summary>
        /// Really not sure if this is needed any more.
        /// </summary>
        /// <param name="DeviceProfile"></param>
        /// <returns>Who can tell?</returns>

        public virtual DeviceEntry MakeEntry(SignedDeviceProfile DeviceProfile) {
            var DeviceEntry = new DeviceEntry();
            DeviceEntry.UDF = DeviceProfile.UDF;
            return DeviceEntry;
            }


        }

    }
