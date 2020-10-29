The UDF EARL locator shown above is resolved by first determining the Web Service
Endpoint for the mmm-udf service for the domain example.com.

~~~~
Discover ("example.com", "mmm-udf") = 
https://example.com/.well-known/mmm-udf/
~~~~

Next the fingerprint of the source UDF is obtained.

~~~~
UDF (EDOU-SBKJ-RKGI-SWL7-DRR3-OCOB-MPJW-X3) =
MBFZ-T2AJ-QFCO-MMGD-474E-YWBC-42AG-EFPM-SE3M-P6FZ-WSIU-VDGB-RCCL-RSD2
~~~~

Combining the Web Service Endpoint and the fingerprint of the source UDF provides
the URI from which the content is obtained using the normal HTTP GET method:

https://example.com/.well-known/mmm-udf/MBFZ-T2AJ-QFCO-MMGD-474E-YWBC-42AG-EFPM-SE3M-P6FZ-WSIU-VDGB-RCCL-RSD2


