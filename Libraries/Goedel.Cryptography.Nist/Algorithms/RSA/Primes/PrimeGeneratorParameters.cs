
namespace Goedel.Cryptography.Nist;

/// <summary>
/// Parameters for NIST prime generation.
/// </summary>
public record PrimeGeneratorParameters {

    ///<summary>Static parameter set for 2048 bit keys</summary> 
    public static PrimeGeneratorParameters RSA2048 { get; } = new PrimeGeneratorParameters() {
        Modulus = 2048,
        PublicE = 65537,
        BitLens = [140, 140, 140, 140],
        PrimeTestK = 32
        };

    ///<summary>Static parameter set for 3072 bit keys</summary> 
    public static PrimeGeneratorParameters RSA3072 { get; } = new PrimeGeneratorParameters() {
        Modulus = 3072,
        PublicE = 65537,
        BitLens = [170, 170, 170, 170],
        PrimeTestK = 27
        };

    ///<summary>Static parameter set for 4096 bit keys</summary> 
    public static PrimeGeneratorParameters RSA4096 { get; } = new PrimeGeneratorParameters() {
        Modulus = 4096,
        PublicE = 65537,
        BitLens = [200, 200, 200, 200],
        PrimeTestK = 22
        };


    /// <summary>
    /// Return parameters for a key of size <paramref name="keySize"/>
    /// </summary>
    /// <param name="keySize">The key size. MUST be 2048, 2096 or 4096 bits.</param>
    /// <returns></returns>
    /// <exception cref="CryptographicException"></exception>
    public static PrimeGeneratorParameters GetPrimeGeneratorParameters(int keySize) =>
        keySize switch {
            2048 => RSA2048,
            3072 => RSA3072,
            4096 => RSA4096,
            _ => throw new CryptographicException()
            };

    // Required

    ///<summary>RSA modulus.</summary> 
    public int Modulus { get; set; }

    ///<summary>The public exponent, almost always 65537</summary> 
    public BigInteger PublicE { get; set; }

    ///<summary>To be deleted</summary> 
    public BitString Seed { get; set; }

    ///<summary>Specify the minimum length of probable auxiliary primes p1, p2 etc.</summary> 
    public int[] BitLens { get; set; } = new int[4]; 

    ///<summary>The prime test K parameter.</summary> 
    public int PrimeTestK { get; set; }


    ///<summary>Optional filter for probable primes</summary> 
    public int A { get; set; }              

    ///<summary>Optional filter for probable primes</summary> 
    public int B { get; set; }         
    }

