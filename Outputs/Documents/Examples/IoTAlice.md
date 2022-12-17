
Alice adds an Internet connected Thermostat to her home. The thermostat has a built in Web
server to allow the settings to be set by a Web browser. During the onboarding process, the
thermostat is assigned a domain name {Policies.ThermostatDns}

Alice's Mesh Service Provider maintains an authoritative DNS server for Alice's Callsign
DNS zone {Policies.AliceDns}. The IP addresses of this server are specified in the callsign
registration of her Mesh Service Provider:

~~~~
{
  "Callsign":{
    "Id":"provider",
    "Presentation":"provider",
    "Holder":"MC33-EPHG-GILF-YB7P-RQF4-DPWZ-TRYY",
    "Service":"@provider",
    "Dns":["10.2.1.1",
      "10.2.1.2",
      "2001:db8::1001"
      ]}}
~~~~

The authoritative DNS server publishes a link from which a Mesh DNS Profile specifying the
security policy for the zone MAY be obtained:

~~~~
[This is probably a prefixed TXT record of some sort.]
~~~~

The security policy for the zone states that the DNS zone is signed using DNSSEC and 
the thermostat supports TLS/1.2 transport layer security:

~~~~
{
  "ProfileDns":{
    "SecurityPolicies":[{
        "CName":["alice.mesh"
          ],
        "Protocol":["dns"
          ],
        "Enhancements":["dnssec"
          ],
        "Roots":[{
            "Udf":"MBHS-EKNA-7EJZ-VMUQ-HI5U-4FH3-RV3T",
            "PublicParameters":{
              "PublicKeyECDH":{
                "crv":"Ed448",
                "Public":"p0H30Oh6fm2HxxcYTqhWNJGLUHD7SQgBHjtRUIE
  zdCGDzAo9ytlAgDwQ_0UT6uF3jBWSnqmJtxMA"}}}
          ]},
      {
        "CName":["hvac.alice.mesh"
          ],
        "Protocol":["http",
          "https"
          ],
        "Enhancements":["tls1.2"
          ],
        "Require":true,
        "Roots":[{
            "Udf":"MBHS-EKNA-7EJZ-VMUQ-HI5U-4FH3-RV3T",
            "PublicParameters":{
              "PublicKeyECDH":{
                "crv":"Ed448",
                "Public":"p0H30Oh6fm2HxxcYTqhWNJGLUHD7SQgBHjtRUIE
  zdCGDzAo9ytlAgDwQ_0UT6uF3jBWSnqmJtxMA"}}}
          ]}
      ]}}
~~~~

A non Mesh-aware browser can access the Web site and establish a TLS connection to the 
thermostat provided that 1) the browser uses a DNS service that supports use of Mesh callsign
zones and 2) the device provides a certificate set that allows the browser to build a 
valid path to a root it trusts.

A Mesh aware browser can access the Web site directly and enforce the security policy
directly. Thus preventing a downgrade attack to an insecure site.

