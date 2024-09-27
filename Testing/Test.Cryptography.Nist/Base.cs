using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Nist;
using Goedel.Mesh.Test;

using System;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace Goedel.XUnit;

/// <summary>
/// Test library for PQC algorithms.
/// </summary>
public class TestNist : Disposable {

    public string ACVP_Root => Path.Combine(TestEnvironmentBase.CommonData,
                "NIST.Test.Vectors");

    public string KemKeyGen => Path.Combine(ACVP_Root, "ML-KEM-keyGen-FIPS203");
    public string KemEncapDecap => Path.Combine(ACVP_Root, "ML-KEM-encapDecap-FIPS203");
    public string DsaKeyGen => Path.Combine(ACVP_Root, "ML-DSA-keyGen-FIPS204");
    public string DsaSign => Path.Combine(ACVP_Root, "ML-DSA-sigGen-FIPS204");
    public string DsaVerify => Path.Combine(ACVP_Root, "ML-DSA-sigVer-FIPS204");



    // ECDSA vectors
    public string EcDsaKeyGen => Path.Combine(ACVP_Root, "ECDSA-KeyGen-FIPS186-5");
    public string EcDsaKeyVer => Path.Combine(ACVP_Root, "ECDSA-KeyVer-FIPS186-5");
    public string EcDsaSign => Path.Combine(ACVP_Root, "ECDSA-SigGen-FIPS186-5");
    public string EcDsaVerify => Path.Combine(ACVP_Root, "ECDSA-SigVer-FIPS186-5");

    // ECDH vectors
    //public string EcDsaKeyGen => Path.Combine(ACVP_Root, "ECDSA-KeyGen-FIPS186-5");




    /// <summary>
    /// Static constructor, put initializations here.
    /// </summary>
    static TestNist() {
        }


    /// <summary>
    /// Create method, return an instance.
    /// </summary>
    /// <returns>The instance</returns>
    public static TestNist Test() => new();


    [Fact]
    public void TestKemKeyGen() {

        var testBinding = new AcvpTestBinding<KemKeyGenTest>(KemKeyGen);
        foreach (var test in testBinding.Tests) {
            test.Value.Test();
            }

        }

    [Fact]
    public void TestKemEncapDecap() {


        var testBinding = new AcvpTestBinding<KemEncapDecapTest>(KemEncapDecap);
        foreach (var test in testBinding.Tests) {
            test.Value.Test();
            }



        }


    [Fact]
    public void TestDsaKeyGen() {


        var testBinding = new AcvpTestBinding<DsaKeyGenTest>(DsaKeyGen);
        foreach (var test in testBinding.Tests) {
            test.Value.Test();
            }



        }

    [Fact]
    public void TestDsaSign() {


        var testBinding = new AcvpTestBinding<DsaSignTest>(DsaSign);
        foreach (var test in testBinding.Tests) {
            test.Value.Test();
            }



        }

    [Fact]
    public void TestDsaVerify() {


        var testBinding = new AcvpTestBinding<DsaVerifyTest>(DsaVerify);
        foreach (var test in testBinding.Tests) {
            test.Value.Test();
            }



        }


    }



