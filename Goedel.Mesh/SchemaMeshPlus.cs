﻿//   Copyright © 2015 by Comodo Group Inc.
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
        /// The set of keys under which the Entry is to be cataloged.
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
        ///// <summary>
        ///// Is true if the Entry passed validation checking.
        ///// </summary>
        ///// <returns>True if the Entry passed validation checking.</returns>
        //public bool GetPrivate () {
        //    return false;
        //    }
        }


    }
