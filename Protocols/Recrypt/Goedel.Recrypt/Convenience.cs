using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Mesh.Portal;
using Goedel.Mesh.Portal.Client;

namespace Goedel.Recrypt {

    /// <summary>Extension methods for recryption classes.</summary>
    public static partial class Extension {

        /// <summary>
        /// Get the recryption profile
        /// </summary>
        /// <param name="PersonalSession">The personal session</param>
        /// <param name="AccountID">The recryption account identifier.</param>
        /// <returns>The recryption profile.</returns>
        public static RecryptProfile GetRecryptProfile (this SessionPersonal PersonalSession, string AccountID) {
            var Personal = PersonalSession.PersonalProfile;
            var Entry = Personal.GetNamedApplicationEntry("RecryptProfile", AccountID);
            Assert.NotNull(Entry, ProfileNotFound.Throw, AccountID ?? "RecryptProfile");

            var ApplicationSession = PersonalSession.GetApplication(Entry.Identifier);

            Assert.NotNull(Entry, ProfileNotFound.Throw, AccountID ?? "Entry.Identifier");
            return ApplicationSession.ApplicationProfile as RecryptProfile;
            }

        }
    }
