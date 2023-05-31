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
	public GuiSection SectionAccounts { get; }
	public GuiSection SectionMessages { get; }
	public GuiSection SectionContacts { get; }
	public GuiSection SectionDocuments { get; }
	public GuiSection SectionGroups { get; }
	public GuiSection SectionFeeds { get; }
	public GuiSection SectionCredentials { get; }
	public GuiSection SectionTasks { get; }
	public GuiSection SectionCalendar { get; }
	public GuiSection SectionApplications { get; }
	public GuiSection SectionDevices { get; }
	public GuiSection SectionServices { get; }
	public GuiSection SectionSettings { get; }

	
	// Actions
	public GuiAction ActionTestService { get; }
	public GuiAction ActionAccountCreate { get; }
	public GuiAction ActionAccountConnect { get; }
	public GuiAction ActionAccountRecover { get; }
	public GuiAction ActionRequestContact { get; }
	public GuiAction ActionCreateMail { get; }
	public GuiAction ActionCreateChat { get; }
	public GuiAction ActionStartVoice { get; }
	public GuiAction ActionStartVideo { get; }
	public GuiAction ActionSendDocument { get; }
	public GuiAction ActionShareDocument { get; }

	// Dialogs
	public GuiDialog DialogAppearance { get; }
	public GuiDialog DialogAccountUser { get; }
	public GuiDialog DialogContact { get; }
	public GuiDialog DialogContactNetworkAddress { get; }
	public GuiDialog DialogContactPhysicalAddress { get; }
	public GuiDialog DialogMessageContactRequest { get; }
	public GuiDialog DialogMessageConfirmationRequest { get; }
	public GuiDialog DialogMessageMail { get; }
	

    public _EverythingMaui () {


	    SectionAccounts = new (
			"Accounts", "Accounts", "user", false, new List<ISectionEntry>() {  
			new GuiButton ("Groups", SectionGroups), 
			new GuiButton ("Services", SectionServices), 
			new GuiChooser ("ChooseUser", "User", "account_user", new List<IChooserEntry>() { 
				new GuiButton ("AccountCreate", ActionAccountCreate), 
				new GuiButton ("AccountConnect", ActionAccountConnect), 
				new GuiButton ("AccountRecover", ActionAccountRecover), 
				new GuiButton ("TestService", ActionTestService)
				}) 		    
            });

	    SectionMessages = new (
			"Messages", "Messages", "messages", true, new List<ISectionEntry>() {  
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
            });

	    SectionContacts = new (
			"Contacts", "Contacts", "contacts", true, new List<ISectionEntry>() {  
			new GuiChooser ("ChooseSelf", "Self", "contact_self", new List<IChooserEntry>() {
				}) , 
			new GuiChooser ("ContactMessage", "Contact Requests", "contact_message", new List<IChooserEntry>() {
				}) , 
			new GuiChooser ("ChooseOther", "Contacts", "contact_other", new List<IChooserEntry>() {
				}) 		    
            });

	    SectionDocuments = new (
			"Documents", "Documents", "Documents", false, new List<ISectionEntry>() {  
			new GuiButton ("SendDocument", ActionSendDocument), 
			new GuiButton ("ShareDocument", ActionShareDocument), 
			new GuiChooser ("ChooseDocuments", "Documents", "documents", new List<IChooserEntry>() {
				}) 		    
            });

	    SectionGroups = new (
			"Groups", "Groups", "groups", false, new List<ISectionEntry>() {  
			new GuiChooser ("ChooseGroup", "User", "account_group", new List<IChooserEntry>() { 
				new GuiButton ("AccountCreate", ActionAccountCreate)
				}) 		    
            });

	    SectionFeeds = new (
			"Feeds", "Feeds", "feeds", false, new List<ISectionEntry>() {  
			new GuiChooser ("ChooseFeed", "Feeds", "feeds", new List<IChooserEntry>() {
				}) 		    
            });

	    SectionCredentials = new (
			"Credentials", "Credentials", "credentials", false, new List<ISectionEntry>() {  
			new GuiChooser ("ChooseCredential", "Credentials", "credentials", new List<IChooserEntry>() {
				}) 		    
            });

	    SectionTasks = new (
			"Tasks", "Tasks", "tasks", false, new List<ISectionEntry>() {  
			new GuiChooser ("ChooseTask", "Tasks", "Tasks", new List<IChooserEntry>() {
				}) 		    
            });

	    SectionCalendar = new (
			"Calendar", "Calendar", "calendar", false, new List<ISectionEntry>() {  
			new GuiChooser ("ChooseAppointment", "Calendar", "Calendar", new List<IChooserEntry>() {
				}) 		    
            });

	    SectionApplications = new (
			"Applications", "Applications", "applications", false, new List<ISectionEntry>() {  
			new GuiChooser ("ChooseApplication", "Applications", "Applications", new List<IChooserEntry>() {
				}) 		    
            });

	    SectionDevices = new (
			"Devices", "Devices", "devices", false, new List<ISectionEntry>() {  
			new GuiChooser ("ChooseDevice", "Devices", "Devices", new List<IChooserEntry>() {
				}) 		    
            });

	    SectionServices = new (
			"Services", "Services", "Services", false, new List<ISectionEntry>() {  
			new GuiChooser ("ChooseService", "Services", "account_service.png", new List<IChooserEntry>() { 
				new GuiButton ("AccountCreate", ActionAccountCreate)
				}) 		    
            });

	    SectionSettings = new (
			"Settings", "Settings", "settings", true, new List<ISectionEntry>() {  
			new GuiDialog ("Appearance", new List<IDialogEntry>() { 
				new GuiColor ("BackgroundColor", "Background Color"), 
				new GuiColor ("HighlightColor", "Highlight Color"), 
				new GuiColor ("TextColor", "Text Color"), 
				new GuiSize ("TextSize", "Text Size"), 
				new GuiSize ("IconSize", "Icon Size")
			    }) 		    
            });


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

	ActionTestService = new (
			"TestService", "Test Service", "test_service", TestService, () => new TestService(), new List<IActionEntry>() { 
			new GuiText ("ServiceAddress", "Service address")
		    });

	ActionAccountCreate = new (
			"AccountCreate", "Create Mesh Account", "new", AccountCreate, () => new AccountCreate(), new List<IActionEntry>() { 
			new GuiText ("ServiceAddress", "Account service address"), 
			new GuiText ("LocalName", "Friendly name (optional)"), 
			new GuiText ("Coupon", "Activation code (if provided)")
		    });

	ActionAccountConnect = new (
			"AccountConnect", "Connect To Existing Account", "connect", AccountConnect, () => new AccountConnect(), new List<IActionEntry>() { 
			new GuiText ("ConnectionString", "Account address"), 
			new GuiText ("ConnectionPin", "Activation code (if provided)")
		    });

	ActionAccountRecover = new (
			"AccountRecover", "Recover Mesh Account", "recover", AccountRecover, () => new AccountRecover(), new List<IActionEntry>() { 
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
		    });

	ActionRequestContact = new (
			"RequestContact", "New Contact", "contact", RequestContact, () => new RequestContact(), new List<IActionEntry>() {
		    });

	ActionCreateMail = new (
			"CreateMail", "New Mail", "mail", CreateMail, () => new CreateMail(), new List<IActionEntry>() {
		    });

	ActionCreateChat = new (
			"CreateChat", "New Chat", "chat", CreateChat, () => new CreateChat(), new List<IActionEntry>() {
		    });

	ActionStartVoice = new (
			"StartVoice", "New Voice", "voice", StartVoice, () => new StartVoice(), new List<IActionEntry>() {
		    });

	ActionStartVideo = new (
			"StartVideo", "New Video", "video", StartVideo, () => new StartVideo(), new List<IActionEntry>() {
		    });

	ActionSendDocument = new (
			"SendDocument", "Send document", "document_send", SendDocument, () => new SendDocument(), new List<IActionEntry>() {
		    });

	ActionShareDocument = new (
			"ShareDocument", "Share document", "document_share", ShareDocument, () => new ShareDocument(), new List<IActionEntry>() {
		    });


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


	DialogAppearance = new (
			"Appearance", new List<IDialogEntry>() { 
			new GuiColor ("BackgroundColor", "Background Color"), 
			new GuiColor ("HighlightColor", "Highlight Color"), 
			new GuiColor ("TextColor", "Text Color"), 
			new GuiSize ("TextSize", "Text Size"), 
			new GuiSize ("IconSize", "Icon Size")			
		    });

	DialogAccountUser = new (
			"AccountUser", new List<IDialogEntry>() { 
			new GuiText ("Udf", "Fingerprint"), 
			new GuiText ("ServiceAddress", "Account service address"), 
			new GuiText ("Local", "Friendly name"), 
			new GuiText ("Description", "Description"), 
			new GuiChooser ("UserChooseDevice", "Devices", "device", new List<IChooserEntry>() {
				}) 			
		    });

	DialogContact = new (
			"Contact", new List<IDialogEntry>() { 
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
		    });

	DialogContactNetworkAddress = new (
			"ContactNetworkAddress", new List<IDialogEntry>() { 
			new GuiIcon ("ProtocolIcon", "protocol_icon"), 
			new GuiText ("Protocol", "Protocol"), 
			new GuiText ("Address", "Address"), 
			new GuiText ("Fingerprint", "Fingerprint")			
		    });

	DialogContactPhysicalAddress = new (
			"ContactPhysicalAddress", new List<IDialogEntry>() { 
			new GuiText ("Appartment", "Appartment"), 
			new GuiText ("Street", "Street"), 
			new GuiText ("District", "District"), 
			new GuiText ("Locality", "Locality"), 
			new GuiText ("County", "County"), 
			new GuiText ("Postcode", "Postcode"), 
			new GuiText ("Country", "Country"), 
			new GuiDecimal ("Latitude", "Latitude"), 
			new GuiDecimal ("Longitude", "Longitude")			
		    });

	DialogMessageContactRequest = new (
			"MessageContactRequest", new List<IDialogEntry>() { 
			new GuiText ("To", "To"), 
			new GuiText ("Comment", "Comment")			
		    });

	DialogMessageConfirmationRequest = new (
			"MessageConfirmationRequest", new List<IDialogEntry>() { 
			new GuiText ("To", "To"), 
			new GuiText ("Request", "Request")			
		    });

	DialogMessageMail = new (
			"MessageMail", new List<IDialogEntry>() { 
			new GuiText ("To", "To"), 
			new GuiText ("Subject", "Subject"), 
			new GuiText ("Body", "Body")			
		    });


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




