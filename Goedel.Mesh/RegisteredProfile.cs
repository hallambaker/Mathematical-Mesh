//   Copyright © 2015 by Comodo Group Inc.
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Mesh {

    /// <summary>
    /// Describe the means by which a registration is made.
    /// </summary>
    public enum RegistrationType {
        /// <summary>
        /// Data is stored in a Windows registry key
        /// </summary>
        Registry,

        /// <summary>
        /// Data is stored in a file in the ~/.mmm directory.
        /// </summary>
        File,

        /// <summary>
        /// Data was previously registered but has been deleted.
        /// </summary>
        Removed
        }

    /// <summary>
    /// Describes a registration
    /// </summary>
    public abstract class Registration {
        /// <summary>
        /// The location of the registration.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The type of registration (i.e. Registry or file)
        /// </summary>
        public RegistrationType Type { get; set; }

        /// <summary>
        /// Fetch the latest version of the profile version
        /// </summary>
        public abstract void Refresh();

        }


    /// <summary>
    /// Describes the registration of as profile on as machine. This includes
    /// the fingerprint, the cached profile data and the list of portal entries
    /// to which the profile is bound.
    /// </summary>
    public class RegistrationPersonal : Registration {


        string _UDF;
        SignedProfile _Profile;
        SortedList<DateTime, SignedProfile> _Profiles;
        List<string> _Accounts;

        /// <summary>
        /// The profile fingerprint
        /// </summary>
        public string UDF {
            get {
                return _UDF;
                }

            set {
                _UDF = value;
                }
            }

        /// <summary>
        /// The most recent cached profile data, if available.
        /// </summary>
        public SignedProfile Profile {
            get {
                return _Profile;
                }

            set {
                _Profile = value;
                }
            }

        /// <summary>
        /// List of the accounts through which the profile is registered.
        /// </summary>
        public List<string> Accounts {
            get {
                return _Accounts;
                }

            set {
                _Accounts = value;
                }
            }

        /// <summary>
        /// Profiles associated with this account in chronological order.
        /// </summary>
        public SortedList<DateTime, SignedProfile> Profiles {
            get {
                return _Profiles;
                }

            set {
                _Profiles = value;
                }
            }

        /// <summary>
        /// Fetch the latest version of the profile version
        /// </summary>
        public override void Refresh() {
            }


        }

    /// <summary>
    /// Describes the registration of a device profile on a machine.
    /// </summary>
    public class RegistrationDevice : Registration {

        DeviceProfile _Device;

        /// <summary>
        /// The Device profile
        /// </summary>
        public DeviceProfile Device {
            get {
                return _Device;
                }

            set {
                _Device = value;
                }
            }

        /// <summary>
        /// Fetch the latest version of the profile version
        /// </summary>
        public override void Refresh() {
            }


        }

    /// <summary>
    /// Describes a set of registered profiles on a particular machine, usually the
    /// current machine.
    /// </summary>
    public class RegistrationMachine : Registration {

        static RegistrationMachine _Current;

        List<RegistrationPersonal> _Personals = new List<RegistrationPersonal> ();
        RegistrationPersonal _Personal;
        List<RegistrationDevice> _Devices = new List<RegistrationDevice> ();
        RegistrationDevice _Device;

        /// <summary>
        /// The registration on the current machine. This will be read from either
        /// the Windows registry (Windows) or the ~/.mmm directory (OSX, Linux).
        /// </summary>
        public static RegistrationMachine Current {
            get {
                if (_Current == null) {
                    _Current = new RegistrationMachine();
                    }
                return _Current;
                }
            }

        /// <summary>
        /// The list of all the available personal profiles
        /// </summary>
        public List<RegistrationPersonal> Personals {
            get {
                return _Personals;
                }

            set {
                _Personals = value;
                }
            }

        /// <summary>
        /// The default personal profile
        /// </summary>
        public RegistrationPersonal Personal {
            get {
                return _Personal;
                }

            set {
                _Personal = value;
                }
            }

        /// <summary>
        /// The list of all device profiles
        /// </summary>
        public List<RegistrationDevice> Devices {
            get {
                return _Devices;
                }

            set {
                _Devices = value;
                }
            }

        /// <summary>
        /// The default device profile
        /// </summary>
        public RegistrationDevice Device {
            get {
                return _Device;
                }

            set {
                _Device = value;
                }
            }


        /// <summary>
        /// Fetch the latest version of the profile version
        /// </summary>
        public override void Refresh() {
            }
        }

    }
