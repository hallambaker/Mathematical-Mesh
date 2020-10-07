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
<rsp>ERROR - An item with the same key has already been added. Key: DVHM-4XCL-BA55-ZW2F-GYO2-JWYN-OGH5
<cmd>Alice> message accept tbs
<rsp>ERROR - The specified message could not be found.
</div>
~~~~

