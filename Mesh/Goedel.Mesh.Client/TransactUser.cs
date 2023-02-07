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


namespace Goedel.Mesh.Client;

/// <summary>
/// Transaction on a Mesh user account.Provides access to the account catalogs and spools.
/// </summary>
public partial class TransactUser : Transaction<ContextUser>, ITransactContextAccount {

    #region // Properties
    /// <summary>The account context in which this transaction takes place.</summary>
    public override ContextUser ContextAccount => ContextUser;
    /// <summary>The account context in which this transaction takes place.</summary>
    public ContextUser ContextUser { get; }

    ///<summary>Returns the application catalog for the account</summary>
    public CatalogApplication GetCatalogApplication() => ContextUser.GetStore(CatalogApplication.Label) as CatalogApplication;

    ///<summary>Returns the contacts catalog for the account</summary>
    public CatalogDevice GetCatalogDevice() => ContextUser.GetStore(CatalogDevice.Label) as CatalogDevice;

    ///<summary>Returns the contacts catalog for the account</summary>
    public CatalogContact GetCatalogContact() => ContextUser.GetStore(CatalogContact.Label) as CatalogContact;

    ///<summary>Returns the credential catalog for the account</summary>
    public CatalogCredential GetCatalogCredential() => ContextUser.GetStore(CatalogCredential.Label) as CatalogCredential;

    ///<summary>Returns the bookmark catalog for the account</summary>
    public CatalogBookmark GetCatalogBookmark() => ContextUser.GetStore(CatalogBookmark.Label) as CatalogBookmark;

    ///<summary>Returns the calendar catalog for the account</summary>
    public CatalogTask GetCatalogCalendar() => ContextUser.GetStore(CatalogTask.Label) as CatalogTask;

    ///<summary>Returns the network catalog for the account</summary>
    public CatalogNetwork GetCatalogNetwork() => ContextUser.GetStore(CatalogNetwork.Label) as CatalogNetwork;

    ///<summary>Returns the inbound spool for the account</summary>
    public SpoolInbound GetSpoolInbound() => ContextUser.GetStore(SpoolInbound.Label) as SpoolInbound;


    ///<inheritdoc/>
    public KeyPair HostEncryptAccount => ContextUser.HostEncryptAccount;

    #endregion
    #region // Constructors

    /// <summary>
    /// Constructor creating transaction instance under the account context
    /// <paramref name="contextUser"/>
    /// </summary>
    /// <param name="contextUser">The account context in which the update
    /// is to be applied.</param>
    public TransactUser(ContextUser contextUser) => ContextUser = contextUser;

    #endregion

    #region // Methods
    /// <summary>
    /// Update the device catalog to add or update <paramref name="catalogedDevice"/>, creating
    /// a recipient decryption entry for the device encryption key <paramref name="encryptionKey"/>.
    /// </summary>
    /// <param name="catalogedDevice">The device description.</param>
    /// <param name="encryptionKey">Encryption key to encrypt a copy of the device description to.</param>
    public void CatalogUpdate(CatalogedDevice catalogedDevice, KeyPair encryptionKey) {

        catalogedDevice.Envelope(encryptionKey: encryptionKey);
        var digest = catalogedDevice.DareEnvelope.GetUnvalidatedDigest();
        catalogedDevice.DareEnvelope.Header.PayloadDigest = digest;

        var digestUDF = UDF.Sha2ToString(digest, 128);

        var accessCapability = new AccessCapability() {
            Id = catalogedDevice.ConnectionService.AuthenticationPublic.KeyIdentifier,
            EnvelopedCatalogedDevice = catalogedDevice.GetEnvelopedCatalogedDevice(),
            CatalogedDeviceDigest = digestUDF,
            Active = true
            };


        Component.Logger.AddAccessCapability(accessCapability._PrimaryKey);
        //Screen.WriteLine($"Add access capability on key {catalogedDevice.ConnectionService.AuthenticationPublic.KeyIdentifier}");
        //Screen.WriteLine($"    Primary key {accessCapability._PrimaryKey}");
        //Screen.WriteLine($"Catalog update: {accessCapability.CatalogedDeviceDigest} Entries: {catalogedDevice.ApplicationEntries?.Count}");


        var catalogedAccess = new CatalogedAccess() {
            Capability = accessCapability
            };

        var catalogDevice = GetCatalogDevice();
        var catalogAccess = GetCatalogAccess();

        CatalogUpdate(catalogAccess, catalogedAccess);
        CatalogUpdate(catalogDevice, catalogedDevice);

        if (ContextAccount.CatalogedDevice?.DeviceUdf == catalogedDevice.DeviceUdf) {
            ContextAccount.UpdateCatalogedMachine(catalogedDevice, digestUDF, false);
            }

        }



    /// <summary>
    /// Add the application described in <paramref name="catalogedApplication"/> to the
    /// profile and create application entries for each authorized device.
    /// </summary>
    /// <param name="catalogedApplication"></param>
    public void ApplicationCreate(
                CatalogedApplication catalogedApplication) {

        var escrow = catalogedApplication.GetEscrow();
        catalogedApplication.EnvelopedEscrow =
                    ContextUser.EscrowSeed(escrow);

        var catalog = GetCatalogApplication();
        CatalogUpdate(catalog, catalogedApplication);

        var catalogDevice = GetCatalogDevice();
        var updated = new List<CatalogedDevice>();
        foreach (var device in catalogDevice.GetEntries) {

            //Screen.WriteLine("Got device");
            if (catalogedApplication.DeviceAuthorized(device)) {
                var applicationEntry = catalogedApplication.GetActivation(device);

                device.ApplicationEntries ??= new();
                device.ApplicationEntries.Add(applicationEntry);

                updated.Add(device);
                }
            }
        foreach (var device in updated) {

            var connectionDevice = device.EnvelopedConnectionDevice.Decode();
            var encryptionKey = connectionDevice.Encryption.GetKeyPair();
            CatalogUpdate(device, encryptionKey);


            //CatalogUpdate(catalogDevice, device);
            }

        }

    // Phase2: Update applications after grant
    /// <summary>
    /// Update the application
    /// </summary>
    /// <param name="catalogedApplication">The updated application entry</param>
    public void ApplicationUpdate(
        CatalogedApplication catalogedApplication) => throw new NYI(this, catalogedApplication);

    #endregion
    }
