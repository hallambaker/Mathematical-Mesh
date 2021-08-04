#region // Copyright
//  © 2021 by Phill Hallam-Baker
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
#endregion



using System.Collections.Generic;

using Goedel.Utilities;

namespace Goedel.Mesh {

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

    /// <summary>
    /// Describes the resources to which access rights are granted.
    /// </summary>
    public enum Resource {
        ///<summary>Profile root signature key.</summary> 
        ProfileRoot,

        ///<summary>Profile administrative signature key.</summary> 
        ProfileAdmin,

        ///<summary>The named store</summary>
        Store,

        ///<summary>Data right: Holder is able to Sign/Decrypt mesh messages under
        ///the account key.</summary> 
        Account,

        ///<summary>Service right: Holder is credentialed to offer services under (name)</summary> 
        Server,

        ///<summary>Service right: Holder may access SSH services as a client.</summary> 
        Ssh,

        ///<summary>Data right: Holder is  able to Sign/Decrypt OpenPgp messages.</summary> 
        Pgp,

        ///<summary>Data right: Holder is  able to Sign/Decrypt S/MIME messages.</summary> 
        Smime,





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


    /// <summary>
    /// An access right.
    /// </summary>
    public struct Right {

        ///<summary>The type of resource to which access rights are granted.</summary> 
        public Resource Resource;

        ///<summary>The named sub-resource (e.g. account).</summary> 
        public string Name;

        ///<summary>The access granted.</summary> 
        public Access Access;

        ///<summary>The form of access (direct, service mediated, etc.)</summary> 
        public Degree Degree;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="resource">The type of resource to which access rights are granted.</param>
        /// <param name="access">The access granted.</param>
        /// <param name="degree">The form of access (direct, service mediated, etc.)</param>
        /// <param name="name">The named sub-resource (e.g. account).</param>
        public Right(Resource resource, Access access = Access.Decrypt, string name = null, Degree degree = Degree.Service) {
            Resource = resource;
            Access = access;
            Name = name;
            Degree = degree;
            }

        ///<summary>Sign (write) access.</summary> 
        public bool Sign => (Access & Access.Sign) == Access.Sign;

        ///<summary>Grant sign (write) access.</summary> 
        public bool GrantSign => (Access & Access.GrantSign) == Access.GrantSign;

        ///<summary>Sign (write) access.</summary> 
        public bool Decrypt => (Access & Access.Decrypt) == Access.Decrypt;

        ///<summary>Grant sign (write) access.</summary> 
        public bool GrantDecrypt => (Access & Access.GrantDecrypt) == Access.GrantDecrypt;

        ///<summary>Sign (write) access.</summary> 
        public bool Authenticate => (Access & Access.Authenticate) == Access.Authenticate;

        ///<summary>Grant sign (write) access.</summary> 
        public bool GrantAuthenticate => (Access & Access.GrantAuthenticate) == Access.GrantAuthenticate;
        }

    /// <summary>
    /// Class containing static identifiers describing rights.
    /// </summary>
    public static partial class Rights {


        static Rights() {
            }

        ///<summary>Name for the  rights set.</summary> 
        public const string IdRightsSuper = "super";
        ///<summary>Name for the  rights set.</summary> 
        public const string IdRightsAdmin = "admin";
        ///<summary>Name for the  rights set.</summary> 
        public const string IdRightsDevice = "device";
        ///<summary>Name for the  rights set.</summary> 
        public const string IdRightsMessage = "message";
        ///<summary>Name for the  rights set.</summary> 
        public const string IdRightsWeb = "web";
        ///<summary>Name for the  rights set.</summary> 
        public const string IdRightsSsh = "ssh";
        ///<summary>Name for the  rights set.</summary> 
        public const string IdRightsPgp = "pgp";
        ///<summary>Name for the  rights set.</summary> 
        public const string IdRightsSmime = "smime";
        ///<summary>Name for the  rights set.</summary> 
        public const string IdRightsGroupadmin = "groupadmin";
        ///<summary>Name for the  rights set.</summary> 
        public const string IdRightsGroupmember = "groupmember";
        ///<summary>Name for the  rights set.</summary> 
        public const string IdRightsStore = "store";




        ///<summary>Account access administration rights</summary> 
        public static List<Right> RightsGrantUser =
                    new() {
                        // Needed to create and publish device connection
                        new Right(Resource.Store, Access.GrantReadWrite, CatalogDevice.Label),
                        new Right(Resource.Store, Access.GrantReadWrite, CatalogContact.Label),
                        new Right(Resource.Store, Access.GrantReadWrite, CatalogTask.Label),
                        new Right(Resource.Store, Access.GrantReadWrite, CatalogBookmark.Label),
                        new Right(Resource.Store, Access.GrantReadWrite, CatalogDevice.Label),
                        new Right(Resource.Store, Access.GrantReadWrite, CatalogNetwork.Label),
                        new Right(Resource.Store, Access.GrantReadWrite, CatalogApplication.Label),
                        new Right(Resource.Store, Access.GrantReadWrite, CatalogPublication.Label),
                        new Right(Resource.Store, Access.GrantReadWrite, SpoolInbound.Label),
                        new Right(Resource.Store, Access.GrantReadWrite, SpoolOutbound.Label)
                        };


        ///<summary>Super administrator rights.</summary> 
        public readonly static List<Right> RightsSuperAdministrator =
                    new() {
                        new Right(Resource.ProfileRoot, Access.Sign),
                        new Right(Resource.ProfileAdmin, Access.Sign | Access.GrantSign),
                        new Right(Resource.Store, Access.ReadWrite, CatalogDevice.Label),
                        };

        ///<summary>Device admninistrator rights</summary> 
        public readonly static List<Right> RightsAdministrator =
                    new List<Right>() {
                        // Needed to create and publish device connection
                        new Right (Resource.ProfileAdmin, Access.Sign),
                        new Right (Resource.Store, Access.Sign, SpoolLocal.Label)
                        }.Concat(RightsGrantUser);



        ///<summary>Rights granted to every device connected to a Mesh. These are currently
        ///limited to the ability to read the network and application catalogs, both of
        ///which will require additional grants to be of use.</summary> 
        public readonly static List<Right> RightsDevce =
                    new() {
                        new Right(Resource.Store, Access.ReadWrite, CatalogNetwork.Label),
                        new Right(Resource.Store, Access.ReadWrite, CatalogApplication.Label)
                        };


        ///<summary>Rights granted to a named service device</summary> 
        public readonly static List<Right> RightsService =
                    new List<Right>() {
                        new Right (Resource.Server, Access.ReadWrite, "*"),
                        }.Concat(RightsDevce);

        ///<summary>Rights granted to a device afforded external messaging capabilities in
        ///addition to those of a connected device.
        ///These add the right to read/update the contacts and publications catalogs, to read 
        ///the inbound spool and read/write to the outbound spool and to sign and decrypt
        ///messages under the public credentials for the account.</summary> 
        public readonly static List<Right> RightsMessage =
                    new List<Right>() {
                        new Right (Resource.Account, Access.ReadWrite|Access.Authenticate),
                        new Right(Resource.Store, Access.ReadWrite, CatalogContact.Label),
                        new Right (Resource.Store, Access.ReadWrite, CatalogPublication.Label),
                        new Right (Resource.Store, Access.ReadWrite, SpoolInbound.Label),
                        new Right (Resource.Store, Access.ReadWrite, SpoolOutbound.Label)
                        }.Concat(RightsDevce);


        ///<summary>Rights granted a device afforded Web access in addition to external
        ///messaging. These add the right to read/update the credential, calendar and 
        ///bookmark catalogs.</summary> 
        public readonly static List<Right> RightsWeb =
                    new List<Right>() {
                        new Right(Resource.Store, Access.ReadWrite, CatalogCredential.Label),
                        new Right(Resource.Store, Access.ReadWrite, CatalogTask.Label),
                        new Right(Resource.Store, Access.ReadWrite, CatalogBookmark.Label)
                        }.Concat(RightsMessage);

        ///<summary>Rights granted an SSH client device. This is limited to access to an
        ///SSH authenticator under the account. Which may be a device specific key plus
        ///a credential or the account key.</summary> 
        public readonly static List<Right> RightsSSH =
                    new() {
                        new Right(Resource.Ssh, Access.Authenticate, "*"),
                        };

        ///<summary>Rights granted to a PGP enabled device. This requires external messaging and
        ///the ability to sign/decrypt messages under the PGP keying.</summary> 
        public readonly static List<Right> RightsPgp =
                    new List<Right>() {
                        new Right (Resource.Pgp, Access.ReadWrite, "*")
                        }.Concat(RightsMessage);

        ///<summary>Rights granted to an S/MIME enabled device. This requires external messaging and
        ///the ability to sign/decrypt messages under the S/MIME keying.</summary> 
        public readonly static List<Right> RightsSmime =
                    new List<Right>() {
                        new Right (Resource.Smime, Access.ReadWrite, "*")
                        }.Concat(RightsMessage);

        ///<summary>Rights granted to a group administrator. An administrator can add users to 
        ///the group but does not automatically gain the ability to access group materials
        ///themselves.</summary> 
        public readonly static List<Right> RightsGroupAdministrator =
                    new() {
                        new Right(Resource.Account, Access.GrantReadWrite),
                        new Right(Resource.Store, Access.GrantReadWrite, CatalogPublication.Label),
                        new Right(Resource.Store, Access.ReadWrite, CatalogMember.Label),
                        };

        ///<summary>Rights granted to a group member. A group member can read/update the group
        ///publications catalog and decrypt data encrypted under the group key.</summary> 
        public readonly static List<Right> RightsGroupMember =
                    new() {
                        new Right(Resource.Account, Access.Decrypt),
                        new Right(Resource.Store, Access.ReadWrite, CatalogPublication.Label),
                        };

        ///<summary>Dictionary mapping rights identifier to rights description.</summary> 
        public readonly static Dictionary<string, List<Right>> DictionaryRights =
            new() {
                [IdRightsSuper] = RightsSuperAdministrator,
                [IdRightsAdmin] = RightsAdministrator,
                [IdRightsDevice] = RightsDevce,
                [IdRightsMessage] = RightsMessage,
                [IdRightsWeb] = RightsWeb,
                [IdRightsSsh] = RightsSSH,
                [IdRightsPgp] = RightsPgp,
                [IdRightsSmime] = RightsSmime,
                [IdRightsGroupmember] = RightsGroupAdministrator,
                [IdRightsStore] = RightsGroupMember,
                };

        /// <summary>
        /// Expand the set of rights described by the role <paramref name="role"/>.
        /// </summary>
        /// <param name="role">The role to expand.</param>
        /// <param name="subresource">Optional sub-respource.</param>
        /// <returns>The list of rights.</returns>
        public static List<Right> GetRights(string role, out string subresource) {
            subresource = null; // NYI: handling of account based rights.

            DictionaryRights.TryGetValue(role, out var dictionary).AssertTrue(UnknownRight.Throw, role);

            return dictionary;

            }


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
        public static List<Right> Concat(
            this List<Right> dictionary,
            List<Right> append) {

            foreach (var entry in append) {
                if (!Update(dictionary, entry)) {
                    dictionary.Add(new Right(entry.Resource, entry.Access, entry.Name, entry.Degree));
                    }
                }

            return dictionary;
            }

        static bool Update(List<Right> rights, Right right) {
            // Can't use foreach because Right is a struct and thus passed by value.
            for (var i = 0; i < rights.Count; i++) {
                var entry = rights[i];
                if ((entry.Resource == right.Resource) & (entry.Name == right.Name)) {
                    entry.Access |= right.Access;
                    rights[i] = entry;
                    return true;
                    }

                }
            return false;
            }


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
