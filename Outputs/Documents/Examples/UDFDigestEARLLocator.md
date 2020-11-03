The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EA2M-ID6J-U55P-2VUV-E2NG-QQEX-MXUT-6L) =
MC4D-X4XD-VVFD-GSHL-WEWV-SRII-LPTN-37XA-XSMI-IYEI-P6GT-PHND-QMVD-UID3
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MC4D-X4XD-VVFD-GSHL-WEWV-SRII-LPTN-37XA-XSMI-IYEI-P6GT-PHND-QMVD-UID3


