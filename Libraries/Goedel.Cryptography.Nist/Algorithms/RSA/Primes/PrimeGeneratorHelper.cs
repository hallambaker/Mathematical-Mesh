
using System.Reflection;

namespace Goedel.Cryptography.Nist;

public static class PrimeGeneratorHelper {
    private static readonly BigInteger Root2Mult2Pow1024Minus1 = new BitString("B504F333F9DE6484597D89B3754ABE9F1D6F60BA893BA84CED17AC85833399154AFC83043AB8A2C3A8B1FE6FDC83DB390F74A85E439C7B4A780487363DFA2768D2202E8742AF1F4E53059C6011BC337BCAB1BC911688458A460ABC722F7C4E33C6D5A8A38BB7E9DCCB2A634331F3C84DF52F120F836E582EEAA4A0899040CA4A").ToPositiveBigInteger();
    private static readonly BigInteger Root2Mult2Pow1536Minus1 = new BitString("B504F333F9DE6484597D89B3754ABE9F1D6F60BA893BA84CED17AC85833399154AFC83043AB8A2C3A8B1FE6FDC83DB390F74A85E439C7B4A780487363DFA2768D2202E8742AF1F4E53059C6011BC337BCAB1BC911688458A460ABC722F7C4E33C6D5A8A38BB7E9DCCB2A634331F3C84DF52F120F836E582EEAA4A0899040CA4A81394AB6D8FD0EFDF4D3A02CEBC93E0C4264DABCD528B651B8CF341B6F8236C70104DC01FE32352F332A5E9F7BDA1EBFF6A1BE3FCA221307DEA06241F7AA81C2").ToPositiveBigInteger();
    private static readonly BigInteger Root2Mult2Pow2048Minus1 = new BitString("B504F333F9DE6484597D89B3754ABE9F1D6F60BA893BA84CED17AC85833399154AFC83043AB8A2C3A8B1FE6FDC83DB390F74A85E439C7B4A780487363DFA2768D2202E8742AF1F4E53059C6011BC337BCAB1BC911688458A460ABC722F7C4E33C6D5A8A38BB7E9DCCB2A634331F3C84DF52F120F836E582EEAA4A0899040CA4A81394AB6D8FD0EFDF4D3A02CEBC93E0C4264DABCD528B651B8CF341B6F8236C70104DC01FE32352F332A5E9F7BDA1EBFF6A1BE3FCA221307DEA06241F7AA81C2C1FCBDDEA2F7DC3318838A2EAFF5F3B2D24F4A763FACB882FDFE170FD3B1F780F9ACCE41797F2805C246785E929570235FCF8F7BCA3EA33B4D7C60A5E633E3E1").ToPositiveBigInteger();


    /// <summary>
    /// C.9 Compute a Probable Prime Factor Based on Auxiliary Primes
    /// </summary>
    /// <param name="r1"></param>
    /// <param name="r2"></param>
    /// <param name="nLen"></param>
    /// <param name="e"></param>
    /// <returns></returns>
    public static PpfResult ProbablePrimeFactor(
                IPrimeGenerator entropyProvider,
                int pBound,
                int c,
                BigInteger r1,
                BigInteger r2,
                int nLen,
                BigInteger e, 
                string tag,
                int? primeSeed,
                int? primeTest) {

        BigInteger lowerBound, upperBound;
        upperBound = NumberTheory.Pow2(nLen / 2) - 1;

        var iterations = nLen switch {
            2048 => 32,
            3072 => 27,
            4096 => 22,
            _ => throw new CryptographicException()
            };

        lowerBound = nLen switch {
            2048 => Root2Mult2Pow1024Minus1,
            3072 => Root2Mult2Pow1536Minus1,
            4096 => Root2Mult2Pow2048Minus1,
            _ => throw new CryptographicException()
            };

        // 1
        if (NumberTheory.GCD(2 * r1, r2) != 1) {
            throw new CryptographicException();
            }

        // 2 and ensure R is positive
        var Rfirst = r2.ModularInverse(2 * r1) * r2;
        var Rsecond = (2 * r1).ModularInverse(r2) * 2 * r1;

        BigInteger R;

        var tag2 = tag + tag;
        do {
            if (Rfirst < Rsecond) {
                Rfirst += (2 * r1 * r2);
                }
            R = Rfirst - Rsecond;
            } while (Rfirst < Rsecond);

        while (true) {
            var modulo = 2 * r1 * r2;

            BigInteger x, y;
            int i;

            do {
                // 3
                x = entropyProvider.GetEntropy(lowerBound, upperBound, tag2, primeSeed);

                // 4
                y = x + (R - x).PosMod(modulo);


                // 4.1 (FIPS 186-5)
                if (c != 0) {
                    // This ends after a maximum of 4 iterations
                    while (y % 8 != c) {
                        y += modulo;
                        }
                    }

                // 5
                i = 0;

                // 6
                } while (y >= NumberTheory.Pow2(nLen / 2));

            var yBase = y;
            int offset = (int)(primeTest is null ? 0 : primeTest);
            y += offset * modulo;
            do {

                y.AssertEqual(yBase + (modulo * offset), CryptographicException.Throw);

                // 7
                if (NumberTheory.GCD(y - 1, e) == 1) {
                    if (NumberTheory.MillerRabin(y, iterations)) {

                        //Console.WriteLine($"Modulo {tag}, {offset}");
                        entropyProvider.Register(tag, offset);
                        return new PpfResult(y, x);
                        }


                    //if (MillerRabin(primeTestMode, nLen, y, true)) {
                    //    return new PpfResult(y, x);
                    //    }
                    }
                if (primeTest is not null) {
                    throw new CryptographicException();
                    }


                // 8
                i++;

                // 9
                if (i >= pBound * (nLen / 2)) {
                    throw new CryptographicException();

                    //return new PpfResult("Failed to Compute a Probable Prime Factor Based on Aux Primes at FIPS 186-5 B.9/FIPS 186-4 C.9 Step 9 (i>=X*(nlen/2)).");
                    }

                // 10
                if (c == 0) {
                    offset++;

                    y += modulo;
                    }
                else {
                    offset+=4;

                    y += modulo * 4;
                    }


                // 6 (repeated)
                } while (y < NumberTheory.Pow2(nLen / 2));
            }
        }



    }

