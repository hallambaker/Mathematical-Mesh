
namespace Goedel.Cryptography.Nist;

/// <summary>
/// Parameters used in ML-KEM
/// </summary>
public class KyberParameters {

    ///<summary>The parameter set.</summary> 
    public KyberParameterSet ParameterSet { get; }

    /// <summary>
    /// Constant. Only valid value is 256.
    /// </summary>
    public int N { get; }

    /// <summary>
    /// Modulus. Only valid value is 3329.
    /// </summary>
    public int Q { get; }

    /// <summary>
    /// Dimensions of A and vectors. Valid values are 2, 3, 4.
    /// </summary>
    public int K { get; }   // DO NOT ADD SET WITHOUT TESTING!

    /// <summary>
    /// Distribution for generating vectors. Valid values are 3, 2, 2.
    /// </summary>
    public int Eta1 { get; }

    /// <summary>
    /// Distribution for generating vectors. Only valid value is 2.
    /// </summary>
    public int Eta2 { get; }

    /// <summary>
    /// Parameters for functions. Valid values are 10, 10, 11.
    /// </summary>
    public int Du { get; }

    /// <summary>
    /// Parameters for functions. Valid values are 4, 4, 5.
    /// </summary>
    public int Dv { get; }

    /// <summary>
    /// Length in bytes of encapsulation key
    /// </summary>
    public int EncapsulationKeyLength { get; }

    /// <summary>
    /// Length in bytes of decapsulation key
    /// </summary>
    public int DecapsulationKeyLength { get; }

    /// <summary>
    /// Length in bytes of ciphertext
    /// </summary>
    public int CiphertextLength { get; }

    ///<summary>Kyber 512 parameters.</summary> 
    public static KyberParameters Kyber512 { get; } =
        new KyberParameters(KyberParameterSet.ML_KEM_512);

    ///<summary>Kyber 768 parameters.</summary> 
    public static KyberParameters Kyber768 { get; } =
        new KyberParameters(KyberParameterSet.ML_KEM_768);

    ///<summary>Kyber 1024 parameters</summary> 
    public static KyberParameters Kyber1024 { get; } =
        new KyberParameters(KyberParameterSet.ML_KEM_1024);

    ///<summary>Encapsulation key for ML-KEM-512</summary> 
    public const int EncapsulationKeyLength512 = 800;
    ///<summary>Decapsulation key for ML-KEM-512</summary> 
    public const int DecapsulationKeyLength512 = 1632;
    ///<summary>Ciphertext for ML-KEM-512</summary> 
    public const int CiphertextLength512 = 768;

    ///<summary>Encapsulation key for ML-KEM-768</summary> 
    public const int EncapsulationKeyLength768 = 1184;
    ///<summary>Decapsulation key for ML-KEM-768</summary> 
    public const int DecapsulationKeyLength768 = 2400;
    ///<summary>Ciphertext for ML-KEM-768</summary> 
    public const int CiphertextLength768 = 1088;

    ///<summary>Encapsulation key for ML-KEM-1024</summary> 
    public const int EncapsulationKeyLength1024 = 1568;
    ///<summary>Decapsulation key for ML-KEM-1024</summary> 
    public const int DecapsulationKeyLength1024 = 3168;
    ///<summary>Ciphertext for ML-KEM-1024</summary> 
    public const int CiphertextLength1024 = 1568;



    /// <summary>
    /// Default constructor, create an instance for the parameters 
    /// <paramref name="param"/>.
    /// </summary>
    /// <param name="param">Specify the security level.</param>
    /// <exception cref="ArgumentException">Invalid parameter set specified.</exception>
    public KyberParameters(KyberParameterSet param) {
        ParameterSet = param;

        switch (param) {
            case KyberParameterSet.ML_KEM_512:
            N = 256;
            Q = 3329;
            K = 2;
            Eta1 = 3;
            Eta2 = 2;
            Du = 10;
            Dv = 4;
            EncapsulationKeyLength = EncapsulationKeyLength512;
            DecapsulationKeyLength = DecapsulationKeyLength512;
            CiphertextLength = CiphertextLength512;
            break;

            case KyberParameterSet.ML_KEM_768:
            N = 256;
            Q = 3329;
            K = 3;
            Eta1 = 2;
            Eta2 = 2;
            Du = 10;
            Dv = 4;
            EncapsulationKeyLength = EncapsulationKeyLength768;
            DecapsulationKeyLength = DecapsulationKeyLength768;
            CiphertextLength = CiphertextLength768;
            break;

            case KyberParameterSet.ML_KEM_1024:
            N = 256;
            Q = 3329;
            K = 4;
            Eta1 = 2;
            Eta2 = 2;
            Du = 11;
            Dv = 5;
            EncapsulationKeyLength = EncapsulationKeyLength1024;
            DecapsulationKeyLength = DecapsulationKeyLength1024;
            CiphertextLength = CiphertextLength1024;
            break;

            default:
            throw new ArgumentException($"Invalid {nameof(KyberParameterSet)} provided");
            }
        }
    }
