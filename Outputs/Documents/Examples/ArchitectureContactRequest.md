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
<rsp><cmd>Alice> message accept tbs
<rsp></div>
~~~~

