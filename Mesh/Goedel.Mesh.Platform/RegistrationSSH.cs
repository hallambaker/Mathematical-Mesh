//using Goedel.Utilities;
//using Goedel.Mesh;
//using Goedel.Mesh.Platform;

//namespace Goedel.Mesh.Platform {


//    public partial class SessionPersonal {

//        /// <summary>
//        /// Convenience method to create and register a new SSHProfile
//        /// </summary>
//        /// <param name="RegistrationPersonal"></param>
//        /// <param name="Write">If true, updates are written to local store and portal</param>
//        /// <returns></returns>
//        public virtual SessionApplication CreateSSH (
//                    bool Write=true) {
//            var Profile = SSHProfile.Create(PersonalProfile);
//            var RegistrationApplication = Add(Profile, false);



//            foreach (var Device in PersonalProfile.Devices) {
//                var Administration = Device.UDF == PersonalProfile.DeviceProfile.UDF;
//                RegistrationApplication.AddDevice(Device.DeviceProfile, Administration);
//                }


//            if (Write) {
//                this.Write();
//                RegistrationApplication.Write();
//                }

//            return RegistrationApplication;
//            }



//        }
//    }
