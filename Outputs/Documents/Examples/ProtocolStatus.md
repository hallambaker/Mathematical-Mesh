
Alice adds an entry to her bookmark catalog. Before the bookmark can be 
added, the device synchronizes to the service. The synchronization process
begins with a request for the status of all the stores associated with the 
account that it has access rights for:


~~~~
{
  "StatusRequest":{
    "CatalogedDeviceDigest":"MALR-EDVY-FMOY-2MZD-7QBN-USK7-56"}}
~~~~


If the account has a very large number of stores, the device might only 
ask for the status of specific stores of interest.

The response specifies the status of each store specifying the index and
Merkle tree apex digest values for each:


~~~~
{
  "StatusResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "ContainerStatus":[{
        "Container":"MMM_Inbound",
        "Index":3},
      {
        "Container":"MMM_Outbound",
        "Index":1,
        "Digest":"FEHy24Y6cLModDXWH31kVc2a3TdhjXPooKHpLAb2JbsO1YQ
  nJolmowXAYHhkOGY0kg3jrKNTjds0myf4Dw1sdg"},
      {
        "Container":"MMM_Local",
        "Index":2},
      {
        "Container":"MMM_Access",
        "Index":3},
      {
        "Container":"MMM_Credential",
        "Index":4},
      {
        "Container":"MMM_Device",
        "Index":3},
      {
        "Container":"MMM_Contact",
        "Index":2},
      {
        "Container":"MMM_Application",
        "Index":1},
      {
        "Container":"MMM_Publication",
        "Index":1},
      {
        "Container":"MMM_Bookmark",
        "Index":1},
      {
        "Container":"MMM_Task",
        "Index":1}
      ]}}
~~~~


Bug: The current version of the reference code is only returning the digest 
values for the outbound store.

