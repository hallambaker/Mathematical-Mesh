
namespace Goedel.Cryptography.Nist;

/// <summary>
/// Parameters used in ML-DSA
/// </summary>
public class DilithiumParameters {

    ///<summary>The parameter set.</summary> 
    public DilithiumParameterSet ParameterSet { get; }

    /// <summary>
    /// Modulus.
    /// Valid option is 8380417
    /// </summary>
    public int Q { get; }

    /// <summary>
    /// The number of dropped bits from t.
    /// Valid option is 13
    /// </summary>
    public int D { get; }

    /// <summary>
    /// Number of +- 1s in polynomial c.
    /// Valid options are 39, 49, 60
    /// </summary>
    public int Tau { get; }

    /// <summary>
    /// The collision strength of cTilde.
    /// Valid options are 128, 192, 256
    /// </summary>
    public int Lambda { get; }

    /// <summary>
    /// Coefficient range of y.
    /// Valid options are 2^17 or 2^19
    /// </summary>
    public int Gamma1 { get; }

    /// <summary>
    /// Low order rounding range.
    /// Valid options are based on Q, (Q - 1) / 88 or (Q - 1) / 32
    /// </summary>
    public int Gamma2 { get; }

    /// <summary>
    /// (K, L) are the dimensions of A.
    /// Valid options are 4, 6, 8
    /// </summary>
    public int K { get; }   // DO NOT ADD SET WITHOUT TESTING!

    /// <summary>
    /// (K, L) are the dimensions of A.
    /// Valid options are 4, 5, 7
    /// </summary>
    public int L { get; }   // DO NOT ADD SET WITHOUT TESTING!

    /// <summary>
    /// Private key range.
    /// Valid options are 2 or 4
    /// </summary>
    public int Eta { get; }

    /// <summary>
    /// Tau * Eta.
    /// Valid options are 78, 196, 120
    /// </summary>
    public int Beta { get; }

    /// <summary>
    /// The maximum number of 1s in hint h.
    /// Valid options are 80, 55, 75
    /// </summary>
    public int Omega { get; }

    ///<summary>The private key length.</summary> 
    public int PrivateKeyLength { get; set; }

    ///<summary>The public key length.</summary> 
    public int PublicKeyLength { get; set; }

    ///<summary>The length of a computed signature.</summary> 
    public int SignatureLength { get; set; }


    public const int PrivateKeyLength44 = 2560;
    public const int PublicKeyLength44 = 1312;
    public const int SignatureLength44 = 2420;


    public const int PrivateKeyLength65 = 4032;
    public const int PublicKeyLength65 = 1952;
    public const int SignatureLength65 = 3309;


    public const int PrivateKeyLength87 = 4896;
    public const int PublicKeyLength87 = 2592;
    public const int SignatureLength87 = 4627;


    public static DilithiumParameters ML_DSA_44 { get; } =
    new DilithiumParameters(DilithiumParameterSet.ML_DSA_44);

    public static DilithiumParameters ML_DSA_65 { get; } =
        new DilithiumParameters(DilithiumParameterSet.ML_DSA_65);

    public static DilithiumParameters ML_DSA_87 { get; } =
        new DilithiumParameters(DilithiumParameterSet.ML_DSA_87);


    /// <summary>
    /// Default constructor, create an instance for the parameters 
    /// <paramref name="param"/>.
    /// </summary>
    /// <param name="param">Specify the security level.</param>
    /// <exception cref="ArgumentException">Invalid parameter set specified.</exception>
    public DilithiumParameters(DilithiumParameterSet param) {
        ParameterSet = param;
        switch (param) {
            case DilithiumParameterSet.ML_DSA_44: {
                Q = 8380417;
                D = 13;
                Tau = 39;
                Lambda = 128;
                Gamma1 = 1 << 17;
                Gamma2 = 95232;
                K = 4;
                L = 4;
                Eta = 2;
                Beta = 78;
                Omega = 80;
                PrivateKeyLength = PrivateKeyLength44;
                PublicKeyLength = PublicKeyLength44;
                SignatureLength = SignatureLength44;
                break;
                }
            case DilithiumParameterSet.ML_DSA_65: {
                Q = 8380417;
                D = 13;
                Tau = 49;
                Lambda = 192;
                Gamma1 = 1 << 19;
                Gamma2 = 261888;
                K = 6;
                L = 5;
                Eta = 4;
                Beta = 196;
                Omega = 55;
                PrivateKeyLength = PrivateKeyLength65;
                PublicKeyLength = PublicKeyLength65;
                SignatureLength = SignatureLength65;
                break;
                }
            case DilithiumParameterSet.ML_DSA_87: {
                Q = 8380417;
                D = 13;
                Tau = 60;
                Lambda = 256;
                Gamma1 = 1 << 19;
                Gamma2 = 261888;
                K = 8;
                L = 7;
                Eta = 2;
                Beta = 120;
                Omega = 75;
                PrivateKeyLength = PrivateKeyLength87;
                PublicKeyLength = PublicKeyLength87;
                SignatureLength = SignatureLength87;
                break;
                }

            default: {
                throw new ArgumentException("Invalid parameter set provided");
                }
            }
        }
    }
