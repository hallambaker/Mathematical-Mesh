
# Using the device Command Set

The `device` command set contains commands used to connect devices to a 
profile.

## Requesting a connection

The `device request` command is used on the new device 
to request connection to the user's profile. Alice need only specify 
the mesh service account alice@example.com to which connection is requested:


````
>device request alice@example.com
ERROR - Object reference not set to an instance of an object.
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


````
>device accept id
ERROR - Object reference not set to an instance of an object.
````

There is a second request that Alice doesn't recognize. Alice rejects this
request:


````
>device reject id
ERROR - Object reference not set to an instance of an object.
````

The connection process is completed by synchronizing the new device. At this point,
all the applications that were available to the first device are available to the
second:


````
>device sync
ERROR - The command  is not known.
````

##Managing connected devices

The `device list` command gives a list of devices in the device 
catalog:


````
>device 
ERROR - The command  is not known.
````

The `device delete` command removes a device from the catalog:


````
>device 
ERROR - The command  is not known.
````


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
ERROR - Object reference not set to an instance of an object.
````

Since the PIN code that was issued was set to be self-authorizing, the device
is connected automatically when the user synchronizes their account from an 
administrator device:


````
>device pending
ERROR - Object reference not set to an instance of an object.
````


## Requesting a connection using an EARL

The interactive connection mechanisms are suitable for devices such as phones and
laptops but not for IoT devices which lack screens and keyboards. Support for
such devices may be provided by means of an EARL presented on the device or its
packaging.

To enable this connection mode, the manufacturer performs the steps of

* Generating a device profile and open connection request

* Encrypting the open connection request under a randomly chosen key

* Provisioning the encrypted device profile to a Web site

* Creating UDF EARL of the key

* Converting the EARL to a QR code which is printed on the device or its packaging.

These steps may be performed using the meshman tool and a QR code generation tool as follows:


````
>device 
ERROR - The command  is not known.
````

A QR code scanning application can use the meshman tool to resolve the EARL and retrieve
the data using the `device earl` command:


````
>device 
ERROR - The command  is not known.
````

The tool resolves the EARL to obtain the encrypted open connection request,
decrypts it and adds it to the user's device catalog. A connection request is
to the Mesh service specified in the open connection request to allow the 
new device to be notified of the connection request and complete the connection.

If the device is already connected to a Mesh profile, it will need to be reset 
before it can be connected to another profile unless the device is designed
to allow connection to multiple devices simultaneously.


