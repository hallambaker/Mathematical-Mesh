#region // Copyright - MIT License
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


namespace Goedel.Mesh;


#region // The data classes CatalogApplication, CatalogedApplication

/// <summary>
/// Device catalog. Describes the properties of all devices connected to the user's Mesh account.
/// </summary>
public class CatalogApplication : Catalog<CatalogedApplication> {
    #region // Properties
    ///<summary>The canonical label for the catalog</summary>
    public const string Label = MeshConstants.StoreTypeApplicationTag;

    ///<inheritdocs/>
    public override StoreType StoreType => StoreType.Application;

    ///<summary>The catalog label</summary>
    public override string SequenceDefault => Label;

    #endregion
    #region // Factory methods and constructors

    /// <summary>
    /// Factory delegate
    /// </summary>
    /// <param name="directory">Directory of store file on local machine.</param>
    /// <param name="storeId">Store identifier.</param>
    /// <param name="cryptoParameters">Cryptographic parameters for the store.</param>
    /// <param name="policy">The cryptographic policy to be applied to the catalog.</param>
    /// <param name="keyCollection">Key collection to be used to resolve keys</param>
    /// <param name="decrypt">If true, attempt decryption of payload contents./</param>
    /// <param name="create">If true, create a new file if none exists.</param>
    /// <param name="meshClient">Parent account context used to obtain a mesh client.</param>
    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
    /// <returns>The instance created.</returns>
    public static new Store Factory(
            string directory,
                string storeId,
                IMeshClient meshClient,
                DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[] bitmask = null) =>
        new CatalogApplication(directory, storeId, policy, cryptoParameters, keyCollection, 
            meshClient, decrypt, create, bitmask: bitmask);


    /// <summary>
    /// Constructor for a catalog named <paramref name="storeName"/> in directory
    /// <paramref name="directory"/> using the cryptographic parameters <paramref name="cryptoParameters"/>
    /// and key collection <paramref name="keyCollection"/>.
    /// </summary>
    /// <param name="create">Create a new persistence store on disk if it does not already exist.</param>
    /// <param name="decrypt">Attempt to decrypt the contents of the catalog if encrypted.</param>
    /// <param name="directory">The directory in which the catalog persistence container is stored.</param>
    /// <param name="storeName">The catalog persistence container file name.</param>
    /// <param name="cryptoParameters">The default cryptographic enhancements to be applied to container entries.</param>
    /// <param name="policy">The cryptographic policy to be applied to the container.</param>
    /// <param name="keyCollection">The key collection to be used to resolve keys when reading entries.</param>
    /// <param name="meshClient">Parent account context used to obtain a mesh client.</param>
    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
    public CatalogApplication(
                string directory,
                string storeName = null,
                DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                IMeshClient meshClient = null,
                bool decrypt = true, bool create = true,
                byte[] bitmask = null) :
        base(directory, storeName, policy, cryptoParameters, keyCollection, 
            decrypt: decrypt, create: create, bitmask: bitmask) {
        }

    #endregion
    #region // Class methods

    /// <summary>
    /// Locate the group <paramref name="groupAddress"/> in the catalog.
    /// </summary>
    /// <param name="groupAddress">The address of the group to locate in account@domain 
    /// format.</param>
    /// <returns>The unique catalog identifier for the group.</returns>
    public CatalogedGroup LocateGroup(string groupAddress) =>
            Locate(CatalogedGroup.GetGroupID(groupAddress)) as CatalogedGroup;


    /// <summary>
    /// Return a sequence of SSH applications in the catalog.
    /// </summary>
    /// <returns>Sequence of SSH application instances.</returns>
    public List<CatalogedApplication> GetSsh() {
        var result = new List<CatalogedApplication>();
        foreach (var application in GetEntries) {
            if (application is CatalogedApplicationSsh catalogedApplicationSsh) {
                result.Add(catalogedApplicationSsh);
                }
            }
        return result;
        }

    ///// <summary>
    ///// Return a sequence of SSH hosts advertised in the SSH application instance
    ///// <paramref name="id"/>.
    ///// </summary>
    ///// <param name="id">The SSH application instance identifier.</param>
    ///// <returns>Sequence of SSH hosts.</returns>
    //public IEnumerable<CatalogedApplicationSshHost> GetSshHosts(
    //        string id) => throw new NYI();

    ///// <summary>
    ///// Return a sequence of SSH clients advertised in the SSH application instance
    ///// <paramref name="id"/>.
    ///// </summary>
    ///// <param name="id">The SSH application instance identifier.</param>
    ///// <returns>Sequence of SSH clients.</returns>
    //public IEnumerable<CatalogedApplicationSshHost> GetSshClients(
    //        string id) => throw new NYI();


    /// <summary>
    /// Return a sequence of Mail applications in the catalog.
    /// </summary>
    /// <returns>Sequence of Mail application instances.</returns>
    public List<CatalogedApplication> GetMail() {
        var result = new List<CatalogedApplication>();
        foreach (var entry in PersistenceStore.ObjectIndex) {
            var application = entry.Value;
            if (application.JsonObject is CatalogedApplicationMail catalogedApplicationMail) {
                result.Add(catalogedApplicationMail);
                }
            }
        return result;
        }



    /// <summary>
    /// Return the contact with identifier <paramref name="key"/>.
    /// </summary>
    /// <param name="key">specifies the identifier to return.</param>
    /// <returns>The contact, if found. Otherwise null.</returns>
    public CatalogedApplicationSsh GetSsh(string key) => Get(key) as CatalogedApplicationSsh;


    /// <summary>
    /// Return the contact with identifier <paramref name="key"/>.
    /// </summary>
    /// <param name="key">specifies the identifier to return.</param>
    /// <returns>The contact, if found. Otherwise null.</returns>
    public CatalogedApplicationMail GetMail(string key) => Get(key) as CatalogedApplicationMail;


    #endregion
    }

public partial class CatalogedApplication {

    /// <summary>
    /// The primary key used to catalog the entry.
    /// </summary>
    public override string _PrimaryKey => Key;


    /// <summary>
    /// Construct an activation record for the application.
    /// </summary>
    /// <param name="catalogedDevice">The device to activate.</param>
    /// <returns>The activation record.</returns>
    public abstract ApplicationEntry GetActivation(CatalogedDevice catalogedDevice);


    /// <summary>
    /// Construct an activation record for the application.
    /// </summary>
    /// <returns>The activation record.</returns>
    public abstract KeyData[] GetEscrow();

    /// <summary>
    /// Apply information from the activation entry <paramref name="activationEntry"/>;
    /// </summary>
    /// <param name="activationEntry"></param>
    /// <param name="keyCollection"></param>
    public abstract void Activate(List<ApplicationEntry> activationEntry, IKeyCollection keyCollection);


    /// <summary>
    /// Determine if the device is authorized to use the application.
    /// </summary>
    /// <param name="catalogedDevice">The device record.</param>
    /// <returns>True if the device <paramref name="catalogedDevice"/> is authorized to 
    /// use this application according to the authorization criteria for the device.</returns>
    public virtual bool DeviceAuthorized(CatalogedDevice catalogedDevice) {
        if (catalogedDevice?.ConnectionDevice?.Roles == null) {
            return false;
            }
        if (Grant == null) {
            return false;
            }

        // Check for Deny first.
        if (Deny != null) {
            foreach (var right in Deny) {
                foreach (var match in catalogedDevice.ConnectionDevice.Roles) {
                    if (right.ToLower() == match.ToLower()) {
                        return false;
                        }
                    }
                }
            }

        // Do we have a grant?
        foreach (var right in Grant) {
            foreach (var match in catalogedDevice.ConnectionDevice.Roles) {
                if (right.ToLower() == match.ToLower()) {
                    return true;
                    }
                }
            }

        // Reject it.
        return false;
        }

    /// <summary>
    /// Write a description of the application to <paramref name="output"/>.
    /// </summary>
    /// <param name="output">Destination to which the description is written.</param>
    public abstract void ToBuilder(StringBuilder output);


    }


public partial class CatalogedApplicationNetwork {


    ///<inheritdoc/>
    public override void Activate(List<ApplicationEntry> activationEntry, IKeyCollection keyCollection) {
        }



    ///<inheritdoc/>
    public override KeyData[] GetEscrow() => Array.Empty<KeyData>();

    ///<inheritdoc/>
    public override ApplicationEntry GetActivation(CatalogedDevice catalogedDevice) => throw new NYI();

    ///<inheritdoc/>
    public override void ToBuilder(StringBuilder output) {

        }
    }
#endregion