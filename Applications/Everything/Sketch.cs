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
    public virtual string ServiceAddress { get;} 

    ///<summary></summary> 
    public virtual string ProfileUdf { get;} 

    ///<summary></summary> 
    public virtual string LocalAddress { get;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _AccountSection,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _AccountSection).ServiceAddress, null, "ServiceAddress"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountSection).ProfileUdf, null, "ProfileUdf"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountSection).LocalAddress, null, "LocalAddress")

            });

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
    public virtual ISelectCollection ChooseMessage { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _MessageSection,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _MessageSection).ChooseMessage, (object data,ISelectCollection value) => (data as _MessageSection).ChooseMessage = value, "ChooseMessage")

            });

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
    public virtual ISelectCollection ChooseContact { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _ContactSection,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _ContactSection).ChooseContact, (object data,ISelectCollection value) => (data as _ContactSection).ChooseContact = value, "ChooseContact")

            });

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
    public virtual ISelectCollection ChooseDocuments { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _DocumentSection,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _DocumentSection).ChooseDocuments, (object data,ISelectCollection value) => (data as _DocumentSection).ChooseDocuments = value, "ChooseDocuments")

            });

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
    public virtual ISelectCollection ChooseFeed { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _FeedSection,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _FeedSection).ChooseFeed, (object data,ISelectCollection value) => (data as _FeedSection).ChooseFeed = value, "ChooseFeed")

            });

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
    public virtual ISelectCollection ChooseGroup { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _GroupSection,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _GroupSection).ChooseGroup, (object data,ISelectCollection value) => (data as _GroupSection).ChooseGroup = value, "ChooseGroup")

            });

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
    public virtual ISelectCollection ChooseCredential { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _CredentialSection,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _CredentialSection).ChooseCredential, (object data,ISelectCollection value) => (data as _CredentialSection).ChooseCredential = value, "ChooseCredential")

            });

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
    public virtual ISelectCollection ChooseTask { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _TaskSection,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _TaskSection).ChooseTask, (object data,ISelectCollection value) => (data as _TaskSection).ChooseTask = value, "ChooseTask")

            });

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
    public virtual ISelectCollection ChooseAppointment { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _CalendarSection,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _CalendarSection).ChooseAppointment, (object data,ISelectCollection value) => (data as _CalendarSection).ChooseAppointment = value, "ChooseAppointment")

            });

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
    public virtual ISelectCollection ChooseBookmark { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BookmarkSection,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _BookmarkSection).ChooseBookmark, (object data,ISelectCollection value) => (data as _BookmarkSection).ChooseBookmark = value, "ChooseBookmark")

            });

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
    public virtual ISelectCollection ChooseApplication { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _ApplicationSection,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _ApplicationSection).ChooseApplication, (object data,ISelectCollection value) => (data as _ApplicationSection).ChooseApplication = value, "ChooseApplication")

            });

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
    public virtual ISelectCollection ChooseDevice { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _DeviceSection,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _DeviceSection).ChooseDevice, (object data,ISelectCollection value) => (data as _DeviceSection).ChooseDevice = value, "ChooseDevice")

            });

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
    public virtual ISelectCollection ChooseService { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _ServiceSection,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _ServiceSection).ChooseService, (object data,ISelectCollection value) => (data as _ServiceSection).ChooseService = value, "ChooseService")

            });

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


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _SettingSection,
        Array.Empty<GuiBoundProperty>());

    }

/// <summary>
/// Callback parameters for section Appearance 
/// </summary>
public partial class Appearance : _Appearance {
    }

/// <summary>
/// Callback parameters for section Appearance 
/// </summary>
public partial class _Appearance : IBindable {

    ///<summary></summary> 
    public virtual IFieldColor BackgroundColor { get; set;} 

    ///<summary></summary> 
    public virtual IFieldColor HighlightColor { get; set;} 

    ///<summary></summary> 
    public virtual IFieldColor TextColor { get; set;} 

    ///<summary></summary> 
    public virtual IFieldSize TextSize { get; set;} 

    ///<summary></summary> 
    public virtual IFieldSize IconSize { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _Appearance,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyColor ((object data) => (data as _Appearance).BackgroundColor, (object data,IFieldColor value) => (data as _Appearance).BackgroundColor = value, "BackgroundColor"), 
            new GuiBoundPropertyColor ((object data) => (data as _Appearance).HighlightColor, (object data,IFieldColor value) => (data as _Appearance).HighlightColor = value, "HighlightColor"), 
            new GuiBoundPropertyColor ((object data) => (data as _Appearance).TextColor, (object data,IFieldColor value) => (data as _Appearance).TextColor = value, "TextColor"), 
            new GuiBoundPropertySize ((object data) => (data as _Appearance).TextSize, (object data,IFieldSize value) => (data as _Appearance).TextSize = value, "TextSize"), 
            new GuiBoundPropertySize ((object data) => (data as _Appearance).IconSize, (object data,IFieldSize value) => (data as _Appearance).IconSize = value, "IconSize")

            });

    }

#endregion
#region // Dialogs
/// <summary>
/// Callback parameters for dialog BoundAccount 
/// </summary>
public partial class BoundAccount : _BoundAccount {
    /// <summary>Type check verification.</summary>
    public static  Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundAccount 
/// </summary>
public partial class _BoundAccount : IParameter {

    public object Bound { get; set; }


    ///<summary></summary> 
    public virtual string Display { get;} 

    ///<summary></summary> 
    public virtual string Service { get;} 

    ///<summary></summary> 
    public virtual string UDF { get;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundAccount,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _BoundAccount).Display, null, "Display"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundAccount).Service, null, "Service"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundAccount).UDF, null, "UDF")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static  Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundMessage 
/// </summary>
public partial class _BoundMessage : IParameter {

    public object Bound { get; set; }


    ///<summary></summary> 
    public virtual IFieldIcon Type { get;} 

    ///<summary></summary> 
    public virtual string Subject { get; set;} 

    ///<summary></summary> 
    public virtual string TimeSent { get; set;} 

    ///<summary></summary> 
    public virtual string Sender { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundMessage,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyIcon ((object data) => (data as _BoundMessage).Type, null, "Type"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMessage).Subject, (object data,string value) => (data as _BoundMessage).Subject = value, "Subject"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMessage).TimeSent, (object data,string value) => (data as _BoundMessage).TimeSent = value, "TimeSent"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMessage).Sender, (object data,string value) => (data as _BoundMessage).Sender = value, "Sender")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static new Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundMailMail 
/// </summary>
public partial class _BoundMailMail : BoundMessage {


    ///<summary></summary> 
    public virtual string Message { get; set;} 


    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundMailMail,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyIcon ((object data) => (data as _BoundMailMail).Type, null, "Type"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMailMail).Subject, (object data,string value) => (data as _BoundMailMail).Subject = value, "Subject"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMailMail).TimeSent, (object data,string value) => (data as _BoundMailMail).TimeSent = value, "TimeSent"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMailMail).Sender, (object data,string value) => (data as _BoundMailMail).Sender = value, "Sender"), 
            new GuiBoundTextArea ((object data) => (data as _BoundMailMail).Message, (object data,string value) => (data as _BoundMailMail).Message = value, "Message")

            });
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static new Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundMessageConfirmationRequest 
/// </summary>
public partial class _BoundMessageConfirmationRequest : BoundMessage {


    ///<summary></summary> 
    public virtual string RequestMessage { get; set;} 


    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundMessageConfirmationRequest,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyIcon ((object data) => (data as _BoundMessageConfirmationRequest).Type, null, "Type"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMessageConfirmationRequest).Subject, (object data,string value) => (data as _BoundMessageConfirmationRequest).Subject = value, "Subject"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMessageConfirmationRequest).TimeSent, (object data,string value) => (data as _BoundMessageConfirmationRequest).TimeSent = value, "TimeSent"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMessageConfirmationRequest).Sender, (object data,string value) => (data as _BoundMessageConfirmationRequest).Sender = value, "Sender"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMessageConfirmationRequest).RequestMessage, (object data,string value) => (data as _BoundMessageConfirmationRequest).RequestMessage = value, "RequestMessage")

            });
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static new Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundMessageConfirmationResponse 
/// </summary>
public partial class _BoundMessageConfirmationResponse : BoundMessage {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundMessageConfirmationResponse,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyIcon ((object data) => (data as _BoundMessageConfirmationResponse).Type, null, "Type"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMessageConfirmationResponse).Subject, (object data,string value) => (data as _BoundMessageConfirmationResponse).Subject = value, "Subject"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMessageConfirmationResponse).TimeSent, (object data,string value) => (data as _BoundMessageConfirmationResponse).TimeSent = value, "TimeSent"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMessageConfirmationResponse).Sender, (object data,string value) => (data as _BoundMessageConfirmationResponse).Sender = value, "Sender")

            });
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static new Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundMessageContactRequest 
/// </summary>
public partial class _BoundMessageContactRequest : BoundMessage {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundMessageContactRequest,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyIcon ((object data) => (data as _BoundMessageContactRequest).Type, null, "Type"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMessageContactRequest).Subject, (object data,string value) => (data as _BoundMessageContactRequest).Subject = value, "Subject"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMessageContactRequest).TimeSent, (object data,string value) => (data as _BoundMessageContactRequest).TimeSent = value, "TimeSent"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMessageContactRequest).Sender, (object data,string value) => (data as _BoundMessageContactRequest).Sender = value, "Sender")

            });
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static new Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundMessageConnectionRequest 
/// </summary>
public partial class _BoundMessageConnectionRequest : BoundMessage {


    ///<summary></summary> 
    public virtual string RequestMessage { get; set;} 


    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundMessageConnectionRequest,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyIcon ((object data) => (data as _BoundMessageConnectionRequest).Type, null, "Type"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMessageConnectionRequest).Subject, (object data,string value) => (data as _BoundMessageConnectionRequest).Subject = value, "Subject"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMessageConnectionRequest).TimeSent, (object data,string value) => (data as _BoundMessageConnectionRequest).TimeSent = value, "TimeSent"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMessageConnectionRequest).Sender, (object data,string value) => (data as _BoundMessageConnectionRequest).Sender = value, "Sender"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMessageConnectionRequest).RequestMessage, (object data,string value) => (data as _BoundMessageConnectionRequest).RequestMessage = value, "RequestMessage")

            });
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static new Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundMessageGroupInvitation 
/// </summary>
public partial class _BoundMessageGroupInvitation : BoundMessage {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundMessageGroupInvitation,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyIcon ((object data) => (data as _BoundMessageGroupInvitation).Type, null, "Type"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMessageGroupInvitation).Subject, (object data,string value) => (data as _BoundMessageGroupInvitation).Subject = value, "Subject"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMessageGroupInvitation).TimeSent, (object data,string value) => (data as _BoundMessageGroupInvitation).TimeSent = value, "TimeSent"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMessageGroupInvitation).Sender, (object data,string value) => (data as _BoundMessageGroupInvitation).Sender = value, "Sender")

            });
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static new Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundMessageTaskRequest 
/// </summary>
public partial class _BoundMessageTaskRequest : BoundMessage {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundMessageTaskRequest,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyIcon ((object data) => (data as _BoundMessageTaskRequest).Type, null, "Type"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMessageTaskRequest).Subject, (object data,string value) => (data as _BoundMessageTaskRequest).Subject = value, "Subject"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMessageTaskRequest).TimeSent, (object data,string value) => (data as _BoundMessageTaskRequest).TimeSent = value, "TimeSent"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundMessageTaskRequest).Sender, (object data,string value) => (data as _BoundMessageTaskRequest).Sender = value, "Sender")

            });
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public override IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public override IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundDocument 
/// </summary>
public partial class BoundDocument : _BoundDocument {
    /// <summary>Type check verification.</summary>
    public static  Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundDocument 
/// </summary>
public partial class _BoundDocument : IParameter {

    public object Bound { get; set; }


    ///<summary></summary> 
    public virtual IFieldIcon Type { get;} 

    ///<summary></summary> 
    public virtual string FileType { get;} 

    ///<summary></summary> 
    public virtual string Filename { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundDocument,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyIcon ((object data) => (data as _BoundDocument).Type, null, "Type"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundDocument).FileType, null, "FileType"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundDocument).Filename, (object data,string value) => (data as _BoundDocument).Filename = value, "Filename")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static  Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundGroup 
/// </summary>
public partial class _BoundGroup : IParameter {

    public object Bound { get; set; }


    ///<summary></summary> 
    public virtual string Display { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundGroup,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _BoundGroup).Display, (object data,string value) => (data as _BoundGroup).Display = value, "Display")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static  Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundCredential 
/// </summary>
public partial class _BoundCredential : IParameter {

    public object Bound { get; set; }


    ///<summary></summary> 
    public virtual IFieldIcon Type { get;} 

    ///<summary></summary> 
    public virtual string Protocol { get; set;} 

    ///<summary></summary> 
    public virtual string Service { get; set;} 

    ///<summary></summary> 
    public virtual string Username { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundCredential,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyIcon ((object data) => (data as _BoundCredential).Type, null, "Type"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundCredential).Protocol, (object data,string value) => (data as _BoundCredential).Protocol = value, "Protocol"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundCredential).Service, (object data,string value) => (data as _BoundCredential).Service = value, "Service"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundCredential).Username, (object data,string value) => (data as _BoundCredential).Username = value, "Username")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static new Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundPassword 
/// </summary>
public partial class _BoundPassword : BoundCredential {


    ///<summary></summary> 
    public virtual string Password { get; set;} 


    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundPassword,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyIcon ((object data) => (data as _BoundPassword).Type, null, "Type"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundPassword).Protocol, (object data,string value) => (data as _BoundPassword).Protocol = value, "Protocol"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundPassword).Service, (object data,string value) => (data as _BoundPassword).Service = value, "Service"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundPassword).Username, (object data,string value) => (data as _BoundPassword).Username = value, "Username"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundPassword).Password, (object data,string value) => (data as _BoundPassword).Password = value, "Password")

            });
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static new Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundPasskey 
/// </summary>
public partial class _BoundPasskey : BoundCredential {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundPasskey,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyIcon ((object data) => (data as _BoundPasskey).Type, null, "Type"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundPasskey).Protocol, (object data,string value) => (data as _BoundPasskey).Protocol = value, "Protocol"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundPasskey).Service, (object data,string value) => (data as _BoundPasskey).Service = value, "Service"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundPasskey).Username, (object data,string value) => (data as _BoundPasskey).Username = value, "Username")

            });
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static  Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundTask 
/// </summary>
public partial class _BoundTask : IParameter {

    public object Bound { get; set; }


    ///<summary></summary> 
    public virtual IFieldIcon Type { get;} 

    ///<summary></summary> 
    public virtual string Title { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundTask,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyIcon ((object data) => (data as _BoundTask).Type, null, "Type"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundTask).Title, (object data,string value) => (data as _BoundTask).Title = value, "Title")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static  Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundAppointment 
/// </summary>
public partial class _BoundAppointment : IParameter {

    public object Bound { get; set; }


    ///<summary></summary> 
    public virtual string Display { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundAppointment,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _BoundAppointment).Display, (object data,string value) => (data as _BoundAppointment).Display = value, "Display")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static  Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundBookmark 
/// </summary>
public partial class _BoundBookmark : IParameter {

    public object Bound { get; set; }


    ///<summary></summary> 
    public virtual IFieldIcon Type { get;} 

    ///<summary></summary> 
    public virtual string Title { get; set;} 

    ///<summary></summary> 
    public virtual string Uri { get; set;} 

    ///<summary></summary> 
    public virtual string Comments { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundBookmark,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyIcon ((object data) => (data as _BoundBookmark).Type, null, "Type"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundBookmark).Title, (object data,string value) => (data as _BoundBookmark).Title = value, "Title"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundBookmark).Uri, (object data,string value) => (data as _BoundBookmark).Uri = value, "Uri"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundBookmark).Comments, (object data,string value) => (data as _BoundBookmark).Comments = value, "Comments")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

        // error on Uri
        if ((Uri != null)
            ) {
            result ??=new GuiResultInvalid(this);
            result.SetError (2, "Must specify a URI", "LinkIsNull");
            }

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
    /// <summary>Type check verification.</summary>
    public static new Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundFeed 
/// </summary>
public partial class _BoundFeed : BoundBookmark {


    ///<summary></summary> 
    public virtual string Protocol { get; set;} 


    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundFeed,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyIcon ((object data) => (data as _BoundFeed).Type, null, "Type"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundFeed).Title, (object data,string value) => (data as _BoundFeed).Title = value, "Title"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundFeed).Uri, (object data,string value) => (data as _BoundFeed).Uri = value, "Uri"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundFeed).Comments, (object data,string value) => (data as _BoundFeed).Comments = value, "Comments"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundFeed).Protocol, (object data,string value) => (data as _BoundFeed).Protocol = value, "Protocol")

            });
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static  Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundApplication 
/// </summary>
public partial class _BoundApplication : IParameter {

    public object Bound { get; set; }


    ///<summary></summary> 
    public virtual string Display { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundApplication,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _BoundApplication).Display, (object data,string value) => (data as _BoundApplication).Display = value, "Display")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static new Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundApplicationMail 
/// </summary>
public partial class _BoundApplicationMail : BoundApplication {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundApplicationMail,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _BoundApplicationMail).Display, (object data,string value) => (data as _BoundApplicationMail).Display = value, "Display")

            });
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static new Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundApplicationSsh 
/// </summary>
public partial class _BoundApplicationSsh : BoundApplication {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundApplicationSsh,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _BoundApplicationSsh).Display, (object data,string value) => (data as _BoundApplicationSsh).Display = value, "Display")

            });
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static new Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundApplicationOpenPgp 
/// </summary>
public partial class _BoundApplicationOpenPgp : BoundApplication {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundApplicationOpenPgp,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _BoundApplicationOpenPgp).Display, (object data,string value) => (data as _BoundApplicationOpenPgp).Display = value, "Display")

            });
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static new Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundApplicationDeveloper 
/// </summary>
public partial class _BoundApplicationDeveloper : BoundApplication {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundApplicationDeveloper,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _BoundApplicationDeveloper).Display, (object data,string value) => (data as _BoundApplicationDeveloper).Display = value, "Display")

            });
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static new Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundApplicationPkix 
/// </summary>
public partial class _BoundApplicationPkix : BoundApplication {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundApplicationPkix,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _BoundApplicationPkix).Display, (object data,string value) => (data as _BoundApplicationPkix).Display = value, "Display")

            });
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static new Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundApplicationGroup 
/// </summary>
public partial class _BoundApplicationGroup : BoundApplication {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundApplicationGroup,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _BoundApplicationGroup).Display, (object data,string value) => (data as _BoundApplicationGroup).Display = value, "Display")

            });
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static new Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundApplicationCallSign 
/// </summary>
public partial class _BoundApplicationCallSign : BoundApplication {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundApplicationCallSign,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _BoundApplicationCallSign).Display, (object data,string value) => (data as _BoundApplicationCallSign).Display = value, "Display")

            });
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static  Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundDevice 
/// </summary>
public partial class _BoundDevice : IParameter {

    public object Bound { get; set; }


    ///<summary></summary> 
    public virtual IFieldIcon Type { get;} 

    ///<summary></summary> 
    public virtual string DeviceType { get; set;} 

    ///<summary></summary> 
    public virtual string Rights { get; set;} 

    ///<summary></summary> 
    public virtual string LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string Udf { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundDevice,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyIcon ((object data) => (data as _BoundDevice).Type, null, "Type"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundDevice).DeviceType, (object data,string value) => (data as _BoundDevice).DeviceType = value, "DeviceType"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundDevice).Rights, (object data,string value) => (data as _BoundDevice).Rights = value, "Rights"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundDevice).LocalName, (object data,string value) => (data as _BoundDevice).LocalName = value, "LocalName"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundDevice).Udf, (object data,string value) => (data as _BoundDevice).Udf = value, "Udf")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog AccountUser 
/// </summary>
public partial class AccountUser : _AccountUser {
    /// <summary>Type check verification.</summary>
    public static  Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section AccountUser 
/// </summary>
public partial class _AccountUser : IParameter {

    public object Bound { get; set; }


    ///<summary></summary> 
    public virtual string Udf { get; set;} 

    ///<summary></summary> 
    public virtual string ServiceAddress { get; set;} 

    ///<summary></summary> 
    public virtual string Local { get; set;} 

    ///<summary></summary> 
    public virtual string Description { get; set;} 

    ///<summary></summary> 
    public virtual ISelectCollection UserChooseDevice { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _AccountUser,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _AccountUser).Udf, (object data,string value) => (data as _AccountUser).Udf = value, "Udf"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountUser).ServiceAddress, (object data,string value) => (data as _AccountUser).ServiceAddress = value, "ServiceAddress"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountUser).Local, (object data,string value) => (data as _AccountUser).Local = value, "Local"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountUser).Description, (object data,string value) => (data as _AccountUser).Description = value, "Description"), 
            new GuiBoundPropertyChooser ((object data) => (data as _AccountUser).UserChooseDevice, (object data,ISelectCollection value) => (data as _AccountUser).UserChooseDevice = value, "UserChooseDevice")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog BoundContact 
/// </summary>
public partial class BoundContact : _BoundContact {
    /// <summary>Type check verification.</summary>
    public static  Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundContact 
/// </summary>
public partial class _BoundContact : IParameter {

    public object Bound { get; set; }


    ///<summary></summary> 
    public virtual IFieldIcon Type { get;} 

    ///<summary></summary> 
    public virtual string Display { get;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundContact,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyIcon ((object data) => (data as _BoundContact).Type, null, "Type"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundContact).Display, null, "Display")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static new Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundContactPerson 
/// </summary>
public partial class _BoundContactPerson : BoundContact {


    ///<summary></summary> 
    public virtual bool Self { get; set;} 

    ///<summary></summary> 
    public virtual string Local { get; set;} 

    ///<summary></summary> 
    public virtual string First { get; set;} 

    ///<summary></summary> 
    public virtual string Last { get; set;} 

    ///<summary></summary> 
    public virtual string Prefix { get; set;} 

    ///<summary></summary> 
    public virtual string Suffix { get; set;} 

    ///<summary></summary> 
    public virtual ISelectCollection NetworkAddresses { get; set;} 

    ///<summary></summary> 
    public virtual ISelectCollection PhysicalAddresses { get; set;} 


    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundContactPerson,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyBoolean ((object data) => (data as _BoundContactPerson).Self, (object data,bool value) => (data as _BoundContactPerson).Self = value, "Self"), 
            new GuiBoundPropertyIcon ((object data) => (data as _BoundContactPerson).Type, null, "Type"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundContactPerson).Display, null, "Display"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundContactPerson).Local, (object data,string value) => (data as _BoundContactPerson).Local = value, "Local"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundContactPerson).First, (object data,string value) => (data as _BoundContactPerson).First = value, "First"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundContactPerson).Last, (object data,string value) => (data as _BoundContactPerson).Last = value, "Last"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundContactPerson).Prefix, (object data,string value) => (data as _BoundContactPerson).Prefix = value, "Prefix"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundContactPerson).Suffix, (object data,string value) => (data as _BoundContactPerson).Suffix = value, "Suffix"), 
            new GuiBoundPropertyList ((object data) => (data as _BoundContactPerson).NetworkAddresses, (object data,ISelectCollection value) => (data as _BoundContactPerson).NetworkAddresses = value, "NetworkAddresses"), 
            new GuiBoundPropertyList ((object data) => (data as _BoundContactPerson).PhysicalAddresses, (object data,ISelectCollection value) => (data as _BoundContactPerson).PhysicalAddresses = value, "PhysicalAddresses")

            });
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static new Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundContactBusiness 
/// </summary>
public partial class _BoundContactBusiness : BoundContact {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundContactBusiness,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyIcon ((object data) => (data as _BoundContactBusiness).Type, null, "Type"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundContactBusiness).Display, null, "Display")

            });
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static new Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section BoundContactPlace 
/// </summary>
public partial class _BoundContactPlace : BoundContact {



    ///<inheritdoc/>
    public override GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static new GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundContactPlace,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyIcon ((object data) => (data as _BoundContactPlace).Type, null, "Type"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundContactPlace).Display, null, "Display")

            });
    ///<summary>Validation</summary> 
    public override IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    /// <summary>Type check verification.</summary>
    public static  Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section ContactNetworkAddress 
/// </summary>
public partial class _ContactNetworkAddress : IParameter {

    public object Bound { get; set; }


    ///<summary></summary> 
    public virtual IFieldIcon Type { get;} 

    ///<summary></summary> 
    public virtual string Protocol { get; set;} 

    ///<summary></summary> 
    public virtual string Address { get; set;} 

    ///<summary></summary> 
    public virtual string Fingerprint { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _ContactNetworkAddress,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyIcon ((object data) => (data as _ContactNetworkAddress).Type, null, "Type"), 
            new GuiBoundPropertyString ((object data) => (data as _ContactNetworkAddress).Protocol, (object data,string value) => (data as _ContactNetworkAddress).Protocol = value, "Protocol"), 
            new GuiBoundPropertyString ((object data) => (data as _ContactNetworkAddress).Address, (object data,string value) => (data as _ContactNetworkAddress).Address = value, "Address"), 
            new GuiBoundPropertyString ((object data) => (data as _ContactNetworkAddress).Fingerprint, (object data,string value) => (data as _ContactNetworkAddress).Fingerprint = value, "Fingerprint")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }

/// <summary>
/// Callback parameters for dialog ContactPhysicalAddress 
/// </summary>
public partial class ContactPhysicalAddress : _ContactPhysicalAddress {
    /// <summary>Type check verification.</summary>
    public static  Func<object, bool> IsBacker { get; set; } = (object _) => false;
    }

/// <summary>
/// Callback parameters for section ContactPhysicalAddress 
/// </summary>
public partial class _ContactPhysicalAddress : IParameter {

    public object Bound { get; set; }


    ///<summary></summary> 
    public virtual string Appartment { get; set;} 

    ///<summary></summary> 
    public virtual string Street { get; set;} 

    ///<summary></summary> 
    public virtual string District { get; set;} 

    ///<summary></summary> 
    public virtual string Region { get; set;} 

    ///<summary></summary> 
    public virtual string Code { get; set;} 

    ///<summary></summary> 
    public virtual string Country { get; set;} 

    ///<summary></summary> 
    public virtual decimal? Latitude { get; set;} 

    ///<summary></summary> 
    public virtual decimal? Longitude { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _ContactPhysicalAddress,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).Appartment, (object data,string value) => (data as _ContactPhysicalAddress).Appartment = value, "Appartment"), 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).Street, (object data,string value) => (data as _ContactPhysicalAddress).Street = value, "Street"), 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).District, (object data,string value) => (data as _ContactPhysicalAddress).District = value, "District"), 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).Region, (object data,string value) => (data as _ContactPhysicalAddress).Region = value, "Region"), 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).Code, (object data,string value) => (data as _ContactPhysicalAddress).Code = value, "Code"), 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).Country, (object data,string value) => (data as _ContactPhysicalAddress).Country = value, "Country"), 
            new GuiBoundPropertyDecimal ((object data) => (data as _ContactPhysicalAddress).Latitude, (object data,decimal? value) => (data as _ContactPhysicalAddress).Latitude = value, "Latitude"), 
            new GuiBoundPropertyDecimal ((object data) => (data as _ContactPhysicalAddress).Longitude, (object data,decimal? value) => (data as _ContactPhysicalAddress).Longitude = value, "Longitude")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    public virtual string ServiceAddress { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _TestService,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _TestService).ServiceAddress, (object data,string value) => (data as _TestService).ServiceAddress = value, "ServiceAddress")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    public virtual string ServiceAddress { get; set;} 

    ///<summary></summary> 
    public virtual string ContactName { get; set;} 

    ///<summary></summary> 
    public virtual string LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string Coupon { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _AccountCreate,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _AccountCreate).ServiceAddress, (object data,string value) => (data as _AccountCreate).ServiceAddress = value, "ServiceAddress"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountCreate).ContactName, (object data,string value) => (data as _AccountCreate).ContactName = value, "ContactName"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountCreate).LocalName, (object data,string value) => (data as _AccountCreate).LocalName = value, "LocalName"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountCreate).Coupon, (object data,string value) => (data as _AccountCreate).Coupon = value, "Coupon")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    public virtual string ConnectionString { get; set;} 

    ///<summary></summary> 
    public virtual string ConnectionPin { get; set;} 

    ///<summary></summary> 
    public virtual string Rights { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _AccountRequestConnect,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _AccountRequestConnect).ConnectionString, (object data,string value) => (data as _AccountRequestConnect).ConnectionString = value, "ConnectionString"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountRequestConnect).ConnectionPin, (object data,string value) => (data as _AccountRequestConnect).ConnectionPin = value, "ConnectionPin"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountRequestConnect).Rights, (object data,string value) => (data as _AccountRequestConnect).Rights = value, "Rights")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    public virtual string LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string Rights { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _DeviceConnectQR,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyQRScan ((object data) => (data as _DeviceConnectQR).QrCode, (object data,GuiQR? value) => (data as _DeviceConnectQR).QrCode = value, "QrCode"), 
            new GuiBoundPropertyString ((object data) => (data as _DeviceConnectQR).LocalName, (object data,string value) => (data as _DeviceConnectQR).LocalName = value, "LocalName"), 
            new GuiBoundPropertyString ((object data) => (data as _DeviceConnectQR).Rights, (object data,string value) => (data as _DeviceConnectQR).Rights = value, "Rights")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    public virtual string Rights { get; set;} 

    ///<summary></summary> 
    public virtual int? Security { get; set;} 

    ///<summary></summary> 
    public virtual int? Expire { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _AccountGetPin,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _AccountGetPin).Rights, (object data,string value) => (data as _AccountGetPin).Rights = value, "Rights"), 
            new GuiBoundPropertyInteger ((object data) => (data as _AccountGetPin).Security, (object data,int? value) => (data as _AccountGetPin).Security = value, "Security"), 
            new GuiBoundPropertyInteger ((object data) => (data as _AccountGetPin).Expire, (object data,int? value) => (data as _AccountGetPin).Expire = value, "Expire")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    public virtual string ServiceAddress { get; set;} 

    ///<summary></summary> 
    public virtual string LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string Coupon { get; set;} 

    ///<summary></summary> 
    public virtual string Share1 { get; set;} 

    ///<summary></summary> 
    public virtual string Share2 { get; set;} 

    ///<summary></summary> 
    public virtual string Share3 { get; set;} 

    ///<summary></summary> 
    public virtual string Share4 { get; set;} 

    ///<summary></summary> 
    public virtual string Share5 { get; set;} 

    ///<summary></summary> 
    public virtual string Share6 { get; set;} 

    ///<summary></summary> 
    public virtual string Share7 { get; set;} 

    ///<summary></summary> 
    public virtual string Share8 { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _AccountRecover,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _AccountRecover).ServiceAddress, (object data,string value) => (data as _AccountRecover).ServiceAddress = value, "ServiceAddress"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountRecover).LocalName, (object data,string value) => (data as _AccountRecover).LocalName = value, "LocalName"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountRecover).Coupon, (object data,string value) => (data as _AccountRecover).Coupon = value, "Coupon"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountRecover).Share1, (object data,string value) => (data as _AccountRecover).Share1 = value, "Share1"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountRecover).Share2, (object data,string value) => (data as _AccountRecover).Share2 = value, "Share2"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountRecover).Share3, (object data,string value) => (data as _AccountRecover).Share3 = value, "Share3"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountRecover).Share4, (object data,string value) => (data as _AccountRecover).Share4 = value, "Share4"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountRecover).Share5, (object data,string value) => (data as _AccountRecover).Share5 = value, "Share5"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountRecover).Share6, (object data,string value) => (data as _AccountRecover).Share6 = value, "Share6"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountRecover).Share7, (object data,string value) => (data as _AccountRecover).Share7 = value, "Share7"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountRecover).Share8, (object data,string value) => (data as _AccountRecover).Share8 = value, "Share8")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _AccountDelete,
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    public virtual ISelectCollection ChooseUser { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _AccountSwitch,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _AccountSwitch).ChooseUser, (object data,ISelectCollection value) => (data as _AccountSwitch).ChooseUser = value, "ChooseUser")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _AccountGenerateRecovery,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyInteger ((object data) => (data as _AccountGenerateRecovery).NumberShares, (object data,int? value) => (data as _AccountGenerateRecovery).NumberShares = value, "NumberShares"), 
            new GuiBoundPropertyInteger ((object data) => (data as _AccountGenerateRecovery).Quorum, (object data,int? value) => (data as _AccountGenerateRecovery).Quorum = value, "Quorum")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    public virtual string Recipient { get; set;} 

    ///<summary></summary> 
    public virtual string Message { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _RequestContact,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _RequestContact).Recipient, (object data,string value) => (data as _RequestContact).Recipient = value, "Recipient"), 
            new GuiBoundPropertyString ((object data) => (data as _RequestContact).Message, (object data,string value) => (data as _RequestContact).Message = value, "Message")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _QrContact,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyQRScan ((object data) => (data as _QrContact).QrCode, (object data,GuiQR? value) => (data as _QrContact).QrCode = value, "QrCode")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    public virtual string Recipient { get; set;} 

    ///<summary></summary> 
    public virtual string Message { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _RequestConfirmation,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _RequestConfirmation).Recipient, (object data,string value) => (data as _RequestConfirmation).Recipient = value, "Recipient"), 
            new GuiBoundPropertyString ((object data) => (data as _RequestConfirmation).Message, (object data,string value) => (data as _RequestConfirmation).Message = value, "Message")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    public virtual string Recipient { get; set;} 

    ///<summary></summary> 
    public virtual string Subject { get; set;} 

    ///<summary></summary> 
    public virtual string Message { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _CreateMail,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _CreateMail).Recipient, (object data,string value) => (data as _CreateMail).Recipient = value, "Recipient"), 
            new GuiBoundPropertyString ((object data) => (data as _CreateMail).Subject, (object data,string value) => (data as _CreateMail).Subject = value, "Subject"), 
            new GuiBoundTextArea ((object data) => (data as _CreateMail).Message, (object data,string value) => (data as _CreateMail).Message = value, "Message")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _CreateChat,
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _StartVoice,
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _StartVideo,
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action SendDocument 
/// </summary>
public partial class SendDocument : _SendDocument {
    }


/// <summary>
/// Callback parameters for action SendDocument 
/// </summary>
public partial class _SendDocument : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _SendDocument,
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action ShareDocument 
/// </summary>
public partial class ShareDocument : _ShareDocument {
    }


/// <summary>
/// Callback parameters for action ShareDocument 
/// </summary>
public partial class _ShareDocument : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _ShareDocument,
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _AddMailAccount,
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _AddSshAccount,
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _AddGitAccount,
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _AddCodeSigningKey,
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
/// Callback parameters for action ConfirmationAccept 
/// </summary>
public partial class ConfirmationAccept : _ConfirmationAccept {
    }


/// <summary>
/// Callback parameters for action ConfirmationAccept 
/// </summary>
public partial class _ConfirmationAccept : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _ConfirmationAccept,
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action ConfirmationReject 
/// </summary>
public partial class ConfirmationReject : _ConfirmationReject {
    }


/// <summary>
/// Callback parameters for action ConfirmationReject 
/// </summary>
public partial class _ConfirmationReject : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _ConfirmationReject,
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action ContactAccept 
/// </summary>
public partial class ContactAccept : _ContactAccept {
    }


/// <summary>
/// Callback parameters for action ContactAccept 
/// </summary>
public partial class _ContactAccept : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _ContactAccept,
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action ContactReject 
/// </summary>
public partial class ContactReject : _ContactReject {
    }


/// <summary>
/// Callback parameters for action ContactReject 
/// </summary>
public partial class _ContactReject : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _ContactReject,
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action ConnectAccept 
/// </summary>
public partial class ConnectAccept : _ConnectAccept {
    }


/// <summary>
/// Callback parameters for action ConnectAccept 
/// </summary>
public partial class _ConnectAccept : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _ConnectAccept,
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action ConnectReject 
/// </summary>
public partial class ConnectReject : _ConnectReject {
    }


/// <summary>
/// Callback parameters for action ConnectReject 
/// </summary>
public partial class _ConnectReject : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _ConnectReject,
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action GroupAccept 
/// </summary>
public partial class GroupAccept : _GroupAccept {
    }


/// <summary>
/// Callback parameters for action GroupAccept 
/// </summary>
public partial class _GroupAccept : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _GroupAccept,
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action GroupReject 
/// </summary>
public partial class GroupReject : _GroupReject {
    }


/// <summary>
/// Callback parameters for action GroupReject 
/// </summary>
public partial class _GroupReject : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _GroupReject,
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action TaskAccept 
/// </summary>
public partial class TaskAccept : _TaskAccept {
    }


/// <summary>
/// Callback parameters for action TaskAccept 
/// </summary>
public partial class _TaskAccept : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _TaskAccept,
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize(Gui gui) => NullResult.Initialized;


    ///<summary>Teardown.</summary> 
    public virtual IResult TearDown(Gui gui) => NullResult.Teardown;


    }


/// <summary>
/// Callback parameters for action TaskReject 
/// </summary>
public partial class TaskReject : _TaskReject {
    }


/// <summary>
/// Callback parameters for action TaskReject 
/// </summary>
public partial class _TaskReject : IParameter {


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _TaskReject,
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate(Gui gui) {
        GuiResultInvalid result = null;

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
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Completed;

    ///<summary></summary> 
    public virtual string ServiceAddress { get; set;} 

    ///<summary></summary> 
    public virtual string ServiceCallsign { get; set;} 

    ///<summary></summary> 
    public virtual string ServiceDns { get; set;} 

    ///<summary></summary> 
    public virtual string ServiceUdf { get; set;} 

    ///<summary></summary> 
    public virtual string HostUdf { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is ReportHost,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as ReportHost).ServiceCallsign, (object data,string value) => (data as ReportHost).ServiceCallsign = value, "ServiceCallsign"), 
            new GuiBoundPropertyString ((object data) => (data as ReportHost).ServiceDns, (object data,string value) => (data as ReportHost).ServiceDns = value, "ServiceDns"), 
            new GuiBoundPropertyString ((object data) => (data as ReportHost).ServiceUdf, (object data,string value) => (data as ReportHost).ServiceUdf = value, "ServiceUdf"), 
            new GuiBoundPropertyString ((object data) => (data as ReportHost).HostUdf, (object data,string value) => (data as ReportHost).HostUdf = value, "HostUdf")

            });

    ///<inheritdoc/>
    public object[] GetValues() => new [] { 
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
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Completed;

    ///<summary></summary> 
    public virtual string ServiceName { get; set;} 

    ///<summary></summary> 
    public virtual string LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string ServiceAddress { get; set;} 

    ///<summary></summary> 
    public virtual string ProfileUdf { get; set;} 

    ///<summary></summary> 
    public virtual string ServiceUdf { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is ReportAccountCreate,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as ReportAccountCreate).LocalName, (object data,string value) => (data as ReportAccountCreate).LocalName = value, "LocalName"), 
            new GuiBoundPropertyString ((object data) => (data as ReportAccountCreate).ServiceAddress, (object data,string value) => (data as ReportAccountCreate).ServiceAddress = value, "ServiceAddress"), 
            new GuiBoundPropertyString ((object data) => (data as ReportAccountCreate).ProfileUdf, (object data,string value) => (data as ReportAccountCreate).ProfileUdf = value, "ProfileUdf"), 
            new GuiBoundPropertyString ((object data) => (data as ReportAccountCreate).ServiceUdf, (object data,string value) => (data as ReportAccountCreate).ServiceUdf = value, "ServiceUdf")

            });

    ///<inheritdoc/>
    public object[] GetValues() => new [] { 
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
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Completed;

    ///<summary></summary> 
    public virtual string ServiceName { get; set;} 

    ///<summary></summary> 
    public virtual string LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string ServiceCallsign { get; set;} 

    ///<summary></summary> 
    public virtual string ServiceAddress { get; set;} 

    ///<summary></summary> 
    public virtual string ProfileUdf { get; set;} 

    ///<summary></summary> 
    public virtual string ServiceUdf { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is ReportAccount,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as ReportAccount).LocalName, (object data,string value) => (data as ReportAccount).LocalName = value, "LocalName"), 
            new GuiBoundPropertyString ((object data) => (data as ReportAccount).ServiceCallsign, (object data,string value) => (data as ReportAccount).ServiceCallsign = value, "ServiceCallsign"), 
            new GuiBoundPropertyString ((object data) => (data as ReportAccount).ServiceAddress, (object data,string value) => (data as ReportAccount).ServiceAddress = value, "ServiceAddress"), 
            new GuiBoundPropertyString ((object data) => (data as ReportAccount).ProfileUdf, (object data,string value) => (data as ReportAccount).ProfileUdf = value, "ProfileUdf"), 
            new GuiBoundPropertyString ((object data) => (data as ReportAccount).ServiceUdf, (object data,string value) => (data as ReportAccount).ServiceUdf = value, "ServiceUdf")

            });

    ///<inheritdoc/>
    public object[] GetValues() => new [] { 
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
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Completed;

    ///<summary></summary> 
    public virtual string ServiceName { get; set;} 

    ///<summary></summary> 
    public virtual string LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string ServiceCallsign { get; set;} 

    ///<summary></summary> 
    public virtual string ServiceAddress { get; set;} 

    ///<summary></summary> 
    public virtual string ServiceUdf { get; set;} 

    ///<summary></summary> 
    public virtual string ServiceMessage { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is ReportPending,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as ReportPending).LocalName, (object data,string value) => (data as ReportPending).LocalName = value, "LocalName"), 
            new GuiBoundPropertyString ((object data) => (data as ReportPending).ServiceCallsign, (object data,string value) => (data as ReportPending).ServiceCallsign = value, "ServiceCallsign"), 
            new GuiBoundPropertyString ((object data) => (data as ReportPending).ServiceAddress, (object data,string value) => (data as ReportPending).ServiceAddress = value, "ServiceAddress"), 
            new GuiBoundPropertyString ((object data) => (data as ReportPending).ServiceUdf, (object data,string value) => (data as ReportPending).ServiceUdf = value, "ServiceUdf"), 
            new GuiBoundPropertyString ((object data) => (data as ReportPending).ServiceMessage, (object data,string value) => (data as ReportPending).ServiceMessage = value, "ServiceMessage")

            });

    ///<inheritdoc/>
    public object[] GetValues() => new [] { 
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
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Completed;

    ///<summary></summary> 
    public virtual string Share1 { get; set;} 

    ///<summary></summary> 
    public virtual string Share2 { get; set;} 

    ///<summary></summary> 
    public virtual string Share3 { get; set;} 

    ///<summary></summary> 
    public virtual string Share4 { get; set;} 

    ///<summary></summary> 
    public virtual string Share5 { get; set;} 

    ///<summary></summary> 
    public virtual string Share6 { get; set;} 

    ///<summary></summary> 
    public virtual string Share7 { get; set;} 

    ///<summary></summary> 
    public virtual string Share8 { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is ReportShares,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as ReportShares).Share1, (object data,string value) => (data as ReportShares).Share1 = value, "Share1"), 
            new GuiBoundPropertyString ((object data) => (data as ReportShares).Share2, (object data,string value) => (data as ReportShares).Share2 = value, "Share2"), 
            new GuiBoundPropertyString ((object data) => (data as ReportShares).Share3, (object data,string value) => (data as ReportShares).Share3 = value, "Share3"), 
            new GuiBoundPropertyString ((object data) => (data as ReportShares).Share4, (object data,string value) => (data as ReportShares).Share4 = value, "Share4"), 
            new GuiBoundPropertyString ((object data) => (data as ReportShares).Share5, (object data,string value) => (data as ReportShares).Share5 = value, "Share5"), 
            new GuiBoundPropertyString ((object data) => (data as ReportShares).Share6, (object data,string value) => (data as ReportShares).Share6 = value, "Share6"), 
            new GuiBoundPropertyString ((object data) => (data as ReportShares).Share7, (object data,string value) => (data as ReportShares).Share7 = value, "Share7"), 
            new GuiBoundPropertyString ((object data) => (data as ReportShares).Share8, (object data,string value) => (data as ReportShares).Share8 = value, "Share8")

            });

    ///<inheritdoc/>
    public object[] GetValues() => new [] { 
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
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Completed;

    ///<summary></summary> 
    public virtual string AccountName { get; set;} 

    ///<summary></summary> 
    public virtual string Identifier { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is MessageSentContact,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as MessageSentContact).AccountName, (object data,string value) => (data as MessageSentContact).AccountName = value, "AccountName"), 
            new GuiBoundPropertyString ((object data) => (data as MessageSentContact).Identifier, (object data,string value) => (data as MessageSentContact).Identifier = value, "Identifier")

            });

    ///<inheritdoc/>
    public object[] GetValues() => new [] { 
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
    public virtual ReturnResult ReturnResult { get; init; } = ReturnResult.Completed;

    ///<summary></summary> 
    public virtual string AccountName { get; set;} 

    ///<summary></summary> 
    public virtual string Identifier { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is MessageSentDevice,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as MessageSentDevice).AccountName, (object data,string value) => (data as MessageSentDevice).AccountName = value, "AccountName"), 
            new GuiBoundPropertyString ((object data) => (data as MessageSentDevice).Identifier, (object data,string value) => (data as MessageSentDevice).Identifier = value, "Identifier")

            });

    ///<inheritdoc/>
    public object[] GetValues() => new [] { 
        AccountName,
        Identifier};
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
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is HttpRequestFail,
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object[] GetValues() => Array.Empty<object>();


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
    public virtual string ServiceName { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is ServiceNotFound,
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object[] GetValues() => new [] { 
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
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is ServiceRefused,
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object[] GetValues() => Array.Empty<object>();


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
    public virtual string ServiceName { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is HostNotFound,
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object[] GetValues() => new [] { 
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
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is InvalidHostCredential,
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object[] GetValues() => Array.Empty<object>();


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
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is CredentialRefused,
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object[] GetValues() => Array.Empty<object>();


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
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is DeviceRefused,
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object[] GetValues() => Array.Empty<object>();


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
    public virtual string Filename { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is FileWriteError,
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object[] GetValues() => new [] { 
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
    public virtual string Filename { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is FileReadError,
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object[] GetValues() => new [] { 
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
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is AccountProfileInvalid,
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object[] GetValues() => Array.Empty<object>();


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
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is DeviceProfileInvalid,
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object[] GetValues() => Array.Empty<object>();


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
    public virtual string ProfileName { get; set;} 

    ///<summary></summary> 
    public virtual string LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string ProfileUdf { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is ActivationKeyNotFound,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as ActivationKeyNotFound).LocalName, (object data,string value) => (data as ActivationKeyNotFound).LocalName = value, "LocalName"), 
            new GuiBoundPropertyString ((object data) => (data as ActivationKeyNotFound).ProfileUdf, (object data,string value) => (data as ActivationKeyNotFound).ProfileUdf = value, "ProfileUdf")

            });

    ///<inheritdoc/>
    public object[] GetValues() => new [] { 
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
    public virtual string CatalogName { get; set;} 

    ///<summary></summary> 
    public virtual string LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string ProfileUdf { get; set;} 


    ///<inheritdoc/>
    public virtual GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is NotAuthorizedCatalog,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as NotAuthorizedCatalog).CatalogName, (object data,string value) => (data as NotAuthorizedCatalog).CatalogName = value, "CatalogName"), 
            new GuiBoundPropertyString ((object data) => (data as NotAuthorizedCatalog).LocalName, (object data,string value) => (data as NotAuthorizedCatalog).LocalName = value, "LocalName"), 
            new GuiBoundPropertyString ((object data) => (data as NotAuthorizedCatalog).ProfileUdf, (object data,string value) => (data as NotAuthorizedCatalog).ProfileUdf = value, "ProfileUdf")

            });

    ///<inheritdoc/>
    public object[] GetValues() => new [] { 
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
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is NotAuthorizedAdministration,
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object[] GetValues() => Array.Empty<object>();


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
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is NotAuthorizedFCatalog,
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object[] GetValues() => Array.Empty<object>();


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
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is CounterpartyApproval,
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object[] GetValues() => Array.Empty<object>();


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
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is SystemExeption,
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object[] GetValues() => Array.Empty<object>();


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
    public static  GuiBinding BaseBinding  { get; } = new (
        (object test) => test is NotYetImplemented,
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object[] GetValues() => Array.Empty<object>();


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
    public override List<GuiAction> Actions { get; }

    ///<inheritdoc/> 
    public override List<GuiAction> Selections { get; }

    ///<inheritdoc/> 
    public override List<GuiResult> Results { get; }


	///<inheritdoc/>

	public override List<GuiImage> Icons => icons;
	readonly List<GuiImage> icons = new () {  
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
		new GuiImage ("display") , 
		new GuiImage ("document_send") , 
		new GuiImage ("document_share") , 
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
	public GuiSection SectionAccountSection { get; } = new ("AccountSection", "Account", "user", false);

    ///<summary>Section SectionMessageSection.</summary> 
	public GuiSection SectionMessageSection { get; } = new ("MessageSection", "Messages", "messages", true);

    ///<summary>Section SectionContactSection.</summary> 
	public GuiSection SectionContactSection { get; } = new ("ContactSection", "Contacts", "contacts", true);

    ///<summary>Section SectionDocumentSection.</summary> 
	public GuiSection SectionDocumentSection { get; } = new ("DocumentSection", "Documents", "Documents", false);

    ///<summary>Section SectionFeedSection.</summary> 
	public GuiSection SectionFeedSection { get; } = new ("FeedSection", "Feeds", "feeds", false);

    ///<summary>Section SectionGroupSection.</summary> 
	public GuiSection SectionGroupSection { get; } = new ("GroupSection", "Groups", "groups", false);

    ///<summary>Section SectionCredentialSection.</summary> 
	public GuiSection SectionCredentialSection { get; } = new ("CredentialSection", "Credentials", "credentials", false);

    ///<summary>Section SectionTaskSection.</summary> 
	public GuiSection SectionTaskSection { get; } = new ("TaskSection", "Tasks", "tasks", false);

    ///<summary>Section SectionCalendarSection.</summary> 
	public GuiSection SectionCalendarSection { get; } = new ("CalendarSection", "Calendar", "calendar", false);

    ///<summary>Section SectionBookmarkSection.</summary> 
	public GuiSection SectionBookmarkSection { get; } = new ("BookmarkSection", "Bookmark", "bookmark", false);

    ///<summary>Section SectionApplicationSection.</summary> 
	public GuiSection SectionApplicationSection { get; } = new ("ApplicationSection", "Applications", "applications", false);

    ///<summary>Section SectionDeviceSection.</summary> 
	public GuiSection SectionDeviceSection { get; } = new ("DeviceSection", "Devices", "devices", false);

    ///<summary>Section SectionServiceSection.</summary> 
	public GuiSection SectionServiceSection { get; } = new ("ServiceSection", "Services", "Services", false);

    ///<summary>Section SectionSettingSection.</summary> 
	public GuiSection SectionSettingSection { get; } = new ("SettingSection", "Settings", "settings", true);

    ///<summary>Section SectionAppearance.</summary> 
	public GuiSection SectionAppearance { get; } = new ("Appearance", "Appearance", "display", false);
#endregion
#region // Actions

    ///<summary>Action ActionTestService.</summary> 
	public GuiAction ActionTestService { get; } = new ("TestService", "Test Service", "test_service", () => new TestService());

    ///<summary>Action ActionAccountCreate.</summary> 
	public GuiAction ActionAccountCreate { get; } = new ("AccountCreate", "Create Mesh Account", "new", () => new AccountCreate());

    ///<summary>Action ActionAccountRequestConnect.</summary> 
	public GuiAction ActionAccountRequestConnect { get; } = new ("AccountRequestConnect", "Connect by Address", "connect", () => new AccountRequestConnect());

    ///<summary>Action ActionDeviceConnectQR.</summary> 
	public GuiAction ActionDeviceConnectQR { get; } = new ("DeviceConnectQR", "Present QR", "present_qr", () => new DeviceConnectQR());

    ///<summary>Action ActionAccountGetPin.</summary> 
	public GuiAction ActionAccountGetPin { get; } = new ("AccountGetPin", "Create connection PIN", "recover", () => new AccountGetPin());

    ///<summary>Action ActionAccountRecover.</summary> 
	public GuiAction ActionAccountRecover { get; } = new ("AccountRecover", "Recover Mesh Account", "recover_account", () => new AccountRecover());

    ///<summary>Action ActionAccountDelete.</summary> 
	public GuiAction ActionAccountDelete { get; } = new ("AccountDelete", "Delete Account", "test_service", () => new AccountDelete());

    ///<summary>Action ActionAccountSwitch.</summary> 
	public GuiAction ActionAccountSwitch { get; } = new ("AccountSwitch", "Change Account", "test_service", () => new AccountSwitch());

    ///<summary>Action ActionAccountGenerateRecovery.</summary> 
	public GuiAction ActionAccountGenerateRecovery { get; } = new ("AccountGenerateRecovery", "Create recovery", "share_nodes_solid", () => new AccountGenerateRecovery());

    ///<summary>Action ActionRequestContact.</summary> 
	public GuiAction ActionRequestContact { get; } = new ("RequestContact", "Request Contact", "contact", () => new RequestContact());

    ///<summary>Action ActionQrContact.</summary> 
	public GuiAction ActionQrContact { get; } = new ("QrContact", "Connect by QR", "contact", () => new QrContact());

    ///<summary>Action ActionRequestConfirmation.</summary> 
	public GuiAction ActionRequestConfirmation { get; } = new ("RequestConfirmation", "Confirmation Request", "confirm", () => new RequestConfirmation());

    ///<summary>Action ActionCreateMail.</summary> 
	public GuiAction ActionCreateMail { get; } = new ("CreateMail", "New Mail", "mail", () => new CreateMail());

    ///<summary>Action ActionCreateChat.</summary> 
	public GuiAction ActionCreateChat { get; } = new ("CreateChat", "New Chat", "chat", () => new CreateChat());

    ///<summary>Action ActionStartVoice.</summary> 
	public GuiAction ActionStartVoice { get; } = new ("StartVoice", "New Voice", "voice", () => new StartVoice());

    ///<summary>Action ActionStartVideo.</summary> 
	public GuiAction ActionStartVideo { get; } = new ("StartVideo", "New Video", "video", () => new StartVideo());

    ///<summary>Action ActionSendDocument.</summary> 
	public GuiAction ActionSendDocument { get; } = new ("SendDocument", "Send document", "document_send", () => new SendDocument());

    ///<summary>Action ActionShareDocument.</summary> 
	public GuiAction ActionShareDocument { get; } = new ("ShareDocument", "Share document", "document_share", () => new ShareDocument());

    ///<summary>Action ActionAddMailAccount.</summary> 
	public GuiAction ActionAddMailAccount { get; } = new ("AddMailAccount", "Add email account", "mail", () => new AddMailAccount());

    ///<summary>Action ActionAddSshAccount.</summary> 
	public GuiAction ActionAddSshAccount { get; } = new ("AddSshAccount", "Create SSH credential", "credentials", () => new AddSshAccount());

    ///<summary>Action ActionAddGitAccount.</summary> 
	public GuiAction ActionAddGitAccount { get; } = new ("AddGitAccount", "Create git credentials", "git", () => new AddGitAccount());

    ///<summary>Action ActionAddCodeSigningKey.</summary> 
	public GuiAction ActionAddCodeSigningKey { get; } = new ("AddCodeSigningKey", "Add Code Signing Key", "signature", () => new AddCodeSigningKey());

#endregion
#region // Actions

    ///<summary>Selection SelectionConfirmationAccept.</summary> 
	public GuiAction SelectionConfirmationAccept { get; } = new ("ConfirmationAccept", "Accept", "circle_check", () => new ConfirmationAccept(), IsSelect:true);

    ///<summary>Selection SelectionConfirmationReject.</summary> 
	public GuiAction SelectionConfirmationReject { get; } = new ("ConfirmationReject", "Reject", "circle_cross", () => new ConfirmationReject(), IsSelect:true);

    ///<summary>Selection SelectionContactAccept.</summary> 
	public GuiAction SelectionContactAccept { get; } = new ("ContactAccept", "Accept", "circle_check", () => new ContactAccept(), IsSelect:true);

    ///<summary>Selection SelectionContactReject.</summary> 
	public GuiAction SelectionContactReject { get; } = new ("ContactReject", "Reject", "circle_cross", () => new ContactReject(), IsSelect:true);

    ///<summary>Selection SelectionConnectAccept.</summary> 
	public GuiAction SelectionConnectAccept { get; } = new ("ConnectAccept", "Accept", "circle_check", () => new ConnectAccept(), IsSelect:true);

    ///<summary>Selection SelectionConnectReject.</summary> 
	public GuiAction SelectionConnectReject { get; } = new ("ConnectReject", "Reject", "circle_cross", () => new ConnectReject(), IsSelect:true);

    ///<summary>Selection SelectionGroupAccept.</summary> 
	public GuiAction SelectionGroupAccept { get; } = new ("GroupAccept", "Accept", "circle_check", () => new GroupAccept(), IsSelect:true);

    ///<summary>Selection SelectionGroupReject.</summary> 
	public GuiAction SelectionGroupReject { get; } = new ("GroupReject", "Reject", "circle_cross", () => new GroupReject(), IsSelect:true);

    ///<summary>Selection SelectionTaskAccept.</summary> 
	public GuiAction SelectionTaskAccept { get; } = new ("TaskAccept", "Accept", "circle_check", () => new TaskAccept(), IsSelect:true);

    ///<summary>Selection SelectionTaskReject.</summary> 
	public GuiAction SelectionTaskReject { get; } = new ("TaskReject", "Reject", "circle_cross", () => new TaskReject(), IsSelect:true);

#endregion
#region // Dialogs

    ///<summary>Dialog DialogBoundAccount.</summary> 
	public GuiDialog DialogBoundAccount { get; } = new ("BoundAccount", "Account", "contacts", () => new BoundAccount()) {
                IsBoundType = (object data) => data is BoundAccount
                };

    ///<summary>Dialog DialogBoundMessage.</summary> 
	public GuiDialog DialogBoundMessage { get; } = new ("BoundMessage", "Message", "contacts", () => new BoundMessage()) {
                IsBoundType = (object data) => data is BoundMessage
                };

    ///<summary>Dialog DialogBoundMailMail.</summary> 
	public GuiDialog DialogBoundMailMail { get; } = new ("BoundMailMail", "Mail", "messages", () => new BoundMailMail()) {
                IsBoundType = (object data) => data is BoundMailMail
                };

    ///<summary>Dialog DialogBoundMessageConfirmationRequest.</summary> 
	public GuiDialog DialogBoundMessageConfirmationRequest { get; } = new ("BoundMessageConfirmationRequest", "Mail", "circle_question", () => new BoundMessageConfirmationRequest()) {
                IsBoundType = (object data) => data is BoundMessageConfirmationRequest
                };

    ///<summary>Dialog DialogBoundMessageConfirmationResponse.</summary> 
	public GuiDialog DialogBoundMessageConfirmationResponse { get; } = new ("BoundMessageConfirmationResponse", "Mail", "circle_check", () => new BoundMessageConfirmationResponse()) {
                IsBoundType = (object data) => data is BoundMessageConfirmationResponse
                };

    ///<summary>Dialog DialogBoundMessageContactRequest.</summary> 
	public GuiDialog DialogBoundMessageContactRequest { get; } = new ("BoundMessageContactRequest", "Mail", "contact", () => new BoundMessageContactRequest()) {
                IsBoundType = (object data) => data is BoundMessageContactRequest
                };

    ///<summary>Dialog DialogBoundMessageConnectionRequest.</summary> 
	public GuiDialog DialogBoundMessageConnectionRequest { get; } = new ("BoundMessageConnectionRequest", "Mail", "connect", () => new BoundMessageConnectionRequest()) {
                IsBoundType = (object data) => data is BoundMessageConnectionRequest
                };

    ///<summary>Dialog DialogBoundMessageGroupInvitation.</summary> 
	public GuiDialog DialogBoundMessageGroupInvitation { get; } = new ("BoundMessageGroupInvitation", "Mail", "groups", () => new BoundMessageGroupInvitation()) {
                IsBoundType = (object data) => data is BoundMessageGroupInvitation
                };

    ///<summary>Dialog DialogBoundMessageTaskRequest.</summary> 
	public GuiDialog DialogBoundMessageTaskRequest { get; } = new ("BoundMessageTaskRequest", "Mail", "task", () => new BoundMessageTaskRequest()) {
                IsBoundType = (object data) => data is BoundMessageTaskRequest
                };

    ///<summary>Dialog DialogBoundDocument.</summary> 
	public GuiDialog DialogBoundDocument { get; } = new ("BoundDocument", "Document", "documents", () => new BoundDocument()) {
                IsBoundType = (object data) => data is BoundDocument
                };

    ///<summary>Dialog DialogBoundGroup.</summary> 
	public GuiDialog DialogBoundGroup { get; } = new ("BoundGroup", "Group", "application_group", () => new BoundGroup()) {
                IsBoundType = (object data) => data is BoundGroup
                };

    ///<summary>Dialog DialogBoundCredential.</summary> 
	public GuiDialog DialogBoundCredential { get; } = new ("BoundCredential", "Passkey", "credentials", () => new BoundCredential()) {
                IsBoundType = (object data) => data is BoundCredential
                };

    ///<summary>Dialog DialogBoundPassword.</summary> 
	public GuiDialog DialogBoundPassword { get; } = new ("BoundPassword", "Password", "password", () => new BoundPassword()) {
                IsBoundType = (object data) => data is BoundPassword
                };

    ///<summary>Dialog DialogBoundPasskey.</summary> 
	public GuiDialog DialogBoundPasskey { get; } = new ("BoundPasskey", "Passkey", "passkey", () => new BoundPasskey()) {
                IsBoundType = (object data) => data is BoundPasskey
                };

    ///<summary>Dialog DialogBoundTask.</summary> 
	public GuiDialog DialogBoundTask { get; } = new ("BoundTask", "Task", "task", () => new BoundTask()) {
                IsBoundType = (object data) => data is BoundTask
                };

    ///<summary>Dialog DialogBoundAppointment.</summary> 
	public GuiDialog DialogBoundAppointment { get; } = new ("BoundAppointment", "Appointment", "task", () => new BoundAppointment()) {
                IsBoundType = (object data) => data is BoundAppointment
                };

    ///<summary>Dialog DialogBoundBookmark.</summary> 
	public GuiDialog DialogBoundBookmark { get; } = new ("BoundBookmark", "Bookmark", "bookmark", () => new BoundBookmark()) {
                IsBoundType = (object data) => data is BoundBookmark
                };

    ///<summary>Dialog DialogBoundFeed.</summary> 
	public GuiDialog DialogBoundFeed { get; } = new ("BoundFeed", "Feed", "feeds", () => new BoundFeed()) {
                IsBoundType = (object data) => data is BoundFeed
                };

    ///<summary>Dialog DialogBoundApplication.</summary> 
	public GuiDialog DialogBoundApplication { get; } = new ("BoundApplication", "Message", "applications", () => new BoundApplication()) {
                IsBoundType = (object data) => data is BoundApplication
                };

    ///<summary>Dialog DialogBoundApplicationMail.</summary> 
	public GuiDialog DialogBoundApplicationMail { get; } = new ("BoundApplicationMail", "Message", "mail", () => new BoundApplicationMail()) {
                IsBoundType = (object data) => data is BoundApplicationMail
                };

    ///<summary>Dialog DialogBoundApplicationSsh.</summary> 
	public GuiDialog DialogBoundApplicationSsh { get; } = new ("BoundApplicationSsh", "Message", "application_ssh", () => new BoundApplicationSsh()) {
                IsBoundType = (object data) => data is BoundApplicationSsh
                };

    ///<summary>Dialog DialogBoundApplicationOpenPgp.</summary> 
	public GuiDialog DialogBoundApplicationOpenPgp { get; } = new ("BoundApplicationOpenPgp", "Message", "application_openpgp", () => new BoundApplicationOpenPgp()) {
                IsBoundType = (object data) => data is BoundApplicationOpenPgp
                };

    ///<summary>Dialog DialogBoundApplicationDeveloper.</summary> 
	public GuiDialog DialogBoundApplicationDeveloper { get; } = new ("BoundApplicationDeveloper", "Message", "application_developer", () => new BoundApplicationDeveloper()) {
                IsBoundType = (object data) => data is BoundApplicationDeveloper
                };

    ///<summary>Dialog DialogBoundApplicationPkix.</summary> 
	public GuiDialog DialogBoundApplicationPkix { get; } = new ("BoundApplicationPkix", "Message", "application_pkix", () => new BoundApplicationPkix()) {
                IsBoundType = (object data) => data is BoundApplicationPkix
                };

    ///<summary>Dialog DialogBoundApplicationGroup.</summary> 
	public GuiDialog DialogBoundApplicationGroup { get; } = new ("BoundApplicationGroup", "Message", "application_group", () => new BoundApplicationGroup()) {
                IsBoundType = (object data) => data is BoundApplicationGroup
                };

    ///<summary>Dialog DialogBoundApplicationCallSign.</summary> 
	public GuiDialog DialogBoundApplicationCallSign { get; } = new ("BoundApplicationCallSign", "Message", "application_callsign", () => new BoundApplicationCallSign()) {
                IsBoundType = (object data) => data is BoundApplicationCallSign
                };

    ///<summary>Dialog DialogBoundDevice.</summary> 
	public GuiDialog DialogBoundDevice { get; } = new ("BoundDevice", "Message", "plug", () => new BoundDevice()) {
                IsBoundType = (object data) => data is BoundDevice
                };

    ///<summary>Dialog DialogAccountUser.</summary> 
	public GuiDialog DialogAccountUser { get; } = new ("AccountUser", "Account", "user", () => new AccountUser()) {
                IsBoundType = (object data) => data is AccountUser
                };

    ///<summary>Dialog DialogBoundContact.</summary> 
	public GuiDialog DialogBoundContact { get; } = new ("BoundContact", "Contact", "contacts", () => new BoundContact()) {
                IsBoundType = (object data) => data is BoundContact
                };

    ///<summary>Dialog DialogBoundContactPerson.</summary> 
	public GuiDialog DialogBoundContactPerson { get; } = new ("BoundContactPerson", "Person", "contacts", () => new BoundContactPerson()) {
                IsBoundType = (object data) => data is BoundContactPerson
                };

    ///<summary>Dialog DialogBoundContactBusiness.</summary> 
	public GuiDialog DialogBoundContactBusiness { get; } = new ("BoundContactBusiness", "Organization", "contacts", () => new BoundContactBusiness()) {
                IsBoundType = (object data) => data is BoundContactBusiness
                };

    ///<summary>Dialog DialogBoundContactPlace.</summary> 
	public GuiDialog DialogBoundContactPlace { get; } = new ("BoundContactPlace", "Place", "contacts", () => new BoundContactPlace()) {
                IsBoundType = (object data) => data is BoundContactPlace
                };

    ///<summary>Dialog DialogContactNetworkAddress.</summary> 
	public GuiDialog DialogContactNetworkAddress { get; } = new ("ContactNetworkAddress", "Network", "protocol_icon", () => new ContactNetworkAddress()) {
                IsBoundType = (object data) => data is ContactNetworkAddress
                };

    ///<summary>Dialog DialogContactPhysicalAddress.</summary> 
	public GuiDialog DialogContactPhysicalAddress { get; } = new ("ContactPhysicalAddress", "Place", "location_pin", () => new ContactPhysicalAddress()) {
                IsBoundType = (object data) => data is ContactPhysicalAddress
                };

#endregion
#region // Results

    ///<summary>Result ResultReportHost.</summary> 
	public GuiResult ResultReportHost { get; } = new ();

    ///<summary>Result ResultReportAccountCreate.</summary> 
	public GuiResult ResultReportAccountCreate { get; } = new ();

    ///<summary>Result ResultReportAccount.</summary> 
	public GuiResult ResultReportAccount { get; } = new ();

    ///<summary>Result ResultReportPending.</summary> 
	public GuiResult ResultReportPending { get; } = new ();

    ///<summary>Result ResultReportShares.</summary> 
	public GuiResult ResultReportShares { get; } = new ();

    ///<summary>Result ResultMessageSentContact.</summary> 
	public GuiResult ResultMessageSentContact { get; } = new ();

    ///<summary>Result ResultMessageSentDevice.</summary> 
	public GuiResult ResultMessageSentDevice { get; } = new ();
	
    ///<summary>Dictionary resolving exception name to factory method.</summary> 
    public Dictionary<string, Func<IResult>> ExceptionDirectory =
        new() { 
                { typeof(HttpRequestException).FullName, () => new HttpRequestFail() } , 
                { typeof(ServerOperationFailed).FullName, () => new ServiceRefused() }             };
#endregion
#region // Constructors
    /// <summary>
    /// Default constructor returning an instance.
    /// </summary>
    public _EverythingMaui () {


	    SectionAccountSection.Gui = this;
	    SectionAccountSection.Active = () => StateAlways;
	    SectionAccountSection.Entries =  new () {  
			new GuiButton ("AccountCreate", ActionAccountCreate), 
			new GuiButton ("AccountRequestConnect", ActionAccountRequestConnect), 
			new GuiButton ("TestService", ActionTestService), 
			new GuiButton ("AccountRecover", ActionAccountRecover), 
			new GuiButton ("AccountGenerateRecovery", ActionAccountGenerateRecovery), 
			new GuiButton ("AccountSwitch", ActionAccountSwitch), 
			new GuiText ("ServiceAddress", "Service Address", 0), 
			new GuiText ("ProfileUdf", "Profile fingerprint", 1), 
			new GuiText ("LocalAddress", "Local Address", 2)		    
            };

	    SectionMessageSection.Gui = this;
	    SectionMessageSection.Active = () => StateDefault;
	    SectionMessageSection.Entries =  new () {  
			new GuiButton ("RequestContact", ActionRequestContact), 
			new GuiButton ("RequestConfirmation", ActionRequestConfirmation), 
			new GuiButton ("CreateMail", ActionCreateMail), 
			new GuiButton ("CreateChat", ActionCreateChat), 
			new GuiButton ("StartVoice", ActionStartVoice), 
			new GuiButton ("StartVideo", ActionStartVideo), 
			new GuiChooser ("ChooseMessage", "Messages", "inbox_messages", 0, new () {
				}) 		    
            };

	    SectionContactSection.Gui = this;
	    SectionContactSection.Active = () => StateDefault;
	    SectionContactSection.Entries =  new () {  
			new GuiButton ("QrContact", ActionQrContact), 
			new GuiButton ("RequestContact", ActionRequestContact), 
			new GuiChooser ("ChooseContact", "Contacts", "contact_other", 0, new () {
				}) 		    
            };

	    SectionDocumentSection.Gui = this;
	    SectionDocumentSection.Active = () => StateDefault;
	    SectionDocumentSection.Entries =  new () {  
			new GuiChooser ("ChooseDocuments", "Documents", "documents", 0, new () {
				}) 		    
            };

	    SectionFeedSection.Gui = this;
	    SectionFeedSection.Active = () => StateDefault;
	    SectionFeedSection.Entries =  new () {  
			new GuiChooser ("ChooseFeed", "Feeds", "feeds", 0, new () {
				}) 		    
            };

	    SectionGroupSection.Gui = this;
	    SectionGroupSection.Active = () => StateDefault;
	    SectionGroupSection.Entries =  new () {  
			new GuiChooser ("ChooseGroup", "User", "account_group", 0, new () {
				}) 		    
            };

	    SectionCredentialSection.Gui = this;
	    SectionCredentialSection.Active = () => StateDefault;
	    SectionCredentialSection.Entries =  new () {  
			new GuiChooser ("ChooseCredential", "Credentials", "credentials", 0, new () {
				}) 		    
            };

	    SectionTaskSection.Gui = this;
	    SectionTaskSection.Active = () => StateDefault;
	    SectionTaskSection.Entries =  new () {  
			new GuiChooser ("ChooseTask", "Tasks", "Tasks", 0, new () {
				}) 		    
            };

	    SectionCalendarSection.Gui = this;
	    SectionCalendarSection.Active = () => StateDefault;
	    SectionCalendarSection.Entries =  new () {  
			new GuiChooser ("ChooseAppointment", "Tasks", "Tasks", 0, new () {
				}) 		    
            };

	    SectionBookmarkSection.Gui = this;
	    SectionBookmarkSection.Active = () => StateDefault;
	    SectionBookmarkSection.Entries =  new () {  
			new GuiChooser ("ChooseBookmark", "Bookmark", "Bookmark", 0, new () {
				}) 		    
            };

	    SectionApplicationSection.Gui = this;
	    SectionApplicationSection.Active = () => StateDefault;
	    SectionApplicationSection.Entries =  new () {  
			new GuiButton ("AddMailAccount", ActionAddMailAccount), 
			new GuiButton ("AddSshAccount", ActionAddSshAccount), 
			new GuiButton ("AddGitAccount", ActionAddGitAccount), 
			new GuiButton ("AddCodeSigningKey", ActionAddCodeSigningKey), 
			new GuiChooser ("ChooseApplication", "Applications", "Applications", 0, new () {
				}) 		    
            };

	    SectionDeviceSection.Gui = this;
	    SectionDeviceSection.Active = () => StateDefault;
	    SectionDeviceSection.Entries =  new () {  
			new GuiButton ("DeviceConnectQR", ActionDeviceConnectQR), 
			new GuiButton ("AccountGetPin", ActionAccountGetPin), 
			new GuiChooser ("ChooseDevice", "Devices", "Devices", 0, new () {
				}) 		    
            };

	    SectionServiceSection.Gui = this;
	    SectionServiceSection.Active = () => StateDefault;
	    SectionServiceSection.Entries =  new () {  
			new GuiChooser ("ChooseService", "Services", "account_service.png", 0, new () {
				}) 		    
            };

	    SectionSettingSection.Gui = this;
	    SectionSettingSection.Active = () => StateAlways;
	    SectionSettingSection.Entries =  new () {  
		    
            };

	    SectionAppearance.Gui = this;
	    SectionAppearance.Active = () => StateDefault;
	    SectionAppearance.Entries =  new () {  
			new GuiColor ("BackgroundColor", "Background Color"), 
			new GuiColor ("HighlightColor", "Highlight Color"), 
			new GuiColor ("TextColor", "Text Color"), 
			new GuiSize ("TextSize", "Text Size"), 
			new GuiSize ("IconSize", "Icon Size")		    
            };


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
		    SectionSettingSection, 
		    SectionAppearance
            };

#endregion
#region // Initialize Actions
        ActionTestService.Callback = (x) => TestService (x as TestService) ;
	    ActionTestService.Entries = new () { 
			new GuiText ("ServiceAddress", "Service address", 0)
		    };

        ActionAccountCreate.Callback = (x) => AccountCreate (x as AccountCreate) ;
	    ActionAccountCreate.Entries = new () { 
			new GuiText ("ServiceAddress", "Account service address", 0), 
			new GuiText ("ContactName", "Contact Name  (optional)", 1), 
			new GuiText ("LocalName", "Friendly name (optional)", 2), 
			new GuiText ("Coupon", "Activation code (if provided)", 3)
		    };

        ActionAccountRequestConnect.Callback = (x) => AccountRequestConnect (x as AccountRequestConnect) ;
	    ActionAccountRequestConnect.Entries = new () { 
			new GuiText ("ConnectionString", "Account address", 0), 
			new GuiText ("ConnectionPin", "Activation code (if provided)", 1), 
			new GuiText ("Rights", "Requested rights", 2)
		    };

        ActionDeviceConnectQR.Callback = (x) => DeviceConnectQR (x as DeviceConnectQR) ;
	    ActionDeviceConnectQR.Entries = new () { 
			new GuiQRScan ("QrCode", "Contact QR", 0), 
			new GuiText ("LocalName", "Friendly name (optional)", 1), 
			new GuiText ("Rights", "Assigned rights", 2)
		    };

        ActionAccountGetPin.Callback = (x) => AccountGetPin (x as AccountGetPin) ;
	    ActionAccountGetPin.Entries = new () { 
			new GuiText ("Rights", "Assigned rights", 0), 
			new GuiInteger ("Security", "Security level", 1), 
			new GuiInteger ("Expire", "Expiry in hours", 2)
		    };

        ActionAccountRecover.Callback = (x) => AccountRecover (x as AccountRecover) ;
	    ActionAccountRecover.Entries = new () { 
			new GuiText ("ServiceAddress", "Account service address", 0), 
			new GuiText ("LocalName", "Friendly name (optional)", 1), 
			new GuiText ("Coupon", "Activation code (if provided)", 2), 
			new GuiText ("Share1", "Recovery share", 3), 
			new GuiText ("Share2", "Recovery share", 4), 
			new GuiText ("Share3", "Recovery share", 5), 
			new GuiText ("Share4", "Recovery share", 6), 
			new GuiText ("Share5", "Recovery share", 7), 
			new GuiText ("Share6", "Recovery share", 8), 
			new GuiText ("Share7", "Recovery share", 9), 
			new GuiText ("Share8", "Recovery share", 10)
		    };

        ActionAccountDelete.Callback = (x) => AccountDelete (x as AccountDelete) ;
	    ActionAccountDelete.Entries = new () {
		    };

        ActionAccountSwitch.Callback = (x) => AccountSwitch (x as AccountSwitch) ;
	    ActionAccountSwitch.Entries = new () { 
			new GuiChooser ("ChooseUser", "User", "account_user", 0, new () {
				}) 
		    };

        ActionAccountGenerateRecovery.Callback = (x) => AccountGenerateRecovery (x as AccountGenerateRecovery) ;
	    ActionAccountGenerateRecovery.Entries = new () { 
			new GuiInteger ("NumberShares", "Total number of shares", 0), 
			new GuiInteger ("Quorum", "Quorum required for recovery", 1)
		    };

        ActionRequestContact.Callback = (x) => RequestContact (x as RequestContact) ;
	    ActionRequestContact.Entries = new () { 
			new GuiText ("Recipient", "Address", 0), 
			new GuiText ("Message", "Message", 1)
		    };

        ActionQrContact.Callback = (x) => QrContact (x as QrContact) ;
	    ActionQrContact.Entries = new () { 
			new GuiQRScan ("QrCode", "Contact QR", 0)
		    };

        ActionRequestConfirmation.Callback = (x) => RequestConfirmation (x as RequestConfirmation) ;
	    ActionRequestConfirmation.Entries = new () { 
			new GuiText ("Recipient", "Address", 0), 
			new GuiText ("Message", "Message", 1)
		    };

        ActionCreateMail.Callback = (x) => CreateMail (x as CreateMail) ;
	    ActionCreateMail.Entries = new () { 
			new GuiText ("Recipient", "Address", 0), 
			new GuiText ("Subject", "Subject", 1), 
			new GuiTextArea ("Message", "Message", 2)
		    };

        ActionCreateChat.Callback = (x) => CreateChat (x as CreateChat) ;
	    ActionCreateChat.Entries = new () {
		    };

        ActionStartVoice.Callback = (x) => StartVoice (x as StartVoice) ;
	    ActionStartVoice.Entries = new () {
		    };

        ActionStartVideo.Callback = (x) => StartVideo (x as StartVideo) ;
	    ActionStartVideo.Entries = new () {
		    };

        ActionSendDocument.Callback = (x) => SendDocument (x as SendDocument) ;
	    ActionSendDocument.Entries = new () {
		    };

        ActionShareDocument.Callback = (x) => ShareDocument (x as ShareDocument) ;
	    ActionShareDocument.Entries = new () {
		    };

        ActionAddMailAccount.Callback = (x) => AddMailAccount (x as AddMailAccount) ;
	    ActionAddMailAccount.Entries = new () {
		    };

        ActionAddSshAccount.Callback = (x) => AddSshAccount (x as AddSshAccount) ;
	    ActionAddSshAccount.Entries = new () {
		    };

        ActionAddGitAccount.Callback = (x) => AddGitAccount (x as AddGitAccount) ;
	    ActionAddGitAccount.Entries = new () {
		    };

        ActionAddCodeSigningKey.Callback = (x) => AddCodeSigningKey (x as AddCodeSigningKey) ;
	    ActionAddCodeSigningKey.Entries = new () {
		    };


        Actions = new List<GuiAction>() {  
		    ActionTestService, 
		    ActionAccountCreate, 
		    ActionAccountRequestConnect, 
		    ActionDeviceConnectQR, 
		    ActionAccountGetPin, 
		    ActionAccountRecover, 
		    ActionAccountDelete, 
		    ActionAccountSwitch, 
		    ActionAccountGenerateRecovery, 
		    ActionRequestContact, 
		    ActionQrContact, 
		    ActionRequestConfirmation, 
		    ActionCreateMail, 
		    ActionCreateChat, 
		    ActionStartVoice, 
		    ActionStartVideo, 
		    ActionSendDocument, 
		    ActionShareDocument, 
		    ActionAddMailAccount, 
		    ActionAddSshAccount, 
		    ActionAddGitAccount, 
		    ActionAddCodeSigningKey
		    };

#endregion

#region // Initialize Selections
        SelectionConfirmationAccept.Callback = (x) => ConfirmationAccept (x as BoundMessageConfirmationRequest) ;
	    SelectionConfirmationAccept.Entries = new () {
		    };

        SelectionConfirmationReject.Callback = (x) => ConfirmationReject (x as BoundMessageConfirmationRequest) ;
	    SelectionConfirmationReject.Entries = new () {
		    };

        SelectionContactAccept.Callback = (x) => ContactAccept (x as BoundMessageContactRequest) ;
	    SelectionContactAccept.Entries = new () {
		    };

        SelectionContactReject.Callback = (x) => ContactReject (x as BoundMessageContactRequest) ;
	    SelectionContactReject.Entries = new () {
		    };

        SelectionConnectAccept.Callback = (x) => ConnectAccept (x as BoundMessageConnectionRequest) ;
	    SelectionConnectAccept.Entries = new () {
		    };

        SelectionConnectReject.Callback = (x) => ConnectReject (x as BoundMessageConnectionRequest) ;
	    SelectionConnectReject.Entries = new () {
		    };

        SelectionGroupAccept.Callback = (x) => GroupAccept (x as BoundMessageGroupInvitation) ;
	    SelectionGroupAccept.Entries = new () {
		    };

        SelectionGroupReject.Callback = (x) => GroupReject (x as BoundMessageGroupInvitation) ;
	    SelectionGroupReject.Entries = new () {
		    };

        SelectionTaskAccept.Callback = (x) => TaskAccept (x as BoundMessageTaskRequest) ;
	    SelectionTaskAccept.Entries = new () {
		    };

        SelectionTaskReject.Callback = (x) => TaskReject (x as BoundMessageTaskRequest) ;
	    SelectionTaskReject.Entries = new () {
		    };


        Selections = new List<GuiAction>() {  
		    SelectionConfirmationAccept, 
		    SelectionConfirmationReject, 
		    SelectionContactAccept, 
		    SelectionContactReject, 
		    SelectionConnectAccept, 
		    SelectionConnectReject, 
		    SelectionGroupAccept, 
		    SelectionGroupReject, 
		    SelectionTaskAccept, 
		    SelectionTaskReject
		    };

#endregion

#region // Initialize Dialogs
	    DialogBoundAccount.Entries = new () { 
			new GuiText ("Display", "Display name", 0), 
			new GuiText ("Service", "Service", 1), 
			new GuiText ("UDF", "Fingerprint", 2)			
		    };

        BoundAccount.IsBacker = (object data) => DialogBoundAccount.IsBacker(data);
	    DialogBoundMessage.Entries = new () { 
			new GuiIcon ("Type", "Type"), 
			new GuiText ("Subject", "Subject", 1), 
			new GuiText ("TimeSent", "Sent", 2), 
			new GuiText ("Sender", "Sender", 3)			
		    };

        BoundMessage.IsBacker = (object data) => DialogBoundMessage.IsBacker(data);
	    DialogBoundMailMail.Entries = new () { 
			new GuiIcon ("Type", "Type"), 
			new GuiText ("Subject", "Subject", 1), 
			new GuiText ("TimeSent", "Sent", 2), 
			new GuiText ("Sender", "Sender", 3), 
			new GuiTextArea ("Message", "Message", 4)			
		    };

        BoundMailMail.IsBacker = (object data) => DialogBoundMailMail.IsBacker(data);
	    DialogBoundMessageConfirmationRequest.Entries = new () { 
			new GuiIcon ("Type", "Type"), 
			new GuiText ("Subject", "Subject", 1), 
			new GuiText ("TimeSent", "Sent", 2), 
			new GuiText ("Sender", "Sender", 3), 
			new GuiText ("RequestMessage", "Request", 4), 
			new GuiButton ("ConfirmationAccept", SelectionConfirmationAccept), 
			new GuiButton ("ConfirmationReject", SelectionConfirmationReject)			
		    };

        BoundMessageConfirmationRequest.IsBacker = (object data) => DialogBoundMessageConfirmationRequest.IsBacker(data);
	    DialogBoundMessageConfirmationResponse.Entries = new () { 
			new GuiIcon ("Type", "Type"), 
			new GuiText ("Subject", "Subject", 1), 
			new GuiText ("TimeSent", "Sent", 2), 
			new GuiText ("Sender", "Sender", 3)			
		    };

        BoundMessageConfirmationResponse.IsBacker = (object data) => DialogBoundMessageConfirmationResponse.IsBacker(data);
	    DialogBoundMessageContactRequest.Entries = new () { 
			new GuiIcon ("Type", "Type"), 
			new GuiText ("Subject", "Subject", 1), 
			new GuiText ("TimeSent", "Sent", 2), 
			new GuiText ("Sender", "Sender", 3), 
			new GuiButton ("ContactAccept", SelectionContactAccept), 
			new GuiButton ("ContactReject", SelectionContactReject)			
		    };

        BoundMessageContactRequest.IsBacker = (object data) => DialogBoundMessageContactRequest.IsBacker(data);
	    DialogBoundMessageConnectionRequest.Entries = new () { 
			new GuiIcon ("Type", "Type"), 
			new GuiText ("Subject", "Subject", 1), 
			new GuiText ("TimeSent", "Sent", 2), 
			new GuiText ("Sender", "Sender", 3), 
			new GuiText ("RequestMessage", "Request", 4), 
			new GuiButton ("ConnectAccept", SelectionConnectAccept), 
			new GuiButton ("ConnectReject", SelectionConnectReject)			
		    };

        BoundMessageConnectionRequest.IsBacker = (object data) => DialogBoundMessageConnectionRequest.IsBacker(data);
	    DialogBoundMessageGroupInvitation.Entries = new () { 
			new GuiIcon ("Type", "Type"), 
			new GuiText ("Subject", "Subject", 1), 
			new GuiText ("TimeSent", "Sent", 2), 
			new GuiText ("Sender", "Sender", 3), 
			new GuiButton ("GroupAccept", SelectionGroupAccept), 
			new GuiButton ("GroupReject", SelectionGroupReject)			
		    };

        BoundMessageGroupInvitation.IsBacker = (object data) => DialogBoundMessageGroupInvitation.IsBacker(data);
	    DialogBoundMessageTaskRequest.Entries = new () { 
			new GuiIcon ("Type", "Type"), 
			new GuiText ("Subject", "Subject", 1), 
			new GuiText ("TimeSent", "Sent", 2), 
			new GuiText ("Sender", "Sender", 3), 
			new GuiButton ("TaskAccept", SelectionTaskAccept), 
			new GuiButton ("TaskReject", SelectionTaskReject)			
		    };

        BoundMessageTaskRequest.IsBacker = (object data) => DialogBoundMessageTaskRequest.IsBacker(data);
	    DialogBoundDocument.Entries = new () { 
			new GuiIcon ("Type", "Type"), 
			new GuiText ("FileType", "Type", 1), 
			new GuiText ("Filename", "File name", 2)			
		    };

        BoundDocument.IsBacker = (object data) => DialogBoundDocument.IsBacker(data);
	    DialogBoundGroup.Entries = new () { 
			new GuiText ("Display", "Display name", 0)			
		    };

        BoundGroup.IsBacker = (object data) => DialogBoundGroup.IsBacker(data);
	    DialogBoundCredential.Entries = new () { 
			new GuiIcon ("Type", "Type"), 
			new GuiText ("Protocol", "Protocol", 1), 
			new GuiText ("Service", "Service", 2), 
			new GuiText ("Username", "Username", 3)			
		    };

        BoundCredential.IsBacker = (object data) => DialogBoundCredential.IsBacker(data);
	    DialogBoundPassword.Entries = new () { 
			new GuiIcon ("Type", "Type"), 
			new GuiText ("Protocol", "Protocol", 1), 
			new GuiText ("Service", "Service", 2), 
			new GuiText ("Username", "Username", 3), 
			new GuiText ("Password", "Password", 4)			
		    };

        BoundPassword.IsBacker = (object data) => DialogBoundPassword.IsBacker(data);
	    DialogBoundPasskey.Entries = new () { 
			new GuiIcon ("Type", "Type"), 
			new GuiText ("Protocol", "Protocol", 1), 
			new GuiText ("Service", "Service", 2), 
			new GuiText ("Username", "Username", 3)			
		    };

        BoundPasskey.IsBacker = (object data) => DialogBoundPasskey.IsBacker(data);
	    DialogBoundTask.Entries = new () { 
			new GuiIcon ("Type", "Type"), 
			new GuiText ("Title", "Title", 1)			
		    };

        BoundTask.IsBacker = (object data) => DialogBoundTask.IsBacker(data);
	    DialogBoundAppointment.Entries = new () { 
			new GuiText ("Display", "Display name", 0)			
		    };

        BoundAppointment.IsBacker = (object data) => DialogBoundAppointment.IsBacker(data);
	    DialogBoundBookmark.Entries = new () { 
			new GuiIcon ("Type", "Type"), 
			new GuiText ("Title", "Title", 1), 
			new GuiText ("Uri", "Link", 2), 
			new GuiText ("Comments", "Comments", 3)			
		    };

        BoundBookmark.IsBacker = (object data) => DialogBoundBookmark.IsBacker(data);
	    DialogBoundFeed.Entries = new () { 
			new GuiIcon ("Type", "Type"), 
			new GuiText ("Title", "Title", 1), 
			new GuiText ("Uri", "Link", 2), 
			new GuiText ("Comments", "Comments", 3), 
			new GuiText ("Protocol", "Protocol", 4)			
		    };

        BoundFeed.IsBacker = (object data) => DialogBoundFeed.IsBacker(data);
	    DialogBoundApplication.Entries = new () { 
			new GuiText ("Display", "Display name", 0)			
		    };

        BoundApplication.IsBacker = (object data) => DialogBoundApplication.IsBacker(data);
	    DialogBoundApplicationMail.Entries = new () { 
			new GuiText ("Display", "Display name", 0)			
		    };

        BoundApplicationMail.IsBacker = (object data) => DialogBoundApplicationMail.IsBacker(data);
	    DialogBoundApplicationSsh.Entries = new () { 
			new GuiText ("Display", "Display name", 0)			
		    };

        BoundApplicationSsh.IsBacker = (object data) => DialogBoundApplicationSsh.IsBacker(data);
	    DialogBoundApplicationOpenPgp.Entries = new () { 
			new GuiText ("Display", "Display name", 0)			
		    };

        BoundApplicationOpenPgp.IsBacker = (object data) => DialogBoundApplicationOpenPgp.IsBacker(data);
	    DialogBoundApplicationDeveloper.Entries = new () { 
			new GuiText ("Display", "Display name", 0)			
		    };

        BoundApplicationDeveloper.IsBacker = (object data) => DialogBoundApplicationDeveloper.IsBacker(data);
	    DialogBoundApplicationPkix.Entries = new () { 
			new GuiText ("Display", "Display name", 0)			
		    };

        BoundApplicationPkix.IsBacker = (object data) => DialogBoundApplicationPkix.IsBacker(data);
	    DialogBoundApplicationGroup.Entries = new () { 
			new GuiText ("Display", "Display name", 0)			
		    };

        BoundApplicationGroup.IsBacker = (object data) => DialogBoundApplicationGroup.IsBacker(data);
	    DialogBoundApplicationCallSign.Entries = new () { 
			new GuiText ("Display", "Display name", 0)			
		    };

        BoundApplicationCallSign.IsBacker = (object data) => DialogBoundApplicationCallSign.IsBacker(data);
	    DialogBoundDevice.Entries = new () { 
			new GuiIcon ("Type", "Type"), 
			new GuiText ("DeviceType", "Platform", 1), 
			new GuiText ("Rights", "Rights", 2), 
			new GuiText ("LocalName", "Name", 3), 
			new GuiText ("Udf", "Udf", 4)			
		    };

        BoundDevice.IsBacker = (object data) => DialogBoundDevice.IsBacker(data);
	    DialogAccountUser.Entries = new () { 
			new GuiText ("Udf", "Fingerprint", 0), 
			new GuiText ("ServiceAddress", "Account service address", 1), 
			new GuiText ("Local", "Friendly name", 2), 
			new GuiText ("Description", "Description", 3), 
			new GuiChooser ("UserChooseDevice", "Devices", "device", 4, new () {
				}) 			
		    };

        AccountUser.IsBacker = (object data) => DialogAccountUser.IsBacker(data);
	    DialogBoundContact.Entries = new () { 
			new GuiIcon ("Type", "Type"), 
			new GuiText ("Display", "Display name", 1)			
		    };

        BoundContact.IsBacker = (object data) => DialogBoundContact.IsBacker(data);
	    DialogBoundContactPerson.Entries = new () { 
			new GuiBoolean ("Self", "Self", 0), 
			new GuiIcon ("Type", "Type"), 
			new GuiText ("Display", "Display name", 1), 
			new GuiText ("Local", "Friendly name", 3), 
			new GuiText ("First", "First name", 4), 
			new GuiText ("Last", "Last name", 5), 
			new GuiText ("Prefix", "Prefix", 6), 
			new GuiText ("Suffix", "Suffix", 7), 
			new GuiList ("NetworkAddresses", "Network Addresses", "network", DialogContactNetworkAddress, 8, new () {
				}) , 
			new GuiList ("PhysicalAddresses", "Locations", "location", DialogContactPhysicalAddress, 9, new () {
				}) 			
		    };

        BoundContactPerson.IsBacker = (object data) => DialogBoundContactPerson.IsBacker(data);
	    DialogBoundContactBusiness.Entries = new () { 
			new GuiIcon ("Type", "Type"), 
			new GuiText ("Display", "Display name", 1)			
		    };

        BoundContactBusiness.IsBacker = (object data) => DialogBoundContactBusiness.IsBacker(data);
	    DialogBoundContactPlace.Entries = new () { 
			new GuiIcon ("Type", "Type"), 
			new GuiText ("Display", "Display name", 1)			
		    };

        BoundContactPlace.IsBacker = (object data) => DialogBoundContactPlace.IsBacker(data);
	    DialogContactNetworkAddress.Entries = new () { 
			new GuiIcon ("Type", "Type"), 
			new GuiText ("Protocol", "Protocol", 1), 
			new GuiText ("Address", "Address", 2), 
			new GuiText ("Fingerprint", "Fingerprint", 3)			
		    };

        ContactNetworkAddress.IsBacker = (object data) => DialogContactNetworkAddress.IsBacker(data);
	    DialogContactPhysicalAddress.Entries = new () { 
			new GuiText ("Appartment", "Appartment", 0), 
			new GuiText ("Street", "Street", 1), 
			new GuiText ("District", "District", 2), 
			new GuiText ("Region", "Region", 3), 
			new GuiText ("Code", "Postcode", 4), 
			new GuiText ("Country", "Country", 5), 
			new GuiDecimal ("Latitude", "Latitude"), 
			new GuiDecimal ("Longitude", "Longitude")			
		    };

        ContactPhysicalAddress.IsBacker = (object data) => DialogContactPhysicalAddress.IsBacker(data);

        Dialogs = new List<GuiDialog>() {  
		    DialogBoundAccount, 
		    DialogBoundMessage, 
		    DialogBoundMailMail, 
		    DialogBoundMessageConfirmationRequest, 
		    DialogBoundMessageConfirmationResponse, 
		    DialogBoundMessageContactRequest, 
		    DialogBoundMessageConnectionRequest, 
		    DialogBoundMessageGroupInvitation, 
		    DialogBoundMessageTaskRequest, 
		    DialogBoundDocument, 
		    DialogBoundGroup, 
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
		    DialogBoundDevice, 
		    DialogAccountUser, 
		    DialogBoundContact, 
		    DialogBoundContactPerson, 
		    DialogBoundContactBusiness, 
		    DialogBoundContactPlace, 
		    DialogContactNetworkAddress, 
		    DialogContactPhysicalAddress
		    };

#endregion
#region // Initialize Results
	    ResultReportHost.Entries = new () { 
			new GuiText ("ServiceCallsign", "Callsign", 0), 
			new GuiText ("ServiceDns", "DNS", 1), 
			new GuiText ("ServiceUdf", "Service fingerprint", 2), 
			new GuiText ("HostUdf", "Host fingerprint", 3)			
		    };

	    ResultReportAccountCreate.Entries = new () { 
			new GuiText ("LocalName", "Local", 0), 
			new GuiText ("ServiceAddress", "DNS", 1), 
			new GuiText ("ProfileUdf", "Profile fingerprint", 2), 
			new GuiText ("ServiceUdf", "Service fingerprint", 3)			
		    };

	    ResultReportAccount.Entries = new () { 
			new GuiText ("LocalName", "Local", 0), 
			new GuiText ("ServiceCallsign", "Callsign", 1), 
			new GuiText ("ServiceAddress", "DNS", 2), 
			new GuiText ("ProfileUdf", "Profile fingerprint", 3), 
			new GuiText ("ServiceUdf", "Service fingerprint", 4)			
		    };

	    ResultReportPending.Entries = new () { 
			new GuiText ("LocalName", "Local", 0), 
			new GuiText ("ServiceCallsign", "Callsign", 1), 
			new GuiText ("ServiceAddress", "DNS", 2), 
			new GuiText ("ServiceUdf", "Service fingerprint", 3), 
			new GuiText ("ServiceMessage", "Message", 4)			
		    };

	    ResultReportShares.Entries = new () { 
			new GuiText ("Share1", "Recovery share", 0), 
			new GuiText ("Share2", "Recovery share", 1), 
			new GuiText ("Share3", "Recovery share", 2), 
			new GuiText ("Share4", "Recovery share", 3), 
			new GuiText ("Share5", "Recovery share", 4), 
			new GuiText ("Share6", "Recovery share", 5), 
			new GuiText ("Share7", "Recovery share", 6), 
			new GuiText ("Share8", "Recovery share", 7)			
		    };

	    ResultMessageSentContact.Entries = new () { 
			new GuiText ("AccountName", "Account", 0), 
			new GuiText ("Identifier", "Identifier", 1)			
		    };

	    ResultMessageSentDevice.Entries = new () { 
			new GuiText ("AccountName", "Account", 0), 
			new GuiText ("Identifier", "Identifier", 1)			
		    };



        Results = new List<GuiResult>() {  
		    ResultReportHost, 
		    ResultReportAccountCreate, 
		    ResultReportAccount, 
		    ResultReportPending, 
		    ResultReportShares, 
		    ResultMessageSentContact, 
		    ResultMessageSentDevice
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
    public virtual Task<IResult> SendDocument (SendDocument data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> ShareDocument (ShareDocument data) 
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
    public virtual Task<IResult> ConfirmationAccept (BoundMessageConfirmationRequest data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> ConfirmationReject (BoundMessageConfirmationRequest data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> ContactAccept (BoundMessageContactRequest data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> ContactReject (BoundMessageContactRequest data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> ConnectAccept (BoundMessageConnectionRequest data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> ConnectReject (BoundMessageConnectionRequest data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> GroupAccept (BoundMessageGroupInvitation data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> GroupReject (BoundMessageGroupInvitation data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> TaskAccept (BoundMessageTaskRequest data) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> TaskReject (BoundMessageTaskRequest data) 
                => throw new NYI();

#endregion
#region // Initialize Bindings

#endregion
	}

#endregion
