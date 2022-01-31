// Script Syntax Version:  1.0

//  © 2015-2021 by Threshold Secrets LLC.
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  
//  
 #pragma warning disable CS1591 
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace Goedel.Mesh.ServiceAdmin;
public partial class DnsConfiguration : global::Goedel.Registry.Script {

	

	//
	// BindConfig
	//
	public void BindConfig (Configuration configuration) {
		_Output.Write ("; PATH=/etc/bind/zones/db.{{}}\n{0}", _Indent);
		_Output.Write (";\n{0}", _Indent);
		_Output.Write (";\n{0}", _Indent);
		_Output.Write ("; This file is automatically generated. Changes MAY be overwritten.\n{0}", _Indent);
		_Output.Write (";\n{0}", _Indent);
		_Output.Write ("; Generated on {1}\n{0}", _Indent, DateTime.Now);
		_Output.Write ("\n{0}", _Indent);
		_Output.Write ("\n{0}", _Indent);
		_Output.Write ("; Fallback discovery address for the service\n{0}", _Indent);
		_Output.Write ("\n{0}", _Indent);
		_Output.Write ("\n{0}", _Indent);
		_Output.Write ("\n{0}", _Indent);
		_Output.Write ("; Service bindings\n{0}", _Indent);
		_Output.Write ("\n{0}", _Indent);
		_Output.Write ("\n{0}", _Indent);
		_Output.Write ("\n{0}", _Indent);
		}
	

	//
	// NetshConfig
	//
	public void NetshConfig (Configuration configuration) {
		}
	// netsh http add urlacl url=http://+:80/MyUri user=DOMAIN\user

	}
