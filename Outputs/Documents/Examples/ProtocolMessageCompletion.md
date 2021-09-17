>>>> Unfinished ProtocolMessageCompletion



After using the PIN code to authenticate connection of a device in the previous 
example, the corresponding MessagePin is marked as having been used by appending 
a completion message to the Local spool.

~~~~
{
  "MessageComplete":{
    "MessageId":"ND7H-WD6O-RZT3-MXIB-7BWV-5O7K-6QCZ",
    "References":[{
        "MessageId":"AD6E-S7OC-XTQK-6IQY-PCE2-FEOB-C7U5",
        "ResponseId":"MDW6-33OF-Z3NV-GCFK-KTD3-SSYM-DFA5",
        "Relationship":"Closed"}
      ]}}
~~~~

