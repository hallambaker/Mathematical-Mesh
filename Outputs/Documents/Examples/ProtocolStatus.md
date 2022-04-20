
Alice adds an entry to her bookmark catalog. Before the bookmark can be 
added, the device synchronizes to the service. The synchronization process
begins with a request for the status of all the stores associated with the 
account that it has access rights for:


~~~~
{
  "StatusRequest":{
    "CatalogedDeviceDigest":"MBD2-CX3T-MAHB-323R-ZKPE-V23R-4O"}}
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
        "Digest":"af-ZCV48K2pp8D8_a7t2Zovpj0Rg083JVQ9FSptSqzHwAwS
  DEv6Q7qd3UJAj5xcHgN8-uixxRM62NP7MDZwZIA"},
      {
        "Container":"MMM_Credential",
        "Index":4,
        "Digest":"xIiGmicJxjUJWEjWM6nqwKIG0Hmotr9pjFxTEFXeCCW1klZ
  VWj4rJv1X4byJvxplJwtGVWYph9YEi0ZMFrNkRw"},
      {
        "Container":"MMM_Device",
        "Index":3,
        "Digest":"AfExhtW64TJvmpW9Lrh5uf8jURFrFTc62FYgffU3IPowOdl
  3HV5gHYxGB-Pucpaco7vowCEqRjqeP5dTMOQzFw"},
      {
        "Container":"MMM_Contact",
        "Index":2,
        "Digest":"VSDUsxoQIIMuSLTVgeEO2QTpGweYanJ86nDrdUMPm0CDX4m
  PVP_8UWAtWdm6HMmpvQ7Pm11pgDUYSNOF72Cofg"},
      {
        "Container":"MMM_Application",
        "Index":1,
        "Digest":"BWJ7_IbH7vcOI-CR-oGpqIXdQz50rPbmGsZvOiL1dqKe9lW
  QJSh5tKElz9TAQRT0EG7G0kOZ2mCqiP_yGZAN3A"},
      {
        "Container":"MMM_Publication",
        "Index":1,
        "Digest":"xDBR1MLSGbMcgX1mjMyT-XEKgTXG8j8v4pNhOfHkZTp_xfm
  3oEWvudSi0dO-varqqX_iwrHFJD9wxWWjfNThAA"},
      {
        "Container":"MMM_Bookmark",
        "Index":1,
        "Digest":"vKaVPfFoa-c_h0XyyLmN5Fb1C0mgFogLo80vb-qu4r0xFUx
  wCJ5qGqObbaxLxK8a7_sSZ88SV8McU1NWl7BS3w"},
      {
        "Container":"MMM_Task",
        "Index":1,
        "Digest":"Od-7rQgE-8X-Dr1oIAgkhuKm5NMc85RIOnFLlJmqskwy3yO
  YoWzorX-aUve1rKPmnBCmbAhDUhHEGo_wUP-kJQ"}
      ]}}
~~~~


Bug: The current version of the reference code is only returning the digest 
values for the outbound store.

