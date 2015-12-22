//Sample license text.
using System.Collections.Generic;
using Goedel.Persistence;


namespace Goedel.Mesh {


    public partial class Entry  {
        /// <summary>
        /// Is true if the Entry passed validation checking.
        /// </summary>
        public virtual bool Valid {
            get { return true; }
            }

        /// <summary>
        /// The set of keys under which the Entry is to be catalogued.
        /// </summary>
        public virtual List<IndexTerm> Keys {
            get { return new List<IndexTerm> (); }
            }
        }

    public partial class SignedProfile {

        /// <summary>
        /// Is true if the Entry passed validation checking.
        /// </summary>
        public override bool Valid {
            get { return true; }
            }
        }

    public partial class EscrowEntry {
        /// <summary>
        /// Is true if the Entry passed validation checking.
        /// </summary>
        public override bool Valid {
            get { return true; }
            }
        }

    public partial class PublicKey {
        /// <summary>
        /// Is true if the Entry passed validation checking.
        /// </summary>
        public bool GetPrivate () {
            return false;
            }
        }

    }
