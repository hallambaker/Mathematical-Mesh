using Goedel.Utilities;

using System;

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


public interface IResult : IBindable {

    }

public record GuiBinding {

    public GuiBoundProperty[] BoundProperties { get; }



    public GuiBinding(GuiBoundProperty[] boundProperties) {
        BoundProperties = boundProperties;
        }

    }

public record GuiBoundProperty  {
    ///<summary>Error to be filled if Validate is called and finds an error</summary> 
    public string? Error { get; set; } = null;

    }


public record GuiBoundPropertyString (
                Func<IBindable, string> GetterString,
                Action<IBindable, string> SetterString

            ) : GuiBoundProperty {
    }

public record GuiBoundPropertyChooser(
                Func<IBindable, ISelectCollection> GetterString,
                Action<IBindable, ISelectCollection> SetterString

            ) : GuiBoundProperty {
    }

public record GuiBoundPropertyColor(
                Func<IBindable, IFieldColor> GetterString,
                Action<IBindable, IFieldColor> SetterString

            ) : GuiBoundProperty {
    }


public record GuiBoundPropertySize(
                Func<IBindable, IFieldSize> GetterString,
                Action<IBindable, IFieldSize> SetterString

            ) : GuiBoundProperty {
    }


public record GuiBoundPropertyDecimal(
                Func<IBindable, double> GetterString,
                Action<IBindable, double> SetterString

            ) : GuiBoundProperty {
    }


public record GuiBoundPropertyIcon(
                Func<IBindable, IFieldIcon> GetterString,
                Action<IBindable, IFieldIcon> SetterString

            ) : GuiBoundProperty {
    }



///<summary></summary> 
public record GuiImage (
            string Icon
            ){
    }


public record GuiItem(
            string Id) {
    }

public record GuiDialog : GuiItem ,ISectionEntry {
    public IPresentation? Presentation { get; set; } = null;

    public string Id { get; set; }
    public List<IDialogEntry> Entries { get; set; } = null!;

    public GuiDialog(
           string id,
            List<IDialogEntry> entries = null!
           ) : base(id){
        Id = id;
        Entries = entries;

        }


    }




public record GuiButton(
            string Id,
            IButtonTarget Target
            ) : GuiItem(Id), ISectionEntry, IChooserEntry {


    }


public record GuiPrompt(
            string Id,
            string Prompt
            ) : GuiItem(Id), IDialogEntry, IActionEntry {



    }


public record GuiSection (
            string Id,
            string Prompt,
            string Icon,
            bool Primary
            ) : GuiPrompt(Id, Prompt), IButtonTarget {
    public IPresentation? Presentation { get; set; } = null;

    public List<ISectionEntry> Entries { get; set; } = null!;


    }


public delegate IResult ActionCallback(object IBindable);
public delegate IBindable FactoryCallback();
public record GuiAction(
            string Id,
            string Prompt,
            string Icon,
            FactoryCallback Factory
            ) : GuiPrompt(Id, Prompt), IButtonTarget {
    public IPresentation? Presentation { get; set; } = null;

    public List<IActionEntry> Entries { get; set; } = null!;

    public ActionCallback Callback { get; set; } = null!;
    }



public record GuiChooser(
            string Id,
            string Prompt,
            string Icon,
            int Index = -1,
            List<IChooserEntry> Entries = null!
            ) : GuiPrompt(Id, Prompt), ISectionEntry, IActionEntry, IDialogEntry {


    }




public record GuiField(
            string Id,
            string Prompt
            ) : GuiPrompt(Id, Prompt), IDialogEntry, IActionEntry {
    }

public record GuiContext(
            string Id,
            string Prompt,
            int Index = -1
            ) : GuiField (Id, Prompt) { 
    }

public record GuiText(
            string Id,
            string Prompt,
            int Index = -1
            ) : GuiField(Id, Prompt) {
    }

public record GuiColor(
            string Id,
            string Prompt,
            int Index = -1
            ) : GuiField(Id, Prompt) {
    }
public record GuiSize(
            string Id,
            string Prompt,
            int Index = -1
            ) : GuiField(Id, Prompt) {
    }
public record GuiDecimal(
            string Id,
            string Prompt,
            int Index = -1
            ) : GuiField(Id, Prompt) {
    }
public record GuiIcon(
            string Id,
            string Prompt,
            int Index = -1
            ) : GuiField(Id, Prompt) {
    }

public interface ISectionEntry {
    }

public interface IActionEntry {
    }

public interface IDialogEntry {
    }

public interface IChooserEntry {
    }

public interface IButtonTarget {
    }



public interface IFieldColor {
    }

public interface IFieldSize {
    }
public interface IFieldIcon {
    }



public interface ISelectCollection {
    }