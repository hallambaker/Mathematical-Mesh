using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Mesh.Platform;

namespace Goedel.Mesh.Platform {


    public partial class RegistrationPersonal {

        /// <summary>
        /// Convenience method to create and register a new SSHProfile
        /// </summary>
        /// <param name="RegistrationPersonal"></param>
        /// <param name="Write">If true, updates are written to local store and portal</param>
        /// <returns></returns>
        public virtual RegistrationApplication CreateSSH (
                    bool Write=true) {
            var Profile = SSHProfile.Create(PersonalProfile);
            var RegistrationApplication = Add(Profile, false);

            if (Write) {
                this.Write();
                RegistrationApplication.Write();
                }

            return RegistrationApplication;
            }



        }
    }
