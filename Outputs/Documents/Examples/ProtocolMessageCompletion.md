>>>> Unfinished ProtocolMessageCompletion



After using the PIN code to authenticate connection of a device in the previous 
example, the corresponding MessagePin is marked as having been used by appending 
a completion message to the Local spool.

~~~~
{
  "MessageComplete":{
    "MessageId":"NCGK-JALZ-YJY7-7RI6-KYAQ-RYGU-QLOW",
    "References":[{
        "MessageId":"ABF7-CTWL-U2EV-KAEF-OLNM-XAW7-76XZ",
        "ResponseId":"MDIU-J7RJ-ZXKZ-GWIH-PU4Z-7G57-W3BG",
        "Relationship":"Closed"}
      ]}}
~~~~

