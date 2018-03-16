<h1>Organization

A user will typically acquire multiple recryption group rights and roles in the 
course of their work. This document describes the organization of these


By definition, each user has one Mesh Profile. If a person has more than one mesh
profile, it is because they are acting as two disting users as far as the Mesh is 
concerned. 

Alice has the Mesh Profile alice@mathmesh.com

A Mesh profile may have multiple recryption profiles associated with it.

Alice has Recryption profiles alice@prismproof.org and alice@example.com

When creating a recryption profile, the tool creates entries at two separate services

alice@mathmesh.com: Add the RecryptionProfile to the PersonalProfile
    The mesh profile contains all the information that is being made public and
    all the information that is being shared between Alice's devices.

alice@prismproof.org: Create the Account
    This is the service to which administrators will direct notifications that
    alice has been added or deleted from a recryption group in the alice@prismproof.org
    role

When a recryption group is created, this is treated as an account on the recryption 
server.

people@prismproof.org: The recryption group
    Contains a list of authorized administrators, keys, recryption pairs, etc.



<h2>The test example

Create Mesh Profile alice@portal.example.com
Create Recryption Profile alice@recrypt.example.com
    Add account to alice@recrypt.example.com
    Update profile to alice@portal.example.com

[Same for Bob, Carol]

Alice creates recryption group recrypt1@example.com
    Add account recrypt1@recrypt.example.com


To add bob@recrypt.example.com to recrypt1@example.com
    1) Get bob's account profile from recrypt.example.com
    2) Get bob's mesh profile from portal.example.com
    3) Create entries for the devices listed in that profile
    4) Upload update to recrypt.example.com

For bob to delete a device
    1) Post the request to recrypt1@recrypt.example.com
    2) Server deletes.. done

For bob to add a device
    1) Post the request to recrypt1@recrypt.example.com
    2) Alice retreives pending requests
    3) Alice processes requests and creates entries
    4) Upload update to recrypt.example.com

So the Mesh profile is only ever used to read data, it 
is not written to by the recryption system except when adding a new recryption profile

