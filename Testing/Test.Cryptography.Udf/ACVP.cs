using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Nist;
using Goedel.Cryptography.PQC;

using System;
using System.Collections;
using System.Security.Cryptography;

namespace Goedel.Test;





public class UdfKeyGenTest : AcvpTest {

    public string? SeedUdf { get; set; }

    public byte[]? KeyUdf { get; set; }

    public string? KeyUdfString { get; set; }

    public string? KeyAlgorithm { get; set; }



    public UdfKeyGenTest() {
        }

    public UdfKeyGenTest (
                    int testId, 
                    UdfAlgorithmIdentifier udfAlgorithm,
                    int size = 256) {
        var data = SHAKE256.Process($"This is a common test seed of {testId}".ToBytes(), size);
        
        SeedUdf = Udf.DerivedKey(udfAlgorithm, data);
        var keypair = Udf.DeriveKey(SeedUdf);
        KeyUdf = keypair.UDFBytes;
        KeyUdfString = keypair.UDFValue;
        KeyAlgorithm = keypair.CryptoAlgorithmId.ToJoseID();

        TestData = new AcvpTestItem() {
            TcId = testId,
            };

        Bind(TestData, "seedUdf", this.SeedUdf);
        Bind(TestData, "keyUdf", KeyUdf);
        Bind(TestData, "keyUdfValue", KeyUdfString);
        Bind(TestData, "keyalg", KeyAlgorithm);


        }


    public override void Populate(AcvpTestGroup group, AcvpTestItem test) {
        base.Populate(group, test);
        SeedUdf = BindString(test, "seedUdf");
        KeyUdf = BindBinary(test, "keyUdf");
        KeyUdfString = BindString(test, "keyUdfValue");
        KeyAlgorithm = BindString(test, "keyalg");

        }


    public override void Test() {
        var keypair = Udf.DeriveKey(SeedUdf);

        keypair.UDFBytes.TestEqual(KeyUdf);
        keypair.UDFValue.TestEqual(KeyUdfString);
        keypair.CryptoAlgorithmId.ToJoseID().TestEqual(KeyAlgorithm);
        }



    }


