#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
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
#endregion
using Goedel.Discovery;

namespace Goedel.Discovery;



public abstract class DNSRecord_Update : DNSItem {


    }

public class DNSRecord_PreNameInUse : DNSRecord_Update {
    public bool Negate { get; set; }
    }

public class DNSRecord_PreRRSetExists : DNSRecord_Update {
    public bool Negate { get; set; }
    public DNSRecord Value { get; set; }
    }


public class DNSRecord_Add : DNSRecord_Update {
    public DNSRecord Add { get; set; }

    public DNSRecord_Add(
                string name,
                DNSTypeCode typeCode,
                byte[] add) {
        
        Add = DNSRecord.DecodeRData(name, typeCode, add);
        Add.Domain = new Domain(name);
        }


    }

public class DNSRecord_DeleteAll : DNSRecord_Update {

    public DNSRecord_DeleteAll(
                string name) {
        }


    }





public class DNSRecord_DeleteRRset : DNSRecord_Update {
    public DNSRecord_DeleteRRset(
                string name,
                DNSTypeCode type) {
        }



    }

public class DNSRecord_DeleteRR : DNSRecord_Update {

    public DNSRecord Delete { get; set; }


    public DNSRecord_DeleteRR(
            string name,
                DNSTypeCode typeCode,
                byte[] add) {
        //Delete = delete;
        }



    }
