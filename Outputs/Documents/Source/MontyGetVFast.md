~~~~
x_p = u
y_p = v

B = x_p * z_2    //v1
C = x_2 + B      //v2
D = X_2 - B      //v3
DD = D^2         //v3
E = DD. X_3      //v3
F = 2 * A * z_2  //v1

G = C + F        //v2
H = x_p * x_2    //v4
I = H + z_2      //v4
J = G * I        //v2
K = F * z_2      //v1
L = J - K        //v2
M = L * z_3      //v2

yy_2 = M - E     //Y'
N = 2 * y_p      //v1
O = N * z_2      //v1
P = O * z_3      //v1
xx_2 = P * x_q   //X'
zz_2 = P * z_ q  //Z'

ZINV = (zz_2^(p - 2))
u2 = xx_2 * ZINV
v2 = yy_2 * ZINV

return u2, v2
~~~~