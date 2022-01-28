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


namespace Goedel.Cryptography.Core;



/// <summary>
/// KeyCollection implementation using platform agnostic .NET 5.0 
/// </summary>
public class KeyCollectionCore : KeyCollection, IKeyCollection {
    const string WindowsMeshKeys = @"Mesh\Keys";
    const string WindowsMeshProfiles = @"Mesh\Profiles";
    const string LinuxMeshKeys = @".Mesh/Keys";
    const string LinuxMeshProfiles = @".Mesh/Profiles";

    static string _DirectoryKeys;
    static string _DirectoryMesh;

    ///<summary>Directory in which to store keys</summary> 
    public virtual string DirectoryKeys => _DirectoryKeys;

    ///<summary>Directory in which to store Mesh application data.</summary> 
    public virtual string DirectoryMesh => _DirectoryMesh;
    //</summary>    @"~\.Mesh\Keys\";


    static KeyCollectionCore() {

        var platform = Environment.OSVersion.Platform;

        switch (platform) {
            case PlatformID.Unix: {
                    SetPlatformUnix();
                    break;
                    }
            case PlatformID.Win32NT: {
                    SetPlatformWindows();
                    break;
                    }
            case PlatformID.MacOSX: {
                    SetPlatformUnix();
                    break;
                    }

            case PlatformID.Win32S:
                break;
            case PlatformID.Win32Windows:
                break;
            case PlatformID.WinCE:
                break;
            case PlatformID.Xbox:
                break;
            default:
                break;
            }


        }

    public KeyCollectionCore(string directory = null) {
        if (directory != null) {
            SetPlatformDirect(directory);
            }
        }


    static void SetPlatformDirect(string directory) {
        _DirectoryKeys = Path.Combine(directory, "Keys");
        _DirectoryMesh = Path.Combine(directory, "Profiles");
        }


    static void SetPlatformWindows() {
        var appsRoot = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        _DirectoryKeys = Path.Combine(appsRoot, WindowsMeshKeys);
        _DirectoryMesh = Path.Combine(appsRoot, WindowsMeshProfiles);
        }

    static void SetPlatformUnix() {
        var userRoot = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        _DirectoryKeys = Path.Combine(userRoot, LinuxMeshKeys);
        _DirectoryMesh = Path.Combine(userRoot, LinuxMeshProfiles);
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

        var fileName = Path.Combine(DirectoryKeys, udf);

        try {

            fileName.OpenReadToEnd(out var data);
            var key = Key.FromJson(data.JsonReader(), true);
            cryptoKey = key.GetKeyPair(key.Exportable ? KeySecurity.Exportable : KeySecurity.Bound, this);
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
    public TrustResult ValidateTrustPath(DareSignature dareSignature, string anchor = null) => throw new NotImplementedException();

    ///<inheritdoc/>
    public override KeyAgreementResult RemoteAgreement(string serviceAddress, KeyPairAdvanced ephemeral, string shareId) => throw new NotImplementedException();
    }



