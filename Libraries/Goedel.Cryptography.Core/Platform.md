#Platform Specific

##Windows

This library is not intended for production use on Windows. Production Windows applications SHOULD 
instead link to Goedel.Cryptography.Windows which makes use of Windows platform features that 
allow data to be encrypted under a key that is gated by the Windows login mechanism. 

Using the native windows feature allows a transparent user experience in which the user has
access to their Mesh features without the need to provide separate authentication to each
Mesh enabled application. The encrypted master key required to decrypt the data is automatically
updated whenever the user changes their Windows password.

##OSX

OSX applications really should make use of the KeyChain feature. This is not yet implemented.

##Linux

The simplest means of achieving the desired unlocking capability on Linux appears to be 
to make use of ecryptfs-utils. The following commands cause these utilities to be installed 
and a directory .Private to be created in a user's home directory.

sudo apt-get install ecryptfs-utils
ecryptfs-setup-private

To automatically encrypt the directory at login, the user needs to install a PAM module:

pam_ecryptfs - PAM module for eCryptfs

See also...

https://wiki.centos.org/PhilipJensen/TransparentEncryptionForHomeFolder