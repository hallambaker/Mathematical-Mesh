
//  This file was automatically generated at 7/9/2021 4:44:07 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  exceptional version 3.0.0.658
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2019
//  
//  Build Platform: Win32NT 10.0.18362.0
//  
//  

//using System;
//using Goedel.Utilities;



#pragma warning disable IDE1006 // Naming Styles
namespace Goedel.Protocol {




    /// <summary>
    /// The packet was too small to contain the data
    /// </summary>
    [global::System.Serializable]
	public partial class PacketSizeExceeded : global::Goedel.Utilities.GoedelException {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
				global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


		///<summary>Templates for formatting response messages.</summary>
		public static new System.Collections.Generic.List<string> Templates {get; set;} = 
				new () {

				"The packet was too small to contain the data."
				};

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public PacketSizeExceeded  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        /// public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new PacketSizeExceeded(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


        }


    /// <summary>
    /// The client is in an invalid state for the requested operation.
    /// </summary>
    [global::System.Serializable]
	public partial class InvalidClientState : global::Goedel.Utilities.GoedelException {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
				global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


		///<summary>Templates for formatting response messages.</summary>
		public static new System.Collections.Generic.List<string> Templates {get; set;} = 
				new () {

				"The client is in an invalid state for the requested operation."
				};

		/// <summary>
		/// Construct instance for exception
		/// </summary>		
		/// <param name="description">Description of the error, may be used to override the 
		/// generated message.</param>	
		/// <param name="inner">Inner Exception</param>	
		/// <param name="args">Optional list of parameterized arguments.</param>
		public InvalidClientState  (string description=null, System.Exception inner=null,
			params object[] args) : 
				base (ExceptionFormatDelegate(description, Templates,
					null, args), inner) {
			}





		/// <summary>
        /// The public fatory delegate
        /// </summary>
        /// public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new InvalidClientState(args:reasons) ;
		
		/// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw {get;} = _Throw;


        }


	}
