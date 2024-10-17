using  System.Text;
using  Goedel.Protocol;
using  Goedel.Utilities;
 #pragma warning disable IDE0022
 #pragma warning disable IDE0060
 #pragma warning disable IDE1006
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace Annotate;
public partial class Annotations : global::Goedel.Registry.Script {

	
	/// <summary>	
	///  StartPage
	/// </summary>
	public void  StartPage () {
		_Output.Write ("<!DOCTYPE html>\n{0}", _Indent);
		_Output.Write ("<html lang=\"en\">\n{0}", _Indent);
		_Output.Write ("  <head>\n{0}", _Indent);
		_Output.Write ("    <meta charset=\"utf-8\">\n{0}", _Indent);
		_Output.Write ("    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\n{0}", _Indent);
		_Output.Write ("    <link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css\">\n{0}", _Indent);
		_Output.Write ("    <script src=\"https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js\"></script>\n{0}", _Indent);
		_Output.Write ("    <script src=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js\"></script>\n{0}", _Indent);
		_Output.Write ("  </head>\n{0}", _Indent);
		_Output.Write ("  <body>\n{0}", _Indent);
		}
	
	/// <summary>	
	///  EndPage 
	/// </summary>
	public void  EndPage  () {
		_Output.Write ("  </body>\n{0}", _Indent);
		_Output.Write ("</html>\n{0}", _Indent);
		}
	
	/// <summary>	
	///  PageHome
	/// </summary>
	public void  PageHome () {
		_Output.Write ("<div class=\"container\">\n{0}", _Indent);
		_Output.Write ("  <h1>Home</h1>\n{0}", _Indent);
		_Output.Write ("  <p><a href=\"Upload\">Add Document</a></p>\n{0}", _Indent);
		_Output.Write ("  <p><a href=\"Documents\">List Documents</a></p>\n{0}", _Indent);
		_Output.Write ("  <p><a href=\"Actions\">List Actions</a></p>\n{0}", _Indent);
		_Output.Write ("</div>\n{0}", _Indent);
		_Output.Write ("\n{0}", _Indent);
		}
	
	/// <summary>	
	///  PageSelect 
	/// </summary>
	public void  PageSelect  () {
		_Output.Write ("<div class=\"container\">\n{0}", _Indent);
		_Output.Write ("\n{0}", _Indent);
		_Output.Write ("    <form method0=\"post\" action=\"Append\" enctype=\"multipart/form-data\">\n{0}", _Indent);
		_Output.Write ("\n{0}", _Indent);
		_Output.Write ("        <label>Select the file:</label>\n{0}", _Indent);
		_Output.Write ("\n{0}", _Indent);
		_Output.Write ("        <input type=\"file\" id=\"fileUpload\" name=\"data\" />\n{0}", _Indent);
		_Output.Write ("        <br/>\n{0}", _Indent);
		_Output.Write ("        <input type=\"radio\" id=\"auto\" name=\"format\" value=\"auto\"><label>Auto detect</label>\n{0}", _Indent);
		_Output.Write ("        <input type=\"radio\" id=\"md\" name=\"format\" value=\"md\"><label>Markdown</label>\n{0}", _Indent);
		_Output.Write ("        <input type=\"radio\" id=\"word\" name=\"format\" value=\"word\"><label>Word</label>\n{0}", _Indent);
		_Output.Write ("        <input type=\"radio\" id=\"html\" name=\"format\" value=\"html\"><label>HTML</label>\n{0}", _Indent);
		_Output.Write ("        <input type=\"radio\" id=\"xml2rfc\" name=\"format\" value=\"xml2rfc\" checked=\"checked\"><label>XML2RFC</label>\n{0}", _Indent);
		_Output.Write ("        <br/>\n{0}", _Indent);
		_Output.Write ("        <input type=\"submit\" value=\"Upload\">\n{0}", _Indent);
		_Output.Write ("    </form>\n{0}", _Indent);
		_Output.Write ("\n{0}", _Indent);
		_Output.Write ("</div>\n{0}", _Indent);
		}
	
	/// <summary>	
	///  PageUpload 
	/// </summary>
	public void  PageUpload  () {
		_Output.Write ("<div class=\"container\">\n{0}", _Indent);
		_Output.Write ("  <h1>Upload Complete</h1>\n{0}", _Indent);
		_Output.Write ("\n{0}", _Indent);
		_Output.Write ("</div>\n{0}", _Indent);
		}
	
	/// <summary>	
	///  PageDocuments 
	/// </summary>
	public void  PageDocuments  () {
		_Output.Write ("<div class=\"container\">\n{0}", _Indent);
		_Output.Write ("  <h1>List of managed documents</h1>\n{0}", _Indent);
		_Output.Write ("\n{0}", _Indent);
		_Output.Write ("</div>\n{0}", _Indent);
		}
	
	/// <summary>	
	///  PageDocument 
	/// </summary>
	public void  PageDocument  () {
		_Output.Write ("<div class=\"container\">\n{0}", _Indent);
		_Output.Write ("  <h1>A particular managed documents</h1>\n{0}", _Indent);
		_Output.Write ("</div>\n{0}", _Indent);
		}
	
	/// <summary>	
	///  PageActions 
	/// </summary>
	public void  PageActions  () {
		_Output.Write ("<div class=\"container\">\n{0}", _Indent);
		_Output.Write ("  <h1>List of outstanding actions</h1>\n{0}", _Indent);
		_Output.Write ("</div>\n{0}", _Indent);
		}
	
	/// <summary>	
	///  PageError 
	/// </summary>
	public void  PageError  () {
		_Output.Write ("<div class=\"container\">\n{0}", _Indent);
		_Output.Write ("  <h1>An error occurred</h1>\n{0}", _Indent);
		_Output.Write ("\n{0}", _Indent);
		_Output.Write ("</div>\n{0}", _Indent);
		}
	}
