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



// Todo: SSH Add support for SSH ECC Algorithms
// Todo: SSH Support for per device client keys
// Todo: SSH Create SSH root of trust for user
// Todo: SSH Collect host credentials, sign and book to service
// Todo: SSH Passphrase for PEM Private keys

namespace Goedel.Mesh;

/// <summary>
/// Profile describing a credential type.
/// </summary>
/// <param name="AlgorithmId">The default algorithm ID.</param>
/// <param name="KeyUses">The default key uses.</param>
/// <param name="KeySize">The default key size.</param>
public record CredentialProfile (
            CryptoAlgorithmId AlgorithmId,
            KeyUses KeyUses = KeyUses.Sign,
            int KeySize = 0
            ) {

    public virtual string Kind => "code";

    ///<summary>The platform served by the credential</summary> 
    public virtual string[] Platforms => ["Any"];

    ///<summary>PKIK credential profile.</summary> 
    public static CredentialProfilePkix Code { get; } = new CredentialProfilePkix(
            CryptoAlgorithmId.P384, KeyUses.Sign);

    ///<summary>Windows credential profile.</summary> 
    public static CredentialProfileWindows Windows { get; } = new CredentialProfileWindows(
                CryptoAlgorithmId.P384, KeyUses.Sign);

    ///<summary>Apple developer (ios and macOS) credential profile.</summary> 
    public static CredentialProfileApple Apple { get; } = new CredentialProfileApple(
                CryptoAlgorithmId.P384, KeyUses.Sign);

    ///<summary>Android credential profile.</summary> 
    public static CredentialProfileAndroid Android { get; } = new CredentialProfileAndroid(
                CryptoAlgorithmId.P384, KeyUses.Sign);

    ///<summary>Linux credential profile.</summary> 
    public static CredentialProfileLinux Linux { get; } = new CredentialProfileLinux(
                CryptoAlgorithmId.P384, KeyUses.Sign);

    ///<summary>Commit credential profile.</summary> 
    public static CredentialProfileCommit Commit { get; } = new CredentialProfileCommit(
                CryptoAlgorithmId.P384, KeyUses.Sign);
    }

/// <summary>
/// OpenPGP Credential Profile
/// </summary>
/// <param name="AlgorithmId">The default algorithm ID.</param>
/// <param name="KeyUses">The default key uses.</param>
/// <param name="KeySize">The default key size.</param>
public record CredentialProfileOpenPgp(
            CryptoAlgorithmId AlgorithmId,
            KeyUses KeyUses = KeyUses.Sign,
            int KeySize = 0
            ) : CredentialProfile (AlgorithmId, KeyUses, KeySize) {

    ///<inheritdoc/>
    public override string[] Platforms => ["OpenPGP"];
    }

/// <summary>
/// Commit Credential Profile
/// </summary>
/// <param name="AlgorithmId">The default algorithm ID.</param>
/// <param name="KeyUses">The default key uses.</param>
/// <param name="KeySize">The default key size.</param>
public record CredentialProfileCommit(
            CryptoAlgorithmId AlgorithmId,
            KeyUses KeyUses = KeyUses.Sign,
            int KeySize = 0
            ) : CredentialProfileOpenPgp(AlgorithmId, KeyUses, KeySize) {

    ///<inheritdoc/>
    public override string Kind => "commit";

    ///<inheritdoc/>
    public override string[] Platforms => null;
    }

/// <summary>
/// Pkix Credential Profile
/// </summary>
/// <param name="AlgorithmId">The default algorithm ID.</param>
/// <param name="KeyUses">The default key uses.</param>
/// <param name="KeySize">The default key size.</param>
public record CredentialProfilePkix(
            CryptoAlgorithmId AlgorithmId,
            KeyUses KeyUses = KeyUses.Sign,
            int KeySize = 0
            ) : CredentialProfile(AlgorithmId, KeyUses, KeySize) {

    ///<inheritdoc/>
    public override string[] Platforms => ["Pkix"];
    }

/// <summary>
/// Windows Credential Profile
/// </summary>
/// <param name="AlgorithmId">The default algorithm ID.</param>
/// <param name="KeyUses">The default key uses.</param>
/// <param name="KeySize">The default key size.</param>
public record CredentialProfileWindows(
            CryptoAlgorithmId AlgorithmId,
            KeyUses KeyUses = KeyUses.Sign,
            int KeySize = 0
            ) : CredentialProfilePkix(AlgorithmId, KeyUses, KeySize) {

    ///<inheritdoc/>
    public override string[] Platforms => ["Windows"];
    }

/// <summary>
/// Apple Credential Profile
/// </summary>
/// <param name="AlgorithmId">The default algorithm ID.</param>
/// <param name="KeyUses">The default key uses.</param>
/// <param name="KeySize">The default key size.</param>
public record CredentialProfileApple(
            CryptoAlgorithmId AlgorithmId,
            KeyUses KeyUses = KeyUses.Sign,
            int KeySize = 0
            ) : CredentialProfilePkix(AlgorithmId, KeyUses, KeySize) {

    ///<inheritdoc/>
    public override string[] Platforms => ["Apple"];
    }

/// <summary>
/// Android Credential Profile
/// </summary>
/// <param name="AlgorithmId">The default algorithm ID.</param>
/// <param name="KeyUses">The default key uses.</param>
/// <param name="KeySize">The default key size.</param>
public record CredentialProfileAndroid(
            CryptoAlgorithmId AlgorithmId,
            KeyUses KeyUses = KeyUses.Sign,
            int KeySize = 0
            ) : CredentialProfilePkix(AlgorithmId, KeyUses, KeySize) {

    ///<inheritdoc/>
    public override string[] Platforms => ["Android"];
    }

/// <summary>
/// Linux Credential Profile
/// </summary>
/// <param name="AlgorithmId">The default algorithm ID.</param>
/// <param name="KeyUses">The default key uses.</param>
/// <param name="KeySize">The default key size.</param>
public record CredentialProfileLinux(
            CryptoAlgorithmId AlgorithmId,
            KeyUses KeyUses = KeyUses.Sign,
            int KeySize = 0
            ) : CredentialProfilePkix(AlgorithmId, KeyUses, KeySize) {

    ///<inheritdoc/>
    public override string[] Platforms => ["Linux"];
    }
