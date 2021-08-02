using  System.Text;
using  Goedel.Mesh;
using  Goedel.Protocol;
using  Goedel.Utilities;
using  Goedel.Cryptography;
using  Goedel.Cryptography.Dare;
 #pragma warning disable IDE0022
 #pragma warning disable IDE0060
 #pragma warning disable IDE1006
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator {
	public partial class CreateExamples : global::Goedel.Registry.Script {

		

		//
		// MakePresentationExamples
		//
		public void MakePresentationExamples (CreateExamples Example) {
			 PresentationFirstContact(Example);
			 PresentationZeroRoundTrip(Example);
			 PresentationFirstContactDeferred(Example);
			 PresentationZeroRoundTripDeferred(Example);
			 PresentationTicketed(Example);
			}
		

		//
		// PresentationFirstContact
		//
		public static void PresentationFirstContact(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\PresentationFirstContact.md");
			Example._Output = _Output;
			Example._PresentationFirstContact(Example);
			}
		public void _PresentationFirstContact(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Key exchange example TBS\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// PresentationZeroRoundTrip
		//
		public static void PresentationZeroRoundTrip(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\PresentationZeroRoundTrip.md");
			Example._Output = _Output;
			Example._PresentationZeroRoundTrip(Example);
			}
		public void _PresentationZeroRoundTrip(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Key exchange example TBS\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// PresentationFirstContactDeferred
		//
		public static void PresentationFirstContactDeferred(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\PresentationFirstContactDeferred.md");
			Example._Output = _Output;
			Example._PresentationFirstContactDeferred(Example);
			}
		public void _PresentationFirstContactDeferred(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Key exchange example TBS\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// PresentationZeroRoundTripDeferred
		//
		public static void PresentationZeroRoundTripDeferred(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\PresentationZeroRoundTripDeferred.md");
			Example._Output = _Output;
			Example._PresentationZeroRoundTripDeferred(Example);
			}
		public void _PresentationZeroRoundTripDeferred(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Key exchange example TBS\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// PresentationTicketed
		//
		public static void PresentationTicketed(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\PresentationTicketed.md");
			Example._Output = _Output;
			Example._PresentationTicketed(Example);
			}
		public void _PresentationTicketed(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Key exchange example TBS\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
