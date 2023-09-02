using Goedel.Utilities;

using System;
using System.Collections;
using System.Threading.Tasks;

namespace Goedel.Guigen;


public interface IPresentation {
    }




public interface IBindable {
    
    ///<summary>Returns the binding for the data type</summary> 
    public GuiBinding Binding { get; }



    }

public interface IParameter : IBindable {




    public bool Validate();

    }

public enum ReturnResult {
    Completed,
    Initialized,
    Valid,
    Invalid,
    Error
    }

public interface IResult : IBindable {

    ReturnResult ReturnResult { get; }

    }


public record NullResult : IResult {

    public ReturnResult ReturnResult { get; init; }

    public string Error { get; }

    public NullResult(string error="") {
        Error = error;
        }

    public GuiBinding Binding => throw new NotImplementedException();

    public static NullResult Initialized = new NullResult() {
        ReturnResult = ReturnResult.Initialized
        };

    public static NullResult Valid = new NullResult() {
        ReturnResult = ReturnResult.Valid
        };

    public static NullResult Invalid = new NullResult() {
        ReturnResult = ReturnResult.Invalid
        };


    }





[Flags]
public enum ActionMode {
    Initialize = 1,
    Validate = 2,
    Execute = 4
    }


public record GuiBinding {

    public Func<object, bool> IsType { get; }

    public GuiBoundProperty[] BoundProperties { get; }



    public GuiBinding(
                Func<object, bool> isType,
                GuiBoundProperty[] boundProperties
                ) {
        BoundProperties = boundProperties;
        IsType = isType;
        }

    }


public record GuiResult {

    public List<IGuiEntry> Entries { get; set; } = null!;



    public GuiResult() {
        }

    }

public record GuiBoundProperty  {
    ///<summary>Error to be filled if Validate is called and finds an error</summary> 
    public string? Error { get; set; } = null;

    }


public record GuiBoundPropertyString (
                Func<object, string> Get,
                Action<object, string> Set,
                string? Label = null) : GuiBoundProperty {
    }

public record GuiBoundPropertyChooser(
                Func<object, ISelectCollection> Get,
                Action<object, ISelectCollection> Set,
                string? Label = null) : GuiBoundProperty {
    }

public record GuiBoundPropertyColor(
                Func<object, IFieldColor> Get,
                Action<object, IFieldColor> Set,
                string? Label = null) : GuiBoundProperty {
    }


public record GuiBoundPropertySize(
                Func<object, IFieldSize> Get,
                Action<object, IFieldSize> Set,
                string? Label = null) : GuiBoundProperty {
    }


public record GuiBoundPropertyDecimal(
                Func<object, double> Get,
                Action<object, double> Set,
                string? Label = null) : GuiBoundProperty {
    }


public record GuiBoundPropertyIcon(
                Func<object, IFieldIcon> Get,
                Action<object, IFieldIcon> Set,
                string? Label = null) : GuiBoundProperty {
    }



///<summary></summary> 
public record GuiImage (
            string Icon
            ){
    }


public record GuiItem(
            string Id) {
    }

public record GuiDialog : GuiItem , IGuiEntry {
    public IPresentation? Presentation { get; set; } = null;

    public List<IGuiEntry> Entries { get; set; } = null!;

    public GuiDialog(
           string id,
            List<IGuiEntry> entries = null!
           ) : base(id){
        Entries = entries;

        }


    }




public record GuiButton(
            string Id,
            IButtonTarget Target
            ) : GuiItem(Id), IGuiEntry {


    }


public record GuiPrompt(
            string Id,
            string Prompt
            ) : GuiItem(Id), IGuiEntry {



    }


public record GuiSection (

            string Id,
            string Prompt,
            string Icon,
            bool Primary
            ) : GuiPrompt(Id, Prompt), IButtonTarget {

    public Func<bool> Active { get; set; } = () => false;

    public Gui Gui { get; set; } = null!;
    public IPresentation? Presentation { get; set; } = null;


    public IBindable? Data {
            get => data ?? BindData().CacheValue(out data);
            set => data = value; }
    IBindable? data = null;

    public Func<IBindable> BindData { get; set; } = () => null! ;

    public List<IGuiEntry> Entries { get; set; } = null!;


    }

public delegate  Task<IResult> ActionCallback(object IBindable, ActionMode mode= ActionMode.Execute);
public delegate IBindable FactoryCallback();
public record GuiAction(
            string Id,
            string Prompt,
            string Icon,
            FactoryCallback Factory,
            ActionMode ActionMode = ActionMode.Execute
            ) : GuiPrompt(Id, Prompt), IButtonTarget {
    public IPresentation? Presentation { get; set; } = null;

    public List<IGuiEntry> Entries { get; set; } = null!;

    public ActionCallback Callback { get; set; } = null!;
    }


public record GuiField(
            string Id,
            string Prompt,
            int Index
            ) : GuiPrompt(Id, Prompt), IGuiEntry {
    }

public record GuiChooser(
            string Id,
            string Prompt,
            string Icon,
            int Index = -1,
            //GuiBinding Binding,
            List<IGuiEntry> Entries = null!
            ) : GuiField(Id, Prompt, Index), IGuiEntry {


    }






public record GuiContext(
            string Id,
            string Prompt,
            int Index = -1
            ) : GuiField (Id, Prompt, Index) { 
    }

public record GuiText(
            string Id,
            string Prompt,
            int Index = -1
            ) : GuiField(Id, Prompt, Index) {
    }

public record GuiColor(
            string Id,
            string Prompt,
            int Index = -1
            ) : GuiField(Id, Prompt, Index) {
    }
public record GuiSize(
            string Id,
            string Prompt,
            int Index = -1
            ) : GuiField(Id, Prompt, Index) {
    }
public record GuiDecimal(
            string Id,
            string Prompt,
            int Index = -1
            ) : GuiField(Id, Prompt, Index) {
    }
public record GuiIcon(
            string Id,
            string Prompt,
            int Index = -1
            ) : GuiField(Id, Prompt, Index) {
    }


public record GuiView(
            GuiBinding Binding
            ) : IGuiEntry {
    }



public interface IGuiEntry {
    }



//public interface ISectionEntry {
//    }

//public interface IActionEntry {
//    }

//public interface IDialogEntry {
//    }

//public interface IChooserEntry {
//    }

public interface IButtonTarget {
    }



public interface IFieldColor {
    }

public interface IFieldSize {
    }
public interface IFieldIcon {
    }



public interface ISelectCollection : IEnumerable{
    }