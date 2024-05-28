﻿using Goedel.Cryptography.Dare;



using System.Xml.Linq;

namespace Goedel.Everything;

#region // Bindings to classes specified through the Guigen schema.



// Documented in Guigen output
public partial class MessageSection : IHeadedSelection{

    IAccountSelector Account { get; }
    ContextUser ContextUser => Account.ContextUser;

    public GuiBinding SelectionBinding => _BoundMessage.BaseBinding;




    /// <summary>
    /// Return an instance bound to the Contacts catalog of the account <paramref name="account"/>.
    /// </summary>
    /// <param name="account">The account whose contacts are to be used.</param>
    public MessageSection(IAccountSelector? account = null) {
        Account = account;
        //ContextUser.DictionaryCatalogDelegates.Replace(CatalogApplication.Label, GuigenCatalogApplication.Factory);
        var catalog = ContextUser.GetStore(SpoolInbound.Label, create: false) as GuigenSpoolInbound;
        ChooseMessage = new MessageSelection(catalog);
        }

    }

// Documented in Guigen output
public partial class BoundMessage : IBoundPresentation, IDialog {

    public virtual GuiDialog Dialog(Gui gui) => (gui as EverythingMaui).DialogBoundMessage;

    public override IFieldIcon Type => FieldIcons.Message(IsRead);


    public bool IsRead => false;

    public virtual Message Convert() {
        var result = new Message();
        Fill();
        return result;
        }

    public static BoundMessage? Convert(SpoolIndexEntry input) {
        var message = input.Message;
        if (message is MessageComplete) {
            return null;
            }


        var result = new BoundMessage();
        result.Fill(input);

        return result;
        }

    protected virtual void Fill(SpoolIndexEntry input) {
        Bound = input;
        var message = input.Message;
        Sender = message.Sender;
        var receiver = message?.EnvelopedMessage?.Header?.Received;
        TimeSent = receiver.ToRFC3339();
        }

    public virtual void Fill() {
        }

    }


public partial class BoundMessageConnectionRequest {

    public override IFieldIcon Type => FieldIcons.Connection(IsRead);
    public override string Category => "Device Connect";

    public override Message Convert() {
        var result = new Message();
        return result;
        }

    public static new BoundMessageConnectionRequest Convert(SpoolIndexEntry input) {
        var message = input.Message as RequestConnection;
        var result = new BoundMessageConnectionRequest();
        result.Fill(input);

        return result;
        }
    }

public partial class BoundMessageAcknowledgeConnection {

    public override IFieldIcon Type => FieldIcons.Connection(IsRead);

    public override string Category => "Connection Request";

    public override Message Convert() {
        var result = new Message();
        return result;
        }

    public static new BoundMessageAcknowledgeConnection Convert(SpoolIndexEntry input) {
        var message = input.Message as AcknowledgeConnection;
        var result = new BoundMessageAcknowledgeConnection();
        result.Fill(input);



        result.Subject ??= $"Device Connection Request {message.Witness}";
        result.Sender ??= message.MessageConnectionRequest.ProfileDevice.UdfString;

        return result;
        }
    }


public partial class BoundMailMail {

    public override IFieldIcon Type  => FieldIcons.Mail(IsRead);

    public override string Category => "Mail";

    public override Message Convert() {
        var result = new Message();
        return result;
        }

    public static new BoundMailMail Convert(SpoolIndexEntry input) {
        var message = input.Message as MessageMail;
        var result = new BoundMailMail() {
            Bound = input
            };
        result.Fill(input);

        return result;
        }
    }

public partial class BoundMessageConfirmationRequest {

    public override IFieldIcon Type  => FieldIcons.ConfirmationRequest(IsRead);

    public override string Category => "Confirmation Request";
    public override Message Convert() {
        var result = new Message();
        return result;
        }
    public static new BoundMessageConfirmationRequest Convert(SpoolIndexEntry input) {
        var message = input.Message as Mesh.RequestConfirmation;
        var result = new BoundMessageConfirmationRequest();
        result.Fill(input);

        return result;
        }
    }

public partial class BoundMessageConfirmationResponse {

    public override IFieldIcon Type => FieldIcons.ConfirmationResponse(IsRead, Accepted);
    public override string Category => "Confirmation Response";
    public bool Accepted => false;


    public override Message Convert() {
        var result = new Message();
        return result;
        }
    public static new BoundMessageConfirmationResponse Convert(SpoolIndexEntry input) {
        var message = input.Message as ResponseConfirmation;
        var result = new BoundMessageConfirmationResponse();
        result.Fill(input);

        return result;
        }
    }

public partial class BoundMessageContactRequest {

    public override GuiDialog Dialog(Gui gui) => (gui as EverythingMaui).DialogBoundMessageContactRequest;

    public override IFieldIcon Type => FieldIcons.ContactRequest(IsRead);
    public override string Category => "Contact Request";

    public override Message Convert() {
        var result = new Message();
        return result;
        }
    public static new BoundMessageContactRequest Convert(SpoolIndexEntry input) {
        var message = input.Message as MessageContact;
        var result = new BoundMessageContactRequest() {
            Subject = message.Subject

            };
        result.Fill(input);

        return result;
        }
    }


public partial class BoundMessageGroupInvitation {

    public override IFieldIcon Type  => FieldIcons.GroupInvitation(IsRead);
    public override string Category => "Group Invitation";
    public override Message Convert() {
        var result = new Message();
        return result;
        }
    public static new BoundMessageGroupInvitation Convert(SpoolIndexEntry input) {
        var message = input.Message as GroupInvitation;
        var result = new BoundMessageGroupInvitation();
        result.Fill(input);

        return result;
        }
    }

public partial class BoundMessageTaskRequest {

    public override IFieldIcon Type => FieldIcons.TaskRequest(IsRead, Accepted);

    public override string Category => "Task Request";
    public bool Accepted => false;

    public override Message Convert() {
        var result = new Message();
        return result;
        }
    public static new BoundMessageTaskRequest Convert(SpoolIndexEntry input) {
        var message = input.Message as RequestTask;
        var result = new BoundMessageTaskRequest();
        result.Fill(input);

        return result;
        }
    }






#endregion
#region // Binding to classes specified in the Mesh schema

/// <summary>
/// Extends <see cref="CatalogApplication"/> to override the <see cref="Intern"/> method
/// so as to allow the bound selection boxes to be updated.
/// </summary>
public class GuigenSpoolInbound : SpoolInbound {

    /// <summary>
    /// Factory delegate
    /// </summary>
    /// <param name="directory">Directory of store file on local machine.</param>
    /// <param name="storeId">Store identifier.</param>
    /// <param name="cryptoParameters">Cryptographic parameters for the store.</param>
    /// <param name="policy">The cryptographic policy to be applied to the container.</param>
    /// <param name="keyCollection">Key collection to be used to resolve keys</param>
    /// <param name="decrypt">If true, attempt decryption of payload contents./</param>
    /// <param name="create">If true, create a new file if none exists.</param>
    /// <param name="meshClient">The mesh client.</param>
    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
    /// <returns>The instance created.</returns>
    public static new Store Factory(
            string directory,
                string storeId,
                IMeshClient? meshClient = null,
                DarePolicy? policy = null,
                CryptoParameters? cryptoParameters = null,
                IKeyCollection? keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[]? bitmask = null) =>
        new GuigenSpoolInbound(directory, storeId, policy, cryptoParameters, keyCollection,
            decrypt, create, bitmask: bitmask);


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
    public GuigenSpoolInbound(
                string directory,
                string? storeName = null,
                DarePolicy? policy = null,
                CryptoParameters? cryptoParameters = null,
                IKeyCollection? keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[]? bitmask = null) :
        base(directory, storeName ?? Label,
                    policy, cryptoParameters, keyCollection,
                    decrypt: decrypt, create: create, bitmask: bitmask) {
        }

    public override void Intern(SequenceIndexEntry indexEntry) {
        base.Intern(indexEntry);
        }



    }


/// <summary>
/// Extends <see cref="CatalogApplication"/> to override the <see cref="Intern"/> method
/// so as to allow the bound selection boxes to be updated.
/// </summary>
public class GuigenSpoolOutbound : SpoolOutbound {

    /// <summary>
    /// Factory delegate
    /// </summary>
    /// <param name="directory">Directory of store file on local machine.</param>
    /// <param name="storeId">Store identifier.</param>
    /// <param name="cryptoParameters">Cryptographic parameters for the store.</param>
    /// <param name="policy">The cryptographic policy to be applied to the container.</param>
    /// <param name="keyCollection">Key collection to be used to resolve keys</param>
    /// <param name="decrypt">If true, attempt decryption of payload contents./</param>
    /// <param name="create">If true, create a new file if none exists.</param>
    /// <param name="meshClient">The mesh client.</param>
    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
    /// <returns>The instance created.</returns>
    public static new Store Factory(
            string directory,
                string storeId,
                IMeshClient? meshClient = null,
                DarePolicy? policy = null,
                CryptoParameters? cryptoParameters = null,
                IKeyCollection? keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[]? bitmask = null) =>
        new GuigenSpoolOutbound(directory, storeId, policy, cryptoParameters, keyCollection,
            decrypt, create, bitmask: bitmask);


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
    public GuigenSpoolOutbound(
                string directory,
                string? storeName = null,
                DarePolicy? policy = null,
                CryptoParameters? cryptoParameters = null,
                IKeyCollection? keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[]? bitmask = null) :
        base(directory, storeName ?? Label,
                    policy, cryptoParameters, keyCollection,
                    decrypt: decrypt, create: create, bitmask: bitmask) {
        }

    public override void Intern(SequenceIndexEntry indexEntry) {
        base.Intern(indexEntry);
        }



    }




/// <summary>
/// Extends <see cref="CatalogApplication"/> to override the <see cref="Intern"/> method
/// so as to allow the bound selection boxes to be updated.
/// </summary>
public class GuigenSpoolLocal : SpoolLocal {

    /// <summary>
    /// Factory delegate
    /// </summary>
    /// <param name="directory">Directory of store file on local machine.</param>
    /// <param name="storeId">Store identifier.</param>
    /// <param name="cryptoParameters">Cryptographic parameters for the store.</param>
    /// <param name="policy">The cryptographic policy to be applied to the container.</param>
    /// <param name="keyCollection">Key collection to be used to resolve keys</param>
    /// <param name="decrypt">If true, attempt decryption of payload contents./</param>
    /// <param name="create">If true, create a new file if none exists.</param>
    /// <param name="meshClient">The mesh client.</param>
    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
    /// <returns>The instance created.</returns>
    public static new Store Factory(
            string directory,
                string storeId,
                IMeshClient? meshClient = null,
                DarePolicy? policy = null,
                CryptoParameters? cryptoParameters = null,
                IKeyCollection? keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[]? bitmask = null) =>
        new GuigenSpoolLocal(directory, storeId, policy, cryptoParameters, keyCollection,
            decrypt, create, bitmask: bitmask);


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
    public GuigenSpoolLocal(
                string directory,
                string? storeName = null,
                DarePolicy? policy = null,
                CryptoParameters? cryptoParameters = null,
                IKeyCollection? keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[]? bitmask = null) :
        base(directory, storeName ?? Label,
                    policy, cryptoParameters, keyCollection,
                    decrypt: decrypt, create: create, bitmask: bitmask) {
        }

    public override void Intern(SequenceIndexEntry indexEntry) {
        base.Intern(indexEntry);
        }



    }



#endregion


#region // Selection Catalog backing type.

public partial class MessageSelection : SelectionSpool<GuigenSpoolInbound, BoundMessage> {

    ///<summary>Messages are immutable, they cannot be changed.</summary> 
    public override bool Readonly => true;

    /// <summary>
    /// Constructor returning an instance of the selection data backer bound to the 
    /// catalog <paramref name="catalog"/>.
    /// </summary>
    /// <param name="catalog"></param>
    public MessageSelection(GuigenSpoolInbound catalog) : base(catalog) {
        }

    #region // Conversion overrides
    //public override Message CreateFromBindable(IBindable entry) =>
    //    (entry as BoundMessage)?.Convert();

    public override BoundMessage ConvertToBindable(SpoolIndexEntry input) {

        switch (input.Message) {

            case MessageMail: {
                return BoundMailMail.Convert(input);
                }
            case AcknowledgeConnection: {
                return BoundMessageAcknowledgeConnection.Convert(input);
                }
            case RequestConnection: {
                return BoundMessageConnectionRequest.Convert(input);
                }
            case Mesh.RequestConfirmation: {
                return BoundMessageConfirmationRequest.Convert(input);
                }
            case ResponseConfirmation: {
                return BoundMessageConfirmationResponse.Convert(input);
                }
            case MessageContact: {
                return BoundMessageContactRequest.Convert(input);
                }
            case GroupInvitation: {
                return BoundMessageGroupInvitation.Convert(input);
                }
            case RequestTask: {
                return BoundMessageTaskRequest.Convert(input);
                }
            //case Compl
            default: {
                return BoundMessage.Convert(input);
                }
            }
        }

    public override SpoolIndexEntry UpdateWithBindable(IBindable entry) {
        var binding = entry as BoundMessage;
        binding.Fill();
        return binding.Bound as SpoolIndexEntry;
        }
    
    #endregion


    }


#endregion