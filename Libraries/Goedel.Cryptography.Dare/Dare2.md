= DARE 2.0 Design notes

Envelope format:


Base:

Type-ID
Unprotected
Content-Metadata
[Payload-Chunk]*
Empty chunk
Trailer


With Encrypted Metadata:

Type-ID
Unprotected
Content-Metadata
Content-Metadata-Encrypted
[Payload-Chunk]*
Empty chunk
Trailer


Sequence Formats


Type-ID
[
Frame-Length
Frame
Frame-Length]*


Frame types


Unprotected
Content-Metadata
Payload
Trailer

Unprotected
Content-Metadata
Content-Metadata-Encrypted
Payload
Trailer


Encryption formats

Two modes are supported, plain and SIV

Plain: Cihertext, Tag
SIV: IV-Mask, Cihertext, Tag

Single:

Encrypt(plaintext)

Fixed-Chunked:

In the fixed chunked encoding, every chunk is the same size

[Encrypt(chunk)]*
Encrypt(final)


In the variable chunked encoding, every chunk has a length indicator

[Length, Encrypt(chunk)]*
Empty chunk