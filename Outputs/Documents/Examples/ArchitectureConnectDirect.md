The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> meshman device request alice@example.com
<rsp>   Device UDF = MBQO-4TTM-QOTS-MKEG-XQTU-XNFM-WUWM
   Witness value = HPSV-N4OL-ME5Y-JOKE-ESFQ-OLFL-YOWQ
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> meshman device pending
<rsp>MessageID: HPSV-N4OL-ME5Y-JOKE-ESFQ-OLFL-YOWQ
        Connection Request::
        MessageID: HPSV-N4OL-ME5Y-JOKE-ESFQ-OLFL-YOWQ
        To:  From: 
        Device:  MBQO-4TTM-QOTS-MKEG-XQTU-XNFM-WUWM
        Witness: HPSV-N4OL-ME5Y-JOKE-ESFQ-OLFL-YOWQ
<cmd>Alice> meshman device accept HPSV-N4OL-ME5Y-JOKE-ESFQ-OLFL-YOWQ ^
    /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> meshman device complete
<rsp>   Device UDF = MBQO-4TTM-QOTS-MKEG-XQTU-XNFM-WUWM
   Account = alice@example.com
   Account UDF = MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36
</div>
~~~~


