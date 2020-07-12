
//using System;
//using Goedel.Utilities;



namespace Goedel.Cryptography.Jose {


    /// <summary>
    /// An internal error occurred. This error cannot be recovered from.
    /// </summary>
    [global::System.Serializable]
	public partial class InternalError : global::Goedel.Utilities.GoedelException {


		///<summary>The message template in the current locale.</summary>
		public static new string MessageTemplate => "An internal error occurred";

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public InternalError  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (description ?? global::System.String.Format(MessageTemplate, args), inner) {
			}




		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _ThrowNew;

        static System.Exception _ThrowNew(object reasons) => new InternalError(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;

        static System.Exception _Throw(object reason) {
			if (reason as string != null) {
				return new InternalError(reason as string);
				}
			else {
				return new InternalError();
				}
            }
        }


	}
