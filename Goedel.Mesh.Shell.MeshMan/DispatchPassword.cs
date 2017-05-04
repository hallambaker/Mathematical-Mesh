using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Mesh.Platform;

namespace Goedel.Mesh.MeshMan {

    public partial class Shell {
        /// Create a new web application profile.
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void Password(Password Options) {
            SetReporting(Options);
            var RegistrationPersonal = GetPersonal(Options);

            var PasswordProfile = new PasswordProfile(true);
            Register(RegistrationPersonal, PasswordProfile);
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void DumpPassword(DumpPassword Options) {
            SetReporting(Options.Report, Options.Verbose);
            GetProfile(Options.Portal, Options.UDF);

            var RegistrationApplication = GetApplication(Options, "PasswordProfile");
            var PasswordProfile = RegistrationApplication?.ApplicationProfile as PasswordProfile;
            var PasswordProfilePrivate = PasswordProfile.Private;

            if (PasswordProfilePrivate.Entries == null) {
                Report("Empty");
                }
            else {
                foreach (var Entry in PasswordProfilePrivate.Entries) {
                    Report("Sites: ", Entry.Sites);
                    Report("    Username: {0} Password {1}", Entry.Username, Entry.Password);
                    }
                }

            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void AddPassword(AddPassword Options) {
            SetReporting(Options.Report, Options.Verbose);
            GetProfile(Options.Portal, Options.UDF);
            GetMeshClient();
            var RegistrationApplication = GetApplication(Options, "PasswordProfile");
            var PasswordProfile = RegistrationApplication?.ApplicationProfile as PasswordProfile;

            PasswordProfile.Add(Options.Site.Value, Options.Username.Value,
                Options.Password.Value);

            RegistrationApplication.Write();
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void GetPassword(GetPassword Options) {
            SetReporting(Options.Report, Options.Verbose);
            GetProfile(Options.Portal, Options.UDF);
            GetMeshClient();
            var RegistrationApplication = GetApplication(Options, "PasswordProfile");
            var PasswordProfile = RegistrationApplication?.ApplicationProfile as PasswordProfile;

            var Entry = PasswordProfile.Get(Options.Site.Value);

            Report("Username {0} Password {1}", Entry.Username, Entry.Password);
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Options">Command line parameters</param>
        public override void DeletePassword(DeletePassword Options) {
            SetReporting(Options.Report, Options.Verbose);
            GetProfile(Options.Portal, Options.UDF);
            GetMeshClient();
            var RegistrationApplication = GetApplication(Options, "PasswordProfile");
            var PasswordProfile = RegistrationApplication?.ApplicationProfile as PasswordProfile;


            PasswordProfile.Delete(Options.Site.Value);

            RegistrationApplication.Write();
            }
        }

    }
