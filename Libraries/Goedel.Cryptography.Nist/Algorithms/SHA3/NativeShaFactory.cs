namespace Goedel.Cryptography.Nist;


/// <summary>
/// Digest factory using the NIST code.
/// </summary>
public class NativeShaFactory : IShaFactory {

    ///<summary>Static instance of this class.</summary> 
    public static IShaFactory Factory = new NativeShaFactory();

    ///<inheritdoc/>
    public ISha GetShaInstance(HashFunction hashFunction) {
        switch (hashFunction.Mode) {

            case ModeValues.SHA3:
            return hashFunction.DigestSize switch {
                DigestSizes.d256 => new NativeFastSha3(256),
                DigestSizes.d384 => new NativeFastSha3(384),
                DigestSizes.d512 => new NativeFastSha3(512),
                _ => throw new ArgumentException($"{nameof(hashFunction)}")
                };

            case ModeValues.SHAKE:
            return hashFunction.DigestSize switch {
                DigestSizes.d128 => new NativeFastShake(128),
                DigestSizes.d256 => new NativeFastShake(256),
                _ => throw new ArgumentException($"{nameof(hashFunction)}")
                };

            default:
            throw new ArgumentException($"{nameof(hashFunction)}");
            }
        }

    ///<inheritdoc/>
    public IShake GetShakeInstance(HashFunction hashFunction) {
        return hashFunction.Mode switch {
            ModeValues.SHAKE => hashFunction.DigestSize switch {
                DigestSizes.d128 => new NativeFastShake(128),
                DigestSizes.d256 => new NativeFastShake(256),
                _ => throw new ArgumentException("Invalid SHAKE")
                },
            _ => throw new ArgumentException("Invalid SHAKE")
            };
        }
    }

