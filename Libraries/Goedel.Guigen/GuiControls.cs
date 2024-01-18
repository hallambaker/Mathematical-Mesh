using Goedel.Utilities;

using System;
using System.Threading.Tasks;

namespace Goedel.Guigen;


public interface IPresentation {
    }




public interface IBindable {
    
    ///<summary>Returns the binding for the data type</summary> 
    public GuiBinding Binding { get; }



    }

public interface IParameter : IBindable {




    IResult Validate(Gui mainWindow);
    IResult Initialize(Gui mainWindow) => NullResult.Initialized;

    IResult TearDown(Gui mainWindow) => NullResult.Teardown;

    }


public interface IMessageable {

    IResult MessageReceived();
    }

public interface ISelectable : IParameter {

    GuiBinding SelectionBinding { get; } 

    }


public interface IHeadedSelection {
    GuiBinding SelectionBinding { get; }
    }


public enum ReturnResult {
    Completed,
    Initialized,
    Valid,
    Invalid,
    Error,
    Teardown
    }





public interface IResult : IBindable {

    public string Message { get; }


    public ResourceId? ResourceId { get; }

    ReturnResult ReturnResult { get; }

    public object[] GetValues();

    }


public interface IFail : IResult { 
    

    
    }



public abstract record NullResult : IResult {


    public ResourceId? ResourceId { get; } = null;

    public string Message => "";

    public virtual ReturnResult ReturnResult { get; init; }

    //public virtual string Error { get; }

    public NullResult( ResourceId? resourceId=null) {
        //Error = error;
        ResourceId = resourceId;
        }

    public GuiBinding Binding => throw new NotImplementedException();

    ///<summary></summary> 

    public static NullResult Teardown { get; } = new TeardownResult() { };

    public static NullResult Initialized { get; }  = new InitializedResult() { };

    public static NullResult Valid { get; } = new ValidResult();

    public static NullResult Completed { get; } = new CompletedResult();

    public object[] GetValues() => Array.Empty<object>();
    }


public record CompletedResult : NullResult {
    public override ReturnResult ReturnResult { get; init; } = ReturnResult.Completed
;
    }

public record InitializedResult : NullResult {
    public override ReturnResult ReturnResult { get; init; } = ReturnResult.Initialized
;
    }

public record TeardownResult : NullResult {
    public override ReturnResult ReturnResult { get; init; } = ReturnResult.Teardown
;
    }

public record ValidResult : NullResult {
    public override ReturnResult ReturnResult { get; init; } = ReturnResult.Valid;
    }


public record ErrorResult : NullResult, IFail {

    public  string? Error { get; }
    Exception? Exception { get; }
    public ErrorResult(string error ) {
        Error = error;
        }

    public ErrorResult(Exception exception) {
        Exception = exception;
        }
    public ErrorResult(ResourceId resourceId) : base(resourceId){

        }

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






public record GuiBoundProperty (
                string? Label,
                bool Primary = false) {


    }


public record GuiBoundPropertyString (
                Func<object, string> Get,
                Action<object, string> Set,
                string? Label,
                bool Primary = false) : GuiBoundProperty (Label, Primary) {
    }

public record GuiBoundPropertyQRScan(
                Func<object, GuiQR> Get,
                Action<object, GuiQR> Set,
                string? Label,
                bool Primary = false) : GuiBoundProperty(Label, Primary) {
    }

public record GuiBoundTextArea(
                Func<object, string> Get,
                Action<object, string> Set,
                string? Label,
                bool Primary = false) : GuiBoundProperty(Label, Primary) {
    }


public class GuiQR {

    public string? Offer { get; set; }
    public string? Identifier { get; set; }
    public string? CapturedByCamera { get; set; }
    public object? ReceivedByMessage { get; set; }

    public GuiQR() { 
        }


    }

public record GuiBoundPropertyChooser(
                Func<object, ISelectCollection> Get,
                Action<object, ISelectCollection> Set,
                string? Label,
                List<GuiEntry>? Entries = null) : GuiBoundProperty(Label) {
    }


public record GuiEntry(
                Func<object, bool> isType,
                GuiBoundProperty[] boundProperties,
                string Label) : GuiBinding(isType, boundProperties) {
    }



public record GuiBoundPropertyColor(
                Func<object, IFieldColor> Get,
                Action<object, IFieldColor> Set,
                string? Label = null) : GuiBoundProperty(Label) {
    }


public record GuiBoundPropertySize(
                Func<object, IFieldSize> Get,
                Action<object, IFieldSize> Set,
                string? Label = null) : GuiBoundProperty(Label) {
    }


public record GuiBoundPropertyDecimal(
                Func<object, decimal?> Get,
                Action<object, decimal?> Set,
                string? Label = null) : GuiBoundProperty(Label) {
    }


public record GuiBoundPropertyInteger(
                Func<object, int?> Get,
                Action<object, int?> Set,
                string? Label = null) : GuiBoundProperty(Label) {
    }

public record GuiBoundPropertyIcon(
                Func<object, IFieldIcon> Get,
                Action<object, IFieldIcon> Set,
                string? Label = null) : GuiBoundProperty(Label) {
    }



///<summary></summary> 
public record GuiImage (
            string Icon
            ){
    }


public record GuiItem(
            string Id) {
    }

public record GuiDialog(

            string Id,
            string Prompt,
            string Icon,
            FactoryCallback Factory) : GuiPrompt(Id, Prompt), IGuiEntry {
    public IPresentation? Presentation { get; set; } = null;

    public List<IGuiEntry> Entries { get; set; } = null!;

    public Func<object, bool> IsBoundType { get; set; } = (object _) => false;
    public Func<object, bool> IsBacker { get; set; } = (object _) => false;

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

public record GuiQRScan(
            string Id,
            string Prompt,
            int Index = -1
            ) : GuiField(Id, Prompt, Index) {
    }

public record GuiTextArea(
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

public record GuiInteger(
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


public record GuiViewDialog(GuiDialog Dialog) : IGuiEntry {
    }
public record GuiViewBinding(GuiBinding Dialog)  : IGuiEntry {
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
