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
		 JSDevicePreparation(Example);
		 JSDeviceItself(Example);
		 JSDeviceOperations(Example);
		 JSDeviceMedia(Example);
		 JSDeviceNetwork(Example);
		 JSDeviceNetworkConfig(Example);
		 JSDeviceNetworkBoot(Example);
		}
	

	//
	// JSDevicePreparation
	//
	public static void JSDevicePreparation(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSDevicePreparation.md");
		Example._Output = _Output;
		Example._JSDevicePreparation(Example);
		}
	public void _JSDevicePreparation(CreateExamples Example) {

			 var jsdevice = Example.JSDevice.JsDevice;
			 var jsmodel = Example.JSDevice.JsModel;
			_Output.Write ("~~~~\n{0}", _Indent);
			 _Output.Write(jsmodel, Example.JSDevice.GeneralProperties);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// JSDeviceItself
	//
	public static void JSDeviceItself(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSDeviceItself.md");
		Example._Output = _Output;
		Example._JSDeviceItself(Example);
		}
	public void _JSDeviceItself(CreateExamples Example) {

			 var jsdevice = Example.JSDevice.JsDevice;
			 var jsmodel = Example.JSDevice.JsModel;
			_Output.Write ("~~~~\n{0}", _Indent);
			 _Output.Write(jsdevice, Example.JSDevice.GeneralProperties);
			_Output.Write ("~~~~\n{0}", _Indent);
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
			_Output.Write ("{1}\n{0}", _Indent, jsdevice.EARL);
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

			 var jsdevice = Example.JSDevice.JsDevice;
			_Output.Write ("~~~~\n{0}", _Indent);
			 _Output.Write(jsdevice, Example.JSDevice.MediaProperties);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// JSDeviceOperations
	//
	public static void JSDeviceOperations(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSDeviceOperations.md");
		Example._Output = _Output;
		Example._JSDeviceOperations(Example);
		}
	public void _JSDeviceOperations(CreateExamples Example) {

			 var jsdevice = Example.JSDevice.JsDevice;
			_Output.Write ("~~~~\n{0}", _Indent);
			 _Output.Write(jsdevice, Example.JSDevice.OperationsProperties);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// JSDeviceNetworkBoot
	//
	public static void JSDeviceNetworkBoot(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSDeviceNetworkBoot.md");
		Example._Output = _Output;
		Example._JSDeviceNetworkBoot(Example);
		}
	public void _JSDeviceNetworkBoot(CreateExamples Example) {

			 var jsdevice = Example.JSDevice.JsDevice;
			_Output.Write ("~~~~\n{0}", _Indent);
			 _Output.Write(jsdevice, Example.JSDevice.NetworkProperties, FilterNetworkBootstrap);
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

			 var jsdevice = Example.JSDevice.JsDevice;
			_Output.Write ("~~~~\n{0}", _Indent);
			 _Output.Write(jsdevice, Example.JSDevice.NetworkProperties, FilterNetworkService);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	

	//
	// JSDeviceNetworkConfig
	//
	public static void JSDeviceNetworkConfig(CreateExamples Example) { /* XFile  */
			using var _Output = new StreamWriter("Examples\\JSDeviceNetworkConfig.md");
		Example._Output = _Output;
		Example._JSDeviceNetworkConfig(Example);
		}
	public void _JSDeviceNetworkConfig(CreateExamples Example) {

			 var jsdevice = Example.JSDevice.JsDevice;
			_Output.Write ("~~~~\n{0}", _Indent);
			 _Output.Write(jsdevice, Example.JSDevice.NetworkProperties, FilterNetworkConfig);
			_Output.Write ("~~~~\n{0}", _Indent);
				}
	}
