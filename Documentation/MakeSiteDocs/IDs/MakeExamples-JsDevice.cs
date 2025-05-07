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
		 JSDeviceEarl(Example);
		 JSDeviceNetwork(Example);
		 JSDeviceMedia(Example);
		 JSDeviceRelated(Example);
		 JSDeviceServices(Example);
		 JSDeviceMaint(Example);
		}
	

	//
	// JSDeviceEarl
	//
	public static void JSDeviceEarl(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSDeviceEarl.md");
		Example._Output = _Output;
		Example._JSDeviceEarl(Example);
		}
	public void _JSDeviceEarl(CreateExamples Example) {

			 var jsdevice = Example.JSDevice;
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
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
	

	//
	// JSDeviceNetwork
	//
	public static void JSDeviceNetwork(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSDeviceNetwork.md");
		Example._Output = _Output;
		Example._JSDeviceNetwork(Example);
		}
	public void _JSDeviceNetwork(CreateExamples Example) {

			 var jsdevice = Example.JSDevice;
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// JSDeviceMedia
	//
	public static void JSDeviceMedia(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSDeviceMedia.md");
		Example._Output = _Output;
		Example._JSDeviceMedia(Example);
		}
	public void _JSDeviceMedia(CreateExamples Example) {

			 var jsdevice = Example.JSDevice;
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// JSDeviceRelated
	//
	public static void JSDeviceRelated(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSDeviceRelated.md");
		Example._Output = _Output;
		Example._JSDeviceRelated(Example);
		}
	public void _JSDeviceRelated(CreateExamples Example) {

			 var jsdevice = Example.JSDevice;
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// JSDeviceServices
	//
	public static void JSDeviceServices(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSDeviceServices.md");
		Example._Output = _Output;
		Example._JSDeviceServices(Example);
		}
	public void _JSDeviceServices(CreateExamples Example) {

			 var jsdevice = Example.JSDevice;
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// JSDeviceMaint
	//
	public static void JSDeviceMaint(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSDeviceMaint.md");
		Example._Output = _Output;
		Example._JSDeviceMaint(Example);
		}
	public void _JSDeviceMaint(CreateExamples Example) {

			 var jsdevice = Example.JSDevice;
			_Output.Write ("~~~~\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	}
