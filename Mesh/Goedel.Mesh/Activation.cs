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

public partial class Activation {
    #region // Properties


    ///<summary>The <see cref="ProfileDevice"/> that this activation activates.</summary>
    public ProfileDevice ProfileDevice { get; set; }


    ///<summary>The connection value.</summary>
    public virtual Connection Connection => throw new NYI();

    ///<summary>The activation seed key.</summary> 
    public PrivateKeyUDF ActivationSeed { get; set; }
    #endregion
    #region // Constructors
    /// <summary>
    /// Base constructor.
    /// </summary>
    public Activation() {
        }


    /// <summary>
    /// Constructor creating a new <see cref="Activation"/> for a profile of type
    /// <paramref name="profile"/>. The property <see cref="ActivationSeed"/> is
    /// calculated from the values <paramref name="udfAlgorithmIdentifier"/>. 
    /// If the value <paramref name="masterSecret"/> is
    /// specified, it is used as the seed value. Otherwise, a seed value of
    /// length <paramref name="bits"/> is generated.
    /// </summary>
    /// <param name="profile">The base profile that the activation activates.</param>
    /// <param name="udfAlgorithmIdentifier">The UDF key derivation specifier.</param>
    /// <param name="masterSecret">If not null, specifies the seed value. Otherwise,
    /// a seed value of <paramref name="bits"/> length is generated.</param>
    /// <param name="bits">The size of the seed to be generated if 
    /// <paramref name="masterSecret"/> is null.</param>
    protected Activation(
            Profile profile,
            UdfAlgorithmIdentifier udfAlgorithmIdentifier,
            byte[] masterSecret = null,
            int bits = 256) {
        (var actor, var keytype) = udfAlgorithmIdentifier.GetMeshKeyType();
        ActivationKey = Cryptography.Udf.DerivedKey(udfAlgorithmIdentifier, data: masterSecret, bits);
        ActivationSeed = new PrivateKeyUDF(ActivationKey);
        //ProfileSignature = ActivationSeed.ActivatePublic(
        //        profile.ProfileSignature.GetKeyPairAdvanced(), actor, MeshKeyOperation.Profile);

        }
    #endregion
    }
