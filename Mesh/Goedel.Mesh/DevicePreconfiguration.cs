#region // Copyright
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


using Goedel.IO;
using Goedel.Protocol;
namespace Goedel.Mesh {
    public partial class DevicePreconfiguration {

        ///<summary>Base constructor for deserialization.</summary>
        public DevicePreconfiguration() {
            }



        /// <summary>
        /// Read device preconfiguration data from a file.
        /// </summary>
        /// <param name="filename">The file to read.</param>
        /// <returns>The DevicePreconfiguration instance created from the file data.</returns>
        public static DevicePreconfiguration FromFile(string filename) {
            using var inputStream = filename.OpenFileRead();
            using var reader = new JsonReader(inputStream);

            return FromJson(reader, tagged: true);

            }


        }
    }
