//Sample license text.
using Goedel.Mesh;
using Goedel.Protocol;
using System.Collections.Generic;

namespace Goedel.MeshSampleClient {

    /// <summary>
    /// Backing class for sample client demo
    /// </summary>
    public partial class SampleApplication {
        public string ConfigPassword = "No profile";
        public string ConfigNetwork = "No profile";
        public string ConfigEmail = "No profile";

        public SignedDeviceProfile ThisDevice;

        public MeshClient MeshClient;

        public string AccountName;
        public string Portal;
        public string AccountID {
            get { return Account.ID(AccountName, Portal); }
            }

        /// <summary>
        /// Flag to allow local processing.
        /// </summary>
        public bool DoLocal = false;


        SignedPersonalProfile SignedCurrentProfile;
        PersonalProfile PersonalCurrentProfile;
        public override void Initialize() {

            if (DoLocal) {
                MeshPortal.Default = new MeshPortalDirect();
                }

            else {
                JPCProvider.LocalLoopback = false;
                var Portal = new MeshPortalRemote();
                MeshPortal.Default = Portal;
                }


            // Get the default device
            ThisDevice = SignedDeviceProfile.GetLocal();

            // Get the default profile
            MeshClient = new MeshClient();
            if (MeshClient.Connected) {
                AccountName = MeshClient.AccountName;
                Portal = MeshClient.Portal;
                SignedCurrentProfile = SignedPersonalProfile.GetLocal(MeshClient.UDF);
                PersonalCurrentProfile = SignedCurrentProfile.Signed;
                PersonalCurrentProfile.SignedDeviceProfile = ThisDevice;
                }
            }


        PasswordProfile _PasswordProfile;
        public PasswordProfile PasswordProfile {
            get {
                if (_PasswordProfile == null) {
                    _PasswordProfile = new PasswordProfile(PersonalCurrentProfile);
                    }
                return _PasswordProfile;
                }
            }

        PasswordProfilePrivate PasswordProfilePrivate {
            get {
                if (PasswordProfile == null) return null;
                return PasswordProfile.Private;
                }
            }


        public string GetPasswords () {
            if (PasswordProfilePrivate == null) return null;

            string Config = "";

            if (PasswordProfilePrivate.Entries != null) {               
                foreach (var Entry in PasswordProfilePrivate.Entries) {
                    Config = Config + string.Format("[{0}/{1}]", Entry.Username, Entry.Password);
                    }
                }
            return Config;
            }


        public bool AddPassword(string DomainName, string Username, string Password) {
            PasswordEntry Entry = new PasswordEntry(DomainName, Username, Password);
            if (PasswordProfilePrivate.Entries == null) {
                PasswordProfilePrivate.Entries = new List<PasswordEntry> ();
                }

            PasswordProfilePrivate.Entries.Add(Entry);

            return false;
            }




        NetworkProfile _NetworkProfile;
        public NetworkProfile NetworkProfile {
            get {
                if (_NetworkProfile == null) {
                    _NetworkProfile = new NetworkProfile(PersonalCurrentProfile);
                    }
                return _NetworkProfile;
                }
            }

        NetworkProfilePrivate NetworkProfilePrivate {
            get {
                if (NetworkProfile == null) return null;
                return NetworkProfile.Private;
                }
            }


        public string GetNetwork() {
            if (NetworkProfilePrivate == null) return "<No Entry>";
            if (NetworkProfilePrivate.DNS == null ||
                NetworkProfilePrivate.DNS.Count <=0) return "<Not Specified>";
            var Connection = NetworkProfilePrivate.DNS[0];

            return string.Format ("{0}:{1}", Connection.ServiceName, Connection.Port);
            }


        public bool SetNetwork(string DNS1, string DNS2, string DNSProtocol) {
            if (NetworkProfilePrivate == null) return false;

            var Security = new List<string> { DNSProtocol };
            var Connection = new Connection(DNS1, 53, DNS2, Security);

            NetworkProfilePrivate.DNS = new List<Connection> { Connection };

            return false;
            }


        MailProfile _MailProfile;
        public MailProfile MailProfile {
            get {
                return _MailProfile;
                }
            }

        MailProfilePrivate MailProfilePrivate {
            get {
                if (MailProfile == null) return null;
                return MailProfile.Private;
                }
            }


        public string GetMail() {
            if (MailProfilePrivate == null) return "<No Entry>";
            //if (MailProfilePrivate.Connections == null ||
            //    MailProfilePrivate.Connections.Count <= 0)
            //    return "<Not Specified>";
            //var Connection = MailProfilePrivate.Connections[0];

            return "Not yet implemented";

            //return string.Format("{0}:{1}", Connection.ServiceName, Connection.Port);
            }


        public bool SetMail(string MailServer, string Account) {
            _MailProfile = new MailProfile(PersonalCurrentProfile, Account);

            var Connection = new Connection(MailServer, 25, null, null);

            //MailProfilePrivate.Connections = new List<Connection> { Connection };

            return false;
            }

        }
    }
