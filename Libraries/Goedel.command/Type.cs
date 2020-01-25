
// Base classes referenced in generated code. Classes use underscore prefixed
// naming to avoid collisions with user written code.
#pragma warning disable IDE1006

namespace Goedel.Command {
    /// <summary>Base class for Command line parser types. This could do with
    /// some decrufting to remove implementation artifacts.</summary>
    public abstract class Type {

        /// <summary>The command line value.</summary>
        public virtual string Text { get; set; }

        /// <summary>If true, the value was set by default</summary>
        public bool ByDefault { get; set; } = true;

        /// <summary>
        /// Convert value to string.
        /// </summary>
        /// <returns>The string value.</returns>
        public override string ToString() => Text;

        /// <summary>
        /// Set parameter text.
        /// </summary>
        /// <param name="TextIn">Text to set.</param>
        public virtual void Parameter(string TextIn) => Text = TextIn;

        /// <summary>
        /// Set the default value for the type.
        /// </summary>
        /// <param name="TextIn">The default value as it would be given on the command line.</param>
        public virtual void Default(string TextIn) {
            Parameter(TextIn);
            ByDefault = true;
            }


        /// <summary>
        /// Completion routine. This is called at the end of parameter processing to finalize default values.
        /// </summary>
        /// <param name="Data">The final data.</param>
        public virtual void Complete(Type[] Data) {
            }

        /// <summary>
        /// Set the flag value.
        /// </summary>
        /// <param name="Negated">If true, flag is negated.</param>
        public virtual void SetFlag(bool Negated) {
            }

        }

    /// <summary>
    /// Command line boolean type for flags.
    /// </summary>
    public abstract class _Flag : Goedel.Command.Type {

        /// <summary>The canonical command line value.</summary>
        public override string Text {
            get => Value ? "true" : "false";
            set => Parameter(value);
            }

        /// <summary>
        /// Construct flag with specified value
        /// </summary>
        /// <param name="Value">The flag value to set</param>
        public _Flag(string Value = null) {
            if (Value != null) {
                Default(Value);
                }
            }


        /// <summary>
        /// The flag value.
        /// </summary>
        public virtual bool Value { get; set; }

        /// <summary>
        /// Set tag value from parameter.
        /// </summary>
        /// <param name="Text">The values true and 1 set a true value, 0 and false set a false value.
        /// Otherwise an exception is thrown.</param>
        public override void Parameter(string Text) {
            //Text = (Text == null) ? "true" : Text;
            switch (Text.ToLower()) {
                case "true":
                case "1": {
                    Value = true;
                    break;
                    }
                case "false":
                case "0": {
                    Value = false;
                    break;
                    }
                case "": {
                    break;
                    }
                default:
                    throw new System.Exception("Flag value not recognized" + Text);
                }
            }

        /// <summary>
        /// Set the negated flag
        /// </summary>
        /// <param name="Negated">If true, command is negated.</param>
        public override void SetFlag(bool Negated) {
            Parameter(Negated ? "false" : "true");
            ByDefault = false;
            }

        /// <summary>
        /// Convert value to string.
        /// </summary>
        /// <returns>the string value</returns>
        public override string ToString() => Text;



        }


    /// <summary>
    /// Command line flag for file.
    /// </summary>
    public abstract class _File : Goedel.Command.Type {


        /// <summary>
        /// Constructor with specified default value.
        /// </summary>
        /// <param name="Value">The default value text for this entry</param>
        public _File(string Value = null) {
            if (Value != null) {
                Default(Value);
                }
            }

        /// <summary>
        /// The default extension.
        /// </summary>
        public string Extension = "";

        /// <summary>
        /// Set the default.
        /// </summary>
        /// <param name="TextIn">The default value text for this entry</param>
        public override void Default(string TextIn) => Extension = TextIn;

        /// <summary>
        /// The value.
        /// </summary>
        public string Value => Text;


        /// <summary>
        /// Construct extension defaulted file name for specified file.
        /// </summary>
        /// <param name="Source">The source file.</param>
        /// <returns>File name.</returns>
        public string DefaultFile(_File Source) => DefaultFile(Source.Text);

        /// <summary>
        /// Construct extension defaulted file name for specified file.
        /// </summary>
        /// <param name="Source">The source file.</param>
        /// <param name="Extension">The extension.</param>
        /// <returns>File name.</returns>
        public string DefaultFile(string Source, string Extension = null) {
            Extension = Extension ?? this.Extension;

            Text = FileTools.DefaultFile(Extension, Source);
            return Text;
            }




        }

    /// <summary>
    /// Command line flag for file.
    /// </summary>
    public abstract class _NewFile : _File {
        bool Flagged = false;

        /// <summary>
        /// Construct flag with specified value
        /// </summary>
        /// <param name="Value">The flag value to set</param>
        public _NewFile(string Value = null) {
            if (Value != null) {
                Default(Value);
                }
            }


        /// <summary>
        /// Set the negated flag
        /// </summary>
        /// <param name="Negated">if true, is negated.</param>
        public override void SetFlag(bool Negated) => Flagged = true;


        /// <summary>
        /// Set the default value for the type.
        /// </summary>
        /// <param name="TextIn">The default value as it would be given on the command line.</param>
        public override void Default(string TextIn) => Extension = TextIn;


        /// <summary>
        /// Completion routine. This is called at the end of parameter processing to finalize default values.
        /// </summary>
        /// <param name="Data">The completed data</param>
        public override void Complete(Type[] Data) {
            if (!ByDefault | !Flagged) {
                return; // not flagged or explicitly set
                }

            var Source = Get(Data);
            if (Source != null) {
                Parameter(DefaultFile(Source));
                }

            }


        _ExistingFile Get(Type[] Data) {
            foreach (var Entry in Data) {
                if (Entry as _ExistingFile != null) {
                    return Entry as _ExistingFile;
                    }
                }
            return null;
            }
        }

    /// <summary>
    /// Command line flag for file.
    /// </summary>
    public abstract class _ExistingFile : _File {

        /// <summary>
        /// Construct flag with specified value
        /// </summary>
        /// <param name="Value">The flag value to set</param>
        public _ExistingFile(string Value = null) {
            if (Value != null) {
                Default(Value);
                }
            }

        }

    /// <summary>
    /// Command line flag for file.
    /// </summary>
    public abstract class _Integer : Type {


        /// <summary>
        /// Construct flag with specified value
        /// </summary>
        /// <param name="Value">The flag value to set</param>
        public _Integer(string Value = null) {
            if (Value != null) {
                Default(Value);
                }
            }

        /// <summary>
        /// Return the 
        /// </summary>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public int ValueDefaulted(int defaultValue) {
            if (Text == "" | Text == null) {
                return defaultValue;
                }
            if (int.TryParse(Text, out var Result)) {
                return Result;
                }
            throw new InvalidOption();
            }

        /// <summary>
        /// Return the value as an integer
        /// </summary>
        public int Value {
            get {
                if (Text == "") {
                    return 0;
                    }
                if (int.TryParse(Text, out var Result)) {
                    return Result;
                    }
                throw new InvalidOption();
                }
            }
        }

    /// <summary>
    /// Command line flag for file.
    /// </summary>
    public abstract class _String : Type {
        /// <summary>
        /// The value.
        /// </summary>
        public string Value => Text;

        /// <summary>
        /// Construct flag with specified value
        /// </summary>
        /// <param name="Value">The flag value to set</param>
        public _String(string Value = null) {
            if (Value != null) {
                Default(Value);
                }
            }

        }


    //     public abstract class _Enumeration<T> : Type  where T: System.Enum {

    /// <summary>
    /// Command line flag for file.
    /// </summary>
    public abstract class _Enumeration<T> : Type {
        DescribeEntryEnumerate Description;

        ///<summary>The typed value</summary>
        public T Value;

        ///<summary>Base constructor</summary>
        public _Enumeration(DescribeEntryEnumerate description, string Value = null) => Description = description;

        }

    }
