namespace Goedel.Everything;
#region // Bindings to classes specified through the Guigen schema.


public partial record FieldIcon(string File) : IFieldIcon {
    public string Source => File + ".png";


    }

/// <summary>
/// Static class returning handlers for standard icons.
/// </summary>
public static partial class FieldIcons  {

    ///<summary>Icon for generic message that has been read.</summary> 
    public static FieldIcon MessageRead { get; } = new("mail_read");

    ///<summary>Icon for generic message that has not been read.</summary> 
    public static FieldIcon MessageUnRead { get; } = new("mail_unread");

    /// <summary>
    /// Return an icon for a generic message according to the value of <paramref name="read"/>.
    /// </summary>
    /// <param name="read">True if the message was read, otherwise false.</param>
    /// <returns>The icon descriptor.</returns>
    public static FieldIcon Message (bool read) => read ? MessageRead : MessageUnRead;

    /// <summary>
    /// Return an icon for a mail message according to the value of <paramref name="read"/>.
    /// </summary>
    /// <param name="read">True if the message was read, otherwise false.</param>
    /// <returns>The icon descriptor.</returns>
    public static FieldIcon Mail (bool read) => Message(read);



    #region // Connection
    ///<summary>Icon for generic message that has been read.</summary> 
    public static FieldIcon ConnectionRead { get; } = new("connect_read");

    ///<summary>Icon for generic message that has not been read.</summary> 
    public static FieldIcon ConnectionUnRead { get; } = new("connect_unread");

    /// <summary>
    /// Return an icon for a generic message according to the value of <paramref name="read"/>.
    /// </summary>
    /// <param name="read">True if the message was read, otherwise false.</param>
    /// <returns>The icon descriptor.</returns>
    public static FieldIcon Connection(bool read) => read ? ConnectionRead : ConnectionUnRead;
    #endregion

    #region // ConfirmationRequest
    ///<summary>Icon for generic message that has been read.</summary> 
    public static FieldIcon ConfirmationRequestRead { get; } = new("confirm_read");

    ///<summary>Icon for generic message that has not been read.</summary> 
    public static FieldIcon ConfirmationRequestUnRead { get; } = new("confirm_unread");

    /// <summary>
    /// Return an icon for a generic message according to the value of <paramref name="read"/>.
    /// </summary>
    /// <param name="read">True if the message was read, otherwise false.</param>
    /// <returns>The icon descriptor.</returns>
    public static FieldIcon ConfirmationRequest(bool read) => read ? ConfirmationRequestRead : ConfirmationRequestUnRead;
    #endregion

    #region // ContactRequest
    ///<summary>Icon for generic message that has been read.</summary> 
    public static FieldIcon ContactRequestRead  { get; } = new("contact_read");

    ///<summary>Icon for generic message that has not been read.</summary> 
    public static FieldIcon ContactRequestUnRead { get; } =  new("contact_unread");

    /// <summary>
    /// Return an icon for a generic message according to the value of <paramref name="read"/>.
    /// </summary>
    /// <param name="read">True if the message was read, otherwise false.</param>
    /// <returns>The icon descriptor.</returns>
    public static FieldIcon ContactRequest(bool read) => read ? ContactRequestRead : ContactRequestUnRead;
    #endregion

    #region // GroupInvitation
    ///<summary>Icon for generic message that has been read.</summary> 
    public static FieldIcon GroupInvitationRead { get; } = new("group_read");

    ///<summary>Icon for generic message that has not been read.</summary> 
    public static FieldIcon GroupInvitationUnRead { get; } = new("group_unread");

    /// <summary>
    /// Return an icon for a generic message according to the value of <paramref name="read"/>.
    /// </summary>
    /// <param name="read">True if the message was read, otherwise false.</param>
    /// <returns>The icon descriptor.</returns>
    public static FieldIcon GroupInvitation(bool read) => read ? GroupInvitationRead : GroupInvitationUnRead;
    #endregion

    #region // ConfirmationResponse
    ///<summary>Icon for generic message that has been read.</summary> 
    public static FieldIcon ConfirmationResponseReadAccept { get; } = new("confirm_accept_read");

    ///<summary>Icon for generic message that has not been read.</summary> 
    public static FieldIcon ConfirmationResponseUnreadAccept { get; } = new("confirm_accept_unread");

    ///<summary>Icon for generic message that has been read.</summary> 
    public static FieldIcon ConfirmationResponseReadReject { get; } =  new("confirm_reject_read");

    ///<summary>Icon for generic message that has not been read.</summary> 
    public static FieldIcon ConfirmationResponseUnreadReject { get; } = new("confirm_reject_unread");

    /// <summary>
    /// Return an icon for a generic message according to the value of <paramref name="read"/>.
    /// </summary>
    /// <param name="read">True if the message was read, otherwise false.</param>
    /// <returns>The icon descriptor.</returns>
    public static FieldIcon ConfirmationResponse(bool read, bool accepted) => accepted ?
        (read ? ConfirmationResponseReadAccept : ConfirmationResponseUnreadAccept) : 
        (read ? ConfirmationResponseReadReject : ConfirmationResponseUnreadReject);
    #endregion


    #region // TaskRequest
    ///<summary>Icon for generic message that has been read.</summary> 
    public static FieldIcon AppointmentReadAccept { get; } = new("confirm_accept_read");

    ///<summary>Icon for generic message that has not been read.</summary> 
    public static FieldIcon AppointmentUnreadAccept { get; } = new("confirm_accept_unread");

    ///<summary>Icon for generic message that has been read.</summary> 
    public static FieldIcon TaskReadReject { get; } = new("confirm_reject_read");

    ///<summary>Icon for generic message that has not been read.</summary> 
    public static FieldIcon TaskUnreadReject { get; } = new("confirm_reject_unread");

    /// <summary>
    /// Return an icon for a generic message according to the value of <paramref name="read"/>.
    /// </summary>
    /// <param name="read">True if the message was read, otherwise false.</param>
    /// <returns>The icon descriptor.</returns>
    public static FieldIcon TaskRequest(bool read, bool appointment) => appointment ?
        (read ? AppointmentReadAccept : AppointmentUnreadAccept) :
        (read ? TaskReadReject : TaskUnreadReject);
    #endregion

    #region // Document


    ///<summary>Icon for document type .</summary> 
    public static FieldIcon DocumentTypeFile { get; } = new("file");

    ///<summary>Icon for document type .</summary> 
    public static FieldIcon DocumentType { get; } = new("file_regular");

    ///<summary>Icon for document type .</summary> 
    public static FieldIcon DocumentTypeAudio { get; } = new("file_audio");

    ///<summary>Icon for document type .</summary> 
    public static FieldIcon DocumentTypeContract { get; } = new("file_contract");

    ///<summary>Icon for document type .</summary> 
    public static FieldIcon DocumentTypeExcel { get; } = new("file_excel");

    ///<summary>Icon for document type .</summary> 
    public static FieldIcon DocumentTypeinvoice { get; } = new("file_invoice");

    ///<summary>Icon for document type .</summary> 
    public static FieldIcon DocumentTypePdf { get; } = new("file_pdf");

    ///<summary>Icon for document type .</summary> 
    public static FieldIcon DocumentTypePowerpoint { get; } = new("file_powerpoint");

    ///<summary>Icon for document type .</summary> 
    public static FieldIcon DocumentTypeVideo { get; } = new("file_video");

    ///<summary>Icon for document type Zip.</summary> 
    public static FieldIcon DocumentTypeZipo { get; } = new("file_zipper");

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filename"></param>
    /// <param name="contentType"></param>
    /// <returns></returns>
    public static FieldIcon Document (string filename, string contentType) => DocumentType;

    #endregion

    #region // Credential 

    ///<summary>Icon for credential password</summary> 
    public static FieldIcon CredentialPassword { get; } = new("password");

    ///<summary>Icon for credential password</summary> 
    public static FieldIcon CredentialPasskey { get; } = new("passkey");

    #endregion

    #region // Task 

    ///<summary>Icon for credential password</summary> 
    public static FieldIcon TaskComplete { get; } = new("password");

    ///<summary>Icon for credential password</summary> 
    public static FieldIcon TaskPriorityHigh { get; } = new("passkey");

    public static FieldIcon TaskPriorityLow { get; } = new("passkey");

    public static FieldIcon TaskPriorityNormal { get; } = new("passkey");

    #endregion


    #region // Bookmark 

    ///<summary>Icon for credential password</summary> 
    public static FieldIcon BookmarkGeneric { get; } = new("bookmark");

    ///<summary>Icon for credential password</summary> 
    public static FieldIcon Bookmark( string uri) => BookmarkGeneric;

    #endregion

    #region // Contact 

    ///<summary>Icon for credential password</summary> 
    public static FieldIcon ContactGeneric { get; } = new("contact");

    ///<summary>Icon for credential password</summary> 
    public static FieldIcon ContactPerson { get; } = new("contact");

    ///<summary>Icon for credential password</summary> 
    public static FieldIcon ContactBusiness { get; } = new("contact");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon ContactPlace { get; } = new("contact");

    ///<summary>Icon for credential password</summary> 
    public static FieldIcon Contact(string uri) => ContactGeneric;

    #endregion

    #region // Device 

    ///<summary>Icon for credential password</summary> 
    public static FieldIcon DeviceGeneric { get; } = new("plug");

    ///<summary>Icon for credential password</summary> 
    public static FieldIcon DeviceOffline { get; } = new("vault");

    ///<summary>Icon for credential password</summary> 
    public static FieldIcon DeviceAdministrator { get; } = new("device_administrator");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon DeviceWorkstation { get; } = new("device_desktop");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon DevicePortable { get; } = new("device_laptop");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon DeviceMobile { get; } = new("device_mobile");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon DeviceTablet { get; } = new("device_tablet");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon DeviceServer { get; } = new("device_server");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon DeviceTV { get; } = new("device_tv");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon DeviceInput { get; } = new("device_keyboard");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon DeviceConsole { get; } = new("device_console");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon DeviceHeadphones { get; } = new("device_headphones");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon DeviceIoT { get; } = new("device_plug");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon DeviceWired { get; } = new("ethernet");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon DeviceWireless { get; } = new("wireless");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon DevicePersonal { get; } = new("watch");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon DeviceNetworking { get; } = new("wifi_router");


    ///<summary>Icon for credential password</summary> 
    public static FieldIcon Device(string deviceType) => DeviceGeneric;

    #endregion

    #region // Application 

    ///<summary>Icon for credential password</summary> 
    public static FieldIcon ApplicationGeneric { get; } = new("applications");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon ApplicationMail { get; } = new("mail");

    ///<summary>Icon for credential password</summary> 
    public static FieldIcon ApplicationShh { get; } = new("application_ssh");

    ///<summary>Icon for credential password</summary> 
    public static FieldIcon ApplicationOpenpgp { get; } = new("application_openpgp");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon ApplicationDeveloper { get; } = new("application_developer");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon ApplicationPkix { get; } = new("application_pkix");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon ApplicationGroup { get; } = new("application_group");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon ApplicationCallsign { get; } = new("application_callsign");

    ///<summary>Icon for credential password</summary> 
    public static FieldIcon Application(string deviceType) => ApplicationGeneric;

    #endregion

    #region // Address 

    ///<summary>Icon for credential password</summary> 
    public static FieldIcon AddressGeneric { get; } = new("applications");

    ///<summary>Icon for credential password</summary> 
    public static FieldIcon AddressSkype { get; } = new("brand_skype");

    ///<summary>Icon for credential password</summary> 
    public static FieldIcon AddressSignal { get; } = new("brand_signal");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon AddressTelephone { get; } = new("voice");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon AddressFacetime { get; } = new("brand_facetime");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon AddressWhatsapp { get; } = new("brand_whatsapp");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon AddressTelegram { get; } = new("brand_telegram");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon AddressFacebook { get; } = new("brand_facebook_messenger");
    ///<summary>Icon for credential password</summary> 
    public static FieldIcon Address(string uri) => AddressGeneric;

    #endregion



    }


#endregion