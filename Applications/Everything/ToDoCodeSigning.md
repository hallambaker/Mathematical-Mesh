# Code Signing


## Windows, create command

https://codesigningstore.com/how-to-create-self-signed-code-signing-certificate-with-powershell#:~:text=How%20to%20Create%20a%20Self-Signed%20Certificate%20With%20Private,administrator.%20...%202%202.%20Run%20the%20New-SelfSignedCertificate%20Command

$cert = New-SelfSignedCertificate -KeyUsage DigitalSignature -KeySpec Signature -KeyAlgorithm RSA -KeyLength 2048 -DNSName “www.yourdomain.com” -CertStoreLocation Cert:\CurrentUser\My -Type CodeSigningCert -Subject “Your Code Signing Certificate Name”

If the EnhancedKeyUsageList value (i.e., a specific identifier) is set as {Code Signing. (1.3.6.1.5.5.7.3.3)}, it means that you’re good to go. The certificate’s key can be used to sign your applications and executables for testing.