﻿#region // Copyright - MIT License
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
using System.Diagnostics;
using System.Security.Cryptography;

using System.Text;

namespace Goedel.Test;

public static class TestName {


    public static string Get(params object[] parameters) {
        var stack = new StackTrace();
        var frame = stack.GetFrame(1);
        var method = frame.GetMethod();

        return Format(method.Name, parameters);
        }

    public static string GetCaller(params object[] parameters) {
        var stack = new StackTrace();
        var frame = stack.GetFrame(1);
        var method = frame.GetMethod();

        return Format(method.Name, parameters);
        }


    static string Format(string tag, params object[] parameters) {

        var builder = new StringBuilder();
        builder.Append(tag);
        foreach (var v in parameters) {
            builder.Append('-');
            builder.Append(v.ToString());
            }

        return builder.ToString();

        }


    public static byte[] GetTestBytes(string tag, int length, int info) =>
        GetTestBytes(tag, length, info.ToString());

    public static byte[] GetTestBytes(string tag, int length, string info) {
        if (length == 0) {
            return Array.Empty<byte>();
            }

        var result = new byte[length];
        var key = KeyDeriveHKDF.Derive(tag.ToBytes(), info: info.ToBytes(), length: 128);


        var aes = new AesGcm(key);
        var nonce = new byte[AesGcm.NonceByteSizes.MinSize];
        var discard = new byte[AesGcm.TagByteSizes.MinSize];


        aes.Encrypt(nonce, result, result, discard);

        return result;
        }



    }

