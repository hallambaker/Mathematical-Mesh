=To Do

==Audit 32 / 64 bit lengths throughout

==Audit generation of keys for encryption algorithms, etc.

==Implement incremental processing



==PKIX

Can't create a certificate from binary data - used the short cut of using the 
platform parser!


   x_1 = u
   x_2 = 1
   z_2 = 0
   x_3 = u
   z_3 = 1
   swap = 0

   For t = bits-1 down to 0:
       k_t = (k >> t) & 1
       swap ^= k_t
       // Conditional swap; see text below.
       (x_2, x_3) = cswap(swap, x_2, x_3)
       (z_2, z_3) = cswap(swap, z_2, z_3)
       swap = k_t

       A = x_2 + z_2
       AA = A^2
       B = x_2 - z_2
       BB = B^2
       E = AA - BB
       C = x_3 + z_3
       D = x_3 - z_3
       DA = D * A
       CB = C * B
       x_3 = (DA + CB)^2
       z_3 = x_1 * (DA - CB)^2
       x_2 = AA * BB
       z_2 = E * (AA + a24 * E)





x_p = u
y_p = v

x_q = x_2
z_q = z_2




B = x_p * z_2                   // v1
C = x_2 + B                     // v2
D = X_2 - B                     // v3
DD = D^2                        // v3
E = DD * X_3                    // v3
F = 2 * A * z_2                 // v1

G = C + F                       // v2
H = (x_p * x_2)  + z_2          // v4
J = G * H                       // v2
K = F * z_2                     // v1

yy_2 = (J - K) * z_3 - E        // Y'
N = 2 * y_p * z_2  * z_3        // v1
xx_2 = N * x_q                  // X'
zz_2 = N * z_ q                 // Z'

ZINV = zz_2^(p - 2)
u2 = xx_2 * ZINV
v2 = yy_2 * ZINV

return u2, v2



B = v2 - v1
C = u2 - u1
CINV = C^(p - 2)
D = B * CINV
DD = D * D
E = B * CINV
EEE = E^3

u3 = DD - A - u1 - u2
v3 = ((2u1 + u2 + A) * B * CINV) - EEE - v1




----------Double

xx = x * x
yinv2 = (y+ y)^(p - 2)

l = (3*xx + 2 * A * x +1) * yinv2
ll = l * l
lll = ll * l

x_out = ll - A - x - x
y_out = (x + x + x + A) * l - lll -y 
