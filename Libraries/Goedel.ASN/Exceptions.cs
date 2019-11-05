namespace Goedel.ASN {


    /// <summary>
    /// An error occurred in the decoding of presumed ASN.1 binary data.
    /// </summary>
    public class ASNDecodingException : global::System.Exception {

        /// <summary>
        /// Construct instance for exception "An ASN.1 Decoding exception occurred"
        /// </summary>		
        public ASNDecodingException() : base("An ASN.1 Decoding exception occurred") {
            }

        /// <summary>
        /// Construct instance for exception "An ASN.1 Decoding exception occurred"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        public ASNDecodingException(string Description) : base(Description) {
            }

        /// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        /// <param name="Inner">Inner Exception</param>	
        public ASNDecodingException(string Description, System.Exception Inner) :
                base(Description, Inner) {
            }

        /// <summary>
        /// User data associated with the exception.
        /// </summary>	
        public object UserData;




        /// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
            if (Reason as string != null) {
                return new ASNDecodingException(Reason as string);
                }
            else {
                return new ASNDecodingException();
                }
            }
        }


    /// <summary>
    /// The data could not be decoded due to an implementation restriction
    /// in the decoder. This should not happen when attempting to decode
    /// legitimate inputs for the intended field of use.
    /// </summary>
    public class Implementation : ASNDecodingException {

        /// <summary>
        /// Construct instance for exception "Implementation restriction"
        /// </summary>		
        public Implementation() : base("Implementation restriction") {
            }

        /// <summary>
        /// Construct instance for exception "Implementation restriction"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        public Implementation(string Description) : base(Description) {
            }

        /// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        /// <param name="Inner">Inner Exception</param>	
        public Implementation(string Description, System.Exception Inner) :
                base(Description, Inner) {
            }





        /// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
            if (Reason as string != null) {
                return new Implementation(Reason as string);
                }
            else {
                return new Implementation();
                }
            }
        }


    /// <summary>
    /// A length specification was invalid.
    /// </summary>
    public class InvalidLength : ASNDecodingException {

        /// <summary>
        /// Construct instance for exception "Length invalid"
        /// </summary>		
        public InvalidLength() : base("Length invalid") {
            }

        /// <summary>
        /// Construct instance for exception "Length invalid"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        public InvalidLength(string Description) : base(Description) {
            }

        /// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        /// <param name="Inner">Inner Exception</param>	
        public InvalidLength(string Description, System.Exception Inner) :
                base(Description, Inner) {
            }





        /// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
            if (Reason as string != null) {
                return new InvalidLength(Reason as string);
                }
            else {
                return new InvalidLength();
                }
            }
        }


    /// <summary>
    /// An indefinite length was specified in a context where it is not
    /// permitted. For example, a DER encoded item.
    /// </summary>
    public class IndefiniteLengthInvalid : ASNDecodingException {

        /// <summary>
        /// Construct instance for exception "Indefinite length not valid"
        /// </summary>		
        public IndefiniteLengthInvalid() : base("Indefinite length not valid") {
            }

        /// <summary>
        /// Construct instance for exception "Indefinite length not valid"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        public IndefiniteLengthInvalid(string Description) : base(Description) {
            }

        /// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        /// <param name="Inner">Inner Exception</param>	
        public IndefiniteLengthInvalid(string Description, System.Exception Inner) :
                base(Description, Inner) {
            }





        /// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
            if (Reason as string != null) {
                return new IndefiniteLengthInvalid(Reason as string);
                }
            else {
                return new IndefiniteLengthInvalid();
                }
            }
        }


    /// <summary>
    /// The declared length of an item exceeds the available data.
    /// This typically happens if the data item has been truncated
    /// or a malicious payload is attempting a buffer overflow attack.
    /// </summary>
    public class LengthExceedsInput : ASNDecodingException {

        /// <summary>
        /// Construct instance for exception "Length exceeds data input"
        /// </summary>		
        public LengthExceedsInput() : base("Length exceeds data input") {
            }

        /// <summary>
        /// Construct instance for exception "Length exceeds data input"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        public LengthExceedsInput(string Description) : base(Description) {
            }

        /// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        /// <param name="Inner">Inner Exception</param>	
        public LengthExceedsInput(string Description, System.Exception Inner) :
                base(Description, Inner) {
            }





        /// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
            if (Reason as string != null) {
                return new LengthExceedsInput(Reason as string);
                }
            else {
                return new LengthExceedsInput();
                }
            }
        }


    /// <summary>
    /// The length of an inner length encoded item exceeds that of the
    /// enclosing item. This means that either the data is not ASN.1,
    /// the data has been corrupted or is a malicious payload intended to
    /// perform a buffer overflow attack.
    /// </summary>
    public class LengthExceedsStructure : ASNDecodingException {

        /// <summary>
        /// Construct instance for exception "Length exceeds current structure"
        /// </summary>		
        public LengthExceedsStructure() : base("Length exceeds current structure") {
            }

        /// <summary>
        /// Construct instance for exception "Length exceeds current structure"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        public LengthExceedsStructure(string Description) : base(Description) {
            }

        /// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        /// <param name="Inner">Inner Exception</param>	
        public LengthExceedsStructure(string Description, System.Exception Inner) :
                base(Description, Inner) {
            }





        /// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
            if (Reason as string != null) {
                return new LengthExceedsStructure(Reason as string);
                }
            else {
                return new LengthExceedsStructure();
                }
            }
        }


    /// <summary>
    /// A sequence of items was expected.
    /// </summary>
    public class ExpectedSequence : ASNDecodingException {

        /// <summary>
        /// Construct instance for exception "Expected Sequence"
        /// </summary>		
        public ExpectedSequence() : base("Expected Sequence") {
            }

        /// <summary>
        /// Construct instance for exception "Expected Sequence"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        public ExpectedSequence(string Description) : base(Description) {
            }

        /// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        /// <param name="Inner">Inner Exception</param>	
        public ExpectedSequence(string Description, System.Exception Inner) :
                base(Description, Inner) {
            }





        /// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
            if (Reason as string != null) {
                return new ExpectedSequence(Reason as string);
                }
            else {
                return new ExpectedSequence();
                }
            }
        }


    /// <summary>
    /// Data was encountered in an unexpected location.
    /// </summary>
    public class UnExpectedData : ASNDecodingException {

        /// <summary>
        /// Construct instance for exception "Unexpected Data"
        /// </summary>		
        public UnExpectedData() : base("Unexpected Data") {
            }

        /// <summary>
        /// Construct instance for exception "Unexpected Data"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        public UnExpectedData(string Description) : base(Description) {
            }

        /// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        /// <param name="Inner">Inner Exception</param>	
        public UnExpectedData(string Description, System.Exception Inner) :
                base(Description, Inner) {
            }





        /// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
            if (Reason as string != null) {
                return new UnExpectedData(Reason as string);
                }
            else {
                return new UnExpectedData();
                }
            }
        }


    /// <summary>
    /// An integer was expected.
    /// </summary>
    public class ExpectedInteger : ASNDecodingException {

        /// <summary>
        /// Construct instance for exception "Expected Integer"
        /// </summary>		
        public ExpectedInteger() : base("Expected Integer") {
            }

        /// <summary>
        /// Construct instance for exception "Expected Integer"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        public ExpectedInteger(string Description) : base(Description) {
            }

        /// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        /// <param name="Inner">Inner Exception</param>	
        public ExpectedInteger(string Description, System.Exception Inner) :
                base(Description, Inner) {
            }





        /// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
            if (Reason as string != null) {
                return new ExpectedInteger(Reason as string);
                }
            else {
                return new ExpectedInteger();
                }
            }
        }


    /// <summary>
    /// The size of an integer exceeds the implementation limit. This
    /// is unlikely to occur in normal use.
    /// </summary>
    public class IntegerOverflow : ASNDecodingException {

        /// <summary>
        /// Construct instance for exception "Integer too large"
        /// </summary>		
        public IntegerOverflow() : base("Integer too large") {
            }

        /// <summary>
        /// Construct instance for exception "Integer too large"
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        public IntegerOverflow(string Description) : base(Description) {
            }

        /// <summary>
        /// Construct instance for exception 		/// containing an inner exception.
        /// </summary>		
        /// <param name="Description">Description of the error</param>	
        /// <param name="Inner">Inner Exception</param>	
        public IntegerOverflow(string Description, System.Exception Inner) :
                base(Description, Inner) {
            }





        /// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object Reason) {
            if (Reason as string != null) {
                return new IntegerOverflow(Reason as string);
                }
            else {
                return new IntegerOverflow();
                }
            }
        }


    }
