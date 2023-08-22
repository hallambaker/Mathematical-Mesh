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

using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Utilities;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Security.Cryptography;

using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Test;

public class UnitTestSet : Disposable {
    public static readonly string AccountAlice = "alice@example.com";
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



    public string CallsignAlice => "@alice";
    public string CallsignBob => "@bob";
    public string CallsignMallet => "@mallet";
    public string CallsignRegistry => "@registry";

    ///<summary>The deterministic seed to be used by the test, may be set explictly
    ///or generated automatically through use in a test method.</summary> 
    public virtual DeterministicSeed Seed {
        get => seed ?? DeterministicSeed.AutoClean ().CacheValue(out seed);
        set => seed = value;
        }

    DeterministicSeed seed;

    }


public class DeterministicSeed {
    public static readonly string TestPath = "TestPath";
    static readonly string WorkingDirectory = "Deterministic";

    public string Seed { get; }
    public byte[] SeedBytes { get; }


    public string Directory { get; }

    public static string TestRoot { get; }

    public int TempCount { get; set;}= 0;

    static DeterministicSeed() {
        TestRoot = Environment.GetEnvironmentVariable(TestPath);
        }


    DeterministicSeed (string name, bool delete=false) {
        Seed = name;
        SeedBytes = Seed.ToBytes ();

        TestRoot.AssertNotNull(EnvironmentVariableRequired.Throw, TestPath);
        

        Directory = System.IO.Path.Combine(TestRoot, WorkingDirectory, Seed);
        if (delete && System.IO.Directory.Exists(Directory)) {
            System.IO.Directory.Delete(Directory, true);
            }

        System.IO.Directory.CreateDirectory(Directory);
        System.IO.Directory.SetCurrentDirectory(Directory);
        }

    public string GetTempFilePath() => Path.Combine(Directory, GetTempFileName());

    public string GetTempDir() {
        var result = GetTempFilePath();
        System.IO.Directory.CreateDirectory(result);

        return result;
        }


    public string GetTempFileName() => $"Temp{TempCount++}";

    public static DeterministicSeed AutoClean(params object[] parameters) {
        var stack = new StackTrace();


        for (var i = 0; i < stack.FrameCount; i++) {
            var frame = stack.GetFrame(stack.FrameCount - i - 1);
            var method = frame.GetMethod();
            if (HasTest(method)) {
                return new DeterministicSeed(Format(method.Name, parameters), true);
                }
            }

        throw new UnitTestNotFound();

        }

    public static DeterministicSeed Auto(params object[] parameters) {
        var stack = new StackTrace();


        for (var i = 0; i < stack.FrameCount; i++) {
            var frame = stack.GetFrame(stack.FrameCount - i -1);
            var method = frame.GetMethod();
            if (HasTest(method)) {
                return new DeterministicSeed(Format(method.Name, parameters));
                }
            }

        throw new UnitTestNotFound();

        }

    static bool HasTest(MethodBase method) {
        //parameter = "";
        if (method is MethodInfo methodInfo) {

            var attributes = methodInfo.GetCustomAttributes();

            foreach (var attribute in attributes) {

                if ((Type)attribute.TypeId == typeof(Xunit.FactAttribute)) {
                    return true;
                    }
                if ((Type)attribute.TypeId == typeof(Xunit.TheoryAttribute)) {
                    //parameter = ParametersToString(methodInfo);
                    return true;
                    }
                }


            }
        //foreach (var attribute in method.Attributes) {

        //    }
        return false;
        }


    public static DeterministicSeed Create(params object[] parameters) {
        var stack = new StackTrace();
        var frame = stack.GetFrame(1);
        var method = frame.GetMethod();

        return new DeterministicSeed (Format(method.Name, parameters));
        }

    public static DeterministicSeed CreateParent(params object[] parameters) {
        var stack = new StackTrace();
        var frame = stack.GetFrame(2);
        var method = frame.GetMethod();

        return new DeterministicSeed(Format(method.Name, parameters));
        }

    public static DeterministicSeed CreateDeep(int parent, params object[] parameters) {
        var stack = new StackTrace();
        var frame = stack.GetFrame(parent);
        var method = frame.GetMethod();

        return new DeterministicSeed(Format(method.Name, parameters));
        }

    public string GetDirectory(string label) =>
        Path.Combine(Directory, label);
        
    public string GetFilename(string label) =>
         Path.Combine(Directory, label);



    public int GetInt32(int ceiling, params object[] parameters) {
        var info = FormatBytes("GetInt32", parameters);

        var bytes = KeyDeriveHKDF.Derive(SeedBytes, info: info, length: 32);
        var number = bytes.LittleEndian32() % ceiling;
        return (int)number;
        }

    public long GetInt64(long ceiling, params object[] parameters) {
        var info = FormatBytes("GetInt64", parameters);

        var bytes = KeyDeriveHKDF.Derive(SeedBytes, info: info, length: 64);
        bytes[7] &= 0x7f;
        var number = (long)bytes.LittleEndian64() % ceiling;
        return (long)number;
        }

    public string GetNonce(params object[] parameters) {
        var info = FormatBytes("GetNonce", parameters);

        var bits = 128;
        var bytes = GetTestBytes(SeedBytes, bits / 8, info);

        return Udf.TypeBDSToString(UdfTypeIdentifier.Nonce, bytes, bits + 8);
        }

    public int GetTask(IList<int> tasks, params object[] parameters) {
        var total = 0;
        foreach (var item in tasks) {
            total += item;
            }
        if (total <= 0) {
            return -1;
            }
        var index = GetInt32 (total, parameters);
        var task = 0;
        for(var i = 0; i<tasks.Count; i++) {
            if (index < tasks[i]) {
                tasks[i]--;
                return task;
                }
            }

        return -1;
        }

    public int GetRandomInt(int ceiling, int info = 0, string label="") {
        var bytes = KeyDeriveHKDF.Derive(Seed.ToBytes(),
                    info: $"Number {info} {label}".ToBytes(), length: 32);
        var number = bytes.LittleEndian32() % ceiling;
        return (int) number;
        }




    public byte[] GetTestBytes(int length, long info) =>
            GetTestBytes(Seed, length, info.ToString());

    public byte[] GetTestBytes(int length, string info) =>
        GetTestBytes(Seed, length, info);



    public void MakeTestFile(string filename, int length, string info="") {

        var bytes = GetTestBytes(length, info);
        using (var stream = filename.OpenFileNew()) {
            stream.Write(bytes);
            }
        }

    public void CheckTestFile(string filename, int length, string info="") {
        var bytes = GetTestBytes(length, info);
        using (var stream = filename.OpenFileRead()) {
            (stream.Length == length).TestTrue();

            var read = new byte[length];
            
            stream.Read(read, 0, length);

            read.TestEqual (bytes);
            }
        }


    public void CheckTestFileNotExist(string filename) {
        File.Exists(filename).TestFalse();
        }

    /* Static, remove over time  */

    public static string GetUnique(params object[] parameters) {
        var stack = new StackTrace();
        var frame = stack.GetFrame(1);
        var method = frame.GetMethod();

        return Format(method.Name, parameters);
        }

    static byte[] FormatBytes(string tag, params object[] parameters) =>
        Format(tag, parameters).ToBytes();


    static string Format(string tag, params object[] parameters) {

        var builder = new StringBuilder();
        builder.Append(tag);
        foreach (var v in parameters) {
            builder.Append('-');
            if (v is not null) {
                builder.Append(v.ToString());
                }
            }

        return builder.ToString();

        }


    static byte[] GetTestBytes(string tag, int length, string info) =>
        GetTestBytes(tag.ToBytes(), length, info.ToBytes());


    static byte[] GetTestBytes(byte[] tag, int length, byte[] info) {
        if (length == 0) {
            return Array.Empty<byte>();
            }

        var result = new byte[length];
        var key = KeyDeriveHKDF.Derive(tag, info: info, length: 128);


        var aes = new AesGcm(key);
        var nonce = new byte[AesGcm.NonceByteSizes.MinSize];
        var discard = new byte[AesGcm.TagByteSizes.MinSize];


        aes.Encrypt(nonce, result, result, discard);

        return result;
        }



    }

