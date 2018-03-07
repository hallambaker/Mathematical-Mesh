using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Mesh.Portal;
using Goedel.Mesh.Portal.Client;

namespace Goedel.Confirm {

    /// <summary>Extension methods.</summary>
    public static partial class Extension {

        /// <summary>
        /// Get the confirmation profile
        /// </summary>
        /// <param name="PersonalSession">The personal profile session.</param>
        /// <param name="AccountID">The recryption account.</param>
        /// <returns>The confirmation profile (if found).</returns>
        public static ConfirmProfile GetConfirmProfile (this SessionPersonal PersonalSession, string AccountID) {
            var Personal = PersonalSession.PersonalProfile;
            var Entry = Personal.GetNamedApplicationEntry("ConfirmProfile", AccountID);
            Assert.NotNull(Entry, ProfileNotFound.Throw, AccountID ?? "RecryptProfile");

            var ApplicationSession = PersonalSession.GetApplication(Entry.Identifier);

            Assert.NotNull(Entry, ProfileNotFound.Throw, AccountID ?? "Entry.Identifier");
            return ApplicationSession.ApplicationProfile as ConfirmProfile;
            }

        }
    }
