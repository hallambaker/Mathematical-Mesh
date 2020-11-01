The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MBLT-PGYV-RQOL-XFPP-HADO-HTTF-Q3UO
   Witness value = H4GO-4HQR-G2LP-PF37-M2MK-GSMK-G6GC
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts it:


~~~~
<div="terminal">
<cmd>Alice> message pending
<rsp>MessageID: AP52-MMYQ-HRAU-AFK2-O3JC-KDQ3-3OOW
        Connection Request::
        MessageID: AP52-MMYQ-HRAU-AFK2-O3JC-KDQ3-3OOW
        To:  From: 
        Device:  MD4F-TMBT-T4WP-QPEX-FSQF-XD7B-UUDY
        Witness: AP52-MMYQ-HRAU-AFK2-O3JC-KDQ3-3OOW
MessageID: NCQN-DQVD-SM3K-QG6K-F2YX-QOVD-AKJQ
        Confirmation Request::
        MessageID: NCQN-DQVD-SM3K-QG6K-F2YX-QOVD-AKJQ
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NBI3-FCGJ-V33K-MFMV-JCQX-PNJ6-RYX7
        Contact Request::
        MessageID: NBI3-FCGJ-V33K-MFMV-JCQX-PNJ6-RYX7
        To: alice@example.com From: bob@example.com
        PIN: ABU5-EVOM-WLLX-4XCU-HEWO-EZ5R-5KAQ
<cmd>Alice> account sync /auto
<rsp>ERROR - Cannot access a closed file.
<cmd>Alice> device accept H4GO-4HQR-G2LP-PF37-M2MK-GSMK-G6GC
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
</div>
~~~~


