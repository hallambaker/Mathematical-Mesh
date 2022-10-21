
Alice adds an entry to her bookmark catalog. Before the bookmark can be 
added, the device synchronizes to the service. The synchronization process
begins with a request for the status of all the stores associated with the 
account that it has access rights for:


~~~~
{
  "StatusRequest":{
    "CatalogedDeviceDigest":"MAC5-ZJWC-FFYC-2KIO-YYOE-OO43-OZ"}}
~~~~


If the account has a very large number of stores, the device might only 
ask for the status of specific stores of interest.

The response specifies the status of each store specifying the index and
Merkle tree apex digest values for each:


~~~~
{
  "StatusResponse":{
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
        "Digest":"r5IajJWI1RhTXt1j2_O75SUzphUMofZvSyfO5kLWLh20OGp
  kLPsCcCEXprd0_QVPMr4PxBO6Mg7cS-WsOlumJw"},
      {
        "Container":"MMM_Credential",
        "Index":4,
        "Digest":"aNMogtuGtBohOUNSCfPXDNONUz5BQ86TNDOfE_HZ5zi2Bw_
  FWQik3E1qWyXFi-GuWipin-bJuFPJ2JPu-mIj4w"},
      {
        "Container":"MMM_Device",
        "Index":3,
        "Digest":"qg4Zf_QebDEnR4kPOfPnQQiNmEhW0G01F8aJR83z5ibKUvK
  cImrRFGTTRDIN2sRNKJZ6HSoAL0Wr1wzEj9NtVQ"},
      {
        "Container":"MMM_Contact",
        "Index":2,
        "Digest":"urm7SZRuU2rWHYs-eoxZLg_WI4Hs4ICidDe_RM-GC__aANA
  P8OKAEx5Bu_SN-P77U1h63JkQpDDeUtOrvn_qLw"},
      {
        "Container":"MMM_Application",
        "Index":1,
        "Digest":"nljVIfu_F6lHDSSYn8dYdpE_QMBgs2KBSP4sI6E8vTA0E5X
  4fJZHS8TVzCVIEL7urcVdLxcB0eeoPO82fYhyuQ"},
      {
        "Container":"MMM_Publication",
        "Index":1,
        "Digest":"XhOEeG1waPc8GRUl1BI_dDoKQnXkaS9Jz16V1Ow5caT9WUL
  1W2YU-z6_CxDafc7JfSwXfdYDv62sVyYwFq5Ieg"},
      {
        "Container":"MMM_Bookmark",
        "Index":1,
        "Digest":"VuysvMaN2_bZXrJuQ-gYpfCHKN-gM7XlRBIkNLY_fB25hu7
  hzdCWMWxgwHK-3KVNMWFC-I8jYYgZxmIOgfVWyQ"},
      {
        "Container":"MMM_Task",
        "Index":1,
        "Digest":"pbjJC7NvIJQF5ke1bpO65uvTe1zvFpur_XK4ddy61dInDLh
  ulURJU9cEsScpMrdkxU7rNxN0i-RGRq5RL3ALFA"}
      ],
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


Bug: The current version of the reference code is only returning the digest 
values for the outbound store.

