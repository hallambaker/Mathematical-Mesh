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

using Goedel.Utilities;
namespace Goedel.IO;

/// <summary>
/// Contains objects to be shared across the whole application.
/// </summary>
public static class UriClient {


    ///<summary>Http Client for whole application</summary> 
    public static HttpClient HttpClient { get; } = new();

    /// <summary>
    /// Uploads a data buffer that contains a Byte array to the URI specified 
    /// as an asynchronous operation using a task object. Uses the application 
    /// default <see cref="HttpClient"/>.
    /// </summary>
    /// <param name="address">The URI of the resource to receive the data.</param>
    /// <param name="data">The data buffer to send to the resource.</param>
    /// <returns>The task object representing the asynchronous operation. The Result 
    /// property on the task object returns a Byte array containing the body of the 
    /// response received from the resource when the data buffer was uploaded.</returns>
    public static async Task<byte[]> UploadDataTaskAsync(this string address, byte[] data) {
        //var webClient = new WebClient();
        //var bytes = webClient.UploadData(address, data);


        Console.WriteLine($"Send request to {address} bytes: {data.Length}");

        var request = new ByteArrayContent(data);

        //address = address + "/";
        var response = await HttpClient.PostAsync(address, request).ConfigureAwait(true);
        var content = response.Content;
        var bytes = await content.ReadAsByteArrayAsync();
        var discard = bytes.ToUTF8();
        return bytes;
        }




    }
