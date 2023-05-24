using Goedel.Utilities;

namespace Goedel.Guigen;
public abstract class Gui {
    ///<summary>List of all the Icon Descriptions</summary> 
    public abstract List<GuiImage> Icons { get; }

    ///<summary>List of all the Section Descriptions</summary> 
    public abstract List<GuiSection> Sections { get; }

    ///<summary>List of all the Action Descriptions</summary> 
    public abstract List<GuiAction> Actions { get; }

    ///<summary>List of all the Dialog Descriptions</summary> 
    public abstract List<GuiDialog> Dialogs { get; }

    }

///<summary></summary> 
public record GuiImage (
            string Icon
            ){
    }

public record GuiItem(
            string Id) {


    }



public record GuiSection (
            string Id,
            string Prompt,
            string Icon,
            bool Primary,
            List<ISectionEntry>Entries
            ) : GuiItem(Id), IButtonTarget {
    }

public record GuiAction (
            string Id,
            string Prompt,
            string Icon,
            List<IActionEntry> Entries
            ) : GuiItem(Id), IButtonTarget {
    }

public record GuiDialog (
            string Id,
            List<IDialogEntry> Entries
            ) : GuiItem(Id), ISectionEntry {
    }

public record GuiChooser (
            string Id,
            string Prompt,
            string Icon,
            List<IChooserEntry> Entries
            ) : GuiItem(Id), ISectionEntry, IActionEntry, IDialogEntry {


    }

public record GuiButton(
            string Id
            ) : GuiItem(Id), ISectionEntry, IChooserEntry {


    }


public record GuiField(
            string Id,
            string Prompt
            ) : GuiItem(Id), IDialogEntry, IActionEntry {
    }

public record GuiContext(
            string Id,
            string Prompt
            ) : GuiField (Id, Prompt) { 
    }

public record GuiText(
            string Id,
            string Prompt
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