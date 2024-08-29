


//using Goedel.Utilities;

//namespace Goedel.Cryptography.Nist;


///// <summary>
///// SHA factory using the .Net Core crypto providers.
///// </summary>
//public class Sha3Core : IShaFactory {

//    ///<inheritdoc/>
//    public ISha GetShaInstance(HashFunction hashFunction) =>
//        hashFunction switch {
//            { Mode: ModeValues.SHA3, DigestSize: DigestSizes.d256 } => throw new NYI(),
//            { Mode: ModeValues.SHA3, DigestSize: DigestSizes.d512 } => throw new NYI(),
//            _ => throw new NYI()
//            };

//    ///<inheritdoc/>
//    public IShake GetShakeInstance(HashFunction hashFunction) {
//        throw new NotImplementedException();
//        }

//    /////<inheritdoc/>
//    //public IShaMct GetShaMctInstance(HashFunction hashFunction, bool oddLength = false) {
//    //    throw new NotImplementedException();
//    //    }
//    }

//internal class Sha3_d256 : ISha {

//    public HashFunction HashFunction { get; } = 
//                    new HashFunction(ModeValues.SHA3, DigestSizes.d256);

//    private SHA3_256 Digest { get; set; } = SHA3_256.Create();


//    public Sha3_d256() {
//        }



//    public void Final(byte[] output, int outputBitLength = 0) {
//        Digest.TryHashFinal (output, outputBitLength);


//        throw new NotImplementedException();
//        }

//    //public HashResult HashLargeMessage(LargeBitString message) {
//    //    throw new NotImplementedException();
//    //    }

//    public HashResult HashMessage(BitString message, int outLen = 0) {
//        throw new NotImplementedException();
//        }

//    public HashResult HashNumber(BigInteger number) {
//        throw new NotImplementedException();
//        }

//    public void Init() {
//        if (Digest.CanReuseTransform) {
//            Digest.Initialize();
//            }
//        else {
//            Digest = SHA3_256.Create();
//            }
//        }

//    public void Update(byte[] message, int bitLength) {
//        throw new NotImplementedException();
//        }

//    public void Update(int message, int bitLength) {
//        throw new NotImplementedException();
//        }
//    }


