
import hashlib
import os

import binascii



def munge_string(s, pos, change):
    return (s[:pos] +
            int.to_bytes(s[pos] ^ change, 1, "little") +
            s[pos+1:])

# Read a file in the format of
# http://ed25519.cr.yp.to/python/sign.input
#lineno = 0
#while True:
#    line = sys.stdin.readline()
#    if not line:
#        break
#    lineno = lineno + 1
#    print(lineno)
#    fields = line.split(":")
#    secret = (binascii.unhexlify(fields[0]))[:32]
#    public = binascii.unhexlify(fields[1])
#    msg = binascii.unhexlify(fields[2])
#    signature = binascii.unhexlify(fields[3])[:64]

 #   privkey,pubkey = Ed25519.keygen(secret)
 #   assert public == pubkey
 #   assert signature == Ed25519.sign(privkey, pubkey, msg)
 #   assert Ed25519.verify(public, msg, signature)
 #   if len(msg) == 0:
 #       bad_msg = b"x"
 #   else:
 #       bad_msg = munge_string(msg, len(msg) // 3, 4)
 #   assert not Ed25519.verify(public,bad_msg,signature)
 #   assert not Ed25519.verify(public, msg, munge_string(signature,20,8))
 #   assert not Ed25519.verify(public,msg,munge_string(signature,40,16))




#Compute candidate square root of x modulo p, with p = 3 (mod 4).
def sqrt4k3(x,p): return pow(x,(p + 1)//4,p)

#Compute candidate square root of x modulo p, with p = 5 (mod 8).
def sqrt8k5(x,p):
    y = pow(x,(p+3)//8,p)
    #If the square root exists, it is either y or y*2^(p-1)/4.
    if (y * y) % p == x % p: return y
    else:
        z = pow(2,(p - 1)//4,p)
        return (y * z) % p

#Decode a hexadecimal string representation of the integer.
def hexi(s): return int.from_bytes(bytes.fromhex(s),byteorder="big")

#Rotate a word x by b places to the left.
def rol(x,b): return ((x << b) | (x >> (64 - b))) & (2**64-1)

#From little endian.
def from_le(s): return int.from_bytes(s, byteorder="little")

#Do the SHA-3 state transform on state s.
def sha3_transform(s):
    ROTATIONS = [0,1,62,28,27,36,44,6,55,20,3,10,43,25,39,41,45,15,\
                 21,8,18,2,61,56,14]
    PERMUTATION = [1,6,9,22,14,20,2,12,13,19,23,15,4,24,21,8,16,5,3,\
                   18,17,11,7,10]
    RC = [0x0000000000000001,0x0000000000008082,0x800000000000808a,\
          0x8000000080008000,0x000000000000808b,0x0000000080000001,\
          0x8000000080008081,0x8000000000008009,0x000000000000008a,\
          0x0000000000000088,0x0000000080008009,0x000000008000000a,\
          0x000000008000808b,0x800000000000008b,0x8000000000008089,\
          0x8000000000008003,0x8000000000008002,0x8000000000000080,\
          0x000000000000800a,0x800000008000000a,0x8000000080008081,\
          0x8000000000008080,0x0000000080000001,0x8000000080008008]

    for rnd in range(0,24):
        #AddColumnParity (Theta)
        c = [0]*5;
        d = [0]*5;
        for i in range(0,25): c[i%5]^=s[i]
        for i in range(0,5): d[i]=c[(i+4)%5]^rol(c[(i+1)%5],1)
        for i in range(0,25): s[i]^=d[i%5]
        #RotateWords (Rho)
        for i in range(0,25): s[i]=rol(s[i],ROTATIONS[i])
        #PermuteWords (Pi)
        t = s[PERMUTATION[0]]
        for i in range(0,len(PERMUTATION)-1):
            s[PERMUTATION[i]]=s[PERMUTATION[i+1]]
        s[PERMUTATION[-1]]=t;
        #NonlinearMixRows (Chi)
        for i in range(0,25,5):
            t=[s[i],s[i+1],s[i+2],s[i+3],s[i+4],s[i],s[i+1]]
            for j in range(0,5): s[i+j]=t[j]^((~t[j+1])&(t[j+2]))
        #AddRoundConstant (Iota)
        s[0]^=RC[rnd]

#Reinterpret octet array b to word array and XOR it to state s.
def reinterpret_to_words_and_xor(s,b):
    for j in range(0,len(b)//8):
        s[j]^=from_le(b[8*j:][:8])

#Reinterpret word array w to octet array and return it.
def reinterpret_to_octets(w):
    mp=bytearray()
    for j in range(0,len(w)):
        mp+=w[j].to_bytes(8,byteorder="little")
    return mp

#(semi-)generic SHA-3 implementation
def sha3_raw(msg,r_w,o_p,e_b):
    r_b=8*r_w
    s=[0]*25
    #Handle whole blocks.
    idx=0
    blocks=len(msg)//r_b
    for i in range(0,blocks):
        reinterpret_to_words_and_xor(s,msg[idx:][:r_b])
        idx+=r_b
        sha3_transform(s)
    #Handle last block padding.
    m=bytearray(msg[idx:])
    m.append(o_p)
    while len(m) < r_b: m.append(0)
    m[len(m)-1]|=128
    #Handle padded last block.
    reinterpret_to_words_and_xor(s,m)
    sha3_transform(s)
    #Output.
    out = bytearray()
    while len(out)<e_b:
        out+=reinterpret_to_octets(s[:r_w])
        sha3_transform(s)
    return out[:e_b]

#Implementation of SHAKE256 functions.
def shake256(msg,olen): return sha3_raw(msg,17,31,olen)

#A (prime) field element.
class Field:
    #Construct number x (mod p).
    def __init__(self,x,p):
        self.__x=x%p
        self.__p=p
    #Check that fields of self and y are the same.
    def __check_fields(self,y):
        if type(y) is not Field or self.__p!=y.__p:
            raise ValueError("Fields don't match")
    #Field addition.  The fields must match.
    def __add__(self,y):
        self.__check_fields(y)
        return Field(self.__x+y.__x,self.__p)
    #Field subtraction.  The fields must match.
    def __sub__(self,y):
        self.__check_fields(y)
        return Field(self.__p+self.__x-y.__x,self.__p)
    #Field negation.
    def __neg__(self):
        return Field(self.__p-self.__x,self.__p)
    #Field multiplication.  The fields must match.
    def __mul__(self,y):
        self.__check_fields(y)
        return Field(self.__x*y.__x,self.__p)
    #Field division.  The fields must match.
    def __truediv__(self,y):
        return self*y.inv()
    #Field inverse (inverse of 0 is 0).
    def inv(self):
        return Field(pow(self.__x,self.__p-2,self.__p),self.__p)
    #Field square root.  Returns none if square root does not exist.
    #Note: not presently implemented for p mod 8 = 1 case.
    def sqrt(self):
        #Compute candidate square root.
        if self.__p%4==3: y=sqrt4k3(self.__x,self.__p)
        elif self.__p%8==5: y=sqrt8k5(self.__x,self.__p)
        else: raise NotImplementedError("sqrt(_,8k+1)")
        _y=Field(y,self.__p);
        #Check square root candidate valid.
        return _y if _y*_y==self else None
    #Make the field element with the same field as this, but
    #with a different value.
    def make(self,ival): return Field(ival,self.__p)
    #Is the field element the additive identity?
    def iszero(self): return self.__x==0
    #Are field elements equal?
    def __eq__(self,y): return self.__x==y.__x and self.__p==y.__p
    #Are field elements not equal?
    def __ne__(self,y): return not (self==y)
    #Serialize number to b-1 bits.
    def tobytes(self,b):
        return self.__x.to_bytes(b//8,byteorder="little")
    #Unserialize number from bits.
    def frombytes(self,x,b):
        rv=from_le(x)%(2**(b-1))
        return Field(rv,self.__p) if rv<self.__p else None
    #Compute sign of number, 0 or 1.  The sign function
    #has the following property:
    #sign(x) = 1 - sign(-x) if x != 0.
    def sign(self): return self.__x%2
    def VALUE(self): return self.__x

#A point on (twisted) Edwards curve.
class EdwardsPoint:
    #base_field = None
    #x = None
    #y = None
    #z = None
    def initpoint(self, x, y):
        self.x=x
        self.y=y
        self.z=self.base_field.make(1)
    def decode_base(self,s,b):
        #Check that point encoding is the correct length.
        if len(s)!=b//8: return (None,None)
        #Extract signbit.
        xs=s[(b-1)//8]>>((b-1)&7)
        #Decode y.  If this fails, fail.
        y = self.base_field.frombytes(s,b)
        if y is None: return (None,None)
        #Try to recover x.  If it does not exist, or if zero and xs
        #are wrong, fail.
        x=self.solve_x2(y).sqrt()
        if x is None or (x.iszero() and xs!=x.sign()):
            return (None,None)
        #If sign of x isn't correct, flip it.
        if x.sign()!=xs: x=-x
        # Return the constructed point.
        return (x,y)
    def encode_base(self,b):
        xp,yp=self.x/self.z,self.y/self.z
        #Encode y.
        s=bytearray(yp.tobytes(b))
        #Add sign bit of x to encoding.
        if xp.sign()!=0: s[(b-1)//8]|=1<<(b-1)%8
        return s

    def __mul__(self,x):
        Q=self.zero_elem()
        P=self
        while x > 0:
            if (x%2)>0:
                Q=Q+P
            P=P.double()
            x=x//2
            print (Q.z.VALUE())
        return Q
    def __eq__(self,y):
        xn1=self.x*y.z
        xn2=y.x*self.z
        yn1=self.y*y.z
        yn2=y.y*self.z
        return xn1==xn2 and yn1==yn2
    #Check if two points are not equal.
    def __ne__(self,y): return not (self==y)

#A point on Edwards25519.
class Edwards25519Point(EdwardsPoint):
    #Create a new point on the curve.
    base_field=Field(1,2**255-19)
    d=-base_field.make(121665)/base_field.make(121666)
    f0=base_field.make(0)
    f1=base_field.make(1)
    xb=base_field.make(hexi("216936D3CD6E53FEC0A4E231FDD6DC5C692CC76"+\
        "09525A7B2C9562D608F25D51A"))
    yb=base_field.make(hexi("666666666666666666666666666666666666666"+\
        "6666666666666666666666658"))
    #The standard base point.
    @staticmethod
    def stdbase():
        return Edwards25519Point(Edwards25519Point.xb,\
            Edwards25519Point.yb)
    def __init__(self,x,y):
        #Check the point is actually on the curve.
        if y*y-x*x!=self.f1+self.d*x*x*y*y:
            raise ValueError("Invalid point")
        self.initpoint(x, y)
        self.t=x*y
    #Decode a point representation.
    def decode(self,s):
        x,y=self.decode_base(s,256);
        return Edwards25519Point(x, y) if x is not None else None
    #Encode a point representation.
    def encode(self):
        return self.encode_base(256)
    #Construct a neutral point on this curve.
    def zero_elem(self):
        return Edwards25519Point(self.f0,self.f1)
    #Solve for x^2.
    def solve_x2(self,y):
        return ((y*y-self.f1)/(self.d*y*y+self.f1))
    #Point addition.
    def __add__(self,y):
        #The formulas are from EFD.
        tmp=self.zero_elem()
        zcp=self.z*y.z
        A=(self.y-self.x)*(y.y-y.x)
        B=(self.y+self.x)*(y.y+y.x)
        C=(self.d+self.d)*self.t*y.t
        D=zcp+zcp
        E,H=B-A,B+A
        F,G=D-C,D+C
        tmp.x,tmp.y,tmp.z,tmp.t=E*F,G*H,F*G,E*H
        return tmp
    #Point doubling.
    def double(self):
        #The formulas are from EFD (with assumption a=-1 propagated).
        tmp=self.zero_elem()
        A=self.x*self.x
        B=self.y*self.y
        Ch=self.z*self.z
        C=Ch+Ch
        H=A+B
        xys=self.x+self.y
        E=H-xys*xys
        G=A-B
        F=C+G
        tmp.x,tmp.y,tmp.z,tmp.t=E*F,G*H,F*G,E*H
        return tmp
    #Order of basepoint.
    def l(self):
        return hexi("1000000000000000000000000000000014def9dea2f79cd"+\
            "65812631a5cf5d3ed")
    #The logarithm of cofactor.
    def c(self): return 3
    #The highest set bit
    def n(self): return 254
    #The coding length
    def b(self): return 256

    #Validity check (for debugging)
    def is_valid_point(self):
        x,y,z,t=self.x,self.y,self.z,self.t
        x2=x*x
        y2=y*y
        z2=z*z
        lhs=(y2-x2)*z2
        rhs=z2*z2+self.d*x2*y2
        assert(lhs == rhs)
        assert(t*z == x*y)

#A point on Edwards448.
class Edwards448Point(EdwardsPoint):
    #Create a new point on the curve.
    base_field=Field(1,2**448-2**224-1)
    d=base_field.make(-39081)
    f0=base_field.make(0)
    f1=base_field.make(1)
    xb=base_field.make(hexi("4F1970C66BED0DED221D15A622BF36DA9E14657"+\
        "0470F1767EA6DE324A3D3A46412AE1AF72AB66511433B80E18B00938E26"+\
        "26A82BC70CC05E"))
    yb=base_field.make(hexi("693F46716EB6BC248876203756C9C7624BEA737"+\
        "36CA3984087789C1E05A0C2D73AD3FF1CE67C39C4FDBD132C4ED7C8AD98"+\
        "08795BF230FA14"))
    #The standard base point.
    @staticmethod
    def stdbase():
        return Edwards448Point(Edwards448Point.xb,Edwards448Point.yb)
    def __init__(self,x,y):
        #Check that the point is actually on the curve.
        if y*y+x*x!=self.f1+self.d*x*x*y*y:
            raise ValueError("Invalid point")
        self.initpoint(x, y)
    #Decode a point representation.
    def decode(self,s):
        x,y=self.decode_base(s,456);
        return Edwards448Point(x, y) if x is not None else None
    #Encode a point representation.
    def encode(self):
        return self.encode_base(456)
    #Construct a neutral point on this curve.
    def zero_elem(self):
        return Edwards448Point(self.f0,self.f1)
    #Solve for x^2.
    def solve_x2(self,y):
        return ((y*y-self.f1)/(self.d*y*y-self.f1))

    #Point addition.
    def __add__(self,y):
        #The formulas are from EFD.
        tmp=self.zero_elem()
        xcp,ycp,zcp=self.x*y.x,self.y*y.y,self.z*y.z
        B=zcp*zcp
        E=self.d*xcp*ycp
        F,G=B-E,B+E
        tmp.x=zcp*F*((self.x+self.y)*(y.x+y.y)-xcp-ycp)
        tmp.y,tmp.z=zcp*G*(ycp-xcp),F*G
        return tmp
    #Point doubling.
    def double(self):
        #The formulas are from EFD.
        tmp=self.zero_elem()
        x1s,y1s,z1s=self.x*self.x,self.y*self.y,self.z*self.z
        xys=self.x+self.y
        F=x1s+y1s
        J=F-(z1s+z1s)
        tmp.x,tmp.y,tmp.z=(xys*xys-x1s-y1s)*J,F*(x1s-y1s),F*J
        return tmp
    #Order of basepoint.
    def l(self):
        return hexi("3ffffffffffffffffffffffffffffffffffffffffffffff"+\
            "fffffffff7cca23e9c44edb49aed63690216cc2728dc58f552378c2"+\
            "92ab5844f3")
    #The logarithm of cofactor.
    def c(self): return 2
    #The highest set bit.
    def n(self): return 447
    #The coding length.
    def b(self): return 456
    #Validity check (for debugging).
    def is_valid_point(self):
        x,y,z=self.x,self.y,self.z
        x2=x*x
        y2=y*y
        z2=z*z
        lhs=(x2+y2)*z2
        rhs=z2*z2+self.d*x2*y2
        assert(lhs == rhs)

#Simple self-check.
def curve_self_check(point):
    p=point
    q=point.zero_elem()
    z=q
    l=p.l()+1
    p.is_valid_point()
    q.is_valid_point()
    for i in range(0,point.b()):
        if (l>>i)&1 != 0:
            q=q+p
            q.is_valid_point()
        p=p.double()
        p.is_valid_point()
    assert q.encode() == point.encode()
    assert q.encode() != p.encode()
    assert q.encode() != z.encode()

#Simple self-check.
def self_check_curves():
    curve_self_check(Edwards25519Point.stdbase())
    curve_self_check(Edwards448Point.stdbase())

#PureEdDSA scheme. (only b mod 8 = 0 is handled.)
class PureEdDSA:
    #Create a new object.
    def __init__(self,properties):
        self.B=properties["B"]
        self.H=properties["H"]
        self.l=self.B.l()
        self.n=self.B.n()
        self.b=self.B.b()
        self.c=self.B.c()
    #Clamp a private scalar.
    def __clamp(self,a):
        _a = bytearray(a)
        for i in range(0,self.c): _a[i//8]&=~(1<<(i%8))
        _a[self.n//8]|=1<<(self.n%8)
        for i in range(self.n+1,self.b): _a[i//8]&=~(1<<(i%8))

        for i in _a:print (i)

        return _a
    #Generate a key.  If privkey is None, a random one is generated.
    #In any case, the (privkey, pubkey) pair is returned.
    def keygen(self,privkey):
        #If no private key data is given, generate random.
        if privkey is None: privkey=os.urandom(self.b//8)
        #Expand key.
        khash=self.H(privkey,None,None)


        print ( binascii.b2a_hex(khash))


        a=from_le(self.__clamp(khash[:self.b//8]))
        #Return the key pair (public key is A=Enc(aB).

        publicPoint = self.B*a
        encoding = publicPoint.encode()

        return privkey,(self.B*a).encode()
    #Sign with key pair.
    def sign(self,privkey,pubkey,msg,ctx,hflag):
        #Expand key.
        khash=self.H(privkey,None,None)
        a=from_le(self.__clamp(khash[:self.b//8]))
        seed=khash[self.b//8:]

        for i in seed:print (i)

        #Calculate r and R (R only used in encoded form).
        r=from_le(self.H(seed+msg,ctx,hflag))%self.l
        R=(self.B*r).encode()
        #Calculate h.
        h=from_le(self.H(R+pubkey+msg,ctx,hflag))%self.l
        #Calculate s.
        S=((r+h*a)%self.l).to_bytes(self.b//8,byteorder="little")
        #The final signature is a concatenation of R and S.
        return R+S
    #wev
    def verifykey(pubkey):
        A=Edwards448Point.stdbase().decode(pubkey)
        return 1

    #Verify signature with public key.
    def verify(self,pubkey,msg,sig,ctx,hflag):
        #Sanity-check sizes.
        if len(sig)!=self.b//4: return False
        if len(pubkey)!=self.b//8: return False
        #Split signature into R and S, and parse.
        Rraw,Sraw=sig[:self.b//8],sig[self.b//8:]
        R,S=self.B.decode(Rraw),from_le(Sraw)
        #Parse public key.
        A=self.B.decode(pubkey)
        #Check parse results.
        if (R is None) or (A is None) or S>=self.l: return False
        #Calculate h.
        h=from_le(self.H(Rraw+pubkey+msg,ctx,hflag))%self.l
        #Calculate left and right sides of check eq.
        rhs=R+(A*h)
        lhs=self.B*S
        for i in range(0, self.c):
            lhs = lhs.double()
            rhs = rhs.double()
        #Check eq. holds?
        return lhs==rhs

def Ed25519_inthash(data,ctx,hflag):
    if (ctx is not None and len(ctx) > 0) or hflag:
        raise ValueError("Contexts/hashes not supported")
    return hashlib.sha512(data).digest()

#The base PureEdDSA schemes.
pEd25519=PureEdDSA({\
    "B":Edwards25519Point.stdbase(),\
    "H":Ed25519_inthash\
})

def Ed25519ctx_inthash(data,ctx,hflag):
    dompfx = b""
    PREFIX=b"SigEd25519 no Ed25519 collisions"
    if ctx is not None:
        if len(ctx) > 255: raise ValueError("Context too big")
        dompfx=PREFIX+bytes([1 if hflag else 0,len(ctx)])+ctx
    return hashlib.sha512(dompfx+data).digest()

pEd25519ctx=PureEdDSA({\
    "B":Edwards25519Point.stdbase(),\
    "H":Ed25519ctx_inthash\
})

def Ed448_inthash(data,ctx,hflag):
    dompfx = b""
    if ctx is not None:
        if len(ctx) > 255: raise ValueError("Context too big")
        dompfx=b"SigEd448"+bytes([1 if hflag else 0,len(ctx)])+ctx
    return shake256(dompfx+data,114)

pEd448 = PureEdDSA({\
    "B":Edwards448Point.stdbase(),\
    "H":Ed448_inthash\
})

#EdDSA scheme.
class EdDSA:
    #Create a new scheme object, with the specified PureEdDSA base
    #scheme and specified prehash.
    def __init__(self,pure_scheme,prehash):
        self.__pflag = True
        self.__pure=pure_scheme
        self.__prehash=prehash
        if self.__prehash is None:
            self.__prehash = lambda x,y:x
            self.__pflag = False
    # Generate a key.  If privkey is none, it generates a random
    # privkey key, otherwise it uses a specified private key.
    # Returns pair (privkey, pubkey).
    def keygen(self,privkey): return self.__pure.keygen(privkey)
    # Generate a key.  If privkey is none, it generates a random
    # privkey key, otherwise it uses a specified private key.
    # Returns pair (privkey, pubkey).
    def keygen2(self,privkey): return self.__pure.keygen(privkey)
    # Sign message msg using specified key pair.
    def sign(self,privkey,pubkey,msg,ctx=None):
        if ctx is None: ctx=b"";
        return self.__pure.sign(privkey,pubkey,self.__prehash(msg,ctx),\
            ctx,self.__pflag)
    # Verify signature sig on message msg using public key pubkey.
    def verify(self,pubkey,msg,sig,ctx=None):
        if ctx is None: ctx=b"";
        return self.__pure.verify(pubkey,self.__prehash(msg,ctx),sig,\
            ctx,self.__pflag)

def Ed448ph_prehash(data,ctx):
    return shake256(data,64)

#Our signature schemes.
Ed25519 = EdDSA(pEd25519,None)
Ed25519ctx = EdDSA(pEd25519ctx,None)
Ed25519ph = EdDSA(pEd25519ctx,lambda x,y:hashlib.sha512(x).digest())
Ed448 = EdDSA(pEd448,None)
Ed448ph = EdDSA(pEd448,Ed448ph_prehash)

def eddsa_obj(name):
    if name == "Ed25519": return Ed25519
    if name == "Ed25519ctx": return Ed25519ctx
    if name == "Ed25519ph": return Ed25519ph
    if name == "Ed448": return Ed448
    if name == "Ed448ph": return Ed448ph
    raise NotImplementedError("Algorithm not implemented")













