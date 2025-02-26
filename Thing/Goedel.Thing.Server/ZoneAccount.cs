//  Copyright © 2021 by Threshold Secrets Llc.
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

using Goedel.Discovery;

using System.Net;
using System.Runtime.ConstrainedExecution;

namespace Goedel.Acme;

public class ZoneAccount {

    public string Name { get; }
    public IPAddress Primary { get; }
    public string TsigKey { get; }



    public ZoneAccount(
                string name,
                IPAddress primary,
                string tsigKey) {
        Name = name;
        Primary = primary;
        TsigKey = tsigKey;
        }


    public void Initialize() {

        }


    private void Prepare (DNSRecord record) { 
        }

    public void Publish (List<DNSRecord> records) {

        // calculate the total record length
        foreach (DNSRecord record in records) {
            }
        var tsig = new DNSRecord_TSIG();

        // Construct the update record


        // add the preamble


        // splice in the records


        // Calculate the TSIG

        }

    private void Verify(DNSRecord record) {
        }


    public void PublishTxt(string domain, string text) {

        var record = new DNSRecord_TXT() {
            Domain = new (domain),
            Text = [text]
            };

        Publish([record]);

        Verify(record);
        }


    public void PublishA(string domain, List<IPAddress>) {
        }


    }
