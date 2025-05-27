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

#pragma warning disable IDE0051

using System.Text.Json.Serialization;

namespace Goedel.Protocol.Test;

public partial class Envelope<T> : Envelope {

    ///// <summary>
    ///// </summary>

    //[JsonPropertyName("Header")]
    //public virtual string? Header { get; set; } //

    ///// <summary>
    ///// </summary>

    //[JsonPropertyName("Body")]
    //public virtual string? Body { get; set; } //

    ///// <summary>
    ///// </summary>

    //[JsonPropertyName("Trailer")]
    //public virtual string? Trailer { get; set; } //

    /////<summary>Implement IBinding</summary> 
    //public override Binding _Binding => _binding;
    //public static readonly new Binding<Envelope> _binding = new(
    //     new() {

    //        { "Header", new PropertyString ("Header",
    //                (IBinding data, string? value) => {(data as Envelope).Header = value;},
    //                (IBinding data) => (data as Envelope).Header )},
    //        { "Body", new PropertyString ("Body",
    //                (IBinding data, string? value) => {(data as Envelope).Body = value;},
    //                (IBinding data) => (data as Envelope).Body )},
    //        { "Trailer", new PropertyString ("Trailer",
    //                (IBinding data, string? value) => {(data as Envelope).Trailer = value;},
    //                (IBinding data) => (data as Envelope).Trailer )}
    // }, __Tag, () => new Envelope(), () => new List<Envelope>(), () => new Dictionary<string, Envelope>(), null);

    ///// <summary>
    ///// Tag identifying this class
    ///// </summary>
    //public override string _Tag => __Tag;

    ///// <summary>
    ///// Tag identifying this class
    ///// </summary>
    //public new const string __Tag = "Envelope";

    //public Enveloped() {
    //    }

    public  void Wrap() {
        }

    public  void Unwrap() {
        }


    }
