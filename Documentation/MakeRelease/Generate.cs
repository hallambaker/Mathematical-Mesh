// Script Syntax Version:  1.0

//  © 2015-2019 by Phill Hallam-Baker
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
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace Goedel.Tool.Version {
	public partial class MakeRelease : global::Goedel.Registry.Script {

		

		//
		// MakeVersionID
		//
		public static void MakeVersionID (Distribution Distribution) { /* File  */
			using (var _Output = new StreamWriter ("Sources\\prismproof\\Downloads\\release.mdx")) {
				var _Indent = ""; 
				if (  (Distribution.Latest != null)  ) {
					_Output.Write ("<a=\"Downloads/index.html\">Mesh Release {1}</a>\n{0}", _Indent, Distribution.Latest.Code);
					} else {
					_Output.Write ("<none>\n{0}", _Indent);
					}
				}
			}
		

		//
		// MakeIndex
		//
		public static void MakeIndex (Distribution Distribution) { /* File  */
			using (var _Output = new StreamWriter ("Sources\\prismproof\\Downloads\\index.md")) {
				var _Indent = ""; 
				 var _Class = new MakeRelease () { _Output = _Output};
				_Output.Write ("<title>Downloads\n{0}", _Indent);
				_Output.Write ("<titlebanner><h1>Downloads\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<h4><icon=\"windows\"> <icon=\"apple\"> <icon=\"linux\"> \n{0}", _Indent);
				_Output.Write ("</titlebanner>\n{0}", _Indent);
				_Output.Write ("<leftmain>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Currently, only the line mode Mesh tools are being developed, the GUI tool provided earlier will \n{0}", _Indent);
				_Output.Write ("be re-launched in due course.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("During the beta test period, it seems simplest to deliver the binary distributions as simple ZIP files.\n{0}", _Indent);
				_Output.Write ("To use them, simply unpack the file to a directory and either add that directory to the shell\n{0}", _Indent);
				_Output.Write ("search path or copy the contents to a directory already in the search path. \n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("When distribution of the GUI tool resumes, there will be platform specific installers for each platform\n{0}", _Indent);
				_Output.Write ("once again.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Mathematical Mesh reference tools are written in C under the Microsoft .NET Core 3.1 framework\n{0}", _Indent);
				_Output.Write ("as Standalone Distribution files. All the files required to run the distribution are provided. It is not\n{0}", _Indent);
				_Output.Write ("necessary to install .NET Core first.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("There is no separate source file distribution, nor is this planned. To access the source files, clone the \n{0}", _Indent);
				_Output.Write ("<a=\"https://github.com/hallambaker/Mathematical-Mesh\">GitHub repository</a>.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("#Latest Stable ", _Indent);
				if (  (Distribution.Stable != null)  ) {
					_Output.Write ("({1})\n{0}", _Indent, Distribution.Stable.Code);
					_Output.Write ("\n{0}", _Indent);
					} else {
					_Output.Write ("\n{0}", _Indent);
					_Output.Write ("\n{0}", _Indent);
					_Output.Write ("&<none&>\n{0}", _Indent);
					}
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("#Latest Build ", _Indent);
				if (  (Distribution.Latest != null)  ) {
					_Output.Write ("({1})\n{0}", _Indent, Distribution.Latest.Code);
					_Output.Write ("\n{0}", _Indent);
					 _Class.Describe(Distribution.Latest);
					} else {
					_Output.Write ("\n{0}", _Indent);
					_Output.Write ("\n{0}", _Indent);
					_Output.Write ("&<none&>\n{0}", _Indent);
					}
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("#Previous Builds\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				if (  (Distribution.Versions.Count ==0)  ) {
					_Output.Write ("&<none&>\n{0}", _Indent);
					} else {
					foreach  (var Version in Distribution.Versions) {
						 _Class.Describe(Version);
						}
					}
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("</leftmain>\n{0}", _Indent);
				}
			}
		

		//
		// MakeVersion
		//
		public void MakeVersion (Version Version) {
			_Output.Write ("<title>Downloads\n{0}", _Indent);
			_Output.Write ("<titlebanner><h1>Release {1}\n{0}", _Indent, Version);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("<h4><icon=\"windows\"> <icon=\"apple\"> <icon=\"linux\"> \n{0}", _Indent);
			_Output.Write ("</titlebanner>\n{0}", _Indent);
			_Output.Write ("<leftmain>\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			Describe (Version);
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("</leftmain>\n{0}", _Indent);
			}
		

		//
		// Describe
		//
		public void Describe (Version Version) {
			_Output.Write ("\n{0}", _Indent);
			foreach  (var Platform in Version.Platforms)  {
				_Output.Write ("##{1}\n{0}", _Indent, Platform.PlatformName);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("<ul>\n{0}", _Indent);
				foreach  (var File in Platform.Files)  {
					_Output.Write ("<li> <b>{1}</b> <a=\"v{2}/{3}\" download=\"{4}\">{5} <icon=\"file-archive-o\"></a>\n{0}", _Indent, File.PlatformDescription, Version.Code, File.Name, File.Name, File.Name);
					}
				_Output.Write ("<ul>\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				}
			_Output.Write ("\n{0}", _Indent);
			_Output.Write ("\n{0}", _Indent);
			}
		}
	}
