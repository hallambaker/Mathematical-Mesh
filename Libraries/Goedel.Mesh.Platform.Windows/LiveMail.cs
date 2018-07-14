// Generated on 4/16/2018 1:09:24 AM
using System;
using System.Collections.Generic;
using System.IO;


namespace Goedel.Mesh.Integration.LiveMail  {



    /// <summary>
    /// Convenience class creating accessors for registry 'Class.Id'
    /// </summary>
    public partial class MessageAccount : Goedel.Mesh.ConfigRegistry {

        /// <summary>
        /// Construct a new empty instance.
        /// </summary>
		public MessageAccount () : base ("MessageAccount") {
			}

        /// <summary>
        /// Construct a new instance from the specified file
        /// </summary>
        /// <param name="FileName">The file to read</param>/// 
		public MessageAccount (string FileName) : base ("MessageAccount", FileName) {
            }

		
        /// <summary>
        /// Accessor for key "Field.Key" of type SZ
        /// </summary>
		public virtual string Account_Name {
            get => GetSZ("Account_Name");
            set => Set("Account_Name", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type DWORD
        /// </summary>
        public virtual uint Connection_Type {
            get => GetDWORD("Connection_Type");
            set => Set("Connection_Type", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type DWORD
        /// </summary>
        public virtual uint Make_Available_Offline {
            get => GetDWORD("Make_Available_Offline");
            set => Set("Make_Available_Offline", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type SZ
        /// </summary>
        public virtual string IMAP_Server {
            get => GetSZ("IMAP_Server");
            set => Set("IMAP_Server", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type SZ
        /// </summary>
        public virtual string IMAP_User_Name {
            get => GetSZ("IMAP_User_Name");
            set => Set("IMAP_User_Name", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type BINARY
        /// </summary>
        public virtual byte[] IMAP_Password2 {
            get => GetBINARY("IMAP_Password2");
            set => Set("IMAP_Password2", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type DWORD
        /// </summary>
        public virtual uint IMAP_Use_Sicily {
            get => GetDWORD("IMAP_Use_Sicily");
            set => Set("IMAP_Use_Sicily", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type DWORD
        /// </summary>
        public virtual uint IMAP_Port {
            get => GetDWORD("IMAP_Port");
            set => Set("IMAP_Port", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type DWORD
        /// </summary>
        public virtual uint IMAP_Secure_Connection {
            get => GetDWORD("IMAP_Secure_Connection");
            set => Set("IMAP_Secure_Connection", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type DWORD
        /// </summary>
        public virtual uint IMAP_Timeout {
            get => GetDWORD("IMAP_Timeout");
            set => Set("IMAP_Timeout", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type DWORD
        /// </summary>
        public virtual uint IMAP_Polling {
            get => GetDWORD("IMAP_Polling");
            set => Set("IMAP_Polling", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type SZ
        /// </summary>
        public virtual string IMAP_Sent_Items_Folder {
            get => GetSZ("IMAP_Sent_Items_Folder");
            set => Set("IMAP_Sent_Items_Folder", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type SZ
        /// </summary>
        public virtual string IMAP_Drafts_Folder {
            get => GetSZ("IMAP_Drafts_Folder");
            set => Set("IMAP_Drafts_Folder", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type DWORD
        /// </summary>
        public virtual uint IMAP_Prompt_for_Password {
            get => GetDWORD("IMAP_Prompt_for_Password");
            set => Set("IMAP_Prompt_for_Password", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type DWORD
        /// </summary>
        public virtual uint IMAP_Dirty {
            get => GetDWORD("IMAP_Dirty");
            set => Set("IMAP_Dirty", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type SZ
        /// </summary>
        public virtual string IMAP_Deleted_Items_Folder {
            get => GetSZ("IMAP_Deleted_Items_Folder");
            set => Set("IMAP_Deleted_Items_Folder", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type SZ
        /// </summary>
        public virtual string IMAP_Junk_E_mail_Folder {
            get => GetSZ("IMAP_Junk_E-mail_Folder");
            set => Set("IMAP_Junk_E-mail_Folder", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type DWORD
        /// </summary>
        public virtual uint IMAP_XLIST_Sent_Items {
            get => GetDWORD("IMAP_XLIST_Sent_Items");
            set => Set("IMAP_XLIST_Sent_Items", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type DWORD
        /// </summary>
        public virtual uint IMAP_XLIST_Drafts {
            get => GetDWORD("IMAP_XLIST_Drafts");
            set => Set("IMAP_XLIST_Drafts", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type DWORD
        /// </summary>
        public virtual uint IMAP_XLIST_Deleted_Items {
            get => GetDWORD("IMAP_XLIST_Deleted_Items");
            set => Set("IMAP_XLIST_Deleted_Items", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type DWORD
        /// </summary>
        public virtual uint IMAP_XLIST_Junk_E_mail {
            get => GetDWORD("IMAP_Junk_E-mail_Folder");
            set => Set("IMAP_Junk_E-mail_Folder", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type DWORD
        /// </summary>
        public virtual uint IMAP_XLIST_Migration_Done {
            get => GetDWORD("IMAP_XLIST_Migration_Done");
            set => Set("IMAP_XLIST_Migration_Done", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type SZ
        /// </summary>
        public virtual string SMTP_Server {
            get => GetSZ("SMTP_Server");
            set => Set("SMTP_Server", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type SZ
        /// </summary>
        public virtual string SMTP_User_Name {
            get => GetSZ("SMTP_User_Name");
            set => Set("SMTP_User_Name", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type SZ
        /// </summary>
        public virtual string SMTP_Password2 {
            get => GetSZ("SMTP_Password2");
            set => Set("SMTP_Password2", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type DWORD
        /// </summary>
        public virtual uint SMTP_Use_Sicily {
            get => GetDWORD("SMTP_Use_Sicily");
            set => Set("SMTP_Use_Sicily", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type DWORD
        /// </summary>
        public virtual uint SMTP_Port {
            get => GetDWORD("SMTP_Port");
            set => Set("SMTP_Port", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type DWORD
        /// </summary>
        public virtual uint SMTP_Secure_Connection {
            get => GetDWORD("SMTP_Secure_Connection");
            set => Set("SMTP_Secure_Connection", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type DWORD
        /// </summary>
        public virtual uint SMTP_Timeout {
            get => GetDWORD("SMTP_Timeout");
            set => Set("SMTP_Timeout", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type SZ
        /// </summary>
        public virtual string SMTP_Display_Name {
            get => GetSZ("SMTP_Display_Name");
            set => Set("SMTP_Display_Name", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type SZ
        /// </summary>
        public virtual string SMTP_Organization_Name {
            get => GetSZ("SMTP_Organization_Name");
            set => Set("SMTP_Organization_Name", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type SZ
        /// </summary>
        public virtual string SMTP_Email_Address {
            get => GetSZ("SMTP_Email_Address");
            set => Set("SMTP_Email_Address", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type SZ
        /// </summary>
        public virtual string SMTP_Reply_To_Email_Address {
            get => GetSZ("SMTP_Reply_To_Email_Address");
            set => Set("SMTP_Reply_To_Email_Address", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type BINARY
        /// </summary>
        public virtual byte[] SMTP_Certificate {
            get => GetBINARY("SMTP_Certificate");
            set => Set("SMTP_Certificate", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type BINARY
        /// </summary>
        public virtual byte[] SMTP_Encryption_Certificate {
            get => GetBINARY("SMTP_Encryption_Certificate");
            set => Set("SMTP_Encryption_Certificate", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type SZ
        /// </summary>
        public virtual string SMTP_Encryption_Algorithm {
            get => GetSZ("SMTP_Encryption_Algorithm");
            set => Set("SMTP_Encryption_Algorithm", value);
            }

        /// <summary>
        /// Accessor for key "Field.Key" of type DWORD
        /// </summary>
        public virtual uint SMTP_Prompt_for_Password {
            get => GetDWORD("SMTP_Prompt_for_Password");
            set => Set("SMTP_Prompt_for_Password", value);
            }

        public override bool Equals(object obj) => obj is MessageAccount account &&
                   Account_Name == account.Account_Name;

        public override int GetHashCode() => base.GetHashCode(); 
        }
	}

