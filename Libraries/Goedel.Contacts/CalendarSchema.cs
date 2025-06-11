
//  Copyright (c) 2016 by .
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
//  This file was automatically generated at 6/10/2025 11:58:28 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.1141
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.26100.0
//  
//  
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Goedel.Protocol;
using Goedel.Utilities;

#pragma warning disable IDE0079
#pragma warning disable IDE1006
#pragma warning disable CA2255 // The 'ModuleInitializer' attribute should not be used in libraries



namespace Goedel.Contacts;


	/// <summary>
	/// </summary>
public abstract partial class Calandars : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Calandars";

	/// <summary>
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(JsCalendarEntry), JsCalendarEntry._binding},
	    {typeof(JsEvent), JsEvent._binding},
	    {typeof(JsTask), JsTask._binding},
	    {typeof(JsGroup), JsGroup._binding},
	    {typeof(Location), Location._binding},
	    {typeof(Link), Link._binding},
	    {typeof(VirtualLocation), VirtualLocation._binding},
	    {typeof(Participant), Participant._binding},
	    {typeof(RecurrenceRule), RecurrenceRule._binding},
	    {typeof(NDay), NDay._binding},
	    {typeof(Alert), Alert._binding},
	    {typeof(Trigger), Trigger._binding},
	    {typeof(TimeZone), TimeZone._binding},
	    {typeof(TimeZoneRule), TimeZoneRule._binding},
	    {typeof(EmptyPatchObject), EmptyPatchObject._binding}
		};

	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static Calandars() {
		_Initialize();
		}

    internal static void _Initialize() {
		AddDictionary(ref _bindingDictionary);
		}

	}



// Service Dispatch Classes



	// Transaction Classes

	/// <summary>
	/// </summary>
public partial class JsCalendarEntry : JmapBase {
    /// <summary>
    ///This relates the object to other objects. This is represented as 
    ///a map of the UIDs of the related objects to information about the relation.
    /// </summary>

	[JsonPropertyName("relatedTo")]
	public virtual Dictionary<string,Relation>?					RelatedTo  {get; set;} //

    /// <summary>
    /// Initially zero, this MUST be incremented by one every time a change is 
    /// made to the object, except if the change only modifies the participants 
    /// property (see Section 4.4.6).
    /// </summary>

	[JsonPropertyName("sequence")]
	public virtual int?					Sequence  {get; set;} //

    /// <summary>
    /// This is the iTIP [RFC5546] method, in lowercase. This MUST only be 
    /// present if the JSCalendar object represents an iTIP scheduling message.
    /// </summary>

	[JsonPropertyName("method")]
	public virtual string?					Method  {get; set;} //

    /// <summary>
    /// This is a short summary of the object.
    /// </summary>

	[JsonPropertyName("title")]
	public virtual string?					Title  {get; set;} //

    /// <summary>
    /// This is a longer-form text description of the object. The content is 
    /// formatted according to the descriptionContentType property.
    /// </summary>

	[JsonPropertyName("description")]
	public virtual string?					Description  {get; set;} //

    /// <summary>
    /// This describes the media type [RFC6838] of the contents of the 
    /// description property. Media types MUST be subtypes of type text
    ///  and SHOULD be text/plain or text/html [MEDIATYPES]. They MAY
    ///  include parameters, and the charset parameter value MUST be 
    /// utf-8, if specified. Descriptions of type text/html MAY contain
    ///  cid URLs [RFC2392] to reference links in the calendar object 
    /// by use of the cid property of the Link object.
    /// </summary>

	[JsonPropertyName("descriptionContentType")]
	public virtual string?					DescriptionContentType  {get; set;} //

    /// <summary>
    /// This indicates that the time is not important to display to the user
    ///  when rendering this calendar object. An example of this is an event
    ///  that conceptually occurs all day or across multiple days, such as 
    /// "New Year's Day" or "Italy Vacation". While the time component is 
    /// important for free-busy calculations and checking for scheduling 
    /// clashes, calendars may choose to omit displaying it and/or display
    ///  the object separately to other objects to enhance the user's 
    /// view of their schedule.
    /// </summary>

	[JsonPropertyName("showWithoutTime")]
	public virtual bool?					ShowWithoutTime  {get; set;} //

    /// <summary>
    /// This is a map of location ids to Location objects, representing locations associated 
    /// with the object.
    /// </summary>

	[JsonPropertyName("locations")]
	public virtual Dictionary<string,Location>?					Locations  {get; set;} //

    /// <summary>
    /// 
    /// </summary>

	[JsonPropertyName("virtualLocations")]
	public virtual Dictionary<string,VirtualLocation>?					VirtualLocations  {get; set;} //

    /// <summary>
    /// This is a map of link ids to Link objects, representing external resources 
    /// associated with the object.
    /// </summary>

	[JsonPropertyName("links")]
	public virtual Dictionary<string,Link>?					links  {get; set;} //

    /// <summary>
    /// This is the language tag, as defined in [RFC5646], that best describes the 
    /// locale used for the text in the calendar object, if known.
    /// </summary>

	[JsonPropertyName("locale")]
	public virtual string?					Locale  {get; set;} //

    /// <summary>
    /// This is a set of keywords or tags that relate to the object. The set is 
    /// represented as a map, with the keys being the keywords. The value for 
    /// each key in the map MUST be true.
    /// </summary>

	[JsonPropertyName("keywords")]
	public virtual Dictionary<string,bool>?					Keywords  {get; set;} //

    /// <summary>
    /// This is a set of categories that relate to the calendar object. The set 
    /// is represented as a map, with the keys being the categories specified 
    /// as URIs. The value for each key in the map MUST be true.
    /// </summary>

	[JsonPropertyName("categories")]
	public virtual Dictionary<string,bool>?					Categories  {get; set;} //

    /// <summary>
    /// This is a color clients MAY use when displaying this calendar object. 
    /// The value is a color name taken from the set of names defined in 
    /// Section 4.3 of CSS Color Module Level 3 [COLORS] or an RGB value 
    /// in hexadecimal notation, as defined in Section 4.2.1 of CSS Color 
    /// Module Level 3.
    /// </summary>

	[JsonPropertyName("color")]
	public virtual string?					Color  {get; set;} //

    /// <summary>
    /// If present, this JSCalendar object represents one occurrence of a 
    /// recurring JSCalendar object. If present, the recurrenceRules and 
    /// recurrenceOverrides properties MUST NOT be present.
    /// </summary>

	[JsonPropertyName("recurrenceId")]
	public virtual string?					RecurrenceId  {get; set;} //

    /// <summary>
    /// Identifies the time zone of the main JSCalendar object, of which 
    /// this JSCalendar object is a recurrence instance. This property 
    /// MUST be set if the recurrenceId property is set. It MUST NOT be 
    /// set if the recurrenceId property is not set.
    /// </summary>

	[JsonPropertyName("recurrenceIdTimeZone")]
	public virtual string?					RecurrenceIdTimeZone  {get; set;} //

    /// <summary>
    /// This defines a set of recurrence rules (repeating patterns) for 
    /// recurring calendar objects.
    /// An Event recurs by applying the recurrence rules to the start date-time.
    /// A Task recurs by applying the recurrence rules to the start date-time, 
    /// if defined; otherwise, it recurs by the due date-time, if defined. 
    /// If the task defines neither a start nor due date-time, it MUST NOT 
    /// define a recurrenceRules property.
    /// </summary>

	[JsonPropertyName("recurrenceRules")]
	public virtual List<RecurrenceRule>?					RecurrenceRules  {get; set;}
    /// <summary>
    /// This defines a set of recurrence rules (repeating patterns) for 
    /// date-times on which the object will not occur. The rules are 
    /// interpreted the same as for the recurrenceRules property 
    /// (see Section 4.3.3), with the exception that the initial date-time 
    /// to which the rule is applied (the "start" date-time for events 
    /// or the "start" or "due" date-time for tasks) is only considered 
    /// part of the expansion if it matches the rule. The resulting 
    /// set of date-times is then removed from those generated by the 
    /// recurrenceRules property, as described in Section 4.3.
    /// </summary>

	[JsonPropertyName("excludedRecurrenceRules")]
	public virtual List<RecurrenceRule>?					ExcludedRecurrenceRules  {get; set;}
    /// <summary>
    /// Maps recurrence ids (the date-time produced by the recurrence rule) 
    /// to the overridden properties of the recurrence instance.
    /// </summary>

	[JsonPropertyName("recurrenceOverrides")]
	public virtual Dictionary<string,JsCalendarEntry>?					RecurrenceOverrides  {get; set;} //

    /// <summary>
    /// This defines if this object is an overridden, excluded instance 
    /// of a recurring JSCalendar object (see Section 4.3.5). If this 
    /// property value is true, this calendar object instance MUST be 
    /// removed from the occurrence expansion. The absence of this 
    /// property, or the presence of its default value as false, 
    /// indicates that this instance MUST be included in the occurrence 
    /// expansion.
    /// </summary>

	[JsonPropertyName("excluded")]
	public virtual bool?					Excluded  {get; set;} //

    /// <summary>
    /// This specifies a priority for the calendar object. This may 
    ///be used as part of scheduling systems to help resolve conflicts 
    /// for a time period.
    /// </summary>

	[JsonPropertyName("priority")]
	public virtual int?					Priority  {get; set;} //

    /// <summary>
    /// This specifies how this calendar object should be treated when 
    /// calculating free-busy state. This MUST be one of the following 
    /// values, another value registered in the IANA "JSCalendar Enum 
    /// Values" registry, or a vendor-specific value (see Section 3.3):
    /// </summary>

	[JsonPropertyName("freeBusyStatus")]
	public virtual string?					FreeBusyStatus  {get; set;} //

    /// <summary>
    /// Calendar objects are normally collected together and may be 
    /// shared with other users. The privacy property allows the 
    /// object owner to indicate that it should not be shared or 
    /// should only have the time information shared but the details 
    /// withheld. Enforcement of the restrictions indicated by this 
    /// property is up to the API via which this object is accessed.
    /// </summary>

	[JsonPropertyName("privacy")]
	public virtual string?					Privacy  {get; set;} //

    /// <summary>
    /// This represents methods by which participants may submit their 
    /// response to the organizer of the calendar object. The keys in 
    /// the property value are the available methods and MUST only 
    /// contain ASCII alphanumeric characters (A-Za-z0-9). The value 
    /// is a URI for the method specified in the key. Future methods 
    /// may be defined in future specifications and registered with 
    /// IANA; a calendar client MUST ignore any method it does not 
    /// understand but MUST preserve the method key and URI. This 
    /// property MUST be omitted if no method is defined (rather 
    /// than being specified as an empty object).
    /// </summary>

	[JsonPropertyName("replyTo")]
	public virtual Dictionary<string,string>?					ReplyTo  {get; set;} //

    /// <summary>
    /// This is the email address in the "From" header of the email 
    /// in which this calendar object was received. This is only relevant 
    /// if the calendar object is received via iMIP or as an attachment to
    /// a message. If set, the value MUST be a valid addr-spec value as 
    /// defined in Section 3.4.1 of [RFC5322].
    /// </summary>

	[JsonPropertyName("sentBy")]
	public virtual string?					SentBy  {get; set;} //

    /// <summary>
    /// This is a map of participant ids to participants, describing 
    /// their participation in the calendar object.
    /// </summary>

	[JsonPropertyName("participants")]
	public virtual Dictionary<string,Participant>?					Participants  {get; set;} //

    /// <summary>
    /// A request status as returned from processing the most recent 
    /// scheduling request for this JSCalendar object. The allowed 
    /// values are defined by the ABNF definitions of statcode, 
    /// statdesc and extdata in Section 3.8.8.3 of [RFC5545] and 
    /// the following ABNF [RFC5234]:
    /// </summary>

	[JsonPropertyName("requestStatus")]
	public virtual string?					RequestStatus  {get; set;} //

    /// <summary>
    /// If true, use the user's default alerts and ignore the value 
    /// of the alerts property. Fetching user defaults is dependent 
    /// on the API from which this JSCalendar object is being fetched 
    /// and is not defined in this specification. If an implementation 
    /// cannot determine the user's default alerts, or none are set, 
    /// it MUST process the alerts property as if useDefaultAlerts is 
    /// set to false.
    /// </summary>

	[JsonPropertyName("useDefaultAlerts")]
	public virtual bool?					UseDefaultAlerts  {get; set;} //

    /// <summary>
    /// This is a map of alert ids to Alert objects, representing 
    /// alerts/reminders to display or send to the user for this calendar 
    /// object.
    /// </summary>

	[JsonPropertyName("alerts")]
	public virtual Dictionary<string,Alert>?					Alerts  {get; set;} //

    /// <summary>
    /// A map where each key is a language tag [RFC5646], and the 
    /// corresponding value is a set of patches to apply to the 
    /// calendar object in order to localize it into that locale.
    /// </summary>

	[JsonPropertyName("localizations")]
	public virtual Dictionary<string,JsCalendarEntry>?					Localizations  {get; set;} //

    /// <summary>
    /// This identifies the time zone the object is scheduled in or
    /// is null for floating time. This is either a name from the IANA
    /// Time Zone Database [TZDB] or the TimeZoneId of a custom time 
    /// zone from the timeZones property (Section 4.7.2). If omitted, 
    /// this MUST be presumed to be null (i.e., floating time).
    /// </summary>

	[JsonPropertyName("timeZone")]
	public virtual string?					TimeZone  {get; set;} //

    /// <summary>
    /// This maps identifiers of custom time zones to their time zone 
    /// definitions. The following restrictions apply for each key in 
    ///the map:
    /// </summary>

	[JsonPropertyName("timeZones")]
	public virtual Dictionary<string,TimeZone>?					TimeZones  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyDictionaryStruct ("relatedTo", typeof (Relation),
					(IBinding data, object? value) => {(data as JsCalendarEntry).RelatedTo = value as Dictionary<string,Relation>;}, 
					(IBinding data) => (data as JsCalendarEntry).RelatedTo,
					false, ()=>new  Dictionary<string,Relation>(), ()=>new Relation(),
					(IBinding data) => (data as JsCalendarEntry).RelatedTo.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Relation>).Add (key as string,value as Relation);}),
		new PropertyInteger32 ("sequence", 
					(IBinding data, int? value) => {(data as JsCalendarEntry).Sequence = value;}, 
					(IBinding data) => (data as JsCalendarEntry).Sequence ),
		new PropertyString ("method", 
					(IBinding data, string? value) => {(data as JsCalendarEntry).Method = value;}, 
					(IBinding data) => (data as JsCalendarEntry).Method ),
		new PropertyString ("title", 
					(IBinding data, string? value) => {(data as JsCalendarEntry).Title = value;}, 
					(IBinding data) => (data as JsCalendarEntry).Title ),
		new PropertyString ("description", 
					(IBinding data, string? value) => {(data as JsCalendarEntry).Description = value;}, 
					(IBinding data) => (data as JsCalendarEntry).Description ),
		new PropertyString ("descriptionContentType", 
					(IBinding data, string? value) => {(data as JsCalendarEntry).DescriptionContentType = value;}, 
					(IBinding data) => (data as JsCalendarEntry).DescriptionContentType ),
		new PropertyBoolean ("showWithoutTime", 
					(IBinding data, bool? value) => {(data as JsCalendarEntry).ShowWithoutTime = value;}, 
					(IBinding data) => (data as JsCalendarEntry).ShowWithoutTime ),
		new PropertyDictionaryStruct ("locations", typeof (Location),
					(IBinding data, object? value) => {(data as JsCalendarEntry).Locations = value as Dictionary<string,Location>;}, 
					(IBinding data) => (data as JsCalendarEntry).Locations,
					false, ()=>new  Dictionary<string,Location>(), ()=>new Location(),
					(IBinding data) => (data as JsCalendarEntry).Locations.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Location>).Add (key as string,value as Location);}),
		new PropertyDictionaryStruct ("virtualLocations", typeof (VirtualLocation),
					(IBinding data, object? value) => {(data as JsCalendarEntry).VirtualLocations = value as Dictionary<string,VirtualLocation>;}, 
					(IBinding data) => (data as JsCalendarEntry).VirtualLocations,
					false, ()=>new  Dictionary<string,VirtualLocation>(), ()=>new VirtualLocation(),
					(IBinding data) => (data as JsCalendarEntry).VirtualLocations.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,VirtualLocation>).Add (key as string,value as VirtualLocation);}),
		new PropertyDictionaryStruct ("links", typeof (Link),
					(IBinding data, object? value) => {(data as JsCalendarEntry).links = value as Dictionary<string,Link>;}, 
					(IBinding data) => (data as JsCalendarEntry).links,
					false, ()=>new  Dictionary<string,Link>(), ()=>new Link(),
					(IBinding data) => (data as JsCalendarEntry).links.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Link>).Add (key as string,value as Link);}),
		new PropertyString ("locale", 
					(IBinding data, string? value) => {(data as JsCalendarEntry).Locale = value;}, 
					(IBinding data) => (data as JsCalendarEntry).Locale ),
		new PropertyDictionaryBoolean ("keywords", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as JsCalendarEntry).Keywords = value;}, 
					(IBinding data) => (data as JsCalendarEntry).Keywords ),
		new PropertyDictionaryBoolean ("categories", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as JsCalendarEntry).Categories = value;}, 
					(IBinding data) => (data as JsCalendarEntry).Categories ),
		new PropertyString ("color", 
					(IBinding data, string? value) => {(data as JsCalendarEntry).Color = value;}, 
					(IBinding data) => (data as JsCalendarEntry).Color ),
		new PropertyString ("recurrenceId", 
					(IBinding data, string? value) => {(data as JsCalendarEntry).RecurrenceId = value;}, 
					(IBinding data) => (data as JsCalendarEntry).RecurrenceId ),
		new PropertyString ("recurrenceIdTimeZone", 
					(IBinding data, string? value) => {(data as JsCalendarEntry).RecurrenceIdTimeZone = value;}, 
					(IBinding data) => (data as JsCalendarEntry).RecurrenceIdTimeZone ),
		new PropertyListStruct ("recurrenceRules", typeof (RecurrenceRule),
					(IBinding data, object? value) => {(data as JsCalendarEntry).RecurrenceRules = value as List<RecurrenceRule>;}, 
					(IBinding data) => (data as JsCalendarEntry).RecurrenceRules,
					false, ()=>new  List<RecurrenceRule>(), ()=>new RecurrenceRule()),
		new PropertyListStruct ("excludedRecurrenceRules", typeof (RecurrenceRule),
					(IBinding data, object? value) => {(data as JsCalendarEntry).ExcludedRecurrenceRules = value as List<RecurrenceRule>;}, 
					(IBinding data) => (data as JsCalendarEntry).ExcludedRecurrenceRules,
					false, ()=>new  List<RecurrenceRule>(), ()=>new RecurrenceRule()),
		new PropertyDictionaryStruct ("recurrenceOverrides", typeof (JsCalendarEntry),
					(IBinding data, object? value) => {(data as JsCalendarEntry).RecurrenceOverrides = value as Dictionary<string,JsCalendarEntry>;}, 
					(IBinding data) => (data as JsCalendarEntry).RecurrenceOverrides,
					false, ()=>new  Dictionary<string,JsCalendarEntry>(), ()=>new JsCalendarEntry(),
					(IBinding data) => (data as JsCalendarEntry).RecurrenceOverrides.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,JsCalendarEntry>).Add (key as string,value as JsCalendarEntry);}),
		new PropertyBoolean ("excluded", 
					(IBinding data, bool? value) => {(data as JsCalendarEntry).Excluded = value;}, 
					(IBinding data) => (data as JsCalendarEntry).Excluded ),
		new PropertyInteger32 ("priority", 
					(IBinding data, int? value) => {(data as JsCalendarEntry).Priority = value;}, 
					(IBinding data) => (data as JsCalendarEntry).Priority ),
		new PropertyString ("freeBusyStatus", 
					(IBinding data, string? value) => {(data as JsCalendarEntry).FreeBusyStatus = value;}, 
					(IBinding data) => (data as JsCalendarEntry).FreeBusyStatus ),
		new PropertyString ("privacy", 
					(IBinding data, string? value) => {(data as JsCalendarEntry).Privacy = value;}, 
					(IBinding data) => (data as JsCalendarEntry).Privacy ),
		new PropertyDictionaryString ("replyTo", 
					(IBinding data, Dictionary<string,string>? value) => {(data as JsCalendarEntry).ReplyTo = value;}, 
					(IBinding data) => (data as JsCalendarEntry).ReplyTo ),
		new PropertyString ("sentBy", 
					(IBinding data, string? value) => {(data as JsCalendarEntry).SentBy = value;}, 
					(IBinding data) => (data as JsCalendarEntry).SentBy ),
		new PropertyDictionaryStruct ("participants", typeof (Participant),
					(IBinding data, object? value) => {(data as JsCalendarEntry).Participants = value as Dictionary<string,Participant>;}, 
					(IBinding data) => (data as JsCalendarEntry).Participants,
					false, ()=>new  Dictionary<string,Participant>(), ()=>new Participant(),
					(IBinding data) => (data as JsCalendarEntry).Participants.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Participant>).Add (key as string,value as Participant);}),
		new PropertyString ("requestStatus", 
					(IBinding data, string? value) => {(data as JsCalendarEntry).RequestStatus = value;}, 
					(IBinding data) => (data as JsCalendarEntry).RequestStatus ),
		new PropertyBoolean ("useDefaultAlerts", 
					(IBinding data, bool? value) => {(data as JsCalendarEntry).UseDefaultAlerts = value;}, 
					(IBinding data) => (data as JsCalendarEntry).UseDefaultAlerts ),
		new PropertyDictionaryStruct ("alerts", typeof (Alert),
					(IBinding data, object? value) => {(data as JsCalendarEntry).Alerts = value as Dictionary<string,Alert>;}, 
					(IBinding data) => (data as JsCalendarEntry).Alerts,
					false, ()=>new  Dictionary<string,Alert>(), ()=>new Alert(),
					(IBinding data) => (data as JsCalendarEntry).Alerts.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Alert>).Add (key as string,value as Alert);}),
		new PropertyDictionaryStruct ("localizations", typeof (JsCalendarEntry),
					(IBinding data, object? value) => {(data as JsCalendarEntry).Localizations = value as Dictionary<string,JsCalendarEntry>;}, 
					(IBinding data) => (data as JsCalendarEntry).Localizations,
					false, ()=>new  Dictionary<string,JsCalendarEntry>(), ()=>new JsCalendarEntry(),
					(IBinding data) => (data as JsCalendarEntry).Localizations.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,JsCalendarEntry>).Add (key as string,value as JsCalendarEntry);}),
		new PropertyString ("timeZone", 
					(IBinding data, string? value) => {(data as JsCalendarEntry).TimeZone = value;}, 
					(IBinding data) => (data as JsCalendarEntry).TimeZone ),
		new PropertyDictionaryStruct ("timeZones", typeof (TimeZone),
					(IBinding data, object? value) => {(data as JsCalendarEntry).TimeZones = value as Dictionary<string,TimeZone>;}, 
					(IBinding data) => (data as JsCalendarEntry).TimeZones,
					false, ()=>new  Dictionary<string,TimeZone>(), ()=>new TimeZone(),
					(IBinding data) => (data as JsCalendarEntry).TimeZones.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,TimeZone>).Add (key as string,value as TimeZone);})
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<JsCalendarEntry> _binding = new (
			new() {
			{ "relatedTo", _properties [0]},
			{ "sequence", _properties [1]},
			{ "method", _properties [2]},
			{ "title", _properties [3]},
			{ "description", _properties [4]},
			{ "descriptionContentType", _properties [5]},
			{ "showWithoutTime", _properties [6]},
			{ "locations", _properties [7]},
			{ "virtualLocations", _properties [8]},
			{ "links", _properties [9]},
			{ "locale", _properties [10]},
			{ "keywords", _properties [11]},
			{ "categories", _properties [12]},
			{ "color", _properties [13]},
			{ "recurrenceId", _properties [14]},
			{ "recurrenceIdTimeZone", _properties [15]},
			{ "recurrenceRules", _properties [16]},
			{ "excludedRecurrenceRules", _properties [17]},
			{ "recurrenceOverrides", _properties [18]},
			{ "excluded", _properties [19]},
			{ "priority", _properties [20]},
			{ "freeBusyStatus", _properties [21]},
			{ "privacy", _properties [22]},
			{ "replyTo", _properties [23]},
			{ "sentBy", _properties [24]},
			{ "participants", _properties [25]},
			{ "requestStatus", _properties [26]},
			{ "useDefaultAlerts", _properties [27]},
			{ "alerts", _properties [28]},
			{ "localizations", _properties [29]},
			{ "timeZone", _properties [30]},
			{ "timeZones", _properties [31]}}, __Tag,
		() => new JsCalendarEntry(), () => [], () => [], JmapBase._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "JsCalendarEntry";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JsCalendarEntry();

	}


	/// <summary>
	///
	///  In addition to the common JSCalendar object properties (Section 4), 
	///  an Event has the following properties:
	/// </summary>
public partial class JsEvent : JsCalendarEntry {
    /// <summary>
    /// This is the date/time the event starts in the event's time 
    /// zone (as specified in the timeZone property, see Section 4.7.1).
    /// </summary>

	[JsonPropertyName("start")]
	public virtual string?					Start  {get; set;} //

    /// <summary>
    /// This is the zero or positive duration of the event in the 
    /// event's start time zone. The end time of an event can be 
    /// found by adding the duration to the event's start time.
    /// </summary>

	[JsonPropertyName("duration")]
	public virtual string?					Duration  {get; set;} //

    /// <summary>
    /// This is the scheduling status (Section 4.4) of an Event. 
    /// If set, it MUST be one of the following values, another 
    /// value registered in the IANA "JSCalendar Enum Values" registry,
    /// or a vendor-specific value (see Section 3.3):
    /// </summary>

	[JsonPropertyName("status")]
	public virtual string?					Status  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("start", 
					(IBinding data, string? value) => {(data as JsEvent).Start = value;}, 
					(IBinding data) => (data as JsEvent).Start ),
		new PropertyString ("duration", 
					(IBinding data, string? value) => {(data as JsEvent).Duration = value;}, 
					(IBinding data) => (data as JsEvent).Duration ),
		new PropertyString ("status", 
					(IBinding data, string? value) => {(data as JsEvent).Status = value;}, 
					(IBinding data) => (data as JsEvent).Status )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<JsEvent> _binding = new (
			new() {
			{ "start", _properties [0]},
			{ "duration", _properties [1]},
			{ "status", _properties [2]}}, __Tag,
		() => new JsEvent(), () => [], () => [], JsCalendarEntry._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "JsEvent";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JsEvent();

	}


	/// <summary>
	///
	///  In addition to the common JSCalendar object properties (Section 4), 
	///  a Task has the following properties
	/// </summary>
public partial class JsTask : JsCalendarEntry {
    /// <summary>
    /// This is the date/time the task is due in the task's time zone.
    /// </summary>

	[JsonPropertyName("due")]
	public virtual string?					Due  {get; set;} //

    /// <summary>
    /// This the date/time the task should start in the task's time zone.
    /// </summary>

	[JsonPropertyName("start")]
	public virtual string?					Start  {get; set;} //

    /// <summary>
    /// This specifies the estimated positive duration of time the task
    /// takes to complete.
    /// </summary>

	[JsonPropertyName("estimatedDuration")]
	public virtual string?					EstimatedDuration  {get; set;} //

    /// <summary>
    /// This represents the percent completion of the task overall. 
    /// The property value MUST be a positive integer between 0 and 100.
    /// </summary>

	[JsonPropertyName("percentComplete")]
	public virtual int?					PercentComplete  {get; set;} //

    /// <summary>
    /// This defines the progress of this task. If omitted, the default 
    /// progress (Section 4.4) of a Task is defined as follows (in order 
    /// of evaluation):
    /// </summary>

	[JsonPropertyName("progress")]
	public virtual string?					Progress  {get; set;} //

    /// <summary>
    /// This specifies the date/time the progress property of either 
    /// the task overall (Section 5.2.5) or a specific participant 
    /// (Section 4.4.6) was last updated.
    /// </summary>

	[JsonPropertyName("progressUpdated")]
	public virtual DateTime?					ProgressUpdated  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("due", 
					(IBinding data, string? value) => {(data as JsTask).Due = value;}, 
					(IBinding data) => (data as JsTask).Due ),
		new PropertyString ("start", 
					(IBinding data, string? value) => {(data as JsTask).Start = value;}, 
					(IBinding data) => (data as JsTask).Start ),
		new PropertyString ("estimatedDuration", 
					(IBinding data, string? value) => {(data as JsTask).EstimatedDuration = value;}, 
					(IBinding data) => (data as JsTask).EstimatedDuration ),
		new PropertyInteger32 ("percentComplete", 
					(IBinding data, int? value) => {(data as JsTask).PercentComplete = value;}, 
					(IBinding data) => (data as JsTask).PercentComplete ),
		new PropertyString ("progress", 
					(IBinding data, string? value) => {(data as JsTask).Progress = value;}, 
					(IBinding data) => (data as JsTask).Progress ),
		new PropertyDateTime ("progressUpdated", 
					(IBinding data, DateTime? value) => {(data as JsTask).ProgressUpdated = value;}, 
					(IBinding data) => (data as JsTask).ProgressUpdated )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<JsTask> _binding = new (
			new() {
			{ "due", _properties [0]},
			{ "start", _properties [1]},
			{ "estimatedDuration", _properties [2]},
			{ "percentComplete", _properties [3]},
			{ "progress", _properties [4]},
			{ "progressUpdated", _properties [5]}}, __Tag,
		() => new JsTask(), () => [], () => [], JsCalendarEntry._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "JsTask";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JsTask();

	}


	/// <summary>
	/// </summary>
public partial class JsGroup : JsCalendarEntry {
    /// <summary>
    /// This is a collection of group members. Implementations MUST 
    /// ignore entries of unknown type.
    /// </summary>

	[JsonPropertyName("entries")]
	public virtual List<JmapBase>?					Entries  {get; set;}
    /// <summary>
    /// This is the source from which updated versions of this group 
    /// may be retrieved. The value MUST be a URI.
    /// </summary>

	[JsonPropertyName("source")]
	public virtual string?					Source  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListStruct ("entries", typeof (JmapBase),
					(IBinding data, object? value) => {(data as JsGroup).Entries = value as List<JmapBase>;}, 
					(IBinding data) => (data as JsGroup).Entries,
					false, ()=>new  List<JmapBase>(), ()=>new JmapBase()),
		new PropertyString ("source", 
					(IBinding data, string? value) => {(data as JsGroup).Source = value;}, 
					(IBinding data) => (data as JsGroup).Source )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<JsGroup> _binding = new (
			new() {
			{ "entries", _properties [0]},
			{ "source", _properties [1]}}, __Tag,
		() => new JsGroup(), () => [], () => [], JsCalendarEntry._binding, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "JsGroup";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JsGroup();

	}


	/// <summary>
	/// </summary>
public partial class Location : Calandars {
    /// <summary>
    /// A Location object has the following properties. It MUST have at least 
    /// one property other than the relativeTo property.
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// This is the human-readable name of the location.
    /// </summary>

	[JsonPropertyName("name")]
	public virtual string?					Name  {get; set;} //

    /// <summary>
    /// This is the human-readable, plain-text instructions for accessing this location. 
    /// This may be an address, set of directions, door access code, etc.
    /// </summary>

	[JsonPropertyName("description")]
	public virtual string?					Description  {get; set;} //

    /// <summary>
    /// This is a set of one or more location types that describe this location. All 
    /// types MUST be from the "Location Types Registry" [LOCATIONTYPES], as defined 
    /// in [RFC4589]. The set is represented as a map, with the keys being the
    /// location types. The value for each key in the map MUST be true.
    /// </summary>

	[JsonPropertyName("locationTypes")]
	public virtual Dictionary<string,bool>?					LocationTypes  {get; set;} //

    /// <summary>
    /// This specifies the relation between this location and the time of the JSCalendar 
    /// object. This is primarily to allow events representing travel to specify the 
    /// location of departure (at the start of the event) and location of arrival
    /// (at the end); this is particularly important if these locations are in 
    /// different time zones, as a client may wish to highlight this information 
    /// for the user.
    /// </summary>

	[JsonPropertyName("relativeTo")]
	public virtual string?					RelativeTo  {get; set;} //

    /// <summary>
    /// This is a time zone for this location.
    /// </summary>

	[JsonPropertyName("timeZone")]
	public virtual string?					TimeZone  {get; set;} //

    /// <summary>
    /// This is a geo: URI [RFC5870] for the location.
    /// </summary>

	[JsonPropertyName("coordinates")]
	public virtual string?					Coordinates  {get; set;} //

    /// <summary>
    /// This is a map of link ids to Link objects, representing external resources 
    /// associated with this location, for example, a vCard or image. If there are 
    /// no links, this MUST be omitted (rather than specified as an empty set).
    /// </summary>

	[JsonPropertyName("link")]
	public virtual Dictionary<string,Link>?					Link  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as Location).Type = value;}, 
					(IBinding data) => (data as Location).Type ),
		new PropertyString ("name", 
					(IBinding data, string? value) => {(data as Location).Name = value;}, 
					(IBinding data) => (data as Location).Name ),
		new PropertyString ("description", 
					(IBinding data, string? value) => {(data as Location).Description = value;}, 
					(IBinding data) => (data as Location).Description ),
		new PropertyDictionaryBoolean ("locationTypes", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as Location).LocationTypes = value;}, 
					(IBinding data) => (data as Location).LocationTypes ),
		new PropertyString ("relativeTo", 
					(IBinding data, string? value) => {(data as Location).RelativeTo = value;}, 
					(IBinding data) => (data as Location).RelativeTo ),
		new PropertyString ("timeZone", 
					(IBinding data, string? value) => {(data as Location).TimeZone = value;}, 
					(IBinding data) => (data as Location).TimeZone ),
		new PropertyString ("coordinates", 
					(IBinding data, string? value) => {(data as Location).Coordinates = value;}, 
					(IBinding data) => (data as Location).Coordinates ),
		new PropertyDictionaryStruct ("link", typeof (Link),
					(IBinding data, object? value) => {(data as Location).Link = value as Dictionary<string,Link>;}, 
					(IBinding data) => (data as Location).Link,
					false, ()=>new  Dictionary<string,Link>(), ()=>new Link(),
					(IBinding data) => (data as Location).Link.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Link>).Add (key as string,value as Link);})
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Location> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "name", _properties [1]},
			{ "description", _properties [2]},
			{ "locationTypes", _properties [3]},
			{ "relativeTo", _properties [4]},
			{ "timeZone", _properties [5]},
			{ "coordinates", _properties [6]},
			{ "link", _properties [7]}}, __Tag,
		() => new Location(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Location";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Location();

	}


	/// <summary>
	/// </summary>
public partial class Link : Calandars {
    /// <summary>
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// This MUST be a valid content-id value according to the definition of 
    /// Section 2 of [RFC2392]. The value MUST be unique within this Link object
    /// but has no meaning beyond that. It MAY be different from the link id for 
    /// this Link object.
    /// </summary>

	[JsonPropertyName("cid")]
	public virtual string?					Cid  {get; set;} //

    /// <summary>
    /// This is the media type [RFC6838] of the resource, if known.
    /// </summary>

	[JsonPropertyName("contentType")]
	public virtual string?					ContentType  {get; set;} //

    /// <summary>
    /// This is the size, in octets, of the resource when fully decoded (i.e., 
    /// the number of octets in the file the user would download), if known. 
    /// Note that this is an informational estimate, and implementations must 
    /// be prepared to handle the actual size being quite different when the 
    /// resource is fetched.
    /// </summary>

	[JsonPropertyName("size")]
	public virtual int?					Size  {get; set;} //

    /// <summary>
    /// This identifies the relation of the linked resource to the object. 
    /// If set, the value MUST be a relation type from the IANA "Link 
    /// Relations" registry [LINKRELS], as established in [RFC8288].
    /// </summary>

	[JsonPropertyName("rel")]
	public virtual string?					Rel  {get; set;} //

    /// <summary>
    /// This describes the intended purpose of a link to an image. If set, 
    /// the rel property MUST be set to icon. The value MUST be one of the 
    /// following values, another value registered in the IANA "JSCalendar 
    /// Enum Values" registry, or a vendor-specific value (see Section 3.3):
    /// </summary>

	[JsonPropertyName("display")]
	public virtual string?					Display  {get; set;} //

    /// <summary>
    /// This is a human-readable, plain-text description of the resource.
    /// </summary>

	[JsonPropertyName("title")]
	public virtual string?					Title  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as Link).Type = value;}, 
					(IBinding data) => (data as Link).Type ),
		new PropertyString ("cid", 
					(IBinding data, string? value) => {(data as Link).Cid = value;}, 
					(IBinding data) => (data as Link).Cid ),
		new PropertyString ("contentType", 
					(IBinding data, string? value) => {(data as Link).ContentType = value;}, 
					(IBinding data) => (data as Link).ContentType ),
		new PropertyInteger32 ("size", 
					(IBinding data, int? value) => {(data as Link).Size = value;}, 
					(IBinding data) => (data as Link).Size ),
		new PropertyString ("rel", 
					(IBinding data, string? value) => {(data as Link).Rel = value;}, 
					(IBinding data) => (data as Link).Rel ),
		new PropertyString ("display", 
					(IBinding data, string? value) => {(data as Link).Display = value;}, 
					(IBinding data) => (data as Link).Display ),
		new PropertyString ("title", 
					(IBinding data, string? value) => {(data as Link).Title = value;}, 
					(IBinding data) => (data as Link).Title )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Link> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "cid", _properties [1]},
			{ "contentType", _properties [2]},
			{ "size", _properties [3]},
			{ "rel", _properties [4]},
			{ "display", _properties [5]},
			{ "title", _properties [6]}}, __Tag,
		() => new Link(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Link";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Link();

	}


	/// <summary>
	/// </summary>
public partial class VirtualLocation : Calandars {
    /// <summary>
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// This is the human-readable name of the virtual location.
    /// </summary>

	[JsonPropertyName("name")]
	public virtual string?					Name  {get; set;} //

    /// <summary>
    /// These are human-readable plain-text instructions for accessing this virtual 
    /// location. This may be a conference access code, etc.
    /// </summary>

	[JsonPropertyName("description")]
	public virtual string?					Description  {get; set;} //

    /// <summary>
    /// This is a URI [RFC3986] that represents how to connect to this virtual location.
    /// </summary>

	[JsonPropertyName("uri")]
	public virtual string?					Uri  {get; set;} //

    /// <summary>
    /// A set of features supported by this virtual location. The set is represented 
    /// as a map, with the keys being the feature. The value for each key in the map 
    /// MUST be true.
    /// </summary>

	[JsonPropertyName("features")]
	public virtual Dictionary<string,bool>?					Features  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as VirtualLocation).Type = value;}, 
					(IBinding data) => (data as VirtualLocation).Type ),
		new PropertyString ("name", 
					(IBinding data, string? value) => {(data as VirtualLocation).Name = value;}, 
					(IBinding data) => (data as VirtualLocation).Name ),
		new PropertyString ("description", 
					(IBinding data, string? value) => {(data as VirtualLocation).Description = value;}, 
					(IBinding data) => (data as VirtualLocation).Description ),
		new PropertyString ("uri", 
					(IBinding data, string? value) => {(data as VirtualLocation).Uri = value;}, 
					(IBinding data) => (data as VirtualLocation).Uri ),
		new PropertyDictionaryBoolean ("features", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as VirtualLocation).Features = value;}, 
					(IBinding data) => (data as VirtualLocation).Features )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<VirtualLocation> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "name", _properties [1]},
			{ "description", _properties [2]},
			{ "uri", _properties [3]},
			{ "features", _properties [4]}}, __Tag,
		() => new VirtualLocation(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "VirtualLocation";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new VirtualLocation();

	}


	/// <summary>
	///
	///  A Participant object has the following properties:
	/// </summary>
public partial class Participant : Calandars {
    /// <summary>
    /// This specifies the type of this object. This MUST be Participant.
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// This is the display name of the participant (e.g., "Joe Bloggs").
    /// </summary>

	[JsonPropertyName("name")]
	public virtual string?					name  {get; set;} //

    /// <summary>
    /// This is the email address to use to contact the participant or, 
    /// for example, match with an address book entry. If set, the value 
    /// MUST be a valid addr-spec value as defined in Section 3.4.1 of [RFC5322].
    /// </summary>

	[JsonPropertyName("email")]
	public virtual string?					email  {get; set;} //

    /// <summary>
    /// This is a plain-text description of this participant. For example,
    /// this may include more information about their role in the event 
    /// or how best to contact them.
    /// </summary>

	[JsonPropertyName("description")]
	public virtual string?					description  {get; set;} //

    /// <summary>
    /// This represents methods by which the participant may receive the 
    /// invitation and updates to the calendar object.
    /// </summary>

	[JsonPropertyName("sendTo")]
	public virtual Dictionary<string,string>?					sendTo  {get; set;} //

    /// <summary>
    /// a single person
    /// </summary>

	[JsonPropertyName("individual")]
	public virtual string?					individual  {get; set;} //

    /// <summary>
    /// a collection of people invited as a whole
    /// </summary>

	[JsonPropertyName("group")]
	public virtual string?					group  {get; set;} //

    /// <summary>
    /// a physical location that needs to be scheduled, e.g., a conference room
    /// </summary>

	[JsonPropertyName("location")]
	public virtual string?					location  {get; set;} //

    /// <summary>
    /// a non-human resource other than a location, such as a projector
    /// </summary>

	[JsonPropertyName("resource")]
	public virtual string?					resource  {get; set;} //

    /// <summary>
    /// This is a set of roles that this participant fulfills.
    /// At least one role MUST be specified for the participant. The keys 
    /// in the set MUST be one of the following values, another value registered
    /// in the IANA "JSCalendar Enum Values" registry, or a vendor-specific value 
    /// (see Section 3.3):
    /// </summary>

	[JsonPropertyName("roles")]
	public virtual Dictionary<string,bool>?					roles  {get; set;} //

    /// <summary>
    /// This is the location at which this participant is expected to be attending.
    /// </summary>

	[JsonPropertyName("locationId")]
	public virtual string?					locationId  {get; set;} //

    /// <summary>
    /// This is the language tag, as defined in [RFC5646], that best describes the 
    /// participant's preferred language, if known.
    /// </summary>

	[JsonPropertyName("language")]
	public virtual string?					language  {get; set;} //

    /// <summary>
    /// This is the participation status, if any, of this participant.
    /// </summary>

	[JsonPropertyName("participationStatus")]
	public virtual string?					participationStatus  {get; set;} //

    /// <summary>
    /// This is a note from the participant to explain their participation status.
    /// </summary>

	[JsonPropertyName("participationComment")]
	public virtual string?					participationComment  {get; set;} //

    /// <summary>
    /// If true, the organizer is expecting the participant to notify them of their 
    /// participation status.
    /// </summary>

	[JsonPropertyName("expectReply")]
	public virtual bool?					expectReply  {get; set;} //

    /// <summary>
    /// This is who is responsible for sending scheduling messages with this 
    /// calendar object to the participant.
    /// </summary>

	[JsonPropertyName("scheduleAgent")]
	public virtual string?					scheduleAgent  {get; set;} //

    /// <summary>
    /// A client may set the property on a participant to true to request that the server send a scheduling message to the participant when it would not normally do so (e.g., if no significant change is made the object or the scheduleAgent is set to client). The property MUST NOT be stored in the JSCalendar object on the server or appear in a scheduling message.
    /// </summary>

	[JsonPropertyName("scheduleForceSend")]
	public virtual bool?					scheduleForceSend  {get; set;} //

    /// <summary>
    /// This is the sequence number of the last response from the participant. If defined, this MUST be a nonnegative integer.
    /// </summary>

	[JsonPropertyName("scheduleSequence")]
	public virtual int?					scheduleSequence  {get; set;} //

    /// <summary>
    /// This is a list of status codes, returned from the processing of the most recent scheduling message sent to this participant. The status codes MUST be valid statcode values as defined in the ABNF in Section 3.8.8.3 of [RFC5545].
    /// </summary>

	[JsonPropertyName("scheduleStatus")]
	public virtual List<string>?					scheduleStatus  {get; set;}
    /// <summary>
    /// This is the timestamp for the most recent response from this participant.
    /// </summary>

	[JsonPropertyName("scheduleUpdated")]
	public virtual string?					scheduleUpdated  {get; set;} //

    /// <summary>
    /// This is the email address in the "From" header of the email that last updated this participant via iMIP. This SHOULD only be set if the email address is different to that in the mailto URI of this participant's imip method in the sendTo property (i.e., the response was received from a different address to that which the invitation was sent to). If set, the value MUST be a valid addr-spec value as defined in Section 3.4.1 of [RFC5322].
    /// </summary>

	[JsonPropertyName("sentBy")]
	public virtual string?					sentBy  {get; set;} //

    /// <summary>
    /// This is the id of the participant who added this participant to the event/task, if known.
    /// </summary>

	[JsonPropertyName("invitedBy")]
	public virtual string?					invitedBy  {get; set;} //

    /// <summary>
    /// This is set of participant ids that this participant has delegated their participation to. Each key in the set MUST be the id of a participant. The value for each key in the map MUST be true. If there are no delegates, this MUST be omitted (rather than specified as an empty set).
    /// </summary>

	[JsonPropertyName("delegatedTo")]
	public virtual Dictionary<string,bool>?					delegatedTo  {get; set;} //

    /// <summary>
    /// This is a set of participant ids that this participant is acting as a delegate for. Each key in the set MUST be the id of a participant. The value for each key in the map MUST be true. If there are no delegators, this MUST be omitted (rather than specified as an empty set).
    /// </summary>

	[JsonPropertyName("delegatedFrom")]
	public virtual Dictionary<string,bool>?					delegatedFrom  {get; set;} //

    /// <summary>
    /// This is a set of group participants that were invited to this calendar object, which caused this participant to be invited due to their membership in the group(s). Each key in the set MUST be the id of a participant. The value for each key in the map MUST be true. If there are no groups, this MUST be omitted (rather than specified as an empty set).
    /// </summary>

	[JsonPropertyName("memberOf")]
	public virtual Dictionary<string,bool>?					memberOf  {get; set;} //

    /// <summary>
    /// This is a map of link ids to Link objects, representing external resources associated with this participant, for example, a vCard or image. If there are no links, this MUST be omitted (rather than specified as an empty set).
    /// </summary>

	[JsonPropertyName("links")]
	public virtual Dictionary<string,Link>?					links  {get; set;} //

    /// <summary>
    /// This represents the progress of the participant for this task. It MUST NOT be set if the participationStatus of this participant is any value other than accepted. See Section 5.2.5 for allowed values and semantics.
    /// </summary>

	[JsonPropertyName("progress")]
	public virtual string?					progress  {get; set;} //

    /// <summary>
    /// This specifies the date-time the progress property was last set on this participant. See Section 5.2.6 for allowed values and semantics.
    /// </summary>

	[JsonPropertyName("progressUpdated")]
	public virtual DateTime?					progressUpdated  {get; set;} //

    /// <summary>
    /// This represents the percent completion of the participant for this task. The property value MUST be a positive integer between 0 and 100.
    /// </summary>

	[JsonPropertyName("percentComplete")]
	public virtual int?					percentComplete  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as Participant).Type = value;}, 
					(IBinding data) => (data as Participant).Type ),
		new PropertyString ("name", 
					(IBinding data, string? value) => {(data as Participant).name = value;}, 
					(IBinding data) => (data as Participant).name ),
		new PropertyString ("email", 
					(IBinding data, string? value) => {(data as Participant).email = value;}, 
					(IBinding data) => (data as Participant).email ),
		new PropertyString ("description", 
					(IBinding data, string? value) => {(data as Participant).description = value;}, 
					(IBinding data) => (data as Participant).description ),
		new PropertyDictionaryString ("sendTo", 
					(IBinding data, Dictionary<string,string>? value) => {(data as Participant).sendTo = value;}, 
					(IBinding data) => (data as Participant).sendTo ),
		new PropertyString ("individual", 
					(IBinding data, string? value) => {(data as Participant).individual = value;}, 
					(IBinding data) => (data as Participant).individual ),
		new PropertyString ("group", 
					(IBinding data, string? value) => {(data as Participant).group = value;}, 
					(IBinding data) => (data as Participant).group ),
		new PropertyString ("location", 
					(IBinding data, string? value) => {(data as Participant).location = value;}, 
					(IBinding data) => (data as Participant).location ),
		new PropertyString ("resource", 
					(IBinding data, string? value) => {(data as Participant).resource = value;}, 
					(IBinding data) => (data as Participant).resource ),
		new PropertyDictionaryBoolean ("roles", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as Participant).roles = value;}, 
					(IBinding data) => (data as Participant).roles ),
		new PropertyString ("locationId", 
					(IBinding data, string? value) => {(data as Participant).locationId = value;}, 
					(IBinding data) => (data as Participant).locationId ),
		new PropertyString ("language", 
					(IBinding data, string? value) => {(data as Participant).language = value;}, 
					(IBinding data) => (data as Participant).language ),
		new PropertyString ("participationStatus", 
					(IBinding data, string? value) => {(data as Participant).participationStatus = value;}, 
					(IBinding data) => (data as Participant).participationStatus ),
		new PropertyString ("participationComment", 
					(IBinding data, string? value) => {(data as Participant).participationComment = value;}, 
					(IBinding data) => (data as Participant).participationComment ),
		new PropertyBoolean ("expectReply", 
					(IBinding data, bool? value) => {(data as Participant).expectReply = value;}, 
					(IBinding data) => (data as Participant).expectReply ),
		new PropertyString ("scheduleAgent", 
					(IBinding data, string? value) => {(data as Participant).scheduleAgent = value;}, 
					(IBinding data) => (data as Participant).scheduleAgent ),
		new PropertyBoolean ("scheduleForceSend", 
					(IBinding data, bool? value) => {(data as Participant).scheduleForceSend = value;}, 
					(IBinding data) => (data as Participant).scheduleForceSend ),
		new PropertyInteger32 ("scheduleSequence", 
					(IBinding data, int? value) => {(data as Participant).scheduleSequence = value;}, 
					(IBinding data) => (data as Participant).scheduleSequence ),
		new PropertyListString ("scheduleStatus", 
					(IBinding data, List<string>? value) => {(data as Participant).scheduleStatus = value;}, 
					(IBinding data) => (data as Participant).scheduleStatus ),
		new PropertyString ("scheduleUpdated", 
					(IBinding data, string? value) => {(data as Participant).scheduleUpdated = value;}, 
					(IBinding data) => (data as Participant).scheduleUpdated ),
		new PropertyString ("sentBy", 
					(IBinding data, string? value) => {(data as Participant).sentBy = value;}, 
					(IBinding data) => (data as Participant).sentBy ),
		new PropertyString ("invitedBy", 
					(IBinding data, string? value) => {(data as Participant).invitedBy = value;}, 
					(IBinding data) => (data as Participant).invitedBy ),
		new PropertyDictionaryBoolean ("delegatedTo", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as Participant).delegatedTo = value;}, 
					(IBinding data) => (data as Participant).delegatedTo ),
		new PropertyDictionaryBoolean ("delegatedFrom", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as Participant).delegatedFrom = value;}, 
					(IBinding data) => (data as Participant).delegatedFrom ),
		new PropertyDictionaryBoolean ("memberOf", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as Participant).memberOf = value;}, 
					(IBinding data) => (data as Participant).memberOf ),
		new PropertyDictionaryStruct ("links", typeof (Link),
					(IBinding data, object? value) => {(data as Participant).links = value as Dictionary<string,Link>;}, 
					(IBinding data) => (data as Participant).links,
					false, ()=>new  Dictionary<string,Link>(), ()=>new Link(),
					(IBinding data) => (data as Participant).links.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Link>).Add (key as string,value as Link);}),
		new PropertyString ("progress", 
					(IBinding data, string? value) => {(data as Participant).progress = value;}, 
					(IBinding data) => (data as Participant).progress ),
		new PropertyDateTime ("progressUpdated", 
					(IBinding data, DateTime? value) => {(data as Participant).progressUpdated = value;}, 
					(IBinding data) => (data as Participant).progressUpdated ),
		new PropertyInteger32 ("percentComplete", 
					(IBinding data, int? value) => {(data as Participant).percentComplete = value;}, 
					(IBinding data) => (data as Participant).percentComplete )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Participant> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "name", _properties [1]},
			{ "email", _properties [2]},
			{ "description", _properties [3]},
			{ "sendTo", _properties [4]},
			{ "individual", _properties [5]},
			{ "group", _properties [6]},
			{ "location", _properties [7]},
			{ "resource", _properties [8]},
			{ "roles", _properties [9]},
			{ "locationId", _properties [10]},
			{ "language", _properties [11]},
			{ "participationStatus", _properties [12]},
			{ "participationComment", _properties [13]},
			{ "expectReply", _properties [14]},
			{ "scheduleAgent", _properties [15]},
			{ "scheduleForceSend", _properties [16]},
			{ "scheduleSequence", _properties [17]},
			{ "scheduleStatus", _properties [18]},
			{ "scheduleUpdated", _properties [19]},
			{ "sentBy", _properties [20]},
			{ "invitedBy", _properties [21]},
			{ "delegatedTo", _properties [22]},
			{ "delegatedFrom", _properties [23]},
			{ "memberOf", _properties [24]},
			{ "links", _properties [25]},
			{ "progress", _properties [26]},
			{ "progressUpdated", _properties [27]},
			{ "percentComplete", _properties [28]}}, __Tag,
		() => new Participant(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Participant";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Participant();

	}


	/// <summary>
	/// </summary>
public partial class RecurrenceRule : Calandars {
    /// <summary>
    /// This specifies the type of this object. This MUST be RecurrenceRule.
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// This is the time span covered by each iteration of this recurrence 
    /// rule (see Section 4.3.3.1 for full semantics). 
    /// </summary>

	[JsonPropertyName("frequency")]
	public virtual string?					frequency  {get; set;} //

    /// <summary>
    /// This is the interval of iteration periods at which the recurrence
    /// repeats. If included, it MUST be an integer >= 1.
    /// </summary>

	[JsonPropertyName("interval")]
	public virtual int?					interval  {get; set;} //

    /// <summary>
    /// This is the calendar system in which this recurrence rule operates, 
    /// in lowercase. This MUST be either a CLDR-registered calendar system 
    /// name [CLDR] or a vendor-specific value (see Section 3.3).
    /// </summary>

	[JsonPropertyName("rscale")]
	public virtual string?					rscale  {get; set;} //

    /// <summary>
    /// This is the behavior to use when the expansion of the recurrence 
    /// produces invalid dates. This property only has an effect if the 
    /// frequency is "yearly" or "monthly". It MUST be one of the following 
    /// values:
    /// </summary>

	[JsonPropertyName("skip")]
	public virtual string?					skip  {get; set;} //

    /// <summary>
    /// This is the day on which the week is considered to start, 
    /// represented as a lowercase, abbreviated, and two-letter English 
    /// day of the week. If included, it MUST be one of the following 
    /// values:
    /// </summary>

	[JsonPropertyName("firstDayOfWeek")]
	public virtual string?					firstDayOfWeek  {get; set;} //

    /// <summary>
    /// These are days of the week on which to repeat. 
    /// </summary>

	[JsonPropertyName("byDay")]
	public virtual List<NDay>?					byDay  {get; set;}
    /// <summary>
    /// If present, rather than representing every occurrence of the weekday 
    /// defined in the day property, it represents only a specific instance 
    /// within the recurrence period. The value can be positive or negative
    ///  but MUST NOT be zero. A negative integer means the nth-last 
    /// occurrence within that period (i.e., -1 is the last occurrence, 
    /// -2 the one before that, etc.).
    /// </summary>

	[JsonPropertyName("nthOfPeriod")]
	public virtual int?					nthOfPeriod  {get; set;} //

    /// <summary>
    /// These are the days of the month on which to repeat. Valid values are between 
    /// 1 and the maximum number of days any month may have in the calendar given 
    /// by the rscale property and the negative values of these numbers. For 
    /// example, in the Gregorian calendar, valid values are 1 to 31 and -31
    ///  to -1. Negative values offset from the end of the month. The array 
    /// MUST have at least one entry if included.
    /// </summary>

	[JsonPropertyName("byMonthDay")]
	public virtual List<int>?					byMonthDay  {get; set;}
    /// <summary>
    /// These are the months in which to repeat. Each entry is a string representation 
    /// of a number, starting from "1" for the first month in the calendar (e.g., 
    /// "1" means January with the Gregorian calendar), with an optional "L" 
    /// suffix (see [RFC7529]) for leap months (this MUST be uppercase, e.g., 
    /// "3L"). The array MUST have at least one entry if included.
    /// </summary>

	[JsonPropertyName("byMonth")]
	public virtual List<string>?					byMonth  {get; set;}
    /// <summary>
    /// These are the days of the year on which to repeat. Valid values are between
    ///  1 and the maximum number of days any year may have in the calendar given 
    /// by the rscale property and the negative values of these numbers. For example, 
    /// in the Gregorian calendar, valid values are 1 to 366 and -366 to -1. Negative 
    /// values offset from the end of the year. The array MUST have at least one 
    /// entry if included.
    /// </summary>

	[JsonPropertyName("byYearDay")]
	public virtual List<int>?					byYearDay  {get; set;}
    /// <summary>
    /// These are the weeks of the year in which to repeat. Valid values are between 
    /// 1 and the maximum number of weeks any year may have in the calendar given by 
    /// the rscale property and the negative values of these numbers. For example, 
    /// in the Gregorian calendar, valid values are 1 to 53 and -53 to -1. The array 
    /// MUST have at least one entry if included.
    /// </summary>

	[JsonPropertyName("byWeekNo")]
	public virtual List<int>?					byWeekNo  {get; set;}
    /// <summary>
    /// These are the hours of the day in which to repeat. Valid values are 0 to 23. 
    /// The array MUST have at least one entry if included. This is the BYHOUR part 
    /// from iCalendar.
    /// </summary>

	[JsonPropertyName("byHour")]
	public virtual List<int>?					byHour  {get; set;}
    /// <summary>
    /// These are the minutes of the hour in which to repeat. Valid values are 
    /// 0 to 59. The array MUST have at least one entry if included.
    /// </summary>

	[JsonPropertyName("byMinute")]
	public virtual List<int>?					byMinute  {get; set;}
    /// <summary>
    /// These are the seconds of the minute in which to repeat. Valid values 
    /// are 0 to 60. The array MUST have at least one entry if included.
    /// </summary>

	[JsonPropertyName("bySecond")]
	public virtual List<int>?					bySecond  {get; set;}
    /// <summary>
    /// These are the occurrences within the recurrence interval to include in 
    /// the final results. Negative values offset from the end of the list of
    /// occurrences. The array MUST have at least one entry if included. 
    /// This is the BYSETPOS part from iCalendar.
    /// </summary>

	[JsonPropertyName("bySetPosition")]
	public virtual List<int>?					bySetPosition  {get; set;}
    /// <summary>
    /// These are the number of occurrences at which to range-bound the recurrence. 
    /// This MUST NOT be included if an until property is specified.
    /// </summary>

	[JsonPropertyName("count")]
	public virtual int?					count  {get; set;} //

    /// <summary>
    /// These are the date-time at which to finish recurring. The last 
    /// occurrence is on or before this date-time. This MUST NOT be included 
    /// if a count property is specified. Note that if not specified otherwise 
    /// for a specific JSCalendar object, this date is to be interpreted in the 
    /// time zone specified in the JSCalendar object's timeZone property.
    /// </summary>

	[JsonPropertyName("until")]
	public virtual DateTime?					until  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as RecurrenceRule).Type = value;}, 
					(IBinding data) => (data as RecurrenceRule).Type ),
		new PropertyString ("frequency", 
					(IBinding data, string? value) => {(data as RecurrenceRule).frequency = value;}, 
					(IBinding data) => (data as RecurrenceRule).frequency ),
		new PropertyInteger32 ("interval", 
					(IBinding data, int? value) => {(data as RecurrenceRule).interval = value;}, 
					(IBinding data) => (data as RecurrenceRule).interval ),
		new PropertyString ("rscale", 
					(IBinding data, string? value) => {(data as RecurrenceRule).rscale = value;}, 
					(IBinding data) => (data as RecurrenceRule).rscale ),
		new PropertyString ("skip", 
					(IBinding data, string? value) => {(data as RecurrenceRule).skip = value;}, 
					(IBinding data) => (data as RecurrenceRule).skip ),
		new PropertyString ("firstDayOfWeek", 
					(IBinding data, string? value) => {(data as RecurrenceRule).firstDayOfWeek = value;}, 
					(IBinding data) => (data as RecurrenceRule).firstDayOfWeek ),
		new PropertyListStruct ("byDay", typeof (NDay),
					(IBinding data, object? value) => {(data as RecurrenceRule).byDay = value as List<NDay>;}, 
					(IBinding data) => (data as RecurrenceRule).byDay,
					false, ()=>new  List<NDay>(), ()=>new NDay()),
		new PropertyInteger32 ("nthOfPeriod", 
					(IBinding data, int? value) => {(data as RecurrenceRule).nthOfPeriod = value;}, 
					(IBinding data) => (data as RecurrenceRule).nthOfPeriod ),
		new PropertyListInteger32 ("byMonthDay", 
					(IBinding data, List<int>? value) => {(data as RecurrenceRule).byMonthDay = value;}, 
					(IBinding data) => (data as RecurrenceRule).byMonthDay ),
		new PropertyListString ("byMonth", 
					(IBinding data, List<string>? value) => {(data as RecurrenceRule).byMonth = value;}, 
					(IBinding data) => (data as RecurrenceRule).byMonth ),
		new PropertyListInteger32 ("byYearDay", 
					(IBinding data, List<int>? value) => {(data as RecurrenceRule).byYearDay = value;}, 
					(IBinding data) => (data as RecurrenceRule).byYearDay ),
		new PropertyListInteger32 ("byWeekNo", 
					(IBinding data, List<int>? value) => {(data as RecurrenceRule).byWeekNo = value;}, 
					(IBinding data) => (data as RecurrenceRule).byWeekNo ),
		new PropertyListInteger32 ("byHour", 
					(IBinding data, List<int>? value) => {(data as RecurrenceRule).byHour = value;}, 
					(IBinding data) => (data as RecurrenceRule).byHour ),
		new PropertyListInteger32 ("byMinute", 
					(IBinding data, List<int>? value) => {(data as RecurrenceRule).byMinute = value;}, 
					(IBinding data) => (data as RecurrenceRule).byMinute ),
		new PropertyListInteger32 ("bySecond", 
					(IBinding data, List<int>? value) => {(data as RecurrenceRule).bySecond = value;}, 
					(IBinding data) => (data as RecurrenceRule).bySecond ),
		new PropertyListInteger32 ("bySetPosition", 
					(IBinding data, List<int>? value) => {(data as RecurrenceRule).bySetPosition = value;}, 
					(IBinding data) => (data as RecurrenceRule).bySetPosition ),
		new PropertyInteger32 ("count", 
					(IBinding data, int? value) => {(data as RecurrenceRule).count = value;}, 
					(IBinding data) => (data as RecurrenceRule).count ),
		new PropertyDateTime ("until", 
					(IBinding data, DateTime? value) => {(data as RecurrenceRule).until = value;}, 
					(IBinding data) => (data as RecurrenceRule).until )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<RecurrenceRule> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "frequency", _properties [1]},
			{ "interval", _properties [2]},
			{ "rscale", _properties [3]},
			{ "skip", _properties [4]},
			{ "firstDayOfWeek", _properties [5]},
			{ "byDay", _properties [6]},
			{ "nthOfPeriod", _properties [7]},
			{ "byMonthDay", _properties [8]},
			{ "byMonth", _properties [9]},
			{ "byYearDay", _properties [10]},
			{ "byWeekNo", _properties [11]},
			{ "byHour", _properties [12]},
			{ "byMinute", _properties [13]},
			{ "bySecond", _properties [14]},
			{ "bySetPosition", _properties [15]},
			{ "count", _properties [16]},
			{ "until", _properties [17]}}, __Tag,
		() => new RecurrenceRule(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "RecurrenceRule";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new RecurrenceRule();

	}


	/// <summary>
	/// </summary>
public partial class NDay : Calandars {
    /// <summary>
    /// This specifies the type of this object. This MUST be NDay.
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// This is a day of the week on which to repeat; the allowed values are the same
    /// as for the firstDayOfWeek recurrenceRule property.
    /// </summary>

	[JsonPropertyName("day")]
	public virtual string?					day  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as NDay).Type = value;}, 
					(IBinding data) => (data as NDay).Type ),
		new PropertyString ("day", 
					(IBinding data, string? value) => {(data as NDay).day = value;}, 
					(IBinding data) => (data as NDay).day )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<NDay> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "day", _properties [1]}}, __Tag,
		() => new NDay(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "NDay";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new NDay();

	}


	/// <summary>
	///
	///  An Alert object has the following properties:
	/// </summary>
public partial class Alert : Calandars {
    /// <summary>
    /// This specifies the type of this object. This MUST be Alert.
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// This defines when to trigger the alert. New types may be 
    /// defined in future documents.
    /// </summary>

	[JsonPropertyName("trigger")]
	public virtual Trigger?					Trigger  {get; set;} //

    /// <summary>
    /// This records when an alert was last acknowledged. This is set
    /// when the user has dismissed the alert; other clients that sync 
    /// this property SHOULD automatically dismiss or suppress duplicate 
    /// alerts (alerts with the same alert id that triggered on or before
    /// this date-time).
    /// </summary>

	[JsonPropertyName("acknowledged")]
	public virtual DateTime?					acknowledged  {get; set;} //

    /// <summary>
    /// This relates this alert to other alerts in the same JSCalendar 
    /// object. If the user wishes to snooze an alert, the application 
    /// MUST create an alert to trigger after snoozing. This new snooze 
    /// alert MUST set a parent relation to the identifier of the original 
    ///alert.
    /// </summary>

	[JsonPropertyName("relatedTo")]
	public virtual Dictionary<string,Relation>?					relatedTo  {get; set;} //

    /// <summary>
    /// This describes how to alert the user.
    /// </summary>

	[JsonPropertyName("action")]
	public virtual string?					action  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as Alert).Type = value;}, 
					(IBinding data) => (data as Alert).Type ),
		new PropertyStruct ("trigger", typeof (Trigger),
					(IBinding data, object? value) => {(data as Alert).Trigger = value as Trigger;}, 
					(IBinding data) => (data as Alert).Trigger,
					false, ()=>new  Trigger(), ()=>new Trigger()),
		new PropertyDateTime ("acknowledged", 
					(IBinding data, DateTime? value) => {(data as Alert).acknowledged = value;}, 
					(IBinding data) => (data as Alert).acknowledged ),
		new PropertyDictionaryStruct ("relatedTo", typeof (Relation),
					(IBinding data, object? value) => {(data as Alert).relatedTo = value as Dictionary<string,Relation>;}, 
					(IBinding data) => (data as Alert).relatedTo,
					false, ()=>new  Dictionary<string,Relation>(), ()=>new Relation(),
					(IBinding data) => (data as Alert).relatedTo.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,Relation>).Add (key as string,value as Relation);}),
		new PropertyString ("action", 
					(IBinding data, string? value) => {(data as Alert).action = value;}, 
					(IBinding data) => (data as Alert).action )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Alert> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "trigger", _properties [1]},
			{ "acknowledged", _properties [2]},
			{ "relatedTo", _properties [3]},
			{ "action", _properties [4]}}, __Tag,
		() => new Alert(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Alert";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Alert();

	}


	/// <summary>
	/// </summary>
public partial class Trigger : Calandars {
    /// <summary>
    /// This specifies the type of this object. This MUST be OffsetTrigger,
    /// AbsoluteTrigger or UnknownTrigger .
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// This defines the offset at which to trigger the alert relative to 
    /// the time property defined in the relativeTo property of the alert. 
    /// Negative durations signify alerts before the time property; positive 
    /// durations signify alerts after the time property.
    /// </summary>

	[JsonPropertyName("offset")]
	public virtual string?					offset  {get; set;} //

    /// <summary>
    /// This specifies the time property that the alert offset is relative to.
    /// </summary>

	[JsonPropertyName("relativeTo")]
	public virtual string?					relativeTo  {get; set;} //

    /// <summary>
    /// This defines a specific UTC date-time when the alert is triggered.
    /// </summary>

	[JsonPropertyName("when")]
	public virtual DateTime?					when  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as Trigger).Type = value;}, 
					(IBinding data) => (data as Trigger).Type ),
		new PropertyString ("offset", 
					(IBinding data, string? value) => {(data as Trigger).offset = value;}, 
					(IBinding data) => (data as Trigger).offset ),
		new PropertyString ("relativeTo", 
					(IBinding data, string? value) => {(data as Trigger).relativeTo = value;}, 
					(IBinding data) => (data as Trigger).relativeTo ),
		new PropertyDateTime ("when", 
					(IBinding data, DateTime? value) => {(data as Trigger).when = value;}, 
					(IBinding data) => (data as Trigger).when )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<Trigger> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "offset", _properties [1]},
			{ "relativeTo", _properties [2]},
			{ "when", _properties [3]}}, __Tag,
		() => new Trigger(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Trigger";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new Trigger();

	}


	/// <summary>
	///
	///  A TimeZone object maps a VTIMEZONE component from iCalendar, and 
	///  the semantics are as defined in [RFC5545]. A valid time zone MUST 
	///  define at least one transition rule in the standard or daylight 
	///  property. Its properties are:
	/// </summary>
public partial class TimeZone : Calandars {
    /// <summary>
    /// This specifies the type of this object. This MUST be TimeZone.
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// This is the TZID property from iCalendar. Note that this implies that the value MUST be a valid paramtext value as specified in Section 3.1. of [RFC5545].
    /// </summary>

	[JsonPropertyName("tzId")]
	public virtual string?					tzId  {get; set;} //

    /// <summary>
    /// This is the LAST-MODIFIED property from iCalendar.
    /// </summary>

	[JsonPropertyName("updated")]
	public virtual DateTime?					updated  {get; set;} //

    /// <summary>
    /// This is the TZURL property from iCalendar.
    /// </summary>

	[JsonPropertyName("url")]
	public virtual string?					url  {get; set;} //

    /// <summary>
    /// This is the TZUNTIL property from iCalendar, specified in [RFC7808].
    /// </summary>

	[JsonPropertyName("validUntil")]
	public virtual DateTime?					validUntil  {get; set;} //

    /// <summary>
    /// This maps the TZID-ALIAS-OF properties from iCalendar, specified 
    /// in [RFC7808], to a JSON set of aliases. The set is represented 
    /// as an object, with the keys being the aliases. The value for 
    /// each key in the map MUST be true.
    /// </summary>

	[JsonPropertyName("aliases")]
	public virtual Dictionary<string,bool>?					aliases  {get; set;} //

    /// <summary>
    /// This the STANDARD sub-components from iCalendar. The order 
    /// MUST be preserved during conversion.
    /// </summary>

	[JsonPropertyName("standard")]
	public virtual List<TimeZoneRule>?					standard  {get; set;}
    /// <summary>
    /// This the DAYLIGHT sub-components from iCalendar. The order 
    /// MUST be preserved during conversion.
    /// </summary>

	[JsonPropertyName("daylight")]
	public virtual List<TimeZoneRule>?					daylight  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as TimeZone).Type = value;}, 
					(IBinding data) => (data as TimeZone).Type ),
		new PropertyString ("tzId", 
					(IBinding data, string? value) => {(data as TimeZone).tzId = value;}, 
					(IBinding data) => (data as TimeZone).tzId ),
		new PropertyDateTime ("updated", 
					(IBinding data, DateTime? value) => {(data as TimeZone).updated = value;}, 
					(IBinding data) => (data as TimeZone).updated ),
		new PropertyString ("url", 
					(IBinding data, string? value) => {(data as TimeZone).url = value;}, 
					(IBinding data) => (data as TimeZone).url ),
		new PropertyDateTime ("validUntil", 
					(IBinding data, DateTime? value) => {(data as TimeZone).validUntil = value;}, 
					(IBinding data) => (data as TimeZone).validUntil ),
		new PropertyDictionaryBoolean ("aliases", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as TimeZone).aliases = value;}, 
					(IBinding data) => (data as TimeZone).aliases ),
		new PropertyListStruct ("standard", typeof (TimeZoneRule),
					(IBinding data, object? value) => {(data as TimeZone).standard = value as List<TimeZoneRule>;}, 
					(IBinding data) => (data as TimeZone).standard,
					false, ()=>new  List<TimeZoneRule>(), ()=>new TimeZoneRule()),
		new PropertyListStruct ("daylight", typeof (TimeZoneRule),
					(IBinding data, object? value) => {(data as TimeZone).daylight = value as List<TimeZoneRule>;}, 
					(IBinding data) => (data as TimeZone).daylight,
					false, ()=>new  List<TimeZoneRule>(), ()=>new TimeZoneRule())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<TimeZone> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "tzId", _properties [1]},
			{ "updated", _properties [2]},
			{ "url", _properties [3]},
			{ "validUntil", _properties [4]},
			{ "aliases", _properties [5]},
			{ "standard", _properties [6]},
			{ "daylight", _properties [7]}}, __Tag,
		() => new TimeZone(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "TimeZone";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new TimeZone();

	}


	/// <summary>
	///
	///  A TimeZoneRule object maps a STANDARD or DAYLIGHT sub-component 
	///  from iCalendar, with the restriction that, at most, one recurrence 
	///  rule is allowed per rule. It has the following properties:
	/// </summary>
public partial class TimeZoneRule : Calandars {
    /// <summary>
    /// This specifies the type of this object. This MUST be TimeZoneRule.
    /// </summary>

	[JsonPropertyName("@type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// This is the DTSTART property from iCalendar.
    /// </summary>

	[JsonPropertyName("start")]
	public virtual string?					Start  {get; set;} //

    /// <summary>
    /// This is the TZOFFSETFROM property from iCalendar.
    /// </summary>

	[JsonPropertyName("offsetFrom")]
	public virtual string?					OffsetFrom  {get; set;} //

    /// <summary>
    /// This is the TZOFFSETTO property from iCalendar.
    /// </summary>

	[JsonPropertyName("offsetTo")]
	public virtual string?					OffsetTo  {get; set;} //

    /// <summary>
    /// This is the RRULE property mapped, as specified in Section 4.3.3. 
    /// During recurrence rule evaluation, the until property 
    /// value MUST be interpreted as a local time in the UTC time zone.
    /// </summary>

	[JsonPropertyName("recurrenceRules")]
	public virtual List<RecurrenceRule>?					RecurrenceRules  {get; set;}
    /// <summary>
    /// This maps the RDATE properties from iCalendar. The set is 
    /// represented as an object, with the keys being the recurrence 
    /// dates. The patch object MUST be the empty JSON object ({}).
    /// </summary>

	[JsonPropertyName("recurrenceOverrides")]
	public virtual Dictionary<string,EmptyPatchObject>?					RecurrenceOverrides  {get; set;} //

    /// <summary>
    /// This maps the TZNAME properties from iCalendar to a JSON set.
    /// The set is represented as an object, with the keys being the 
    /// names, excluding any tznparam component from iCalendar. The 
    /// value for each key in the map MUST be true.
    /// </summary>

	[JsonPropertyName("names")]
	public virtual Dictionary<string,bool>?					Names  {get; set;} //

    /// <summary>
    /// This maps the COMMENT properties from iCalendar. The order 
    /// MUST be preserved during conversion.
    /// </summary>

	[JsonPropertyName("comments")]
	public virtual List<string>?					Comments  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("@type", 
					(IBinding data, string? value) => {(data as TimeZoneRule).Type = value;}, 
					(IBinding data) => (data as TimeZoneRule).Type ),
		new PropertyString ("start", 
					(IBinding data, string? value) => {(data as TimeZoneRule).Start = value;}, 
					(IBinding data) => (data as TimeZoneRule).Start ),
		new PropertyString ("offsetFrom", 
					(IBinding data, string? value) => {(data as TimeZoneRule).OffsetFrom = value;}, 
					(IBinding data) => (data as TimeZoneRule).OffsetFrom ),
		new PropertyString ("offsetTo", 
					(IBinding data, string? value) => {(data as TimeZoneRule).OffsetTo = value;}, 
					(IBinding data) => (data as TimeZoneRule).OffsetTo ),
		new PropertyListStruct ("recurrenceRules", typeof (RecurrenceRule),
					(IBinding data, object? value) => {(data as TimeZoneRule).RecurrenceRules = value as List<RecurrenceRule>;}, 
					(IBinding data) => (data as TimeZoneRule).RecurrenceRules,
					false, ()=>new  List<RecurrenceRule>(), ()=>new RecurrenceRule()),
		new PropertyDictionaryStruct ("recurrenceOverrides", typeof (EmptyPatchObject),
					(IBinding data, object? value) => {(data as TimeZoneRule).RecurrenceOverrides = value as Dictionary<string,EmptyPatchObject>;}, 
					(IBinding data) => (data as TimeZoneRule).RecurrenceOverrides,
					false, ()=>new  Dictionary<string,EmptyPatchObject>(), ()=>new EmptyPatchObject(),
					(IBinding data) => (data as TimeZoneRule).RecurrenceOverrides.GetEnumerable(),
					(object dictionary, object key, object value) =>
						 {(dictionary as Dictionary<string,EmptyPatchObject>).Add (key as string,value as EmptyPatchObject);}),
		new PropertyDictionaryBoolean ("names", 
					(IBinding data, Dictionary<string,bool>? value) => {(data as TimeZoneRule).Names = value;}, 
					(IBinding data) => (data as TimeZoneRule).Names ),
		new PropertyListString ("comments", 
					(IBinding data, List<string>? value) => {(data as TimeZoneRule).Comments = value;}, 
					(IBinding data) => (data as TimeZoneRule).Comments )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<TimeZoneRule> _binding = new (
			new() {
			{ "@type", _properties [0]},
			{ "start", _properties [1]},
			{ "offsetFrom", _properties [2]},
			{ "offsetTo", _properties [3]},
			{ "recurrenceRules", _properties [4]},
			{ "recurrenceOverrides", _properties [5]},
			{ "names", _properties [6]},
			{ "comments", _properties [7]}}, __Tag,
		() => new TimeZoneRule(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "TimeZoneRule";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new TimeZoneRule();

	}


	/// <summary>
	///
	///  Empty object used in recurrenceOverrides
	/// </summary>
public partial class EmptyPatchObject : Calandars {

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<EmptyPatchObject> _binding = new (
			new() {}, __Tag,
		() => new EmptyPatchObject(), () => [], () => [], null, Generic: false);


	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "EmptyPatchObject";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new EmptyPatchObject();

	}



