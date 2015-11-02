using System.Collections.Generic;
using Goedel.Persistence;


namespace Goedel.Mesh {
    public partial class Entry  {

        public virtual bool Valid {
            get { return true; }
            
            }

        public virtual List<IndexTerm> Keys {
            get { return new List<IndexTerm> (); }

            }
        }

    public partial class SignedProfile {


        public override bool Valid {
            get { return true; }

            }
        }

    public partial class EscrowEntry {
        public override bool Valid {
            get { return true; }

            }
        }


    }
