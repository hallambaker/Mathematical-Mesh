﻿#region // Copyright 

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

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _Settings,
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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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
/// Callback parameters for dialog AccountUser 
/// </summary>
public partial class AccountUser : _AccountUser {
    }

/// <summary>
/// Callback parameters for section AccountUser 
/// </summary>
public partial class _AccountUser : IParameter {

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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _AccountUser,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _AccountUser).Udf, (object data,string value) => (data as _AccountUser).Udf = value, "Udf"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountUser).ServiceAddress, (object data,string value) => (data as _AccountUser).ServiceAddress = value, "ServiceAddress"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountUser).Local, (object data,string value) => (data as _AccountUser).Local = value, "Local"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountUser).Description, (object data,string value) => (data as _AccountUser).Description = value, "Description"), 
            new GuiBoundPropertyChooser ((object data) => (data as _AccountUser).UserChooseDevice, (object data,ISelectCollection value) => (data as _AccountUser).UserChooseDevice = value, "UserChooseDevice")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate() {
        GuiResultInvalid result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize() => NullResult.Initialized;

    //public virtual IResult Validate() => null;
    //public virtual IResult Initialize() => null;

    }

/// <summary>
/// Callback parameters for dialog BoundContactPerson 
/// </summary>
public partial class BoundContactPerson : _BoundContactPerson {
    }

/// <summary>
/// Callback parameters for section BoundContactPerson 
/// </summary>
public partial class _BoundContactPerson : IParameter {

    ///<summary></summary> 
    public virtual string Display { get;} 

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
    public virtual ISelectCollection NetworkAddress { get; set;} 

    ///<summary></summary> 
    public virtual ISelectCollection PhysicalAddress { get; set;} 

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _BoundContactPerson,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _BoundContactPerson).Display, null, "Display"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundContactPerson).Local, (object data,string value) => (data as _BoundContactPerson).Local = value, "Local"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundContactPerson).First, (object data,string value) => (data as _BoundContactPerson).First = value, "First"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundContactPerson).Last, (object data,string value) => (data as _BoundContactPerson).Last = value, "Last"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundContactPerson).Prefix, (object data,string value) => (data as _BoundContactPerson).Prefix = value, "Prefix"), 
            new GuiBoundPropertyString ((object data) => (data as _BoundContactPerson).Suffix, (object data,string value) => (data as _BoundContactPerson).Suffix = value, "Suffix"), 
            new GuiBoundPropertyChooser ((object data) => (data as _BoundContactPerson).NetworkAddress, (object data,ISelectCollection value) => (data as _BoundContactPerson).NetworkAddress = value, "NetworkAddress"), 
            new GuiBoundPropertyChooser ((object data) => (data as _BoundContactPerson).PhysicalAddress, (object data,ISelectCollection value) => (data as _BoundContactPerson).PhysicalAddress = value, "PhysicalAddress")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate() {
        GuiResultInvalid result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize() => NullResult.Initialized;

    //public virtual IResult Validate() => null;
    //public virtual IResult Initialize() => null;

    }

/// <summary>
/// Callback parameters for dialog ContactNetworkAddress 
/// </summary>
public partial class ContactNetworkAddress : _ContactNetworkAddress {
    }

/// <summary>
/// Callback parameters for section ContactNetworkAddress 
/// </summary>
public partial class _ContactNetworkAddress : IParameter {

    ///<summary></summary> 
    public virtual string Protocol { get; set;} 

    ///<summary></summary> 
    public virtual string Address { get; set;} 

    ///<summary></summary> 
    public virtual string Fingerprint { get; set;} 

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _ContactNetworkAddress,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _ContactNetworkAddress).Protocol, (object data,string value) => (data as _ContactNetworkAddress).Protocol = value, "Protocol"), 
            new GuiBoundPropertyString ((object data) => (data as _ContactNetworkAddress).Address, (object data,string value) => (data as _ContactNetworkAddress).Address = value, "Address"), 
            new GuiBoundPropertyString ((object data) => (data as _ContactNetworkAddress).Fingerprint, (object data,string value) => (data as _ContactNetworkAddress).Fingerprint = value, "Fingerprint")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate() {
        GuiResultInvalid result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize() => NullResult.Initialized;

    //public virtual IResult Validate() => null;
    //public virtual IResult Initialize() => null;

    }

/// <summary>
/// Callback parameters for dialog ContactPhysicalAddress 
/// </summary>
public partial class ContactPhysicalAddress : _ContactPhysicalAddress {
    }

/// <summary>
/// Callback parameters for section ContactPhysicalAddress 
/// </summary>
public partial class _ContactPhysicalAddress : IParameter {

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
    public virtual decimal? Latitude { get; set;} 

    ///<summary></summary> 
    public virtual decimal? Longitude { get; set;} 

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _ContactPhysicalAddress,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).Appartment, (object data,string value) => (data as _ContactPhysicalAddress).Appartment = value, "Appartment"), 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).Street, (object data,string value) => (data as _ContactPhysicalAddress).Street = value, "Street"), 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).District, (object data,string value) => (data as _ContactPhysicalAddress).District = value, "District"), 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).Locality, (object data,string value) => (data as _ContactPhysicalAddress).Locality = value, "Locality"), 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).County, (object data,string value) => (data as _ContactPhysicalAddress).County = value, "County"), 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).Postcode, (object data,string value) => (data as _ContactPhysicalAddress).Postcode = value, "Postcode"), 
            new GuiBoundPropertyString ((object data) => (data as _ContactPhysicalAddress).Country, (object data,string value) => (data as _ContactPhysicalAddress).Country = value, "Country"), 
            new GuiBoundPropertyDecimal ((object data) => (data as _ContactPhysicalAddress).Latitude, (object data,decimal? value) => (data as _ContactPhysicalAddress).Latitude = value, "Latitude"), 
            new GuiBoundPropertyDecimal ((object data) => (data as _ContactPhysicalAddress).Longitude, (object data,decimal? value) => (data as _ContactPhysicalAddress).Longitude = value, "Longitude")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate() {
        GuiResultInvalid result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize() => NullResult.Initialized;

    //public virtual IResult Validate() => null;
    //public virtual IResult Initialize() => null;

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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _TestService,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _TestService).ServiceAddress, (object data,string value) => (data as _TestService).ServiceAddress = value, "ServiceAddress")

            });
    ///<summary>Validation</summary> 
    public virtual IResult Validate() {
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

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _AccountRequestConnect,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _AccountRequestConnect).ConnectionString, (object data,string value) => (data as _AccountRequestConnect).ConnectionString = value, "ConnectionString"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountRequestConnect).ConnectionPin, (object data,string value) => (data as _AccountRequestConnect).ConnectionPin = value, "ConnectionPin"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountRequestConnect).Rights, (object data,string value) => (data as _AccountRequestConnect).Rights = value, "Rights")

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
/// Callback parameters for action AccountConnectUri 
/// </summary>
public partial class AccountConnectUri : _AccountConnectUri {
    }


/// <summary>
/// Callback parameters for action AccountConnectUri 
/// </summary>
public partial class _AccountConnectUri : IParameter {

    ///<summary></summary> 
    public virtual string ConnectionUri { get; set;} 

    ///<summary></summary> 
    public virtual string LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string Rights { get; set;} 

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _AccountConnectUri,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _AccountConnectUri).ConnectionUri, (object data,string value) => (data as _AccountConnectUri).ConnectionUri = value, "ConnectionUri"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountConnectUri).LocalName, (object data,string value) => (data as _AccountConnectUri).LocalName = value, "LocalName"), 
            new GuiBoundPropertyString ((object data) => (data as _AccountConnectUri).Rights, (object data,string value) => (data as _AccountConnectUri).Rights = value, "Rights")

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
/// Callback parameters for action DeviceDynamicUri 
/// </summary>
public partial class DeviceDynamicUri : _DeviceDynamicUri {
    }


/// <summary>
/// Callback parameters for action DeviceDynamicUri 
/// </summary>
public partial class _DeviceDynamicUri : IParameter {

    ///<summary></summary> 
    public virtual string LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string Rights { get; set;} 

    ///<summary></summary> 
    public virtual int? Security { get; set;} 

    ///<summary></summary> 
    public virtual int? Expire { get; set;} 

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _DeviceDynamicUri,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _DeviceDynamicUri).LocalName, (object data,string value) => (data as _DeviceDynamicUri).LocalName = value, "LocalName"), 
            new GuiBoundPropertyString ((object data) => (data as _DeviceDynamicUri).Rights, (object data,string value) => (data as _DeviceDynamicUri).Rights = value, "Rights"), 
            new GuiBoundPropertyInteger ((object data) => (data as _DeviceDynamicUri).Security, (object data,int? value) => (data as _DeviceDynamicUri).Security = value, "Security"), 
            new GuiBoundPropertyInteger ((object data) => (data as _DeviceDynamicUri).Expire, (object data,int? value) => (data as _DeviceDynamicUri).Expire = value, "Expire")

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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _AccountGetPin,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _AccountGetPin).Rights, (object data,string value) => (data as _AccountGetPin).Rights = value, "Rights"), 
            new GuiBoundPropertyInteger ((object data) => (data as _AccountGetPin).Security, (object data,int? value) => (data as _AccountGetPin).Security = value, "Security"), 
            new GuiBoundPropertyInteger ((object data) => (data as _AccountGetPin).Expire, (object data,int? value) => (data as _AccountGetPin).Expire = value, "Expire")

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
/// Callback parameters for action DeviceStaticUri 
/// </summary>
public partial class DeviceStaticUri : _DeviceStaticUri {
    }


/// <summary>
/// Callback parameters for action DeviceStaticUri 
/// </summary>
public partial class _DeviceStaticUri : IParameter {

    ///<summary></summary> 
    public virtual string ConnectionUri { get; set;} 

    ///<summary></summary> 
    public virtual string LocalName { get; set;} 

    ///<summary></summary> 
    public virtual string Rights { get; set;} 

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _DeviceStaticUri,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _DeviceStaticUri).ConnectionUri, (object data,string value) => (data as _DeviceStaticUri).ConnectionUri = value, "ConnectionUri"), 
            new GuiBoundPropertyString ((object data) => (data as _DeviceStaticUri).LocalName, (object data,string value) => (data as _DeviceStaticUri).LocalName = value, "LocalName"), 
            new GuiBoundPropertyString ((object data) => (data as _DeviceStaticUri).Rights, (object data,string value) => (data as _DeviceStaticUri).Rights = value, "Rights")

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

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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
/// Callback parameters for action AccountDelete 
/// </summary>
public partial class AccountDelete : _AccountDelete {
    }


/// <summary>
/// Callback parameters for action AccountDelete 
/// </summary>
public partial class _AccountDelete : IParameter {

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _AccountDelete,
        Array.Empty<GuiBoundProperty>());
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

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _AccountGenerateRecovery,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyInteger ((object data) => (data as _AccountGenerateRecovery).NumberShares, (object data,int? value) => (data as _AccountGenerateRecovery).NumberShares = value, "NumberShares"), 
            new GuiBoundPropertyInteger ((object data) => (data as _AccountGenerateRecovery).Quorum, (object data,int? value) => (data as _AccountGenerateRecovery).Quorum = value, "Quorum")

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
    public virtual string Recipient { get; set;} 

    ///<summary></summary> 
    public virtual string Message { get; set;} 

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _RequestContact,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _RequestContact).Recipient, (object data,string value) => (data as _RequestContact).Recipient = value, "Recipient"), 
            new GuiBoundPropertyString ((object data) => (data as _RequestContact).Message, (object data,string value) => (data as _RequestContact).Message = value, "Message")

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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _RequestConfirmation,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as _RequestConfirmation).Recipient, (object data,string value) => (data as _RequestConfirmation).Recipient = value, "Recipient"), 
            new GuiBoundPropertyString ((object data) => (data as _RequestConfirmation).Message, (object data,string value) => (data as _RequestConfirmation).Message = value, "Message")

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

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _CreateMail,
        Array.Empty<GuiBoundProperty>());
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

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _CreateChat,
        Array.Empty<GuiBoundProperty>());
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

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _StartVoice,
        Array.Empty<GuiBoundProperty>());
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

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _StartVideo,
        Array.Empty<GuiBoundProperty>());
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

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _SendDocument,
        Array.Empty<GuiBoundProperty>());
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

    ///<inheritdoc/>
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _ShareDocument,
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate() {
        GuiResultInvalid result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize() => NullResult.Initialized;


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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _AddMailAccount,
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate() {
        GuiResultInvalid result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize() => NullResult.Initialized;


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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _AddSshAccount,
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate() {
        GuiResultInvalid result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize() => NullResult.Initialized;


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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _AddGitAccount,
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate() {
        GuiResultInvalid result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize() => NullResult.Initialized;


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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is _AddCodeSigningKey,
        Array.Empty<GuiBoundProperty>());
    ///<summary>Validation</summary> 
    public virtual IResult Validate() {
        GuiResultInvalid result = null;

        return (result as IResult) ?? NullResult.Valid;
        }

    ///<summary>Initialization.</summary> 
    public virtual IResult Initialize() => NullResult.Initialized;


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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
        (object test) => test is ServiceNotFound,
        Array.Empty<GuiBoundProperty>());

    ///<inheritdoc/>
    public object[] GetValues() => new [] { 
        ServiceName};

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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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
    public GuiBinding Binding => BaseBinding;

    ///<summary>The binding for the data type.</summary> 
    public static GuiBinding BaseBinding  { get; } = new (
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
    public override List<GuiResult> Results { get; }


	///<inheritdoc/>
	public override List<GuiImage> Icons => icons;
	readonly List<GuiImage> icons = new () {  
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
		new GuiImage ("clipboard_check_solid") , 
		new GuiImage ("connect") , 
		new GuiImage ("contact") , 
		new GuiImage ("contacts") , 
		new GuiImage ("credentials") , 
		new GuiImage ("devices") , 
		new GuiImage ("display") , 
		new GuiImage ("document_send") , 
		new GuiImage ("document_share") , 
		new GuiImage ("documents") , 
		new GuiImage ("feeds") , 
		new GuiImage ("git") , 
		new GuiImage ("groups") , 
		new GuiImage ("location_pin") , 
		new GuiImage ("mail") , 
		new GuiImage ("messages") , 
		new GuiImage ("new") , 
		new GuiImage ("plus") , 
		new GuiImage ("protocol_icon") , 
		new GuiImage ("recover") , 
		new GuiImage ("services") , 
		new GuiImage ("settings") , 
		new GuiImage ("share_nodes_solid") , 
		new GuiImage ("signature") , 
		new GuiImage ("tasks") , 
		new GuiImage ("test_service") , 
		new GuiImage ("triangle_exclamation_solid") , 
		new GuiImage ("user") , 
		new GuiImage ("video") , 
		new GuiImage ("voice") 
		};


#region // Sections
    ///<summary>Section SectionAccount.</summary> 
	public GuiSection SectionAccount { get; } = new ("Account", "Account", "user", false);
    ///<summary>Section SectionMessages.</summary> 
	public GuiSection SectionMessages { get; } = new ("Messages", "Messages", "messages", true);
    ///<summary>Section SectionContacts.</summary> 
	public GuiSection SectionContacts { get; } = new ("Contacts", "Contacts", "contacts", true);
    ///<summary>Section SectionDocuments.</summary> 
	public GuiSection SectionDocuments { get; } = new ("Documents", "Documents", "Documents", false);
    ///<summary>Section SectionGroups.</summary> 
	public GuiSection SectionGroups { get; } = new ("Groups", "Groups", "groups", false);
    ///<summary>Section SectionFeeds.</summary> 
	public GuiSection SectionFeeds { get; } = new ("Feeds", "Feeds", "feeds", false);
    ///<summary>Section SectionCredentials.</summary> 
	public GuiSection SectionCredentials { get; } = new ("Credentials", "Credentials", "credentials", false);
    ///<summary>Section SectionTasks.</summary> 
	public GuiSection SectionTasks { get; } = new ("Tasks", "Tasks", "tasks", false);
    ///<summary>Section SectionCalendar.</summary> 
	public GuiSection SectionCalendar { get; } = new ("Calendar", "Calendar", "calendar", false);
    ///<summary>Section SectionBookmark.</summary> 
	public GuiSection SectionBookmark { get; } = new ("Bookmark", "Bookmark", "bookmark", false);
    ///<summary>Section SectionApplications.</summary> 
	public GuiSection SectionApplications { get; } = new ("Applications", "Applications", "applications", false);
    ///<summary>Section SectionDevices.</summary> 
	public GuiSection SectionDevices { get; } = new ("Devices", "Devices", "devices", false);
    ///<summary>Section SectionServices.</summary> 
	public GuiSection SectionServices { get; } = new ("Services", "Services", "Services", false);
    ///<summary>Section SectionSettings.</summary> 
	public GuiSection SectionSettings { get; } = new ("Settings", "Settings", "settings", true);
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
    ///<summary>Action ActionAccountConnectUri.</summary> 
	public GuiAction ActionAccountConnectUri { get; } = new ("AccountConnectUri", "Connect by QR", "connect", () => new AccountConnectUri());
    ///<summary>Action ActionDeviceDynamicUri.</summary> 
	public GuiAction ActionDeviceDynamicUri { get; } = new ("DeviceDynamicUri", "Present QR", "connect", () => new DeviceDynamicUri());
    ///<summary>Action ActionAccountGetPin.</summary> 
	public GuiAction ActionAccountGetPin { get; } = new ("AccountGetPin", "Create connection PIN", "recover", () => new AccountGetPin());
    ///<summary>Action ActionDeviceStaticUri.</summary> 
	public GuiAction ActionDeviceStaticUri { get; } = new ("DeviceStaticUri", "Scan QR", "connect", () => new DeviceStaticUri());
    ///<summary>Action ActionAccountRecover.</summary> 
	public GuiAction ActionAccountRecover { get; } = new ("AccountRecover", "Recover Mesh Account", "recover", () => new AccountRecover());
    ///<summary>Action ActionAccountDelete.</summary> 
	public GuiAction ActionAccountDelete { get; } = new ("AccountDelete", "Delete Account", "test_service", () => new AccountDelete());
    ///<summary>Action ActionAccountSwitch.</summary> 
	public GuiAction ActionAccountSwitch { get; } = new ("AccountSwitch", "Change Account", "test_service", () => new AccountSwitch());
    ///<summary>Action ActionAccountGenerateRecovery.</summary> 
	public GuiAction ActionAccountGenerateRecovery { get; } = new ("AccountGenerateRecovery", "Create recovery", "share_nodes_solid", () => new AccountGenerateRecovery());
    ///<summary>Action ActionRequestContact.</summary> 
	public GuiAction ActionRequestContact { get; } = new ("RequestContact", "Contact Request", "contact", () => new RequestContact());
    ///<summary>Action ActionRequestConfirmation.</summary> 
	public GuiAction ActionRequestConfirmation { get; } = new ("RequestConfirmation", "Confirmation Request", "clipboard_check_solid", () => new RequestConfirmation());
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
#region // Dialogs
    ///<summary>Dialog DialogAccountUser.</summary> 
	public GuiDialog DialogAccountUser { get; } = new ("AccountUser", "Account", "user", () => new AccountUser());
    ///<summary>Dialog DialogBoundContactPerson.</summary> 
	public GuiDialog DialogBoundContactPerson { get; } = new ("BoundContactPerson", "Person", "contacts", () => new BoundContactPerson());
    ///<summary>Dialog DialogContactNetworkAddress.</summary> 
	public GuiDialog DialogContactNetworkAddress { get; } = new ("ContactNetworkAddress", "Network", "protocol_icon", () => new ContactNetworkAddress());
    ///<summary>Dialog DialogContactPhysicalAddress.</summary> 
	public GuiDialog DialogContactPhysicalAddress { get; } = new ("ContactPhysicalAddress", "Place", "location_pin", () => new ContactPhysicalAddress());

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
	
    ///<summary>Dictionary resolving exception name to factory method.</summary> 
    public Dictionary<string, Func<IResult>> ExceptionDirectory =
        new() {
                { typeof(HttpRequestException).FullName, () => new HttpRequestFail() }
            };
#endregion
#region // Constructors
    /// <summary>
    /// Default constructor returning an instance.
    /// </summary>
    public _EverythingMaui () {


	    SectionAccount.Gui = this;
	    SectionAccount.Active = () => StateAlways;
	    SectionAccount.Entries =  new () {  
			new GuiButton ("AccountCreate", ActionAccountCreate), 
			new GuiButton ("AccountRequestConnect", ActionAccountRequestConnect), 
			new GuiButton ("AccountConnectUri", ActionAccountConnectUri), 
			new GuiButton ("TestService", ActionTestService), 
			new GuiButton ("AccountRecover", ActionAccountRecover), 
			new GuiButton ("AccountGenerateRecovery", ActionAccountGenerateRecovery), 
			new GuiButton ("AccountSwitch", ActionAccountSwitch), 
			new GuiText ("ServiceAddress", "Service Address", 0), 
			new GuiText ("ProfileUdf", "Profile fingerprint", 1), 
			new GuiText ("LocalAddress", "Local Address", 2)		    
            };

	    SectionMessages.Gui = this;
	    SectionMessages.Active = () => StateDefault;
	    SectionMessages.Entries =  new () {  
			new GuiButton ("RequestContact", ActionRequestContact), 
			new GuiButton ("RequestConfirmation", ActionRequestConfirmation), 
			new GuiButton ("CreateMail", ActionCreateMail), 
			new GuiButton ("CreateChat", ActionCreateChat), 
			new GuiButton ("StartVoice", ActionStartVoice), 
			new GuiButton ("StartVideo", ActionStartVideo), 
			new GuiChooser ("ChooseMessage", "Messages", "inbox_messages", 0, new () {
				}) 		    
            };

	    SectionContacts.Gui = this;
	    SectionContacts.Active = () => StateDefault;
	    SectionContacts.Entries =  new () {  
			new GuiButton ("RequestContact", ActionRequestContact), 
			new GuiChooser ("ChooseContact", "Contacts", "contact_other", 0, new () { 
				new GuiViewDialog (DialogBoundContactPerson)
				}) 		    
            };

	    SectionDocuments.Gui = this;
	    SectionDocuments.Active = () => StateDefault;
	    SectionDocuments.Entries =  new () {  
			new GuiButton ("SendDocument", ActionSendDocument), 
			new GuiButton ("ShareDocument", ActionShareDocument), 
			new GuiChooser ("ChooseDocuments", "Documents", "documents", 0, new () { 
				new GuiViewBinding (BindingCatalogedDocument)
				}) 		    
            };

	    SectionGroups.Gui = this;
	    SectionGroups.Active = () => StateDefault;
	    SectionGroups.Entries =  new () {  
			new GuiChooser ("ChooseGroup", "User", "account_group", 0, new () { 
				new GuiViewBinding (BindingCatalogedGroup)
				}) 		    
            };

	    SectionFeeds.Gui = this;
	    SectionFeeds.Active = () => StateDefault;
	    SectionFeeds.Entries =  new () {  
			new GuiChooser ("ChooseFeed", "Feeds", "feeds", 0, new () { 
				new GuiViewBinding (BindingCatalogedFeed)
				}) 		    
            };

	    SectionCredentials.Gui = this;
	    SectionCredentials.Active = () => StateDefault;
	    SectionCredentials.Entries =  new () {  
			new GuiChooser ("ChooseCredential", "Credentials", "credentials", 0, new () { 
				new GuiViewBinding (BindingCatalogedCredential)
				}) 		    
            };

	    SectionTasks.Gui = this;
	    SectionTasks.Active = () => StateDefault;
	    SectionTasks.Entries =  new () {  
			new GuiChooser ("ChooseTask", "Tasks", "Tasks", 0, new () { 
				new GuiViewBinding (BindingCatalogedTask)
				}) 		    
            };

	    SectionCalendar.Gui = this;
	    SectionCalendar.Active = () => StateDefault;
	    SectionCalendar.Entries =  new () {  
			new GuiChooser ("ChooseAppointment", "Tasks", "Tasks", 0, new () { 
				new GuiViewBinding (BindingCatalogedTask)
				}) 		    
            };

	    SectionBookmark.Gui = this;
	    SectionBookmark.Active = () => StateDefault;
	    SectionBookmark.Entries =  new () {  
			new GuiChooser ("ChooseBookmark", "Bookmark", "Bookmark", 0, new () { 
				new GuiViewBinding (BindingCatalogedBookmark)
				}) 		    
            };

	    SectionApplications.Gui = this;
	    SectionApplications.Active = () => StateDefault;
	    SectionApplications.Entries =  new () {  
			new GuiButton ("AddMailAccount", ActionAddMailAccount), 
			new GuiButton ("AddSshAccount", ActionAddSshAccount), 
			new GuiButton ("AddGitAccount", ActionAddGitAccount), 
			new GuiButton ("AddCodeSigningKey", ActionAddCodeSigningKey), 
			new GuiChooser ("ChooseApplication", "Applications", "Applications", 0, new () { 
				new GuiViewBinding (BindingCatalogedApplication)
				}) 		    
            };

	    SectionDevices.Gui = this;
	    SectionDevices.Active = () => StateDefault;
	    SectionDevices.Entries =  new () {  
			new GuiButton ("DeviceDynamicUri", ActionDeviceDynamicUri), 
			new GuiButton ("DeviceStaticUri", ActionDeviceStaticUri), 
			new GuiButton ("AccountGetPin", ActionAccountGetPin), 
			new GuiChooser ("ChooseDevice", "Devices", "Devices", 0, new () { 
				new GuiViewBinding (BindingCatalogedDevice)
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
		    SectionSettings, 
		    SectionAppearance
            };

#endregion
#region // Initialize Actions
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

        ActionAccountRequestConnect.Callback = (x, mode) => AccountRequestConnect (x as AccountRequestConnect, mode) ;
	    ActionAccountRequestConnect.Entries = new () { 
			new GuiText ("ConnectionString", "Account address", 0), 
			new GuiText ("ConnectionPin", "Activation code (if provided)", 1), 
			new GuiText ("Rights", "Requested rights", 2)
		    };

        ActionAccountConnectUri.Callback = (x, mode) => AccountConnectUri (x as AccountConnectUri, mode) ;
	    ActionAccountConnectUri.Entries = new () { 
			new GuiText ("ConnectionUri", "Connection URI", 0), 
			new GuiText ("LocalName", "Friendly name (optional)", 1), 
			new GuiText ("Rights", "Requested rights", 2)
		    };

        ActionDeviceDynamicUri.Callback = (x, mode) => DeviceDynamicUri (x as DeviceDynamicUri, mode) ;
	    ActionDeviceDynamicUri.Entries = new () { 
			new GuiText ("LocalName", "Friendly name (optional)", 0), 
			new GuiText ("Rights", "Assigned rights", 1), 
			new GuiInteger ("Security", "Security level", 2), 
			new GuiInteger ("Expire", "Expiry in hours", 3)
		    };

        ActionAccountGetPin.Callback = (x, mode) => AccountGetPin (x as AccountGetPin, mode) ;
	    ActionAccountGetPin.Entries = new () { 
			new GuiText ("Rights", "Assigned rights", 0), 
			new GuiInteger ("Security", "Security level", 1), 
			new GuiInteger ("Expire", "Expiry in hours", 2)
		    };

        ActionDeviceStaticUri.Callback = (x, mode) => DeviceStaticUri (x as DeviceStaticUri, mode) ;
	    ActionDeviceStaticUri.Entries = new () { 
			new GuiText ("ConnectionUri", "Connection URI", 0), 
			new GuiText ("LocalName", "Friendly name (optional)", 1), 
			new GuiText ("Rights", "Requested rights", 2)
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

        ActionAccountDelete.Callback = (x, mode) => AccountDelete (x as AccountDelete, mode) ;
	    ActionAccountDelete.Entries = new () {
		    };

        ActionAccountSwitch.Callback = (x, mode) => AccountSwitch (x as AccountSwitch, mode) ;
	    ActionAccountSwitch.Entries = new () { 
			new GuiChooser ("ChooseUser", "User", "account_user", 0, new () {
				}) 
		    };

        ActionAccountGenerateRecovery.Callback = (x, mode) => AccountGenerateRecovery (x as AccountGenerateRecovery, mode) ;
	    ActionAccountGenerateRecovery.Entries = new () { 
			new GuiInteger ("NumberShares", "Total number of shares", 0), 
			new GuiInteger ("Quorum", "Quorum required for recovery", 1)
		    };

        ActionRequestContact.Callback = (x, mode) => RequestContact (x as RequestContact, mode) ;
	    ActionRequestContact.Entries = new () { 
			new GuiText ("Recipient", "Address", 0), 
			new GuiText ("Message", "Message", 1)
		    };

        ActionRequestConfirmation.Callback = (x, mode) => RequestConfirmation (x as RequestConfirmation, mode) ;
	    ActionRequestConfirmation.Entries = new () { 
			new GuiText ("Recipient", "Address", 0), 
			new GuiText ("Message", "Message", 1)
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

        ActionAddMailAccount.Callback = (x, mode) => AddMailAccount (x as AddMailAccount, mode) ;
	    ActionAddMailAccount.Entries = new () {
		    };

        ActionAddSshAccount.Callback = (x, mode) => AddSshAccount (x as AddSshAccount, mode) ;
	    ActionAddSshAccount.Entries = new () {
		    };

        ActionAddGitAccount.Callback = (x, mode) => AddGitAccount (x as AddGitAccount, mode) ;
	    ActionAddGitAccount.Entries = new () {
		    };

        ActionAddCodeSigningKey.Callback = (x, mode) => AddCodeSigningKey (x as AddCodeSigningKey, mode) ;
	    ActionAddCodeSigningKey.Entries = new () {
		    };


        Actions = new List<GuiAction>() {  
		    ActionTestService, 
		    ActionAccountCreate, 
		    ActionAccountRequestConnect, 
		    ActionAccountConnectUri, 
		    ActionDeviceDynamicUri, 
		    ActionAccountGetPin, 
		    ActionDeviceStaticUri, 
		    ActionAccountRecover, 
		    ActionAccountDelete, 
		    ActionAccountSwitch, 
		    ActionAccountGenerateRecovery, 
		    ActionRequestContact, 
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
#region // Initialize Dialogs
	    DialogAccountUser.Entries = new () { 
			new GuiText ("Udf", "Fingerprint", 0), 
			new GuiText ("ServiceAddress", "Account service address", 1), 
			new GuiText ("Local", "Friendly name", 2), 
			new GuiText ("Description", "Description", 3), 
			new GuiChooser ("UserChooseDevice", "Devices", "device", 4, new () {
				}) 			
		    };

	    DialogBoundContactPerson.Entries = new () { 
			new GuiText ("Display", "Display name", 0), 
			new GuiText ("Local", "Friendly name", 1), 
			new GuiText ("First", "First name", 2), 
			new GuiText ("Last", "Last name", 3), 
			new GuiText ("Prefix", "Prefix", 4), 
			new GuiText ("Suffix", "Suffix", 5), 
			new GuiChooser ("NetworkAddress", "Network Addresses", "network", 6, new () { 
				new GuiViewDialog (DialogContactNetworkAddress)
				}) , 
			new GuiChooser ("PhysicalAddress", "Locations", "location", 7, new () { 
				new GuiViewDialog (DialogContactPhysicalAddress)
				}) 			
		    };

	    DialogContactNetworkAddress.Entries = new () { 
			new GuiText ("Protocol", "Protocol", 0), 
			new GuiText ("Address", "Address", 1), 
			new GuiText ("Fingerprint", "Fingerprint", 2)			
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


        Dialogs = new List<GuiDialog>() {  
		    DialogAccountUser, 
		    DialogBoundContactPerson, 
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



        Results = new List<GuiResult>() {  
		    ResultReportHost, 
		    ResultReportAccountCreate, 
		    ResultReportAccount, 
		    ResultReportPending, 
		    ResultReportShares
		    };

        }

#endregion
#region // Initialize Actions
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
    public virtual Task<IResult> AccountRequestConnect (AccountRequestConnect data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AccountConnectUri (AccountConnectUri data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> DeviceDynamicUri (DeviceDynamicUri data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AccountGetPin (AccountGetPin data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> DeviceStaticUri (DeviceStaticUri data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AccountRecover (AccountRecover data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AccountDelete (AccountDelete data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AccountSwitch (AccountSwitch data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AccountGenerateRecovery (AccountGenerateRecovery data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> RequestContact (RequestContact data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> RequestConfirmation (RequestConfirmation data, ActionMode mode = ActionMode.Execute) 
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

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AddMailAccount (AddMailAccount data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AddSshAccount (AddSshAccount data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AddGitAccount (AddGitAccount data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

    /// <summary>
    /// GUI action
    /// </summary>
    public virtual Task<IResult> AddCodeSigningKey (AddCodeSigningKey data, ActionMode mode = ActionMode.Execute) 
                => throw new NYI();

 
#endregion
#region // Initialize Bindings
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedDevice  { get; } = new (
        (object test) => test is CatalogedDevice,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as CatalogedDevice).LocalName, (object data,string value) => (data as CatalogedDevice).LocalName = value, "LocalName"), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedDevice).Udf, (object data,string value) => (data as CatalogedDevice).Udf = value, "Udf"), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedDevice).LocalName, (object data,string value) => (data as CatalogedDevice).LocalName = value, "LocalName"), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedDevice).Description, (object data,string value) => (data as CatalogedDevice).Description = value, "Description")

            });
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedDocument  { get; } = new (
        (object test) => test is CatalogedDocument,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as CatalogedDocument).ContentType, (object data,string value) => (data as CatalogedDocument).ContentType = value, "ContentType"), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedDocument).Description, (object data,string value) => (data as CatalogedDocument).Description = value, "Description")

            });
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedGroup  { get; } = new (
        (object test) => test is CatalogedGroup,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as CatalogedGroup).LocalName, (object data,string value) => (data as CatalogedGroup).LocalName = value, "LocalName")

            });
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedFeed  { get; } = new (
        (object test) => test is CatalogedFeed,
        Array.Empty<GuiBoundProperty>());
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedContact  { get; } = new (
        (object test) => test is CatalogedContact,
        Array.Empty<GuiBoundProperty>());
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedCredential  { get; } = new (
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
    public static GuiBinding BindingCatalogedTask  { get; } = new (
        (object test) => test is CatalogedTask,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as CatalogedTask).LocalName, (object data,string value) => (data as CatalogedTask).LocalName = value, "LocalName"), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedTask).Title, (object data,string value) => (data as CatalogedTask).Title = value, "Title")

            });
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedBookmark  { get; } = new (
        (object test) => test is CatalogedBookmark,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as CatalogedBookmark).LocalName, (object data,string value) => (data as CatalogedBookmark).LocalName = value, "LocalName"), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedBookmark).Uri, (object data,string value) => (data as CatalogedBookmark).Uri = value, "Uri"), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedBookmark).Title, (object data,string value) => (data as CatalogedBookmark).Title = value, "Title"), 
            new GuiBoundPropertyString ((object data) => (data as CatalogedBookmark).Description, (object data,string value) => (data as CatalogedBookmark).Description = value, "Description")

            });
    /// <summary> </summary>
    public static GuiBinding BindingCatalogedApplication  { get; } = new (
        (object test) => test is CatalogedApplication,
        new GuiBoundProperty[] { 
            new GuiBoundPropertyString ((object data) => (data as CatalogedApplication).LocalName, (object data,string value) => (data as CatalogedApplication).LocalName = value, "LocalName")

            });

#endregion
	}

#endregion
