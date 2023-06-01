#region // Copyright 

//  Copyright (c) 2023 by Threshold Secrets LLC
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
#endregion

using Goedel.Guigen;
using Goedel.Utilities;

namespace Goedel.Everything;


/// <summary>
/// Defines the graphical user interface.
/// </summary>
public partial class EverythingMaui :  _EverythingMaui {



    
    }


/// <summary>
/// Defines the graphical user interface.
/// </summary>
public class _EverythingMaui : Gui {


    ///<inheritdoc/> 
    public override List<GuiDialog> Dialogs { get; }

    ///<inheritdoc/> 
    public override List<GuiSection> Sections { get; }

    ///<inheritdoc/> 
    public override List<GuiAction> Actions { get; }


	///<inheritdoc/>
	public override List<GuiImage> Icons => icons;
	readonly List<GuiImage> icons = new () {  
		new GuiImage ("applications") , 
		new GuiImage ("calendar") , 
		new GuiImage ("chat") , 
		new GuiImage ("connect") , 
		new GuiImage ("contact") , 
		new GuiImage ("contacts") , 
		new GuiImage ("credentials") , 
		new GuiImage ("devices") , 
		new GuiImage ("document_send") , 
		new GuiImage ("document_share") , 
		new GuiImage ("documents") , 
		new GuiImage ("feeds") , 
		new GuiImage ("groups") , 
		new GuiImage ("mail") , 
		new GuiImage ("messages") , 
		new GuiImage ("new") , 
		new GuiImage ("recover") , 
		new GuiImage ("services") , 
		new GuiImage ("settings") , 
		new GuiImage ("tasks") , 
		new GuiImage ("test_service") , 
		new GuiImage ("user") , 
		new GuiImage ("video") , 
		new GuiImage ("voice") 
		};


	// Sections
	public GuiSection SectionAccounts { get; } = new ("Accounts", "Accounts", "user", false);
	public GuiSection SectionMessages { get; } = new ("Messages", "Messages", "messages", true);
	public GuiSection SectionContacts { get; } = new ("Contacts", "Contacts", "contacts", true);
	public GuiSection SectionDocuments { get; } = new ("Documents", "Documents", "Documents", false);
	public GuiSection SectionGroups { get; } = new ("Groups", "Groups", "groups", false);
	public GuiSection SectionFeeds { get; } = new ("Feeds", "Feeds", "feeds", false);
	public GuiSection SectionCredentials { get; } = new ("Credentials", "Credentials", "credentials", false);
	public GuiSection SectionTasks { get; } = new ("Tasks", "Tasks", "tasks", false);
	public GuiSection SectionCalendar { get; } = new ("Calendar", "Calendar", "calendar", false);
	public GuiSection SectionApplications { get; } = new ("Applications", "Applications", "applications", false);
	public GuiSection SectionDevices { get; } = new ("Devices", "Devices", "devices", false);
	public GuiSection SectionServices { get; } = new ("Services", "Services", "Services", false);
	public GuiSection SectionSettings { get; } = new ("Settings", "Settings", "settings", true);

	
	// Actions
	public GuiAction ActionTestService { get; } = new ("TestService", "Test Service", "test_service", () => new TestService());
	public GuiAction ActionAccountCreate { get; } = new ("AccountCreate", "Create Mesh Account", "new", () => new AccountCreate());
	public GuiAction ActionAccountConnect { get; } = new ("AccountConnect", "Connect To Existing Account", "connect", () => new AccountConnect());
	public GuiAction ActionAccountRecover { get; } = new ("AccountRecover", "Recover Mesh Account", "recover", () => new AccountRecover());
	public GuiAction ActionRequestContact { get; } = new ("RequestContact", "New Contact", "contact", () => new RequestContact());
	public GuiAction ActionCreateMail { get; } = new ("CreateMail", "New Mail", "mail", () => new CreateMail());
	public GuiAction ActionCreateChat { get; } = new ("CreateChat", "New Chat", "chat", () => new CreateChat());
	public GuiAction ActionStartVoice { get; } = new ("StartVoice", "New Voice", "voice", () => new StartVoice());
	public GuiAction ActionStartVideo { get; } = new ("StartVideo", "New Video", "video", () => new StartVideo());
	public GuiAction ActionSendDocument { get; } = new ("SendDocument", "Send document", "document_send", () => new SendDocument());
	public GuiAction ActionShareDocument { get; } = new ("ShareDocument", "Share document", "document_share", () => new ShareDocument());

	// Dialogs
	public GuiDialog DialogAppearance { get; } = new ("Appearance");
	public GuiDialog DialogAccountUser { get; } = new ("AccountUser");
	public GuiDialog DialogContact { get; } = new ("Contact");
	public GuiDialog DialogContactNetworkAddress { get; } = new ("ContactNetworkAddress");
	public GuiDialog DialogContactPhysicalAddress { get; } = new ("ContactPhysicalAddress");
	public GuiDialog DialogMessageContactRequest { get; } = new ("MessageContactRequest");
	public GuiDialog DialogMessageConfirmationRequest { get; } = new ("MessageConfirmationRequest");
	public GuiDialog DialogMessageMail { get; } = new ("MessageMail");
	

    public _EverythingMaui () {


	    SectionAccounts.Entries =  new List<ISectionEntry>() {  
			new GuiButton ("Groups", SectionGroups), 
			new GuiButton ("Services", SectionServices), 
			new GuiChooser ("ChooseUser", "User", "account_user", new List<IChooserEntry>() { 
				new GuiButton ("AccountCreate", ActionAccountCreate), 
				new GuiButton ("AccountConnect", ActionAccountConnect), 
				new GuiButton ("AccountRecover", ActionAccountRecover), 
				new GuiButton ("TestService", ActionTestService)
				}) 		    
            };

	    SectionMessages.Entries =  new List<ISectionEntry>() {  
			new GuiButton ("RequestContact", ActionRequestContact), 
			new GuiButton ("CreateMail", ActionCreateMail), 
			new GuiButton ("CreateChat", ActionCreateChat), 
			new GuiButton ("StartVoice", ActionStartVoice), 
			new GuiButton ("StartVideo", ActionStartVideo), 
			new GuiChooser ("UrgentMessage", "Urgent", "urgent_messages", new List<IChooserEntry>() {
				}) , 
			new GuiChooser ("ContactRequests", "Contact Requests", "contact_messages", new List<IChooserEntry>() {
				}) , 
			new GuiChooser ("OtherMessage", "Messages", "inbox_messages", new List<IChooserEntry>() {
				}) 		    
            };

	    SectionContacts.Entries =  new List<ISectionEntry>() {  
			new GuiChooser ("ChooseSelf", "Self", "contact_self", new List<IChooserEntry>() {
				}) , 
			new GuiChooser ("ContactMessage", "Contact Requests", "contact_message", new List<IChooserEntry>() {
				}) , 
			new GuiChooser ("ChooseOther", "Contacts", "contact_other", new List<IChooserEntry>() {
				}) 		    
            };

	    SectionDocuments.Entries =  new List<ISectionEntry>() {  
			new GuiButton ("SendDocument", ActionSendDocument), 
			new GuiButton ("ShareDocument", ActionShareDocument), 
			new GuiChooser ("ChooseDocuments", "Documents", "documents", new List<IChooserEntry>() {
				}) 		    
            };

	    SectionGroups.Entries =  new List<ISectionEntry>() {  
			new GuiChooser ("ChooseGroup", "User", "account_group", new List<IChooserEntry>() { 
				new GuiButton ("AccountCreate", ActionAccountCreate)
				}) 		    
            };

	    SectionFeeds.Entries =  new List<ISectionEntry>() {  
			new GuiChooser ("ChooseFeed", "Feeds", "feeds", new List<IChooserEntry>() {
				}) 		    
            };

	    SectionCredentials.Entries =  new List<ISectionEntry>() {  
			new GuiChooser ("ChooseCredential", "Credentials", "credentials", new List<IChooserEntry>() {
				}) 		    
            };

	    SectionTasks.Entries =  new List<ISectionEntry>() {  
			new GuiChooser ("ChooseTask", "Tasks", "Tasks", new List<IChooserEntry>() {
				}) 		    
            };

	    SectionCalendar.Entries =  new List<ISectionEntry>() {  
			new GuiChooser ("ChooseAppointment", "Calendar", "Calendar", new List<IChooserEntry>() {
				}) 		    
            };

	    SectionApplications.Entries =  new List<ISectionEntry>() {  
			new GuiChooser ("ChooseApplication", "Applications", "Applications", new List<IChooserEntry>() {
				}) 		    
            };

	    SectionDevices.Entries =  new List<ISectionEntry>() {  
			new GuiChooser ("ChooseDevice", "Devices", "Devices", new List<IChooserEntry>() {
				}) 		    
            };

	    SectionServices.Entries =  new List<ISectionEntry>() {  
			new GuiChooser ("ChooseService", "Services", "account_service.png", new List<IChooserEntry>() { 
				new GuiButton ("AccountCreate", ActionAccountCreate)
				}) 		    
            };

	    SectionSettings.Entries =  new List<ISectionEntry>() {  
			new GuiDialog ("Appearance", new List<IDialogEntry>() { 
				new GuiColor ("BackgroundColor", "Background Color"), 
				new GuiColor ("HighlightColor", "Highlight Color"), 
				new GuiColor ("TextColor", "Text Color"), 
				new GuiSize ("TextSize", "Text Size"), 
				new GuiSize ("IconSize", "Icon Size")
			    }) 		    
            };


        Sections = new List<GuiSection> () {  
		    SectionAccounts, 
		    SectionMessages, 
		    SectionContacts, 
		    SectionDocuments, 
		    SectionGroups, 
		    SectionFeeds, 
		    SectionCredentials, 
		    SectionTasks, 
		    SectionCalendar, 
		    SectionApplications, 
		    SectionDevices, 
		    SectionServices, 
		    SectionSettings
            };

    ActionTestService.Callback = TestService;
	ActionTestService.Entries = new List<IActionEntry>() { 
			new GuiText ("ServiceAddress", "Service address")
		    };

    ActionAccountCreate.Callback = AccountCreate;
	ActionAccountCreate.Entries = new List<IActionEntry>() { 
			new GuiText ("ServiceAddress", "Account service address"), 
			new GuiText ("LocalName", "Friendly name (optional)"), 
			new GuiText ("Coupon", "Activation code (if provided)")
		    };

    ActionAccountConnect.Callback = AccountConnect;
	ActionAccountConnect.Entries = new List<IActionEntry>() { 
			new GuiText ("ConnectionString", "Account address"), 
			new GuiText ("ConnectionPin", "Activation code (if provided)")
		    };

    ActionAccountRecover.Callback = AccountRecover;
	ActionAccountRecover.Entries = new List<IActionEntry>() { 
			new GuiText ("ServiceAddress", "Account service address"), 
			new GuiText ("LocalName", "Friendly name (optional)"), 
			new GuiText ("Coupon", "Activation code (if provided)"), 
			new GuiText ("Share1", "Recovery share"), 
			new GuiText ("Share2", "Recovery share"), 
			new GuiText ("Share3", "Recovery share"), 
			new GuiText ("Share4", "Recovery share"), 
			new GuiText ("Share5", "Recovery share"), 
			new GuiText ("Share6", "Recovery share"), 
			new GuiText ("Share7", "Recovery share"), 
			new GuiText ("Share8", "Recovery share")
		    };

    ActionRequestContact.Callback = RequestContact;
	ActionRequestContact.Entries = new List<IActionEntry>() {
		    };

    ActionCreateMail.Callback = CreateMail;
	ActionCreateMail.Entries = new List<IActionEntry>() {
		    };

    ActionCreateChat.Callback = CreateChat;
	ActionCreateChat.Entries = new List<IActionEntry>() {
		    };

    ActionStartVoice.Callback = StartVoice;
	ActionStartVoice.Entries = new List<IActionEntry>() {
		    };

    ActionStartVideo.Callback = StartVideo;
	ActionStartVideo.Entries = new List<IActionEntry>() {
		    };

    ActionSendDocument.Callback = SendDocument;
	ActionSendDocument.Entries = new List<IActionEntry>() {
		    };

    ActionShareDocument.Callback = ShareDocument;
	ActionShareDocument.Entries = new List<IActionEntry>() {
		    };


    Actions = new List<GuiAction>() {  
		    ActionTestService, 
		    ActionAccountCreate, 
		    ActionAccountConnect, 
		    ActionAccountRecover, 
		    ActionRequestContact, 
		    ActionCreateMail, 
		    ActionCreateChat, 
		    ActionStartVoice, 
		    ActionStartVideo, 
		    ActionSendDocument, 
		    ActionShareDocument
		    };


	DialogAppearance.Entries = new List<IDialogEntry>() { 
			new GuiColor ("BackgroundColor", "Background Color"), 
			new GuiColor ("HighlightColor", "Highlight Color"), 
			new GuiColor ("TextColor", "Text Color"), 
			new GuiSize ("TextSize", "Text Size"), 
			new GuiSize ("IconSize", "Icon Size")			
		    };

	DialogAccountUser.Entries = new List<IDialogEntry>() { 
			new GuiText ("Udf", "Fingerprint"), 
			new GuiText ("ServiceAddress", "Account service address"), 
			new GuiText ("Local", "Friendly name"), 
			new GuiText ("Description", "Description"), 
			new GuiChooser ("UserChooseDevice", "Devices", "device", new List<IChooserEntry>() {
				}) 			
		    };

	DialogContact.Entries = new List<IDialogEntry>() { 
			new GuiText ("Local", "Friendly name"), 
			new GuiText ("Full", "Full name"), 
			new GuiText ("First", "First name"), 
			new GuiText ("Last", "Last name"), 
			new GuiText ("Prefix", "Prefix"), 
			new GuiText ("Suffix", "Suffix"), 
			new GuiChooser ("NetworkAddress", "Network Addresses", "network", new List<IChooserEntry>() {
				}) , 
			new GuiChooser ("PhysicalAddress", "Locations", "location", new List<IChooserEntry>() {
				}) 			
		    };

	DialogContactNetworkAddress.Entries = new List<IDialogEntry>() { 
			new GuiIcon ("ProtocolIcon", "protocol_icon"), 
			new GuiText ("Protocol", "Protocol"), 
			new GuiText ("Address", "Address"), 
			new GuiText ("Fingerprint", "Fingerprint")			
		    };

	DialogContactPhysicalAddress.Entries = new List<IDialogEntry>() { 
			new GuiText ("Appartment", "Appartment"), 
			new GuiText ("Street", "Street"), 
			new GuiText ("District", "District"), 
			new GuiText ("Locality", "Locality"), 
			new GuiText ("County", "County"), 
			new GuiText ("Postcode", "Postcode"), 
			new GuiText ("Country", "Country"), 
			new GuiDecimal ("Latitude", "Latitude"), 
			new GuiDecimal ("Longitude", "Longitude")			
		    };

	DialogMessageContactRequest.Entries = new List<IDialogEntry>() { 
			new GuiText ("To", "To"), 
			new GuiText ("Comment", "Comment")			
		    };

	DialogMessageConfirmationRequest.Entries = new List<IDialogEntry>() { 
			new GuiText ("To", "To"), 
			new GuiText ("Request", "Request")			
		    };

	DialogMessageMail.Entries = new List<IDialogEntry>() { 
			new GuiText ("To", "To"), 
			new GuiText ("Subject", "Subject"), 
			new GuiText ("Body", "Body")			
		    };


        Dialogs = new List<GuiDialog>() {  
		    DialogAppearance, 
		    DialogAccountUser, 
		    DialogContact, 
		    DialogContactNetworkAddress, 
		    DialogContactPhysicalAddress, 
		    DialogMessageContactRequest, 
		    DialogMessageConfirmationRequest, 
		    DialogMessageMail
		    };

        }

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual void TestService (object data) => NotYetImplemented ();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual void AccountCreate (object data) => NotYetImplemented ();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual void AccountConnect (object data) => NotYetImplemented ();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual void AccountRecover (object data) => NotYetImplemented ();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual void RequestContact (object data) => NotYetImplemented ();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual void CreateMail (object data) => NotYetImplemented ();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual void CreateChat (object data) => NotYetImplemented ();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual void StartVoice (object data) => NotYetImplemented ();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual void StartVideo (object data) => NotYetImplemented ();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual void SendDocument (object data) => NotYetImplemented ();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual void ShareDocument (object data) => NotYetImplemented ();

    
    
    /// <summary>
    /// Default action
    /// </summary>    
    void NotYetImplemented () {
        }

	}


/// <summary>
/// Callback parameters for action TestService 
/// </summary>
public partial class TestService {


    public static object _Factory => new TestService ();
    }

/// <summary>
/// Callback parameters for action AccountCreate 
/// </summary>
public partial class AccountCreate {


    public static object _Factory => new AccountCreate ();
    }

/// <summary>
/// Callback parameters for action AccountConnect 
/// </summary>
public partial class AccountConnect {


    public static object _Factory => new AccountConnect ();
    }

/// <summary>
/// Callback parameters for action AccountRecover 
/// </summary>
public partial class AccountRecover {


    public static object _Factory => new AccountRecover ();
    }

/// <summary>
/// Callback parameters for action RequestContact 
/// </summary>
public partial class RequestContact {


    public static object _Factory => new RequestContact ();
    }

/// <summary>
/// Callback parameters for action CreateMail 
/// </summary>
public partial class CreateMail {


    public static object _Factory => new CreateMail ();
    }

/// <summary>
/// Callback parameters for action CreateChat 
/// </summary>
public partial class CreateChat {


    public static object _Factory => new CreateChat ();
    }

/// <summary>
/// Callback parameters for action StartVoice 
/// </summary>
public partial class StartVoice {


    public static object _Factory => new StartVoice ();
    }

/// <summary>
/// Callback parameters for action StartVideo 
/// </summary>
public partial class StartVideo {


    public static object _Factory => new StartVideo ();
    }

/// <summary>
/// Callback parameters for action SendDocument 
/// </summary>
public partial class SendDocument {


    public static object _Factory => new SendDocument ();
    }

/// <summary>
/// Callback parameters for action ShareDocument 
/// </summary>
public partial class ShareDocument {


    public static object _Factory => new ShareDocument ();
    }




