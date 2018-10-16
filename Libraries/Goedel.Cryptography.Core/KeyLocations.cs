//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Goedel.Cryptography.Core {
//    public class KeyLocationsCore {

       


//        ///<summary></summary>
//        public static string DirectoryPersonalHome;

//        ///<summary></summary>
//        public static string DirectoryApplicationHome;

//        ///<summary></summary>
//        public static string DirectoryPersonalKeys;

//        ///<summary></summary>
//        public static string DirectoryMeshContainer;

//        static KeyLocationsCore() {
//            DirectoryPersonalHome = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
//            DirectoryApplicationHome = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

//            }




//        public static string GetPlatformInformation(PlatformInformation platformInformation) {
//            switch (platformInformation) {
//                case PlatformInformation.DirectoryPersonalHome:
//                    return DirectoryPersonalHome;
//                case PlatformInformation.DirectoryApplicationHome:
//                    return DirectoryApplicationHome;
//                }

//            return null;

//            }

//        }
//    }
