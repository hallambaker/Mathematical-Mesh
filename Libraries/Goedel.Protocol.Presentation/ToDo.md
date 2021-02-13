# Flows


## Initial-Immediate

Client->Host:   Initial
    ClientEphemeral
    Payload

Host->Client: HostExchange
    Extension: HostCredentials
    Extension: HostEphemerals
    Encrypt (ClientEphemeral.HostCredential)
        Payload

Client->Host: ClientComplete
    Encrypt (ClientEphemeral.HostCredential)
        ClientCredential
        Encrypt (ClientEphemeral.HostCredential+HostEphemeral.ClientCredential)
            Payload
        Padding

## Initial-Deferred

Client->Host:   Initial
    ClientEphemeral
    Payload

Host->Client: HostChallenge
    Extension: Challenge
    HostCredential
    HostEphemeral
    Payload

Client->Host: ClientComplete
    Extension: Answer
    Encrypt (ClientEphemeral.HostCredential)
        ClientCredential
        Encrypt (ClientEphemeral.HostCredential+HostEphemeral.ClientCredential)
            Payload
        Padding

## ClientExchange-Immediate [HostCredential ]

Client->Host:   ClientExchange
    ClientEphemeral
    Encrypt (ClientEphemeral.HostCredential)
        ClientCredential
        Payload


Host->Client: HostComplete
    HostEphemeral
    Encrypt (ClientEphemeral.HostCredential+HostEphemeral.ClientCredential)
        Payload

## ClientExchange-Deferred  [HostCredential]

Client->Host:   ClientExchange 
    ClientEphemeral
    Encrypt (ClientEphemeral.HostCredential)
        ClientCredential
        Payload

Host->Client: HostChallenge
    Extension: Challenge
    HostEphemeral
    Payload

Client->Host: ClientComplete
    Extension: Answer
    Encrypt (ClientEphemeral.HostCredential)
        ClientCredential
        Encrypt (ClientEphemeral.HostCredential+HostEphemeral.ClientCredential)
            Payload
        Padding