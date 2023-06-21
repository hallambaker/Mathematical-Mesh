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
/// Callback parameters for section Accounts 
/// </summary>
public partial class Accounts : _Accounts {
    }

/// <summary>
/// Callback parameters for section Accounts 
/// </summary>
public partial class _Accounts : IBindable {

        ///<summary></summary> 
        public virtual string ServiceAddress { get;} 

        ///<summary></summary> 
        public virtual string ProfileUDF { get;} 

        ///<summary></summary> 
        public virtual string LocalAddress { get;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((IBindable data) => (data as _Accounts).ServiceAddress, null), 
            new GuiBoundPropertyString ((IBindable data) => (data as _Accounts).ProfileUDF, null), 
            new GuiBoundPropertyString ((IBindable data) => (data as _Accounts).LocalAddress, null)
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
        public virtual ISelectCollection UrgentMessage { get; set;} 

        ///<summary></summary> 
        public virtual ISelectCollection ContactRequests { get; set;} 

        ///<summary></summary> 
        public virtual ISelectCollection OtherMessage { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((IBindable data) => (data as _Messages).UrgentMessage, (IBindable data,ISelectCollection value) => (data as _Messages).UrgentMessage = value), 
            new GuiBoundPropertyChooser ((IBindable data) => (data as _Messages).ContactRequests, (IBindable data,ISelectCollection value) => (data as _Messages).ContactRequests = value), 
            new GuiBoundPropertyChooser ((IBindable data) => (data as _Messages).OtherMessage, (IBindable data,ISelectCollection value) => (data as _Messages).OtherMessage = value)
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
        public virtual ISelectCollection ChooseSelf { get; set;} 

        ///<summary></summary> 
        public virtual ISelectCollection ContactMessage { get; set;} 

        ///<summary></summary> 
        public virtual ISelectCollection ChooseOther { get; set;} 


    public GuiBinding Binding => BaseBinding;
    public static GuiBinding BaseBinding = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyChooser ((IBindable data) => (data as _Contacts).ChooseSelf, (IBindable data,ISelectCollection value) => (data as _Contacts).ChooseSelf = value), 
            new GuiBoundPropertyChooser ((IBindable data) => (data as _Contacts).ContactMessage, (IBindable data,ISelectCollection value) => (data as _Contacts).ContactMessage = value), 
            new GuiBoundPropertyChooser ((IBindable data) => (data as _Contacts).ChooseOther, (IBindable data,ISelectCollection value) => (data as _Contacts).ChooseOther = value)
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
            new GuiBoundPropertyChooser ((IBindable data) => (data as _Documents).ChooseDocuments, (IBindable data,ISelectCollection value) => (data as _Documents).ChooseDocuments = value)
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
            new GuiBoundPropertyChooser ((IBindable data) => (data as _Groups).ChooseGroup, (IBindable data,ISelectCollection value) => (data as _Groups).ChooseGroup = value)
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
            new GuiBoundPropertyChooser ((IBindable data) => (data as _Feeds).ChooseFeed, (IBindable data,ISelectCollection value) => (data as _Feeds).ChooseFeed = value)
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
            new GuiBoundPropertyChooser ((IBindable data) => (data as _Credentials).ChooseCredential, (IBindable data,ISelectCollection value) => (data as _Credentials).ChooseCredential = value)
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
            new GuiBoundPropertyChooser ((IBindable data) => (data as _Tasks).ChooseTask, (IBindable data,ISelectCollection value) => (data as _Tasks).ChooseTask = value)
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
            new GuiBoundPropertyChooser ((IBindable data) => (data as _Calendar).ChooseAppointment, (IBindable data,ISelectCollection value) => (data as _Calendar).ChooseAppointment = value)
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
            new GuiBoundPropertyChooser ((IBindable data) => (data as _Applications).ChooseApplication, (IBindable data,ISelectCollection value) => (data as _Applications).ChooseApplication = value)
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
            new GuiBoundPropertyChooser ((IBindable data) => (data as _Devices).ChooseDevice, (IBindable data,ISelectCollection value) => (data as _Devices).ChooseDevice = value)
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
            new GuiBoundPropertyChooser ((IBindable data) => (data as _Services).ChooseService, (IBindable data,ISelectCollection value) => (data as _Services).ChooseService = value)
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
            new GuiBoundPropertyColor ((IBindable data) => (data as _Appearance).BackgroundColor, (IBindable data,IFieldColor value) => (data as _Appearance).BackgroundColor = value), 
            new GuiBoundPropertyColor ((IBindable data) => (data as _Appearance).HighlightColor, (IBindable data,IFieldColor value) => (data as _Appearance).HighlightColor = value), 
            new GuiBoundPropertyColor ((IBindable data) => (data as _Appearance).TextColor, (IBindable data,IFieldColor value) => (data as _Appearance).TextColor = value), 
            new GuiBoundPropertySize ((IBindable data) => (data as _Appearance).TextSize, (IBindable data,IFieldSize value) => (data as _Appearance).TextSize = value), 
            new GuiBoundPropertySize ((IBindable data) => (data as _Appearance).IconSize, (IBindable data,IFieldSize value) => (data as _Appearance).IconSize = value)
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
            new GuiBoundPropertyString ((IBindable data) => (data as _AccountUser).Udf, (IBindable data,string value) => (data as _AccountUser).Udf = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _AccountUser).ServiceAddress, (IBindable data,string value) => (data as _AccountUser).ServiceAddress = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _AccountUser).Local, (IBindable data,string value) => (data as _AccountUser).Local = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _AccountUser).Description, (IBindable data,string value) => (data as _AccountUser).Description = value), 
            new GuiBoundPropertyChooser ((IBindable data) => (data as _AccountUser).UserChooseDevice, (IBindable data,ISelectCollection value) => (data as _AccountUser).UserChooseDevice = value)
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
            new GuiBoundPropertyString ((IBindable data) => (data as _Contact).Local, (IBindable data,string value) => (data as _Contact).Local = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _Contact).Full, (IBindable data,string value) => (data as _Contact).Full = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _Contact).First, (IBindable data,string value) => (data as _Contact).First = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _Contact).Last, (IBindable data,string value) => (data as _Contact).Last = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _Contact).Prefix, (IBindable data,string value) => (data as _Contact).Prefix = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _Contact).Suffix, (IBindable data,string value) => (data as _Contact).Suffix = value), 
            new GuiBoundPropertyChooser ((IBindable data) => (data as _Contact).NetworkAddress, (IBindable data,ISelectCollection value) => (data as _Contact).NetworkAddress = value), 
            new GuiBoundPropertyChooser ((IBindable data) => (data as _Contact).PhysicalAddress, (IBindable data,ISelectCollection value) => (data as _Contact).PhysicalAddress = value)
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
            new GuiBoundPropertyIcon ((IBindable data) => (data as _ContactNetworkAddress).ProtocolIcon, (IBindable data,IFieldIcon value) => (data as _ContactNetworkAddress).ProtocolIcon = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _ContactNetworkAddress).Protocol, (IBindable data,string value) => (data as _ContactNetworkAddress).Protocol = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _ContactNetworkAddress).Address, (IBindable data,string value) => (data as _ContactNetworkAddress).Address = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _ContactNetworkAddress).Fingerprint, (IBindable data,string value) => (data as _ContactNetworkAddress).Fingerprint = value)
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
            new GuiBoundPropertyString ((IBindable data) => (data as _ContactPhysicalAddress).Appartment, (IBindable data,string value) => (data as _ContactPhysicalAddress).Appartment = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _ContactPhysicalAddress).Street, (IBindable data,string value) => (data as _ContactPhysicalAddress).Street = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _ContactPhysicalAddress).District, (IBindable data,string value) => (data as _ContactPhysicalAddress).District = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _ContactPhysicalAddress).Locality, (IBindable data,string value) => (data as _ContactPhysicalAddress).Locality = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _ContactPhysicalAddress).County, (IBindable data,string value) => (data as _ContactPhysicalAddress).County = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _ContactPhysicalAddress).Postcode, (IBindable data,string value) => (data as _ContactPhysicalAddress).Postcode = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _ContactPhysicalAddress).Country, (IBindable data,string value) => (data as _ContactPhysicalAddress).Country = value), 
            new GuiBoundPropertyDecimal ((IBindable data) => (data as _ContactPhysicalAddress).Latitude, (IBindable data,double value) => (data as _ContactPhysicalAddress).Latitude = value), 
            new GuiBoundPropertyDecimal ((IBindable data) => (data as _ContactPhysicalAddress).Longitude, (IBindable data,double value) => (data as _ContactPhysicalAddress).Longitude = value)
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
            new GuiBoundPropertyString ((IBindable data) => (data as _MessageContactRequest).To, (IBindable data,string value) => (data as _MessageContactRequest).To = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _MessageContactRequest).Comment, (IBindable data,string value) => (data as _MessageContactRequest).Comment = value)
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
            new GuiBoundPropertyString ((IBindable data) => (data as _MessageConfirmationRequest).To, (IBindable data,string value) => (data as _MessageConfirmationRequest).To = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _MessageConfirmationRequest).Request, (IBindable data,string value) => (data as _MessageConfirmationRequest).Request = value)
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
            new GuiBoundPropertyString ((IBindable data) => (data as _MessageMail).To, (IBindable data,string value) => (data as _MessageMail).To = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _MessageMail).Subject, (IBindable data,string value) => (data as _MessageMail).Subject = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _MessageMail).Body, (IBindable data,string value) => (data as _MessageMail).Body = value)
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
            new GuiBoundPropertyString ((IBindable data) => (data as _TestService).ServiceAddress, (IBindable data,string value) => (data as _TestService).ServiceAddress = value)
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
            new GuiBoundPropertyChooser ((IBindable data) => (data as _AccountSwitch).ChooseUser, (IBindable data,ISelectCollection value) => (data as _AccountSwitch).ChooseUser = value)
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
            new GuiBoundPropertyString ((IBindable data) => (data as _AccountCreate).ServiceAddress, (IBindable data,string value) => (data as _AccountCreate).ServiceAddress = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _AccountCreate).LocalName, (IBindable data,string value) => (data as _AccountCreate).LocalName = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _AccountCreate).Coupon, (IBindable data,string value) => (data as _AccountCreate).Coupon = value)
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
            new GuiBoundPropertyString ((IBindable data) => (data as _AccountConnect).ConnectionString, (IBindable data,string value) => (data as _AccountConnect).ConnectionString = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _AccountConnect).ConnectionPin, (IBindable data,string value) => (data as _AccountConnect).ConnectionPin = value)
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
            new GuiBoundPropertyString ((IBindable data) => (data as _AccountRecover).ServiceAddress, (IBindable data,string value) => (data as _AccountRecover).ServiceAddress = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _AccountRecover).LocalName, (IBindable data,string value) => (data as _AccountRecover).LocalName = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _AccountRecover).Coupon, (IBindable data,string value) => (data as _AccountRecover).Coupon = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _AccountRecover).Share1, (IBindable data,string value) => (data as _AccountRecover).Share1 = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _AccountRecover).Share2, (IBindable data,string value) => (data as _AccountRecover).Share2 = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _AccountRecover).Share3, (IBindable data,string value) => (data as _AccountRecover).Share3 = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _AccountRecover).Share4, (IBindable data,string value) => (data as _AccountRecover).Share4 = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _AccountRecover).Share5, (IBindable data,string value) => (data as _AccountRecover).Share5 = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _AccountRecover).Share6, (IBindable data,string value) => (data as _AccountRecover).Share6 = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _AccountRecover).Share7, (IBindable data,string value) => (data as _AccountRecover).Share7 = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as _AccountRecover).Share8, (IBindable data,string value) => (data as _AccountRecover).Share8 = value)
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
            new GuiBoundPropertyString ((IBindable data) => (data as _RequestContact).Address, (IBindable data,string value) => (data as _RequestContact).Address = value)
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
	public GuiSection SectionAccounts { get; } = new ("Accounts", "Account", "user", false);
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


	    SectionAccounts.Entries =  new () {  
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
			new GuiChooser ("UrgentMessage", "Urgent", "urgent_messages", 0, new () {
				}) , 
			new GuiChooser ("ContactRequests", "Contact Requests", "contact_messages", 1, new () {
				}) , 
			new GuiChooser ("OtherMessage", "Messages", "inbox_messages", 2, new () {
				}) 		    
            };

	    SectionContacts.Entries =  new () {  
			new GuiChooser ("ChooseSelf", "Self", "contact_self", 0, new () {
				}) , 
			new GuiChooser ("ContactMessage", "Contact Requests", "contact_message", 1, new () {
				}) , 
			new GuiChooser ("ChooseOther", "Contacts", "contact_other", 2, new () {
				}) 		    
            };

	    SectionDocuments.Entries =  new () {  
			new GuiButton ("SendDocument", ActionSendDocument), 
			new GuiButton ("ShareDocument", ActionShareDocument), 
			new GuiChooser ("ChooseDocuments", "Documents", "documents", 0, new () {
				}) 		    
            };

	    SectionGroups.Entries =  new () {  
			new GuiChooser ("ChooseGroup", "User", "account_group", 0, new () { 
				new GuiButton ("AccountCreate", ActionAccountCreate)
				}) 		    
            };

	    SectionFeeds.Entries =  new () {  
			new GuiChooser ("ChooseFeed", "Feeds", "feeds", 0, new () {
				}) 		    
            };

	    SectionCredentials.Entries =  new () {  
			new GuiChooser ("ChooseCredential", "Credentials", "credentials", 0, new () { 
				new GuiView (BindingCatalogedCredential)
				}) 		    
            };

	    SectionTasks.Entries =  new () {  
			new GuiChooser ("ChooseTask", "Tasks", "Tasks", 0, new () {
				}) 		    
            };

	    SectionCalendar.Entries =  new () {  
			new GuiChooser ("ChooseAppointment", "Calendar", "Calendar", 0, new () {
				}) 		    
            };

	    SectionApplications.Entries =  new () {  
			new GuiChooser ("ChooseApplication", "Applications", "Applications", 0, new () {
				}) 		    
            };

	    SectionDevices.Entries =  new () {  
			new GuiChooser ("ChooseDevice", "Devices", "Devices", 0, new () {
				}) 		    
            };

	    SectionServices.Entries =  new () {  
			new GuiChooser ("ChooseService", "Services", "account_service.png", 0, new () { 
				new GuiButton ("AccountCreate", ActionAccountCreate)
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

        ActionTestService.Callback = (x) => (TestService (x as TestService) as IResult);
	    ActionTestService.Entries = new () { 
			new GuiText ("ServiceAddress", "Service address", 0)
		    };

        ActionAccountSwitch.Callback = (x) => (AccountSwitch (x as AccountSwitch) as IResult);
	    ActionAccountSwitch.Entries = new () { 
			new GuiChooser ("ChooseUser", "User", "account_user", 0, new () {
				}) 
		    };

        ActionAccountCreate.Callback = (x) => (AccountCreate (x as AccountCreate) as IResult);
	    ActionAccountCreate.Entries = new () { 
			new GuiText ("ServiceAddress", "Account service address", 0), 
			new GuiText ("LocalName", "Friendly name (optional)", 1), 
			new GuiText ("Coupon", "Activation code (if provided)", 2)
		    };

        ActionAccountConnect.Callback = (x) => (AccountConnect (x as AccountConnect) as IResult);
	    ActionAccountConnect.Entries = new () { 
			new GuiText ("ConnectionString", "Account address", 0), 
			new GuiText ("ConnectionPin", "Activation code (if provided)", 1)
		    };

        ActionAccountRecover.Callback = (x) => (AccountRecover (x as AccountRecover) as IResult);
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

        ActionRequestContact.Callback = (x) => (RequestContact (x as RequestContact) as IResult);
	    ActionRequestContact.Entries = new () { 
			new GuiText ("Address", "Address", 0)
		    };

        ActionCreateMail.Callback = (x) => (CreateMail (x as CreateMail) as IResult);
	    ActionCreateMail.Entries = new () {
		    };

        ActionCreateChat.Callback = (x) => (CreateChat (x as CreateChat) as IResult);
	    ActionCreateChat.Entries = new () {
		    };

        ActionStartVoice.Callback = (x) => (StartVoice (x as StartVoice) as IResult);
	    ActionStartVoice.Entries = new () {
		    };

        ActionStartVideo.Callback = (x) => (StartVideo (x as StartVideo) as IResult);
	    ActionStartVideo.Entries = new () {
		    };

        ActionSendDocument.Callback = (x) => (SendDocument (x as SendDocument) as IResult);
	    ActionSendDocument.Entries = new () {
		    };

        ActionShareDocument.Callback = (x) => (ShareDocument (x as ShareDocument) as IResult);
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
    public virtual IResult TestService (TestService data) => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual IResult AccountSwitch (AccountSwitch data) => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual IResult AccountCreate (AccountCreate data) => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual IResult AccountConnect (AccountConnect data) => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual IResult AccountRecover (AccountRecover data) => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual IResult RequestContact (RequestContact data) => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual IResult CreateMail (CreateMail data) => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual IResult CreateChat (CreateChat data) => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual IResult StartVoice (StartVoice data) => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual IResult StartVideo (StartVideo data) => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual IResult SendDocument (SendDocument data) => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual IResult ShareDocument (ShareDocument data) => throw new NYI();

    
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedCredential = new GuiBinding (new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((IBindable data) => (data as CatalogedCredential).Service, (IBindable data,string value) => (data as CatalogedCredential).Service = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as CatalogedCredential).Username, (IBindable data,string value) => (data as CatalogedCredential).Username = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as CatalogedCredential).Password, (IBindable data,string value) => (data as CatalogedCredential).Password = value), 
            new GuiBoundPropertyString ((IBindable data) => (data as CatalogedCredential).Protocol, (IBindable data,string value) => (data as CatalogedCredential).Protocol = value)
            });


	}



