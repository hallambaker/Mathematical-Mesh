
Alice adds an entry to her bookmark catalog. Before the bookmark can be 
added, the device synchronizes to the service. The synchronization process
begins with a request for the status of all the stores associated with the 
account that it has access rights for:


~~~~
{
  "StatusRequest":{
    "CatalogedDeviceDigest":"MCVS-2II3-VYAM-XP25-A3AE-37V4-IY"}}
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
        "Index":3,
        "Digest":"v795u7iQguBcYMOykxRJQURYNtKB9FpsUr2HhbIA80ogeJf
  XTE-hLg4VTDN0KInkgjDB8mWbZk8s_YKtp7kk2w"},
      {
        "Container":"MMM_Credential",
        "Index":4,
        "Digest":"plYLtIgRdVJB82LEKiUn3rs9guARA9bnSf6eGOmmR5Wuj5u
  IEYhnL2q2v29mOD8SUZdYeL6f5CDLciY0onNHnw"},
      {
        "Container":"MMM_Device",
        "Index":3,
        "Digest":"Uxv1sKwhMiAPW9C6UFz8fa6hxsVIWg2V4SfNeiY7451Hguk
  vNZ-2tKcLAwUb1h8Vr1CclTvp6VahC-NZSnGwtQ"},
      {
        "Container":"MMM_Contact",
        "Index":2,
        "Digest":"E5cy6H92RWEXAYbMmbl5A590rKBETQd3YFkAy7A28rvtH8I
  pN4ewUA8KK5Lt_ZWL7dT5ILymkidLeW99pnRqbw"},
      {
        "Container":"MMM_Application",
        "Index":1,
        "Digest":"R4anFVpXdWUhO_RmILwy3oXpnEuqJ5g8pFNBozTARZXGNuw
  TX5IxX210ZYF5C6_N-F9Q6UOJNrz5n4ta0_IaMQ"},
      {
        "Container":"MMM_Publication",
        "Index":1,
        "Digest":"NJYOQsft6BrQXQc5qUWCsHgAhU-7n8suQOZnVs5laRaNTAY
  0OGTb2rgjWehKgf9F_4Em-1PWhOeUNmfeY2YNVA"},
      {
        "Container":"MMM_Bookmark",
        "Index":1,
        "Digest":"Wf_YvfuKlCCpmPo-FYoPXMxEX9-YI2xl6vUN_TSW8BRVIHy
  yvsEB86TohoxCVhdj0VvO47DOux-Z8hrgVGfz_A"},
      {
        "Container":"MMM_Task",
        "Index":1,
        "Digest":"uCUYDH2jYoeU_2j2ICR6AfhsxlaFKFLkxbXhOTsHp0d38Jo
  BI_zaCzf-2g9Ay7kyCieJWFAtHTsztVC8UBtVfQ"}
      ]}}
~~~~


Bug: The current version of the reference code is only returning the digest 
values for the outbound store.

