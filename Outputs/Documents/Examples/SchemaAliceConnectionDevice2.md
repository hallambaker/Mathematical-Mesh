
The ConnectionDevice assertion is used by the device to authenticate it to other 
devices connected to the account. This connection assertion specifies the
Encryption, Authentication, and Signature keys the device is to use in the context of
the account and the list of roles that have been authorized for the device..

~~~~
{
  "ConnectionDevice":{
    "Authentication":{
      "Udf":"MATM-JRGO-RVHK-YUI3-2YMW-GQZI-HWVH",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"zD5w7SAL4Bz2JZo7urN58bgS057ldoz6zFr8yD_XzPbVr
  yvdgTFETSxOpbtrxgeUslyOpdjEZwoA"}}},
    "Roles":["message",
      "web"
      ],
    "Signature":{
      "Udf":"MBIR-6RB4-2ZMR-SUV3-DU5O-2FWT-PK3O",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"JmWVO9NUWfWPEN_5lkd7VuFemLRXr5Ca-64fn4sXqjeYN
  ACm4ZSbjV3NbXdaneOcur6Umfa6jQoA"}}},
    "Encryption":{
      "Udf":"MCFN-WQTF-JQUN-MU73-FZOS-Q73Q-I7SC",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"dVsvLz-Xo0Yk3LEMoCxMZwqYrRE6w2rdD3bnE8cGtjgGE
  BfSS8rDZ5MEk9C1A2pBQZV1ZU8objQA"}}}}}
~~~~

The ConnectionService assertion is used to authenticate the device to the 
Mesh service. In order to allow the assertion to fit in a single packet, it
is important that this assertion be as small as possible. Only the 
Authentication key is specified.

The corresponding ConnectionService assertion is:

~~~~
{
  "ConnectionService":{
    "Authentication":{
      "Udf":"MATM-JRGO-RVHK-YUI3-2YMW-GQZI-HWVH",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"zD5w7SAL4Bz2JZo7urN58bgS057ldoz6zFr8yD_XzPbVr
  yvdgTFETSxOpbtrxgeUslyOpdjEZwoA"}}}}}
~~~~

