using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Mesh.Platform;

namespace Goedel.Recrypt {
    public static class Convenience {


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
