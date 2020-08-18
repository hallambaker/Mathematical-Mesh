using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Mesh;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Goedel.Protocol;
using System.Diagnostics;
using System.Runtime.Serialization;
using Goedel.IO;

namespace Goedel.Mesh.Client {

    /// <summary>
    /// Desribes the means by which a right is granted.
    /// </summary>
    public enum Degree {
        ///<summary>The holder has direct access to the cryptographic key required
        ///to perform the operation.</summary> 
        Direct,

        ///<summary>The cryptographic key required for the right are divided 
        ///between the device and the Mesh service.</summary> 
        Service,

        ///<summary></summary>
        MultiParty
        }


    public enum Resource {
        ///<summary>Profile root signature key.</summary> 
        ProfileRoot,

        ///<summary>Profile administrative signature key.</summary> 
        ProfileAdmin,


        ///<summary>The credential catalog. Access limited to the service and
        ///administrative devices.</summary>
        CatalogCredential,

        ///<summary>The device catalog</summary> 
        CatalogDevice,

        ///<summary>The contacts catalog</summary>
        CatalogContact,

        ///<summary>The calendar/task catalog</summary>
        CatalogCalendar,

        ///<summary>The bookmark catalog</summary>
        CatalogBookmark,

        ///<summary>The network catalog</summary>
        CatalogNetwork,

        ///<summary>The device catalog</summary>
        CatalogApplication,



        ///<summary>The capability catalog catalog</summary>
        CatalogCapability,

        ///<summary>The publications catalog</summary>
        CatalogPublication,

        ///<summary>The inbound spool. Read access is restricted
        ///to External devices. Write access is limited to the Mesh Service and
        ///to External devices posting completion messages.</summary>
        SpoolInbound,

        ///<summary>The outbound spool. Read/write access is restricted
        ///to External devices.</summary> 
        SpoolOutbound,
        
        ///<summary>The local spool. Write access is limited to administration 
        ///devices. Read access is limited to the specific device to which a message
        ///is directed.</summary> 
        SpoolLocal,

        ///<summary>Service right: Holder is credentialed as an SSH client.</summary> 
        SshClient,

        ///<summary>Service right: Holder is credentialed as an SSH service.</summary> 
        SshService,

        ///<summary>Data right: Holder is  able to Sign/Decrypt OpenPgp messages.</summary> 
        Pgp,

        ///<summary>Data right: Holder is  able to Sign/Decrypt S/MIME messages.</summary> 
        Smime,

        ///<summary>Data right: Holder is able to Sign/Decrypt mesh messages under
        ///the account key.</summary> 
        User,

        ///<summary>Group membership catalog (restricted to GroupAdministrator)</summary> 
        CatalogMember,

        ///<summary>Ability to read data controlled under the group.</summary> 
        GroupMember
        }

    /// <summary>
    /// Access rights. These are principally Decrypt (read), Sign (write) and Authenticate
    /// (login) plus the ability grant these rights. Rights to a specific resource are
    /// limited to either data rights (read/write) or service rights (login).
    /// </summary>
    public enum Access {
        ///<summary>Decrypt (read) access.</summary> 
        Decrypt = 0b0001,
        ///<summary>Sign (write) access, i.e. ability to sign updates to the catalog</summary> 
        Sign = 0b0010,
        ///<summary>Read/decrypt access.</summary> 
        Authenticate = 0b100,

        ///<summary>Ability togrant read/decrypt access.</summary> 
        Grant = 0b010000,
        ///<summary>Ability togrant read/decrypt access.</summary> 
        GrantDecrypt = Grant * Decrypt,
        ///<summary>Ability to grant write/sign access.</summary> 
        GrantSign = Grant * Sign,
        ///<summary>Read/decrypt access.</summary> 
        GrantAuthenticate = Grant * Authenticate,

        ///<summary>Shorthand for Read + Write</summary> 
        ReadWrite = Decrypt | Sign,

        ///<summary>Shorthand for GrantDecrypt + GrantSign</summary> 
        GrantReadWrite = GrantDecrypt | GrantSign,

        ///<summary>Shorthand for all rights</summary> 
        All = ReadWrite | GrantReadWrite,
        }

    public static partial class Extension {

        }


    public  static partial class Rights {

        ///<summary>Dictionary mapping rights identifier to rights description.</summary> 
        public readonly static Dictionary<string, Dictionary<Resource, Access>> DictionaryRights =
            new Dictionary<string, Dictionary<Resource, Access>> {
                ["super"] = RightsSuperAdministrator,
                ["admin"] = RightsAdministrator,
                ["device"] = RightsDevce,
                ["message"] = RightsMessage,
                ["web"] = RightsWeb,
                ["ssh"] = RightsSSH,
                ["pgp"] = RightsPgp,
                ["smime"] = RightsSmime,
                ["groupadmin"] = RightsGroupAdministrator,
                ["groupmember"] = RightsGroupMember,
                };

        ///<summary>Super administrator rights.</summary> 
        public readonly static Dictionary<Resource, Access> RightsSuperAdministrator = 
                    new Dictionary<Resource, Access>() {
             [Resource.ProfileRoot]= Access.Sign ,
             [Resource.ProfileAdmin]= Access.Sign|Access.GrantSign ,
             [Resource.CatalogDevice]= Access.GrantReadWrite
            }.Concat(RightsGrantUser);

        ///<summary>Device admninistrator rights</summary> 
        public readonly static Dictionary<Resource, Access> RightsAdministrator =
                    new Dictionary<Resource, Access>() {
                        // Needed to create and publish device connection
            [Resource.ProfileAdmin]=Access.Sign,
            [Resource.SpoolLocal] = Access.Sign,
            }.Concat (RightsGrantUser);

        ///<summary>Account access administration rights</summary> 
        public readonly static Dictionary<Resource, Access> RightsGrantUser =
                    new Dictionary<Resource, Access>() {
            // Needed to create and publish device connection
            [Resource.CatalogDevice] = Access.ReadWrite,
            [Resource.CatalogContact] = Access.GrantReadWrite,
            [Resource.CatalogCalendar] = Access.GrantReadWrite,
            [Resource.CatalogBookmark] = Access.GrantReadWrite,
            [Resource.CatalogNetwork] = Access.GrantReadWrite,
            [Resource.CatalogApplication] = Access.GrantReadWrite,
            [Resource.CatalogCredential] = Access.GrantReadWrite,
            [Resource.CatalogPublication] = Access.GrantReadWrite,
            [Resource.SpoolInbound] = Access.GrantReadWrite,
            [Resource.SpoolOutbound] = Access.GrantReadWrite
            };

        ///<summary>Rights granted to every device connected to a Mesh. These are currently
        ///limited to the ability to read the network and application catalogs, both of
        ///which will require additional grants to be of use.</summary> 
        public readonly static Dictionary<Resource, Access> RightsDevce =
                    new Dictionary<Resource, Access>() {
            [Resource.CatalogNetwork] = Access.ReadWrite,
            [Resource.CatalogApplication] = Access.Decrypt,
            [Resource.SshService] = Access.Authenticate
                        };

        ///<summary>Rights granted to a device afforded external messaging capabilities in
        ///addition to those of a connected device.
        ///These add the right to read/update the contacts and publications catalogs, to read 
        ///the inbound spool and read/write to the outbound spool and to sign and decrypt
        ///messages under the public credentials for the account.</summary> 
        public readonly static Dictionary<Resource, Access> RightsMessage =
                    new Dictionary<Resource, Access>() {
            [Resource.CatalogContact] = Access.ReadWrite,
            [Resource.SpoolInbound] = Access.Decrypt,
            [Resource.SpoolOutbound] = Access.Sign,
            [Resource.User] = Access.ReadWrite,
            [Resource.CatalogPublication] = Access.ReadWrite
            }.Concat(RightsDevce);

        ///<summary>Rights granted a device afforded Web access in addition to external
        ///messaging. These add the right to read/update the credential, calendar and 
        ///bookmark catalogs.</summary> 
        public readonly static Dictionary<Resource, Access> RightsWeb =
                    new Dictionary<Resource, Access>() {
            [Resource.CatalogCredential] = Access.ReadWrite,
            [Resource.CatalogCalendar] = Access.ReadWrite,
            [Resource.CatalogBookmark] = Access.ReadWrite
            
            }.Concat(RightsMessage);

        ///<summary>Rights granted an SSH client device. This is limited to access to an
        ///SSH authenticator under the account. Which may be a device specific key plus
        ///a credential or the account key.</summary> 
        public readonly static Dictionary<Resource, Access> RightsSSH =
                    new Dictionary<Resource, Access>() {
            [Resource.SshClient] = Access.Authenticate
            };

        ///<summary>Rights granted to a PGP enabled device. This requires external messaging and
        ///the ability to sign/decrypt messages under the PGP keying.</summary> 
        public readonly static Dictionary<Resource, Access> RightsPgp =
                    new Dictionary<Resource, Access>() {
            [Resource.Pgp] = Access.ReadWrite
            }.Concat(RightsMessage);

        ///<summary>Rights granted to an S/MIME enabled device. This requires external messaging and
        ///the ability to sign/decrypt messages under the S/MIME keying.</summary> 
        public readonly static Dictionary<Resource, Access> RightsSmime =
                    new Dictionary<Resource, Access>() {
            [Resource.Smime] = Access.ReadWrite
            }.Concat(RightsMessage);

        ///<summary>Rights granted to a group administrator. An administrator can add users to 
        ///the group but does not automatically gain the ability to access group materials
        ///themselves.</summary> 
        public readonly static Dictionary<Resource, Access> RightsGroupAdministrator =
                    new Dictionary<Resource, Access>() {
            [Resource.CatalogMember]= Access.Sign,
            [Resource.CatalogPublication] = Access.GrantReadWrite,
            [Resource.GroupMember]= Access.GrantReadWrite
            };

        ///<summary>Rights granted to a group member. A group member can read/update the group
        ///publications catalog and decrypt data encrypted under the group key.</summary> 
        public readonly static Dictionary<Resource, Access> RightsGroupMember =
                    new Dictionary<Resource, Access>() {
            [Resource.CatalogPublication] = Access.GrantReadWrite,
            [Resource.GroupMember] = Access.Decrypt        
            };

        /// <summary>
        /// Concatenate the rights specified in <paramref name="append"/> to the dictionary
        /// <paramref name="dictionary"/> and return <paramref name="dictionary"/>. If the
        /// entry already exists, the access rights are combined to specify the union 
        /// of the source access rights.
        /// </summary>
        /// <param name="dictionary">The dictionary to merge entries from 
        /// <paramref name="append"/> into.</param>
        /// <param name="append">The entries to add.</param>
        /// <returns>The parameter <paramref name="dictionary"/>.</returns>
        public static Dictionary<Resource, Access> Concat(
            this Dictionary<Resource, Access> dictionary,
            Dictionary<Resource, Access> append) {

            foreach (var entry in append) {
                if (dictionary.TryGetValue(entry.Key, out var value)) {
                    dictionary.Remove(entry.Key);
                    dictionary.Add(entry.Key, value | entry.Value);
                    }
                dictionary.Add(entry.Key, entry.Value);
                }

            return dictionary;
            }

        }

    }
