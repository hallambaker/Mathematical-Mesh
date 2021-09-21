
After using the PIN code to authenticate connection of a device in the previous 
example, the corresponding MessagePin is marked as having been used by appending 
a completion message to the Local spool.

~~~~
{
  "MessageComplete":{
    "MessageId":"NCY3-5SIF-WMLW-Z5N4-PYQM-U7IR-O6RK",
    "References":[{
        "MessageId":"ACLZ-SOE3-SD37-MLE2-VG3Q-RQJL-Q2JH",
        "ResponseId":"MCNL-JG33-NCGA-GXHI-42DU-UJVE-CN2S",
        "Relationship":"Closed"}
      ]}}
~~~~

