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


using System.Text;

namespace Goedel.Mesh;

#region // The data classes CatalogNetwork, CatalogedNetwork
/// <summary>
/// Device catalog. Describes the network entries in a Mesh account.
/// </summary>
public class CatalogNetwork : Catalog<CatalogedNetwork> {
    #region // Properties
    ///<summary>The canonical label for the catalog</summary>
    public const string Label = MeshConstants.StoreTypeNetworkTag;

    ///<inheritdocs/>
    public override StoreType StoreType => StoreType.Network;

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
    /// <param name="meshClient">If present provides a means of obtaining a MeshClient instance
    /// which may be used to resolve thresholded key shares.</param>
    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
    /// <returns>The instance created.</returns>
    public static new Store Factory(
            string directory,
                string storeId,
                IMeshClient meshClient = null,
                DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[] bitmask = null) =>
        new CatalogNetwork(directory, storeId, policy, cryptoParameters, 
            keyCollection, decrypt, create, bitmask: bitmask);

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
    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
    public CatalogNetwork(
                string directory,
                string storeName = null,
                DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[] bitmask = null) :
        base(directory, storeName ?? Label,
                    policy, cryptoParameters, keyCollection, 
                    decrypt: decrypt, create: create, bitmask: bitmask) {
        }

    #endregion
    #region // Class methods

    /// <summary>
    /// Locate credential matching the specified service name, ignoring the protocol value.
    /// </summary>
    /// <param name="key">The service to be matched.</param>
    /// <returns>If a match is found, returns the matching entry, otherwise null.</returns>
    public CatalogedNetwork LocateByService(string key) {
        foreach (var network in AsCatalogedType) {
            if (network.Service == key) {
                return network;
                }
            }
        return null;
        }
    #endregion
    }


public partial class CatalogedNetwork {
    #region // Properties
    ///<summary>The primary key is protocol:site </summary>
    public override string _PrimaryKey => PrimaryKey(Protocol, Service);

    /// <summary>
    /// Compute a primary key from the values <paramref name="protocol"/> and
    /// <paramref name="service"/>
    /// </summary>
    /// <param name="protocol">The protocol name.</param>
    /// <param name="service">The service name</param>
    /// <returns>The computed primary key.</returns>
    public static string PrimaryKey(string? protocol, string? service) =>
        $"{protocol ?? ""}:{service ?? ""}";

    #endregion
    #region // Override methods

    ///<inheritdoc/>

    public override void Describe(StringBuilder builder, bool detail = false) => ItemToBuilder(builder);

    ///<inheritdoc/>
    public override void ItemToBuilder(StringBuilder stringBuilder, int indent = 0, IKeyCollection keyCollection = null) {
        stringBuilder.Append($"[{_PrimaryKey}");
        stringBuilder.AppendNotNull(LocalName, $"/{LocalName}");
        stringBuilder.Append($"] {Protocol} {Service} ");
        stringBuilder.AppendNotNull(Password, Password);
        }


    #endregion
    }
#endregion