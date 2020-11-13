The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MDXZ-CDAK-HQK2-DAQX-I6RR-2SMY-SWPT
   Witness value = SCR2-CEZJ-CPJJ-HEPT-3MKL-WUBW-RXCO
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> message pending
<rsp>MessageID: SEI7-CZRC-SND6-YTD6-JI37-VCM5-ZRTU
        Connection Request::
        MessageID: SEI7-CZRC-SND6-YTD6-JI37-VCM5-ZRTU
        To:  From: 
        Device:  MAAK-CCMO-EIOM-2AZ5-6SXD-W3L2-KWK2
        Witness: SEI7-CZRC-SND6-YTD6-JI37-VCM5-ZRTU
MessageID: NDBR-Q2V7-VKQP-4HSN-JJVC-JIM5-GV2R
        Confirmation Request::
        MessageID: NDBR-Q2V7-VKQP-4HSN-JJVC-JIM5-GV2R
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NAEX-I6PT-PAPW-DIHU-I4XK-WP5U-KO5V
        Contact Request::
        MessageID: NAEX-I6PT-PAPW-DIHU-I4XK-WP5U-KO5V
        To: alice@example.com From: bob@example.com
        PIN: ABII-UOYN-BS3E-FXM5-3HSW-FCQQ-2DTA
<cmd>Alice> account sync /auto
<cmd>Alice> device accept SCR2-CEZJ-CPJJ-HEPT-3MKL-WUBW-RXCO /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> device complete
</div>
~~~~


