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
        public virtual string ProfileUDF { get;} 

        ///<summary></summary> 
        public virtual string LocalAddress { get;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _Account).ServiceAddress, null), 
            new GuiBoundPropertyString ((object data) => (data as _Account).ProfileUDF, null), 
            new GuiBoundPropertyString ((object data) => (data as _Account).LocalAddress, null)
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _Messages).ChooseMessage, (object data,ISelectCollection value) => (data as _Messages).ChooseMessage = value)
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _Contacts).ChooseContact, (object data,ISelectCollection value) => (data as _Contacts).ChooseContact = value)
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _Documents).ChooseDocuments, (object data,ISelectCollection value) => (data as _Documents).ChooseDocuments = value)
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _Groups).ChooseGroup, (object data,ISelectCollection value) => (data as _Groups).ChooseGroup = value)
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _Feeds).ChooseFeed, (object data,ISelectCollection value) => (data as _Feeds).ChooseFeed = value)
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _Credentials).ChooseCredential, (object data,ISelectCollection value) => (data as _Credentials).ChooseCredential = value)
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _Tasks).ChooseTask, (object data,ISelectCollection value) => (data as _Tasks).ChooseTask = value)
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _Calendar).ChooseAppointment, (object data,ISelectCollection value) => (data as _Calendar).ChooseAppointment = value)
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _Bookmark).ChooseBookmark, (object data,ISelectCollection value) => (data as _Bookmark).ChooseBookmark = value)
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _Applications).ChooseApplication, (object data,ISelectCollection value) => (data as _Applications).ChooseApplication = value)
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _Devices).ChooseDevice, (object data,ISelectCollection value) => (data as _Devices).ChooseDevice = value)
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _Services).ChooseService, (object data,ISelectCollection value) => (data as _Services).ChooseService = value)
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] {
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyColor ((object data) => (data as _Appearance).BackgroundColor, (object data,IFieldColor value) => (data as _Appearance).BackgroundColor = value), 
            new GuiBoundPropertyColor ((object data) => (data as _Appearance).HighlightColor, (object data,IFieldColor value) => (data as _Appearance).HighlightColor = value), 
            new GuiBoundPropertyColor ((object data) => (data as _Appearance).TextColor, (object data,IFieldColor value) => (data as _Appearance).TextColor = value), 
            new GuiBoundPropertySize ((object data) => (data as _Appearance).TextSize, (object data,IFieldSize value) => (data as _Appearance).TextSize = value), 
            new GuiBoundPropertySize ((object data) => (data as _Appearance).IconSize, (object data,IFieldSize value) => (data as _Appearance).IconSize = value)
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _AccountUser).Udf, (object data,string value) => (data as _AccountUser).Udf = value), 
            new GuiBoundPropertyString ((object data) => (data as _AccountUser).ServiceAddress, (object data,string value) => (data as _AccountUser).ServiceAddress = value), 
            new GuiBoundPropertyString ((object data) => (data as _AccountUser).Local, (object data,string value) => (data as _AccountUser).Local = value), 
            new GuiBoundPropertyString ((object data) => (data as _AccountUser).Description, (object data,string value) => (data as _AccountUser).Description = value), 
            new GuiBoundPropertyChooser ((object data) => (data as _AccountUser).UserChooseDevice, (object data,ISelectCollection value) => (data as _AccountUser).UserChooseDevice = value)
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _Contact).Local, (object data,string value) => (data as _Contact).Local = value), 
            new GuiBoundPropertyString ((object data) => (data as _Contact).Full, (object data,string value) => (data as _Contact).Full = value), 
            new GuiBoundPropertyString ((object data) => (data as _Contact).First, (object data,string value) => (data as _Contact).First = value), 
            new GuiBoundPropertyString ((object data) => (data as _Contact).Last, (object data,string value) => (data as _Contact).Last = value), 
            new GuiBoundPropertyString ((object data) => (data as _Contact).Prefix, (object data,string value) => (data as _Contact).Prefix = value), 
            new GuiBoundPropertyString ((object data) => (data as _Contact).Suffix, (object data,string value) => (data as _Contact).Suffix = value), 
            new GuiBoundPropertyChooser ((object data) => (data as _Contact).NetworkAddress, (object data,ISelectCollection value) => (data as _Contact).NetworkAddress = value), 
            new GuiBoundPropertyChooser ((object data) => (data as _Contact).PhysicalAddress, (object data,ISelectCollection value) => (data as _Contact).PhysicalAddress = value)
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyIcon ((object data) => (data as _ContactNetworkAddress).ProtocolIcon, (object data,IFieldIcon value) => (data as _ContactNetworkAddress).ProtocolIcon = value), 
            new GuiBoundPropertyString ((object data) => (data as _ContactNetworkAddress).Protocol, (object data,string value) => (data as _ContactNetworkAddress).Protocol = value), 
            new GuiBoundPropertyString ((object data) => (data as _ContactNetworkAddress).Address, (object data,string value) => (data as _ContactNetworkAddress).Address = value), 
            new GuiBoundPropertyString ((object data) => (data as _ContactNetworkAddress).Fingerprint, (object data,string value) => (data as _ContactNetworkAddress).Fingerprint = value)
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).Appartment, (object data,string value) => (data as _ContactPhysicalAddress).Appartment = value), 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).Street, (object data,string value) => (data as _ContactPhysicalAddress).Street = value), 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).District, (object data,string value) => (data as _ContactPhysicalAddress).District = value), 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).Locality, (object data,string value) => (data as _ContactPhysicalAddress).Locality = value), 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).County, (object data,string value) => (data as _ContactPhysicalAddress).County = value), 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).Postcode, (object data,string value) => (data as _ContactPhysicalAddress).Postcode = value), 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).Country, (object data,string value) => (data as _ContactPhysicalAddress).Country = value), 
            new GuiBoundPropertyDecimal ((object data) => (data as _ContactPhysicalAddress).Latitude, (object data,double value) => (data as _ContactPhysicalAddress).Latitude = value), 
            new GuiBoundPropertyDecimal ((object data) => (data as _ContactPhysicalAddress).Longitude, (object data,double value) => (data as _ContactPhysicalAddress).Longitude = value)
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _MessageContactRequest).To, (object data,string value) => (data as _MessageContactRequest).To = value), 
            new GuiBoundPropertyString ((object data) => (data as _MessageContactRequest).Comment, (object data,string value) => (data as _MessageContactRequest).Comment = value)
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _MessageConfirmationRequest).To, (object data,string value) => (data as _MessageConfirmationRequest).To = value), 
            new GuiBoundPropertyString ((object data) => (data as _MessageConfirmationRequest).Request, (object data,string value) => (data as _MessageConfirmationRequest).Request = value)
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _MessageMail).To, (object data,string value) => (data as _MessageMail).To = value), 
            new GuiBoundPropertyString ((object data) => (data as _MessageMail).Subject, (object data,string value) => (data as _MessageMail).Subject = value), 
            new GuiBoundPropertyString ((object data) => (data as _MessageMail).Body, (object data,string value) => (data as _MessageMail).Body = value)
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _TestService).ServiceAddress, (object data,string value) => (data as _TestService).ServiceAddress = value)
            });

    public virtual bool Validate() => true;
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((object data) => (data as _AccountSwitch).ChooseUser, (object data,ISelectCollection value) => (data as _AccountSwitch).ChooseUser = value)
            });

    public virtual bool Validate() => true;
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _AccountCreate).ServiceAddress, (object data,string value) => (data as _AccountCreate).ServiceAddress = value), 
            new GuiBoundPropertyString ((object data) => (data as _AccountCreate).LocalName, (object data,string value) => (data as _AccountCreate).LocalName = value), 
            new GuiBoundPropertyString ((object data) => (data as _AccountCreate).Coupon, (object data,string value) => (data as _AccountCreate).Coupon = value)
            });

    public virtual bool Validate() => true;
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _AccountConnect).ConnectionString, (object data,string value) => (data as _AccountConnect).ConnectionString = value), 
            new GuiBoundPropertyString ((object data) => (data as _AccountConnect).ConnectionPin, (object data,string value) => (data as _AccountConnect).ConnectionPin = value)
            });

    public virtual bool Validate() => true;
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _AccountRecover).ServiceAddress, (object data,string value) => (data as _AccountRecover).ServiceAddress = value), 
            new GuiBoundPropertyString ((object data) => (data as _AccountRecover).LocalName, (object data,string value) => (data as _AccountRecover).LocalName = value), 
            new GuiBoundPropertyString ((object data) => (data as _AccountRecover).Coupon, (object data,string value) => (data as _AccountRecover).Coupon = value), 
            new GuiBoundPropertyString ((object data) => (data as _AccountRecover).Share1, (object data,string value) => (data as _AccountRecover).Share1 = value), 
            new GuiBoundPropertyString ((object data) => (data as _AccountRecover).Share2, (object data,string value) => (data as _AccountRecover).Share2 = value), 
            new GuiBoundPropertyString ((object data) => (data as _AccountRecover).Share3, (object data,string value) => (data as _AccountRecover).Share3 = value), 
            new GuiBoundPropertyString ((object data) => (data as _AccountRecover).Share4, (object data,string value) => (data as _AccountRecover).Share4 = value), 
            new GuiBoundPropertyString ((object data) => (data as _AccountRecover).Share5, (object data,string value) => (data as _AccountRecover).Share5 = value), 
            new GuiBoundPropertyString ((object data) => (data as _AccountRecover).Share6, (object data,string value) => (data as _AccountRecover).Share6 = value), 
            new GuiBoundPropertyString ((object data) => (data as _AccountRecover).Share7, (object data,string value) => (data as _AccountRecover).Share7 = value), 
            new GuiBoundPropertyString ((object data) => (data as _AccountRecover).Share8, (object data,string value) => (data as _AccountRecover).Share8 = value)
            });

    public virtual bool Validate() => true;
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _RequestContact).Address, (object data,string value) => (data as _RequestContact).Address = value)
            });

    public virtual bool Validate() => true;
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] {
            });

    public virtual bool Validate() => true;
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] {
            });

    public virtual bool Validate() => true;
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] {
            });

    public virtual bool Validate() => true;
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] {
            });

    public virtual bool Validate() => true;
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] {
            });

    public virtual bool Validate() => true;
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
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] {
            });

    public virtual bool Validate() => true;
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
	public GuiAction ActionAccountSwitch { get; } = new ("AccountSwitch", "Change Account", "test_service", () => new AccountSwitch());
	public GuiAction ActionAccountCreate { get; } = new ("AccountCreate", "Create Mesh Account", "new", () => new AccountCreate());
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
	

    public _EverythingMaui () {


	    SectionAccount.Entries =  new () {  
			new GuiButton ("Groups", SectionGroups), 
			new GuiButton ("Services", SectionServices), 
			new GuiButton ("AccountCreate", ActionAccountCreate), 
			new GuiButton ("AccountConnect", ActionAccountConnect), 
			new GuiButton ("AccountRecover", ActionAccountRecover), 
			new GuiButton ("TestService", ActionTestService), 
			new GuiText ("ServiceAddress", "Service Address", 0), 
			new GuiText ("ProfileUDF", "Profile fingerprint", 1), 
			new GuiText ("LocalAddress", "Local Address", 2)		    
            };

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

	    SectionContacts.Entries =  new () {  
			new GuiButton ("RequestContact", ActionRequestContact), 
			new GuiChooser ("ChooseContact", "Contacts", "contact_other", 0, new () { 
				new GuiView (BindingCatalogedContact)
				}) 		    
            };

	    SectionDocuments.Entries =  new () {  
			new GuiButton ("SendDocument", ActionSendDocument), 
			new GuiButton ("ShareDocument", ActionShareDocument), 
			new GuiChooser ("ChooseDocuments", "Documents", "documents", 0, new () { 
				new GuiView (BindingCatalogedDocument)
				}) 		    
            };

	    SectionGroups.Entries =  new () {  
			new GuiChooser ("ChooseGroup", "User", "account_group", 0, new () { 
				new GuiView (BindingCatalogedGroup)
				}) 		    
            };

	    SectionFeeds.Entries =  new () {  
			new GuiChooser ("ChooseFeed", "Feeds", "feeds", 0, new () { 
				new GuiView (BindingCatalogedFeed)
				}) 		    
            };

	    SectionCredentials.Entries =  new () {  
			new GuiChooser ("ChooseCredential", "Credentials", "credentials", 0, new () { 
				new GuiView (BindingCatalogedCredential)
				}) 		    
            };

	    SectionTasks.Entries =  new () {  
			new GuiChooser ("ChooseTask", "Tasks", "Tasks", 0, new () { 
				new GuiView (BindingCatalogedTask)
				}) 		    
            };

	    SectionCalendar.Entries =  new () {  
			new GuiChooser ("ChooseAppointment", "Tasks", "Tasks", 0, new () { 
				new GuiView (BindingCatalogedTask)
				}) 		    
            };

	    SectionBookmark.Entries =  new () {  
			new GuiChooser ("ChooseBookmark", "Bookmark", "Bookmark", 0, new () { 
				new GuiView (BindingCatalogedBookmark)
				}) 		    
            };

	    SectionApplications.Entries =  new () {  
			new GuiChooser ("ChooseApplication", "Applications", "Applications", 0, new () { 
				new GuiView (BindingCatalogedApplication)
				}) 		    
            };

	    SectionDevices.Entries =  new () {  
			new GuiChooser ("ChooseDevice", "Devices", "Devices", 0, new () { 
				new GuiView (BindingCatalogedDevice)
				}) 		    
            };

	    SectionServices.Entries =  new () {  
			new GuiChooser ("ChooseService", "Services", "account_service.png", 0, new () {
				}) 		    
            };

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

        ActionAccountSwitch.Callback = (x, mode) => AccountSwitch (x as AccountSwitch, mode) ;
	    ActionAccountSwitch.Entries = new () { 
			new GuiChooser ("ChooseUser", "User", "account_user", 0, new () {
				}) 
		    };

        ActionAccountCreate.Callback = (x, mode) => AccountCreateAsync (x as AccountCreate, mode) ;
	    ActionAccountCreate.Entries = new () { 
			new GuiText ("ServiceAddress", "Account service address", 0), 
			new GuiText ("LocalName", "Friendly name (optional)", 1), 
			new GuiText ("Coupon", "Activation code (if provided)", 2)
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
		    ActionAccountSwitch, 
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

        }

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> TestService (TestService data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AccountSwitch (AccountSwitch data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AccountCreateAsync (AccountCreate data, ActionMode mode = ActionMode.Execute) 
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
    public static GuiBinding BindingMessage = new GuiBinding (new GuiBoundProperty[] {
            });
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedDevice = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as CatalogedDevice).LocalName, (object data,string value) => (data as CatalogedDevice).LocalName = value), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedDevice).Udf, (object data,string value) => (data as CatalogedDevice).Udf = value), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedDevice).LocalName, (object data,string value) => (data as CatalogedDevice).LocalName = value), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedDevice).Description, (object data,string value) => (data as CatalogedDevice).Description = value)
            });
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedDocument = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as CatalogedDocument).ContentType, (object data,string value) => (data as CatalogedDocument).ContentType = value), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedDocument).Description, (object data,string value) => (data as CatalogedDocument).Description = value)
            });
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedGroup = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as CatalogedGroup).LocalName, (object data,string value) => (data as CatalogedGroup).LocalName = value)
            });
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedFeed = new GuiBinding (new GuiBoundProperty[] {
            });
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedContact = new GuiBinding (new GuiBoundProperty[] {
            });
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedCredential = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as CatalogedCredential).LocalName, (object data,string value) => (data as CatalogedCredential).LocalName = value), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedCredential).Service, (object data,string value) => (data as CatalogedCredential).Service = value), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedCredential).Username, (object data,string value) => (data as CatalogedCredential).Username = value), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedCredential).Password, (object data,string value) => (data as CatalogedCredential).Password = value), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedCredential).Protocol, (object data,string value) => (data as CatalogedCredential).Protocol = value), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedCredential).Description, (object data,string value) => (data as CatalogedCredential).Description = value)
            });
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedTask = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as CatalogedTask).LocalName, (object data,string value) => (data as CatalogedTask).LocalName = value), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedTask).Title, (object data,string value) => (data as CatalogedTask).Title = value)
            });
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedBookmark = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as CatalogedBookmark).LocalName, (object data,string value) => (data as CatalogedBookmark).LocalName = value), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedBookmark).Uri, (object data,string value) => (data as CatalogedBookmark).Uri = value), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedBookmark).Title, (object data,string value) => (data as CatalogedBookmark).Title = value), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedBookmark).Description, (object data,string value) => (data as CatalogedBookmark).Description = value)
            });
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedApplication = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as CatalogedApplication).LocalName, (object data,string value) => (data as CatalogedApplication).LocalName = value)
            });


	}



