
A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.


~~~~
Missing example 21
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


The publication is found and the claim is accepted, the publication  is returned
in the response.


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

