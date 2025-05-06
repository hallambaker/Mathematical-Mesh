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
namespace ExampleGenerator;
public partial class CreateExamples : global::Goedel.Registry.Script {

	
	/// <summary>	
	/// MakeJSDeviceExamples
	/// </summary>
	/// <param name="Example"></param>
	public void MakeJSDeviceExamples (CreateExamples Example) {
		 JSDeviceInitial(Example);
		}
	

	//
	// JSDeviceInitial
	//
	public static void JSDeviceInitial(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSDeviceInitial.md");
		Example._Output = _Output;
		Example._JSDeviceInitial(Example);
		}
	public void _JSDeviceInitial(CreateExamples Example) {

			 var jsdevice = Example.JSDevice;
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	}
