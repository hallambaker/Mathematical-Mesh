# Notes on the PQC algorithms

## Kyber

### Key generation


'gen_matrix'

The corner case ctr < 256 does not always trigger. This creates a real risk that test 
vectors do not provide coverage for this particular code path which has some non-trivial
implementation issues.


