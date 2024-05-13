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

public interface IButtonState {

    ButtonState ButtonState { get; }
    }

public enum ReturnNavigation {
    Home,
    Section,
    Action
    }


public enum ReturnResult {
    Home,
    Completed,
    Report,
    Initialized,
    Valid,
    Invalid,
    Error,
    Teardown
    }



public enum ButtonState {
    Enabled,
    Selected,
    Disabled


    }


public interface IResult : IBindable {



    public string Message { get; }


    public ResourceId? ResourceId { get; }

    ReturnResult ReturnResult { get; }


    public object?[] GetValues();

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

    public GuiBinding? Binding => null;

    ///<summary></summary> 

    public static NullResult Teardown { get; } = new TeardownResult() { };

    public static NullResult Initialized { get; }  = new InitializedResult() { };

    public static NullResult Valid { get; } = new ValidResult();

    public static NullResult Completed { get; } = new CompletedResult();

    public static NullResult HomeResult { get; } = new HomeResult();

    public object[] GetValues() => Array.Empty<object>();
    }

public record HomeResult : NullResult {
    public override ReturnResult ReturnResult { get; init; } = ReturnResult.Home
;
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


public record GuiBinding(
                Func<object, bool> IsType,
                Func<IBindable> Factory,
                GuiBoundProperty[] BoundProperties
                ) {

    }

public record GuiBindingSingle(
                Func<object, bool> IsType,
                Func<IBindable> Factory,
                GuiBoundProperty[] BoundProperties
                ) : GuiBinding(IsType, Factory, BoundProperties) {
    }

public record GuiBindingMultiple(
                Func<object, bool> IsType,
                Func<IBindable> Factory,
                GuiBoundProperty[] BoundProperties,
                int Index
                ) : GuiBinding(IsType, Factory, BoundProperties) {
    public GuiBoundPropertyChooser Chooser => (BoundProperties[Index] as GuiBoundPropertyChooser)!;
    }

public record GuiBindingQr(
                Func<object, bool> IsType,
                Func<IBindable> Factory,
                GuiBoundProperty[] BoundProperties,
                int Index
                ) : GuiBinding(IsType, Factory, BoundProperties) {
    public GuiBoundPropertyQRScan Chooser => (BoundProperties[Index] as GuiBoundPropertyQRScan)!;
    }


public record GuiBoundProperty (
                string? Label) {
    public virtual bool IsReadOnly => true;

    }

public record GuiBoundPropertyButton(
                string? Label) : GuiBoundProperty(Label) {
    public IButtonTarget Target = null!;

    }

public record GuiBoundPropertySelection(
                string? Label,
                string? Prompt) : GuiBoundPropertyPrompted(Label, Prompt) {
    public IButtonTarget Target = null!;

    }

public record GuiBoundPropertyPrompted(
                string? Label,
                string? Prompt) : GuiBoundProperty (Label){
    }

public record GuiBoundPropertyBoolean(
                string? Label,
                string? Prompt,
                Func<object, bool?> Get,
                Action<object, bool?>? Set
                ) : GuiBoundPropertyPrompted(Label, Prompt) {
    public override bool IsReadOnly => Set is null;
    }

public record GuiBoundPropertyString(
                string? Label,
                string? Prompt,
                Func<object, string?> Get,
                Action<object, string?>? Set,
                int? Width = null) : GuiBoundPropertyPrompted(Label, Prompt) {
    public override bool IsReadOnly => Set is null;
    }

public record GuiBoundTextArea(
                string? Label,
                string? Prompt,
                Func<object, string?> Get,
                Action<object, string?>? Set) : GuiBoundPropertyPrompted(Label, Prompt) {
    public override bool IsReadOnly => Set is null;
    }


public record GuiBoundPropertyColor(
                string? Label,
                string? Prompt,
                Func<object, IFieldColor?> Get,
                Action<object, IFieldColor?>? Set) : GuiBoundPropertyPrompted(Label, Prompt) {
    public override bool IsReadOnly => Set is null;
    }


public record GuiBoundPropertySize(
                string? Label,
                string? Prompt,
                Func<object, IFieldSize?> Get,
                Action<object, IFieldSize?>? Set) : GuiBoundPropertyPrompted(Label, Prompt) {
    public override bool IsReadOnly => Set is null;
    }


public record GuiBoundPropertyDecimal(
                string? Label,
                string? Prompt,
                Func<object, decimal?> Get,
                Action<object, decimal?>? Set) : GuiBoundPropertyPrompted(Label, Prompt) {
    public override bool IsReadOnly => Set is null;
    }


public record GuiBoundPropertyInteger(
                string? Label,
                string? Prompt,
                Func<object, int?> Get,
                Action<object, int?>? Set) : GuiBoundPropertyPrompted(Label, Prompt) {
    public override bool IsReadOnly => Set is null;
    }



public record GuiBoundPropertyQRScan(
                string? Label,
                string? Prompt,
                Func<object, GuiQR?> Get,
                Action<object, GuiQR?>? Set) : GuiBoundPropertyPrompted(Label, Prompt) {
    public override bool IsReadOnly => Set is null;
    }


public record GuiBoundPropertyIcon(
                string? Label,
                string? Prompt,
                Func<object, IFieldIcon?> Get,
                Action<object, IFieldIcon?>? Set) : GuiBoundPropertyPrompted(Label, Prompt) {
    public override bool IsReadOnly => Set is null;
    }


public record GuiBoundPropertyDataActions(
                string? Label,
                string? Prompt,
                Func<object, IDataActions?> Get,
                Action<object, IDataActions?>? Set) : GuiBoundPropertyPrompted(Label, Prompt) {
    public override bool IsReadOnly => Set is null;
    }
public record GuiBoundPropertyChooser(
                string? Label,
                string? Prompt,
                Func<object, ISelectCollection?> Get,
                Action<object, ISelectCollection?>? Set,
                List<GuiEntry>? Entries = null) : GuiBoundPropertyPrompted(Label, Prompt) {

    // The selection is always read only, but items in the selection MAY be editable.
    public override bool IsReadOnly => true;
    }

public record GuiBoundPropertyList(
                string? Label,
                string? Prompt,
                Func<object, ISelectList?> Get,
                Action<object, ISelectList?>? Set,
                GuiBinding EntryBinding,
                List<GuiEntry>? Entries = null) : GuiBoundPropertyPrompted(Label, Prompt) {
    public override bool IsReadOnly => Set is null;
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

    ///<summary>The action entries</summary> 
    public List<IGuiEntry> Entries { get; set; } = null!;

    public Func<object, bool> IsBoundType { get; set; } = (object _) => false;
    public Func<object, bool> IsBacker { get; set; } = (object _) => false;

    }

public interface IGetState {
    Func<ButtonState>? GetButton { get; }
    }


public record GuiSection (
            string Id,
            string Prompt,
            string Icon,
            GuiBinding Binding,
            bool Primary
            ) : GuiFieldSet(Id, Prompt, Binding), IButtonTarget, IGetState {

    public Func<bool> Active { get; set; } = () => false;

    public Gui Gui { get; set; } = null!;
    public IPresentation? Presentation { get; set; } = null;


    public IBindable? Data {
            get => data ?? BindData().CacheValue(out data);
            set => data = value; }
    IBindable? data = null;

    public Action UpdateData { get; set; }


    public Func<IBindable?> BindData { get; set; } = () => null! ;


    ///<summary>The action entries</summary> 
    public List<IGuiEntry> Entries { get; set; } = null!;



    public Func<ButtonState>? GetButton { get; set; } = null;

    public void Reset(Func<IBindable?> bindData, Func<ButtonState>? getButton) {
        Data = null;
        BindData = bindData;
        GetButton = getButton;
        }

    }


public record GuiAction(
            string Id,
            string Prompt,
            string Icon,
            GuiBinding Binding,
            FactoryCallback Factory,
            bool IsSelect = false,
            bool IsConfirmation = false,
            Action<object, IBindable>? setContext = null
            ) : GuiFieldSet(Id, Prompt, Binding), IButtonTarget {
    public IPresentation? Presentation { get; set; } = null;

    public ActionCallback Callback { get; set; } = null!;
    }

public record GuiDataAction(
            string? Prompt,
            string? Icon,
            DataActionCallback Callback) {
    }

public delegate Task<IResult> DataActionCallback(GuiDataAction action, object IBindable);

public delegate Task<IResult> ActionCallback(object IBindable);
public delegate IBindable FactoryCallback();




public record GuiButton(
            string Id,
            IButtonTarget Target
            ) : GuiItem(Id), IGuiEntry {
    }







public interface IGuiEntry {
    }




public interface IButtonTarget {
    string Icon { get; }
    string Prompt { get; }
    }



public interface IFieldColor {
    }

public interface IFieldSize {
    }
public interface IFieldIcon {

    public string Source { get; }
    }


public interface IDataActions {
    }


