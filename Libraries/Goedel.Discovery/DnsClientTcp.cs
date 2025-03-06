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


/// <summary>
/// DNS update client.
/// </summary>
public class DnsUpdate {


    /// <summary>
    /// Constructor returns a new instance for the service at <paramref name="iPAddress"/>.
    /// </summary>
    /// <param name="iPAddress">IP address of the service to push updates to.</param>
    public DnsUpdate(
            IPAddress iPAddress) : this(new DnsClientTcp(iPAddress)) {
        }

    /// <summary>
    /// Constructor returns a new instance for the service using the DNS Client <paramref name="client"/>.
    /// </summary>
    /// <param name="client"></param>
    public DnsUpdate(
                DnsClient client) {
        }


    /// <summary>
    /// Initialize the zone entries.
    /// </summary>
    /// <param name="zoneName"></param>
    /// <param name="tsig"></param>
    public void InitializeZone(
                    string zoneName, 
                    string tsig) {
        }


    /// <summary>
    /// Publish the update records <paramref name="records"/> to the zone.
    /// </summary>
    /// <param name="records">The records to update.</param>
    public void Publish (
                    List<DNSRecord> records) { 
        }

    }


/// <summary>
/// DNS Client over TCP transport.
/// </summary>
public class DnsClientTcp : DnsClient {

    /// <summary>
    /// Constructor, return a new instance for the IP Address <paramref name="ipAddress"/>
    /// </summary>
    /// <param name="ipAddress">IP Address for the server to bind to.</param>
    public DnsClientTcp(
                    IPAddress ipAddress) {

        }



    /// <summary>
    /// Return a new DNS query context.
    /// </summary>
    /// <returns>The constrructed context.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public override DNSContext GetContext() {
        throw new NotImplementedException();
        }






    }
