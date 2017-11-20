
Goedel.Recrypt.Server Namespace

RecryptStore class

	GetUserDecryptionEntry method
			in GroupKeyID string
			in MemberID string
			in MemberKeyUDF string 
			return UserDecryptionEntry UserDecryptionEntry

		UserDecryptionEntry = null

		UDF.ParseStrongRFC822(GroupKeyID, out var GroupName, out var EncryptionKeyUDF)

		RecryptionGroup = GetGroup(GroupName)
        require (RecryptionGroup != null)

		MemberEntry = GetMember(RecryptionGroup, MemberID)
        require (MemberEntry != null)

        UserDecryptionEntry = GetUserDecryptionEntry(MemberEntry, EncryptionKeyUDF, MemberKeyUDF)


