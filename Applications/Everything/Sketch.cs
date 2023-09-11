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
/// Callback parameters for section Account 
/// </summary>
public partial class Account : _Account {
    }

/// <summary>
/// Callback parameters for section Account 
/// </summary>
public partial class _Account : IBindable {

        ///<summary></summary> 
    public virtual string ServiceAddress { get;} 

        ///<summary></summary> 
    public virtual string ProfileUdf { get;} 

        ///<summary></summary> 
    public virtual string LocalAddress { get;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _Account,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _Account).ServiceAddress, null, "ServiceAddress"), 
            new GuiBoundPropertyString ((object data) => (data as _Account).ProfileUdf, null, "ProfileUdf"), 
            new GuiBoundPropertyString ((object data) => (data as _Account).LocalAddress, null, "LocalAddress")
            });

    }

/// <summary>
/// Callback parameters for section Messages 
/// </summary>
public partial class Messages : _Messages {
    }

/// <summary>
/// Callback parameters for section Messages 
/// </summary>
public partial class _Messages : IBindable {

        ///<summary></summary> 
    public virtual ISelectCollection ChooseMessage { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _Messages,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _Messages).ChooseMessage, (object data,ISelectCollection value) => (data as _Messages).ChooseMessage = value, "ChooseMessage")
            });

    }

/// <summary>
/// Callback parameters for section Contacts 
/// </summary>
public partial class Contacts : _Contacts {
    }

/// <summary>
/// Callback parameters for section Contacts 
/// </summary>
public partial class _Contacts : IBindable {

        ///<summary></summary> 
    public virtual ISelectCollection ChooseContact { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _Contacts,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _Contacts).ChooseContact, (object data,ISelectCollection value) => (data as _Contacts).ChooseContact = value, "ChooseContact")
            });

    }

/// <summary>
/// Callback parameters for section Documents 
/// </summary>
public partial class Documents : _Documents {
    }

/// <summary>
/// Callback parameters for section Documents 
/// </summary>
public partial class _Documents : IBindable {

        ///<summary></summary> 
    public virtual ISelectCollection ChooseDocuments { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _Documents,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _Documents).ChooseDocuments, (object data,ISelectCollection value) => (data as _Documents).ChooseDocuments = value, "ChooseDocuments")
            });

    }

/// <summary>
/// Callback parameters for section Groups 
/// </summary>
public partial class Groups : _Groups {
    }

/// <summary>
/// Callback parameters for section Groups 
/// </summary>
public partial class _Groups : IBindable {

        ///<summary></summary> 
    public virtual ISelectCollection ChooseGroup { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _Groups,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _Groups).ChooseGroup, (object data,ISelectCollection value) => (data as _Groups).ChooseGroup = value, "ChooseGroup")
            });

    }

/// <summary>
/// Callback parameters for section Feeds 
/// </summary>
public partial class Feeds : _Feeds {
    }

/// <summary>
/// Callback parameters for section Feeds 
/// </summary>
public partial class _Feeds : IBindable {

        ///<summary></summary> 
    public virtual ISelectCollection ChooseFeed { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _Feeds,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _Feeds).ChooseFeed, (object data,ISelectCollection value) => (data as _Feeds).ChooseFeed = value, "ChooseFeed")
            });

    }

/// <summary>
/// Callback parameters for section Credentials 
/// </summary>
public partial class Credentials : _Credentials {
    }

/// <summary>
/// Callback parameters for section Credentials 
/// </summary>
public partial class _Credentials : IBindable {

        ///<summary></summary> 
    public virtual ISelectCollection ChooseCredential { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _Credentials,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _Credentials).ChooseCredential, (object data,ISelectCollection value) => (data as _Credentials).ChooseCredential = value, "ChooseCredential")
            });

    }

/// <summary>
/// Callback parameters for section Tasks 
/// </summary>
public partial class Tasks : _Tasks {
    }

/// <summary>
/// Callback parameters for section Tasks 
/// </summary>
public partial class _Tasks : IBindable {

        ///<summary></summary> 
    public virtual ISelectCollection ChooseTask { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _Tasks,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _Tasks).ChooseTask, (object data,ISelectCollection value) => (data as _Tasks).ChooseTask = value, "ChooseTask")
            });

    }

/// <summary>
/// Callback parameters for section Calendar 
/// </summary>
public partial class Calendar : _Calendar {
    }

/// <summary>
/// Callback parameters for section Calendar 
/// </summary>
public partial class _Calendar : IBindable {

        ///<summary></summary> 
    public virtual ISelectCollection ChooseAppointment { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _Calendar,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _Calendar).ChooseAppointment, (object data,ISelectCollection value) => (data as _Calendar).ChooseAppointment = value, "ChooseAppointment")
            });

    }

/// <summary>
/// Callback parameters for section Bookmark 
/// </summary>
public partial class Bookmark : _Bookmark {
    }

/// <summary>
/// Callback parameters for section Bookmark 
/// </summary>
public partial class _Bookmark : IBindable {

        ///<summary></summary> 
    public virtual ISelectCollection ChooseBookmark { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _Bookmark,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _Bookmark).ChooseBookmark, (object data,ISelectCollection value) => (data as _Bookmark).ChooseBookmark = value, "ChooseBookmark")
            });

    }

/// <summary>
/// Callback parameters for section Applications 
/// </summary>
public partial class Applications : _Applications {
    }

/// <summary>
/// Callback parameters for section Applications 
/// </summary>
public partial class _Applications : IBindable {

        ///<summary></summary> 
    public virtual ISelectCollection ChooseApplication { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _Applications,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _Applications).ChooseApplication, (object data,ISelectCollection value) => (data as _Applications).ChooseApplication = value, "ChooseApplication")
            });

    }

/// <summary>
/// Callback parameters for section Devices 
/// </summary>
public partial class Devices : _Devices {
    }

/// <summary>
/// Callback parameters for section Devices 
/// </summary>
public partial class _Devices : IBindable {

        ///<summary></summary> 
    public virtual ISelectCollection ChooseDevice { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _Devices,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _Devices).ChooseDevice, (object data,ISelectCollection value) => (data as _Devices).ChooseDevice = value, "ChooseDevice")
            });

    }

/// <summary>
/// Callback parameters for section Services 
/// </summary>
public partial class Services : _Services {
    }

/// <summary>
/// Callback parameters for section Services 
/// </summary>
public partial class _Services : IBindable {

        ///<summary></summary> 
    public virtual ISelectCollection ChooseService { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _Services,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _Services).ChooseService, (object data,ISelectCollection value) => (data as _Services).ChooseService = value, "ChooseService")
            });

    }

/// <summary>
/// Callback parameters for section Settings 
/// </summary>
public partial class Settings : _Settings {
    }

/// <summary>
/// Callback parameters for section Settings 
/// </summary>
public partial class _Settings : IBindable {


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _Settings,
        new GuiBoundProperty[] {
            });

    }



/// <summary>
/// Callback parameters for dialog Appearance 
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


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _Appearance,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyColor ((object data) => (data as _Appearance).BackgroundColor, (object data,IFieldColor value) => (data as _Appearance).BackgroundColor = value, "BackgroundColor"), 
            new GuiBoundPropertyColor ((object data) => (data as _Appearance).HighlightColor, (object data,IFieldColor value) => (data as _Appearance).HighlightColor = value, "HighlightColor"), 
            new GuiBoundPropertyColor ((object data) => (data as _Appearance).TextColor, (object data,IFieldColor value) => (data as _Appearance).TextColor = value, "TextColor"), 
            new GuiBoundPropertySize ((object data) => (data as _Appearance).TextSize, (object data,IFieldSize value) => (data as _Appearance).TextSize = value, "TextSize"), 
            new GuiBoundPropertySize ((object data) => (data as _Appearance).IconSize, (object data,IFieldSize value) => (data as _Appearance).IconSize = value, "IconSize")
            });

    }

/// <summary>
/// Callback parameters for dialog AccountUser 
/// </summary>
public partial class AccountUser : _AccountUser {
    }

/// <summary>
/// Callback parameters for section AccountUser 
/// </summary>
public partial class _AccountUser : IBindable {

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


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _AccountUser,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _AccountUser).Udf, (object data,string value) => (data as _AccountUser).Udf = value, "Udf"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountUser).ServiceAddress, (object data,string value) => (data as _AccountUser).ServiceAddress = value, "ServiceAddress"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountUser).Local, (object data,string value) => (data as _AccountUser).Local = value, "Local"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountUser).Description, (object data,string value) => (data as _AccountUser).Description = value, "Description"), 
            new GuiBoundPropertyChooser ((object data) => (data as _AccountUser).UserChooseDevice, (object data,ISelectCollection value) => (data as _AccountUser).UserChooseDevice = value, "UserChooseDevice")
            });

    }

/// <summary>
/// Callback parameters for dialog Contact 
/// </summary>
public partial class Contact : _Contact {
    }

/// <summary>
/// Callback parameters for section Contact 
/// </summary>
public partial class _Contact : IBindable {

        ///<summary></summary> 
    public virtual string Local { get; set;} 

        ///<summary></summary> 
    public virtual string Full { get; set;} 

        ///<summary></summary> 
    public virtual string First { get; set;} 

        ///<summary></summary> 
    public virtual string Last { get; set;} 

        ///<summary></summary> 
    public virtual string Prefix { get; set;} 

        ///<summary></summary> 
    public virtual string Suffix { get; set;} 

        ///<summary></summary> 
    public virtual ISelectCollection NetworkAddress { get; set;} 

        ///<summary></summary> 
    public virtual ISelectCollection PhysicalAddress { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _Contact,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _Contact).Local, (object data,string value) => (data as _Contact).Local = value, "Local"), 
            new GuiBoundPropertyString ((object data) => (data as _Contact).Full, (object data,string value) => (data as _Contact).Full = value, "Full"), 
            new GuiBoundPropertyString ((object data) => (data as _Contact).First, (object data,string value) => (data as _Contact).First = value, "First"), 
            new GuiBoundPropertyString ((object data) => (data as _Contact).Last, (object data,string value) => (data as _Contact).Last = value, "Last"), 
            new GuiBoundPropertyString ((object data) => (data as _Contact).Prefix, (object data,string value) => (data as _Contact).Prefix = value, "Prefix"), 
            new GuiBoundPropertyString ((object data) => (data as _Contact).Suffix, (object data,string value) => (data as _Contact).Suffix = value, "Suffix"), 
            new GuiBoundPropertyChooser ((object data) => (data as _Contact).NetworkAddress, (object data,ISelectCollection value) => (data as _Contact).NetworkAddress = value, "NetworkAddress"), 
            new GuiBoundPropertyChooser ((object data) => (data as _Contact).PhysicalAddress, (object data,ISelectCollection value) => (data as _Contact).PhysicalAddress = value, "PhysicalAddress")
            });

    }

/// <summary>
/// Callback parameters for dialog ContactNetworkAddress 
/// </summary>
public partial class ContactNetworkAddress : _ContactNetworkAddress {
    }

/// <summary>
/// Callback parameters for section ContactNetworkAddress 
/// </summary>
public partial class _ContactNetworkAddress : IBindable {

        ///<summary></summary> 
    public virtual IFieldIcon ProtocolIcon { get; set;} 

        ///<summary></summary> 
    public virtual string Protocol { get; set;} 

        ///<summary></summary> 
    public virtual string Address { get; set;} 

        ///<summary></summary> 
    public virtual string Fingerprint { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _ContactNetworkAddress,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyIcon ((object data) => (data as _ContactNetworkAddress).ProtocolIcon, (object data,IFieldIcon value) => (data as _ContactNetworkAddress).ProtocolIcon = value, "ProtocolIcon"), 
            new GuiBoundPropertyString ((object data) => (data as _ContactNetworkAddress).Protocol, (object data,string value) => (data as _ContactNetworkAddress).Protocol = value, "Protocol"), 
            new GuiBoundPropertyString ((object data) => (data as _ContactNetworkAddress).Address, (object data,string value) => (data as _ContactNetworkAddress).Address = value, "Address"), 
            new GuiBoundPropertyString ((object data) => (data as _ContactNetworkAddress).Fingerprint, (object data,string value) => (data as _ContactNetworkAddress).Fingerprint = value, "Fingerprint")
            });

    }

/// <summary>
/// Callback parameters for dialog ContactPhysicalAddress 
/// </summary>
public partial class ContactPhysicalAddress : _ContactPhysicalAddress {
    }

/// <summary>
/// Callback parameters for section ContactPhysicalAddress 
/// </summary>
public partial class _ContactPhysicalAddress : IBindable {

        ///<summary></summary> 
    public virtual string Appartment { get; set;} 

        ///<summary></summary> 
    public virtual string Street { get; set;} 

        ///<summary></summary> 
    public virtual string District { get; set;} 

        ///<summary></summary> 
    public virtual string Locality { get; set;} 

        ///<summary></summary> 
    public virtual string County { get; set;} 

        ///<summary></summary> 
    public virtual string Postcode { get; set;} 

        ///<summary></summary> 
    public virtual string Country { get; set;} 

        ///<summary></summary> 
    public virtual double Latitude { get; set;} 

        ///<summary></summary> 
    public virtual double Longitude { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _ContactPhysicalAddress,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).Appartment, (object data,string value) => (data as _ContactPhysicalAddress).Appartment = value, "Appartment"), 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).Street, (object data,string value) => (data as _ContactPhysicalAddress).Street = value, "Street"), 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).District, (object data,string value) => (data as _ContactPhysicalAddress).District = value, "District"), 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).Locality, (object data,string value) => (data as _ContactPhysicalAddress).Locality = value, "Locality"), 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).County, (object data,string value) => (data as _ContactPhysicalAddress).County = value, "County"), 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).Postcode, (object data,string value) => (data as _ContactPhysicalAddress).Postcode = value, "Postcode"), 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).Country, (object data,string value) => (data as _ContactPhysicalAddress).Country = value, "Country"), 
            new GuiBoundPropertyDecimal ((object data) => (data as _ContactPhysicalAddress).Latitude, (object data,double value) => (data as _ContactPhysicalAddress).Latitude = value, "Latitude"), 
            new GuiBoundPropertyDecimal ((object data) => (data as _ContactPhysicalAddress).Longitude, (object data,double value) => (data as _ContactPhysicalAddress).Longitude = value, "Longitude")
            });

    }

/// <summary>
/// Callback parameters for dialog MessageContactRequest 
/// </summary>
public partial class MessageContactRequest : _MessageContactRequest {
    }

/// <summary>
/// Callback parameters for section MessageContactRequest 
/// </summary>
public partial class _MessageContactRequest : IBindable {

        ///<summary></summary> 
    public virtual string To { get; set;} 

        ///<summary></summary> 
    public virtual string Comment { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _MessageContactRequest,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _MessageContactRequest).To, (object data,string value) => (data as _MessageContactRequest).To = value, "To"), 
            new GuiBoundPropertyString ((object data) => (data as _MessageContactRequest).Comment, (object data,string value) => (data as _MessageContactRequest).Comment = value, "Comment")
            });

    }

/// <summary>
/// Callback parameters for dialog MessageConfirmationRequest 
/// </summary>
public partial class MessageConfirmationRequest : _MessageConfirmationRequest {
    }

/// <summary>
/// Callback parameters for section MessageConfirmationRequest 
/// </summary>
public partial class _MessageConfirmationRequest : IBindable {

        ///<summary></summary> 
    public virtual string To { get; set;} 

        ///<summary></summary> 
    public virtual string Request { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _MessageConfirmationRequest,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _MessageConfirmationRequest).To, (object data,string value) => (data as _MessageConfirmationRequest).To = value, "To"), 
            new GuiBoundPropertyString ((object data) => (data as _MessageConfirmationRequest).Request, (object data,string value) => (data as _MessageConfirmationRequest).Request = value, "Request")
            });

    }

/// <summary>
/// Callback parameters for dialog MessageMail 
/// </summary>
public partial class MessageMail : _MessageMail {
    }

/// <summary>
/// Callback parameters for section MessageMail 
/// </summary>
public partial class _MessageMail : IBindable {

        ///<summary></summary> 
    public virtual string To { get; set;} 

        ///<summary></summary> 
    public virtual string Subject { get; set;} 

        ///<summary></summary> 
    public virtual string Body { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _MessageMail,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _MessageMail).To, (object data,string value) => (data as _MessageMail).To = value, "To"), 
            new GuiBoundPropertyString ((object data) => (data as _MessageMail).Subject, (object data,string value) => (data as _MessageMail).Subject = value, "Subject"), 
            new GuiBoundPropertyString ((object data) => (data as _MessageMail).Body, (object data,string value) => (data as _MessageMail).Body = value, "Body")
            });

    }




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


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _TestService,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _TestService).ServiceAddress, (object data,string value) => (data as _TestService).ServiceAddress = value, "ServiceAddress")
            });

    ///<summary>Validation</summary> 
    public virtual IResult Validate() {
        GuiResultInvalid result = null;

        // error on ServiceAddress
        if (ServiceAddress == null
            ) {
            result ??=new GuiResultInvalid(this);
            result.SetError (nameof(ServiceAddress), "Service address cannot be blank", "ServiceAddressNotEmpty");
            }

        // error on ServiceAddress
        if (!ServiceAddress.TryParseServiceAddress()
            ) {
            result ??=new GuiResultInvalid(this);
            result.SetError (nameof(ServiceAddress), "Not a valid service address", "ServiceAddressNotValid");
            }



        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize() => NullResult.Initialized;
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
    public virtual string LocalName { get; set;} 

        ///<summary></summary> 
    public virtual string Coupon { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _AccountCreate,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _AccountCreate).ServiceAddress, (object data,string value) => (data as _AccountCreate).ServiceAddress = value, "ServiceAddress"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountCreate).LocalName, (object data,string value) => (data as _AccountCreate).LocalName = value, "LocalName"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountCreate).Coupon, (object data,string value) => (data as _AccountCreate).Coupon = value, "Coupon")
            });

    ///<summary>Validation</summary> 
    public virtual IResult Validate() {
        GuiResultInvalid result = null;



        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize() => NullResult.Initialized;
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


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _AccountSwitch,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _AccountSwitch).ChooseUser, (object data,ISelectCollection value) => (data as _AccountSwitch).ChooseUser = value, "ChooseUser")
            });

    ///<summary>Validation</summary> 
    public virtual IResult Validate() {
        GuiResultInvalid result = null;



        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize() => NullResult.Initialized;
    }


/// <summary>
/// Callback parameters for action AccountConnect 
/// </summary>
public partial class AccountConnect : _AccountConnect {
    }


/// <summary>
/// Callback parameters for action AccountConnect 
/// </summary>
public partial class _AccountConnect : IParameter {

        ///<summary></summary> 
    public virtual string ConnectionString { get; set;} 

        ///<summary></summary> 
    public virtual string ConnectionPin { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _AccountConnect,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _AccountConnect).ConnectionString, (object data,string value) => (data as _AccountConnect).ConnectionString = value, "ConnectionString"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountConnect).ConnectionPin, (object data,string value) => (data as _AccountConnect).ConnectionPin = value, "ConnectionPin")
            });

    ///<summary>Validation</summary> 
    public virtual IResult Validate() {
        GuiResultInvalid result = null;



        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize() => NullResult.Initialized;
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


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
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
    public virtual IResult Validate() {
        GuiResultInvalid result = null;



        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize() => NullResult.Initialized;
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
    public virtual string Address { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _RequestContact,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _RequestContact).Address, (object data,string value) => (data as _RequestContact).Address = value, "Address")
            });

    ///<summary>Validation</summary> 
    public virtual IResult Validate() {
        GuiResultInvalid result = null;



        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize() => NullResult.Initialized;
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


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _CreateMail,
        new GuiBoundProperty[] {
            });

    ///<summary>Validation</summary> 
    public virtual IResult Validate() {
        GuiResultInvalid result = null;



        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize() => NullResult.Initialized;
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


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _CreateChat,
        new GuiBoundProperty[] {
            });

    ///<summary>Validation</summary> 
    public virtual IResult Validate() {
        GuiResultInvalid result = null;



        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize() => NullResult.Initialized;
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


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _StartVoice,
        new GuiBoundProperty[] {
            });

    ///<summary>Validation</summary> 
    public virtual IResult Validate() {
        GuiResultInvalid result = null;



        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize() => NullResult.Initialized;
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


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _StartVideo,
        new GuiBoundProperty[] {
            });

    ///<summary>Validation</summary> 
    public virtual IResult Validate() {
        GuiResultInvalid result = null;



        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize() => NullResult.Initialized;
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


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _SendDocument,
        new GuiBoundProperty[] {
            });

    ///<summary>Validation</summary> 
    public virtual IResult Validate() {
        GuiResultInvalid result = null;



        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize() => NullResult.Initialized;
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


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is _ShareDocument,
        new GuiBoundProperty[] {
            });

    ///<summary>Validation</summary> 
    public virtual IResult Validate() {
        GuiResultInvalid result = null;



        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize() => NullResult.Initialized;
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

    public virtual ReturnResult ReturnResult { get; init; }

        ///<summary></summary> 
    public virtual string ServiceCallsign { get; set;} 

        ///<summary></summary> 
    public virtual string ServiceDns { get; set;} 

        ///<summary></summary> 
    public virtual string ServiceUdf { get; set;} 

        ///<summary></summary> 
    public virtual string HostUdf { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is ReportHost,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as ReportHost).ServiceCallsign, (object data,string value) => (data as ReportHost).ServiceCallsign = value, "ServiceCallsign"), 
            new GuiBoundPropertyString ((object data) => (data as ReportHost).ServiceDns, (object data,string value) => (data as ReportHost).ServiceDns = value, "ServiceDns"), 
            new GuiBoundPropertyString ((object data) => (data as ReportHost).ServiceUdf, (object data,string value) => (data as ReportHost).ServiceUdf = value, "ServiceUdf"), 
            new GuiBoundPropertyString ((object data) => (data as ReportHost).HostUdf, (object data,string value) => (data as ReportHost).HostUdf = value, "HostUdf")
            });

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

    public virtual ReturnResult ReturnResult { get; init; }

        ///<summary></summary> 
    public virtual string ServiceCallsign { get; set;} 

        ///<summary></summary> 
    public virtual string ServiceAddress { get; set;} 

        ///<summary></summary> 
    public virtual string ProfileUdf { get; set;} 

        ///<summary></summary> 
    public virtual string ServiceUdf { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is ReportAccount,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as ReportAccount).ServiceCallsign, (object data,string value) => (data as ReportAccount).ServiceCallsign = value, "ServiceCallsign"), 
            new GuiBoundPropertyString ((object data) => (data as ReportAccount).ServiceAddress, (object data,string value) => (data as ReportAccount).ServiceAddress = value, "ServiceAddress"), 
            new GuiBoundPropertyString ((object data) => (data as ReportAccount).ProfileUdf, (object data,string value) => (data as ReportAccount).ProfileUdf = value, "ProfileUdf"), 
            new GuiBoundPropertyString ((object data) => (data as ReportAccount).ServiceUdf, (object data,string value) => (data as ReportAccount).ServiceUdf = value, "ServiceUdf")
            });

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

    public virtual ReturnResult ReturnResult { get; init; }

        ///<summary></summary> 
    public virtual string ServiceCallsign { get; set;} 

        ///<summary></summary> 
    public virtual string ServiceAddress { get; set;} 

        ///<summary></summary> 
    public virtual string ServiceUdf { get; set;} 

        ///<summary></summary> 
    public virtual string Message { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (
        (object test) => test is ReportPending,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as ReportPending).ServiceCallsign, (object data,string value) => (data as ReportPending).ServiceCallsign = value, "ServiceCallsign"), 
            new GuiBoundPropertyString ((object data) => (data as ReportPending).ServiceAddress, (object data,string value) => (data as ReportPending).ServiceAddress = value, "ServiceAddress"), 
            new GuiBoundPropertyString ((object data) => (data as ReportPending).ServiceUdf, (object data,string value) => (data as ReportPending).ServiceUdf = value, "ServiceUdf"), 
            new GuiBoundPropertyString ((object data) => (data as ReportPending).Message, (object data,string value) => (data as ReportPending).Message = value, "Message")
            });

    }




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
    public override List<GuiResult> Results { get; }


	///<inheritdoc/>
	public override List<GuiImage> Icons => icons;
	readonly List<GuiImage> icons = new () {  
		new GuiImage ("applications") , 
		new GuiImage ("bookmark") , 
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
	public GuiSection SectionAccount { get; } = new ("Account", "Account", "user", false);
	public GuiSection SectionMessages { get; } = new ("Messages", "Messages", "messages", true);
	public GuiSection SectionContacts { get; } = new ("Contacts", "Contacts", "contacts", true);
	public GuiSection SectionDocuments { get; } = new ("Documents", "Documents", "Documents", false);
	public GuiSection SectionGroups { get; } = new ("Groups", "Groups", "groups", false);
	public GuiSection SectionFeeds { get; } = new ("Feeds", "Feeds", "feeds", false);
	public GuiSection SectionCredentials { get; } = new ("Credentials", "Credentials", "credentials", false);
	public GuiSection SectionTasks { get; } = new ("Tasks", "Tasks", "tasks", false);
	public GuiSection SectionCalendar { get; } = new ("Calendar", "Calendar", "calendar", false);
	public GuiSection SectionBookmark { get; } = new ("Bookmark", "Bookmark", "bookmark", false);
	public GuiSection SectionApplications { get; } = new ("Applications", "Applications", "applications", false);
	public GuiSection SectionDevices { get; } = new ("Devices", "Devices", "devices", false);
	public GuiSection SectionServices { get; } = new ("Services", "Services", "Services", false);
	public GuiSection SectionSettings { get; } = new ("Settings", "Settings", "settings", true);

	
	// Actions
	public GuiAction ActionTestService { get; } = new ("TestService", "Test Service", "test_service", () => new TestService());
	public GuiAction ActionAccountCreate { get; } = new ("AccountCreate", "Create Mesh Account", "new", () => new AccountCreate());
	public GuiAction ActionAccountSwitch { get; } = new ("AccountSwitch", "Change Account", "test_service", () => new AccountSwitch());
	public GuiAction ActionAccountConnect { get; } = new ("AccountConnect", "Connect To Existing Account", "connect", () => new AccountConnect());
	public GuiAction ActionAccountRecover { get; } = new ("AccountRecover", "Recover Mesh Account", "recover", () => new AccountRecover());
	public GuiAction ActionRequestContact { get; } = new ("RequestContact", "Contact Request", "contact", () => new RequestContact());
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

	// Dialogs
	public GuiResult ResultReportHost { get; } = new ();
	public GuiResult ResultReportAccount { get; } = new ();
	public GuiResult ResultReportPending { get; } = new ();
	

    public _EverythingMaui () {


	    SectionAccount.Gui = this;
	    SectionAccount.Active = () => StateAlways;
	    SectionAccount.Entries =  new () {  
			new GuiButton ("AccountCreate", ActionAccountCreate), 
			new GuiButton ("TestService", ActionTestService), 
			new GuiButton ("AccountConnect", ActionAccountConnect), 
			new GuiButton ("AccountRecover", ActionAccountRecover), 
			new GuiText ("ServiceAddress", "Service Address", 0), 
			new GuiText ("ProfileUdf", "Profile fingerprint", 1), 
			new GuiText ("LocalAddress", "Local Address", 2)		    
            };

	    SectionMessages.Gui = this;
	    SectionMessages.Active = () => StateDefault;
	    SectionMessages.Entries =  new () {  
			new GuiButton ("RequestContact", ActionRequestContact), 
			new GuiButton ("CreateMail", ActionCreateMail), 
			new GuiButton ("CreateChat", ActionCreateChat), 
			new GuiButton ("StartVoice", ActionStartVoice), 
			new GuiButton ("StartVideo", ActionStartVideo), 
			new GuiChooser ("ChooseMessage", "Messages", "inbox_messages", 0, new () { 
				new GuiView (BindingMessage)
				}) 		    
            };

	    SectionContacts.Gui = this;
	    SectionContacts.Active = () => StateDefault;
	    SectionContacts.Entries =  new () {  
			new GuiButton ("RequestContact", ActionRequestContact), 
			new GuiChooser ("ChooseContact", "Contacts", "contact_other", 0, new () { 
				new GuiView (BindingCatalogedContact)
				}) 		    
            };

	    SectionDocuments.Gui = this;
	    SectionDocuments.Active = () => StateDefault;
	    SectionDocuments.Entries =  new () {  
			new GuiButton ("SendDocument", ActionSendDocument), 
			new GuiButton ("ShareDocument", ActionShareDocument), 
			new GuiChooser ("ChooseDocuments", "Documents", "documents", 0, new () { 
				new GuiView (BindingCatalogedDocument)
				}) 		    
            };

	    SectionGroups.Gui = this;
	    SectionGroups.Active = () => StateDefault;
	    SectionGroups.Entries =  new () {  
			new GuiChooser ("ChooseGroup", "User", "account_group", 0, new () { 
				new GuiView (BindingCatalogedGroup)
				}) 		    
            };

	    SectionFeeds.Gui = this;
	    SectionFeeds.Active = () => StateDefault;
	    SectionFeeds.Entries =  new () {  
			new GuiChooser ("ChooseFeed", "Feeds", "feeds", 0, new () { 
				new GuiView (BindingCatalogedFeed)
				}) 		    
            };

	    SectionCredentials.Gui = this;
	    SectionCredentials.Active = () => StateDefault;
	    SectionCredentials.Entries =  new () {  
			new GuiChooser ("ChooseCredential", "Credentials", "credentials", 0, new () { 
				new GuiView (BindingCatalogedCredential)
				}) 		    
            };

	    SectionTasks.Gui = this;
	    SectionTasks.Active = () => StateDefault;
	    SectionTasks.Entries =  new () {  
			new GuiChooser ("ChooseTask", "Tasks", "Tasks", 0, new () { 
				new GuiView (BindingCatalogedTask)
				}) 		    
            };

	    SectionCalendar.Gui = this;
	    SectionCalendar.Active = () => StateDefault;
	    SectionCalendar.Entries =  new () {  
			new GuiChooser ("ChooseAppointment", "Tasks", "Tasks", 0, new () { 
				new GuiView (BindingCatalogedTask)
				}) 		    
            };

	    SectionBookmark.Gui = this;
	    SectionBookmark.Active = () => StateDefault;
	    SectionBookmark.Entries =  new () {  
			new GuiChooser ("ChooseBookmark", "Bookmark", "Bookmark", 0, new () { 
				new GuiView (BindingCatalogedBookmark)
				}) 		    
            };

	    SectionApplications.Gui = this;
	    SectionApplications.Active = () => StateDefault;
	    SectionApplications.Entries =  new () {  
			new GuiChooser ("ChooseApplication", "Applications", "Applications", 0, new () { 
				new GuiView (BindingCatalogedApplication)
				}) 		    
            };

	    SectionDevices.Gui = this;
	    SectionDevices.Active = () => StateDefault;
	    SectionDevices.Entries =  new () {  
			new GuiChooser ("ChooseDevice", "Devices", "Devices", 0, new () { 
				new GuiView (BindingCatalogedDevice)
				}) 		    
            };

	    SectionServices.Gui = this;
	    SectionServices.Active = () => StateDefault;
	    SectionServices.Entries =  new () {  
			new GuiChooser ("ChooseService", "Services", "account_service.png", 0, new () {
				}) 		    
            };

	    SectionSettings.Gui = this;
	    SectionSettings.Active = () => StateAlways;
	    SectionSettings.Entries =  new () {  
			new GuiDialog ("Appearance", new () { 
				new GuiColor ("BackgroundColor", "Background Color"), 
				new GuiColor ("HighlightColor", "Highlight Color"), 
				new GuiColor ("TextColor", "Text Color"), 
				new GuiSize ("TextSize", "Text Size"), 
				new GuiSize ("IconSize", "Icon Size")
			    }) 		    
            };


        Sections = new List<GuiSection> () {  
		    SectionAccount, 
		    SectionMessages, 
		    SectionContacts, 
		    SectionDocuments, 
		    SectionGroups, 
		    SectionFeeds, 
		    SectionCredentials, 
		    SectionTasks, 
		    SectionCalendar, 
		    SectionBookmark, 
		    SectionApplications, 
		    SectionDevices, 
		    SectionServices, 
		    SectionSettings
            };

        ActionTestService.Callback = (x, mode) => TestService (x as TestService, mode) ;
	    ActionTestService.Entries = new () { 
			new GuiText ("ServiceAddress", "Service address", 0)
		    };

        ActionAccountCreate.Callback = (x, mode) => AccountCreate (x as AccountCreate, mode) ;
	    ActionAccountCreate.Entries = new () { 
			new GuiText ("ServiceAddress", "Account service address", 0), 
			new GuiText ("LocalName", "Friendly name (optional)", 1), 
			new GuiText ("Coupon", "Activation code (if provided)", 2)
		    };

        ActionAccountSwitch.Callback = (x, mode) => AccountSwitch (x as AccountSwitch, mode) ;
	    ActionAccountSwitch.Entries = new () { 
			new GuiChooser ("ChooseUser", "User", "account_user", 0, new () {
				}) 
		    };

        ActionAccountConnect.Callback = (x, mode) => AccountConnect (x as AccountConnect, mode) ;
	    ActionAccountConnect.Entries = new () { 
			new GuiText ("ConnectionString", "Account address", 0), 
			new GuiText ("ConnectionPin", "Activation code (if provided)", 1)
		    };

        ActionAccountRecover.Callback = (x, mode) => AccountRecover (x as AccountRecover, mode) ;
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

        ActionRequestContact.Callback = (x, mode) => RequestContact (x as RequestContact, mode) ;
	    ActionRequestContact.Entries = new () { 
			new GuiText ("Address", "Address", 0)
		    };

        ActionCreateMail.Callback = (x, mode) => CreateMail (x as CreateMail, mode) ;
	    ActionCreateMail.Entries = new () {
		    };

        ActionCreateChat.Callback = (x, mode) => CreateChat (x as CreateChat, mode) ;
	    ActionCreateChat.Entries = new () {
		    };

        ActionStartVoice.Callback = (x, mode) => StartVoice (x as StartVoice, mode) ;
	    ActionStartVoice.Entries = new () {
		    };

        ActionStartVideo.Callback = (x, mode) => StartVideo (x as StartVideo, mode) ;
	    ActionStartVideo.Entries = new () {
		    };

        ActionSendDocument.Callback = (x, mode) => SendDocument (x as SendDocument, mode) ;
	    ActionSendDocument.Entries = new () {
		    };

        ActionShareDocument.Callback = (x, mode) => ShareDocument (x as ShareDocument, mode) ;
	    ActionShareDocument.Entries = new () {
		    };


        Actions = new List<GuiAction>() {  
		    ActionTestService, 
		    ActionAccountCreate, 
		    ActionAccountSwitch, 
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


	    DialogAppearance.Entries = new () { 
			new GuiColor ("BackgroundColor", "Background Color"), 
			new GuiColor ("HighlightColor", "Highlight Color"), 
			new GuiColor ("TextColor", "Text Color"), 
			new GuiSize ("TextSize", "Text Size"), 
			new GuiSize ("IconSize", "Icon Size")			
		    };

	    DialogAccountUser.Entries = new () { 
			new GuiText ("Udf", "Fingerprint", 0), 
			new GuiText ("ServiceAddress", "Account service address", 1), 
			new GuiText ("Local", "Friendly name", 2), 
			new GuiText ("Description", "Description", 3), 
			new GuiChooser ("UserChooseDevice", "Devices", "device", 4, new () {
				}) 			
		    };

	    DialogContact.Entries = new () { 
			new GuiText ("Local", "Friendly name", 0), 
			new GuiText ("Full", "Full name", 1), 
			new GuiText ("First", "First name", 2), 
			new GuiText ("Last", "Last name", 3), 
			new GuiText ("Prefix", "Prefix", 4), 
			new GuiText ("Suffix", "Suffix", 5), 
			new GuiChooser ("NetworkAddress", "Network Addresses", "network", 6, new () {
				}) , 
			new GuiChooser ("PhysicalAddress", "Locations", "location", 7, new () {
				}) 			
		    };

	    DialogContactNetworkAddress.Entries = new () { 
			new GuiIcon ("ProtocolIcon", "protocol_icon"), 
			new GuiText ("Protocol", "Protocol", 1), 
			new GuiText ("Address", "Address", 2), 
			new GuiText ("Fingerprint", "Fingerprint", 3)			
		    };

	    DialogContactPhysicalAddress.Entries = new () { 
			new GuiText ("Appartment", "Appartment", 0), 
			new GuiText ("Street", "Street", 1), 
			new GuiText ("District", "District", 2), 
			new GuiText ("Locality", "Locality", 3), 
			new GuiText ("County", "County", 4), 
			new GuiText ("Postcode", "Postcode", 5), 
			new GuiText ("Country", "Country", 6), 
			new GuiDecimal ("Latitude", "Latitude"), 
			new GuiDecimal ("Longitude", "Longitude")			
		    };

	    DialogMessageContactRequest.Entries = new () { 
			new GuiText ("To", "To", 0), 
			new GuiText ("Comment", "Comment", 1)			
		    };

	    DialogMessageConfirmationRequest.Entries = new () { 
			new GuiText ("To", "To", 0), 
			new GuiText ("Request", "Request", 1)			
		    };

	    DialogMessageMail.Entries = new () { 
			new GuiText ("To", "To", 0), 
			new GuiText ("Subject", "Subject", 1), 
			new GuiText ("Body", "Body", 2)			
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

	    ResultReportHost.Entries = new () { 
			new GuiText ("ServiceCallsign", "Callsign", 0), 
			new GuiText ("ServiceDns", "DNS", 1), 
			new GuiText ("ServiceUdf", "Service fingerprint", 2), 
			new GuiText ("HostUdf", "Host fingerprint", 3)			
		    };

	    ResultReportAccount.Entries = new () { 
			new GuiText ("ServiceCallsign", "Callsign", 0), 
			new GuiText ("ServiceAddress", "DNS", 1), 
			new GuiText ("ProfileUdf", "Service fingerprint", 2), 
			new GuiText ("ServiceUdf", "Service fingerprint", 3)			
		    };

	    ResultReportPending.Entries = new () { 
			new GuiText ("ServiceCallsign", "Callsign", 0), 
			new GuiText ("ServiceAddress", "DNS", 1), 
			new GuiText ("ServiceUdf", "Service fingerprint", 2), 
			new GuiText ("Message", "Message", 3)			
		    };



        Results = new List<GuiResult>() {  
		    ResultReportHost, 
		    ResultReportAccount, 
		    ResultReportPending
		    };

        }

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> TestService (TestService data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AccountCreate (AccountCreate data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AccountSwitch (AccountSwitch data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AccountConnect (AccountConnect data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AccountRecover (AccountRecover data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> RequestContact (RequestContact data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> CreateMail (CreateMail data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> CreateChat (CreateChat data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> StartVoice (StartVoice data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> StartVideo (StartVideo data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> SendDocument (SendDocument data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> ShareDocument (ShareDocument data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    
    /// <summary> </summary>
    public static GuiBinding BindingMessage = new GuiBinding (
        (object test) => test is Message,
        new GuiBoundProperty[] {
            });
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedDevice = new GuiBinding (
        (object test) => test is CatalogedDevice,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as CatalogedDevice).LocalName, (object data,string value) => (data as CatalogedDevice).LocalName = value, "LocalName"), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedDevice).Udf, (object data,string value) => (data as CatalogedDevice).Udf = value, "Udf"), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedDevice).LocalName, (object data,string value) => (data as CatalogedDevice).LocalName = value, "LocalName"), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedDevice).Description, (object data,string value) => (data as CatalogedDevice).Description = value, "Description")
            });
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedDocument = new GuiBinding (
        (object test) => test is CatalogedDocument,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as CatalogedDocument).ContentType, (object data,string value) => (data as CatalogedDocument).ContentType = value, "ContentType"), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedDocument).Description, (object data,string value) => (data as CatalogedDocument).Description = value, "Description")
            });
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedGroup = new GuiBinding (
        (object test) => test is CatalogedGroup,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as CatalogedGroup).LocalName, (object data,string value) => (data as CatalogedGroup).LocalName = value, "LocalName")
            });
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedFeed = new GuiBinding (
        (object test) => test is CatalogedFeed,
        new GuiBoundProperty[] {
            });
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedContact = new GuiBinding (
        (object test) => test is CatalogedContact,
        new GuiBoundProperty[] {
            });
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedCredential = new GuiBinding (
        (object test) => test is CatalogedCredential,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as CatalogedCredential).LocalName, (object data,string value) => (data as CatalogedCredential).LocalName = value, "LocalName"), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedCredential).Service, (object data,string value) => (data as CatalogedCredential).Service = value, "Service"), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedCredential).Username, (object data,string value) => (data as CatalogedCredential).Username = value, "Username"), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedCredential).Password, (object data,string value) => (data as CatalogedCredential).Password = value, "Password"), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedCredential).Protocol, (object data,string value) => (data as CatalogedCredential).Protocol = value, "Protocol"), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedCredential).Description, (object data,string value) => (data as CatalogedCredential).Description = value, "Description")
            });
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedTask = new GuiBinding (
        (object test) => test is CatalogedTask,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as CatalogedTask).LocalName, (object data,string value) => (data as CatalogedTask).LocalName = value, "LocalName"), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedTask).Title, (object data,string value) => (data as CatalogedTask).Title = value, "Title")
            });
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedBookmark = new GuiBinding (
        (object test) => test is CatalogedBookmark,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as CatalogedBookmark).LocalName, (object data,string value) => (data as CatalogedBookmark).LocalName = value, "LocalName"), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedBookmark).Uri, (object data,string value) => (data as CatalogedBookmark).Uri = value, "Uri"), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedBookmark).Title, (object data,string value) => (data as CatalogedBookmark).Title = value, "Title"), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedBookmark).Description, (object data,string value) => (data as CatalogedBookmark).Description = value, "Description")
            });
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedApplication = new GuiBinding (
        (object test) => test is CatalogedApplication,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as CatalogedApplication).LocalName, (object data,string value) => (data as CatalogedApplication).LocalName = value, "LocalName")
            });


	}



