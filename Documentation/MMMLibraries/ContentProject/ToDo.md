<id>0695f76e-4221-4514-aa03-e49c20375202
<version>1
<contenttype>developerConceptualDocument

To do list


#Mesh Services

The biggest weakness in the design right now is that there is no authentication or authorization of
service requests or responses. This needs to be fixed by reimplementing the ticket system and 
writing it up in Json Web Service Binding.

##Encryption Format

Need to implement a new encryption format in JSON-ish encoding. This will probably entail 
an extension of JSON-B

##Efficiency

Implement JSON-B

##Discovery

Implement TXT handling in the discovery mechanism.


#Mesh/Mail

Need to integrate to Microsoft Outlook and to document how to drop a key file out
of the tool so as to push into thunderbird, etc.


#Mesh/SSH

Need to get the code polished and integrated so it generates the right files. 

This is gated on getting the unix build set up.


#Mesh/Recrypt

<ul>
<li>Need a mechanism to tell a user that they have a membership of a group and some
means of tracking all the groups a user knows that they are a member of. Perhaps the 
simplest approach would be to store this information at each of the recryption 
services that they subscribe to. This would allow a government worker who is in 
50 groups to just subscribe to maybe 3 services.

<li>Need to make use of the incremental log file format.
</ul>


#Mesh/Proxy

Client side proxy that intercepts all outbound SMTP and HTTP connections allowing
a transparent upgrade to support Mesh/Recrypt and Mesh/Mail
