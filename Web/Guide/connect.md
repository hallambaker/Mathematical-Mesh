
# Using the device Command Set

The `device` command set contains commands used to connect devices to a 
profile.

## Requesting a connection

The `device request` command is used on the new device 
to request connection to the user's profile. Alice need only specify 
the mesh service account alice@example.com to which connection is requested:


````
>device request alice@example.com
ERROR - The feature has not been implemented
````

In this case there is no existing device profile and so a new profile is
created and used to create a registration request which is posted to the user's 
account.

The tool reports the connection request authenticator, a UDF fingerprint which
authenticates this particular request.

Alice must use a device already connected to her account to
complete the connection process.

The `device pending` command gives a list of pending connection
messages.


````
>device pending
ERROR - Object reference not set to an instance of an object.
````

Alice sees the request that she posted and approves it with the connect
`device accept` command:

**Missing Example***

There is a second request (from Mallet) that Alice doesn't recognize. Alice rejects this
request:

**Missing Example***

The connection process is completed by synchronizing the new device. At this point,
all the applications that were available to the first device are available to the
second:

**Missing Example***

##Managing connected devices

The `device list` command gives a list of devices in the device 
catalog:

**Missing Example***

The `device delete` command removes a device from the catalog:

**Missing Example***


## Requesting a connection using a PIN

The simple connection mechanism is straightforward but relies on the user who is
processing the connection requests recognizing the correct fingerprint. While this
is approach has proved practical when it is the same user who is making and 
approving the connection request, it is less satisfactory when this is done
by two different people or by the same person at different times.

Connection requests may be authenticated by means of a PIN created on an 
administration device. The `device pin` command generates
a new PIN code:


````
>device pin
ERROR - Object reference not set to an instance of an object.
````

The pin code can now be used to authenticate the connection request:


````
>device request /pin=PIN
ERROR - The feature has not been implemented
````

Since the PIN code that was issued was set to be self-authorizing, the device
is connected automatically when the user synchronizes their account from an 
administrator device:


````
>device pending
ERROR - Object reference not set to an instance of an object.
````


## Pre Configuring Devices

The `device delete` command creates a device profile without attempting
to connect the device to a Mesh profile:


````
>device create /id="IoTDevice"
ERROR - The option  is not known.
````

The most common reason for generating a device profile in this fashion is to allow
an embedded or 'IoT' device to be preconfigured for Mesh control during manufacture.


### Requesting a connection using an EARL

Encrypted Authenticated Resource Locators provide one means of preconfiguring
a device to enable simple and straightforward connection to a Mesh profile.

The EARL itself is typically presented by means of a barcode on the device
or its packaging. To connect the device, the user simply scans the QR code using
a Mesh enabled application on an administion device and applies power.
configuration then proceeds automatically.

Alternatively, the EARL may be transfered wirelessly by a near field 
communications link or by cycling an LED.



To enable this connection mode, the manufacturer performs the steps of

* Generating a device profile and open connection request

* Encrypting the open connection request under a randomly chosen key

* Provisioning the encrypted device profile to a Web site

* Creating UDF EARL of the key

* Converting the EARL to a QR code which is printed on the device or its packaging.

These steps may be performed using the meshman tool and a QR code generation tool as follows:


````
>device create /ocr
OK
Device Profile UDF=MDLW-AEJG-XAOU-4UUN-HVME-SFKO-35PS
````

A QR code scanning application can use the meshman tool to resolve the EARL and retrieve
the data using the `device earl` command:


````
>device earl udf://example.com/
ERROR - Object reference not set to an instance of an object.
````

The tool resolves the EARL to obtain the encrypted open connection request,
decrypts it and adds it to the user's device catalog. A connection request is
to the Mesh service specified in the open connection request to allow the 
new device to be notified of the connection request and complete the connection.

If the device is already connected to a Mesh profile, it will need to be reset 
before it can be connected to another profile unless the device is designed
to allow connection to multiple devices simultaneously.


