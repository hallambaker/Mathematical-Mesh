The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MDAU-GA6X-VXHV-AZCF-SRMU-UKC5-JCYC
   Witness value = MVVS-W7AX-L5IY-5WWI-H66B-SRPS-3U3K
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: MVVS-W7AX-L5IY-5WWI-H66B-SRPS-3U3K
        Connection Request::
        MessageID: MVVS-W7AX-L5IY-5WWI-H66B-SRPS-3U3K
        To:  From: 
        Device:  MDAU-GA6X-VXHV-AZCF-SRMU-UKC5-JCYC
        Witness: MVVS-W7AX-L5IY-5WWI-H66B-SRPS-3U3K
<cmd>Alice> device accept MVVS-W7AX-L5IY-5WWI-H66B-SRPS-3U3K /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MDAU-GA6X-VXHV-AZCF-SRMU-UKC5-JCYC
   Account = alice@example.com
   Account UDF = MBMJ-7X6T-DWE7-6EGQ-2QGZ-RSYR-553Q
</div>
~~~~


