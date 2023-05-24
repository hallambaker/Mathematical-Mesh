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

namespace Goedel.Everything;

/// <summary>
/// Defines the graphical user interface.
/// </summary>
public partial class EverythingMaui : Gui {


	///<inheritdoc/>
	public override List<GuiIcon> Icons => icons;
	readonly List<GuiIcon> icons = new () {  
		new GuiIcon ("user") , 
		new GuiIcon ("messages") , 
		new GuiIcon ("contacts") , 
		new GuiIcon ("Documents") , 
		new GuiIcon ("groups") , 
		new GuiIcon ("feeds") , 
		new GuiIcon ("credentials") , 
		new GuiIcon ("tasks") , 
		new GuiIcon ("calendar") , 
		new GuiIcon ("applications") , 
		new GuiIcon ("devices") , 
		new GuiIcon ("Services") , 
		new GuiIcon ("settings") , 
		new GuiIcon ("test_service") , 
		new GuiIcon ("new") , 
		new GuiIcon ("connect") , 
		new GuiIcon ("recover") , 
		new GuiIcon ("contact") , 
		new GuiIcon ("mail") , 
		new GuiIcon ("chat") , 
		new GuiIcon ("voice") , 
		new GuiIcon ("video") , 
		new GuiIcon ("document_send") , 
		new GuiIcon ("document_share") 
		};

	///<inheritdoc/>
	public override List<GuiSection> Sections => sections;
	readonly List<GuiSection> sections = new () {  
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
	readonly List<GuiAction> actions = new () {  
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
	readonly List<GuiDialog> dialogs = new () {  
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
			// Button , 
			// Button , 
			// Chooser 
			}) {
		};

	static readonly GuiSection SectionMessages = new (
			"Messages", "Messages", "messages", true, new List<ISectionEntry>() {  
			// Button , 
			// Button , 
			// Button , 
			// Button , 
			// Button , 
			// Chooser , 
			// Chooser , 
			// Chooser 
			}) {
		};

	static readonly GuiSection SectionContacts = new (
			"Contacts", "Contacts", "contacts", true, new List<ISectionEntry>() {  
			// Chooser , 
			// Chooser , 
			// Chooser 
			}) {
		};

	static readonly GuiSection SectionDocuments = new (
			"Documents", "Documents", "Documents", false, new List<ISectionEntry>() {  
			// Button , 
			// Button , 
			// Chooser 
			}) {
		};

	static readonly GuiSection SectionGroups = new (
			"Groups", "Groups", "groups", false, new List<ISectionEntry>() {  
			// Chooser 
			}) {
		};

	static readonly GuiSection SectionFeeds = new (
			"Feeds", "Feeds", "feeds", false, new List<ISectionEntry>() {  
			// Chooser 
			}) {
		};

	static readonly GuiSection SectionCredentials = new (
			"Credentials", "Credentials", "credentials", false, new List<ISectionEntry>() {  
			// Chooser 
			}) {
		};

	static readonly GuiSection SectionTasks = new (
			"Tasks", "Tasks", "tasks", false, new List<ISectionEntry>() {  
			// Chooser 
			}) {
		};

	static readonly GuiSection SectionCalendar = new (
			"Calendar", "Calendar", "calendar", false, new List<ISectionEntry>() {  
			// Chooser 
			}) {
		};

	static readonly GuiSection SectionApplications = new (
			"Applications", "Applications", "applications", false, new List<ISectionEntry>() {  
			// Chooser 
			}) {
		};

	static readonly GuiSection SectionDevices = new (
			"Devices", "Devices", "devices", false, new List<ISectionEntry>() {  
			// Chooser 
			}) {
		};

	static readonly GuiSection SectionServices = new (
			"Services", "Services", "Services", false, new List<ISectionEntry>() {  
			// Chooser 
			}) {
		};

	static readonly GuiSection SectionSettings = new (
			"Settings", "Settings", "settings", true, new List<ISectionEntry>() {  
			// Dialog 
			}) {
		};

	
	// Actions
	static readonly GuiAction ActionTestService = new (
			"TestService", "Test Service", "test_service", new List<IActionEntry>() { 
			// Text 
			}) {
		};

	static readonly GuiAction ActionAccountCreate = new (
			"AccountCreate", "Create Mesh Account", "new", new List<IActionEntry>() { 
			// Text , 
			// Text , 
			// Text 
			}) {
		};

	static readonly GuiAction ActionAccountConnect = new (
			"AccountConnect", "Connect To Existing Account", "connect", new List<IActionEntry>() { 
			// Text , 
			// Text 
			}) {
		};

	static readonly GuiAction ActionAccountRecover = new (
			"AccountRecover", "Recover Mesh Account", "recover", new List<IActionEntry>() { 
			// Text , 
			// Text , 
			// Text , 
			// Text , 
			// Text , 
			// Text , 
			// Text , 
			// Text , 
			// Text , 
			// Text , 
			// Text 
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
			// Color , 
			// Color , 
			// Color , 
			// Text , 
			// Text 
			}) {
		};

	static readonly GuiDialog DialogAccountUser = new (
			"AccountUser", new List<IDialogEntry>() { 
			// Text , 
			// Text , 
			// Text , 
			// Text , 
			// Chooser 
			}) {
		};

	static readonly GuiDialog DialogContact = new (
			"Contact", new List<IDialogEntry>() { 
			// Text , 
			// Text , 
			// Text , 
			// Text , 
			// Text , 
			// Text , 
			// Chooser , 
			// Chooser 
			}) {
		};

	static readonly GuiDialog DialogContactNetworkAddress = new (
			"ContactNetworkAddress", new List<IDialogEntry>() { 
			// Icon , 
			// Text , 
			// Text , 
			// Text 
			}) {
		};

	static readonly GuiDialog DialogContactPhysicalAddress = new (
			"ContactPhysicalAddress", new List<IDialogEntry>() { 
			// Text , 
			// Text , 
			// Text , 
			// Text , 
			// Text , 
			// Text , 
			// Text , 
			// Decimal , 
			// Decimal 
			}) {
		};

	static readonly GuiDialog DialogMessageContactRequest = new (
			"MessageContactRequest", new List<IDialogEntry>() { 
			// Text , 
			// Text 
			}) {
		};

	static readonly GuiDialog DialogMessageConfirmationRequest = new (
			"MessageConfirmationRequest", new List<IDialogEntry>() { 
			// Text , 
			// Text 
			}) {
		};

	static readonly GuiDialog DialogMessageMail = new (
			"MessageMail", new List<IDialogEntry>() { 
			// Text , 
			// Text , 
			// Text 
			}) {
		};

	
	}


