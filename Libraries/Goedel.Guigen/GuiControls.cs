using Goedel.Utilities;

using System;
using System.Threading.Tasks;

namespace Goedel.Guigen;


public interface IPresentation {
    }


public interface IDialog {

    GuiDialog Dialog(Gui gui);
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

    ///<summary>The binding used to select items for display in a selector box.</summary> 
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

//[Flags]
//public enum ActionMode {
//    Initialize = 1,
//    Validate = 2,
//    Execute = 4
//    }




public record GuiBinding {

    public Func<object, bool> IsType { get; }

    public Func<IBindable> Factory { get; }


    public GuiBoundProperty[] BoundProperties { get; }



    public GuiBinding(
                Func<object, bool> isType,
                Func<IBindable> factory,
                GuiBoundProperty[] boundProperties
                ) {
        BoundProperties = boundProperties;
        IsType = isType;
        Factory = factory;
        }

    }






public record GuiBoundProperty (
                string? Label) {


    }

public record GuiBoundPropertyButton(
                string? Label) : GuiBoundProperty(Label) {
    public IButtonTarget Target = null!;

    }

public record GuiBoundPropertyPrompted(
                string? Label,
                string? Prompt) : GuiBoundProperty (Label){
    }

public record GuiBoundPropertyBoolean(
                string? Label,
                string? Prompt,
                Func<object, bool> Get,
                Action<object, bool> Set
                ) : GuiBoundPropertyPrompted(Label, Prompt) {
    }

public record GuiBoundPropertyString(
                string? Label,
                string? Prompt,
                Func<object, string> Get,
                Action<object, string> Set,
                int? Width = null) : GuiBoundPropertyPrompted(Label, Prompt) {
    }

public record GuiBoundTextArea(
                string? Label,
                string? Prompt,
                Func<object, string> Get,
                Action<object, string> Set) : GuiBoundPropertyPrompted(Label, Prompt) {
    }


public record GuiBoundPropertyColor(
                string? Label,
                string? Prompt,
                Func<object, IFieldColor> Get,
                Action<object, IFieldColor> Set) : GuiBoundPropertyPrompted(Label, Prompt) {
    }


public record GuiBoundPropertySize(
                string? Label,
                string? Prompt,
                Func<object, IFieldSize> Get,
                Action<object, IFieldSize> Set) : GuiBoundPropertyPrompted(Label, Prompt) {
    }


public record GuiBoundPropertyDecimal(
                string? Label,
                string? Prompt,
                Func<object, decimal?> Get,
                Action<object, decimal?> Set) : GuiBoundPropertyPrompted(Label, Prompt) {
    }


public record GuiBoundPropertyInteger(
                string? Label,
                string? Prompt,
                Func<object, int?> Get,
                Action<object, int?> Set) : GuiBoundPropertyPrompted(Label, Prompt) {
    }



public record GuiBoundPropertyQRScan(
                string? Label,
                string? Prompt,
                Func<object, GuiQR> Get,
                Action<object, GuiQR> Set) : GuiBoundPropertyPrompted(Label, Prompt) {
    }


public record GuiBoundPropertyIcon(
                string? Label,
                string? Prompt,
                Func<object, IFieldIcon> Get,
                Action<object, IFieldIcon> Set) : GuiBoundPropertyPrompted(Label, Prompt) {
    }

public record GuiBoundPropertyChooser(
                string? Label,
                string? Prompt,
                Func<object, ISelectCollection> Get,
                Action<object, ISelectCollection> Set,
                List<GuiEntry>? Entries = null) : GuiBoundPropertyPrompted(Label, Prompt) {
    }

public record GuiBoundPropertyList(
                string? Label,
                string? Prompt,
                Func<object, ISelectCollection> Get,
                Action<object, ISelectCollection> Set,
                GuiBinding EntryBinding,
                List<GuiEntry>? Entries = null) : GuiBoundPropertyPrompted(Label, Prompt) {
    }


public record GuiEntry(
                string? Label,
                Func<object, bool> isType,
                GuiBoundProperty[] boundProperties) : GuiBinding(isType, null, boundProperties) {
    }










public class GuiQR {

    public string? Offer { get; set; }
    public string? Identifier { get; set; }
    public string? CapturedByCamera { get; set; }
    public object? ReceivedByMessage { get; set; }

    public GuiQR() {
        }


    }


///<summary></summary> 
public record GuiImage (
            string Icon
            ){
    }


/// <summary>
/// Backing class for a GUI item.
/// </summary>
/// <param name="Id"></param>
public record GuiItem(
            string Id) {
    }


/// <summary>
/// Backing class for a GUI element that has a prompt.
/// </summary>
/// <param name="Id">The unique identifier</param>
/// <param name="Prompt">The prompt.</param>
public record GuiPrompt(
            string Id,
            string Prompt
            ) : GuiItem(Id), IGuiEntry {
    }

/// <summary>
/// Backing class for a GUI element that presents a set of bound fields.
/// </summary>
/// <param name="Id"></param>
/// <param name="Prompt"></param>
/// <param name="Binding"></param>
public record GuiFieldSet (
            string Id,
            string Prompt,
            GuiBinding Binding
            ) : GuiPrompt(Id, Prompt){
    }


/// <summary>
/// Backing class for a GUI Dialog 
/// </summary>
/// <param name="Id"></param>
/// <param name="Prompt"></param>
/// <param name="Icon"></param>
/// <param name="Factory"></param>
public record GuiDialog(

            string Id,
            string Prompt,
            string Icon,
            GuiBinding Binding,
            FactoryCallback Factory) : GuiFieldSet(Id, Prompt, Binding), IGuiEntry {


    public List<IGuiEntry> Entries { get; set; } = null!;

    public Func<object, bool> IsBoundType { get; set; } = (object _) => false;
    public Func<object, bool> IsBacker { get; set; } = (object _) => false;

    }




public record GuiSection (
            string Id,
            string Prompt,
            string Icon,
            GuiBinding Binding,
            bool Primary
            ) : GuiFieldSet(Id, Prompt, Binding), IButtonTarget {

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


public record GuiAction(
            string Id,
            string Prompt,
            string Icon,
            GuiBinding Binding,
            FactoryCallback Factory,
            bool IsSelect = false
            ) : GuiFieldSet(Id, Prompt, Binding), IButtonTarget {
    public IPresentation? Presentation { get; set; } = null;

    public List<IGuiEntry> Entries { get; set; } = null!;

    public ActionCallback Callback { get; set; } = null!;
    }


public delegate Task<IResult> ActionCallback(object IBindable);
public delegate IBindable FactoryCallback();




public record GuiField(
            string Id,
            string Prompt,
            int Index
            ) : GuiPrompt(Id, Prompt), IGuiEntry {
    }

public record GuiButton(
            string Id,
            IButtonTarget Target
            ) : GuiItem(Id), IGuiEntry {
    }



public record GuiChooser(
            string Id,
            string Prompt,
            string Icon,
            int Index = -1,
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
            int Index = -1,
            int? Width = null
            ) : GuiField(Id, Prompt, Index) {
    }

public record GuiBoolean(
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

public record GuiList(
            string Id,
            string Prompt,
            string Icon,
            GuiDialog dialog = null!,
            int Index = -1,
            List<IGuiEntry> Entries = null!
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
