namespace Goedel.Guigen;
public abstract class Gui {
    ///<summary>List of all the Icon Descriptions</summary> 
    public abstract List<GuiIcon> Icons { get; }

    ///<summary>List of all the Section Descriptions</summary> 
    public abstract List<GuiSection> Sections { get; }

    ///<summary>List of all the Action Descriptions</summary> 
    public abstract List<GuiAction> Actions { get; }

    ///<summary>List of all the Dialog Descriptions</summary> 
    public abstract List<GuiDialog> Dialogs { get; }

    }

///<summary></summary> 
public record GuiIcon (
            string Icon
            ){
    }

public record GuiSection (
            string Id,
            string Prompt,
            string Icon,
            bool Primary,
            List<ISectionEntry>Entries
            ) : IButtonTarget {
    }

public record GuiAction (
            string Id,
            string Prompt,
            string Icon,
            List<IActionEntry> Entries
            ) : IButtonTarget {
    }

public record GuiDialog (
            string Id,
            List<IDialogEntry> Entries
            ) : ISectionEntry {
    }

public record GuiChooser (
            string Id,
            string Prompt,
            string Icon
            ) : ISectionEntry, IActionEntry, IDialogEntry {


    }

public record GuiButton(
            string Id
            ) : ISectionEntry, IChooserEntry {


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