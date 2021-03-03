//  Copyright © 2021 by Threshold Secrets Llc.
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.

using Goedel.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Goedel.Cryptography.Algorithms {
    public class AESCFB {

        /*
         Function name:
     HASH
   Input:
     K, string of KEYLEN bits                      // Key
     A, string of any length                       // Associated data
   Output:
     Sum, string of 128 bits                       // Hash result

   Sum is defined as follows.

     //
     // Key-dependent variables
     //
     L_* = ENCIPHER(K, zeros(128))
     L_$ = double(L_*)
     L_0 = double(L_$)
     L_i = double(L_{i-1}) for every integer i > 0

     //
     // Consider A as a sequence of 128-bit blocks
     //
     Let m be the largest integer so that 128m <= bitlen(A)
     Let A_1, A_2, ..., A_m and A_* be strings so that
       A == A_1 || A_2 || ... || A_m || A_*, and
       bitlen(A_i) == 128 for each 1 <= i <= m.
       Note: A_* may possibly be the empty string.

     //
     // Process any whole blocks
     //
     Sum_0 = zeros(128)
     Offset_0 = zeros(128)
     for each 1 <= i <= m
        Offset_i = Offset_{i-1} xor L_{ntz(i)}
        Sum_i = Sum_{i-1} xor ENCIPHER(K, A_i xor Offset_i)
     end for

     //
     // Process any final partial block; compute final hash value
     //
     if bitlen(A_*) > 0 then
        Offset_* = Offset_m xor L_*
        CipherInput = (A_* || 1 || zeros(127-bitlen(A_*))) xor Offset_*
        Sum = Sum_m xor ENCIPHER(K, CipherInput)
     else
        Sum = Sum_m
     end if




Krovetz & Rogaway             Informational                     [Page 7]

RFC 7253              OCB Authenticated Encryption              May 2014


4.2.  Encryption: OCB-ENCRYPT

   This function computes a ciphertext (which includes a bundled
   authentication tag) when given a plaintext, associated data, nonce,
   and key.  For each invocation of OCB-ENCRYPT using the same key K,
   the value of the nonce input N must be distinct.

   Function name:
     OCB-ENCRYPT
   Input:
     K, string of KEYLEN bits                      // Key
     N, string of no more than 120 bits            // Nonce
     A, string of any length                       // Associated data
     P, string of any length                       // Plaintext
   Output:
     C, string of length bitlen(P) + TAGLEN bits   // Ciphertext

   C is defined as follows.

     //
     // Key-dependent variables
     //
     L_* = ENCIPHER(K, zeros(128))
     L_$ = double(L_*)
     L_0 = double(L_$)
     L_i = double(L_{i-1}) for every integer i > 0

     //
     // Consider P as a sequence of 128-bit blocks
     //
     Let m be the largest integer so that 128m <= bitlen(P)
     Let P_1, P_2, ..., P_m and P_* be strings so that
       P == P_1 || P_2 || ... || P_m || P_*, and
       bitlen(P_i) == 128 for each 1 <= i <= m.
       Note: P_* may possibly be the empty string.

     //
     // Nonce-dependent and per-encryption variables
     //
     Nonce = num2str(TAGLEN mod 128,7) || zeros(120-bitlen(N)) || 1 || N
     bottom = str2num(Nonce[123..128])
     Ktop = ENCIPHER(K, Nonce[1..122] || zeros(6))
     Stretch = Ktop || (Ktop[1..64] xor Ktop[9..72])
     Offset_0 = Stretch[1+bottom..128+bottom]
     Checksum_0 = zeros(128)

     //
     // Process any whole blocks
     //
     for each 1 <= i <= m
        Offset_i = Offset_{i-1} xor L_{ntz(i)}
        C_i = Offset_i xor ENCIPHER(K, P_i xor Offset_i)
        Checksum_i = Checksum_{i-1} xor P_i
     end for

     //
     // Process any final partial block and compute raw tag
     //
     if bitlen(P_*) > 0 then
        Offset_* = Offset_m xor L_*
        Pad = ENCIPHER(K, Offset_*)
        C_* = P_* xor Pad[1..bitlen(P_*)]
        Checksum_* = Checksum_m xor (P_* || 1 || zeros(127-bitlen(P_*)))
        Tag = ENCIPHER(K, Checksum_* xor Offset_* xor L_$) xor HASH(K,A)
     else
        C_* = <empty string>
        Tag = ENCIPHER(K, Checksum_m xor Offset_m xor L_$) xor HASH(K,A)
     end if

     //
     // Assemble ciphertext
     //
     C = C_1 || C_2 || ... || C_m || C_* || Tag[1..TAGLEN]
         */



        }
    }
