namespace Goedel.Guigen;
/// <summary>
/// 
/// </summary>
public abstract class Gui {

    ///<summary>List of all the Icon Descriptions</summary> 
    public abstract List<GuiImage> Icons { get; }

    ///<summary>List of all the Section Descriptions</summary> 
    public abstract List<GuiSection> Sections { get; }

    ///<summary>List of all the Action Descriptions</summary> 
    public abstract List<GuiAction> Actions { get; }

    ///<summary>List of all the Dialog Descriptions</summary> 
    public abstract List<GuiDialog> Dialogs { get; }


    ///<summary>List of all the Result Descriptions</summary> 
    public abstract List<GuiResult> Results { get; }

    public virtual GuiSection DefaultSection => Sections[0];

    public virtual string GetPrompt(GuiPrompt guiPrompt) => guiPrompt.Prompt;


    }
