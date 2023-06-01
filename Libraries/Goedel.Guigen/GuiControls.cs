using Goedel.Utilities;

using System;

namespace Goedel.Guigen;


public interface IPresentation {
    }




public interface IBindable {
    
    ///<summary>Returns the binding for the data type</summary> 
    public GuiBinding Binding { get; }


    public bool Validate();

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


public delegate void SetterString(string field);
public delegate string GetterString();
public record GuiBoundPropertyString (
                GetterString GetterString,
            SetterString SetterString

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


public delegate void ActionCallback(object parameters);
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
            string Prompt
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
            string Prompt
            ) : GuiField(Id, Prompt) {
    }
public record GuiSize(
            string Id,
            string Prompt
            ) : GuiField(Id, Prompt) {
    }
public record GuiDecimal(
            string Id,
            string Prompt
            ) : GuiField(Id, Prompt) {
    }
public record GuiIcon(
            string Id,
            string Prompt
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