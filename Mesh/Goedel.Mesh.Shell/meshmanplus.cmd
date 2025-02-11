

	CommandSet Callsign "callsign"
		Command CallsignRegister "register"
			Brief "Register a callsign"
			Parameter Identifier "id" String
				Brief "The callsign to register in requested presentation form"
			Include AccountOptions
			Include Reporting

		Command CallsignBind "bind"
			Brief "Bind a registered callsign to an account"
			Parameter Identifier "id" String
				Brief "The callsign to bind"
			Include AccountOptions
			Include Reporting

		Command CallsignResolve "resolve"
			Brief "Request callsign resolution."
			Parameter Identifier "id" String
				Brief "The callsign to resolve"
			Include AccountOptions
			Include Reporting
		
		Command CallsignTransfer "transfer"
			Brief "Transfer a callsign to another user."
			Parameter Identifier "id" String
				Brief "The callsign to bind"
			Parameter Recipient "recipient" String
				Brief "The recipient to send the callsign to"
			Include AccountOptions
			Include Reporting
		
		Command CallsignStatus "status"
			Brief "Report callsign registration status."
			Parameter Identifier "id" String
				Brief "The callsign to resolve"
			Include AccountOptions
			Include Reporting
		
		Command CallsignList "list"
			Brief "List callsign registrations."
			Include AccountOptions
			Include Reporting



	CommandSet Wallet "wallet"
		Command WalletInvoice "invoice"
			Brief "Send a request for payment."
			Parameter Recipient "recipient" String
				Brief "The recipient to send the confirmation request to"
			Parameter Invoice "message" ExistingFile
				Brief "The invoice text"
			Parameter Currency "currency" String
				Brief "The payment currency"
			Parameter Amount "amount" String
				Brief "The payment amount"
			Parameter Reason "reason" String
				Brief "The reason for the payment request"
			Include AccountOptions
			Include Reporting

		Command WalletTransfer "transfer"
			Brief "Transfer a token to another user."
			Parameter Recipient "recipient" String
				Brief "The recipient to send the confirmation request to"
			Parameter Currency "currency" String
				Brief "The payment currency"
			Parameter Amount "amount" String
				Brief "The payment amount"
			Parameter Reason "reason" String
				Brief "The reason for the transfer"
			Include AccountOptions
			Include Reporting

		Command WalletAccept "accept"
			Brief "Accept an invoice and make payment"
			Parameter MessageId "message" String
				Brief "The invoice message id"
			Include AccountOptions
			Include Reporting

		Command WalletReject "reject"
			Brief "Accept an invoice and make payment"
			Parameter MessageId "message" String
				Brief "The invoice message id"
			Include AccountOptions
			Include Reporting

		Command WalletRedeem "redeem"
			Brief "Redeem an invoice payment"
			Parameter MessageId "message" String
				Brief "The payment message id to redeem"
			Include AccountOptions
			Include Reporting

		Command WalletList "list"
			Brief "List wallet entries"
			Include AccountOptions
			Include Reporting

		Command WalletDelete "delete"
			Brief "Delete wallet entry"
			Parameter Identifier "id" String
				Brief "Wallet entry identifier"
			Include AccountOptions
			Include Reporting

		Command WalletkGet "get"
			Brief "Lookup wallet entry"
			Parameter Identifier "id" String
				Brief "Local identifier"
			Include AccountOptions
			Include Reporting



	CommandSet Chat "chat"
		Command ChatMessage "message"

		Command ChatListen "listen"
			Option Quantum "quantum" Integer
				Brief "The value of each ticket"	

		Command ChatPoll "poll"

