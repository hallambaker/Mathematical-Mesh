
Alice added Bob to groupw@example.com as a member. This resulted in Bob receiving the
invitation described in section ??? and the following access entry being added
to the Access catalog of the group account:

~~~~
{
  "CatalogedAccess":{
    "Capability":{
      "CapabilityDecryptServiced":{
        "Id":"MBMI-CCU4-T2BW-ZCOG-ZG4X-WQ43-CQ2S",
        "Active":true,
        "GranteeUdf":"bob@example.com",
        "EnvelopedKeyShare":[{
            "enc":"A256CBC",
            "kid":"EBQP-3JFZ-QC5K-4UYT-N554-2NVQ-GE7U",
            "Salt":"mKAjv2AotDNxttLS6zBAGw",
            "recipients":[{
                "kid":"MA7N-XF4O-SQ6T-ER7G-5II7-LRMJ-DZ2I",
                "epk":{
                  "PublicKeyECDH":{
                    "crv":"X448",
                    "Public":"ELUedfJzr4Pcfbyt7GPZ00Ibnpp3zVahVfw
  faMg1nMzJMflF-vcKxb_XxYfkkIjjlWNWRgzWyCYA"}},
                "wmk":"DqfMyM2wOz2lmgzlv943a7fMPXg1USHrsqMom34KmV
  2REyxAjljCmg"}
              ],
            "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJLZXlEYX
  RhIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhdGV
  kIjogIjIwMjEtMDktMjFUMDA6NTg6NTJaIn0"},
          "PFohosgje0GROMknQCpwscpiwQefODAiKv-c_Iyu_j225Lxx20RU_H
  pkjdcOH50g9Efeh5CNH1eu_tXr43CaN_4tcZJBOOqUIpGiurnWROwG_tnlCwinqea
  2kOKlZjNq3dWl0mGAZ-hI3U-6jRhuqYsYb38s1_A-AzHeHWH0t14JDh6N3EUQjIos
  g_LWzMEZs8vxdi9xkLwJsBMSJK4kf--YgLl0OfudbcT-8g_mACuMNilyav8GY3pEX
  ejd9Z_j532SGYn63K0JQMqMXzBNZx3OWNpqmANezYWKD4QCWuB-ra7oXwZg9rf_mo
  u4HGLDgjPLui7IoXmNjkFJDc2ohnau7jguUoQBAX9ciIFpbpiP8GQOb8hyD2GM264
  PUXDSFQY2ERDZnTCL1BoNfnVF2UduYJ4fcJZSY19dyldChdMOqKvDMjW1tWFfNV_t
  0ZPMNMLX3a9Bi2afrGzzAe7fW5SHCGzltak_3hOZEl2ma87A4ecGX0cKSVMoobnD0
  7IdQcWxcC0rAzygBDveoN4Q-eK8A-2W71DWDSTCtqFI9trDU6eEcICJClf4kOho_p
  MpwZRYBTaO68ZBowzYPcD7JoMI967BTbz3MZrFiPkOcqPnQ8UhbGydnKI_cLGbYPE
  -NjawaSPvZrtYPm-uUhWtT3n1CwT88OArj7s5rUE3vjFnnCVq-J0NNmB5HdVLB4GZ
  0X6e1VF7GwFuKWDT49toCA"
          ]}}}}
~~~~

The private key (in this case a key share) is encrypted under the service key.

To make use of the access entry, a request is made that specifies the key share
to be operated on and the public key parameters to perform the agreement with.

The request payload:


~~~~
{
  "OperateRequest":{
    "AccountAddress":"groupw@example.com",
    "Operations":[{
        "CryptographicOperationKeyAgreement":{
          "KeyId":"MBMI-CCU4-T2BW-ZCOG-ZG4X-WQ43-CQ2S",
          "PublicKey":{
            "PublicKeyECDH":{
              "crv":"X448",
              "Public":"hJphJ8ULXr1sqB-phunTBO4lMjU0VdBIFMMs00QSl
  3mpIkU5GkHqxAKo7RTHyvRFdUyVsxretcmA"}}}}
      ]}}
~~~~


The service checks to see if the request is authorized and if so, performs the
operation and returns the result:


~~~~
{
  "OperateResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "Results":[{
        "CryptographicResultKeyAgreement":{
          "KeyAgreement":{
            "KeyAgreementECDH":{
              "Curve":"X448",
              "Result":"6hjQDC-uMdEAtTVj7bwxo-OYqV6l-RqJR3Axki0qX
  cnrkDnP6RXUXFovNoIf7mruUlQICF-mn58A"}}}}
      ]}}
~~~~

