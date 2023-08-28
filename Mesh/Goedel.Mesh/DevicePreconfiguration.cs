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


namespace Goedel.Mesh;

/// <summary>
/// 
/// </summary>
/// <param name="SecretSeed">The computed secret seed value.</param>
/// <param name="ProfileDevice">The computed device profile.</param>
/// <param name="ConnectionService">Slim version of the device connection for 
/// authentication to the service.</param>
/// <param name="ConnectionDevice">The computed device connection.</param>
/// <param name="ConnectKey">The computed PIN code.</param>
/// <param name="ConnectUri">The connection URI to be used for pickup.</param>
public record DevicePreconfiguration (
                PrivateKeyUDF SecretSeed,
                ProfileDevice ProfileDevice,
                ConnectionService ConnectionService,
                ConnectionDevice ConnectionDevice,
                string ConnectKey,
                string ConnectUri) {

    ///<summary>The public configuration file (for e.g. Web publication.</summary> 
    public DevicePreconfigurationPublic DevicePreconfigurationPublic;

    ///<summary>The private configuration file (for upload to the device).</summary> 
    public DevicePreconfigurationPrivate DevicePreconfigurationPrivate;

    ///<summary>Filename the preconfiguration was written to.</summary> 
    public string Filename;

    }



public partial class DevicePreconfigurationPrivate {

    ///<summary>Base constructor for deserialization.</summary>
    public DevicePreconfigurationPrivate() {
        }



    /// <summary>
    /// Read device preconfiguration data from a file.
    /// </summary>
    /// <param name="filename">The file to read.</param>
    /// <returns>The DevicePreconfiguration instance created from the file data.</returns>
    public static DevicePreconfigurationPrivate FromFile(string filename) {
        using var inputStream = filename.OpenFileRead();
        using var reader = new JsonReader(inputStream);

        return FromJson(reader, tagged: true);

        }


    }
