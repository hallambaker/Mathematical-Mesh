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

namespace Goedel.Test;

// The base from which all test sets should be derrived
public class UnitTestSet : Disposable {
    public static readonly string AccountAlice = "alice@example.com";
    public static readonly string HandleAlice = "@alice.alt";
    public static readonly string HandleBob = "@bob.alt";

    public static readonly string ServiceName = "example.com";
    public static readonly string AccountBob = "bob@example.com";
    public static readonly string AccountQ = "q@example.com";
    public static readonly string AccountMallet = "mallet@example.com";
    public static readonly string AccountRegistryAdmin = "registryadmin@example.com";
    public static readonly string AccountAdminCarnet = "carnetadmin@example.com";
    public static readonly string AccountRegistry = "callsign@example.com";
    public static readonly string AccountResolver = "resolver@example.com";
    public static readonly string AccountCarnet = "carnet@example.com";

    public static readonly string AccountServiceAdmin = "admin@example.com";


    public string DeviceAliceAdmin = "Alice Admin";
    public string DeviceAlice2 = "Alice Device 2";
    public string DeviceAlice3 = "Alice Device 3";
    public string DeviceBobAdmin = "Bob Admin";
    public string DeviceQ = "DeviceQ";
    public string DeviceMallet = "DeviceMallet";

    public static string DeviceAdminName => "DeviceAdmin";
    public static string DeviceConnect1Name => "DeviceConnect1";


    public string CallsignAlice => "@alice";
    public string CallsignBob => "@bob";
    public string CallsignMallet => "@mallet";
    public string CallsignRegistry => "@registry";

    ///<summary>The deterministic seed to be used by the test, may be set explictly
    ///or generated automatically through use in a test method.</summary> 
    public virtual DeterministicSeed Seed {
        get => seed ?? DeterministicSeed.AutoClean().CacheValue(out seed);
        set => seed = value;
        }
    DeterministicSeed seed;


    protected string GetUniqueFilepath(string extension = "txt") =>
            Seed.GetUniqueFilepath(extension);

    protected string GetUniqueFilepathData(string content, string extension = "txt") {
        var result = Seed.GetUniqueFilepath(extension);
        result.WriteFileNew(content);
        return result;
        }

    protected string GetUniqueFilepathData(byte[] content, string extension = "bin") {
        var result = Seed.GetUniqueFilepath(extension);
        result.WriteFileNew(content);
        return result;
        }

    public virtual void StartTest(params object[] parameters) {
        Seed = DeterministicSeed.AutoClean(parameters);
        }

    protected virtual void EndTest() {
        }

    }

