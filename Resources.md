# Resources

C#, dotNet Core and Maui provide a lot of platform specific customization but lack support
for others. This document collects together resources that may prove useful in enabling that
support.

<dl>
<dt>URI Activation</dt>
<dd>Al,low other applications on the platform to hand off Mesh URIs to the app</dd>
<dt>Use platform Key Store</dt>
<dd>Windows and OSX provide secure storage mechanisms for private keys, these
should be used to store Mesh keys and key seeds.</dd>
<dt>Platform Key Store</dt>
<dd></dd>
<dt>Join named WiFi Network</dt>
<dd></dd>
<dt>Code Signing</dt>
<dd>Generate root keys and code signing keys for development and production use.</dd>
<dt>Application Credentials</dt>
<dd>Public key credentials consumed by various applications</dd>
<dt></dt>
<dd></dd>
</dl>


## URI Activation

Register Mesh URI schemes so that when someone clicks on a Mesh URI link, this
causes a new instance of the program to start if there is no application running
or a message to be sent to the running application otherwise.


### Windows

https://stackoverflow.com/questions/72606737/how-to-open-winui-maui-through-uri-activation

## Platform Key Store

## Join named WiFi Network

A common requirement for onboarding is to connect a device to a different WiFi 
network. So before the IoT device can connect to the local network, it broadcasts an
SSID for 'Device12345' and waits for a configuration device to attempt to connect on
port 80.


## Configure Network Credentials

## Transfer passwords / credentials into the device vault




## Code Signing

### Personal root key

Since the code signing world doesn't use the Ed448 curve, we need to choose a signature
algorithm. NIST P-521, aka secp521r1, aka 1.3.132.0.35 is supported on Windows and by Apple.

We prefer 521 over the other NIST curves because it is a rigid construction constrained
by the choice of the Mersene prime 2^521 - 1.

### Windows Code Signing (Powershell, dotNet, etc.)

### Android Code Signing

### Apple Code Signing (Side loading)

## Application Credentials

### SSH Credentials

Currently only supports Ed25519 

### PGP Credentials

Can choose between NIST P-521 and Ed448

Need to consider Git Commit signing and Email as separate things.

### S/MIME

Create S/MIME credentials and install them in Outlook, etc.
