#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
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
#endregion
using System;
using System.IO;

namespace Goedel.Registry;

/// <summary>
/// Output format types
/// </summary>
public enum OutputFormat {
    /// <summary>Goedel input file format.</summary>
    Goedel,
    /// <summary>XML</summary>
    XML,
    /// <summary>JSON</summary>
    JSON,
    /// <summary>Markdown</summary>
    MD
    }

/// <summary>
/// Base class for Formatting writer. Used to create output documents in multiple
/// encoding formats.
/// </summary>
public abstract class StructureWriter {

    /// <summary>
    /// Indent is the character string that will be written out to indent 
    /// blocks of code. Default is four spaces but can be set to two spaces, 
    /// a tab character or other text as required.
    /// </summary>
    public string Indent = "    ";
    /// <summary>The output writer</summary>
    protected TextWriter TextWriter;
    /// <summary>Current indent level</summary>
    protected int Level = 0;
    /// <summary>If true, output is at start of line.</summary>
    protected bool StartOfLine;
    bool first = true;

    /// <summary>
    /// Called to start the line
    /// </summary>
    protected void StartLine() {
        StartOfLine = true;
        if (first) {
            first = false;
            return;
            }
        TextWriter.WriteLine();
        for (int i = 0; i < Level; i++) {
            TextWriter.Write(Indent);
            }
        }

    /// <summary>
    /// Factory method for specified output stream and output format.
    /// </summary>
    /// <param name="TextWriter">The output</param>
    /// <param name="OutputFormat">Format to write output in.</param>
    /// <returns>The created output writer.</returns>
    public static StructureWriter GetStructureWriter(TextWriter TextWriter, OutputFormat OutputFormat) => OutputFormat switch {
        Goedel.Registry.OutputFormat.Goedel => new IndentWriter(TextWriter),
        Goedel.Registry.OutputFormat.XML => new XMLWriter(TextWriter),
        _ => null,
        };

    /// <summary>
    /// Constructor.
    /// </summary>
    protected StructureWriter() {
        }

    /// <summary>
    /// Set the output textwriter.
    /// </summary>
    /// <param name="TextWriter">The output</param>
    public StructureWriter(TextWriter TextWriter) => this.TextWriter = TextWriter;

    /// <summary>
    /// Called at the start of the document.
    /// </summary>
    /// <param name="Tag">Encoding specific document preamble.</param>
    public abstract void StartDocument(string Tag);
    /// <summary>Write document preamble</summary>
    public void StartDocument() => StartDocument(null);
    /// <summary>
    /// Called at the end of the document;
    /// </summary>
    /// <param name="Tag">Encoding specific .</param>
    public abstract void EndDocument(string Tag);
    /// <summary>Write end of document.</summary>
    public void EndDocument() => EndDocument(null);
    /// <summary>Begin list</summary>
    /// <param name="Tag">Tag to write</param>
    public abstract void StartList(string Tag);
    /// <summary>End list</summary>
    /// <param name="Tag">Tag to write</param>
    public abstract void EndList(string Tag);
    /// <summary>Start element</summary>
    /// <param name="Tag">Tag to write</param>
    public abstract void StartElement(string Tag);
    /// <summary>End element</summary>
    /// <param name="Tag">Tag to write</param>
    public abstract void EndElement(string Tag);

    /// <summary>Write identifier</summary>
    /// <param name="Tag">Tag to write</param>
    /// <param name="Data">Data to write</param>
    public abstract void WriteId(string Tag, string Data);
    /// <summary>Write string attribute</summary>
    /// <param name="Tag">Tag to write</param>
    /// <param name="Data">Data to write</param>
    public abstract void WriteAttribute(string Tag, string Data);
    /// <summary>Write integer attribute</summary>
    /// <param name="Tag">Tag to write</param>
    /// <param name="Data">Data to write</param>
    public abstract void WriteAttribute(string Tag, int Data);
    /// <summary>Write float attribute</summary>
    /// <param name="Tag">Tag to write</param>
    /// <param name="Data">Data to write</param>
    public abstract void WriteAttribute(string Tag, float Data);
    }

/// <summary>
/// Indenting structured writer.
/// </summary>
public class IndentWriter : StructureWriter {

    void Space() {
        if (StartOfLine) {
            StartOfLine = false;
            return;
            }
        TextWriter.Write(" ");
        }
    void Write(string Data) {
        Space();
        TextWriter.Write(Data);
        }

    /// <summary>
    /// Constructor for specified output stream and output format.
    /// </summary>
    /// <param name="TextWriter">The output</param>
    public IndentWriter(TextWriter TextWriter) => base.TextWriter = TextWriter;

    /// <summary>
    /// Called at the start of the document.
    /// </summary>
    /// <param name="Tag">Encoding specific document preamble.</param>        
    public override void StartDocument(string Tag) {
        }
    /// <summary>
    /// Called at the end of the document;
    /// </summary>
    /// <param name="Tag">Encoding specific .</param>        
    public override void EndDocument(string Tag) {
        TextWriter.WriteLine();
        TextWriter.Flush();
        }
    /// <summary>Begin list</summary>
    /// <param name="Tag">Tag to write</param>
    public override void StartList(string Tag) => Level++;
    /// <summary>End list</summary>
    /// <param name="Tag">Tag to write</param>
    public override void EndList(string Tag) { }

    /// <summary>Start element</summary>
    /// <param name="Tag">Tag to write</param>
    public override void StartElement(string Tag) {
        StartLine();
        Write(Tag);
        }
    /// <summary>End element</summary>
    /// <param name="Tag">Tag to write</param>
    public override void EndElement(string Tag) { }

    /// <summary>Write identifier</summary>
    /// <param name="Tag">Tag to write</param>
    /// <param name="Data">Data to write</param>
    public override void WriteId(string Tag, string Data) => Write(Data);
    /// <summary>Write string attribute</summary>
    /// <param name="Tag">Tag to write</param>
    /// <param name="Data">Data to write</param>
    public override void WriteAttribute(string Tag, string Data) => Write("\"" + Data + "\"");
    /// <summary>Write integer attribute</summary>
    /// <param name="Tag">Tag to write</param>
    /// <param name="Data">Data to write</param>
    public override void WriteAttribute(string Tag, int Data) => Write(Convert.ToString(Data));
    /// <summary>Write float attribute</summary>
    /// <param name="Tag">Tag to write</param>
    /// <param name="Data">Data to write</param>
    public override void WriteAttribute(string Tag, float Data) => Write(Convert.ToString(Data));
    }

/// <summary>
/// Currently unimplemented XML output writer class.
/// </summary>
public class XMLWriter : StructureWriter {

    /// <summary>
    /// Create XML writer with specified output
    /// </summary>
    /// <param name="TextWriterIn">The output stream</param>
    public XMLWriter(TextWriter TextWriterIn) => TextWriter = TextWriterIn;

    /// <summary>
    /// Starts the document.
    /// </summary>
    /// <param name="Tag">XML declaration string, if null a default value is used.</param>
    public override void StartDocument(string Tag) {
        if (Tag == null) {
            TextWriter.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\" ?>");
            }
        else {
            TextWriter.WriteLine(Tag);
            }
        }

    /// <summary>
    /// Called at the end of the document;
    /// </summary>
    /// <param name="Tag">Encoding specific .</param>
    public override void EndDocument(string Tag) {
        TextWriter.WriteLine();
        TextWriter.Flush();
        }

    /// <summary>Begin list</summary>
    /// <param name="Tag">Tag to write</param>
    public override void StartList(string Tag) { }
    /// <summary>End list</summary>
    /// <param name="Tag">Tag to write</param>
    public override void EndList(string Tag) { }
    /// <summary>Start element</summary>
    /// <param name="Tag">Tag to write</param>
    public override void StartElement(string Tag) { }
    /// <summary>End element</summary>
    /// <param name="Tag">Tag to write</param>
    public override void EndElement(string Tag) { }

    /// <summary>Write identifier</summary>
    /// <param name="Tag">Tag to write</param>
    /// <param name="Data">Data to write</param>
    public override void WriteId(string Tag, string Data) { }
    /// <summary>Write string attribute</summary>
    /// <param name="Tag">Tag to write</param>
    /// <param name="Data">Data to write</param>
    public override void WriteAttribute(string Tag, string Data) { }
    /// <summary>Write integer attribute</summary>
    /// <param name="Tag">Tag to write</param>
    /// <param name="Data">Data to write</param>
    public override void WriteAttribute(string Tag, int Data) { }
    /// <summary>Write float attribute</summary>
    /// <param name="Tag">Tag to write</param>
    /// <param name="Data">Data to write</param>
    public override void WriteAttribute(string Tag, float Data) { }
    }
