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


namespace Goedel.Mesh.Server;

/// <summary>
/// Catalog tracking the accounts created at a server.
/// </summary>
public class CatalogAccount : Catalog<AccountEntry> {

    ///<summary>The canonical label for the catalog</summary>
    public const string Label = MeshConstants.StoreTypeAccountTag;

    ///<inheritdocs/>
    public override StoreType StoreType => StoreType.Account;

    ///<summary>The catalog label</summary>
    public override string SequenceDefault => Label;

    ///<summary>Dictionary tracking accounts by their account address.</summary> 
    public Dictionary<string, AccountEntry> AccountByAddress = new();

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
    /// <param name="bitmask">The bitmask value to be used to advertise update to this catalog.</param>
    public CatalogAccount(
                string directory,
                string storeName = null,
                DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                IMeshClient meshClient = null,
                bool decrypt = true,
                bool create = true,
                byte[] bitmask = null) :
        base(directory, storeName ?? Label,
                    policy, cryptoParameters, keyCollection,
                    decrypt: decrypt, create: create, bitmask: bitmask) {
        }

    ///<inheritdoc/>
    public override void Intern(SequenceIndexEntry indexEntry) {
        base.Intern(indexEntry);

        if (indexEntry.DataLength > 0) {

            var accountUser = indexEntry.GetJSONObject() as AccountUser;
            //var hostAssignment = accountUser.EnvelopedAccountHostAssignment.Decode();

            //Console.WriteLine($"*** Add account {accountUser.LocalName}");


            if (AccountByAddress.TryGetValue(accountUser.LocalAddress, out var previous)) {
                if (indexEntry.FramePosition > previous.SequenceIndexEntry.FramePosition) {
                    accountUser.SequenceIndexEntry = indexEntry;
                    AccountByAddress.Remove(accountUser.LocalAddress);
                    AccountByAddress.Add(accountUser.LocalAddress, accountUser);
                    }
                }
            else {
                accountUser.SequenceIndexEntry = indexEntry;
                AccountByAddress.Add(accountUser.LocalAddress, accountUser);
                }
            }
        }

    /// <summary>
    /// Attempt to resolve the account address <paramref name="identifier"/>. If
    /// found, return the value true and set <paramref name="account"/> to the
    /// account value. Otherwise return false.
    /// </summary>
    /// <param name="identifier">The account identifier, this may be a service address
    /// or a profile UDF.</param>
    /// <param name="account">The account, if found otherwise null.</param>
    /// <returns>True if successful, otherwise false.</returns>
    public bool TryGetAccountByAny(string identifier, out AccountEntry account) =>
        AccountByAddress.TryGetValue(identifier, out account);


    /// <summary>
    /// Attempt to resolve the account address <paramref name="identifier"/>. If
    /// found, return the value true and set <paramref name="account"/> to the
    /// account value. Otherwise return false.
    /// </summary>
    /// <param name="identifier">The account identifier, this may be a service address
    /// or a profile UDF.</param>
    /// <param name="account">The account, if found otherwise null.</param>
    /// <returns>True if successful, otherwise false.</returns>
    public bool TryGetAccount(string identifier, out AccountEntry account) =>
        AccountByAddress.TryGetValue(identifier, out account);

    }
