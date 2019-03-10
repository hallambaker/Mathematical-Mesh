
# Using the Key Command Set

The Key command set contains commands that operate on cryptographic secrets and
nonces.

## Generating Secrets and Nonces

Secrets and nonces both consist of a randomly generated sequence of bits. The
only distinction made between a secret and a nonce is the uses that may be 
made of them. For example, a secret value must not be passed in clear text in 
any circumstances. The visual distinction between these uses afforded by UDF 
presentation aids application debugging and audit.

The `key nonce` command is used to generate a new random nonce value:

% ConsoleExample (_Output, KeyNonce)

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option

% ConsoleExample (_Output, KeyNonce256)

Secrets are generated using the `key secret` in the same way:

% ConsoleExample (_Output, KeySecret)
% ConsoleExample (_Output, KeySecret256)

## Generating EARL values

An Encrypted Authenticated Resource locator is a form of URI that specifies 
a means of locating and decrypting content stored on a remote Web service.

The EARL itself specifies a domain name and a secret. The content is stored
on the Web Service under a label that is the Content Digest of the secret.

EARLs may be generated using either the `key earl` command to generate
a new secret/digest pair which are then used to process the content data:

% ConsoleExample (_Output, KeyEarl)

Alternatively, the 'file earl' command may be used to perform both operations:

% ConsoleExample (_Output, FileEarl)

## Sharing and recovering secrets

Secret sharing splits a secret into a set of shares such that the original
secret can be recovered from a chosen number of shares called the quorum.

The `key share` command creates a secret and splits it into the specified
number of shares with the specified quorum for recovery. By default, a 128
bit secret is created and three shares are created with a quorum of two:

% ConsoleExample (_Output, KeyShare)

The original secret may be recovered from a sufficient number of shares to
meet the quorum:

% ConsoleExample (_Output, KeyRecovery)

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:

% ConsoleExample (_Output, KeyShare2)

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:

% ConsoleExample (_Output, KeyShare3)

