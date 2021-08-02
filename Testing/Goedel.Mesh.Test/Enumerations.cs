namespace Goedel.Mesh.Test {




    public enum ContentEnhancement {

        // *** Encryption mode

        ///<summary>Content stored as plaintext.</summary>
        Plaintext = 0b_0000_0000,

        ///<summary>Each envelope is encrypted under a separate key agreement.</summary>
        EncryptIndividual = 0b_0000_0001,

        ///<summary>All envelopes are encrypted under a common key agreement specified in 
        ///frame zero.</summary>
        EncryptCommon = 0b_0000_0010,

        ///<summary>All envelopes are encrypted. A fresh key agreement is performed at
        ///intervals but not for every addition.</summary>
        EncryptIncremental = 0b_0000_0011,

        // *** Encryption scope
        ///<summary>The envelopes contain only content</summary>
        ContentOnly = 0b_0000_0000,

        ///<summary>The envelopes contaion content and EDS sequences.</summary>
        ContentEDS = 0b_0001_0000,


        // *** Signature mode
        ///<summary>The content is not authenticated.</summary>
        Unsigned = 0b_0000_0000_0000,

        ///<summary>The content is authenticated under a digest.</summary>
        Digest = 0b_0001_0000_0000,

        ///<summary>Each envelope is signed under a separate signature.</summary>
        SignedIndividual = 0b_0010_0000_0000,

        ///<summary>The sequence is signed by periodically signing the apex digest value.</summary>
        SignedIncremental = 0b_0011_0000_0000,


        // *** Signature scope
        ///<summary>The signature scope only covers the envelope body.</summary>
        SignBodyOnly = 0b_0000_0000_0000_0000,

        ///<summary>The signature scope covers the envelope body and content metadata.</summary>
        SignBodyContentMeta = 0b_0001_0000_0000_0000,

        }

    public enum AccessPattern {
        ///<summary>The data is valid</summary>
        All,

        ///<summary>The data is valid</summary>
        First,

        ///<summary>The data is valid</summary>
        Last,

        ///<summary>The data is valid</summary>
        Forward,

        ///<summary>The data is valid</summary>
        Backwards,

        ///<summary>The data is valid</summary>
        Random
        }





    }
