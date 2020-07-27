The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MC6T-FX77-ABC5-BVJ5-U3C4-MYCH-PQVR
   Witness value = XP3F-7HEO-OYBH-SKCJ-EO7P-Q54P-6HED
   Personal Mesh = MBU4-C4AJ-TGTO-AETP-LQDC-R3L6-VMX7
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts it:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: CIGO-WAFU-OAYI-PF7E-5L4H-DOG2-SY3Z
        Connection Request::
        MessageID: CIGO-WAFU-OAYI-PF7E-5L4H-DOG2-SY3Z
        To:  From: 
        Device:  MD7W-S6XF-V4EL-7QEO-MUPK-B5JL-MLPY
        Witness: CIGO-WAFU-OAYI-PF7E-5L4H-DOG2-SY3Z
MessageID: XP3F-7HEO-OYBH-SKCJ-EO7P-Q54P-6HED
        Connection Request::
        MessageID: XP3F-7HEO-OYBH-SKCJ-EO7P-Q54P-6HED
        To:  From: 
        Device:  MC6T-FX77-ABC5-BVJ5-U3C4-MYCH-PQVR
        Witness: XP3F-7HEO-OYBH-SKCJ-EO7P-Q54P-6HED
<cmd>Alice> device accept CIGO-WAFU-OAYI-PF7E-5L4H-DOG2-SY3Z
<rsp>Result: Accept
Added device: MD7W-S6XF-V4EL-7QEO-MUPK-B5JL-MLPY
</div>
~~~~

The new device will now synchronize automatically in response to any Mesh commands. For example, 
listing the password catalog:


~~~~
<div="terminal">
<cmd>Alice2> password list
<rsp>ERROR - Unspecified error
</div>
~~~~
