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


/* Unmerged change from project 'Goedel.Discovery'
Before:
using System.Net.NetworkInformation;
using System.Text;

using System.Threading;
After:
using System.Net.Sockets;
using System.Text;
using System.Threading;
*/
using System.Net;

namespace Goedel.Discovery;



public class DnsUpdate {


    public DnsUpdate(
            IPAddress iPAddress) : this(new DnsClientTcp(iPAddress)) {
        }

    public DnsUpdate(
                DnsClient client) {



        }


    public void InitializeZone(
                    string zoneName, 
                    string tsig) {

        }

    public void Publish (
                    List<DNSRecord> records) { 
        
        
        }





    }


public class DnsClientTcp : DnsClient {


    public DnsClientTcp(
                    IPAddress iPAddress) {

        }




    public override DNSContext GetContext() {
        throw new NotImplementedException();
        }






    }
