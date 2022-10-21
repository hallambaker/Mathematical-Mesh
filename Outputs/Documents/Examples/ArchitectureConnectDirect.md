The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> meshman device request alice@example.com
<rsp>   Device UDF = MBYN-Q2AT-73EJ-2RO5-FZG3-CMIE-3YFA
   Witness value = 7QI7-PLXA-DZB2-XCQK-NGHH-DRXM-FIRV
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> meshman device pending
<rsp>MessageID: 7QI7-PLXA-DZB2-XCQK-NGHH-DRXM-FIRV
        Connection Request::
        MessageID: 7QI7-PLXA-DZB2-XCQK-NGHH-DRXM-FIRV
        To:  From: 
        Device:  MBYN-Q2AT-73EJ-2RO5-FZG3-CMIE-3YFA
        Witness: 7QI7-PLXA-DZB2-XCQK-NGHH-DRXM-FIRV
<cmd>Alice> meshman device accept 7QI7-PLXA-DZB2-XCQK-NGHH-DRXM-FIRV ^
    /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> meshman device complete
<rsp>   Device UDF = MBYN-Q2AT-73EJ-2RO5-FZG3-CMIE-3YFA
   Account = alice@example.com
   Account UDF = MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA
</div>
~~~~


