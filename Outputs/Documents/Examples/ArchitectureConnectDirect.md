The connection request is initiated on the device being connected:


~~~~
<div="terminal">
<cmd>Alice2> meshman device request alice@example.com
<rsp>   Device UDF = MBYI-QYCM-JXEY-OJ5D-4OW2-RPIR-SHUM
   Witness value = Z3PE-JMM5-G3XQ-CB3Q-LNX4-2YY6-Q74Y
</div>
~~~~

Using her administration device, Alice gets a list of pending requests. Seeing that
there is a pending request matching the witness value presented by the device, Alice
accepts the request, granting the new device the messaging and web roles:


~~~~
<div="terminal">
<cmd>Alice> meshman device pending
<rsp>MessageID: Z3PE-JMM5-G3XQ-CB3Q-LNX4-2YY6-Q74Y
        Connection Request::
        MessageID: Z3PE-JMM5-G3XQ-CB3Q-LNX4-2YY6-Q74Y
        To:  From: 
        Device:  MBYI-QYCM-JXEY-OJ5D-4OW2-RPIR-SHUM
        Witness: Z3PE-JMM5-G3XQ-CB3Q-LNX4-2YY6-Q74Y
<cmd>Alice> meshman device accept Z3PE-JMM5-G3XQ-CB3Q-LNX4-2YY6-Q74Y ^
    /message /web
</div>
~~~~

Alice can now synchronize her newly connected device to her account:


~~~~
<div="terminal">
<cmd>Alice2> meshman device complete
<rsp>   Device UDF = MBYI-QYCM-JXEY-OJ5D-4OW2-RPIR-SHUM
   Account = alice@example.com
   Account UDF = MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
</div>
~~~~


