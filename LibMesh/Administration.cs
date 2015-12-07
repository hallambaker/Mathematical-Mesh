using System;
using System.Collections.Generic;
using Goedel.Registry;
using Goedel.Persistence;
using Goedel.LibCrypto;
using Goedel.LibCrypto.PKIX;

namespace Goedel.Mesh {
    //public partial class AdministrationProfile {
    //    public PublicKey AdminSignatureKey;



    //    public AdministrationProfile(DeviceProfile DeviceProfile) {

    //        }



    //    ///// <summary>
    //    ///// Create a new administration profile. This can only be done on
    //    ///// a machine that has access to the POSK.
    //    ///// </summary>
    //    ///// <param name="SignatureAlgorithmID">Signature algorithm to use.</param>
    //    ///// <param name="Signer">Signing Key, usually the POSK.</param>
    //    //public AdministrationProfile(CryptoAlgorithmID SignatureAlgorithmID,
    //    //            PublicKey Signer) {

    //    //    AdminSignatureKey = new PublicKey(KeyType.POSK,
    //    //            Application.CA, SignatureAlgorithmID, Signer);

    //    //    Names = new List<string> ();
    //    //    Names.Add (Profile.AdminKey);
    //    //    }

    //    ///// <summary>
    //    ///// Complete a device entry for this profile.
    //    ///// </summary>
    //    ///// <param name="Entry">Device entry to complete</param>
    //    ///// <param name="AdminKey">Signature key.</param>
    //    //public override void CompleteDeviceEntry(DeviceProfile Profile, DeviceEntry Entry,
    //    //            PublicKey AdminKey) {

    //    //    //Since Admin profiles are signed using the POSK and not the
    //    //    //device administration key, do nothing here.

    //    //    }

    //    ///// <summary>
    //    ///// Create a device entry request to a device profile template.
    //    ///// </summary>
    //    ///// <param name="Profile">Template profile to add the request to</param>
    //    //public override void MakeDeviceEntryRequests(DeviceProfile Profile) {
    //    //    var Entry = new DeviceEntry(Profile);
    //    //    Entry.SignatureKey = AdminSignatureKey;

    //    //    if (Entries == null) {
    //    //        Entries = new List<DeviceEntry>();
    //    //        }
    //    //    Entries.Add(Entry);
    //    //    }


    //    }
    }
