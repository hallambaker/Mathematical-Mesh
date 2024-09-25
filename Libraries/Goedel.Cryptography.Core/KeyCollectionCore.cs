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

namespace Goedel.Cryptography.Core;



/// <summary>
/// KeyCollection implementation using platform agnostic .NET 5.0 
/// </summary>
public class KeyCollectionCore : KeyCollection, IKeyCollection {

    const string WindowsMeshDirectory = @"Mesh";
    const string LinuxMeshDirectory = @"Mesh";
    const string KeysDirectory = @"Keys";
    static string directoryKeys;

    ///<summary>Directory in which to store keys</summary> 
    public virtual string DirectoryKeys => directoryKeys;

    ///<summary>Directory containing the Mesh configuration.</summary> 

    public static string MeshConfigurationDirectory = null!;


    //static string GetWindowsAppRoot() => Path.Combine(
    //                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppData\\Local");

    static string GetWindowsAppRoot() => Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Mesh");


    static KeyCollectionCore() {
        var platform = Environment.OSVersion.Platform;
        switch (platform) {
            case PlatformID.Win32NT: {
                var appsRoot = GetWindowsAppRoot();

                MeshConfigurationDirectory = Path.Combine(appsRoot, WindowsMeshDirectory);
                directoryKeys = Path.Combine(MeshConfigurationDirectory, KeysDirectory);
                break;
                }
            default: {
                var userRoot = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

                MeshConfigurationDirectory = Path.Combine(userRoot, WindowsMeshDirectory);
                directoryKeys = Path.Combine(MeshConfigurationDirectory, KeysDirectory);
                break;
                }
            }
        }



    /// <summary>
    /// Return the service directory for storing Mesh data on the current platform.
    /// </summary>
    /// <param name="service">The service for which the directory is required.</param>
    /// <returns>The full directory path of the directory.</returns>
    public static string GetServiceDirectory(string service) {
        var platform = Environment.OSVersion.Platform;
        switch (platform) {
            case PlatformID.Win32NT: {
                var appsRoot = GetWindowsAppRoot();
                return Path.Combine(appsRoot, WindowsMeshDirectory, service);
                }
            default: {
                var userRoot = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                return Path.Combine(userRoot, LinuxMeshDirectory, service);
                }
            }
        }

    /// <summary>
    /// Constructor returning an instance. If not-null, <paramref name="directory"/>
    /// overrides the location of the key stores. This may be used in testing or to enable 
    /// a key store belonging to a different user to be mounted.
    /// </summary>
    /// <param name="directory">If not, null, specifies directory in which the </param>
    public KeyCollectionCore(string? directory = null) {
        if (directory != null) {
            SetPlatformDirect(directory);
            }
        }

    /// <summary>
    /// Set the platform directory to <paramref name="directory"/>. This is intended for 
    /// use in testing of for cases where an end user might override the directory.
    /// </summary>
    /// <param name="directory">The directory value to set.</param>
    public static void SetPlatformDirect(string directory) {
        directoryKeys = Path.Combine(directory, "Keys");
        }




    ///<inheritdoc/>
    public override void Persist(string udf, IPKIXPrivateKey privateKey, bool exportable) {
        var fileName = Path.Combine(DirectoryKeys, udf);

        // keys are persisted as plaintext for now.

        var joseKey = Key.Factory(privateKey);
        joseKey.Exportable = exportable;
        var plaintext = joseKey.ToJson(true);

        Directory.CreateDirectory(DirectoryKeys);
        fileName.WriteFileNew(plaintext);


        }
    ///<inheritdoc/>
    public override void Persist(string udf, IJson joseKey, bool exportable) {



        var fileName = Path.Combine(DirectoryKeys, udf);

        joseKey.Exportable = exportable;
        var plaintext = joseKey.ToJson(true);

        Directory.CreateDirectory(DirectoryKeys);
        fileName.WriteFileNew(plaintext);

        //Console.WriteLine($"Persist to {udf} : {plaintext.ToUTF8()}");
        }

    /// <summary>
    /// Erase the private key <paramref name="udf"/> from storage.
    /// </summary>
    /// <param name="udf">The key to erase.</param>
    public void ErasePrivateKey(string udf) {
        var fileName = Path.Combine(DirectoryKeys, udf);

        try {
            File.Delete(fileName);
            }
        catch {
            throw new KeyErasureFailed();
            }
        }

    ///<inheritdoc/>
    public override IJson LocatePrivateKey(string udf) {

        var fileName = Path.Combine(DirectoryKeys, udf);

        try {

            fileName.OpenReadToEnd(out var data);
            return Key.FromJson(data.JsonReader(), true);
            }
        catch {
            throw new PrivateKeyNotFound();
            }
        }

    ///<inheritdoc/>
    public override bool LocatePrivateKeyPair(string udf, out CryptoKey cryptoKey) {
        if (base.LocatePrivateKeyPair (udf, out cryptoKey)) {
            return true;
            }

        var fileName = Path.Combine(DirectoryKeys, udf);

        try {

            fileName.OpenReadToEnd(out var data);
            var key = Key.FromJson(data.JsonReader(), true);
            cryptoKey = key.GetKeyPair(key.Exportable == true ? KeySecurity.Exportable : KeySecurity.Bound, this);
            return true;
            }
        catch {
            return base.LocatePrivateKeyPair(udf, out cryptoKey);
            }
        }

    /// <summary>
    /// Validate the trust path specified in <paramref name="dareSignature"/> relative to the
    /// trust anchor <paramref name="anchor"/> and return the result.
    /// </summary>
    /// <param name="dareSignature">The signature to evaluate.</param>
    /// <param name="anchor">The trust anchor to evaluate relative to.</param>
    /// <returns>The trust result.</returns>
    public TrustResult ValidateTrustPath(DareSignature dareSignature, string? anchor = null) => throw new NotImplementedException();

    ///<inheritdoc/>
    public override KeyAgreementResult RemoteAgreement(string serviceAddress, KeyPairAdvanced ephemeral, string shareId) => throw new NotImplementedException();
    }



