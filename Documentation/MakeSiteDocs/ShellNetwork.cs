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

using System.Collections.Generic;

using Goedel.Mesh.Test;
using Goedel.Mesh;
using Goedel.Mesh.Client;
using Goedel.Utilities;
namespace ExampleGenerator;

public class ShellNetwork : ExampleSet {
    public List<ExampleResult> NetworkAdd;
    public List<ExampleResult> NetworkImport;
    public List<ExampleResult> NetworkGet;
    public List<ExampleResult> NetworkList;
    public List<ExampleResult> NetworkList1;
    public List<ExampleResult> NetworkList2;

    public List<ExampleResult> NetworkDelete;
    public List<ExampleResult> NetworkAuth;

    public const string NetworkFile1 = "NetworkEntry1.json";
    public const string NetworkFile2 = "NetworkEntry2.json";
    public const string NetworkID1 = "NetID1";
    public const string NetworkID2 = "NetID2";
    public const string NetworkSSID = "mywifi";
    public const string NetworkWiFi = "wifipassword";

    public ShellNetwork(CreateExamples createExamples) :
            base(createExamples) {

        var network2 = new CatalogedNetwork() {
            Protocol = "WPA2",
            Service = "ssid",
            Password = "Password"
            };
        network2.ToFile(NetworkFile2, tagged:true);



        NetworkAdd = Alice1.Example($"network add {NetworkSSID} {NetworkWiFi} /id={NetworkID1}");
        NetworkImport = Alice1.Example(
            $"network import {NetworkFile2} /id={NetworkID2}");

        var primaryKey = network2._PrimaryKey;

        NetworkGet = Alice1.Example($"network get {primaryKey}");
        NetworkGet = Alice1.Example($"network get {NetworkID2}");
        NetworkList = Alice1.Example($"network list");

        NetworkDelete = Alice1.Example(
            $"network delete {NetworkID2}",
            $"network list");

        // check the entry is properly deleted.

        NetworkGet = Alice1.Example($"!network get {primaryKey}");
        NetworkGet = Alice1.Example($"!network get {NetworkID2}");



        }
    }
