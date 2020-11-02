The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MCEK-MYVQ-ZK3G-7CE4-Y5UW-CKT4-EFE5
   Witness value = RRHK-27PQ-XJXM-AJD5-5Y67-DJZZ-KECH
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts it:


~~~~
<div="terminal">
<cmd>Alice> message pending
<rsp>MessageID: 4INK-WBOH-Z2LY-OG5L-SPP6-6EGL-5JZA
        Connection Request::
        MessageID: 4INK-WBOH-Z2LY-OG5L-SPP6-6EGL-5JZA
        To:  From: 
        Device:  MDKY-2MTB-IRYG-P6K4-CFZA-TV4H-IHG2
        Witness: 4INK-WBOH-Z2LY-OG5L-SPP6-6EGL-5JZA
MessageID: NAII-QGL5-YARH-DJRY-VIBX-QPOE-RDZS
        Confirmation Request::
        MessageID: NAII-QGL5-YARH-DJRY-VIBX-QPOE-RDZS
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NACV-TW2M-ICI2-5VBJ-QKAS-44FO-BRIP
        Contact Request::
        MessageID: NACV-TW2M-ICI2-5VBJ-QKAS-44FO-BRIP
        To: alice@example.com From: bob@example.com
        PIN: AADY-YL2H-5LIT-6PDV-USRI-74XS-YVJA
<cmd>Alice> account sync /auto
<rsp>ERROR - Cannot access a closed file.
<cmd>Alice> device accept RRHK-27PQ-XJXM-AJD5-5Y67-DJZZ-KECH
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
</div>
~~~~


