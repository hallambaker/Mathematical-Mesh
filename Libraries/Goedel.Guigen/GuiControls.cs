using Goedel.Utilities;

using System;

namespace Goedel.Guigen;


public interface IPresentation {
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
            List<IDialogEntry> Entries
            ) : GuiItem(Id), ISectionEntry {
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
            bool Primary,
            List<ISectionEntry>Entries
            ) : GuiPrompt(Id, Prompt), IButtonTarget {
    public IPresentation? Presentation { get; set; } = null;

    }

public record GuiAction(
            string Id,
            string Prompt,
            string Icon,
            List<IActionEntry> Entries
            ) : GuiPrompt(Id, Prompt), IButtonTarget {
    }



public record GuiChooser(
            string Id,
            string Prompt,
            string Icon,
            List<IChooserEntry> Entries
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