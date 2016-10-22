using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Platform {
    /// <summary>
    /// Initialize the platform
    /// </summary>
    public class Initialize {

        /// <summary>
        /// Initializtation method
        /// </summary>
        public Initialize() {

            WindowsCertificateStore.Initialize();
            }
        }
    }
