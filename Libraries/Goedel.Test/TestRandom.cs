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
using Goedel.Cryptography.Algorithms;
using System.Security.Principal;

namespace Goedel.Test;

public class TestRandom {

    int Count { get; set; }

    string Seed { get; set; }

    /// <summary>
    /// Constructor creating an instance using the string 
    /// <paramref name="test"/>-<paramref name="parameters"/>-<paramref name="count"/>.
    /// </summary>
    /// <param name="test"></param>
    /// <param name="parameters"></param>
    /// <param name="count"></param>
    public TestRandom(string test, string? parameters = null, int count = 0) {


        Seed = test + (parameters ?? "") + "-";

        //Console.WriteLine(Seed);
        Count = count;

        }


    /// <summary>
    /// Determine the name of the calling method and return a random number provider
    /// for that label with the specified count.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NYI"></exception>
    public static TestRandom GetRandom(string? parameters = null, int count = 0) =>
        new TestRandom(AssemblyStack.GetCallerMethodName(), parameters, count);



    public byte[] GetBytes(int length, string tag=null) {
        var seed = Seed + tag ?? (Count.ToString());
        Count++;


        Console.WriteLine($"Seed {seed} [{length}]");

        return SHAKE256.GetBytes(length);
        }


    public void FillRandomBytes(byte[] Data, int Offset, int Count) {
        }


    }

