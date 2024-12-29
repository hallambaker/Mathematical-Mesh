namespace Goedel.Cryptography.Nist;

/// <summary>
/// Random number generation.
/// </summary>
public class Random800_90 : IRandom800_90 {

    private static readonly RandomNumberGenerator Global = RandomNumberGenerator.Create();
    [ThreadStatic] private static Random _local;

    //private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

    private static Random Randy {
        get {
            if (_local != null) {
                //Logger.Debug("Request for random, reusing instance on thread.");
                return _local;
                }
            //Logger.Debug("Request for random, has not been used on thread, create.");
            var buffer = new byte[4];
            Global.GetBytes(buffer);
            _local = new Random(
                BitConverter.ToInt32(buffer, 0));

            return _local;
            }
        }

    ///<inheritdoc/>
    public BigInteger GetRandomBigInteger(BigInteger maxInclusive) {
        byte[] bytes = maxInclusive.ToByteArray();
        BigInteger R;


        do {
            Randy.NextBytes(bytes);
            bytes[bytes.Length - 1] &= (byte)0x7F; //force sign bit to positive
            R = new BigInteger(bytes);
            } while (R > maxInclusive);

        return R;
        }

    }

