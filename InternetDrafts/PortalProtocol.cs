Internet Engineering Task Force (IETF)                   January 4, 2016
INTERNET-DRAFT
Intended Status: 
Expires: July 7, 2016


                                 Title
                           ietf-draft-TBS-00

Abstract

Status of This Memo

   This Internet-Draft is submitted in full conformance with the 
   provisions of BCP 78 and BCP 79.

   Internet-Drafts are working documents of the Internet Engineering 
   Task Force (IETF).  Note that other groups may also distribute 
   working documents as Internet-Drafts.  The list of current Internet-
   Drafts is at http://datatracker.ietf.org/drafts/current/.

   Internet-Drafts are draft documents valid for a maximum of six months
   and may be updated, replaced, or obsoleted by other documents at any 
   time.  It is inappropriate to use Internet-Drafts as reference 
   material or to cite them other than as "work in progress."

Copyright Notice

   Copyright (c) 2016 IETF Trust and the persons identified as the 
   document authors.  All rights reserved.

   This document is subject to BCP 78 and the IETF Trust's Legal 
   Provisions Relating to IETF Documents 
   (http://trustee.ietf.org/license-info) in effect on the date of 
   publication of this document. Please review these documents 
   carefully, as they describe your rights and restrictions with respect
   to this document. Code Components extracted from this document must 
   include Simplified BSD License text as described in Section 4.e of 
   the Trust Legal Provisions and are provided without warranty as 
   described in the Simplified BSD License.
















                              July 7, 2016                      [Page 1]

Internet-Draft                   Title                      January 2016

Table of Contents

    . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .  3
   Portal Transactions  . . . . . . . . . . . . . . . . . . . . . . .  3
   Portal Messages  . . . . . . . . . . . . . . . . . . . . . . . . .  3
   Portal Structures  . . . . . . . . . . . . . . . . . . . . . . . .  3
   Structure: PortalEntry   . . . . . . . . . . . . . . . . . . . . .  3
   Structure: Account   . . . . . . . . . . . . . . . . . . . . . . .  3
   Structure: AccountProfile  . . . . . . . . . . . . . . . . . . . .  4
   Structure: ConnectionsPending  . . . . . . . . . . . . . . . . . .  4












































                              July 7, 2016                      [Page 2]

Internet-Draft                   Title                      January 2016


Portal Transactions 

Portal Messages 

Portal Structures 

Structure: PortalEntry 

         Created : 
            DateTime [0..1] 

   Time the pending item was created. 

         Modified : 
            DateTime [0..1] 

   Time the pending item was last modified. 

Structure: Account 

   Entry containing the  UniqueID is Account[Name]-[Portal] Indexed by 
   [Name], [UserProfileUDF] [Most recent open] 

         Created : 
            DateTime [0..1] 

   Time the pending item was created. 

         Modified : 
            DateTime [0..1] 

   Time the pending item was last modified. 

         AccountID : 
            String [0..1] 

   Assigned account identifier, e.g. 'alice@example.com'. Account names 
   are  not case sensitive. 

         UserProfileUDF : 
            String [0..1] 

   Fingerprint of associated user profile 

         Status : 
            String [0..1] 

   Status of the account, valid values are 'Open', 'Closed', 'Suspended'





                              July 7, 2016                      [Page 3]

Internet-Draft                   Title                      January 2016

Structure: AccountProfile 

         Created : 
            DateTime [0..1] 

   Time the pending item was created. 

         Modified : 
            DateTime [0..1] 

   Time the pending item was last modified. 

         AccountID : 
            String [0..1] 

   Assigned account identifier, e.g. 'alice@example.com'. Account names 
   are  not case sensitive. 

         UserProfileUDF : 
            String [0..1] 

   Fingerprint of associated user profile 

         Status : 
            String [0..1] 

   Status of the account, valid values are 'Open', 'Closed', 'Suspended'

         Profile : 
            SignedPersonalProfile [0..1] 

   [TBS] 

Structure: ConnectionsPending 

   Object containing the list of currently pending device connection 
   requests for the specified account.  Unique-ID is ConnectionsPending-
   [UserProfileUDF] 

         Created : 
            DateTime [0..1] 

   Time the pending item was created. 

         Modified : 
            DateTime [0..1] 








                              July 7, 2016                      [Page 4]

Internet-Draft                   Title                      January 2016

   Time the pending item was last modified. 

         AccountID : 
            String [0..1] 

   Assigned account identifier, e.g. 'alice@example.com'. Account names 
   are  not case sensitive. 

         UserProfileUDF : 
            String [0..1] 

   Fingerprint of associated user profile 

         Status : 
            String [0..1] 

   Status of the account, valid values are 'Open', 'Closed', 'Suspended'

         Requests : 
            SignedConnectionRequest [0..Many] 

   List of pending requests 
































                              July 7, 2016                      [Page 5]
