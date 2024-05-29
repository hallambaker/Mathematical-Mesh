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
#pragma warning disable IDE1006 // Naming Styles

namespace Goedel.Everything;

#region // Sections
/// <summary>
/// Callback parameters for section AccountSection 
/// </summary>
public partial class AccountSection : _AccountSection {
    }

/// <summary>
/// Callback parameters for section AccountSection 
/// </summary>
public partial class _AccountSection : IBindable {

    ///<summary></summary> 
    public virtual string? ServiceAddress { get;} 

    ///<summary></summary> 
    public virtual string? ProfileUdf { get;} 

    ///<summary></summary> 
    public virtual string? LocalAddress { get;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _AccountSection,
        () => new AccountSection(),
        [ 
            new GuiBoundPropertyButton ("AccountCreate")  /* 0 */ , 
            new GuiBoundPropertyButton ("AccountRequestConnect")  /* 1 */ , 
            new GuiBoundPropertyButton ("TestService")  /* 2 */ , 
            new GuiBoundPropertyButton ("AccountRecover")  /* 3 */ , 
            new GuiBoundPropertyButton ("AccountGenerateRecovery")  /* 4 */ , 
            new GuiBoundPropertyButton ("AccountSwitch")  /* 5 */ , 
            new GuiBoundPropertyString ("ServiceAddress", "Service Address", (object data) => (data as _AccountSection)?.ServiceAddress , null)  /* 6 */ , 
            new GuiBoundPropertyString ("ProfileUdf", "Profile fingerprint", (object data) => (data as _AccountSection)?.ProfileUdf , null)  /* 7 */ , 
            new GuiBoundPropertyString ("LocalAddress", "Local Address", (object data) => (data as _AccountSection)?.LocalAddress , null)  /* 8 */ 
            ]);

    }

/// <summary>
/// Callback parameters for section MessageSection 
/// </summary>
public partial class MessageSection : _MessageSection {
    }

/// <summary>
/// Callback parameters for section MessageSection 
/// </summary>
public partial class _MessageSection : IBindable {

    ///<summary></summary> 
    public virtual ISelectCollection? ChooseMessage { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingMultiple BaseBinding  { get; } = new (
        (object test) => test is _MessageSection,
        () => new MessageSection(),
        [ 
            new GuiBoundPropertyButton ("RequestContact")  /* 0 */ , 
            new GuiBoundPropertyButton ("RequestConfirmation")  /* 1 */ , 
            new GuiBoundPropertyButton ("CreateMail")  /* 2 */ , 
            new GuiBoundPropertyButton ("CreateChat")  /* 3 */ , 
            new GuiBoundPropertyButton ("StartVoice")  /* 4 */ , 
            new GuiBoundPropertyButton ("StartVideo")  /* 5 */ , 
            new GuiBoundPropertyChooser ("ChooseMessage", "Messages", (object data) => (data as _MessageSection)?.ChooseMessage , null)  /* 6 */ 
            ], 6
);

    }

/// <summary>
/// Callback parameters for section ContactSection 
/// </summary>
public partial class ContactSection : _ContactSection {
    }

/// <summary>
/// Callback parameters for section ContactSection 
/// </summary>
public partial class _ContactSection : IBindable {

    ///<summary></summary> 
    public virtual ISelectCollection? ChooseContact { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingMultiple BaseBinding  { get; } = new (
        (object test) => test is _ContactSection,
        () => new ContactSection(),
        [ 
            new GuiBoundPropertyButton ("AddPerson")  /* 0 */ , 
            new GuiBoundPropertyButton ("AddOrganization")  /* 1 */ , 
            new GuiBoundPropertyButton ("AddLocation")  /* 2 */ , 
            new GuiBoundPropertyButton ("QrContact")  /* 3 */ , 
            new GuiBoundPropertyButton ("RequestContact")  /* 4 */ , 
            new GuiBoundPropertyChooser ("ChooseContact", "Contacts", (object data) => (data as _ContactSection)?.ChooseContact , null)  /* 5 */ 
            ], 5
);

    }

/// <summary>
/// Callback parameters for section DocumentSection 
/// </summary>
public partial class DocumentSection : _DocumentSection {
    }

/// <summary>
/// Callback parameters for section DocumentSection 
/// </summary>
public partial class _DocumentSection : IBindable {

    ///<summary></summary> 
    public virtual ISelectCollection? ChooseDocuments { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingMultiple BaseBinding  { get; } = new (
        (object test) => test is _DocumentSection,
        () => new DocumentSection(),
        [ 
            new GuiBoundPropertyButton ("UploadDocument")  /* 0 */ , 
            new GuiBoundPropertyChooser ("ChooseDocuments", "Documents", (object data) => (data as _DocumentSection)?.ChooseDocuments , null)  /* 1 */ 
            ], 1
);

    }

/// <summary>
/// Callback parameters for section FeedSection 
/// </summary>
public partial class FeedSection : _FeedSection {
    }

/// <summary>
/// Callback parameters for section FeedSection 
/// </summary>
public partial class _FeedSection : IBindable {

    ///<summary></summary> 
    public virtual ISelectCollection? ChooseFeed { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingMultiple BaseBinding  { get; } = new (
        (object test) => test is _FeedSection,
        () => new FeedSection(),
        [ 
            new GuiBoundPropertyChooser ("ChooseFeed", "Feeds", (object data) => (data as _FeedSection)?.ChooseFeed , null)  /* 0 */ 
            ], 0
);

    }

/// <summary>
/// Callback parameters for section GroupSection 
/// </summary>
public partial class GroupSection : _GroupSection {
    }

/// <summary>
/// Callback parameters for section GroupSection 
/// </summary>
public partial class _GroupSection : IBindable {

    ///<summary></summary> 
    public virtual ISelectCollection? ChooseGroup { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingMultiple BaseBinding  { get; } = new (
        (object test) => test is _GroupSection,
        () => new GroupSection(),
        [ 
            new GuiBoundPropertyButton ("AddGroup")  /* 0 */ , 
            new GuiBoundPropertyChooser ("ChooseGroup", "User", (object data) => (data as _GroupSection)?.ChooseGroup , null)  /* 1 */ 
            ], 1
);

    }

/// <summary>
/// Callback parameters for section CredentialSection 
/// </summary>
public partial class CredentialSection : _CredentialSection {
    }

/// <summary>
/// Callback parameters for section CredentialSection 
/// </summary>
public partial class _CredentialSection : IBindable {

    ///<summary></summary> 
    public virtual ISelectCollection? ChooseCredential { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingMultiple BaseBinding  { get; } = new (
        (object test) => test is _CredentialSection,
        () => new CredentialSection(),
        [ 
            new GuiBoundPropertyButton ("AddPassword")  /* 0 */ , 
            new GuiBoundPropertyButton ("AddPasskey")  /* 1 */ , 
            new GuiBoundPropertyChooser ("ChooseCredential", "Credentials", (object data) => (data as _CredentialSection)?.ChooseCredential , null)  /* 2 */ 
            ], 2
);

    }

/// <summary>
/// Callback parameters for section TaskSection 
/// </summary>
public partial class TaskSection : _TaskSection {
    }

/// <summary>
/// Callback parameters for section TaskSection 
/// </summary>
public partial class _TaskSection : IBindable {

    ///<summary></summary> 
    public virtual ISelectCollection? ChooseTask { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingMultiple BaseBinding  { get; } = new (
        (object test) => test is _TaskSection,
        () => new TaskSection(),
        [ 
            new GuiBoundPropertyButton ("AddTask")  /* 0 */ , 
            new GuiBoundPropertyChooser ("ChooseTask", "Tasks", (object data) => (data as _TaskSection)?.ChooseTask , null)  /* 1 */ 
            ], 1
);

    }

/// <summary>
/// Callback parameters for section CalendarSection 
/// </summary>
public partial class CalendarSection : _CalendarSection {
    }

/// <summary>
/// Callback parameters for section CalendarSection 
/// </summary>
public partial class _CalendarSection : IBindable {

    ///<summary></summary> 
    public virtual ISelectCollection? ChooseAppointment { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingMultiple BaseBinding  { get; } = new (
        (object test) => test is _CalendarSection,
        () => new CalendarSection(),
        [ 
            new GuiBoundPropertyButton ("AddTask")  /* 0 */ , 
            new GuiBoundPropertyChooser ("ChooseAppointment", "Tasks", (object data) => (data as _CalendarSection)?.ChooseAppointment , null)  /* 1 */ 
            ], 1
);

    }

/// <summary>
/// Callback parameters for section BookmarkSection 
/// </summary>
public partial class BookmarkSection : _BookmarkSection {
    }

/// <summary>
/// Callback parameters for section BookmarkSection 
/// </summary>
public partial class _BookmarkSection : IBindable {

    ///<summary></summary> 
    public virtual ISelectCollection? ChooseBookmark { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingMultiple BaseBinding  { get; } = new (
        (object test) => test is _BookmarkSection,
        () => new BookmarkSection(),
        [ 
            new GuiBoundPropertyButton ("AddBookmark")  /* 0 */ , 
            new GuiBoundPropertyChooser ("ChooseBookmark", "Bookmark", (object data) => (data as _BookmarkSection)?.ChooseBookmark , null)  /* 1 */ 
            ], 1
);

    }

/// <summary>
/// Callback parameters for section ApplicationSection 
/// </summary>
public partial class ApplicationSection : _ApplicationSection {
    }

/// <summary>
/// Callback parameters for section ApplicationSection 
/// </summary>
public partial class _ApplicationSection : IBindable {

    ///<summary></summary> 
    public virtual ISelectCollection? ChooseApplication { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingMultiple BaseBinding  { get; } = new (
        (object test) => test is _ApplicationSection,
        () => new ApplicationSection(),
        [ 
            new GuiBoundPropertyButton ("AddMailAccount")  /* 0 */ , 
            new GuiBoundPropertyButton ("AddSshAccount")  /* 1 */ , 
            new GuiBoundPropertyButton ("AddGitAccount")  /* 2 */ , 
            new GuiBoundPropertyButton ("AddCodeSigningKey")  /* 3 */ , 
            new GuiBoundPropertyChooser ("ChooseApplication", "Applications", (object data) => (data as _ApplicationSection)?.ChooseApplication , null)  /* 4 */ 
            ], 4
);

    }

/// <summary>
/// Callback parameters for section DeviceSection 
/// </summary>
public partial class DeviceSection : _DeviceSection {
    }

/// <summary>
/// Callback parameters for section DeviceSection 
/// </summary>
public partial class _DeviceSection : IBindable {

    ///<summary></summary> 
    public virtual ISelectCollection? ChooseDevice { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingMultiple BaseBinding  { get; } = new (
        (object test) => test is _DeviceSection,
        () => new DeviceSection(),
        [ 
            new GuiBoundPropertyButton ("DeviceConnectQR")  /* 0 */ , 
            new GuiBoundPropertyButton ("AccountGetPin")  /* 1 */ , 
            new GuiBoundPropertyChooser ("ChooseDevice", "Devices", (object data) => (data as _DeviceSection)?.ChooseDevice , null)  /* 2 */ 
            ], 2
);

    }

/// <summary>
/// Callback parameters for section ServiceSection 
/// </summary>
public partial class ServiceSection : _ServiceSection {
    }

/// <summary>
/// Callback parameters for section ServiceSection 
/// </summary>
public partial class _ServiceSection : IBindable {

    ///<summary></summary> 
    public virtual ISelectCollection? ChooseService { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingMultiple BaseBinding  { get; } = new (
        (object test) => test is _ServiceSection,
        () => new ServiceSection(),
        [ 
            new GuiBoundPropertyChooser ("ChooseService", "Services", (object data) => (data as _ServiceSection)?.ChooseService , null)  /* 0 */ 
            ], 0
);

    }

/// <summary>
/// Callback parameters for section SettingSection 
/// </summary>
public partial class SettingSection : _SettingSection {
    }

/// <summary>
/// Callback parameters for section SettingSection 
/// </summary>
public partial class _SettingSection : IBindable {

    ///<summary></summary> 
    public virtual IFieldColor? BackgroundColor { get; set;} 

    ///<summary></summary> 
    public virtual IFieldColor? HighlightColor { get; set;} 

    ///<summary></summary> 
    public virtual IFieldColor? TextColor { get; set;} 

    ///<summary></summary> 
    public virtual IFieldSize? TextSize { get; set;} 

    ///<summary></summary> 
    public virtual IFieldSize? IconSize { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _SettingSection,
        () => new SettingSection(),
        [ 
            new GuiBoundPropertyColor ("BackgroundColor", "Background Color", (object data) => (data as _SettingSection)?.BackgroundColor , 
                (object data,IFieldColor? value) => { if (data is _SettingSection datad) { datad.BackgroundColor = value; }})  /* 0 */ , 
            new GuiBoundPropertyColor ("HighlightColor", "Highlight Color", (object data) => (data as _SettingSection)?.HighlightColor , 
                (object data,IFieldColor? value) => { if (data is _SettingSection datad) { datad.HighlightColor = value; }})  /* 1 */ , 
            new GuiBoundPropertyColor ("TextColor", "Text Color", (object data) => (data as _SettingSection)?.TextColor , 
                (object data,IFieldColor? value) => { if (data is _SettingSection datad) { datad.TextColor = value; }})  /* 2 */ , 
            new GuiBoundPropertySize ("TextSize", "Text Size", (object data) => (data as _SettingSection)?.TextSize , 
                (object data,IFieldSize? value) => { if (data is _SettingSection datad) { datad.TextSize = value; }})  /* 3 */ , 
            new GuiBoundPropertySize ("IconSize", "Icon Size", (object data) => (data as _SettingSection)?.IconSize , 
                (object data,IFieldSize? value) => { if (data is _SettingSection datad) { datad.IconSize = value; }})  /* 4 */ 
            ]);

    }

#endregion
#region // Dialogs
/// <summary>
/// Callback parameters for dialog BoundAccount 
/// </summary>
public partial class BoundAccount : _BoundAccount {
    // <summary>Type check verification.</summary>
    // public static  Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundAccount 
/// </summary>
public partial class _BoundAccount : IParameter {

    public object? Bound { get; set; }


    ///<summary></summary> 
    public virtual string? Display { get;} 

    ///<summary></summary> 
    public virtual bool? Default { get; set;} 

    ///<summary></summary> 
    public virtual string? Service { get;} 

    ///<summary></summary> 
    public virtual string? UDF { get;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundAccount,
        () => new BoundAccount(),
        [ 
            new GuiBoundPropertyString ("Display", "Display name", (object data) => (data as _BoundAccount)?.Display , null)  /* 0 */ , 
            new GuiBoundPropertyBoolean ("Default", "Default", (object data) => (data as _BoundAccount)?.Default , 
                (object data,bool? value) => { if (data is _BoundAccount datad) { datad.Default = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Service", "Service", (object data) => (data as _BoundAccount)?.Service , null)  /* 2 */ , 
            new GuiBoundPropertyString ("UDF", "Fingerprint", (object data) => (data as _BoundAccount)?.UDF , null)  /* 3 */ , 
            new GuiBoundPropertySelection ("AccountSelect", "Switch")  /* 4 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundMessage 
/// </summary>
public partial class BoundMessage : _BoundMessage {
    // <summary>Type check verification.</summary>
    // public static  Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundMessage 
/// </summary>
public partial class _BoundMessage : IParameter {

    public object? Bound { get; set; }


    ///<summary></summary> 
    public virtual IFieldIcon? Type { get;} 

    ///<summary></summary> 
    public virtual string? Category { get;} 

    ///<summary></summary> 
    public virtual string? TimeSent { get; set;} 

    ///<summary></summary> 
    public virtual string? Sender { get; set;} 

    ///<summary></summary> 
    public virtual string? Subject { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundMessage,
        () => new BoundMessage(),
        [ 
            new GuiBoundPropertyIcon ("Type", "Type", (object data) => (data as _BoundMessage)?.Type , null)  /* 0 */ , 
            new GuiBoundPropertyString ("Category", "Category", (object data) => (data as _BoundMessage)?.Category , null, Width: 100)  /* 1 */ , 
            new GuiBoundPropertyString ("TimeSent", "Sent", (object data) => (data as _BoundMessage)?.TimeSent , 
                (object data,string? value) => { if (data is _BoundMessage datad) { datad.TimeSent = value; }}, Width: 100)  /* 2 */ , 
            new GuiBoundPropertyString ("Sender", "Sender", (object data) => (data as _BoundMessage)?.Sender , 
                (object data,string? value) => { if (data is _BoundMessage datad) { datad.Sender = value; }}, Width: 150)  /* 3 */ , 
            new GuiBoundPropertyString ("Subject", "Subject", (object data) => (data as _BoundMessage)?.Subject , 
                (object data,string? value) => { if (data is _BoundMessage datad) { datad.Subject = value; }}, Width: 300)  /* 4 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundMailMail 
/// </summary>
public partial class BoundMailMail : _BoundMailMail {
    // <summary>Type check verification.</summary>
    // public static new Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundMailMail 
/// </summary>
public partial class _BoundMailMail : BoundMessage {


    ///<summary></summary> 
    public virtual string? Message { get; set;} 


    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundMailMail,
        () => new BoundMailMail(),
        [ 
            new GuiBoundPropertyIcon ("Type", "Type", (object data) => (data as _BoundMailMail)?.Type , null)  /* 0 */ , 
            new GuiBoundPropertyString ("Category", "Category", (object data) => (data as _BoundMailMail)?.Category , null, Width: 100)  /* 1 */ , 
            new GuiBoundPropertyString ("TimeSent", "Sent", (object data) => (data as _BoundMailMail)?.TimeSent , 
                (object data,string? value) => { if (data is _BoundMailMail datad) { datad.TimeSent = value; }}, Width: 100)  /* 2 */ , 
            new GuiBoundPropertyString ("Sender", "Sender", (object data) => (data as _BoundMailMail)?.Sender , 
                (object data,string? value) => { if (data is _BoundMailMail datad) { datad.Sender = value; }}, Width: 150)  /* 3 */ , 
            new GuiBoundPropertyString ("Subject", "Subject", (object data) => (data as _BoundMailMail)?.Subject , 
                (object data,string? value) => { if (data is _BoundMailMail datad) { datad.Subject = value; }}, Width: 300)  /* 4 */ , 
            new GuiBoundTextArea ("Message", "Message", (object data) => (data as _BoundMailMail)?.Message , 
                (object data,string? value) => { if (data is _BoundMailMail datad) { datad.Message = value; }})  /* 5 */ 
            ]);
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public override IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public override IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundMessageActionRequest 
/// </summary>
public partial class BoundMessageActionRequest : _BoundMessageActionRequest {
    // <summary>Type check verification.</summary>
    // public static new Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundMessageActionRequest 
/// </summary>
public partial class _BoundMessageActionRequest : BoundMessage {


    ///<summary></summary> 
    public virtual string? RequestMessage { get; set;} 


    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundMessageActionRequest,
        () => new BoundMessageActionRequest(),
        [ 
            new GuiBoundPropertyIcon ("Type", "Type", (object data) => (data as _BoundMessageActionRequest)?.Type , null)  /* 0 */ , 
            new GuiBoundPropertyString ("Category", "Category", (object data) => (data as _BoundMessageActionRequest)?.Category , null, Width: 100)  /* 1 */ , 
            new GuiBoundPropertyString ("TimeSent", "Sent", (object data) => (data as _BoundMessageActionRequest)?.TimeSent , 
                (object data,string? value) => { if (data is _BoundMessageActionRequest datad) { datad.TimeSent = value; }}, Width: 100)  /* 2 */ , 
            new GuiBoundPropertyString ("Sender", "Sender", (object data) => (data as _BoundMessageActionRequest)?.Sender , 
                (object data,string? value) => { if (data is _BoundMessageActionRequest datad) { datad.Sender = value; }}, Width: 150)  /* 3 */ , 
            new GuiBoundPropertyString ("Subject", "Subject", (object data) => (data as _BoundMessageActionRequest)?.Subject , 
                (object data,string? value) => { if (data is _BoundMessageActionRequest datad) { datad.Subject = value; }}, Width: 300)  /* 4 */ , 
            new GuiBoundPropertyString ("RequestMessage", "Details", (object data) => (data as _BoundMessageActionRequest)?.RequestMessage , 
                (object data,string? value) => { if (data is _BoundMessageActionRequest datad) { datad.RequestMessage = value; }})  /* 5 */ , 
            new GuiBoundPropertySelection ("ActionAccept", "Accept")  /* 6 */ , 
            new GuiBoundPropertySelection ("ActionReject", "Reject")  /* 7 */ 
            ]);
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public override IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public override IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundMessageConfirmationRequest 
/// </summary>
public partial class BoundMessageConfirmationRequest : _BoundMessageConfirmationRequest {
    // <summary>Type check verification.</summary>
    // public static new Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundMessageConfirmationRequest 
/// </summary>
public partial class _BoundMessageConfirmationRequest : BoundMessageActionRequest {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundMessageConfirmationRequest,
        () => new BoundMessageConfirmationRequest(),
        [ 
            new GuiBoundPropertyIcon ("Type", "Type", (object data) => (data as _BoundMessageConfirmationRequest)?.Type , null)  /* 0 */ , 
            new GuiBoundPropertyString ("Category", "Category", (object data) => (data as _BoundMessageConfirmationRequest)?.Category , null, Width: 100)  /* 1 */ , 
            new GuiBoundPropertyString ("TimeSent", "Sent", (object data) => (data as _BoundMessageConfirmationRequest)?.TimeSent , 
                (object data,string? value) => { if (data is _BoundMessageConfirmationRequest datad) { datad.TimeSent = value; }}, Width: 100)  /* 2 */ , 
            new GuiBoundPropertyString ("Sender", "Sender", (object data) => (data as _BoundMessageConfirmationRequest)?.Sender , 
                (object data,string? value) => { if (data is _BoundMessageConfirmationRequest datad) { datad.Sender = value; }}, Width: 150)  /* 3 */ , 
            new GuiBoundPropertyString ("Subject", "Subject", (object data) => (data as _BoundMessageConfirmationRequest)?.Subject , 
                (object data,string? value) => { if (data is _BoundMessageConfirmationRequest datad) { datad.Subject = value; }}, Width: 300)  /* 4 */ , 
            new GuiBoundPropertyString ("RequestMessage", "Details", (object data) => (data as _BoundMessageConfirmationRequest)?.RequestMessage , 
                (object data,string? value) => { if (data is _BoundMessageConfirmationRequest datad) { datad.RequestMessage = value; }})  /* 5 */ , 
            new GuiBoundPropertySelection ("ActionAccept", "Accept")  /* 6 */ , 
            new GuiBoundPropertySelection ("ActionReject", "Reject")  /* 7 */ 
            ]);
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public override IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public override IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundMessageConfirmationResponse 
/// </summary>
public partial class BoundMessageConfirmationResponse : _BoundMessageConfirmationResponse {
    // <summary>Type check verification.</summary>
    // public static new Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundMessageConfirmationResponse 
/// </summary>
public partial class _BoundMessageConfirmationResponse : BoundMessage {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundMessageConfirmationResponse,
        () => new BoundMessageConfirmationResponse(),
        [ 
            new GuiBoundPropertyIcon ("Type", "Type", (object data) => (data as _BoundMessageConfirmationResponse)?.Type , null)  /* 0 */ , 
            new GuiBoundPropertyString ("Category", "Category", (object data) => (data as _BoundMessageConfirmationResponse)?.Category , null, Width: 100)  /* 1 */ , 
            new GuiBoundPropertyString ("TimeSent", "Sent", (object data) => (data as _BoundMessageConfirmationResponse)?.TimeSent , 
                (object data,string? value) => { if (data is _BoundMessageConfirmationResponse datad) { datad.TimeSent = value; }}, Width: 100)  /* 2 */ , 
            new GuiBoundPropertyString ("Sender", "Sender", (object data) => (data as _BoundMessageConfirmationResponse)?.Sender , 
                (object data,string? value) => { if (data is _BoundMessageConfirmationResponse datad) { datad.Sender = value; }}, Width: 150)  /* 3 */ , 
            new GuiBoundPropertyString ("Subject", "Subject", (object data) => (data as _BoundMessageConfirmationResponse)?.Subject , 
                (object data,string? value) => { if (data is _BoundMessageConfirmationResponse datad) { datad.Subject = value; }}, Width: 300)  /* 4 */ 
            ]);
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public override IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public override IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundMessageContactRequest 
/// </summary>
public partial class BoundMessageContactRequest : _BoundMessageContactRequest {
    // <summary>Type check verification.</summary>
    // public static new Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundMessageContactRequest 
/// </summary>
public partial class _BoundMessageContactRequest : BoundMessageActionRequest {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundMessageContactRequest,
        () => new BoundMessageContactRequest(),
        [ 
            new GuiBoundPropertyIcon ("Type", "Type", (object data) => (data as _BoundMessageContactRequest)?.Type , null)  /* 0 */ , 
            new GuiBoundPropertyString ("Category", "Category", (object data) => (data as _BoundMessageContactRequest)?.Category , null, Width: 100)  /* 1 */ , 
            new GuiBoundPropertyString ("TimeSent", "Sent", (object data) => (data as _BoundMessageContactRequest)?.TimeSent , 
                (object data,string? value) => { if (data is _BoundMessageContactRequest datad) { datad.TimeSent = value; }}, Width: 100)  /* 2 */ , 
            new GuiBoundPropertyString ("Sender", "Sender", (object data) => (data as _BoundMessageContactRequest)?.Sender , 
                (object data,string? value) => { if (data is _BoundMessageContactRequest datad) { datad.Sender = value; }}, Width: 150)  /* 3 */ , 
            new GuiBoundPropertyString ("Subject", "Subject", (object data) => (data as _BoundMessageContactRequest)?.Subject , 
                (object data,string? value) => { if (data is _BoundMessageContactRequest datad) { datad.Subject = value; }}, Width: 300)  /* 4 */ , 
            new GuiBoundPropertyString ("RequestMessage", "Details", (object data) => (data as _BoundMessageContactRequest)?.RequestMessage , 
                (object data,string? value) => { if (data is _BoundMessageContactRequest datad) { datad.RequestMessage = value; }})  /* 5 */ , 
            new GuiBoundPropertySelection ("ActionAccept", "Accept")  /* 6 */ , 
            new GuiBoundPropertySelection ("ActionReject", "Reject")  /* 7 */ 
            ]);
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public override IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public override IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundMessageAcknowledgeConnection 
/// </summary>
public partial class BoundMessageAcknowledgeConnection : _BoundMessageAcknowledgeConnection {
    // <summary>Type check verification.</summary>
    // public static new Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundMessageAcknowledgeConnection 
/// </summary>
public partial class _BoundMessageAcknowledgeConnection : BoundMessageActionRequest {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundMessageAcknowledgeConnection,
        () => new BoundMessageAcknowledgeConnection(),
        [ 
            new GuiBoundPropertyIcon ("Type", "Type", (object data) => (data as _BoundMessageAcknowledgeConnection)?.Type , null)  /* 0 */ , 
            new GuiBoundPropertyString ("Category", "Category", (object data) => (data as _BoundMessageAcknowledgeConnection)?.Category , null, Width: 100)  /* 1 */ , 
            new GuiBoundPropertyString ("TimeSent", "Sent", (object data) => (data as _BoundMessageAcknowledgeConnection)?.TimeSent , 
                (object data,string? value) => { if (data is _BoundMessageAcknowledgeConnection datad) { datad.TimeSent = value; }}, Width: 100)  /* 2 */ , 
            new GuiBoundPropertyString ("Sender", "Sender", (object data) => (data as _BoundMessageAcknowledgeConnection)?.Sender , 
                (object data,string? value) => { if (data is _BoundMessageAcknowledgeConnection datad) { datad.Sender = value; }}, Width: 150)  /* 3 */ , 
            new GuiBoundPropertyString ("Subject", "Subject", (object data) => (data as _BoundMessageAcknowledgeConnection)?.Subject , 
                (object data,string? value) => { if (data is _BoundMessageAcknowledgeConnection datad) { datad.Subject = value; }}, Width: 300)  /* 4 */ , 
            new GuiBoundPropertyString ("RequestMessage", "Details", (object data) => (data as _BoundMessageAcknowledgeConnection)?.RequestMessage , 
                (object data,string? value) => { if (data is _BoundMessageAcknowledgeConnection datad) { datad.RequestMessage = value; }})  /* 5 */ , 
            new GuiBoundPropertySelection ("ActionAccept", "Accept")  /* 6 */ , 
            new GuiBoundPropertySelection ("ActionReject", "Reject")  /* 7 */ 
            ]);
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public override IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public override IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundMessageConnectionRequest 
/// </summary>
public partial class BoundMessageConnectionRequest : _BoundMessageConnectionRequest {
    // <summary>Type check verification.</summary>
    // public static new Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundMessageConnectionRequest 
/// </summary>
public partial class _BoundMessageConnectionRequest : BoundMessageActionRequest {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundMessageConnectionRequest,
        () => new BoundMessageConnectionRequest(),
        [ 
            new GuiBoundPropertyIcon ("Type", "Type", (object data) => (data as _BoundMessageConnectionRequest)?.Type , null)  /* 0 */ , 
            new GuiBoundPropertyString ("Category", "Category", (object data) => (data as _BoundMessageConnectionRequest)?.Category , null, Width: 100)  /* 1 */ , 
            new GuiBoundPropertyString ("TimeSent", "Sent", (object data) => (data as _BoundMessageConnectionRequest)?.TimeSent , 
                (object data,string? value) => { if (data is _BoundMessageConnectionRequest datad) { datad.TimeSent = value; }}, Width: 100)  /* 2 */ , 
            new GuiBoundPropertyString ("Sender", "Sender", (object data) => (data as _BoundMessageConnectionRequest)?.Sender , 
                (object data,string? value) => { if (data is _BoundMessageConnectionRequest datad) { datad.Sender = value; }}, Width: 150)  /* 3 */ , 
            new GuiBoundPropertyString ("Subject", "Subject", (object data) => (data as _BoundMessageConnectionRequest)?.Subject , 
                (object data,string? value) => { if (data is _BoundMessageConnectionRequest datad) { datad.Subject = value; }}, Width: 300)  /* 4 */ , 
            new GuiBoundPropertyString ("RequestMessage", "Details", (object data) => (data as _BoundMessageConnectionRequest)?.RequestMessage , 
                (object data,string? value) => { if (data is _BoundMessageConnectionRequest datad) { datad.RequestMessage = value; }})  /* 5 */ , 
            new GuiBoundPropertySelection ("ActionAccept", "Accept")  /* 6 */ , 
            new GuiBoundPropertySelection ("ActionReject", "Reject")  /* 7 */ 
            ]);
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public override IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public override IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundMessageGroupInvitation 
/// </summary>
public partial class BoundMessageGroupInvitation : _BoundMessageGroupInvitation {
    // <summary>Type check verification.</summary>
    // public static new Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundMessageGroupInvitation 
/// </summary>
public partial class _BoundMessageGroupInvitation : BoundMessageActionRequest {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundMessageGroupInvitation,
        () => new BoundMessageGroupInvitation(),
        [ 
            new GuiBoundPropertyIcon ("Type", "Type", (object data) => (data as _BoundMessageGroupInvitation)?.Type , null)  /* 0 */ , 
            new GuiBoundPropertyString ("Category", "Category", (object data) => (data as _BoundMessageGroupInvitation)?.Category , null, Width: 100)  /* 1 */ , 
            new GuiBoundPropertyString ("TimeSent", "Sent", (object data) => (data as _BoundMessageGroupInvitation)?.TimeSent , 
                (object data,string? value) => { if (data is _BoundMessageGroupInvitation datad) { datad.TimeSent = value; }}, Width: 100)  /* 2 */ , 
            new GuiBoundPropertyString ("Sender", "Sender", (object data) => (data as _BoundMessageGroupInvitation)?.Sender , 
                (object data,string? value) => { if (data is _BoundMessageGroupInvitation datad) { datad.Sender = value; }}, Width: 150)  /* 3 */ , 
            new GuiBoundPropertyString ("Subject", "Subject", (object data) => (data as _BoundMessageGroupInvitation)?.Subject , 
                (object data,string? value) => { if (data is _BoundMessageGroupInvitation datad) { datad.Subject = value; }}, Width: 300)  /* 4 */ , 
            new GuiBoundPropertyString ("RequestMessage", "Details", (object data) => (data as _BoundMessageGroupInvitation)?.RequestMessage , 
                (object data,string? value) => { if (data is _BoundMessageGroupInvitation datad) { datad.RequestMessage = value; }})  /* 5 */ , 
            new GuiBoundPropertySelection ("ActionAccept", "Accept")  /* 6 */ , 
            new GuiBoundPropertySelection ("ActionReject", "Reject")  /* 7 */ 
            ]);
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public override IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public override IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundMessageTaskRequest 
/// </summary>
public partial class BoundMessageTaskRequest : _BoundMessageTaskRequest {
    // <summary>Type check verification.</summary>
    // public static new Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundMessageTaskRequest 
/// </summary>
public partial class _BoundMessageTaskRequest : BoundMessageActionRequest {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundMessageTaskRequest,
        () => new BoundMessageTaskRequest(),
        [ 
            new GuiBoundPropertyIcon ("Type", "Type", (object data) => (data as _BoundMessageTaskRequest)?.Type , null)  /* 0 */ , 
            new GuiBoundPropertyString ("Category", "Category", (object data) => (data as _BoundMessageTaskRequest)?.Category , null, Width: 100)  /* 1 */ , 
            new GuiBoundPropertyString ("TimeSent", "Sent", (object data) => (data as _BoundMessageTaskRequest)?.TimeSent , 
                (object data,string? value) => { if (data is _BoundMessageTaskRequest datad) { datad.TimeSent = value; }}, Width: 100)  /* 2 */ , 
            new GuiBoundPropertyString ("Sender", "Sender", (object data) => (data as _BoundMessageTaskRequest)?.Sender , 
                (object data,string? value) => { if (data is _BoundMessageTaskRequest datad) { datad.Sender = value; }}, Width: 150)  /* 3 */ , 
            new GuiBoundPropertyString ("Subject", "Subject", (object data) => (data as _BoundMessageTaskRequest)?.Subject , 
                (object data,string? value) => { if (data is _BoundMessageTaskRequest datad) { datad.Subject = value; }}, Width: 300)  /* 4 */ , 
            new GuiBoundPropertyString ("RequestMessage", "Details", (object data) => (data as _BoundMessageTaskRequest)?.RequestMessage , 
                (object data,string? value) => { if (data is _BoundMessageTaskRequest datad) { datad.RequestMessage = value; }})  /* 5 */ , 
            new GuiBoundPropertySelection ("ActionAccept", "Accept")  /* 6 */ , 
            new GuiBoundPropertySelection ("ActionReject", "Reject")  /* 7 */ 
            ]);
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public override IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public override IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundContact 
/// </summary>
public partial class BoundContact : _BoundContact {
    // <summary>Type check verification.</summary>
    // public static  Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundContact 
/// </summary>
public partial class _BoundContact : IParameter {

    public object? Bound { get; set; }


    ///<summary></summary> 
    public virtual IFieldIcon? Type { get;} 

    ///<summary></summary> 
    public virtual string? Display { get;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundContact,
        () => new BoundContact(),
        [ 
            new GuiBoundPropertyIcon ("Type", "Type", (object data) => (data as _BoundContact)?.Type , null)  /* 0 */ , 
            new GuiBoundPropertyString ("Display", "Display name", (object data) => (data as _BoundContact)?.Display , null)  /* 1 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundContactPerson 
/// </summary>
public partial class BoundContactPerson : _BoundContactPerson {
    // <summary>Type check verification.</summary>
    // public static new Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundContactPerson 
/// </summary>
public partial class _BoundContactPerson : BoundContact {


    ///<summary></summary> 
    public virtual bool? Self { get; set;} 

    ///<summary></summary> 
    public virtual string? Local { get; set;} 

    ///<summary></summary> 
    public virtual string? First { get; set;} 

    ///<summary></summary> 
    public virtual string? Last { get; set;} 

    ///<summary></summary> 
    public virtual string? Prefix { get; set;} 

    ///<summary></summary> 
    public virtual string? Suffix { get; set;} 

    ///<summary></summary> 
    public virtual ISelectList? NetworkAddresses { get; set;} 

    ///<summary></summary> 
    public virtual ISelectList? PhysicalAddresses { get; set;} 


    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundContactPerson,
        () => new BoundContactPerson(),
        [ 
            new GuiBoundPropertyIcon ("Type", "Type", (object data) => (data as _BoundContactPerson)?.Type , null)  /* 0 */ , 
            new GuiBoundPropertyString ("Display", "Display name", (object data) => (data as _BoundContactPerson)?.Display , null)  /* 1 */ , 
            new GuiBoundPropertyBoolean ("Self", "Self", (object data) => (data as _BoundContactPerson)?.Self , 
                (object data,bool? value) => { if (data is _BoundContactPerson datad) { datad.Self = value; }})  /* 2 */ , 
            new GuiBoundPropertyString ("Local", "Friendly name", (object data) => (data as _BoundContactPerson)?.Local , 
                (object data,string? value) => { if (data is _BoundContactPerson datad) { datad.Local = value; }})  /* 3 */ , 
            new GuiBoundPropertyString ("First", "First name", (object data) => (data as _BoundContactPerson)?.First , 
                (object data,string? value) => { if (data is _BoundContactPerson datad) { datad.First = value; }})  /* 4 */ , 
            new GuiBoundPropertyString ("Last", "Last name", (object data) => (data as _BoundContactPerson)?.Last , 
                (object data,string? value) => { if (data is _BoundContactPerson datad) { datad.Last = value; }})  /* 5 */ , 
            new GuiBoundPropertyString ("Prefix", "Prefix", (object data) => (data as _BoundContactPerson)?.Prefix , 
                (object data,string? value) => { if (data is _BoundContactPerson datad) { datad.Prefix = value; }})  /* 6 */ , 
            new GuiBoundPropertyString ("Suffix", "Suffix", (object data) => (data as _BoundContactPerson)?.Suffix , 
                (object data,string? value) => { if (data is _BoundContactPerson datad) { datad.Suffix = value; }})  /* 7 */ , 
            new GuiBoundPropertyList ("NetworkAddresses", "Network Addresses", (object data) => (data as _BoundContactPerson)?.NetworkAddresses , 
                (object data,ISelectList? value) => { if (data is _BoundContactPerson datad) { datad.NetworkAddresses = value; }}, _ContactNetworkIdentifier.BaseBinding)  /* 8 */ , 
            new GuiBoundPropertyList ("PhysicalAddresses", "Locations", (object data) => (data as _BoundContactPerson)?.PhysicalAddresses , 
                (object data,ISelectList? value) => { if (data is _BoundContactPerson datad) { datad.PhysicalAddresses = value; }}, _ContactPhysicalAddress.BaseBinding)  /* 9 */ , 
            new GuiBoundPropertyButton ("ContactAddNetwork")  /* 10 */ , 
            new GuiBoundPropertyButton ("ContactAddCredential")  /* 11 */ , 
            new GuiBoundPropertyButton ("ContactAddPostal")  /* 12 */ 
            ]);
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public override IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public override IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog ContactNetworkIdentifier 
/// </summary>
public partial class ContactNetworkIdentifier : _ContactNetworkIdentifier {
    // <summary>Type check verification.</summary>
    // public static new Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section ContactNetworkIdentifier 
/// </summary>
public partial class _ContactNetworkIdentifier : ContactNetworkAddress {


    ///<summary></summary> 
    public virtual string? Protocol { get; set;} 

    ///<summary></summary> 
    public virtual string? Address { get; set;} 

    ///<summary></summary> 
    public virtual string? Fingerprint { get; set;} 

    ///<summary></summary> 
    public virtual IDataActions? Actions { get;} 


    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _ContactNetworkIdentifier,
        () => new ContactNetworkIdentifier(),
        [ 
            new GuiBoundPropertyIcon ("Type", "Type", (object data) => (data as _ContactNetworkIdentifier)?.Type , null)  /* 0 */ , 
            new GuiBoundPropertyString ("Protocol", "Protocol", (object data) => (data as _ContactNetworkIdentifier)?.Protocol , 
                (object data,string? value) => { if (data is _ContactNetworkIdentifier datad) { datad.Protocol = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Address", "Address", (object data) => (data as _ContactNetworkIdentifier)?.Address , 
                (object data,string? value) => { if (data is _ContactNetworkIdentifier datad) { datad.Address = value; }})  /* 2 */ , 
            new GuiBoundPropertyString ("Fingerprint", "Fingerprint", (object data) => (data as _ContactNetworkIdentifier)?.Fingerprint , 
                (object data,string? value) => { if (data is _ContactNetworkIdentifier datad) { datad.Fingerprint = value; }})  /* 3 */ , 
            new GuiBoundPropertyDataActions ("Actions", "Actions", (object data) => (data as _ContactNetworkIdentifier)?.Actions , null)  /* 4 */ 
            ]);
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public override IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public override IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundContactBusiness 
/// </summary>
public partial class BoundContactBusiness : _BoundContactBusiness {
    // <summary>Type check verification.</summary>
    // public static new Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundContactBusiness 
/// </summary>
public partial class _BoundContactBusiness : BoundContact {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundContactBusiness,
        () => new BoundContactBusiness(),
        [ 
            new GuiBoundPropertyIcon ("Type", "Type", (object data) => (data as _BoundContactBusiness)?.Type , null)  /* 0 */ , 
            new GuiBoundPropertyString ("Display", "Display name", (object data) => (data as _BoundContactBusiness)?.Display , null)  /* 1 */ 
            ]);
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public override IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public override IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundContactPlace 
/// </summary>
public partial class BoundContactPlace : _BoundContactPlace {
    // <summary>Type check verification.</summary>
    // public static new Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundContactPlace 
/// </summary>
public partial class _BoundContactPlace : BoundContact {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundContactPlace,
        () => new BoundContactPlace(),
        [ 
            new GuiBoundPropertyIcon ("Type", "Type", (object data) => (data as _BoundContactPlace)?.Type , null)  /* 0 */ , 
            new GuiBoundPropertyString ("Display", "Display name", (object data) => (data as _BoundContactPlace)?.Display , null)  /* 1 */ 
            ]);
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public override IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public override IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog ContactNetworkAddress 
/// </summary>
public partial class ContactNetworkAddress : _ContactNetworkAddress {
    // <summary>Type check verification.</summary>
    // public static  Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section ContactNetworkAddress 
/// </summary>
public partial class _ContactNetworkAddress : IParameter {

    public object? Bound { get; set; }


    ///<summary></summary> 
    public virtual IFieldIcon? Type { get;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _ContactNetworkAddress,
        () => new ContactNetworkAddress(),
        [ 
            new GuiBoundPropertyIcon ("Type", "Type", (object data) => (data as _ContactNetworkAddress)?.Type , null)  /* 0 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog ContactNetworkCredential 
/// </summary>
public partial class ContactNetworkCredential : _ContactNetworkCredential {
    // <summary>Type check verification.</summary>
    // public static new Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section ContactNetworkCredential 
/// </summary>
public partial class _ContactNetworkCredential : ContactNetworkAddress {


    ///<summary></summary> 
    public virtual string? Protocol { get;} 

    ///<summary></summary> 
    public virtual string? Address { get;} 

    ///<summary></summary> 
    public virtual string? Fingerprint { get;} 

    ///<summary></summary> 
    public virtual IDataActions? Actions { get;} 


    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _ContactNetworkCredential,
        () => new ContactNetworkCredential(),
        [ 
            new GuiBoundPropertyIcon ("Type", "Type", (object data) => (data as _ContactNetworkCredential)?.Type , null)  /* 0 */ , 
            new GuiBoundPropertyString ("Protocol", "Protocol", (object data) => (data as _ContactNetworkCredential)?.Protocol , null)  /* 1 */ , 
            new GuiBoundPropertyString ("Address", "Address", (object data) => (data as _ContactNetworkCredential)?.Address , null)  /* 2 */ , 
            new GuiBoundPropertyString ("Fingerprint", "Fingerprint", (object data) => (data as _ContactNetworkCredential)?.Fingerprint , null)  /* 3 */ , 
            new GuiBoundPropertyDataActions ("Actions", "Actions", (object data) => (data as _ContactNetworkCredential)?.Actions , null)  /* 4 */ 
            ]);
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public override IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public override IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog ContactPhysicalAddress 
/// </summary>
public partial class ContactPhysicalAddress : _ContactPhysicalAddress {
    // <summary>Type check verification.</summary>
    // public static  Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section ContactPhysicalAddress 
/// </summary>
public partial class _ContactPhysicalAddress : IParameter {

    public object? Bound { get; set; }


    ///<summary></summary> 
    public virtual string? Appartment { get; set;} 

    ///<summary></summary> 
    public virtual string? Street { get; set;} 

    ///<summary></summary> 
    public virtual string? District { get; set;} 

    ///<summary></summary> 
    public virtual string? Locality { get; set;} 

    ///<summary></summary> 
    public virtual string? Country { get; set;} 

    ///<summary></summary> 
    public virtual string? Postcode { get; set;} 

    ///<summary></summary> 
    public virtual decimal? Latitude { get; set;} 

    ///<summary></summary> 
    public virtual decimal? Longitude { get; set;} 

    ///<summary></summary> 
    public virtual IDataActions? Actions { get;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _ContactPhysicalAddress,
        () => new ContactPhysicalAddress(),
        [ 
            new GuiBoundPropertyString ("Appartment", "Appartment", (object data) => (data as _ContactPhysicalAddress)?.Appartment , 
                (object data,string? value) => { if (data is _ContactPhysicalAddress datad) { datad.Appartment = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("Street", "Street", (object data) => (data as _ContactPhysicalAddress)?.Street , 
                (object data,string? value) => { if (data is _ContactPhysicalAddress datad) { datad.Street = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("District", "District", (object data) => (data as _ContactPhysicalAddress)?.District , 
                (object data,string? value) => { if (data is _ContactPhysicalAddress datad) { datad.District = value; }})  /* 2 */ , 
            new GuiBoundPropertyString ("Locality", "Locality", (object data) => (data as _ContactPhysicalAddress)?.Locality , 
                (object data,string? value) => { if (data is _ContactPhysicalAddress datad) { datad.Locality = value; }})  /* 3 */ , 
            new GuiBoundPropertyString ("Country", "Country", (object data) => (data as _ContactPhysicalAddress)?.Country , 
                (object data,string? value) => { if (data is _ContactPhysicalAddress datad) { datad.Country = value; }})  /* 4 */ , 
            new GuiBoundPropertyString ("Postcode", "Postcode", (object data) => (data as _ContactPhysicalAddress)?.Postcode , 
                (object data,string? value) => { if (data is _ContactPhysicalAddress datad) { datad.Postcode = value; }})  /* 5 */ , 
            new GuiBoundPropertyDecimal ("Latitude", "Latitude", (object data) => (data as _ContactPhysicalAddress)?.Latitude , 
                (object data,decimal? value) => { if (data is _ContactPhysicalAddress datad) { datad.Latitude = value; }})  /* 6 */ , 
            new GuiBoundPropertyDecimal ("Longitude", "Longitude", (object data) => (data as _ContactPhysicalAddress)?.Longitude , 
                (object data,decimal? value) => { if (data is _ContactPhysicalAddress datad) { datad.Longitude = value; }})  /* 7 */ , 
            new GuiBoundPropertyDataActions ("Actions", "Actions", (object data) => (data as _ContactPhysicalAddress)?.Actions , null)  /* 8 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundDocument 
/// </summary>
public partial class BoundDocument : _BoundDocument {
    // <summary>Type check verification.</summary>
    // public static  Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundDocument 
/// </summary>
public partial class _BoundDocument : IParameter {

    public object? Bound { get; set; }


    ///<summary></summary> 
    public virtual IFieldIcon? Type { get;} 

    ///<summary></summary> 
    public virtual string? FileType { get;} 

    ///<summary></summary> 
    public virtual string? Filename { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundDocument,
        () => new BoundDocument(),
        [ 
            new GuiBoundPropertyIcon ("Type", "Type", (object data) => (data as _BoundDocument)?.Type , null)  /* 0 */ , 
            new GuiBoundPropertyString ("FileType", "Type", (object data) => (data as _BoundDocument)?.FileType , null)  /* 1 */ , 
            new GuiBoundPropertyString ("Filename", "File name", (object data) => (data as _BoundDocument)?.Filename , 
                (object data,string? value) => { if (data is _BoundDocument datad) { datad.Filename = value; }})  /* 2 */ , 
            new GuiBoundPropertySelection ("DocumentUpdate", "Update")  /* 3 */ , 
            new GuiBoundPropertySelection ("DocumentExport", "Export")  /* 4 */ , 
            new GuiBoundPropertySelection ("DocumentSend", "Send")  /* 5 */ , 
            new GuiBoundPropertySelection ("DocumentDelete", "Delete")  /* 6 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundGroup 
/// </summary>
public partial class BoundGroup : _BoundGroup {
    // <summary>Type check verification.</summary>
    // public static  Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundGroup 
/// </summary>
public partial class _BoundGroup : IParameter {

    public object? Bound { get; set; }


    ///<summary></summary> 
    public virtual string? GroupName { get; set;} 

    ///<summary></summary> 
    public virtual string? GroupAddress { get; set;} 

    ///<summary></summary> 
    public virtual ISelectList? Members { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundGroup,
        () => new BoundGroup(),
        [ 
            new GuiBoundPropertyString ("GroupName", "Display name", (object data) => (data as _BoundGroup)?.GroupName , 
                (object data,string? value) => { if (data is _BoundGroup datad) { datad.GroupName = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("GroupAddress", "Address", (object data) => (data as _BoundGroup)?.GroupAddress , 
                (object data,string? value) => { if (data is _BoundGroup datad) { datad.GroupAddress = value; }})  /* 1 */ , 
            new GuiBoundPropertyList ("Members", "Members", (object data) => (data as _BoundGroup)?.Members , 
                (object data,ISelectList? value) => { if (data is _BoundGroup datad) { datad.Members = value; }}, _BoundGroupMember.BaseBinding)  /* 2 */ , 
            new GuiBoundPropertyButton ("GroupInvite")  /* 3 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundGroupMember 
/// </summary>
public partial class BoundGroupMember : _BoundGroupMember {
    // <summary>Type check verification.</summary>
    // public static  Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundGroupMember 
/// </summary>
public partial class _BoundGroupMember : IParameter {

    public object? Bound { get; set; }


    ///<summary></summary> 
    public virtual string? ContactName { get; set;} 

    ///<summary></summary> 
    public virtual string? Address { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundGroupMember,
        () => new BoundGroupMember(),
        [ 
            new GuiBoundPropertyString ("ContactName", "Name", (object data) => (data as _BoundGroupMember)?.ContactName , 
                (object data,string? value) => { if (data is _BoundGroupMember datad) { datad.ContactName = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("Address", "Address", (object data) => (data as _BoundGroupMember)?.Address , 
                (object data,string? value) => { if (data is _BoundGroupMember datad) { datad.Address = value; }})  /* 1 */ , 
            new GuiBoundPropertySelection ("MemberDelete", "Delete")  /* 2 */ , 
            new GuiBoundPropertySelection ("MemberReInvite", "Sesent Invitation")  /* 3 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundCredential 
/// </summary>
public partial class BoundCredential : _BoundCredential {
    // <summary>Type check verification.</summary>
    // public static  Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundCredential 
/// </summary>
public partial class _BoundCredential : IParameter {

    public object? Bound { get; set; }


    ///<summary></summary> 
    public virtual IFieldIcon? Type { get;} 

    ///<summary></summary> 
    public virtual string? Protocol { get; set;} 

    ///<summary></summary> 
    public virtual string? Service { get; set;} 

    ///<summary></summary> 
    public virtual string? Username { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundCredential,
        () => new BoundCredential(),
        [ 
            new GuiBoundPropertyIcon ("Type", "Type", (object data) => (data as _BoundCredential)?.Type , null)  /* 0 */ , 
            new GuiBoundPropertyString ("Protocol", "Protocol", (object data) => (data as _BoundCredential)?.Protocol , 
                (object data,string? value) => { if (data is _BoundCredential datad) { datad.Protocol = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Service", "Service", (object data) => (data as _BoundCredential)?.Service , 
                (object data,string? value) => { if (data is _BoundCredential datad) { datad.Service = value; }})  /* 2 */ , 
            new GuiBoundPropertyString ("Username", "Username", (object data) => (data as _BoundCredential)?.Username , 
                (object data,string? value) => { if (data is _BoundCredential datad) { datad.Username = value; }})  /* 3 */ , 
            new GuiBoundPropertySelection ("CredentialUpdate", "Update")  /* 4 */ , 
            new GuiBoundPropertySelection ("CredentialDelete", "Delete")  /* 5 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundPassword 
/// </summary>
public partial class BoundPassword : _BoundPassword {
    // <summary>Type check verification.</summary>
    // public static new Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundPassword 
/// </summary>
public partial class _BoundPassword : BoundCredential {


    ///<summary></summary> 
    public virtual string? Password { get; set;} 


    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundPassword,
        () => new BoundPassword(),
        [ 
            new GuiBoundPropertyIcon ("Type", "Type", (object data) => (data as _BoundPassword)?.Type , null)  /* 0 */ , 
            new GuiBoundPropertyString ("Protocol", "Protocol", (object data) => (data as _BoundPassword)?.Protocol , 
                (object data,string? value) => { if (data is _BoundPassword datad) { datad.Protocol = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Service", "Service", (object data) => (data as _BoundPassword)?.Service , 
                (object data,string? value) => { if (data is _BoundPassword datad) { datad.Service = value; }})  /* 2 */ , 
            new GuiBoundPropertyString ("Username", "Username", (object data) => (data as _BoundPassword)?.Username , 
                (object data,string? value) => { if (data is _BoundPassword datad) { datad.Username = value; }})  /* 3 */ , 
            new GuiBoundPropertySelection ("CredentialUpdate", "Update")  /* 4 */ , 
            new GuiBoundPropertySelection ("CredentialDelete", "Delete")  /* 5 */ , 
            new GuiBoundPropertyString ("Password", "Password", (object data) => (data as _BoundPassword)?.Password , 
                (object data,string? value) => { if (data is _BoundPassword datad) { datad.Password = value; }})  /* 6 */ 
            ]);
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public override IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public override IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundPasskey 
/// </summary>
public partial class BoundPasskey : _BoundPasskey {
    // <summary>Type check verification.</summary>
    // public static new Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundPasskey 
/// </summary>
public partial class _BoundPasskey : BoundCredential {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundPasskey,
        () => new BoundPasskey(),
        [ 
            new GuiBoundPropertyIcon ("Type", "Type", (object data) => (data as _BoundPasskey)?.Type , null)  /* 0 */ , 
            new GuiBoundPropertyString ("Protocol", "Protocol", (object data) => (data as _BoundPasskey)?.Protocol , 
                (object data,string? value) => { if (data is _BoundPasskey datad) { datad.Protocol = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Service", "Service", (object data) => (data as _BoundPasskey)?.Service , 
                (object data,string? value) => { if (data is _BoundPasskey datad) { datad.Service = value; }})  /* 2 */ , 
            new GuiBoundPropertyString ("Username", "Username", (object data) => (data as _BoundPasskey)?.Username , 
                (object data,string? value) => { if (data is _BoundPasskey datad) { datad.Username = value; }})  /* 3 */ , 
            new GuiBoundPropertySelection ("CredentialUpdate", "Update")  /* 4 */ , 
            new GuiBoundPropertySelection ("CredentialDelete", "Delete")  /* 5 */ 
            ]);
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public override IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public override IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundTask 
/// </summary>
public partial class BoundTask : _BoundTask {
    // <summary>Type check verification.</summary>
    // public static  Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundTask 
/// </summary>
public partial class _BoundTask : IParameter {

    public object? Bound { get; set; }


    ///<summary></summary> 
    public virtual IFieldIcon? Type { get;} 

    ///<summary></summary> 
    public virtual string? Title { get; set;} 

    ///<summary></summary> 
    public virtual string? Description { get; set;} 

    ///<summary></summary> 
    public virtual string? Path { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundTask,
        () => new BoundTask(),
        [ 
            new GuiBoundPropertyIcon ("Type", "Type", (object data) => (data as _BoundTask)?.Type , null)  /* 0 */ , 
            new GuiBoundPropertyString ("Title", "Title", (object data) => (data as _BoundTask)?.Title , 
                (object data,string? value) => { if (data is _BoundTask datad) { datad.Title = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Description", "Description", (object data) => (data as _BoundTask)?.Description , 
                (object data,string? value) => { if (data is _BoundTask datad) { datad.Description = value; }})  /* 2 */ , 
            new GuiBoundPropertyString ("Path", "Path", (object data) => (data as _BoundTask)?.Path , 
                (object data,string? value) => { if (data is _BoundTask datad) { datad.Path = value; }})  /* 3 */ , 
            new GuiBoundPropertySelection ("TaskUpdate", "Update")  /* 4 */ , 
            new GuiBoundPropertySelection ("TaskDelete", "Delete")  /* 5 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundAppointment 
/// </summary>
public partial class BoundAppointment : _BoundAppointment {
    // <summary>Type check verification.</summary>
    // public static  Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundAppointment 
/// </summary>
public partial class _BoundAppointment : IParameter {

    public object? Bound { get; set; }


    ///<summary></summary> 
    public virtual string? Display { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundAppointment,
        () => new BoundAppointment(),
        [ 
            new GuiBoundPropertyString ("Display", "Display name", (object data) => (data as _BoundAppointment)?.Display , 
                (object data,string? value) => { if (data is _BoundAppointment datad) { datad.Display = value; }})  /* 0 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundBookmark 
/// </summary>
public partial class BoundBookmark : _BoundBookmark {
    // <summary>Type check verification.</summary>
    // public static  Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundBookmark 
/// </summary>
public partial class _BoundBookmark : IParameter {

    public object? Bound { get; set; }


    ///<summary></summary> 
    public virtual IFieldIcon? Type { get;} 

    ///<summary></summary> 
    public virtual string? Path { get; set;} 

    ///<summary></summary> 
    public virtual string? Title { get; set;} 

    ///<summary></summary> 
    public virtual string? Uri { get; set;} 

    ///<summary></summary> 
    public virtual string? Description { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundBookmark,
        () => new BoundBookmark(),
        [ 
            new GuiBoundPropertyIcon ("Type", "Type", (object data) => (data as _BoundBookmark)?.Type , null)  /* 0 */ , 
            new GuiBoundPropertyString ("Path", "Path", (object data) => (data as _BoundBookmark)?.Path , 
                (object data,string? value) => { if (data is _BoundBookmark datad) { datad.Path = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Title", "Title", (object data) => (data as _BoundBookmark)?.Title , 
                (object data,string? value) => { if (data is _BoundBookmark datad) { datad.Title = value; }})  /* 2 */ , 
            new GuiBoundPropertyString ("Uri", "Link", (object data) => (data as _BoundBookmark)?.Uri , 
                (object data,string? value) => { if (data is _BoundBookmark datad) { datad.Uri = value; }})  /* 3 */ , 
            new GuiBoundPropertyString ("Description", "Description", (object data) => (data as _BoundBookmark)?.Description , 
                (object data,string? value) => { if (data is _BoundBookmark datad) { datad.Description = value; }})  /* 4 */ , 
            new GuiBoundPropertySelection ("BookmarkUpdate", "Update")  /* 5 */ , 
            new GuiBoundPropertySelection ("BookmarkDelete", "Delete")  /* 6 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundFeed 
/// </summary>
public partial class BoundFeed : _BoundFeed {
    // <summary>Type check verification.</summary>
    // public static new Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundFeed 
/// </summary>
public partial class _BoundFeed : BoundBookmark {


    ///<summary></summary> 
    public virtual string? Protocol { get; set;} 


    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundFeed,
        () => new BoundFeed(),
        [ 
            new GuiBoundPropertyIcon ("Type", "Type", (object data) => (data as _BoundFeed)?.Type , null)  /* 0 */ , 
            new GuiBoundPropertyString ("Path", "Path", (object data) => (data as _BoundFeed)?.Path , 
                (object data,string? value) => { if (data is _BoundFeed datad) { datad.Path = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Title", "Title", (object data) => (data as _BoundFeed)?.Title , 
                (object data,string? value) => { if (data is _BoundFeed datad) { datad.Title = value; }})  /* 2 */ , 
            new GuiBoundPropertyString ("Uri", "Link", (object data) => (data as _BoundFeed)?.Uri , 
                (object data,string? value) => { if (data is _BoundFeed datad) { datad.Uri = value; }})  /* 3 */ , 
            new GuiBoundPropertyString ("Description", "Description", (object data) => (data as _BoundFeed)?.Description , 
                (object data,string? value) => { if (data is _BoundFeed datad) { datad.Description = value; }})  /* 4 */ , 
            new GuiBoundPropertySelection ("BookmarkUpdate", "Update")  /* 5 */ , 
            new GuiBoundPropertySelection ("BookmarkDelete", "Delete")  /* 6 */ , 
            new GuiBoundPropertyString ("Protocol", "Protocol", (object data) => (data as _BoundFeed)?.Protocol , 
                (object data,string? value) => { if (data is _BoundFeed datad) { datad.Protocol = value; }})  /* 7 */ 
            ]);
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public override IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public override IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundApplication 
/// </summary>
public partial class BoundApplication : _BoundApplication {
    // <summary>Type check verification.</summary>
    // public static  Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundApplication 
/// </summary>
public partial class _BoundApplication : IParameter {

    public object? Bound { get; set; }


    ///<summary></summary> 
    public virtual string? LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string? Description { get; set;} 

    ///<summary></summary> 
    public virtual string? Path { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundApplication,
        () => new BoundApplication(),
        [ 
            new GuiBoundPropertyString ("LocalName", "Local", (object data) => (data as _BoundApplication)?.LocalName , 
                (object data,string? value) => { if (data is _BoundApplication datad) { datad.LocalName = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("Description", "Description", (object data) => (data as _BoundApplication)?.Description , 
                (object data,string? value) => { if (data is _BoundApplication datad) { datad.Description = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Path", "Path", (object data) => (data as _BoundApplication)?.Path , 
                (object data,string? value) => { if (data is _BoundApplication datad) { datad.Path = value; }})  /* 2 */ , 
            new GuiBoundPropertySelection ("ApplicationUpdate", "Update")  /* 3 */ , 
            new GuiBoundPropertySelection ("ApplicationDelete", "Delete")  /* 4 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundApplicationMail 
/// </summary>
public partial class BoundApplicationMail : _BoundApplicationMail {
    // <summary>Type check verification.</summary>
    // public static new Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundApplicationMail 
/// </summary>
public partial class _BoundApplicationMail : BoundApplication {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundApplicationMail,
        () => new BoundApplicationMail(),
        [ 
            new GuiBoundPropertyString ("LocalName", "Local", (object data) => (data as _BoundApplicationMail)?.LocalName , 
                (object data,string? value) => { if (data is _BoundApplicationMail datad) { datad.LocalName = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("Description", "Description", (object data) => (data as _BoundApplicationMail)?.Description , 
                (object data,string? value) => { if (data is _BoundApplicationMail datad) { datad.Description = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Path", "Path", (object data) => (data as _BoundApplicationMail)?.Path , 
                (object data,string? value) => { if (data is _BoundApplicationMail datad) { datad.Path = value; }})  /* 2 */ , 
            new GuiBoundPropertySelection ("ApplicationUpdate", "Update")  /* 3 */ , 
            new GuiBoundPropertySelection ("ApplicationDelete", "Delete")  /* 4 */ 
            ]);
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public override IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public override IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundApplicationSsh 
/// </summary>
public partial class BoundApplicationSsh : _BoundApplicationSsh {
    // <summary>Type check verification.</summary>
    // public static new Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundApplicationSsh 
/// </summary>
public partial class _BoundApplicationSsh : BoundApplication {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundApplicationSsh,
        () => new BoundApplicationSsh(),
        [ 
            new GuiBoundPropertyString ("LocalName", "Local", (object data) => (data as _BoundApplicationSsh)?.LocalName , 
                (object data,string? value) => { if (data is _BoundApplicationSsh datad) { datad.LocalName = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("Description", "Description", (object data) => (data as _BoundApplicationSsh)?.Description , 
                (object data,string? value) => { if (data is _BoundApplicationSsh datad) { datad.Description = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Path", "Path", (object data) => (data as _BoundApplicationSsh)?.Path , 
                (object data,string? value) => { if (data is _BoundApplicationSsh datad) { datad.Path = value; }})  /* 2 */ , 
            new GuiBoundPropertySelection ("ApplicationUpdate", "Update")  /* 3 */ , 
            new GuiBoundPropertySelection ("ApplicationDelete", "Delete")  /* 4 */ 
            ]);
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public override IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public override IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundApplicationOpenPgp 
/// </summary>
public partial class BoundApplicationOpenPgp : _BoundApplicationOpenPgp {
    // <summary>Type check verification.</summary>
    // public static new Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundApplicationOpenPgp 
/// </summary>
public partial class _BoundApplicationOpenPgp : BoundApplication {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundApplicationOpenPgp,
        () => new BoundApplicationOpenPgp(),
        [ 
            new GuiBoundPropertyString ("LocalName", "Local", (object data) => (data as _BoundApplicationOpenPgp)?.LocalName , 
                (object data,string? value) => { if (data is _BoundApplicationOpenPgp datad) { datad.LocalName = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("Description", "Description", (object data) => (data as _BoundApplicationOpenPgp)?.Description , 
                (object data,string? value) => { if (data is _BoundApplicationOpenPgp datad) { datad.Description = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Path", "Path", (object data) => (data as _BoundApplicationOpenPgp)?.Path , 
                (object data,string? value) => { if (data is _BoundApplicationOpenPgp datad) { datad.Path = value; }})  /* 2 */ , 
            new GuiBoundPropertySelection ("ApplicationUpdate", "Update")  /* 3 */ , 
            new GuiBoundPropertySelection ("ApplicationDelete", "Delete")  /* 4 */ 
            ]);
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public override IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public override IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundApplicationDeveloper 
/// </summary>
public partial class BoundApplicationDeveloper : _BoundApplicationDeveloper {
    // <summary>Type check verification.</summary>
    // public static new Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundApplicationDeveloper 
/// </summary>
public partial class _BoundApplicationDeveloper : BoundApplication {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundApplicationDeveloper,
        () => new BoundApplicationDeveloper(),
        [ 
            new GuiBoundPropertyString ("LocalName", "Local", (object data) => (data as _BoundApplicationDeveloper)?.LocalName , 
                (object data,string? value) => { if (data is _BoundApplicationDeveloper datad) { datad.LocalName = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("Description", "Description", (object data) => (data as _BoundApplicationDeveloper)?.Description , 
                (object data,string? value) => { if (data is _BoundApplicationDeveloper datad) { datad.Description = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Path", "Path", (object data) => (data as _BoundApplicationDeveloper)?.Path , 
                (object data,string? value) => { if (data is _BoundApplicationDeveloper datad) { datad.Path = value; }})  /* 2 */ , 
            new GuiBoundPropertySelection ("ApplicationUpdate", "Update")  /* 3 */ , 
            new GuiBoundPropertySelection ("ApplicationDelete", "Delete")  /* 4 */ 
            ]);
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public override IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public override IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundApplicationPkix 
/// </summary>
public partial class BoundApplicationPkix : _BoundApplicationPkix {
    // <summary>Type check verification.</summary>
    // public static new Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundApplicationPkix 
/// </summary>
public partial class _BoundApplicationPkix : BoundApplication {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundApplicationPkix,
        () => new BoundApplicationPkix(),
        [ 
            new GuiBoundPropertyString ("LocalName", "Local", (object data) => (data as _BoundApplicationPkix)?.LocalName , 
                (object data,string? value) => { if (data is _BoundApplicationPkix datad) { datad.LocalName = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("Description", "Description", (object data) => (data as _BoundApplicationPkix)?.Description , 
                (object data,string? value) => { if (data is _BoundApplicationPkix datad) { datad.Description = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Path", "Path", (object data) => (data as _BoundApplicationPkix)?.Path , 
                (object data,string? value) => { if (data is _BoundApplicationPkix datad) { datad.Path = value; }})  /* 2 */ , 
            new GuiBoundPropertySelection ("ApplicationUpdate", "Update")  /* 3 */ , 
            new GuiBoundPropertySelection ("ApplicationDelete", "Delete")  /* 4 */ 
            ]);
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public override IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public override IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundApplicationGroup 
/// </summary>
public partial class BoundApplicationGroup : _BoundApplicationGroup {
    // <summary>Type check verification.</summary>
    // public static new Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundApplicationGroup 
/// </summary>
public partial class _BoundApplicationGroup : BoundApplication {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundApplicationGroup,
        () => new BoundApplicationGroup(),
        [ 
            new GuiBoundPropertyString ("LocalName", "Local", (object data) => (data as _BoundApplicationGroup)?.LocalName , 
                (object data,string? value) => { if (data is _BoundApplicationGroup datad) { datad.LocalName = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("Description", "Description", (object data) => (data as _BoundApplicationGroup)?.Description , 
                (object data,string? value) => { if (data is _BoundApplicationGroup datad) { datad.Description = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Path", "Path", (object data) => (data as _BoundApplicationGroup)?.Path , 
                (object data,string? value) => { if (data is _BoundApplicationGroup datad) { datad.Path = value; }})  /* 2 */ , 
            new GuiBoundPropertySelection ("ApplicationUpdate", "Update")  /* 3 */ , 
            new GuiBoundPropertySelection ("ApplicationDelete", "Delete")  /* 4 */ 
            ]);
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public override IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public override IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundApplicationCallSign 
/// </summary>
public partial class BoundApplicationCallSign : _BoundApplicationCallSign {
    // <summary>Type check verification.</summary>
    // public static new Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundApplicationCallSign 
/// </summary>
public partial class _BoundApplicationCallSign : BoundApplication {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundApplicationCallSign,
        () => new BoundApplicationCallSign(),
        [ 
            new GuiBoundPropertyString ("LocalName", "Local", (object data) => (data as _BoundApplicationCallSign)?.LocalName , 
                (object data,string? value) => { if (data is _BoundApplicationCallSign datad) { datad.LocalName = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("Description", "Description", (object data) => (data as _BoundApplicationCallSign)?.Description , 
                (object data,string? value) => { if (data is _BoundApplicationCallSign datad) { datad.Description = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Path", "Path", (object data) => (data as _BoundApplicationCallSign)?.Path , 
                (object data,string? value) => { if (data is _BoundApplicationCallSign datad) { datad.Path = value; }})  /* 2 */ , 
            new GuiBoundPropertySelection ("ApplicationUpdate", "Update")  /* 3 */ , 
            new GuiBoundPropertySelection ("ApplicationDelete", "Delete")  /* 4 */ 
            ]);
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public override IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public override IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundDevice 
/// </summary>
public partial class BoundDevice : _BoundDevice {
    // <summary>Type check verification.</summary>
    // public static  Func<object, bool> IsBacker { get; set; } = (object _) => false; 
    }

/// <summary>
/// Callback parameters for section BoundDevice 
/// </summary>
public partial class _BoundDevice : IParameter {

    public object? Bound { get; set; }


    ///<summary></summary> 
    public virtual IFieldIcon? Type { get;} 

    ///<summary></summary> 
    public virtual string? DeviceType { get; set;} 

    ///<summary></summary> 
    public virtual string? Rights { get; set;} 

    ///<summary></summary> 
    public virtual string? LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string? Udf { get;} 

    ///<summary></summary> 
    public virtual string? Path { get; set;} 

    ///<summary></summary> 
    public virtual string? Description { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BoundDevice,
        () => new BoundDevice(),
        [ 
            new GuiBoundPropertyIcon ("Type", "Type", (object data) => (data as _BoundDevice)?.Type , null)  /* 0 */ , 
            new GuiBoundPropertyString ("DeviceType", "Platform", (object data) => (data as _BoundDevice)?.DeviceType , 
                (object data,string? value) => { if (data is _BoundDevice datad) { datad.DeviceType = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Rights", "Rights", (object data) => (data as _BoundDevice)?.Rights , 
                (object data,string? value) => { if (data is _BoundDevice datad) { datad.Rights = value; }})  /* 2 */ , 
            new GuiBoundPropertyString ("LocalName", "Name", (object data) => (data as _BoundDevice)?.LocalName , 
                (object data,string? value) => { if (data is _BoundDevice datad) { datad.LocalName = value; }})  /* 3 */ , 
            new GuiBoundPropertyString ("Udf", "Udf", (object data) => (data as _BoundDevice)?.Udf , null)  /* 4 */ , 
            new GuiBoundPropertyString ("Path", "Path", (object data) => (data as _BoundDevice)?.Path , 
                (object data,string? value) => { if (data is _BoundDevice datad) { datad.Path = value; }})  /* 5 */ , 
            new GuiBoundPropertyString ("Description", "Description", (object data) => (data as _BoundDevice)?.Description , 
                (object data,string? value) => { if (data is _BoundDevice datad) { datad.Description = value; }})  /* 6 */ , 
            new GuiBoundPropertySelection ("DeviceUpdate", "Update")  /* 7 */ , 
            new GuiBoundPropertySelection ("DeviceDelete", "Delete")  /* 8 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }

#endregion
#region // Actions


/// <summary>
/// Callback parameters for action TestService 
/// </summary>
public partial class TestService : _TestService {
    }


/// <summary>
/// Callback parameters for action TestService 
/// </summary>
public partial class _TestService : IParameter {

    ///<summary></summary> 
    public virtual string? ServiceAddress { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _TestService,
        () => new TestService(),
        [ 
            new GuiBoundPropertyString ("ServiceAddress", "Service address", (object data) => (data as _TestService)?.ServiceAddress , 
                (object data,string? value) => { if (data is _TestService datad) { datad.ServiceAddress = value; }})  /* 0 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        // error on ServiceAddress
        if (!ServiceAddress.TryParseServiceAddress()
            ) {
            result ??=new GuiResultInvalid(this);
            result.SetError (0, "Not a valid service address", "ServiceAddressNotValid");
            }

        // error on ServiceAddress
        if (ServiceAddress == null || ServiceAddress?.Length == 0
            ) {
            result ??=new GuiResultInvalid(this);
            result.SetError (0, "Service address cannot be blank", "ServiceAddressNotEmpty");
            }

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action AccountCreate 
/// </summary>
public partial class AccountCreate : _AccountCreate {
    }


/// <summary>
/// Callback parameters for action AccountCreate 
/// </summary>
public partial class _AccountCreate : IParameter {

    ///<summary></summary> 
    public virtual string? ServiceAddress { get; set;} 

    ///<summary></summary> 
    public virtual string? ContactName { get; set;} 

    ///<summary></summary> 
    public virtual string? LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string? Coupon { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _AccountCreate,
        () => new AccountCreate(),
        [ 
            new GuiBoundPropertyString ("ServiceAddress", "Account service address", (object data) => (data as _AccountCreate)?.ServiceAddress , 
                (object data,string? value) => { if (data is _AccountCreate datad) { datad.ServiceAddress = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("ContactName", "Contact Name  (optional)", (object data) => (data as _AccountCreate)?.ContactName , 
                (object data,string? value) => { if (data is _AccountCreate datad) { datad.ContactName = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("LocalName", "Friendly name (optional)", (object data) => (data as _AccountCreate)?.LocalName , 
                (object data,string? value) => { if (data is _AccountCreate datad) { datad.LocalName = value; }})  /* 2 */ , 
            new GuiBoundPropertyString ("Coupon", "Activation code (if provided)", (object data) => (data as _AccountCreate)?.Coupon , 
                (object data,string? value) => { if (data is _AccountCreate datad) { datad.Coupon = value; }})  /* 3 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        // error on ServiceAddress
        if (!ServiceAddress.TryParseServiceAddress()
            ) {
            result ??=new GuiResultInvalid(this);
            result.SetError (0, "Not a valid service address", "ServiceAddressNotValid");
            }

        // error on ServiceAddress
        if (ServiceAddress == null || ServiceAddress?.Length == 0
            ) {
            result ??=new GuiResultInvalid(this);
            result.SetError (0, "Service address cannot be blank", "ServiceAddressNotEmpty");
            }

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action AccountRequestConnect 
/// </summary>
public partial class AccountRequestConnect : _AccountRequestConnect {
    }


/// <summary>
/// Callback parameters for action AccountRequestConnect 
/// </summary>
public partial class _AccountRequestConnect : IParameter {

    ///<summary></summary> 
    public virtual string? ConnectionString { get; set;} 

    ///<summary></summary> 
    public virtual string? ConnectionPin { get; set;} 

    ///<summary></summary> 
    public virtual string? Rights { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _AccountRequestConnect,
        () => new AccountRequestConnect(),
        [ 
            new GuiBoundPropertyString ("ConnectionString", "Account address", (object data) => (data as _AccountRequestConnect)?.ConnectionString , 
                (object data,string? value) => { if (data is _AccountRequestConnect datad) { datad.ConnectionString = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("ConnectionPin", "Activation code (if provided)", (object data) => (data as _AccountRequestConnect)?.ConnectionPin , 
                (object data,string? value) => { if (data is _AccountRequestConnect datad) { datad.ConnectionPin = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Rights", "Requested rights", (object data) => (data as _AccountRequestConnect)?.Rights , 
                (object data,string? value) => { if (data is _AccountRequestConnect datad) { datad.Rights = value; }})  /* 2 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action AccountRecover 
/// </summary>
public partial class AccountRecover : _AccountRecover {
    }


/// <summary>
/// Callback parameters for action AccountRecover 
/// </summary>
public partial class _AccountRecover : IParameter {

    ///<summary></summary> 
    public virtual string? ServiceAddress { get; set;} 

    ///<summary></summary> 
    public virtual string? LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string? Coupon { get; set;} 

    ///<summary></summary> 
    public virtual string? Share1 { get; set;} 

    ///<summary></summary> 
    public virtual string? Share2 { get; set;} 

    ///<summary></summary> 
    public virtual string? Share3 { get; set;} 

    ///<summary></summary> 
    public virtual string? Share4 { get; set;} 

    ///<summary></summary> 
    public virtual string? Share5 { get; set;} 

    ///<summary></summary> 
    public virtual string? Share6 { get; set;} 

    ///<summary></summary> 
    public virtual string? Share7 { get; set;} 

    ///<summary></summary> 
    public virtual string? Share8 { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _AccountRecover,
        () => new AccountRecover(),
        [ 
            new GuiBoundPropertyString ("ServiceAddress", "Account service address", (object data) => (data as _AccountRecover)?.ServiceAddress , 
                (object data,string? value) => { if (data is _AccountRecover datad) { datad.ServiceAddress = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("LocalName", "Friendly name (optional)", (object data) => (data as _AccountRecover)?.LocalName , 
                (object data,string? value) => { if (data is _AccountRecover datad) { datad.LocalName = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Coupon", "Activation code (if provided)", (object data) => (data as _AccountRecover)?.Coupon , 
                (object data,string? value) => { if (data is _AccountRecover datad) { datad.Coupon = value; }})  /* 2 */ , 
            new GuiBoundPropertyString ("Share1", "Recovery share", (object data) => (data as _AccountRecover)?.Share1 , 
                (object data,string? value) => { if (data is _AccountRecover datad) { datad.Share1 = value; }})  /* 3 */ , 
            new GuiBoundPropertyString ("Share2", "Recovery share", (object data) => (data as _AccountRecover)?.Share2 , 
                (object data,string? value) => { if (data is _AccountRecover datad) { datad.Share2 = value; }})  /* 4 */ , 
            new GuiBoundPropertyString ("Share3", "Recovery share", (object data) => (data as _AccountRecover)?.Share3 , 
                (object data,string? value) => { if (data is _AccountRecover datad) { datad.Share3 = value; }})  /* 5 */ , 
            new GuiBoundPropertyString ("Share4", "Recovery share", (object data) => (data as _AccountRecover)?.Share4 , 
                (object data,string? value) => { if (data is _AccountRecover datad) { datad.Share4 = value; }})  /* 6 */ , 
            new GuiBoundPropertyString ("Share5", "Recovery share", (object data) => (data as _AccountRecover)?.Share5 , 
                (object data,string? value) => { if (data is _AccountRecover datad) { datad.Share5 = value; }})  /* 7 */ , 
            new GuiBoundPropertyString ("Share6", "Recovery share", (object data) => (data as _AccountRecover)?.Share6 , 
                (object data,string? value) => { if (data is _AccountRecover datad) { datad.Share6 = value; }})  /* 8 */ , 
            new GuiBoundPropertyString ("Share7", "Recovery share", (object data) => (data as _AccountRecover)?.Share7 , 
                (object data,string? value) => { if (data is _AccountRecover datad) { datad.Share7 = value; }})  /* 9 */ , 
            new GuiBoundPropertyString ("Share8", "Recovery share", (object data) => (data as _AccountRecover)?.Share8 , 
                (object data,string? value) => { if (data is _AccountRecover datad) { datad.Share8 = value; }})  /* 10 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action AccountDelete 
/// </summary>
public partial class AccountDelete : _AccountDelete {
    }


/// <summary>
/// Callback parameters for action AccountDelete 
/// </summary>
public partial class _AccountDelete : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _AccountDelete,
        () => new AccountDelete(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action AccountSwitch 
/// </summary>
public partial class AccountSwitch : _AccountSwitch {
    }


/// <summary>
/// Callback parameters for action AccountSwitch 
/// </summary>
public partial class _AccountSwitch : IParameter {

    ///<summary></summary> 
    public virtual ISelectCollection? ChooseUser { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingMultiple BaseBinding  { get; } = new (
        (object test) => test is _AccountSwitch,
        () => new AccountSwitch(),
        [ 
            new GuiBoundPropertyChooser ("ChooseUser", "User", (object data) => (data as _AccountSwitch)?.ChooseUser , null)  /* 0 */ 
            ], 0
);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action AccountGenerateRecovery 
/// </summary>
public partial class AccountGenerateRecovery : _AccountGenerateRecovery {
    }


/// <summary>
/// Callback parameters for action AccountGenerateRecovery 
/// </summary>
public partial class _AccountGenerateRecovery : IParameter {

    ///<summary></summary> 
    public virtual int? NumberShares { get; set;} 

    ///<summary></summary> 
    public virtual int? Quorum { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _AccountGenerateRecovery,
        () => new AccountGenerateRecovery(),
        [ 
            new GuiBoundPropertyInteger ("NumberShares", "Total number of shares", (object data) => (data as _AccountGenerateRecovery)?.NumberShares , 
                (object data,int? value) => { if (data is _AccountGenerateRecovery datad) { datad.NumberShares = value; }})  /* 0 */ , 
            new GuiBoundPropertyInteger ("Quorum", "Quorum required for recovery", (object data) => (data as _AccountGenerateRecovery)?.Quorum , 
                (object data,int? value) => { if (data is _AccountGenerateRecovery datad) { datad.Quorum = value; }})  /* 1 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action RequestConfirmation 
/// </summary>
public partial class RequestConfirmation : _RequestConfirmation {
    }


/// <summary>
/// Callback parameters for action RequestConfirmation 
/// </summary>
public partial class _RequestConfirmation : IParameter {

    ///<summary></summary> 
    public virtual string? Recipient { get; set;} 

    ///<summary></summary> 
    public virtual string? Message { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _RequestConfirmation,
        () => new RequestConfirmation(),
        [ 
            new GuiBoundPropertyString ("Recipient", "Address", (object data) => (data as _RequestConfirmation)?.Recipient , 
                (object data,string? value) => { if (data is _RequestConfirmation datad) { datad.Recipient = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("Message", "Message", (object data) => (data as _RequestConfirmation)?.Message , 
                (object data,string? value) => { if (data is _RequestConfirmation datad) { datad.Message = value; }})  /* 1 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action CreateMail 
/// </summary>
public partial class CreateMail : _CreateMail {
    }


/// <summary>
/// Callback parameters for action CreateMail 
/// </summary>
public partial class _CreateMail : IParameter {

    ///<summary></summary> 
    public virtual string? Recipient { get; set;} 

    ///<summary></summary> 
    public virtual string? Subject { get; set;} 

    ///<summary></summary> 
    public virtual string? Message { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _CreateMail,
        () => new CreateMail(),
        [ 
            new GuiBoundPropertyString ("Recipient", "Address", (object data) => (data as _CreateMail)?.Recipient , 
                (object data,string? value) => { if (data is _CreateMail datad) { datad.Recipient = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("Subject", "Subject", (object data) => (data as _CreateMail)?.Subject , 
                (object data,string? value) => { if (data is _CreateMail datad) { datad.Subject = value; }})  /* 1 */ , 
            new GuiBoundTextArea ("Message", "Message", (object data) => (data as _CreateMail)?.Message , 
                (object data,string? value) => { if (data is _CreateMail datad) { datad.Message = value; }})  /* 2 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action CreateChat 
/// </summary>
public partial class CreateChat : _CreateChat {
    }


/// <summary>
/// Callback parameters for action CreateChat 
/// </summary>
public partial class _CreateChat : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _CreateChat,
        () => new CreateChat(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action StartVoice 
/// </summary>
public partial class StartVoice : _StartVoice {
    }


/// <summary>
/// Callback parameters for action StartVoice 
/// </summary>
public partial class _StartVoice : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _StartVoice,
        () => new StartVoice(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action StartVideo 
/// </summary>
public partial class StartVideo : _StartVideo {
    }


/// <summary>
/// Callback parameters for action StartVideo 
/// </summary>
public partial class _StartVideo : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _StartVideo,
        () => new StartVideo(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action AddPerson 
/// </summary>
public partial class AddPerson : _AddPerson {
    }


/// <summary>
/// Callback parameters for action AddPerson 
/// </summary>
public partial class _AddPerson : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _AddPerson,
        () => new AddPerson(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action AddOrganization 
/// </summary>
public partial class AddOrganization : _AddOrganization {
    }


/// <summary>
/// Callback parameters for action AddOrganization 
/// </summary>
public partial class _AddOrganization : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _AddOrganization,
        () => new AddOrganization(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action AddLocation 
/// </summary>
public partial class AddLocation : _AddLocation {
    }


/// <summary>
/// Callback parameters for action AddLocation 
/// </summary>
public partial class _AddLocation : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _AddLocation,
        () => new AddLocation(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action RequestContact 
/// </summary>
public partial class RequestContact : _RequestContact {
    }


/// <summary>
/// Callback parameters for action RequestContact 
/// </summary>
public partial class _RequestContact : IParameter {

    ///<summary></summary> 
    public virtual string? Recipient { get; set;} 

    ///<summary></summary> 
    public virtual string? Message { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _RequestContact,
        () => new RequestContact(),
        [ 
            new GuiBoundPropertyString ("Recipient", "Address", (object data) => (data as _RequestContact)?.Recipient , 
                (object data,string? value) => { if (data is _RequestContact datad) { datad.Recipient = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("Message", "Message", (object data) => (data as _RequestContact)?.Message , 
                (object data,string? value) => { if (data is _RequestContact datad) { datad.Message = value; }})  /* 1 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action QrContact 
/// </summary>
public partial class QrContact : _QrContact {
    }


/// <summary>
/// Callback parameters for action QrContact 
/// </summary>
public partial class _QrContact : IParameter {

    ///<summary></summary> 
    public virtual GuiQR? QrCode { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingQr BaseBinding  { get; } = new (
        (object test) => test is _QrContact,
        () => new QrContact(),
        [ 
            new GuiBoundPropertyQRScan ("QrCode", "Contact QR", (object data) => (data as _QrContact)?.QrCode , 
                (object data,GuiQR? value) => { if (data is _QrContact datad) { datad.QrCode = value; }})  /* 0 */ 
            ], 0
);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action ContactAddNetwork 
/// </summary>
public partial class ContactAddNetwork : _ContactAddNetwork {
    }


/// <summary>
/// Callback parameters for action ContactAddNetwork 
/// </summary>
public partial class _ContactAddNetwork : IParameter {

    ///<summary></summary> 
    public virtual BoundContactPerson Context { get; set;} 

    ///<summary></summary> 
    public virtual string? Protocol { get; set;} 

    ///<summary></summary> 
    public virtual string? Address { get; set;} 

    ///<summary></summary> 
    public virtual string? Fingerprint { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _ContactAddNetwork,
        () => new ContactAddNetwork(),
        [ 
            new GuiBoundPropertyString ("Protocol", "Protocol", (object data) => (data as _ContactAddNetwork)?.Protocol , 
                (object data,string? value) => { if (data is _ContactAddNetwork datad) { datad.Protocol = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("Address", "Address", (object data) => (data as _ContactAddNetwork)?.Address , 
                (object data,string? value) => { if (data is _ContactAddNetwork datad) { datad.Address = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Fingerprint", "Fingerprint", (object data) => (data as _ContactAddNetwork)?.Fingerprint , 
                (object data,string? value) => { if (data is _ContactAddNetwork datad) { datad.Fingerprint = value; }})  /* 2 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action ContactAddCredential 
/// </summary>
public partial class ContactAddCredential : _ContactAddCredential {
    }


/// <summary>
/// Callback parameters for action ContactAddCredential 
/// </summary>
public partial class _ContactAddCredential : IParameter {

    ///<summary></summary> 
    public virtual BoundContactPerson Context { get; set;} 

    ///<summary></summary> 
    public virtual string? File { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _ContactAddCredential,
        () => new ContactAddCredential(),
        [ 
            new GuiBoundPropertyString ("File", "File name TBS", (object data) => (data as _ContactAddCredential)?.File , 
                (object data,string? value) => { if (data is _ContactAddCredential datad) { datad.File = value; }})  /* 0 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action ContactAddPostal 
/// </summary>
public partial class ContactAddPostal : _ContactAddPostal {
    }


/// <summary>
/// Callback parameters for action ContactAddPostal 
/// </summary>
public partial class _ContactAddPostal : IParameter {

    ///<summary></summary> 
    public virtual BoundContactPerson Context { get; set;} 

    ///<summary></summary> 
    public virtual string? Appartment { get; set;} 

    ///<summary></summary> 
    public virtual string? Street { get; set;} 

    ///<summary></summary> 
    public virtual string? District { get; set;} 

    ///<summary></summary> 
    public virtual string? Locality { get; set;} 

    ///<summary></summary> 
    public virtual string? County { get; set;} 

    ///<summary></summary> 
    public virtual string? Postcode { get; set;} 

    ///<summary></summary> 
    public virtual string? Country { get; set;} 

    ///<summary></summary> 
    public virtual decimal? Latitude { get; set;} 

    ///<summary></summary> 
    public virtual decimal? Longitude { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _ContactAddPostal,
        () => new ContactAddPostal(),
        [ 
            new GuiBoundPropertyString ("Appartment", "Appartment", (object data) => (data as _ContactAddPostal)?.Appartment , 
                (object data,string? value) => { if (data is _ContactAddPostal datad) { datad.Appartment = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("Street", "Street", (object data) => (data as _ContactAddPostal)?.Street , 
                (object data,string? value) => { if (data is _ContactAddPostal datad) { datad.Street = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("District", "District", (object data) => (data as _ContactAddPostal)?.District , 
                (object data,string? value) => { if (data is _ContactAddPostal datad) { datad.District = value; }})  /* 2 */ , 
            new GuiBoundPropertyString ("Locality", "Locality", (object data) => (data as _ContactAddPostal)?.Locality , 
                (object data,string? value) => { if (data is _ContactAddPostal datad) { datad.Locality = value; }})  /* 3 */ , 
            new GuiBoundPropertyString ("County", "County", (object data) => (data as _ContactAddPostal)?.County , 
                (object data,string? value) => { if (data is _ContactAddPostal datad) { datad.County = value; }})  /* 4 */ , 
            new GuiBoundPropertyString ("Postcode", "Postcode", (object data) => (data as _ContactAddPostal)?.Postcode , 
                (object data,string? value) => { if (data is _ContactAddPostal datad) { datad.Postcode = value; }})  /* 5 */ , 
            new GuiBoundPropertyString ("Country", "Country", (object data) => (data as _ContactAddPostal)?.Country , 
                (object data,string? value) => { if (data is _ContactAddPostal datad) { datad.Country = value; }})  /* 6 */ , 
            new GuiBoundPropertyDecimal ("Latitude", "Latitude", (object data) => (data as _ContactAddPostal)?.Latitude , 
                (object data,decimal? value) => { if (data is _ContactAddPostal datad) { datad.Latitude = value; }})  /* 7 */ , 
            new GuiBoundPropertyDecimal ("Longitude", "Longitude", (object data) => (data as _ContactAddPostal)?.Longitude , 
                (object data,decimal? value) => { if (data is _ContactAddPostal datad) { datad.Longitude = value; }})  /* 8 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action UploadDocument 
/// </summary>
public partial class UploadDocument : _UploadDocument {
    }


/// <summary>
/// Callback parameters for action UploadDocument 
/// </summary>
public partial class _UploadDocument : IParameter {

    ///<summary></summary> 
    public virtual string? Title { get; set;} 

    ///<summary></summary> 
    public virtual string? Version { get; set;} 

    ///<summary></summary> 
    public virtual string? Path { get; set;} 

    ///<summary></summary> 
    public virtual string? Description { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _UploadDocument,
        () => new UploadDocument(),
        [ 
            new GuiBoundPropertyString ("Title", "Title", (object data) => (data as _UploadDocument)?.Title , 
                (object data,string? value) => { if (data is _UploadDocument datad) { datad.Title = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("Version", "Version", (object data) => (data as _UploadDocument)?.Version , 
                (object data,string? value) => { if (data is _UploadDocument datad) { datad.Version = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Path", "Path", (object data) => (data as _UploadDocument)?.Path , 
                (object data,string? value) => { if (data is _UploadDocument datad) { datad.Path = value; }})  /* 2 */ , 
            new GuiBoundPropertyString ("Description", "Description", (object data) => (data as _UploadDocument)?.Description , 
                (object data,string? value) => { if (data is _UploadDocument datad) { datad.Description = value; }})  /* 3 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action AddFeed 
/// </summary>
public partial class AddFeed : _AddFeed {
    }


/// <summary>
/// Callback parameters for action AddFeed 
/// </summary>
public partial class _AddFeed : IParameter {

    ///<summary></summary> 
    public virtual string? Title { get; set;} 

    ///<summary></summary> 
    public virtual string? Uri { get; set;} 

    ///<summary></summary> 
    public virtual string? Path { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _AddFeed,
        () => new AddFeed(),
        [ 
            new GuiBoundPropertyString ("Title", "Title", (object data) => (data as _AddFeed)?.Title , 
                (object data,string? value) => { if (data is _AddFeed datad) { datad.Title = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("Uri", "Uri", (object data) => (data as _AddFeed)?.Uri , 
                (object data,string? value) => { if (data is _AddFeed datad) { datad.Uri = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Path", "Path", (object data) => (data as _AddFeed)?.Path , 
                (object data,string? value) => { if (data is _AddFeed datad) { datad.Path = value; }})  /* 2 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action AddGroup 
/// </summary>
public partial class AddGroup : _AddGroup {
    }


/// <summary>
/// Callback parameters for action AddGroup 
/// </summary>
public partial class _AddGroup : IParameter {

    ///<summary></summary> 
    public virtual string? GroupName { get; set;} 

    ///<summary></summary> 
    public virtual string? GroupAddress { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _AddGroup,
        () => new AddGroup(),
        [ 
            new GuiBoundPropertyString ("GroupName", "Name", (object data) => (data as _AddGroup)?.GroupName , 
                (object data,string? value) => { if (data is _AddGroup datad) { datad.GroupName = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("GroupAddress", "Address", (object data) => (data as _AddGroup)?.GroupAddress , 
                (object data,string? value) => { if (data is _AddGroup datad) { datad.GroupAddress = value; }})  /* 1 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action GroupInvite 
/// </summary>
public partial class GroupInvite : _GroupInvite {
    }


/// <summary>
/// Callback parameters for action GroupInvite 
/// </summary>
public partial class _GroupInvite : IParameter {

    ///<summary></summary> 
    public virtual string? Address { get; set;} 

    ///<summary></summary> 
    public virtual string? Message { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _GroupInvite,
        () => new GroupInvite(),
        [ 
            new GuiBoundPropertyString ("Address", "Member Address", (object data) => (data as _GroupInvite)?.Address , 
                (object data,string? value) => { if (data is _GroupInvite datad) { datad.Address = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("Message", "Message", (object data) => (data as _GroupInvite)?.Message , 
                (object data,string? value) => { if (data is _GroupInvite datad) { datad.Message = value; }})  /* 1 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action AddPassword 
/// </summary>
public partial class AddPassword : _AddPassword {
    }


/// <summary>
/// Callback parameters for action AddPassword 
/// </summary>
public partial class _AddPassword : IParameter {

    ///<summary></summary> 
    public virtual string? Protocol { get; set;} 

    ///<summary></summary> 
    public virtual string? Service { get; set;} 

    ///<summary></summary> 
    public virtual string? Username { get; set;} 

    ///<summary></summary> 
    public virtual string? Password { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _AddPassword,
        () => new AddPassword(),
        [ 
            new GuiBoundPropertyString ("Protocol", "Protocol", (object data) => (data as _AddPassword)?.Protocol , 
                (object data,string? value) => { if (data is _AddPassword datad) { datad.Protocol = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("Service", "Service", (object data) => (data as _AddPassword)?.Service , 
                (object data,string? value) => { if (data is _AddPassword datad) { datad.Service = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Username", "Username", (object data) => (data as _AddPassword)?.Username , 
                (object data,string? value) => { if (data is _AddPassword datad) { datad.Username = value; }})  /* 2 */ , 
            new GuiBoundPropertyString ("Password", "Password", (object data) => (data as _AddPassword)?.Password , 
                (object data,string? value) => { if (data is _AddPassword datad) { datad.Password = value; }})  /* 3 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action AddPasskey 
/// </summary>
public partial class AddPasskey : _AddPasskey {
    }


/// <summary>
/// Callback parameters for action AddPasskey 
/// </summary>
public partial class _AddPasskey : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _AddPasskey,
        () => new AddPasskey(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action AddTask 
/// </summary>
public partial class AddTask : _AddTask {
    }


/// <summary>
/// Callback parameters for action AddTask 
/// </summary>
public partial class _AddTask : IParameter {

    ///<summary></summary> 
    public virtual string? Title { get; set;} 

    ///<summary></summary> 
    public virtual string? Path { get; set;} 

    ///<summary></summary> 
    public virtual string? Description { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _AddTask,
        () => new AddTask(),
        [ 
            new GuiBoundPropertyString ("Title", "Title", (object data) => (data as _AddTask)?.Title , 
                (object data,string? value) => { if (data is _AddTask datad) { datad.Title = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("Path", "Path", (object data) => (data as _AddTask)?.Path , 
                (object data,string? value) => { if (data is _AddTask datad) { datad.Path = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Description", "Description", (object data) => (data as _AddTask)?.Description , 
                (object data,string? value) => { if (data is _AddTask datad) { datad.Description = value; }})  /* 2 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action AddBookmark 
/// </summary>
public partial class AddBookmark : _AddBookmark {
    }


/// <summary>
/// Callback parameters for action AddBookmark 
/// </summary>
public partial class _AddBookmark : IParameter {

    ///<summary></summary> 
    public virtual string? Title { get; set;} 

    ///<summary></summary> 
    public virtual string? Uri { get; set;} 

    ///<summary></summary> 
    public virtual string? Path { get; set;} 

    ///<summary></summary> 
    public virtual string? Description { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _AddBookmark,
        () => new AddBookmark(),
        [ 
            new GuiBoundPropertyString ("Title", "Title", (object data) => (data as _AddBookmark)?.Title , 
                (object data,string? value) => { if (data is _AddBookmark datad) { datad.Title = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("Uri", "Uri", (object data) => (data as _AddBookmark)?.Uri , 
                (object data,string? value) => { if (data is _AddBookmark datad) { datad.Uri = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Path", "Path", (object data) => (data as _AddBookmark)?.Path , 
                (object data,string? value) => { if (data is _AddBookmark datad) { datad.Path = value; }})  /* 2 */ , 
            new GuiBoundPropertyString ("Description", "Description", (object data) => (data as _AddBookmark)?.Description , 
                (object data,string? value) => { if (data is _AddBookmark datad) { datad.Description = value; }})  /* 3 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action AddMailAccount 
/// </summary>
public partial class AddMailAccount : _AddMailAccount {
    }


/// <summary>
/// Callback parameters for action AddMailAccount 
/// </summary>
public partial class _AddMailAccount : IParameter {

    ///<summary></summary> 
    public virtual string? AccountAddress { get; set;} 

    ///<summary></summary> 
    public virtual string? LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string? Description { get; set;} 

    ///<summary></summary> 
    public virtual string? Path { get; set;} 

    ///<summary></summary> 
    public virtual string? InboundConnect { get; set;} 

    ///<summary></summary> 
    public virtual string? OutboundConnect { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _AddMailAccount,
        () => new AddMailAccount(),
        [ 
            new GuiBoundPropertyString ("AccountAddress", "Address", (object data) => (data as _AddMailAccount)?.AccountAddress , 
                (object data,string? value) => { if (data is _AddMailAccount datad) { datad.AccountAddress = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("LocalName", "Local", (object data) => (data as _AddMailAccount)?.LocalName , 
                (object data,string? value) => { if (data is _AddMailAccount datad) { datad.LocalName = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Description", "Description", (object data) => (data as _AddMailAccount)?.Description , 
                (object data,string? value) => { if (data is _AddMailAccount datad) { datad.Description = value; }})  /* 2 */ , 
            new GuiBoundPropertyString ("Path", "Path", (object data) => (data as _AddMailAccount)?.Path , 
                (object data,string? value) => { if (data is _AddMailAccount datad) { datad.Path = value; }})  /* 3 */ , 
            new GuiBoundPropertyString ("InboundConnect", "Inbound Service", (object data) => (data as _AddMailAccount)?.InboundConnect , 
                (object data,string? value) => { if (data is _AddMailAccount datad) { datad.InboundConnect = value; }})  /* 4 */ , 
            new GuiBoundPropertyString ("OutboundConnect", "Outbound Service", (object data) => (data as _AddMailAccount)?.OutboundConnect , 
                (object data,string? value) => { if (data is _AddMailAccount datad) { datad.OutboundConnect = value; }})  /* 5 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action AddSshAccount 
/// </summary>
public partial class AddSshAccount : _AddSshAccount {
    }


/// <summary>
/// Callback parameters for action AddSshAccount 
/// </summary>
public partial class _AddSshAccount : IParameter {

    ///<summary></summary> 
    public virtual string? Algorithm { get; set;} 

    ///<summary></summary> 
    public virtual string? LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string? Description { get; set;} 

    ///<summary></summary> 
    public virtual string? Path { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _AddSshAccount,
        () => new AddSshAccount(),
        [ 
            new GuiBoundPropertyString ("Algorithm", "Algorithm", (object data) => (data as _AddSshAccount)?.Algorithm , 
                (object data,string? value) => { if (data is _AddSshAccount datad) { datad.Algorithm = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("LocalName", "Local", (object data) => (data as _AddSshAccount)?.LocalName , 
                (object data,string? value) => { if (data is _AddSshAccount datad) { datad.LocalName = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Description", "Description", (object data) => (data as _AddSshAccount)?.Description , 
                (object data,string? value) => { if (data is _AddSshAccount datad) { datad.Description = value; }})  /* 2 */ , 
            new GuiBoundPropertyString ("Path", "Path", (object data) => (data as _AddSshAccount)?.Path , 
                (object data,string? value) => { if (data is _AddSshAccount datad) { datad.Path = value; }})  /* 3 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action AddGitAccount 
/// </summary>
public partial class AddGitAccount : _AddGitAccount {
    }


/// <summary>
/// Callback parameters for action AddGitAccount 
/// </summary>
public partial class _AddGitAccount : IParameter {

    ///<summary></summary> 
    public virtual string? Algorithm { get; set;} 

    ///<summary></summary> 
    public virtual string? LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string? Description { get; set;} 

    ///<summary></summary> 
    public virtual string? Path { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _AddGitAccount,
        () => new AddGitAccount(),
        [ 
            new GuiBoundPropertyString ("Algorithm", "Algorithm", (object data) => (data as _AddGitAccount)?.Algorithm , 
                (object data,string? value) => { if (data is _AddGitAccount datad) { datad.Algorithm = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("LocalName", "Local", (object data) => (data as _AddGitAccount)?.LocalName , 
                (object data,string? value) => { if (data is _AddGitAccount datad) { datad.LocalName = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Description", "Description", (object data) => (data as _AddGitAccount)?.Description , 
                (object data,string? value) => { if (data is _AddGitAccount datad) { datad.Description = value; }})  /* 2 */ , 
            new GuiBoundPropertyString ("Path", "Path", (object data) => (data as _AddGitAccount)?.Path , 
                (object data,string? value) => { if (data is _AddGitAccount datad) { datad.Path = value; }})  /* 3 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action AddCodeSigningKey 
/// </summary>
public partial class AddCodeSigningKey : _AddCodeSigningKey {
    }


/// <summary>
/// Callback parameters for action AddCodeSigningKey 
/// </summary>
public partial class _AddCodeSigningKey : IParameter {

    ///<summary></summary> 
    public virtual string? Algorithm { get; set;} 

    ///<summary></summary> 
    public virtual string? LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string? Description { get; set;} 

    ///<summary></summary> 
    public virtual string? Path { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _AddCodeSigningKey,
        () => new AddCodeSigningKey(),
        [ 
            new GuiBoundPropertyString ("Algorithm", "Algorithm", (object data) => (data as _AddCodeSigningKey)?.Algorithm , 
                (object data,string? value) => { if (data is _AddCodeSigningKey datad) { datad.Algorithm = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("LocalName", "Local", (object data) => (data as _AddCodeSigningKey)?.LocalName , 
                (object data,string? value) => { if (data is _AddCodeSigningKey datad) { datad.LocalName = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Description", "Description", (object data) => (data as _AddCodeSigningKey)?.Description , 
                (object data,string? value) => { if (data is _AddCodeSigningKey datad) { datad.Description = value; }})  /* 2 */ , 
            new GuiBoundPropertyString ("Path", "Path", (object data) => (data as _AddCodeSigningKey)?.Path , 
                (object data,string? value) => { if (data is _AddCodeSigningKey datad) { datad.Path = value; }})  /* 3 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action DeviceConnectQR 
/// </summary>
public partial class DeviceConnectQR : _DeviceConnectQR {
    }


/// <summary>
/// Callback parameters for action DeviceConnectQR 
/// </summary>
public partial class _DeviceConnectQR : IParameter {

    ///<summary></summary> 
    public virtual GuiQR? QrCode { get; set;} 

    ///<summary></summary> 
    public virtual string? LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string? Rights { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingQr BaseBinding  { get; } = new (
        (object test) => test is _DeviceConnectQR,
        () => new DeviceConnectQR(),
        [ 
            new GuiBoundPropertyQRScan ("QrCode", "Contact QR", (object data) => (data as _DeviceConnectQR)?.QrCode , 
                (object data,GuiQR? value) => { if (data is _DeviceConnectQR datad) { datad.QrCode = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("LocalName", "Friendly name (optional)", (object data) => (data as _DeviceConnectQR)?.LocalName , 
                (object data,string? value) => { if (data is _DeviceConnectQR datad) { datad.LocalName = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Rights", "Assigned rights", (object data) => (data as _DeviceConnectQR)?.Rights , 
                (object data,string? value) => { if (data is _DeviceConnectQR datad) { datad.Rights = value; }})  /* 2 */ 
            ], 0
);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action AccountGetPin 
/// </summary>
public partial class AccountGetPin : _AccountGetPin {
    }


/// <summary>
/// Callback parameters for action AccountGetPin 
/// </summary>
public partial class _AccountGetPin : IParameter {

    ///<summary></summary> 
    public virtual string? Rights { get; set;} 

    ///<summary></summary> 
    public virtual int? Security { get; set;} 

    ///<summary></summary> 
    public virtual int? Expire { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _AccountGetPin,
        () => new AccountGetPin(),
        [ 
            new GuiBoundPropertyString ("Rights", "Assigned rights", (object data) => (data as _AccountGetPin)?.Rights , 
                (object data,string? value) => { if (data is _AccountGetPin datad) { datad.Rights = value; }})  /* 0 */ , 
            new GuiBoundPropertyInteger ("Security", "Security level", (object data) => (data as _AccountGetPin)?.Security , 
                (object data,int? value) => { if (data is _AccountGetPin datad) { datad.Security = value; }})  /* 1 */ , 
            new GuiBoundPropertyInteger ("Expire", "Expiry in hours", (object data) => (data as _AccountGetPin)?.Expire , 
                (object data,int? value) => { if (data is _AccountGetPin datad) { datad.Expire = value; }})  /* 2 */ 
            ]);
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }

#endregion
#region // Selections


/// <summary>
/// Callback parameters for action AccountSelect 
/// </summary>
public partial class AccountSelect : _AccountSelect {
    }


/// <summary>
/// Callback parameters for action AccountSelect 
/// </summary>
public partial class _AccountSelect : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _AccountSelect,
        () => new AccountSelect(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action ActionAccept 
/// </summary>
public partial class ActionAccept : _ActionAccept {
    }


/// <summary>
/// Callback parameters for action ActionAccept 
/// </summary>
public partial class _ActionAccept : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _ActionAccept,
        () => new ActionAccept(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action ActionReject 
/// </summary>
public partial class ActionReject : _ActionReject {
    }


/// <summary>
/// Callback parameters for action ActionReject 
/// </summary>
public partial class _ActionReject : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _ActionReject,
        () => new ActionReject(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action DocumentUpdate 
/// </summary>
public partial class DocumentUpdate : _DocumentUpdate {
    }


/// <summary>
/// Callback parameters for action DocumentUpdate 
/// </summary>
public partial class _DocumentUpdate : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _DocumentUpdate,
        () => new DocumentUpdate(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action DocumentExport 
/// </summary>
public partial class DocumentExport : _DocumentExport {
    }


/// <summary>
/// Callback parameters for action DocumentExport 
/// </summary>
public partial class _DocumentExport : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _DocumentExport,
        () => new DocumentExport(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action DocumentSend 
/// </summary>
public partial class DocumentSend : _DocumentSend {
    }


/// <summary>
/// Callback parameters for action DocumentSend 
/// </summary>
public partial class _DocumentSend : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _DocumentSend,
        () => new DocumentSend(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action DocumentDelete 
/// </summary>
public partial class DocumentDelete : _DocumentDelete {
    }


/// <summary>
/// Callback parameters for action DocumentDelete 
/// </summary>
public partial class _DocumentDelete : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _DocumentDelete,
        () => new DocumentDelete(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action MemberDelete 
/// </summary>
public partial class MemberDelete : _MemberDelete {
    }


/// <summary>
/// Callback parameters for action MemberDelete 
/// </summary>
public partial class _MemberDelete : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _MemberDelete,
        () => new MemberDelete(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action MemberReInvite 
/// </summary>
public partial class MemberReInvite : _MemberReInvite {
    }


/// <summary>
/// Callback parameters for action MemberReInvite 
/// </summary>
public partial class _MemberReInvite : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _MemberReInvite,
        () => new MemberReInvite(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action CredentialUpdate 
/// </summary>
public partial class CredentialUpdate : _CredentialUpdate {
    }


/// <summary>
/// Callback parameters for action CredentialUpdate 
/// </summary>
public partial class _CredentialUpdate : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _CredentialUpdate,
        () => new CredentialUpdate(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action CredentialDelete 
/// </summary>
public partial class CredentialDelete : _CredentialDelete {
    }


/// <summary>
/// Callback parameters for action CredentialDelete 
/// </summary>
public partial class _CredentialDelete : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _CredentialDelete,
        () => new CredentialDelete(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action TaskUpdate 
/// </summary>
public partial class TaskUpdate : _TaskUpdate {
    }


/// <summary>
/// Callback parameters for action TaskUpdate 
/// </summary>
public partial class _TaskUpdate : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _TaskUpdate,
        () => new TaskUpdate(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action TaskDelete 
/// </summary>
public partial class TaskDelete : _TaskDelete {
    }


/// <summary>
/// Callback parameters for action TaskDelete 
/// </summary>
public partial class _TaskDelete : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _TaskDelete,
        () => new TaskDelete(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action BookmarkUpdate 
/// </summary>
public partial class BookmarkUpdate : _BookmarkUpdate {
    }


/// <summary>
/// Callback parameters for action BookmarkUpdate 
/// </summary>
public partial class _BookmarkUpdate : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BookmarkUpdate,
        () => new BookmarkUpdate(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action BookmarkDelete 
/// </summary>
public partial class BookmarkDelete : _BookmarkDelete {
    }


/// <summary>
/// Callback parameters for action BookmarkDelete 
/// </summary>
public partial class _BookmarkDelete : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _BookmarkDelete,
        () => new BookmarkDelete(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action ApplicationUpdate 
/// </summary>
public partial class ApplicationUpdate : _ApplicationUpdate {
    }


/// <summary>
/// Callback parameters for action ApplicationUpdate 
/// </summary>
public partial class _ApplicationUpdate : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _ApplicationUpdate,
        () => new ApplicationUpdate(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action ApplicationDelete 
/// </summary>
public partial class ApplicationDelete : _ApplicationDelete {
    }


/// <summary>
/// Callback parameters for action ApplicationDelete 
/// </summary>
public partial class _ApplicationDelete : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _ApplicationDelete,
        () => new ApplicationDelete(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action DeviceUpdate 
/// </summary>
public partial class DeviceUpdate : _DeviceUpdate {
    }


/// <summary>
/// Callback parameters for action DeviceUpdate 
/// </summary>
public partial class _DeviceUpdate : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _DeviceUpdate,
        () => new DeviceUpdate(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action DeviceDelete 
/// </summary>
public partial class DeviceDelete : _DeviceDelete {
    }


/// <summary>
/// Callback parameters for action DeviceDelete 
/// </summary>
public partial class _DeviceDelete : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is _DeviceDelete,
        () => new DeviceDelete(),
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid? result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }

#endregion
#region // Results


/// <summary>
/// Return parameters for result SuccessGroupCreate 
/// </summary>
public partial record SuccessGroupCreate : _SuccessGroupCreate {
    }


/// <summary>
/// Callback parameters for result SuccessGroupCreate 
/// </summary>
public partial record _SuccessGroupCreate : IResult {

    ///<inheritdoc/>
    public string Message => "Group Created";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("SuccessGroupCreate");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Report;

    ///<summary></summary> 
    public virtual string? GroupName { get; set;} 

    ///<summary></summary> 
    public virtual string? GroupAddress { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is SuccessGroupCreate,
        () => new SuccessGroupCreate(),
        [ 
            new GuiBoundPropertyString ("GroupName", "Name", (object data) => (data as SuccessGroupCreate)?.GroupName , 
                (object data,string? value) => { if (data is SuccessGroupCreate datad) { datad.GroupName = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("GroupAddress", "Address", (object data) => (data as SuccessGroupCreate)?.GroupAddress , 
                (object data,string? value) => { if (data is SuccessGroupCreate datad) { datad.GroupAddress = value; }})  /* 1 */ 
            ]);

    ///<inheritdoc/>
    public object?[] GetValues() => new [] { 
        GroupName,
        GroupAddress};
    }


/// <summary>
/// Return parameters for result ReportPinValue 
/// </summary>
public partial record ReportPinValue : _ReportPinValue {
    }


/// <summary>
/// Callback parameters for result ReportPinValue 
/// </summary>
public partial record _ReportPinValue : IResult {

    ///<inheritdoc/>
    public string Message => "Pin Value";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("ReportPinValue");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Report;

    ///<summary></summary> 
    public virtual string? Pin { get; set;} 

    ///<summary></summary> 
    public virtual string? Expiry { get; set;} 

    ///<summary></summary> 
    public virtual string? Rights { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is ReportPinValue,
        () => new ReportPinValue(),
        [ 
            new GuiBoundPropertyString ("Pin", "Pin", (object data) => (data as ReportPinValue)?.Pin , 
                (object data,string? value) => { if (data is ReportPinValue datad) { datad.Pin = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("Expiry", "Expires", (object data) => (data as ReportPinValue)?.Expiry , 
                (object data,string? value) => { if (data is ReportPinValue datad) { datad.Expiry = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Rights", "Rights", (object data) => (data as ReportPinValue)?.Rights , 
                (object data,string? value) => { if (data is ReportPinValue datad) { datad.Rights = value; }})  /* 2 */ 
            ]);

    ///<inheritdoc/>
    public object?[] GetValues() => new [] { 
        Pin,
        Expiry,
        Rights};
    }


/// <summary>
/// Return parameters for result ReportHost 
/// </summary>
public partial record ReportHost : _ReportHost {
    }


/// <summary>
/// Callback parameters for result ReportHost 
/// </summary>
public partial record _ReportHost : IResult {

    ///<inheritdoc/>
    public string Message => "Host {0} acknowledged your request.";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("ReportHost");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Report;

    ///<summary></summary> 
    public virtual string? ServiceAddress { get; set;} 

    ///<summary></summary> 
    public virtual string? ServiceCallsign { get; set;} 

    ///<summary></summary> 
    public virtual string? ServiceDns { get; set;} 

    ///<summary></summary> 
    public virtual string? ServiceUdf { get; set;} 

    ///<summary></summary> 
    public virtual string? HostUdf { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is ReportHost,
        () => new ReportHost(),
        [ 
            new GuiBoundPropertyString ("ServiceCallsign", "Callsign", (object data) => (data as ReportHost)?.ServiceCallsign , 
                (object data,string? value) => { if (data is ReportHost datad) { datad.ServiceCallsign = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("ServiceDns", "DNS", (object data) => (data as ReportHost)?.ServiceDns , 
                (object data,string? value) => { if (data is ReportHost datad) { datad.ServiceDns = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("ServiceUdf", "Service fingerprint", (object data) => (data as ReportHost)?.ServiceUdf , 
                (object data,string? value) => { if (data is ReportHost datad) { datad.ServiceUdf = value; }})  /* 2 */ , 
            new GuiBoundPropertyString ("HostUdf", "Host fingerprint", (object data) => (data as ReportHost)?.HostUdf , 
                (object data,string? value) => { if (data is ReportHost datad) { datad.HostUdf = value; }})  /* 3 */ 
            ]);

    ///<inheritdoc/>
    public object?[] GetValues() => new [] { 
        ServiceAddress,
        ServiceCallsign,
        ServiceDns,
        ServiceUdf,
        HostUdf};
    }


/// <summary>
/// Return parameters for result ReportAccountCreate 
/// </summary>
public partial record ReportAccountCreate : _ReportAccountCreate {
    }


/// <summary>
/// Callback parameters for result ReportAccountCreate 
/// </summary>
public partial record _ReportAccountCreate : IResult {

    ///<inheritdoc/>
    public string Message => "Created account {0}.";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("ReportAccountCreate");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Report;

    ///<summary></summary> 
    public virtual string? ServiceName { get; set;} 

    ///<summary></summary> 
    public virtual string? LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string? ServiceAddress { get; set;} 

    ///<summary></summary> 
    public virtual string? ProfileUdf { get; set;} 

    ///<summary></summary> 
    public virtual string? ServiceUdf { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is ReportAccountCreate,
        () => new ReportAccountCreate(),
        [ 
            new GuiBoundPropertyString ("LocalName", "Local", (object data) => (data as ReportAccountCreate)?.LocalName , 
                (object data,string? value) => { if (data is ReportAccountCreate datad) { datad.LocalName = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("ServiceAddress", "DNS", (object data) => (data as ReportAccountCreate)?.ServiceAddress , 
                (object data,string? value) => { if (data is ReportAccountCreate datad) { datad.ServiceAddress = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("ProfileUdf", "Profile fingerprint", (object data) => (data as ReportAccountCreate)?.ProfileUdf , 
                (object data,string? value) => { if (data is ReportAccountCreate datad) { datad.ProfileUdf = value; }})  /* 2 */ , 
            new GuiBoundPropertyString ("ServiceUdf", "Service fingerprint", (object data) => (data as ReportAccountCreate)?.ServiceUdf , 
                (object data,string? value) => { if (data is ReportAccountCreate datad) { datad.ServiceUdf = value; }})  /* 3 */ 
            ]);

    ///<inheritdoc/>
    public object?[] GetValues() => new [] { 
        ServiceName,
        LocalName,
        ServiceAddress,
        ProfileUdf,
        ServiceUdf};
    }


/// <summary>
/// Return parameters for result ReportAccount 
/// </summary>
public partial record ReportAccount : _ReportAccount {
    }


/// <summary>
/// Callback parameters for result ReportAccount 
/// </summary>
public partial record _ReportAccount : IResult {

    ///<inheritdoc/>
    public string Message => "Connection to account {0} is active.";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("ReportAccount");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Report;

    ///<summary></summary> 
    public virtual string? ServiceName { get; set;} 

    ///<summary></summary> 
    public virtual string? LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string? ServiceCallsign { get; set;} 

    ///<summary></summary> 
    public virtual string? ServiceAddress { get; set;} 

    ///<summary></summary> 
    public virtual string? ProfileUdf { get; set;} 

    ///<summary></summary> 
    public virtual string? ServiceUdf { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is ReportAccount,
        () => new ReportAccount(),
        [ 
            new GuiBoundPropertyString ("LocalName", "Local", (object data) => (data as ReportAccount)?.LocalName , 
                (object data,string? value) => { if (data is ReportAccount datad) { datad.LocalName = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("ServiceCallsign", "Callsign", (object data) => (data as ReportAccount)?.ServiceCallsign , 
                (object data,string? value) => { if (data is ReportAccount datad) { datad.ServiceCallsign = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("ServiceAddress", "DNS", (object data) => (data as ReportAccount)?.ServiceAddress , 
                (object data,string? value) => { if (data is ReportAccount datad) { datad.ServiceAddress = value; }})  /* 2 */ , 
            new GuiBoundPropertyString ("ProfileUdf", "Profile fingerprint", (object data) => (data as ReportAccount)?.ProfileUdf , 
                (object data,string? value) => { if (data is ReportAccount datad) { datad.ProfileUdf = value; }})  /* 3 */ , 
            new GuiBoundPropertyString ("ServiceUdf", "Service fingerprint", (object data) => (data as ReportAccount)?.ServiceUdf , 
                (object data,string? value) => { if (data is ReportAccount datad) { datad.ServiceUdf = value; }})  /* 4 */ 
            ]);

    ///<inheritdoc/>
    public object?[] GetValues() => new [] { 
        ServiceName,
        LocalName,
        ServiceCallsign,
        ServiceAddress,
        ProfileUdf,
        ServiceUdf};
    }


/// <summary>
/// Return parameters for result ReportPending 
/// </summary>
public partial record ReportPending : _ReportPending {
    }


/// <summary>
/// Callback parameters for result ReportPending 
/// </summary>
public partial record _ReportPending : IResult {

    ///<inheritdoc/>
    public string Message => "Connection to account {0} is pending.";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("ReportPending");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Report;

    ///<summary></summary> 
    public virtual string? ServiceName { get; set;} 

    ///<summary></summary> 
    public virtual string? LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string? ServiceCallsign { get; set;} 

    ///<summary></summary> 
    public virtual string? ServiceAddress { get; set;} 

    ///<summary></summary> 
    public virtual string? ServiceUdf { get; set;} 

    ///<summary></summary> 
    public virtual string? ServiceMessage { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is ReportPending,
        () => new ReportPending(),
        [ 
            new GuiBoundPropertyString ("LocalName", "Local", (object data) => (data as ReportPending)?.LocalName , 
                (object data,string? value) => { if (data is ReportPending datad) { datad.LocalName = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("ServiceCallsign", "Callsign", (object data) => (data as ReportPending)?.ServiceCallsign , 
                (object data,string? value) => { if (data is ReportPending datad) { datad.ServiceCallsign = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("ServiceAddress", "DNS", (object data) => (data as ReportPending)?.ServiceAddress , 
                (object data,string? value) => { if (data is ReportPending datad) { datad.ServiceAddress = value; }})  /* 2 */ , 
            new GuiBoundPropertyString ("ServiceUdf", "Service fingerprint", (object data) => (data as ReportPending)?.ServiceUdf , 
                (object data,string? value) => { if (data is ReportPending datad) { datad.ServiceUdf = value; }})  /* 3 */ , 
            new GuiBoundPropertyString ("ServiceMessage", "Message", (object data) => (data as ReportPending)?.ServiceMessage , 
                (object data,string? value) => { if (data is ReportPending datad) { datad.ServiceMessage = value; }})  /* 4 */ 
            ]);

    ///<inheritdoc/>
    public object?[] GetValues() => new [] { 
        ServiceName,
        LocalName,
        ServiceCallsign,
        ServiceAddress,
        ServiceUdf,
        ServiceMessage};
    }


/// <summary>
/// Return parameters for result ReportShares 
/// </summary>
public partial record ReportShares : _ReportShares {
    }


/// <summary>
/// Callback parameters for result ReportShares 
/// </summary>
public partial record _ReportShares : IResult {

    ///<inheritdoc/>
    public string Message => "Secret shares";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("ReportShares");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Report;

    ///<summary></summary> 
    public virtual string? Share1 { get; set;} 

    ///<summary></summary> 
    public virtual string? Share2 { get; set;} 

    ///<summary></summary> 
    public virtual string? Share3 { get; set;} 

    ///<summary></summary> 
    public virtual string? Share4 { get; set;} 

    ///<summary></summary> 
    public virtual string? Share5 { get; set;} 

    ///<summary></summary> 
    public virtual string? Share6 { get; set;} 

    ///<summary></summary> 
    public virtual string? Share7 { get; set;} 

    ///<summary></summary> 
    public virtual string? Share8 { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is ReportShares,
        () => new ReportShares(),
        [ 
            new GuiBoundPropertyString ("Share1", "Recovery share", (object data) => (data as ReportShares)?.Share1 , 
                (object data,string? value) => { if (data is ReportShares datad) { datad.Share1 = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("Share2", "Recovery share", (object data) => (data as ReportShares)?.Share2 , 
                (object data,string? value) => { if (data is ReportShares datad) { datad.Share2 = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("Share3", "Recovery share", (object data) => (data as ReportShares)?.Share3 , 
                (object data,string? value) => { if (data is ReportShares datad) { datad.Share3 = value; }})  /* 2 */ , 
            new GuiBoundPropertyString ("Share4", "Recovery share", (object data) => (data as ReportShares)?.Share4 , 
                (object data,string? value) => { if (data is ReportShares datad) { datad.Share4 = value; }})  /* 3 */ , 
            new GuiBoundPropertyString ("Share5", "Recovery share", (object data) => (data as ReportShares)?.Share5 , 
                (object data,string? value) => { if (data is ReportShares datad) { datad.Share5 = value; }})  /* 4 */ , 
            new GuiBoundPropertyString ("Share6", "Recovery share", (object data) => (data as ReportShares)?.Share6 , 
                (object data,string? value) => { if (data is ReportShares datad) { datad.Share6 = value; }})  /* 5 */ , 
            new GuiBoundPropertyString ("Share7", "Recovery share", (object data) => (data as ReportShares)?.Share7 , 
                (object data,string? value) => { if (data is ReportShares datad) { datad.Share7 = value; }})  /* 6 */ , 
            new GuiBoundPropertyString ("Share8", "Recovery share", (object data) => (data as ReportShares)?.Share8 , 
                (object data,string? value) => { if (data is ReportShares datad) { datad.Share8 = value; }})  /* 7 */ 
            ]);

    ///<inheritdoc/>
    public object?[] GetValues() => new [] { 
        Share1,
        Share2,
        Share3,
        Share4,
        Share5,
        Share6,
        Share7,
        Share8};
    }


/// <summary>
/// Return parameters for result MessageSentContact 
/// </summary>
public partial record MessageSentContact : _MessageSentContact {
    }


/// <summary>
/// Callback parameters for result MessageSentContact 
/// </summary>
public partial record _MessageSentContact : IResult {

    ///<inheritdoc/>
    public string Message => "Contact Requested";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("MessageSentContact");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Report;

    ///<summary></summary> 
    public virtual string? AccountName { get; set;} 

    ///<summary></summary> 
    public virtual string? Identifier { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is MessageSentContact,
        () => new MessageSentContact(),
        [ 
            new GuiBoundPropertyString ("AccountName", "Account", (object data) => (data as MessageSentContact)?.AccountName , 
                (object data,string? value) => { if (data is MessageSentContact datad) { datad.AccountName = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("Identifier", "Identifier", (object data) => (data as MessageSentContact)?.Identifier , 
                (object data,string? value) => { if (data is MessageSentContact datad) { datad.Identifier = value; }})  /* 1 */ 
            ]);

    ///<inheritdoc/>
    public object?[] GetValues() => new [] { 
        AccountName,
        Identifier};
    }


/// <summary>
/// Return parameters for result MessageSentDevice 
/// </summary>
public partial record MessageSentDevice : _MessageSentDevice {
    }


/// <summary>
/// Callback parameters for result MessageSentDevice 
/// </summary>
public partial record _MessageSentDevice : IResult {

    ///<inheritdoc/>
    public string Message => "Connection Requested";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("MessageSentDevice");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Report;

    ///<summary></summary> 
    public virtual string? AccountName { get; set;} 

    ///<summary></summary> 
    public virtual string? Identifier { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is MessageSentDevice,
        () => new MessageSentDevice(),
        [ 
            new GuiBoundPropertyString ("AccountName", "Account", (object data) => (data as MessageSentDevice)?.AccountName , 
                (object data,string? value) => { if (data is MessageSentDevice datad) { datad.AccountName = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("Identifier", "Identifier", (object data) => (data as MessageSentDevice)?.Identifier , 
                (object data,string? value) => { if (data is MessageSentDevice datad) { datad.Identifier = value; }})  /* 1 */ 
            ]);

    ///<inheritdoc/>
    public object?[] GetValues() => new [] { 
        AccountName,
        Identifier};
    }


/// <summary>
/// Return parameters for result BeginCommunication 
/// </summary>
public partial record BeginCommunication : _BeginCommunication {
    }


/// <summary>
/// Callback parameters for result BeginCommunication 
/// </summary>
public partial record _BeginCommunication : IResult {

    ///<inheritdoc/>
    public string Message => "TBS Dialog to implement commuinication interaction";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("BeginCommunication");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Report;


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is BeginCommunication,
        () => new BeginCommunication(),
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object?[] GetValues() => Array.Empty<object>();

    }



#endregion
#region // Failure Results


/// <summary>
/// Return parameters for failure result HttpRequestFail 
/// </summary>
public partial record HttpRequestFail : _HttpRequestFail {
    }


/// <summary>
/// Callback parameters for failure result HttpRequestFail 
/// </summary>
public partial record _HttpRequestFail : IFail {

    ///<inheritdoc/>
    public string Message => "The Mesh service did not respond";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("HttpRequestFail");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Error;


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is HttpRequestFail,
        () => new HttpRequestFail(),
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object?[] GetValues() => Array.Empty<object>();


    }




/// <summary>
/// Return parameters for failure result ServiceNotFound 
/// </summary>
public partial record ServiceNotFound : _ServiceNotFound {
    }


/// <summary>
/// Callback parameters for failure result ServiceNotFound 
/// </summary>
public partial record _ServiceNotFound : IFail {

    ///<inheritdoc/>
    public string Message => "The service {0} could not be found";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("ServiceNotFound");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Error;

    ///<summary></summary> 
    public virtual string? ServiceName { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is ServiceNotFound,
        () => new ServiceNotFound(),
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object?[] GetValues() => new [] { 
        ServiceName};

    }




/// <summary>
/// Return parameters for failure result ServiceRefused 
/// </summary>
public partial record ServiceRefused : _ServiceRefused {
    }


/// <summary>
/// Callback parameters for failure result ServiceRefused 
/// </summary>
public partial record _ServiceRefused : IFail {

    ///<inheritdoc/>
    public string Message => "The service refused the request";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("ServiceRefused");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Error;


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is ServiceRefused,
        () => new ServiceRefused(),
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object?[] GetValues() => Array.Empty<object>();


    }




/// <summary>
/// Return parameters for failure result HostNotFound 
/// </summary>
public partial record HostNotFound : _HostNotFound {
    }


/// <summary>
/// Callback parameters for failure result HostNotFound 
/// </summary>
public partial record _HostNotFound : IFail {

    ///<inheritdoc/>
    public string Message => "No host could not be reached for service {0}";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("HostNotFound");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Error;

    ///<summary></summary> 
    public virtual string? ServiceName { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is HostNotFound,
        () => new HostNotFound(),
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object?[] GetValues() => new [] { 
        ServiceName};

    }




/// <summary>
/// Return parameters for failure result InvalidHostCredential 
/// </summary>
public partial record InvalidHostCredential : _InvalidHostCredential {
    }


/// <summary>
/// Callback parameters for failure result InvalidHostCredential 
/// </summary>
public partial record _InvalidHostCredential : IFail {

    ///<inheritdoc/>
    public string Message => "The host presented an invalid credential";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("InvalidHostCredential");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Error;


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is InvalidHostCredential,
        () => new InvalidHostCredential(),
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object?[] GetValues() => Array.Empty<object>();


    }




/// <summary>
/// Return parameters for failure result CredentialRefused 
/// </summary>
public partial record CredentialRefused : _CredentialRefused {
    }


/// <summary>
/// Callback parameters for failure result CredentialRefused 
/// </summary>
public partial record _CredentialRefused : IFail {

    ///<inheritdoc/>
    public string Message => "The host refused service on account of an invalid credential";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("CredentialRefused");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Error;


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is CredentialRefused,
        () => new CredentialRefused(),
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object?[] GetValues() => Array.Empty<object>();


    }




/// <summary>
/// Return parameters for failure result DeviceRefused 
/// </summary>
public partial record DeviceRefused : _DeviceRefused {
    }


/// <summary>
/// Callback parameters for failure result DeviceRefused 
/// </summary>
public partial record _DeviceRefused : IFail {

    ///<inheritdoc/>
    public string Message => "This device is no longer authorized to access this account";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("DeviceRefused");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Error;


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is DeviceRefused,
        () => new DeviceRefused(),
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object?[] GetValues() => Array.Empty<object>();


    }




/// <summary>
/// Return parameters for failure result FileWriteError 
/// </summary>
public partial record FileWriteError : _FileWriteError {
    }


/// <summary>
/// Callback parameters for failure result FileWriteError 
/// </summary>
public partial record _FileWriteError : IFail {

    ///<inheritdoc/>
    public string Message => "Could not write file {0}";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("FileWriteError");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Error;

    ///<summary></summary> 
    public virtual string? Filename { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is FileWriteError,
        () => new FileWriteError(),
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object?[] GetValues() => new [] { 
        Filename};

    }




/// <summary>
/// Return parameters for failure result FileReadError 
/// </summary>
public partial record FileReadError : _FileReadError {
    }


/// <summary>
/// Callback parameters for failure result FileReadError 
/// </summary>
public partial record _FileReadError : IFail {

    ///<inheritdoc/>
    public string Message => "Could not read file {0}";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("FileReadError");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Error;

    ///<summary></summary> 
    public virtual string? Filename { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is FileReadError,
        () => new FileReadError(),
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object?[] GetValues() => new [] { 
        Filename};

    }




/// <summary>
/// Return parameters for failure result AccountProfileInvalid 
/// </summary>
public partial record AccountProfileInvalid : _AccountProfileInvalid {
    }


/// <summary>
/// Callback parameters for failure result AccountProfileInvalid 
/// </summary>
public partial record _AccountProfileInvalid : IFail {

    ///<inheritdoc/>
    public string Message => "Account profile file is invalid";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("AccountProfileInvalid");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Error;


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is AccountProfileInvalid,
        () => new AccountProfileInvalid(),
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object?[] GetValues() => Array.Empty<object>();


    }




/// <summary>
/// Return parameters for failure result DeviceProfileInvalid 
/// </summary>
public partial record DeviceProfileInvalid : _DeviceProfileInvalid {
    }


/// <summary>
/// Callback parameters for failure result DeviceProfileInvalid 
/// </summary>
public partial record _DeviceProfileInvalid : IFail {

    ///<inheritdoc/>
    public string Message => "Device profile file is invalid";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("DeviceProfileInvalid");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Error;


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is DeviceProfileInvalid,
        () => new DeviceProfileInvalid(),
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object?[] GetValues() => Array.Empty<object>();


    }




/// <summary>
/// Return parameters for failure result ActivationKeyNotFound 
/// </summary>
public partial record ActivationKeyNotFound : _ActivationKeyNotFound {
    }


/// <summary>
/// Callback parameters for failure result ActivationKeyNotFound 
/// </summary>
public partial record _ActivationKeyNotFound : IFail {

    ///<inheritdoc/>
    public string Message => "The activation key for the profile {0} could not be found";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("ActivationKeyNotFound");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Error;

    ///<summary></summary> 
    public virtual string? ProfileName { get; set;} 

    ///<summary></summary> 
    public virtual string? LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string? ProfileUdf { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is ActivationKeyNotFound,
        () => new ActivationKeyNotFound(),
        [ 
            new GuiBoundPropertyString ("LocalName", "Local", (object data) => (data as ActivationKeyNotFound)?.LocalName , 
                (object data,string? value) => { if (data is ActivationKeyNotFound datad) { datad.LocalName = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("ProfileUdf", "Profile fingerprint", (object data) => (data as ActivationKeyNotFound)?.ProfileUdf , 
                (object data,string? value) => { if (data is ActivationKeyNotFound datad) { datad.ProfileUdf = value; }})  /* 1 */ 
            ]);

    ///<inheritdoc/>
    public object?[] GetValues() => new [] { 
        ProfileName,
        LocalName,
        ProfileUdf};

    }




/// <summary>
/// Return parameters for failure result NotAuthorizedCatalog 
/// </summary>
public partial record NotAuthorizedCatalog : _NotAuthorizedCatalog {
    }


/// <summary>
/// Callback parameters for failure result NotAuthorizedCatalog 
/// </summary>
public partial record _NotAuthorizedCatalog : IFail {

    ///<inheritdoc/>
    public string Message => "This device is not authorized to access the {0} catalog";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("NotAuthorizedCatalog");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Error;

    ///<summary></summary> 
    public virtual string? CatalogName { get; set;} 

    ///<summary></summary> 
    public virtual string? LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string? ProfileUdf { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is NotAuthorizedCatalog,
        () => new NotAuthorizedCatalog(),
        [ 
            new GuiBoundPropertyString ("CatalogName", "Catalog", (object data) => (data as NotAuthorizedCatalog)?.CatalogName , 
                (object data,string? value) => { if (data is NotAuthorizedCatalog datad) { datad.CatalogName = value; }})  /* 0 */ , 
            new GuiBoundPropertyString ("LocalName", "Profile", (object data) => (data as NotAuthorizedCatalog)?.LocalName , 
                (object data,string? value) => { if (data is NotAuthorizedCatalog datad) { datad.LocalName = value; }})  /* 1 */ , 
            new GuiBoundPropertyString ("ProfileUdf", "Profile fingerprint", (object data) => (data as NotAuthorizedCatalog)?.ProfileUdf , 
                (object data,string? value) => { if (data is NotAuthorizedCatalog datad) { datad.ProfileUdf = value; }})  /* 2 */ 
            ]);

    ///<inheritdoc/>
    public object?[] GetValues() => new [] { 
        CatalogName,
        LocalName,
        ProfileUdf};

    }




/// <summary>
/// Return parameters for failure result NotAuthorizedAdministration 
/// </summary>
public partial record NotAuthorizedAdministration : _NotAuthorizedAdministration {
    }


/// <summary>
/// Callback parameters for failure result NotAuthorizedAdministration 
/// </summary>
public partial record _NotAuthorizedAdministration : IFail {

    ///<inheritdoc/>
    public string Message => "This device is not authorized to perform administrative requests";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("NotAuthorizedAdministration");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Error;


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is NotAuthorizedAdministration,
        () => new NotAuthorizedAdministration(),
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object?[] GetValues() => Array.Empty<object>();


    }




/// <summary>
/// Return parameters for failure result NotAuthorizedFCatalog 
/// </summary>
public partial record NotAuthorizedFCatalog : _NotAuthorizedFCatalog {
    }


/// <summary>
/// Callback parameters for failure result NotAuthorizedFCatalog 
/// </summary>
public partial record _NotAuthorizedFCatalog : IFail {

    ///<inheritdoc/>
    public string Message => "This device is not authorized to access the {0} catalog";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("NotAuthorizedFCatalog");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Error;


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is NotAuthorizedFCatalog,
        () => new NotAuthorizedFCatalog(),
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object?[] GetValues() => Array.Empty<object>();


    }




/// <summary>
/// Return parameters for failure result CounterpartyApproval 
/// </summary>
public partial record CounterpartyApproval : _CounterpartyApproval {
    }


/// <summary>
/// Callback parameters for failure result CounterpartyApproval 
/// </summary>
public partial record _CounterpartyApproval : IFail {

    ///<inheritdoc/>
    public string Message => "Request requires counterparty confirmation";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("CounterpartyApproval");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Error;


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is CounterpartyApproval,
        () => new CounterpartyApproval(),
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object?[] GetValues() => Array.Empty<object>();


    }




/// <summary>
/// Return parameters for failure result SystemExeption 
/// </summary>
public partial record SystemExeption : _SystemExeption {
    }


/// <summary>
/// Callback parameters for failure result SystemExeption 
/// </summary>
public partial record _SystemExeption : IFail {

    ///<inheritdoc/>
    public string Message => "Application failure";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("SystemExeption");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Error;


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is SystemExeption,
        () => new SystemExeption(),
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object?[] GetValues() => Array.Empty<object>();


    }




/// <summary>
/// Return parameters for failure result NotYetImplemented 
/// </summary>
public partial record NotYetImplemented : _NotYetImplemented {
    }


/// <summary>
/// Callback parameters for failure result NotYetImplemented 
/// </summary>
public partial record _NotYetImplemented : IFail {

    ///<inheritdoc/>
    public string Message => "This feature is not yet implemented";

    ///<inheritdoc/>
    public ResourceId ResourceId => resourceId;
    static readonly ResourceId resourceId = new ("NotYetImplemented");

    ///<summary>The return result.</summary> 
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Error;


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBindingSingle BaseBinding  { get; } = new (
        (object test) => test is NotYetImplemented,
        () => new NotYetImplemented(),
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object?[] GetValues() => Array.Empty<object>();


    }





#endregion
#region // Gui classes

/// <summary>
/// Defines the graphical user interface.
/// </summary>
public partial class EverythingMaui :  _EverythingMaui {



    
    }


/// <summary>
/// Defines the graphical user interface.
/// </summary>
public class _EverythingMaui : Gui {

    ///<summary></summary> 
    public virtual bool StateDefault => true;

    ///<summary></summary> 
    public virtual bool StateAlways => true;

    ///<inheritdoc/> 
    public override List<GuiDialog> Dialogs { get; }

    ///<inheritdoc/> 
    public override List<GuiSection> Sections { get; }




























































    ///<inheritdoc/> 
    public override Dictionary<string, GuiAction>Actions { get; }

    ///<inheritdoc/> 
    public override Dictionary<string, GuiAction> Selections { get; }

    ///<inheritdoc/> 
    public override List<GuiResult> Results { get; }

    ///<inheritdoc/> 
   public override IEnumerable<GuiDataAction>? GetDataActions(IDataActions data) => null;

	///<inheritdoc/>

	public override List<GuiImage> Icons => icons;
	readonly List<GuiImage> icons = new () {  
		new GuiImage ("account_group") , 
		new GuiImage ("application_callsign") , 
		new GuiImage ("application_developer") , 
		new GuiImage ("application_group") , 
		new GuiImage ("application_openpgp") , 
		new GuiImage ("application_pkix") , 
		new GuiImage ("application_ssh") , 
		new GuiImage ("applications") , 
		new GuiImage ("bookmark") , 
		new GuiImage ("brand_facebook") , 
		new GuiImage ("brand_facebook_messenger") , 
		new GuiImage ("brand_facetime") , 
		new GuiImage ("brand_github") , 
		new GuiImage ("brand_linkedin") , 
		new GuiImage ("brand_medium") , 
		new GuiImage ("brand_signal") , 
		new GuiImage ("brand_skype") , 
		new GuiImage ("brand_telegram") , 
		new GuiImage ("brand_twitter") , 
		new GuiImage ("brand_whatsapp") , 
		new GuiImage ("brand_wordpress") , 
		new GuiImage ("calendar") , 
		new GuiImage ("chat") , 
		new GuiImage ("circle_check") , 
		new GuiImage ("circle_cross") , 
		new GuiImage ("circle_question") , 
		new GuiImage ("confirm") , 
		new GuiImage ("connect") , 
		new GuiImage ("contact") , 
		new GuiImage ("contacts") , 
		new GuiImage ("credentials") , 
		new GuiImage ("device_administrator") , 
		new GuiImage ("device_console") , 
		new GuiImage ("device_desktop") , 
		new GuiImage ("device_headphones") , 
		new GuiImage ("device_keyboard") , 
		new GuiImage ("device_laptop") , 
		new GuiImage ("device_mobile") , 
		new GuiImage ("device_plug") , 
		new GuiImage ("device_server") , 
		new GuiImage ("device_tablet") , 
		new GuiImage ("device_tv") , 
		new GuiImage ("devices") , 
		new GuiImage ("documents") , 
		new GuiImage ("ethernet") , 
		new GuiImage ("feeds") , 
		new GuiImage ("file_excel") , 
		new GuiImage ("file_image") , 
		new GuiImage ("file_pdf") , 
		new GuiImage ("file_powerpoint") , 
		new GuiImage ("file_word") , 
		new GuiImage ("file_zipper") , 
		new GuiImage ("git") , 
		new GuiImage ("group member") , 
		new GuiImage ("groups") , 
		new GuiImage ("location_pin") , 
		new GuiImage ("mail") , 
		new GuiImage ("message") , 
		new GuiImage ("messages") , 
		new GuiImage ("new") , 
		new GuiImage ("passkey") , 
		new GuiImage ("password") , 
		new GuiImage ("platform_android") , 
		new GuiImage ("platform_ios") , 
		new GuiImage ("platform_linux") , 
		new GuiImage ("platform_macos") , 
		new GuiImage ("platform_rasberry_pi") , 
		new GuiImage ("platform_windows") , 
		new GuiImage ("plug") , 
		new GuiImage ("plus") , 
		new GuiImage ("present_qr") , 
		new GuiImage ("protocol_icon") , 
		new GuiImage ("recover") , 
		new GuiImage ("recover_account") , 
		new GuiImage ("services") , 
		new GuiImage ("settings") , 
		new GuiImage ("share_nodes_solid") , 
		new GuiImage ("signature") , 
		new GuiImage ("task") , 
		new GuiImage ("tasks") , 
		new GuiImage ("test_service") , 
		new GuiImage ("triangle_exclamation_solid") , 
		new GuiImage ("user") , 
		new GuiImage ("vault") , 
		new GuiImage ("video") , 
		new GuiImage ("voice") , 
		new GuiImage ("watch") , 
		new GuiImage ("wifi_router") , 
		new GuiImage ("wireless") 
		};


#region // Sections

    ///<summary>Section SectionAccountSection.</summary> 
	public GuiSection SectionAccountSection { get; } = new (
        "AccountSection", "Account", "user", 
        _AccountSection.BaseBinding, false);

    ///<summary>Section SectionMessageSection.</summary> 
	public GuiSection SectionMessageSection { get; } = new (
        "MessageSection", "Messages", "messages", 
        _MessageSection.BaseBinding, true);

    ///<summary>Section SectionContactSection.</summary> 
	public GuiSection SectionContactSection { get; } = new (
        "ContactSection", "Contacts", "contacts", 
        _ContactSection.BaseBinding, true);

    ///<summary>Section SectionDocumentSection.</summary> 
	public GuiSection SectionDocumentSection { get; } = new (
        "DocumentSection", "Documents", "Documents", 
        _DocumentSection.BaseBinding, false);

    ///<summary>Section SectionFeedSection.</summary> 
	public GuiSection SectionFeedSection { get; } = new (
        "FeedSection", "Feeds", "feeds", 
        _FeedSection.BaseBinding, false);

    ///<summary>Section SectionGroupSection.</summary> 
	public GuiSection SectionGroupSection { get; } = new (
        "GroupSection", "Groups", "groups", 
        _GroupSection.BaseBinding, false);

    ///<summary>Section SectionCredentialSection.</summary> 
	public GuiSection SectionCredentialSection { get; } = new (
        "CredentialSection", "Credentials", "credentials", 
        _CredentialSection.BaseBinding, false);

    ///<summary>Section SectionTaskSection.</summary> 
	public GuiSection SectionTaskSection { get; } = new (
        "TaskSection", "Tasks", "tasks", 
        _TaskSection.BaseBinding, false);

    ///<summary>Section SectionCalendarSection.</summary> 
	public GuiSection SectionCalendarSection { get; } = new (
        "CalendarSection", "Calendar", "calendar", 
        _CalendarSection.BaseBinding, false);

    ///<summary>Section SectionBookmarkSection.</summary> 
	public GuiSection SectionBookmarkSection { get; } = new (
        "BookmarkSection", "Bookmark", "bookmark", 
        _BookmarkSection.BaseBinding, false);

    ///<summary>Section SectionApplicationSection.</summary> 
	public GuiSection SectionApplicationSection { get; } = new (
        "ApplicationSection", "Applications", "applications", 
        _ApplicationSection.BaseBinding, false);

    ///<summary>Section SectionDeviceSection.</summary> 
	public GuiSection SectionDeviceSection { get; } = new (
        "DeviceSection", "Devices", "devices", 
        _DeviceSection.BaseBinding, false);

    ///<summary>Section SectionServiceSection.</summary> 
	public GuiSection SectionServiceSection { get; } = new (
        "ServiceSection", "Services", "Services", 
        _ServiceSection.BaseBinding, false);

    ///<summary>Section SectionSettingSection.</summary> 
	public GuiSection SectionSettingSection { get; } = new (
        "SettingSection", "Settings", "settings", 
        _SettingSection.BaseBinding, false);
#endregion
#region // Actions

    ///<summary>Action ActionTestService.</summary> 
	public GuiAction ActionTestService { get; } = new (
        "TestService", "Test Service", "test_service", 
        _TestService.BaseBinding, () => new TestService(),
        IsConfirmation: true);

    ///<summary>Action ActionAccountCreate.</summary> 
	public GuiAction ActionAccountCreate { get; } = new (
        "AccountCreate", "Create Mesh Account", "new", 
        _AccountCreate.BaseBinding, () => new AccountCreate(),
        IsConfirmation: true);

    ///<summary>Action ActionAccountRequestConnect.</summary> 
	public GuiAction ActionAccountRequestConnect { get; } = new (
        "AccountRequestConnect", "Connect by Address", "connect", 
        _AccountRequestConnect.BaseBinding, () => new AccountRequestConnect(),
        IsConfirmation: true);

    ///<summary>Action ActionAccountRecover.</summary> 
	public GuiAction ActionAccountRecover { get; } = new (
        "AccountRecover", "Recover Mesh Account", "recover_account", 
        _AccountRecover.BaseBinding, () => new AccountRecover(),
        IsConfirmation: true);

    ///<summary>Action ActionAccountDelete.</summary> 
	public GuiAction ActionAccountDelete { get; } = new (
        "AccountDelete", "Delete Account", "test_service", 
        _AccountDelete.BaseBinding, () => new AccountDelete(),
        IsConfirmation: false);

    ///<summary>Action ActionAccountSwitch.</summary> 
	public GuiAction ActionAccountSwitch { get; } = new (
        "AccountSwitch", "Change Account", "test_service", 
        _AccountSwitch.BaseBinding, () => new AccountSwitch(),
        IsConfirmation: true);

    ///<summary>Action ActionAccountGenerateRecovery.</summary> 
	public GuiAction ActionAccountGenerateRecovery { get; } = new (
        "AccountGenerateRecovery", "Create recovery", "share_nodes_solid", 
        _AccountGenerateRecovery.BaseBinding, () => new AccountGenerateRecovery(),
        IsConfirmation: true);

    ///<summary>Action ActionRequestConfirmation.</summary> 
	public GuiAction ActionRequestConfirmation { get; } = new (
        "RequestConfirmation", "Confirmation Request", "confirm", 
        _RequestConfirmation.BaseBinding, () => new RequestConfirmation(),
        IsConfirmation: true);

    ///<summary>Action ActionCreateMail.</summary> 
	public GuiAction ActionCreateMail { get; } = new (
        "CreateMail", "New Mail", "mail", 
        _CreateMail.BaseBinding, () => new CreateMail(),
        IsConfirmation: true);

    ///<summary>Action ActionCreateChat.</summary> 
	public GuiAction ActionCreateChat { get; } = new (
        "CreateChat", "New Chat", "chat", 
        _CreateChat.BaseBinding, () => new CreateChat(),
        IsConfirmation: false);

    ///<summary>Action ActionStartVoice.</summary> 
	public GuiAction ActionStartVoice { get; } = new (
        "StartVoice", "New Voice", "voice", 
        _StartVoice.BaseBinding, () => new StartVoice(),
        IsConfirmation: false);

    ///<summary>Action ActionStartVideo.</summary> 
	public GuiAction ActionStartVideo { get; } = new (
        "StartVideo", "New Video", "video", 
        _StartVideo.BaseBinding, () => new StartVideo(),
        IsConfirmation: false);

    ///<summary>Action ActionAddPerson.</summary> 
	public GuiAction ActionAddPerson { get; } = new (
        "AddPerson", "Add Person", "contact", 
        _AddPerson.BaseBinding, () => new AddPerson(),
        IsConfirmation: false);

    ///<summary>Action ActionAddOrganization.</summary> 
	public GuiAction ActionAddOrganization { get; } = new (
        "AddOrganization", "Add Organization", "contact", 
        _AddOrganization.BaseBinding, () => new AddOrganization(),
        IsConfirmation: false);

    ///<summary>Action ActionAddLocation.</summary> 
	public GuiAction ActionAddLocation { get; } = new (
        "AddLocation", "Add Location", "contact", 
        _AddLocation.BaseBinding, () => new AddLocation(),
        IsConfirmation: false);

    ///<summary>Action ActionRequestContact.</summary> 
	public GuiAction ActionRequestContact { get; } = new (
        "RequestContact", "Request Contact", "contact", 
        _RequestContact.BaseBinding, () => new RequestContact(),
        IsConfirmation: true);

    ///<summary>Action ActionQrContact.</summary> 
	public GuiAction ActionQrContact { get; } = new (
        "QrContact", "Connect by QR", "contact", 
        _QrContact.BaseBinding, () => new QrContact(),
        IsConfirmation: true);

    ///<summary>Action ActionContactAddNetwork.</summary> 
	public GuiAction ActionContactAddNetwork { get; } = new (
        "ContactAddNetwork", "Add Network", "contacts", 
        _ContactAddNetwork.BaseBinding, () => new ContactAddNetwork(),
        IsConfirmation: true, setContext: (object data, IBindable value) => { if (data is ContactAddNetwork datad) {datad.Context=(value as BoundContactPerson)!;}});

    ///<summary>Action ActionContactAddCredential.</summary> 
	public GuiAction ActionContactAddCredential { get; } = new (
        "ContactAddCredential", "Add Credential", "contacts", 
        _ContactAddCredential.BaseBinding, () => new ContactAddCredential(),
        IsConfirmation: true, setContext: (object data, IBindable value) => { if (data is ContactAddCredential datad) {datad.Context=(value as BoundContactPerson)!;}});

    ///<summary>Action ActionContactAddPostal.</summary> 
	public GuiAction ActionContactAddPostal { get; } = new (
        "ContactAddPostal", "Add Postal", "contacts", 
        _ContactAddPostal.BaseBinding, () => new ContactAddPostal(),
        IsConfirmation: true, setContext: (object data, IBindable value) => { if (data is ContactAddPostal datad) {datad.Context=(value as BoundContactPerson)!;}});

    ///<summary>Action ActionUploadDocument.</summary> 
	public GuiAction ActionUploadDocument { get; } = new (
        "UploadDocument", "Connect by QR", "contact", 
        _UploadDocument.BaseBinding, () => new UploadDocument(),
        IsConfirmation: true);

    ///<summary>Action ActionAddFeed.</summary> 
	public GuiAction ActionAddFeed { get; } = new (
        "AddFeed", "Add Feed", "account_group", 
        _AddFeed.BaseBinding, () => new AddFeed(),
        IsConfirmation: true);

    ///<summary>Action ActionAddGroup.</summary> 
	public GuiAction ActionAddGroup { get; } = new (
        "AddGroup", "Create group", "account_group", 
        _AddGroup.BaseBinding, () => new AddGroup(),
        IsConfirmation: true);

    ///<summary>Action ActionGroupInvite.</summary> 
	public GuiAction ActionGroupInvite { get; } = new (
        "GroupInvite", "Invite member", "account_group", 
        _GroupInvite.BaseBinding, () => new GroupInvite(),
        IsConfirmation: true);

    ///<summary>Action ActionAddPassword.</summary> 
	public GuiAction ActionAddPassword { get; } = new (
        "AddPassword", "Add password", "credentials", 
        _AddPassword.BaseBinding, () => new AddPassword(),
        IsConfirmation: true);

    ///<summary>Action ActionAddPasskey.</summary> 
	public GuiAction ActionAddPasskey { get; } = new (
        "AddPasskey", "Add Passkey", "credentials", 
        _AddPasskey.BaseBinding, () => new AddPasskey(),
        IsConfirmation: false);

    ///<summary>Action ActionAddTask.</summary> 
	public GuiAction ActionAddTask { get; } = new (
        "AddTask", "Create password", "credentials", 
        _AddTask.BaseBinding, () => new AddTask(),
        IsConfirmation: true);

    ///<summary>Action ActionAddBookmark.</summary> 
	public GuiAction ActionAddBookmark { get; } = new (
        "AddBookmark", "Add Bookmark", "account_group", 
        _AddBookmark.BaseBinding, () => new AddBookmark(),
        IsConfirmation: true);

    ///<summary>Action ActionAddMailAccount.</summary> 
	public GuiAction ActionAddMailAccount { get; } = new (
        "AddMailAccount", "Add email account", "mail", 
        _AddMailAccount.BaseBinding, () => new AddMailAccount(),
        IsConfirmation: true);

    ///<summary>Action ActionAddSshAccount.</summary> 
	public GuiAction ActionAddSshAccount { get; } = new (
        "AddSshAccount", "Create SSH credential", "credentials", 
        _AddSshAccount.BaseBinding, () => new AddSshAccount(),
        IsConfirmation: true);

    ///<summary>Action ActionAddGitAccount.</summary> 
	public GuiAction ActionAddGitAccount { get; } = new (
        "AddGitAccount", "Create git credentials", "git", 
        _AddGitAccount.BaseBinding, () => new AddGitAccount(),
        IsConfirmation: true);

    ///<summary>Action ActionAddCodeSigningKey.</summary> 
	public GuiAction ActionAddCodeSigningKey { get; } = new (
        "AddCodeSigningKey", "Add Code Signing Key", "signature", 
        _AddCodeSigningKey.BaseBinding, () => new AddCodeSigningKey(),
        IsConfirmation: true);

    ///<summary>Action ActionDeviceConnectQR.</summary> 
	public GuiAction ActionDeviceConnectQR { get; } = new (
        "DeviceConnectQR", "Present QR", "present_qr", 
        _DeviceConnectQR.BaseBinding, () => new DeviceConnectQR(),
        IsConfirmation: true);

    ///<summary>Action ActionAccountGetPin.</summary> 
	public GuiAction ActionAccountGetPin { get; } = new (
        "AccountGetPin", "Create connection PIN", "recover", 
        _AccountGetPin.BaseBinding, () => new AccountGetPin(),
        IsConfirmation: true);

#endregion
#region // Actions

    ///<summary>Selection SelectionAccountSelect.</summary> 
	public GuiAction SelectionAccountSelect { get; } = new (
        "AccountSelect", "Switch", "circle_check", _AccountSelect.BaseBinding, () => new AccountSelect(), IsSelect:true);

    ///<summary>Selection SelectionActionAccept.</summary> 
	public GuiAction SelectionActionAccept { get; } = new (
        "ActionAccept", "Accept", "circle_check", _ActionAccept.BaseBinding, () => new ActionAccept(), IsSelect:true);

    ///<summary>Selection SelectionActionReject.</summary> 
	public GuiAction SelectionActionReject { get; } = new (
        "ActionReject", "Reject", "circle_cross", _ActionReject.BaseBinding, () => new ActionReject(), IsSelect:true);

    ///<summary>Selection SelectionDocumentUpdate.</summary> 
	public GuiAction SelectionDocumentUpdate { get; } = new (
        "DocumentUpdate", "Update", "circle_cross", _DocumentUpdate.BaseBinding, () => new DocumentUpdate(), IsSelect:true);

    ///<summary>Selection SelectionDocumentExport.</summary> 
	public GuiAction SelectionDocumentExport { get; } = new (
        "DocumentExport", "Export", "circle_cross", _DocumentExport.BaseBinding, () => new DocumentExport(), IsSelect:true);

    ///<summary>Selection SelectionDocumentSend.</summary> 
	public GuiAction SelectionDocumentSend { get; } = new (
        "DocumentSend", "Send", "circle_cross", _DocumentSend.BaseBinding, () => new DocumentSend(), IsSelect:true);

    ///<summary>Selection SelectionDocumentDelete.</summary> 
	public GuiAction SelectionDocumentDelete { get; } = new (
        "DocumentDelete", "Delete", "circle_cross", _DocumentDelete.BaseBinding, () => new DocumentDelete(), IsSelect:true);

    ///<summary>Selection SelectionMemberDelete.</summary> 
	public GuiAction SelectionMemberDelete { get; } = new (
        "MemberDelete", "Delete", "circle_cross", _MemberDelete.BaseBinding, () => new MemberDelete(), IsSelect:true);

    ///<summary>Selection SelectionMemberReInvite.</summary> 
	public GuiAction SelectionMemberReInvite { get; } = new (
        "MemberReInvite", "Sesent Invitation", "circle_cross", _MemberReInvite.BaseBinding, () => new MemberReInvite(), IsSelect:true);

    ///<summary>Selection SelectionCredentialUpdate.</summary> 
	public GuiAction SelectionCredentialUpdate { get; } = new (
        "CredentialUpdate", "Update", "circle_cross", _CredentialUpdate.BaseBinding, () => new CredentialUpdate(), IsSelect:true);

    ///<summary>Selection SelectionCredentialDelete.</summary> 
	public GuiAction SelectionCredentialDelete { get; } = new (
        "CredentialDelete", "Delete", "circle_cross", _CredentialDelete.BaseBinding, () => new CredentialDelete(), IsSelect:true);

    ///<summary>Selection SelectionTaskUpdate.</summary> 
	public GuiAction SelectionTaskUpdate { get; } = new (
        "TaskUpdate", "Update", "circle_cross", _TaskUpdate.BaseBinding, () => new TaskUpdate(), IsSelect:true);

    ///<summary>Selection SelectionTaskDelete.</summary> 
	public GuiAction SelectionTaskDelete { get; } = new (
        "TaskDelete", "Delete", "circle_cross", _TaskDelete.BaseBinding, () => new TaskDelete(), IsSelect:true);

    ///<summary>Selection SelectionBookmarkUpdate.</summary> 
	public GuiAction SelectionBookmarkUpdate { get; } = new (
        "BookmarkUpdate", "Update", "circle_cross", _BookmarkUpdate.BaseBinding, () => new BookmarkUpdate(), IsSelect:true);

    ///<summary>Selection SelectionBookmarkDelete.</summary> 
	public GuiAction SelectionBookmarkDelete { get; } = new (
        "BookmarkDelete", "Delete", "circle_cross", _BookmarkDelete.BaseBinding, () => new BookmarkDelete(), IsSelect:true);

    ///<summary>Selection SelectionApplicationUpdate.</summary> 
	public GuiAction SelectionApplicationUpdate { get; } = new (
        "ApplicationUpdate", "Update", "circle_cross", _ApplicationUpdate.BaseBinding, () => new ApplicationUpdate(), IsSelect:true);

    ///<summary>Selection SelectionApplicationDelete.</summary> 
	public GuiAction SelectionApplicationDelete { get; } = new (
        "ApplicationDelete", "Delete", "circle_cross", _ApplicationDelete.BaseBinding, () => new ApplicationDelete(), IsSelect:true);

    ///<summary>Selection SelectionDeviceUpdate.</summary> 
	public GuiAction SelectionDeviceUpdate { get; } = new (
        "DeviceUpdate", "Update", "circle_cross", _DeviceUpdate.BaseBinding, () => new DeviceUpdate(), IsSelect:true);

    ///<summary>Selection SelectionDeviceDelete.</summary> 
	public GuiAction SelectionDeviceDelete { get; } = new (
        "DeviceDelete", "Delete", "circle_cross", _DeviceDelete.BaseBinding, () => new DeviceDelete(), IsSelect:true);

#endregion
#region // Dialogs

    ///<summary>Dialog DialogBoundAccount.</summary> 
	public GuiDialog DialogBoundAccount { get; } = new (
        "BoundAccount", "Account", "contacts", _BoundAccount.BaseBinding, () => new BoundAccount()) {
                IsBoundType = (object data) => data is BoundAccount
                };

    ///<summary>Dialog DialogBoundMessage.</summary> 
	public GuiDialog DialogBoundMessage { get; } = new (
        "BoundMessage", "Message", "contacts", _BoundMessage.BaseBinding, () => new BoundMessage()) {
                IsBoundType = (object data) => data is BoundMessage
                };

    ///<summary>Dialog DialogBoundMailMail.</summary> 
	public GuiDialog DialogBoundMailMail { get; } = new (
        "BoundMailMail", "Mail", "messages", _BoundMailMail.BaseBinding, () => new BoundMailMail()) {
                IsBoundType = (object data) => data is BoundMailMail
                };

    ///<summary>Dialog DialogBoundMessageActionRequest.</summary> 
	public GuiDialog DialogBoundMessageActionRequest { get; } = new (
        "BoundMessageActionRequest", "Message", "contacts", _BoundMessageActionRequest.BaseBinding, () => new BoundMessageActionRequest()) {
                IsBoundType = (object data) => data is BoundMessageActionRequest
                };

    ///<summary>Dialog DialogBoundMessageConfirmationRequest.</summary> 
	public GuiDialog DialogBoundMessageConfirmationRequest { get; } = new (
        "BoundMessageConfirmationRequest", "Mail", "circle_question", _BoundMessageConfirmationRequest.BaseBinding, () => new BoundMessageConfirmationRequest()) {
                IsBoundType = (object data) => data is BoundMessageConfirmationRequest
                };

    ///<summary>Dialog DialogBoundMessageConfirmationResponse.</summary> 
	public GuiDialog DialogBoundMessageConfirmationResponse { get; } = new (
        "BoundMessageConfirmationResponse", "Mail", "circle_check", _BoundMessageConfirmationResponse.BaseBinding, () => new BoundMessageConfirmationResponse()) {
                IsBoundType = (object data) => data is BoundMessageConfirmationResponse
                };

    ///<summary>Dialog DialogBoundMessageContactRequest.</summary> 
	public GuiDialog DialogBoundMessageContactRequest { get; } = new (
        "BoundMessageContactRequest", "Mail", "contact", _BoundMessageContactRequest.BaseBinding, () => new BoundMessageContactRequest()) {
                IsBoundType = (object data) => data is BoundMessageContactRequest
                };

    ///<summary>Dialog DialogBoundMessageAcknowledgeConnection.</summary> 
	public GuiDialog DialogBoundMessageAcknowledgeConnection { get; } = new (
        "BoundMessageAcknowledgeConnection", "Mail", "connect", _BoundMessageAcknowledgeConnection.BaseBinding, () => new BoundMessageAcknowledgeConnection()) {
                IsBoundType = (object data) => data is BoundMessageAcknowledgeConnection
                };

    ///<summary>Dialog DialogBoundMessageConnectionRequest.</summary> 
	public GuiDialog DialogBoundMessageConnectionRequest { get; } = new (
        "BoundMessageConnectionRequest", "Mail", "connect", _BoundMessageConnectionRequest.BaseBinding, () => new BoundMessageConnectionRequest()) {
                IsBoundType = (object data) => data is BoundMessageConnectionRequest
                };

    ///<summary>Dialog DialogBoundMessageGroupInvitation.</summary> 
	public GuiDialog DialogBoundMessageGroupInvitation { get; } = new (
        "BoundMessageGroupInvitation", "Mail", "groups", _BoundMessageGroupInvitation.BaseBinding, () => new BoundMessageGroupInvitation()) {
                IsBoundType = (object data) => data is BoundMessageGroupInvitation
                };

    ///<summary>Dialog DialogBoundMessageTaskRequest.</summary> 
	public GuiDialog DialogBoundMessageTaskRequest { get; } = new (
        "BoundMessageTaskRequest", "Mail", "task", _BoundMessageTaskRequest.BaseBinding, () => new BoundMessageTaskRequest()) {
                IsBoundType = (object data) => data is BoundMessageTaskRequest
                };

    ///<summary>Dialog DialogBoundContact.</summary> 
	public GuiDialog DialogBoundContact { get; } = new (
        "BoundContact", "Contact", "contacts", _BoundContact.BaseBinding, () => new BoundContact()) {
                IsBoundType = (object data) => data is BoundContact
                };

    ///<summary>Dialog DialogBoundContactPerson.</summary> 
	public GuiDialog DialogBoundContactPerson { get; } = new (
        "BoundContactPerson", "Person", "contacts", _BoundContactPerson.BaseBinding, () => new BoundContactPerson()) {
                IsBoundType = (object data) => data is BoundContactPerson
                };

    ///<summary>Dialog DialogContactNetworkIdentifier.</summary> 
	public GuiDialog DialogContactNetworkIdentifier { get; } = new (
        "ContactNetworkIdentifier", "Network", "protocol_icon", _ContactNetworkIdentifier.BaseBinding, () => new ContactNetworkIdentifier()) {
                IsBoundType = (object data) => data is ContactNetworkIdentifier
                };

    ///<summary>Dialog DialogBoundContactBusiness.</summary> 
	public GuiDialog DialogBoundContactBusiness { get; } = new (
        "BoundContactBusiness", "Organization", "contacts", _BoundContactBusiness.BaseBinding, () => new BoundContactBusiness()) {
                IsBoundType = (object data) => data is BoundContactBusiness
                };

    ///<summary>Dialog DialogBoundContactPlace.</summary> 
	public GuiDialog DialogBoundContactPlace { get; } = new (
        "BoundContactPlace", "Place", "contacts", _BoundContactPlace.BaseBinding, () => new BoundContactPlace()) {
                IsBoundType = (object data) => data is BoundContactPlace
                };

    ///<summary>Dialog DialogContactNetworkAddress.</summary> 
	public GuiDialog DialogContactNetworkAddress { get; } = new (
        "ContactNetworkAddress", "Network", "protocol_icon", _ContactNetworkAddress.BaseBinding, () => new ContactNetworkAddress()) {
                IsBoundType = (object data) => data is ContactNetworkAddress
                };

    ///<summary>Dialog DialogContactNetworkCredential.</summary> 
	public GuiDialog DialogContactNetworkCredential { get; } = new (
        "ContactNetworkCredential", "Network", "protocol_icon", _ContactNetworkCredential.BaseBinding, () => new ContactNetworkCredential()) {
                IsBoundType = (object data) => data is ContactNetworkCredential
                };

    ///<summary>Dialog DialogContactPhysicalAddress.</summary> 
	public GuiDialog DialogContactPhysicalAddress { get; } = new (
        "ContactPhysicalAddress", "Place", "location_pin", _ContactPhysicalAddress.BaseBinding, () => new ContactPhysicalAddress()) {
                IsBoundType = (object data) => data is ContactPhysicalAddress
                };

    ///<summary>Dialog DialogBoundDocument.</summary> 
	public GuiDialog DialogBoundDocument { get; } = new (
        "BoundDocument", "Document", "documents", _BoundDocument.BaseBinding, () => new BoundDocument()) {
                IsBoundType = (object data) => data is BoundDocument
                };

    ///<summary>Dialog DialogBoundGroup.</summary> 
	public GuiDialog DialogBoundGroup { get; } = new (
        "BoundGroup", "Group", "application_group", _BoundGroup.BaseBinding, () => new BoundGroup()) {
                IsBoundType = (object data) => data is BoundGroup
                };

    ///<summary>Dialog DialogBoundGroupMember.</summary> 
	public GuiDialog DialogBoundGroupMember { get; } = new (
        "BoundGroupMember", "Member", "Group Member", _BoundGroupMember.BaseBinding, () => new BoundGroupMember()) {
                IsBoundType = (object data) => data is BoundGroupMember
                };

    ///<summary>Dialog DialogBoundCredential.</summary> 
	public GuiDialog DialogBoundCredential { get; } = new (
        "BoundCredential", "Passkey", "credentials", _BoundCredential.BaseBinding, () => new BoundCredential()) {
                IsBoundType = (object data) => data is BoundCredential
                };

    ///<summary>Dialog DialogBoundPassword.</summary> 
	public GuiDialog DialogBoundPassword { get; } = new (
        "BoundPassword", "Password", "password", _BoundPassword.BaseBinding, () => new BoundPassword()) {
                IsBoundType = (object data) => data is BoundPassword
                };

    ///<summary>Dialog DialogBoundPasskey.</summary> 
	public GuiDialog DialogBoundPasskey { get; } = new (
        "BoundPasskey", "Passkey", "passkey", _BoundPasskey.BaseBinding, () => new BoundPasskey()) {
                IsBoundType = (object data) => data is BoundPasskey
                };

    ///<summary>Dialog DialogBoundTask.</summary> 
	public GuiDialog DialogBoundTask { get; } = new (
        "BoundTask", "Task", "task", _BoundTask.BaseBinding, () => new BoundTask()) {
                IsBoundType = (object data) => data is BoundTask
                };

    ///<summary>Dialog DialogBoundAppointment.</summary> 
	public GuiDialog DialogBoundAppointment { get; } = new (
        "BoundAppointment", "Appointment", "task", _BoundAppointment.BaseBinding, () => new BoundAppointment()) {
                IsBoundType = (object data) => data is BoundAppointment
                };

    ///<summary>Dialog DialogBoundBookmark.</summary> 
	public GuiDialog DialogBoundBookmark { get; } = new (
        "BoundBookmark", "Bookmark", "bookmark", _BoundBookmark.BaseBinding, () => new BoundBookmark()) {
                IsBoundType = (object data) => data is BoundBookmark
                };

    ///<summary>Dialog DialogBoundFeed.</summary> 
	public GuiDialog DialogBoundFeed { get; } = new (
        "BoundFeed", "Feed", "feeds", _BoundFeed.BaseBinding, () => new BoundFeed()) {
                IsBoundType = (object data) => data is BoundFeed
                };

    ///<summary>Dialog DialogBoundApplication.</summary> 
	public GuiDialog DialogBoundApplication { get; } = new (
        "BoundApplication", "Message", "applications", _BoundApplication.BaseBinding, () => new BoundApplication()) {
                IsBoundType = (object data) => data is BoundApplication
                };

    ///<summary>Dialog DialogBoundApplicationMail.</summary> 
	public GuiDialog DialogBoundApplicationMail { get; } = new (
        "BoundApplicationMail", "Message", "mail", _BoundApplicationMail.BaseBinding, () => new BoundApplicationMail()) {
                IsBoundType = (object data) => data is BoundApplicationMail
                };

    ///<summary>Dialog DialogBoundApplicationSsh.</summary> 
	public GuiDialog DialogBoundApplicationSsh { get; } = new (
        "BoundApplicationSsh", "Message", "application_ssh", _BoundApplicationSsh.BaseBinding, () => new BoundApplicationSsh()) {
                IsBoundType = (object data) => data is BoundApplicationSsh
                };

    ///<summary>Dialog DialogBoundApplicationOpenPgp.</summary> 
	public GuiDialog DialogBoundApplicationOpenPgp { get; } = new (
        "BoundApplicationOpenPgp", "Message", "application_openpgp", _BoundApplicationOpenPgp.BaseBinding, () => new BoundApplicationOpenPgp()) {
                IsBoundType = (object data) => data is BoundApplicationOpenPgp
                };

    ///<summary>Dialog DialogBoundApplicationDeveloper.</summary> 
	public GuiDialog DialogBoundApplicationDeveloper { get; } = new (
        "BoundApplicationDeveloper", "Message", "application_developer", _BoundApplicationDeveloper.BaseBinding, () => new BoundApplicationDeveloper()) {
                IsBoundType = (object data) => data is BoundApplicationDeveloper
                };

    ///<summary>Dialog DialogBoundApplicationPkix.</summary> 
	public GuiDialog DialogBoundApplicationPkix { get; } = new (
        "BoundApplicationPkix", "Message", "application_pkix", _BoundApplicationPkix.BaseBinding, () => new BoundApplicationPkix()) {
                IsBoundType = (object data) => data is BoundApplicationPkix
                };

    ///<summary>Dialog DialogBoundApplicationGroup.</summary> 
	public GuiDialog DialogBoundApplicationGroup { get; } = new (
        "BoundApplicationGroup", "Message", "application_group", _BoundApplicationGroup.BaseBinding, () => new BoundApplicationGroup()) {
                IsBoundType = (object data) => data is BoundApplicationGroup
                };

    ///<summary>Dialog DialogBoundApplicationCallSign.</summary> 
	public GuiDialog DialogBoundApplicationCallSign { get; } = new (
        "BoundApplicationCallSign", "Message", "application_callsign", _BoundApplicationCallSign.BaseBinding, () => new BoundApplicationCallSign()) {
                IsBoundType = (object data) => data is BoundApplicationCallSign
                };

    ///<summary>Dialog DialogBoundDevice.</summary> 
	public GuiDialog DialogBoundDevice { get; } = new (
        "BoundDevice", "Message", "plug", _BoundDevice.BaseBinding, () => new BoundDevice()) {
                IsBoundType = (object data) => data is BoundDevice
                };

#endregion
#region // Results

    ///<summary>Result ResultSuccessGroupCreate.</summary> 
	public GuiResult ResultSuccessGroupCreate { get; } = new (_SuccessGroupCreate.BaseBinding);

    ///<summary>Result ResultReportPinValue.</summary> 
	public GuiResult ResultReportPinValue { get; } = new (_ReportPinValue.BaseBinding);

    ///<summary>Result ResultReportHost.</summary> 
	public GuiResult ResultReportHost { get; } = new (_ReportHost.BaseBinding);

    ///<summary>Result ResultReportAccountCreate.</summary> 
	public GuiResult ResultReportAccountCreate { get; } = new (_ReportAccountCreate.BaseBinding);

    ///<summary>Result ResultReportAccount.</summary> 
	public GuiResult ResultReportAccount { get; } = new (_ReportAccount.BaseBinding);

    ///<summary>Result ResultReportPending.</summary> 
	public GuiResult ResultReportPending { get; } = new (_ReportPending.BaseBinding);

    ///<summary>Result ResultReportShares.</summary> 
	public GuiResult ResultReportShares { get; } = new (_ReportShares.BaseBinding);

    ///<summary>Result ResultMessageSentContact.</summary> 
	public GuiResult ResultMessageSentContact { get; } = new (_MessageSentContact.BaseBinding);

    ///<summary>Result ResultMessageSentDevice.</summary> 
	public GuiResult ResultMessageSentDevice { get; } = new (_MessageSentDevice.BaseBinding);

    ///<summary>Result ResultBeginCommunication.</summary> 
	public GuiResult ResultBeginCommunication { get; } = new (_BeginCommunication.BaseBinding);
	
    ///<summary>Dictionary resolving exception name to factory method.</summary> 
    public Dictionary<string, Func<IResult>> ExceptionDirectory =
        new() { 
                { typeof(HttpRequestException)?.FullName!, () => new HttpRequestFail() } , 
                { typeof(ServerOperationFailed)?.FullName!, () => new ServiceRefused() }             };
#endregion
#region // Constructors
    /// <summary>
    /// Default constructor returning an instance.
    /// </summary>
    public _EverythingMaui () {


	    SectionAccountSection.Gui = this;
	    SectionAccountSection.Active = () => StateAlways;
	    SectionAccountSection.Entries = [
			new GuiButton ("AccountCreate", ActionAccountCreate),
			new GuiButton ("AccountRequestConnect", ActionAccountRequestConnect),
			new GuiButton ("TestService", ActionTestService),
			new GuiButton ("AccountRecover", ActionAccountRecover),
			new GuiButton ("AccountGenerateRecovery", ActionAccountGenerateRecovery),
			new GuiButton ("AccountSwitch", ActionAccountSwitch)];

	    SectionMessageSection.Gui = this;
	    SectionMessageSection.Active = () => StateDefault;
	    SectionMessageSection.Entries = [
			new GuiButton ("RequestContact", ActionRequestContact),
			new GuiButton ("RequestConfirmation", ActionRequestConfirmation),
			new GuiButton ("CreateMail", ActionCreateMail),
			new GuiButton ("CreateChat", ActionCreateChat),
			new GuiButton ("StartVoice", ActionStartVoice),
			new GuiButton ("StartVideo", ActionStartVideo)];

	    SectionContactSection.Gui = this;
	    SectionContactSection.Active = () => StateDefault;
	    SectionContactSection.Entries = [
			new GuiButton ("AddPerson", ActionAddPerson),
			new GuiButton ("AddOrganization", ActionAddOrganization),
			new GuiButton ("AddLocation", ActionAddLocation),
			new GuiButton ("QrContact", ActionQrContact),
			new GuiButton ("RequestContact", ActionRequestContact)];

	    SectionDocumentSection.Gui = this;
	    SectionDocumentSection.Active = () => StateDefault;
	    SectionDocumentSection.Entries = [
			new GuiButton ("UploadDocument", ActionUploadDocument)];

	    SectionFeedSection.Gui = this;
	    SectionFeedSection.Active = () => StateDefault;
	    SectionFeedSection.Entries = [];

	    SectionGroupSection.Gui = this;
	    SectionGroupSection.Active = () => StateDefault;
	    SectionGroupSection.Entries = [
			new GuiButton ("AddGroup", ActionAddGroup)];

	    SectionCredentialSection.Gui = this;
	    SectionCredentialSection.Active = () => StateDefault;
	    SectionCredentialSection.Entries = [
			new GuiButton ("AddPassword", ActionAddPassword),
			new GuiButton ("AddPasskey", ActionAddPasskey)];

	    SectionTaskSection.Gui = this;
	    SectionTaskSection.Active = () => StateDefault;
	    SectionTaskSection.Entries = [
			new GuiButton ("AddTask", ActionAddTask)];

	    SectionCalendarSection.Gui = this;
	    SectionCalendarSection.Active = () => StateDefault;
	    SectionCalendarSection.Entries = [
			new GuiButton ("AddTask", ActionAddTask)];

	    SectionBookmarkSection.Gui = this;
	    SectionBookmarkSection.Active = () => StateDefault;
	    SectionBookmarkSection.Entries = [
			new GuiButton ("AddBookmark", ActionAddBookmark)];

	    SectionApplicationSection.Gui = this;
	    SectionApplicationSection.Active = () => StateDefault;
	    SectionApplicationSection.Entries = [
			new GuiButton ("AddMailAccount", ActionAddMailAccount),
			new GuiButton ("AddSshAccount", ActionAddSshAccount),
			new GuiButton ("AddGitAccount", ActionAddGitAccount),
			new GuiButton ("AddCodeSigningKey", ActionAddCodeSigningKey)];

	    SectionDeviceSection.Gui = this;
	    SectionDeviceSection.Active = () => StateDefault;
	    SectionDeviceSection.Entries = [
			new GuiButton ("DeviceConnectQR", ActionDeviceConnectQR),
			new GuiButton ("AccountGetPin", ActionAccountGetPin)];

	    SectionServiceSection.Gui = this;
	    SectionServiceSection.Active = () => StateDefault;
	    SectionServiceSection.Entries = [];

	    SectionSettingSection.Gui = this;
	    SectionSettingSection.Active = () => StateDefault;
	    SectionSettingSection.Entries = [];


#endregion
#region // Initialize Sections
        Sections = new List<GuiSection> () {  
		    SectionAccountSection, 
		    SectionMessageSection, 
		    SectionContactSection, 
		    SectionDocumentSection, 
		    SectionFeedSection, 
		    SectionGroupSection, 
		    SectionCredentialSection, 
		    SectionTaskSection, 
		    SectionCalendarSection, 
		    SectionBookmarkSection, 
		    SectionApplicationSection, 
		    SectionDeviceSection, 
		    SectionServiceSection, 
		    SectionSettingSection
            };

#endregion
#region // Initialize Actions
        ActionTestService.Callback = (x) => {
            if (x is TestService xx) {
                return TestService (xx); 
                }
            throw new NYI();
            } ;

        ActionAccountCreate.Callback = (x) => {
            if (x is AccountCreate xx) {
                return AccountCreate (xx); 
                }
            throw new NYI();
            } ;

        ActionAccountRequestConnect.Callback = (x) => {
            if (x is AccountRequestConnect xx) {
                return AccountRequestConnect (xx); 
                }
            throw new NYI();
            } ;

        ActionAccountRecover.Callback = (x) => {
            if (x is AccountRecover xx) {
                return AccountRecover (xx); 
                }
            throw new NYI();
            } ;

        ActionAccountDelete.Callback = (x) => {
            if (x is AccountDelete xx) {
                return AccountDelete (xx); 
                }
            throw new NYI();
            } ;

        ActionAccountSwitch.Callback = (x) => {
            if (x is AccountSwitch xx) {
                return AccountSwitch (xx); 
                }
            throw new NYI();
            } ;

        ActionAccountGenerateRecovery.Callback = (x) => {
            if (x is AccountGenerateRecovery xx) {
                return AccountGenerateRecovery (xx); 
                }
            throw new NYI();
            } ;

        ActionRequestConfirmation.Callback = (x) => {
            if (x is RequestConfirmation xx) {
                return RequestConfirmation (xx); 
                }
            throw new NYI();
            } ;

        ActionCreateMail.Callback = (x) => {
            if (x is CreateMail xx) {
                return CreateMail (xx); 
                }
            throw new NYI();
            } ;

        ActionCreateChat.Callback = (x) => {
            if (x is CreateChat xx) {
                return CreateChat (xx); 
                }
            throw new NYI();
            } ;

        ActionStartVoice.Callback = (x) => {
            if (x is StartVoice xx) {
                return StartVoice (xx); 
                }
            throw new NYI();
            } ;

        ActionStartVideo.Callback = (x) => {
            if (x is StartVideo xx) {
                return StartVideo (xx); 
                }
            throw new NYI();
            } ;

        ActionAddPerson.Callback = (x) => {
            if (x is AddPerson xx) {
                return AddPerson (xx); 
                }
            throw new NYI();
            } ;

        ActionAddOrganization.Callback = (x) => {
            if (x is AddOrganization xx) {
                return AddOrganization (xx); 
                }
            throw new NYI();
            } ;

        ActionAddLocation.Callback = (x) => {
            if (x is AddLocation xx) {
                return AddLocation (xx); 
                }
            throw new NYI();
            } ;

        ActionRequestContact.Callback = (x) => {
            if (x is RequestContact xx) {
                return RequestContact (xx); 
                }
            throw new NYI();
            } ;

        ActionQrContact.Callback = (x) => {
            if (x is QrContact xx) {
                return QrContact (xx); 
                }
            throw new NYI();
            } ;

        ActionContactAddNetwork.Callback = (x) => {
            if (x is ContactAddNetwork xx) {
                return ContactAddNetwork (xx); 
                }
            throw new NYI();
            } ;

        ActionContactAddCredential.Callback = (x) => {
            if (x is ContactAddCredential xx) {
                return ContactAddCredential (xx); 
                }
            throw new NYI();
            } ;

        ActionContactAddPostal.Callback = (x) => {
            if (x is ContactAddPostal xx) {
                return ContactAddPostal (xx); 
                }
            throw new NYI();
            } ;

        ActionUploadDocument.Callback = (x) => {
            if (x is UploadDocument xx) {
                return UploadDocument (xx); 
                }
            throw new NYI();
            } ;

        ActionAddFeed.Callback = (x) => {
            if (x is AddFeed xx) {
                return AddFeed (xx); 
                }
            throw new NYI();
            } ;

        ActionAddGroup.Callback = (x) => {
            if (x is AddGroup xx) {
                return AddGroup (xx); 
                }
            throw new NYI();
            } ;

        ActionGroupInvite.Callback = (x) => {
            if (x is GroupInvite xx) {
                return GroupInvite (xx); 
                }
            throw new NYI();
            } ;

        ActionAddPassword.Callback = (x) => {
            if (x is AddPassword xx) {
                return AddPassword (xx); 
                }
            throw new NYI();
            } ;

        ActionAddPasskey.Callback = (x) => {
            if (x is AddPasskey xx) {
                return AddPasskey (xx); 
                }
            throw new NYI();
            } ;

        ActionAddTask.Callback = (x) => {
            if (x is AddTask xx) {
                return AddTask (xx); 
                }
            throw new NYI();
            } ;

        ActionAddBookmark.Callback = (x) => {
            if (x is AddBookmark xx) {
                return AddBookmark (xx); 
                }
            throw new NYI();
            } ;

        ActionAddMailAccount.Callback = (x) => {
            if (x is AddMailAccount xx) {
                return AddMailAccount (xx); 
                }
            throw new NYI();
            } ;

        ActionAddSshAccount.Callback = (x) => {
            if (x is AddSshAccount xx) {
                return AddSshAccount (xx); 
                }
            throw new NYI();
            } ;

        ActionAddGitAccount.Callback = (x) => {
            if (x is AddGitAccount xx) {
                return AddGitAccount (xx); 
                }
            throw new NYI();
            } ;

        ActionAddCodeSigningKey.Callback = (x) => {
            if (x is AddCodeSigningKey xx) {
                return AddCodeSigningKey (xx); 
                }
            throw new NYI();
            } ;

        ActionDeviceConnectQR.Callback = (x) => {
            if (x is DeviceConnectQR xx) {
                return DeviceConnectQR (xx); 
                }
            throw new NYI();
            } ;

        ActionAccountGetPin.Callback = (x) => {
            if (x is AccountGetPin xx) {
                return AccountGetPin (xx); 
                }
            throw new NYI();
            } ;


        Actions = new Dictionary<string,GuiAction>() {  
		    {"TestService", ActionTestService}, 
		    {"AccountCreate", ActionAccountCreate}, 
		    {"AccountRequestConnect", ActionAccountRequestConnect}, 
		    {"AccountRecover", ActionAccountRecover}, 
		    {"AccountDelete", ActionAccountDelete}, 
		    {"AccountSwitch", ActionAccountSwitch}, 
		    {"AccountGenerateRecovery", ActionAccountGenerateRecovery}, 
		    {"RequestConfirmation", ActionRequestConfirmation}, 
		    {"CreateMail", ActionCreateMail}, 
		    {"CreateChat", ActionCreateChat}, 
		    {"StartVoice", ActionStartVoice}, 
		    {"StartVideo", ActionStartVideo}, 
		    {"AddPerson", ActionAddPerson}, 
		    {"AddOrganization", ActionAddOrganization}, 
		    {"AddLocation", ActionAddLocation}, 
		    {"RequestContact", ActionRequestContact}, 
		    {"QrContact", ActionQrContact}, 
		    {"ContactAddNetwork", ActionContactAddNetwork}, 
		    {"ContactAddCredential", ActionContactAddCredential}, 
		    {"ContactAddPostal", ActionContactAddPostal}, 
		    {"UploadDocument", ActionUploadDocument}, 
		    {"AddFeed", ActionAddFeed}, 
		    {"AddGroup", ActionAddGroup}, 
		    {"GroupInvite", ActionGroupInvite}, 
		    {"AddPassword", ActionAddPassword}, 
		    {"AddPasskey", ActionAddPasskey}, 
		    {"AddTask", ActionAddTask}, 
		    {"AddBookmark", ActionAddBookmark}, 
		    {"AddMailAccount", ActionAddMailAccount}, 
		    {"AddSshAccount", ActionAddSshAccount}, 
		    {"AddGitAccount", ActionAddGitAccount}, 
		    {"AddCodeSigningKey", ActionAddCodeSigningKey}, 
		    {"DeviceConnectQR", ActionDeviceConnectQR}, 
		    {"AccountGetPin", ActionAccountGetPin}
		    };

#endregion

#region // Initialize Selections
        SelectionAccountSelect.Callback = (x) => {
            if (x is BoundAccount xx) {
                return AccountSelect (xx); 
                }
            throw new NYI();
            } ;

        SelectionActionAccept.Callback = (x) => {
            if (x is BoundMessageActionRequest xx) {
                return ActionAccept (xx); 
                }
            throw new NYI();
            } ;

        SelectionActionReject.Callback = (x) => {
            if (x is BoundMessageActionRequest xx) {
                return ActionReject (xx); 
                }
            throw new NYI();
            } ;

        SelectionDocumentUpdate.Callback = (x) => {
            if (x is BoundDocument xx) {
                return DocumentUpdate (xx); 
                }
            throw new NYI();
            } ;

        SelectionDocumentExport.Callback = (x) => {
            if (x is BoundDocument xx) {
                return DocumentExport (xx); 
                }
            throw new NYI();
            } ;

        SelectionDocumentSend.Callback = (x) => {
            if (x is BoundDocument xx) {
                return DocumentSend (xx); 
                }
            throw new NYI();
            } ;

        SelectionDocumentDelete.Callback = (x) => {
            if (x is BoundDocument xx) {
                return DocumentDelete (xx); 
                }
            throw new NYI();
            } ;

        SelectionMemberDelete.Callback = (x) => {
            if (x is BoundGroupMember xx) {
                return MemberDelete (xx); 
                }
            throw new NYI();
            } ;

        SelectionMemberReInvite.Callback = (x) => {
            if (x is BoundGroupMember xx) {
                return MemberReInvite (xx); 
                }
            throw new NYI();
            } ;

        SelectionCredentialUpdate.Callback = (x) => {
            if (x is BoundCredential xx) {
                return CredentialUpdate (xx); 
                }
            throw new NYI();
            } ;

        SelectionCredentialDelete.Callback = (x) => {
            if (x is BoundCredential xx) {
                return CredentialDelete (xx); 
                }
            throw new NYI();
            } ;

        SelectionTaskUpdate.Callback = (x) => {
            if (x is BoundTask xx) {
                return TaskUpdate (xx); 
                }
            throw new NYI();
            } ;

        SelectionTaskDelete.Callback = (x) => {
            if (x is BoundTask xx) {
                return TaskDelete (xx); 
                }
            throw new NYI();
            } ;

        SelectionBookmarkUpdate.Callback = (x) => {
            if (x is BoundBookmark xx) {
                return BookmarkUpdate (xx); 
                }
            throw new NYI();
            } ;

        SelectionBookmarkDelete.Callback = (x) => {
            if (x is BoundBookmark xx) {
                return BookmarkDelete (xx); 
                }
            throw new NYI();
            } ;

        SelectionApplicationUpdate.Callback = (x) => {
            if (x is BoundApplication xx) {
                return ApplicationUpdate (xx); 
                }
            throw new NYI();
            } ;

        SelectionApplicationDelete.Callback = (x) => {
            if (x is BoundApplication xx) {
                return ApplicationDelete (xx); 
                }
            throw new NYI();
            } ;

        SelectionDeviceUpdate.Callback = (x) => {
            if (x is BoundDevice xx) {
                return DeviceUpdate (xx); 
                }
            throw new NYI();
            } ;

        SelectionDeviceDelete.Callback = (x) => {
            if (x is BoundDevice xx) {
                return DeviceDelete (xx); 
                }
            throw new NYI();
            } ;


        Selections = new Dictionary<string,GuiAction>() {  
		    {"AccountSelect", SelectionAccountSelect}, 
		    {"ActionAccept", SelectionActionAccept}, 
		    {"ActionReject", SelectionActionReject}, 
		    {"DocumentUpdate", SelectionDocumentUpdate}, 
		    {"DocumentExport", SelectionDocumentExport}, 
		    {"DocumentSend", SelectionDocumentSend}, 
		    {"DocumentDelete", SelectionDocumentDelete}, 
		    {"MemberDelete", SelectionMemberDelete}, 
		    {"MemberReInvite", SelectionMemberReInvite}, 
		    {"CredentialUpdate", SelectionCredentialUpdate}, 
		    {"CredentialDelete", SelectionCredentialDelete}, 
		    {"TaskUpdate", SelectionTaskUpdate}, 
		    {"TaskDelete", SelectionTaskDelete}, 
		    {"BookmarkUpdate", SelectionBookmarkUpdate}, 
		    {"BookmarkDelete", SelectionBookmarkDelete}, 
		    {"ApplicationUpdate", SelectionApplicationUpdate}, 
		    {"ApplicationDelete", SelectionApplicationDelete}, 
		    {"DeviceUpdate", SelectionDeviceUpdate}, 
		    {"DeviceDelete", SelectionDeviceDelete}
		    };

#endregion
#region // Initialize Dialogs

	    DialogBoundAccount.Entries = [];

	    DialogBoundMessage.Entries = [];

	    DialogBoundMailMail.Entries = [];

	    DialogBoundMessageActionRequest.Entries = [];

	    DialogBoundMessageConfirmationRequest.Entries = [];

	    DialogBoundMessageConfirmationResponse.Entries = [];

	    DialogBoundMessageContactRequest.Entries = [];

	    DialogBoundMessageAcknowledgeConnection.Entries = [];

	    DialogBoundMessageConnectionRequest.Entries = [];

	    DialogBoundMessageGroupInvitation.Entries = [];

	    DialogBoundMessageTaskRequest.Entries = [];

	    DialogBoundContact.Entries = [];

	    DialogBoundContactPerson.Entries = [
			new GuiButton ("ContactAddNetwork", ActionContactAddNetwork),
			new GuiButton ("ContactAddCredential", ActionContactAddCredential),
			new GuiButton ("ContactAddPostal", ActionContactAddPostal)];

	    DialogContactNetworkIdentifier.Entries = [];

	    DialogBoundContactBusiness.Entries = [];

	    DialogBoundContactPlace.Entries = [];

	    DialogContactNetworkAddress.Entries = [];

	    DialogContactNetworkCredential.Entries = [];

	    DialogContactPhysicalAddress.Entries = [];

	    DialogBoundDocument.Entries = [];

	    DialogBoundGroup.Entries = [
			new GuiButton ("GroupInvite", ActionGroupInvite)];

	    DialogBoundGroupMember.Entries = [];

	    DialogBoundCredential.Entries = [];

	    DialogBoundPassword.Entries = [];

	    DialogBoundPasskey.Entries = [];

	    DialogBoundTask.Entries = [];

	    DialogBoundAppointment.Entries = [];

	    DialogBoundBookmark.Entries = [];

	    DialogBoundFeed.Entries = [];

	    DialogBoundApplication.Entries = [];

	    DialogBoundApplicationMail.Entries = [];

	    DialogBoundApplicationSsh.Entries = [];

	    DialogBoundApplicationOpenPgp.Entries = [];

	    DialogBoundApplicationDeveloper.Entries = [];

	    DialogBoundApplicationPkix.Entries = [];

	    DialogBoundApplicationGroup.Entries = [];

	    DialogBoundApplicationCallSign.Entries = [];

	    DialogBoundDevice.Entries = [];


        Dialogs = new List<GuiDialog>() {  
		    DialogBoundAccount, 
		    DialogBoundMessage, 
		    DialogBoundMailMail, 
		    DialogBoundMessageActionRequest, 
		    DialogBoundMessageConfirmationRequest, 
		    DialogBoundMessageConfirmationResponse, 
		    DialogBoundMessageContactRequest, 
		    DialogBoundMessageAcknowledgeConnection, 
		    DialogBoundMessageConnectionRequest, 
		    DialogBoundMessageGroupInvitation, 
		    DialogBoundMessageTaskRequest, 
		    DialogBoundContact, 
		    DialogBoundContactPerson, 
		    DialogContactNetworkIdentifier, 
		    DialogBoundContactBusiness, 
		    DialogBoundContactPlace, 
		    DialogContactNetworkAddress, 
		    DialogContactNetworkCredential, 
		    DialogContactPhysicalAddress, 
		    DialogBoundDocument, 
		    DialogBoundGroup, 
		    DialogBoundGroupMember, 
		    DialogBoundCredential, 
		    DialogBoundPassword, 
		    DialogBoundPasskey, 
		    DialogBoundTask, 
		    DialogBoundAppointment, 
		    DialogBoundBookmark, 
		    DialogBoundFeed, 
		    DialogBoundApplication, 
		    DialogBoundApplicationMail, 
		    DialogBoundApplicationSsh, 
		    DialogBoundApplicationOpenPgp, 
		    DialogBoundApplicationDeveloper, 
		    DialogBoundApplicationPkix, 
		    DialogBoundApplicationGroup, 
		    DialogBoundApplicationCallSign, 
		    DialogBoundDevice
		    };

#endregion
#region // Initialize Results

        Results = new List<GuiResult>() {  
		    ResultSuccessGroupCreate, 
		    ResultReportPinValue, 
		    ResultReportHost, 
		    ResultReportAccountCreate, 
		    ResultReportAccount, 
		    ResultReportPending, 
		    ResultReportShares, 
		    ResultMessageSentContact, 
		    ResultMessageSentDevice, 
		    ResultBeginCommunication
		    };

        }

#endregion
#region // Initialize Actions
    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> TestService (TestService data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AccountCreate (AccountCreate data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AccountRequestConnect (AccountRequestConnect data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AccountRecover (AccountRecover data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AccountDelete (AccountDelete data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AccountSwitch (AccountSwitch data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AccountGenerateRecovery (AccountGenerateRecovery data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> RequestConfirmation (RequestConfirmation data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> CreateMail (CreateMail data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> CreateChat (CreateChat data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> StartVoice (StartVoice data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> StartVideo (StartVideo data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AddPerson (AddPerson data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AddOrganization (AddOrganization data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AddLocation (AddLocation data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> RequestContact (RequestContact data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> QrContact (QrContact data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> ContactAddNetwork (ContactAddNetwork data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> ContactAddCredential (ContactAddCredential data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> ContactAddPostal (ContactAddPostal data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> UploadDocument (UploadDocument data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AddFeed (AddFeed data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AddGroup (AddGroup data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> GroupInvite (GroupInvite data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AddPassword (AddPassword data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AddPasskey (AddPasskey data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AddTask (AddTask data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AddBookmark (AddBookmark data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AddMailAccount (AddMailAccount data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AddSshAccount (AddSshAccount data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AddGitAccount (AddGitAccount data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AddCodeSigningKey (AddCodeSigningKey data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> DeviceConnectQR (DeviceConnectQR data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AccountGetPin (AccountGetPin data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AccountSelect (BoundAccount data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> ActionAccept (BoundMessageActionRequest data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> ActionReject (BoundMessageActionRequest data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> DocumentUpdate (BoundDocument data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> DocumentExport (BoundDocument data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> DocumentSend (BoundDocument data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> DocumentDelete (BoundDocument data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> MemberDelete (BoundGroupMember data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> MemberReInvite (BoundGroupMember data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> CredentialUpdate (BoundCredential data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> CredentialDelete (BoundCredential data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> TaskUpdate (BoundTask data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> TaskDelete (BoundTask data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> BookmarkUpdate (BoundBookmark data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> BookmarkDelete (BoundBookmark data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> ApplicationUpdate (BoundApplication data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> ApplicationDelete (BoundApplication data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> DeviceUpdate (BoundDevice data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> DeviceDelete (BoundDevice data) 
                => throw new NYI();


#endregion
	}

#endregion
