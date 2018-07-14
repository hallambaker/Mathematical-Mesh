using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Registry {
    /// <summary>
    /// Extension methods for escaping XML Text
    /// </summary>
    public static class XMLEscape {

        /// <summary>
        /// Convert a string to XML escaped form for body content.
        /// </summary>
        /// <param name="Text">The input</param>
        /// <returns>The escaped string.</returns>
        public static string AsXML (this string Text) {
            var Result = new StringBuilder();

            foreach (char c in Text) {
                switch (c) {
                    case '<': Result.Append ("&lt;"); break;
                    case '>': Result.Append("&gt;"); break;
                    case '&': Result.Append("&amp;"); break;
                    case (char)160: Result.Append("&nbsp;"); break;
                    default: Result.Append(c); break;
                    }
                }

            return Result.ToString();
            }

        /// <summary>
        /// Convert a string to XML escaped form for attribute values.
        /// </summary>
        /// <param name="Text">The input</param>
        /// <returns>The escaped string.</returns>
        public static string AsXMLAttribute(this string Text) {
            var Result = new StringBuilder();

            Text = Text ?? "null";
            foreach (char c in Text) {
                switch (c) {
                    case '<': Result.Append("&lt;"); break;
                    case '>': Result.Append("&gt;"); break;
                    case '&': Result.Append("&amp;"); break;
                    case '\"': Result.Append("&quot;"); break;
                    case (char)160: Result.Append("&nbsp;"); break;
                    default: Result.Append(c); break;
                    }
                }

            return Result.ToString();
            }
        }

    /// <summary>
    /// Write XML tags out using the 
    /// </summary>
    public class XMLTextWriter {

        Stack<string> StackIndent = new Stack<string>();
        Stack<string> StackTag = new Stack<string>();

        /// <summary>Tracks the indentation level.</summary>
        public int Stack => StackIndent.Count;

        /// <summary>
        /// Defines the indent increment. These are spaces that are prepended to the
        /// next line.
        /// </summary>
        public string IndentIncrement { get; set; } = "  ";

        /// <summary>
        /// Convenience accessor for the Indent value
        /// </summary>
        string Indent {get; set; }

        /// <summary>The underlying output stream.</summary>
        protected TextWriter Output;

        /// <summary>
        /// Constructor specifying underlying stream.
        /// </summary>
        /// <param name="Output">The underlying ourput stream to wrap.</param>
        /// <param name="Header">If true, output an XML header.</param>
        public XMLTextWriter(TextWriter Output, bool Header = true) {
            this.Output = Output;

            if (Header) {
                Output.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n");
                }
            }



        /// <summary>
        /// Write out a complete element with start and closing tag. If
        /// the text value is omitted or null an empty tag &lt;Name/&gt;
        /// is produced. Otherwise the tag wraps the supplied text.
        /// </summary>
        /// <param name="Tag">Tag to wrap text with.</param>
        /// <param name="Attributes">List of tag/value pairs.</param>
        public void WriteElementEmpty (string Tag,
            params string[] Attributes) {
            //Console.WriteLine("{1}<{0}>", Tag, Indent);

            StartLine();

            Output.Write("<");
            Output.Write(Tag);
            Write(Attributes);
            Output.Write(">");

            EndLine();
            }

        /// <summary>
        /// Write out an XML element if the specified text is not null and trim the text.
        /// </summary>
        /// <param name="Tag">Tag to wrap text with.</param>
        /// <param name="Text">The text to wrap (after trimming)</param>
        /// <param name="Attributes">List of tag/value pairs.</param>
        public void WriteElementIfTrim (string Tag,
                string Text,
                params string[] Attributes) {
            if (Text != null) {
                WriteElement(Tag, Text.Trim(), Attributes);
                }
            }

        /// <summary>
        /// Write out an XML element if the specified text is not null writing the verbatim text.
        /// </summary>
        /// <param name="Tag">Tag to wrap text with.</param>
        /// <param name="Text">The text to wrap (verbatim)</param>
        /// <param name="Attributes">List of tag/value pairs.</param>
        public void WriteElementIf (string Tag,
                string Text,
                params string[] Attributes) {
            if (Text != null) {
                WriteElement(Tag, Text, Attributes);
                }
            }

        /// <summary>
        /// Write out a complete element with start and closing tag. If
        /// the text value is omitted or null an empty tag &lt;Name/&gt;
        /// is produced. Otherwise the tag wraps the supplied text.
        /// </summary>
        /// <param name="Tag">Tag to wrap text with.</param>
        /// <param name="Text">The text to wrap (verbatim)</param>
        /// <param name="Attributes">List of tag/value pairs.</param>
        public void WriteElement(string Tag,
            string Text = null,
            params string[] Attributes) => WriteElement(Tag, true, true, Text, Attributes);


        /// <summary>
        /// Write out a complete element with start and closing tag. If
        /// the text value is omitted or null an empty tag &lt;Name/&gt;
        /// is produced. Otherwise the tag wraps the supplied text.
        /// </summary>
        /// <param name="Tag">Tag to wrap text with.</param>
        /// <param name="Texts">List of text strings to wrap, each string being wrapped separately.</param>
        /// <param name="Attributes">List of tag/value pairs.</param>
        public void WriteElement (string Tag,
                    List<string> Texts,
                    params string[] Attributes) {
            if (Texts == null) {
                return;
                }
            foreach (var Text in Texts) {
                WriteElement(Tag, true, true, Text, Attributes);
                }
            }

        /// <summary>
        /// Write out a complete element with start and closing tag. If
        /// the text value is omitted or null an empty tag &lt;Name/&gt;
        /// is produced. Otherwise the tag wraps the supplied text.
        /// </summary>
        /// <param name="Tag">Tag to wrap text with.</param>
        /// <param name="Text">The text to wrap (verbatim)</param>
        /// <param name="Start">If true, write out start of line whitespace.</param>
        /// <param name="End">If true, write out end of line whitespace.</param>
        /// <param name="Attributes">List of tag/value pairs.</param>
        public void WriteElement(string Tag,
            bool Start, bool End,
            string Text = null, 
            params string[] Attributes) {
            //Console.WriteLine("{1}<{0}>", Tag, Indent);

            StartLine(Start);
            if (Text == null) {
                Output.Write("<");
                Output.Write(Tag);
                Write(Attributes);
                Output.Write("/>");
                }
            else {
                Output.Write("<");
                Output.Write(Tag);
                Write(Attributes);
                Output.Write(">");

                Output.Write(Text);

                Output.Write("</");
                Output.Write(Tag);
                Output.Write(">");
                }
            EndLine(End);
            }

        /// <summary>
        /// Write out a complete element with start and closing tag. If
        /// the text value is omitted or null an empty tag &lt;Name/&gt;
        /// is produced. Otherwise the tag wraps the supplied text.
        /// </summary>
        /// <param name="Tag">Tag to wrap text with.</param>
        /// <param name="Text">The text to wrap (verbatim)</param>
        /// <param name="Attributes">List of tag/value pairs.</param>
        public void WriteInlineElement (string Tag,
            string Text = null,
            params string[] Attributes) {
            //Console.WriteLine("{1}<{0}>", Tag, Indent);

            if (Text == null) {
                Output.Write("<");
                Output.Write(Tag);
                Write(Attributes);
                Output.Write("/>");
                }
            else {
                Output.Write("<");
                Output.Write(Tag);
                Write(Attributes);
                Output.Write(">");

                Output.Write(Text);

                Output.Write("</");
                Output.Write(Tag);
                Output.Write(">");
                }
            }


        /// <summary>
        /// Write an element start tag with optional attributes.
        /// </summary>
        /// <param name="Tag">Tag to wrap text with.</param>
        /// <param name="Attributes">List of tag/value pairs.</param>
        public void Start(string Tag, params string[] Attributes) {
            //Console.WriteLine("{1}<{0}>", Tag, Indent);

            StackIndent.Push(Indent);
            StackTag.Push(Tag);

            StartLine();
            Output.Write("<");
            Output.Write(Tag);
            Write(Attributes);
            //Atts
            Output.Write(">");
            EndLine();

            Indent += IndentIncrement;
            }

        /// <summary>
        /// Write an element start tag with optional attributes.
        /// </summary>
        /// <param name="Tag">Tag to wrap text with.</param>
        /// <param name="Start">If true, write out start of line whitespace.</param>
        /// <param name="End">If true, write out end of line whitespace.</param>
        /// <param name="Attributes">List of tag/value pairs.</param>
        public void Start (string Tag, bool Start, bool End,
                        params string[] Attributes) {
            //Console.WriteLine("{1}<{0}>", Tag, Indent);

            StackIndent.Push(Indent);
            StackTag.Push(Tag);
            StartLine(Start);
            Output.Write("<");
            Output.Write(Tag);
            Write(Attributes);
            //Atts
            Output.Write(">");
            EndLine(End);
            Indent += IndentIncrement;
            }


        void Write (string[] Attributes) {
            bool IsTag = true;

            foreach (var Item in Attributes) {

                if (IsTag) {
                    Output.Write(" ");
                    Output.Write(Item);
                    }
                else {
                    Output.Write("=\"");
                    Output.Write(Item.AsXMLAttribute());
                    Output.Write("\"");
                    }
                IsTag = !IsTag;
                }
            }


        /// <summary>
        /// Write out comment text.
        /// </summary>
        /// <param name="Text">Text to write.</param>
        public void Comment(string Text) {
            StartLine();
            Output.Write("<!--");
            Output.Write(Text.AsXML());
            Output.Write("-->");
            EndLine();
            }

        /// <summary>
        /// Write out text performing XML escaping.
        /// </summary>
        /// <param name="Text">Text to write.</param>
        /// <param name="Start">If true, write out start of line whitespace.</param>
        /// <param name="End">If true, write out end of line whitespace.</param>
        public void Write (string Text="", bool Start = true, bool End = true) {
            //Console.Write("{0}:  ", StackTag.Count);
            //Console.WriteLine(Text);
            StartLine(Start);
            Output.Write(Text.AsXML());
            EndLine(End);
            }

        /// <summary>
        ///  Write out text performing XML escaping as CDATA section.
        /// </summary>
        /// <param name="Text">Text to write.</param>
        public void WriteVerbatim(string Text) {
            StartLine();
            Output.Write("<![CDATA[");
            Output.Write(Text.AsXML());
            Output.Write("]]>");
            EndLine();
            }

        /// <summary>
        /// Close an open tag
        /// </summary>
        /// <param name="Start">If true, write out start of line whitespace.</param>
        /// <param name="End">If true, write out end of line whitespace.</param>        
        public void End(bool Start=true, bool End=true) {
            

            var Tag = StackTag.Pop();
            Indent = StackIndent.Pop();
            StartLine(Start);
            Output.Write("</");
            Output.Write(Tag);
            Output.Write(">");
            EndLine(End);

            //Console.WriteLine("{1}</{0}>", Tag, Indent);
            }

        /// <summary>
        /// Write out the start of line indentation if the condition is true.
        /// </summary>
        /// <param name="Write">If true write out line start</param>
        protected void StartLine(bool Write=true) {
            if (!Write) {
                return;
                }
            Output.Write(Indent);
            }

        /// <summary>
        /// Write out the end of line sequence if the condition is true.
        /// </summary>
        /// <param name="Write">If true write out line end.</param>
        protected void EndLine (bool Write = true) {
            if (!Write) {
                return;
                }
            Output.Write("\n");
            }
        }

    }
