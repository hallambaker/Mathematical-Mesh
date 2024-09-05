# Notes on the PQC algorithms

## Kyber

### Key generation


'gen_matrix'

The corner case ctr < 256 does not always trigger. This creates a real risk that test 
vectors do not provide coverage for this particular code path which has some non-trivial
implementation issues.


kem.c//crypto_kem_keypair


What on earth is the point of this code. All it does is to always append a random value
to the buffer.

  /* Value z for pseudo-random output on reject */
  randombytes(sk+KYBER_SECRETKEYBYTES-KYBER_SYMBYTES, KYBER_SYMBYTES);