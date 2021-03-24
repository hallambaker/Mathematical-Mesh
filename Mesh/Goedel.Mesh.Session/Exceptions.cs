﻿
//  This file was automatically generated at 2/23/2021 1:56:50 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  exceptional version 3.0.0.570
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
namespace Goedel.Tool.ProtoGen {
    /// <summary>
    /// The input could not be parsed
    /// </summary>
    [global::System.Serializable]
    public partial class UndefinedReference : global::Goedel.Utilities.GoedelException {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
                global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


        ///<summary>Templates for formatting response messages.</summary>
        public static new System.Collections.Generic.List<string> Templates =
                new System.Collections.Generic.List<string> {

                "Reference to undefined object"
                };

        /// <summary>
        /// Construct instance for exception
        /// </summary>		
        /// <param name="description">Description of the error, may be used to override the 
        /// generated message.</param>	
        /// <param name="inner">Inner Exception</param>	
        /// <param name="args">Optional list of parameterized arguments.</param>
        public UndefinedReference(string description = null, System.Exception inner = null,
            params object[] args) :
                base(ExceptionFormatDelegate(description, Templates,
                    null, args), inner) {
            }





        /// <summary>
        /// The public fatory delegate
        /// </summary>
        /// public static global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new UndefinedReference(args: reasons);

        /// <summary>
        /// The public fatory delegate
        /// </summary>
        public static global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


    /// <summary>
    /// The file could not be read.
    /// </summary>
    [global::System.Serializable]
    public partial class UndefinedParent : UndefinedReference {

        ///<summary>The exception formatting delegate. May be overriden 
		///locally or globally to implement different exception formatting.</summary>
		public static new global::Goedel.Utilities.ExceptionFormatDelegate ExceptionFormatDelegate { get; set; } =
                global::Goedel.Utilities.GoedelException.ExceptionFormatDelegate;


        ///<summary>Templates for formatting response messages.</summary>
        public static new System.Collections.Generic.List<string> Templates =
                new System.Collections.Generic.List<string> {

                "The parent is not referenced."
                };

        /// <summary>
        /// Construct instance for exception
        /// </summary>		
        /// <param name="description">Description of the error, may be used to override the 
        /// generated message.</param>	
        /// <param name="inner">Inner Exception</param>	
        /// <param name="args">Optional list of parameterized arguments.</param>
        public UndefinedParent(string description = null, System.Exception inner = null,
            params object[] args) :
                base(ExceptionFormatDelegate(description, Templates,
                    null, args), inner) {
            }





        /// <summary>
        /// The public fatory delegate
        /// </summary>
        /// public static new global::Goedel.Utilities.ThrowNewDelegate ThrowNew = _Throw;

        static System.Exception _Throw(object reasons) => new UndefinedParent(args: reasons);

        /// <summary>
        /// The public fatory delegate
        /// </summary>
        public static new global::Goedel.Utilities.ThrowDelegate Throw = _Throw;


        }


    }
