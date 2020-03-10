~~~~
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Examples {

    class Examples {

        /// <summary>
        /// Combine a set of <paramref name="n"/> points (x, f(x))
        /// on a polynomial of degree <paramref name="n"/> in a 
        /// discrete field modulo prime <paramref name="p"/> to 
        /// recover the value f(0) using Lagrange basis polynomials.
        /// </summary>
        /// <param name="fx">The values f(x).</param>
        /// <param name="x">The values for x.</param>
        /// <param name="p">The modulus.</param>
        /// <param name="n">The polynomial degree.</param>
        /// <returns>The value f(0).</returns>
        static BigInteger CombineNK(
                    BigInteger[] fx,
                    int[] x,
                    BigInteger p,
                    int n) {
            if (fx.Length < n) {
                throw new Exception("Insufficient shares");
                }

            BigInteger accumulator = 0;
            for (var formula = 0; formula < n; formula++) {
                var value = fx[formula];

                BigInteger numerator = 1, denominator = 1;
                for (var count = 0; count < n; count++) {
                    if (formula == count) {
                        continue;  // If not the same value
                        }

                    var start = x[formula];
                    var next = x[count];

                    numerator = (numerator * -next) % p;
                    denominator = (denominator * (start - next)) % p;
                    }

                var InvDenominator = ModInverse(denominator, p);

                accumulator = Modulus((accumulator + 
                    (fx[formula] * numerator * InvDenominator)), p);
                }

            return accumulator;
            }

        /// <summary>
        /// Compute the modular multiplicative inverse of the value 
        /// <paramref name="k"/> modulo <paramref name="p"/>
        /// </summary>
        /// <param name="k">The value to find the inverse of</param>
        /// <param name="p">The modulus.</param>
        /// <returns></returns>
        static BigInteger ModInverse(
                    BigInteger k, 
                    BigInteger p) {
            var m2 = p - 2;
            if (k < 0) {
                k = k + p;
                }

            return BigInteger.ModPow(k, m2, p);
            }

        /// <summary>
        /// Calculate the modulus of a number with correct handling 
        /// for negative numbers.
        /// </summary>
        /// <param name="x">Value</param>
        /// <param name="p">The modulus.</param>
        /// <returns>x mod p</returns>
        public static BigInteger Modulus(
                    BigInteger x, 
                    BigInteger p) {
            var Result = x % p;
            return Result.Sign >= 0 ? Result : Result + p;
            }
        }
    }
~~~~
