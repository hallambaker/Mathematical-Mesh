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
public partial class EverythingMaui : Gui {


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

	///<inheritdoc/>
	public override List<GuiSection> Sections => sections;
    readonly List<GuiSection> sections = new List<GuiSection> () {  
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


	///<inheritdoc/>
	public override List<GuiAction> Actions => actions;
    readonly List<GuiAction> actions = new List<GuiAction>() {  
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


	///<inheritdoc/>
	public override List<GuiDialog> Dialogs => dialogs;
    readonly List<GuiDialog> dialogs = new List<GuiDialog>() {  
		DialogAppearance, 
		DialogAccountUser, 
		DialogContact, 
		DialogContactNetworkAddress, 
		DialogContactPhysicalAddress, 
		DialogMessageContactRequest, 
		DialogMessageConfirmationRequest, 
		DialogMessageMail
		};

	// Sections
	static readonly GuiSection SectionAccounts = new (
			"Accounts", "Accounts", "user", false, new List<ISectionEntry>() {  
			new GuiButton ("Groups", SectionGroups), 
			new GuiButton ("Services", SectionServices), 
			new GuiChooser ("ChooseUser", "User", "account_user", new List<IChooserEntry>() { 
				new GuiButton ("AccountCreate", ActionAccountCreate), 
				new GuiButton ("AccountConnect", ActionAccountConnect), 
				new GuiButton ("AccountRecover", ActionAccountRecover), 
				new GuiButton ("TestService", ActionTestService)
					}) 
			}) {
		};

	static readonly GuiSection SectionMessages = new (
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
			}) {
		};

	static readonly GuiSection SectionContacts = new (
			"Contacts", "Contacts", "contacts", true, new List<ISectionEntry>() {  
			new GuiChooser ("ChooseSelf", "Self", "contact_self", new List<IChooserEntry>() {
					}) , 
			new GuiChooser ("ContactMessage", "Contact Requests", "contact_message", new List<IChooserEntry>() {
					}) , 
			new GuiChooser ("ChooseOther", "Contacts", "contact_other", new List<IChooserEntry>() {
					}) 
			}) {
		};

	static readonly GuiSection SectionDocuments = new (
			"Documents", "Documents", "Documents", false, new List<ISectionEntry>() {  
			new GuiButton ("SendDocument", ActionSendDocument), 
			new GuiButton ("ShareDocument", ActionShareDocument), 
			new GuiChooser ("ChooseDocuments", "Documents", "documents", new List<IChooserEntry>() {
					}) 
			}) {
		};

	static readonly GuiSection SectionGroups = new (
			"Groups", "Groups", "groups", false, new List<ISectionEntry>() {  
			new GuiChooser ("ChooseGroup", "User", "account_group", new List<IChooserEntry>() { 
				new GuiButton ("AccountCreate", ActionAccountCreate)
					}) 
			}) {
		};

	static readonly GuiSection SectionFeeds = new (
			"Feeds", "Feeds", "feeds", false, new List<ISectionEntry>() {  
			new GuiChooser ("ChooseFeed", "Feeds", "feeds", new List<IChooserEntry>() {
					}) 
			}) {
		};

	static readonly GuiSection SectionCredentials = new (
			"Credentials", "Credentials", "credentials", false, new List<ISectionEntry>() {  
			new GuiChooser ("ChooseCredential", "Credentials", "credentials", new List<IChooserEntry>() {
					}) 
			}) {
		};

	static readonly GuiSection SectionTasks = new (
			"Tasks", "Tasks", "tasks", false, new List<ISectionEntry>() {  
			new GuiChooser ("ChooseTask", "Tasks", "Tasks", new List<IChooserEntry>() {
					}) 
			}) {
		};

	static readonly GuiSection SectionCalendar = new (
			"Calendar", "Calendar", "calendar", false, new List<ISectionEntry>() {  
			new GuiChooser ("ChooseAppointment", "Calendar", "Calendar", new List<IChooserEntry>() {
					}) 
			}) {
		};

	static readonly GuiSection SectionApplications = new (
			"Applications", "Applications", "applications", false, new List<ISectionEntry>() {  
			new GuiChooser ("ChooseApplication", "Applications", "Applications", new List<IChooserEntry>() {
					}) 
			}) {
		};

	static readonly GuiSection SectionDevices = new (
			"Devices", "Devices", "devices", false, new List<ISectionEntry>() {  
			new GuiChooser ("ChooseDevice", "Devices", "Devices", new List<IChooserEntry>() {
					}) 
			}) {
		};

	static readonly GuiSection SectionServices = new (
			"Services", "Services", "Services", false, new List<ISectionEntry>() {  
			new GuiChooser ("ChooseService", "Services", "account_service.png", new List<IChooserEntry>() { 
				new GuiButton ("AccountCreate", ActionAccountCreate)
					}) 
			}) {
		};

	static readonly GuiSection SectionSettings = new (
			"Settings", "Settings", "settings", true, new List<ISectionEntry>() {  
			new GuiDialog ("Appearance", new List<IDialogEntry>() { 
				new GuiColor ("BackgroundColor", "Background Color"), 
				new GuiColor ("HighlightColor", "Highlight Color"), 
				new GuiColor ("TextColor", "Text Color"), 
				new GuiSize ("TextSize", "Text Size"), 
				new GuiSize ("IconSize", "Icon Size")
					}) 
			}) {
		};

	
	// Actions
	static readonly GuiAction ActionTestService = new (
			"TestService", "Test Service", "test_service", new List<IActionEntry>() { 
			new GuiText ("ServiceAddress", "Service address")
			}) {
		};

	static readonly GuiAction ActionAccountCreate = new (
			"AccountCreate", "Create Mesh Account", "new", new List<IActionEntry>() { 
			new GuiText ("ServiceAddress", "Account service address"), 
			new GuiText ("LocalName", "Friendly name (optional)"), 
			new GuiText ("Coupon", "Activation code (if provided)")
			}) {
		};

	static readonly GuiAction ActionAccountConnect = new (
			"AccountConnect", "Connect To Existing Account", "connect", new List<IActionEntry>() { 
			new GuiText ("ConnectionString", "Account address"), 
			new GuiText ("ConnectionPin", "Activation code (if provided)")
			}) {
		};

	static readonly GuiAction ActionAccountRecover = new (
			"AccountRecover", "Recover Mesh Account", "recover", new List<IActionEntry>() { 
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
			}) {
		};

	static readonly GuiAction ActionRequestContact = new (
			"RequestContact", "New Contact", "contact", new List<IActionEntry>() {
			}) {
		};

	static readonly GuiAction ActionCreateMail = new (
			"CreateMail", "New Mail", "mail", new List<IActionEntry>() {
			}) {
		};

	static readonly GuiAction ActionCreateChat = new (
			"CreateChat", "New Chat", "chat", new List<IActionEntry>() {
			}) {
		};

	static readonly GuiAction ActionStartVoice = new (
			"StartVoice", "New Voice", "voice", new List<IActionEntry>() {
			}) {
		};

	static readonly GuiAction ActionStartVideo = new (
			"StartVideo", "New Video", "video", new List<IActionEntry>() {
			}) {
		};

	static readonly GuiAction ActionSendDocument = new (
			"SendDocument", "Send document", "document_send", new List<IActionEntry>() {
			}) {
		};

	static readonly GuiAction ActionShareDocument = new (
			"ShareDocument", "Share document", "document_share", new List<IActionEntry>() {
			}) {
		};


	// Dialogs
	static readonly GuiDialog DialogAppearance = new (
			"Appearance", new List<IDialogEntry>() { 
			new GuiColor ("BackgroundColor", "Background Color"), 
			new GuiColor ("HighlightColor", "Highlight Color"), 
			new GuiColor ("TextColor", "Text Color"), 
			new GuiSize ("TextSize", "Text Size"), 
			new GuiSize ("IconSize", "Icon Size")
			}) {
		};

	static readonly GuiDialog DialogAccountUser = new (
			"AccountUser", new List<IDialogEntry>() { 
			new GuiText ("Udf", "Fingerprint"), 
			new GuiText ("ServiceAddress", "Account service address"), 
			new GuiText ("Local", "Friendly name"), 
			new GuiText ("Description", "Description"), 
			new GuiChooser ("UserChooseDevice", "Devices", "device", new List<IChooserEntry>() {
					}) 
			}) {
		};

	static readonly GuiDialog DialogContact = new (
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
			}) {
		};

	static readonly GuiDialog DialogContactNetworkAddress = new (
			"ContactNetworkAddress", new List<IDialogEntry>() { 
			new GuiIcon ("ProtocolIcon", "protocol_icon"), 
			new GuiText ("Protocol", "Protocol"), 
			new GuiText ("Address", "Address"), 
			new GuiText ("Fingerprint", "Fingerprint")
			}) {
		};

	static readonly GuiDialog DialogContactPhysicalAddress = new (
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
			}) {
		};

	static readonly GuiDialog DialogMessageContactRequest = new (
			"MessageContactRequest", new List<IDialogEntry>() { 
			new GuiText ("To", "To"), 
			new GuiText ("Comment", "Comment")
			}) {
		};

	static readonly GuiDialog DialogMessageConfirmationRequest = new (
			"MessageConfirmationRequest", new List<IDialogEntry>() { 
			new GuiText ("To", "To"), 
			new GuiText ("Request", "Request")
			}) {
		};

	static readonly GuiDialog DialogMessageMail = new (
			"MessageMail", new List<IDialogEntry>() { 
			new GuiText ("To", "To"), 
			new GuiText ("Subject", "Subject"), 
			new GuiText ("Body", "Body")
			}) {
		};

	
	}


