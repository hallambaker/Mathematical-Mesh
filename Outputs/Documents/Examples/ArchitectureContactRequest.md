Bob requests Alice add him to her contacts catalog:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp></div>
~~~~

When Alice next checks her messages, she sees the pending contact request from Bob and accepts
it. Bob's contact details are added to her catalog and Bob receives a response containing
Alice's credentials:


~~~~
<div="terminal">
<cmd>Alice> message pending
<rsp>MessageID: NAKQ-VJU5-XERR-C3C2-YBFL-HZXN-TWGD
        Contact Request::
        MessageID: NAKQ-VJU5-XERR-C3C2-YBFL-HZXN-TWGD
        To: alice@example.com From: bob@example.com
        PIN: ECFX-4MRD-ALZE-QDW2-242H-5LXI-OM7N
MessageID: CIGO-WAFU-OAYI-PF7E-5L4H-DOG2-SY3Z
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
<cmd>Alice> message accept tbs
<rsp>ERROR - The specified message could not be found.
</div>
~~~~

