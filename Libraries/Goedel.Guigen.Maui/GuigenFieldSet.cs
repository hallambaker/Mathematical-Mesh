using Microsoft.UI.Xaml.Documents;

using System;
using System.Security.Cryptography;

using Windows.ApplicationModel.VoiceCommands;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Guigen.Maui;





public class GuigenFieldSet : IWidget, IPresentation {


    ///<summary>The bound UI</summary> 
    public GuigenBinding Binding { get; }

    ///<summary>The main window.</summary> 
    public IMainWindow MainWindow => Binding.MainWindow;

    public virtual View View { get; }



    public List<GuigenField> MauiFields { get; } = new();

    //int[] FieldMap;

    int GridRow { get; set; } = 0;
    int GridColumn { get; set; } = 0;

    public IBindable Data { get; set; }
    public Layout ButtonBox { get; private set;  }

    public bool IsChooser { get; set; } = false;
    protected GuiBinding FieldBinding { get; }


    public bool IsSection { get; set; } = true;

    public bool IsReadOnly { get; set; } = true;

    public bool IsEditMode { get; set; } = false;


    /*
     * The primary containers used in the display.
     * 
     * On a desktop platform, these appear as a stacked list, on a mobile device,
     * a paged mod may be employed.
     * 
     *      ActionMenu
     *      [Chooser]
     *      FieldGrid
     *      ContextMenu
     */

    ///<summary>Container for the action section</summary> 
    public Layout ActionMenu            { get; set; }

    ///<summary>Container for the fields section</summary> 
    public Grid FieldGrid               { get; private set; }

    ///<summary>Container for the confirm/cancel/context section</summary> 
    public Layout ContextMenu           { get; set; }


    public GuigenButton ConfirmButton   { get; set; }

    public GuigenButton CancelButton    { get; set; }

    public GuigenButton EditButton      { get; set; }

    public GuigenButton UpdateButton    { get; set; }




    public GuigenFieldSet(
                GuigenBinding binding,
                GuiBinding fieldBinding = null,
                IBindable? data = null) {
        Binding = binding;
        FieldBinding = fieldBinding;
        FieldGrid = MakeFieldGrid();
        }

    private Grid MakeFieldGrid() {
        var fieldGrid = new Grid();
        fieldGrid.AddColumnDefinition(new ColumnDefinition(GridLength.Auto));
        fieldGrid.AddColumnDefinition(new ColumnDefinition(GridLength.Star));
        return fieldGrid;
        }

    protected void AddFields(GuiBinding fieldBinding, IBindable data) {

        foreach (var entry in fieldBinding.BoundProperties) {
            switch (entry) {
                case GuiBoundPropertyBoolean bound: {
                    var field = new GuigenFieldBoolean(this, bound, data);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundPropertyString bound: {
                    var field = new GuigenFieldString(this, bound, data);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundTextArea bound: {
                    var field = new GuigenFieldTextArea(this, bound, data);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundPropertyColor bound: {
                    var field = new GuigenFieldColor(this, bound, data);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundPropertySize bound: {
                    var field = new GuigenFieldSize(this, bound, data);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundPropertyDecimal bound: {
                    var field = new GuigenFieldDecimal(this, bound, data);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundPropertyInteger bound: {
                    var field = new GuigenFieldInteger(this, bound, data);
                    MauiFields.Add(field);
                    break;
                    }
                //case GuiBoundPropertyQRScan bound: {
                //    var field = new GuigenFieldQr(this, bound, data);
                //    MauiFields.Add(field);
                //    break;
                //    }
                case GuiBoundPropertyIcon bound: {
                    var field = new GuigenFieldIcon(this, bound, data);
                    MauiFields.Add(field);
                    break;
                    }
                //case GuiBoundPropertyChooser bound: {
                //    var field = new GuigenFieldChooser(this, bound, data);
                //    MauiFields.Add(field);
                //    ButtonBox = new HorizontalStackLayout();
                //    IsChooser = true;
                //    break;
                //    }
                case GuiBoundPropertyList bound: {
                    var field = new GuigenFieldList(this, bound, data);
                    MauiFields.Add(field);
                    break;
                    }
                default: {
                    break;
                    }

                }
            }
        }

    public void SetEditable(bool isEditable) {
        IsEditMode = isEditable;
        foreach (var field in MauiFields) {
            field.SetEditable();
            }
    }

    public void Update() {
        GetFields(Data);
        SetEditable(false);
        }





    public void SetFields(IBindable data) {
        Data = data;
        if (data == null) {
            return;
            }
        if (!data.Binding.IsType(data)) {
            return;
            }
        foreach (var field in MauiFields) {
            field.SetField(data);
            }
        }

    public void GetFields(IBindable data) {
        if (data == null) {
            return;
            }

        foreach (var field in MauiFields) {
            field.GetField(data);
            }
        }


    public void Feedback(GuiResultInvalid feedback) {
        foreach (var field in MauiFields) {
            field.ClearFeedback();
            }

        foreach (var message in feedback.Messages) {
            //var index = FieldMap[message.Index];
            //if (index != -1) {
            //    MauiFields[index].SetFeedback(message);
            //    }
            }
        }


    public virtual int AddField(IView label, IView child, IView? feedback=null) {

        FieldGrid.Add(label, 0, GridRow);
        if (child != null) {
            FieldGrid.Add(child, 1, GridRow);
            }
        if (feedback != null) {
            FieldGrid.Add(feedback, 2, GridRow);
            }
        return GridRow++;
        }

    public virtual void ReplaceField(IView current, IView replacement, int gridRow) {
        FieldGrid.Remove(current);
        FieldGrid.Add(replacement, 1, gridRow);
        }


    public void AddField(IView child) {
        FieldGrid.Add(child, 0, GridRow++);
        }

    public void AddStaticButtons(IEnumerable<IGuiEntry> entries) {
        if (entries is null) {
            return;
            }
        foreach (var entry in entries) {
            if (entry is GuiButton buttonEntry) {
                var button = Binding.GetButton(buttonEntry.Target);
                ActionMenu.Add(button.View);
                }
            }

        }


    /// <summary>
    /// Add context sensitive buttons to the Context Menu.
    /// </summary>
    /// <param name="layout">The context menu layout</param>
    public void AddButtons(Layout layout) {

        foreach (var field in FieldBinding.BoundProperties) {
            switch (field) {
                case GuiBoundPropertyButton button1: {
                    if (MainWindow.Gui.Selections.TryGetValue(button1.Label, out var action)) {
                        var button = new GuigenSelectionButton(MainWindow, action, Data);
                        layout.Add(button.View);
                        }
                    break;
                    }
                case GuiBoundPropertySelection selection: {
                    if (MainWindow.Gui.Selections.TryGetValue(selection.Label, out var action)) {
                        var button = new GuigenSelectionButton(MainWindow, action, Data);
                        layout.Add (button.View);
                        }
                    break;
                    }
                }
            }

        }

    IView AddButton(GuiButton button) {

        switch (button.Target) {

            case GuiSection section: {
                return new GuigenSectionButton(Binding, section).View;
                }
            case GuiAction action: {
                return new GuigenActionButton(Binding, action) {
                    FieldSet = this}.View;
                }
            }
        throw new NotImplementedException();
        }

    }

public class GuigenFieldSetSingle : GuigenFieldSet {
    
    public override View View => MainLayout;
    Layout MainLayout;
    GuiSection? GuiSection;
    public GuigenFieldSetSingle(
            GuigenBinding binding,
            GuiBindingSingle fieldBinding = null,
            IBindable? data = null,
            GuiSection? guiSection=null) : base(binding, fieldBinding, data) {
        GuiSection = guiSection;

        // Create the Action buttons
        ActionMenu = new FlexLayout() { 
            Wrap = FlexWrap.Wrap
            };
        //AddButtons(ActionMenu);
        AddStaticButtons(guiSection?.Entries);

        // Create the fields 
        AddFields(fieldBinding, data);

        // Create the Context Menu for the Bottom
        CancelButton = new GuigenButton(Binding, null, "Cancel", OnCancel);
        UpdateButton = new GuigenButton(Binding, null, "Update", OnCancel);
        EditButton = new GuigenButton(Binding, null, "Edit", OnCancel);
        
        ContextMenu = new FlexLayout() {
            Wrap = FlexWrap.Wrap
            };
        SetState();

        // Create the main layout
        MainLayout = new VerticalStackLayout {
            ActionMenu,
            FieldGrid,
            ContextMenu
            };
        }

    void SetState() {
        ContextMenu.Clear();

        if (!IsSection | IsEditMode) {
            ContextMenu.Add(CancelButton.View);
            }
        else if (!IsReadOnly) {
            ContextMenu.Add(IsEditMode ? UpdateButton.View: EditButton.View);
            }
        }

    private void OnCancel(object sender, EventArgs e) {
        SetEditable(false);
        }

    private void OnEdit(object sender, EventArgs e) {
        SetEditable(true);
        }

    private void OnUpdate(object sender, EventArgs e) {
        // pull data from the fields

        // preform the commit action

        SetEditable(false);
        }

    }


public class GuigenFieldSetMultiple : GuigenFieldSet {

    public override View View => MainLayout;
    Layout MainLayout;

    ///<summary>The chooser section (if present)</summary> 
    public GuigenFieldChooser Chooser { get; set; }

    public GuigenFieldSetMultiple(
            GuigenBinding binding,
            GuiBindingMultiple fieldBinding = null,
            GuiSection guiSection = null,
            IBindable? data = null) : base(binding, fieldBinding, data) {

        ActionMenu = new FlexLayout() {
            Wrap = FlexWrap.Wrap
            };
        AddStaticButtons(guiSection?.Entries);

        Chooser = new GuigenFieldChooser(this, fieldBinding.Chooser, data);

        ContextMenu = new FlexLayout() {
            Wrap = FlexWrap.Wrap
            };

        SetState();

        // Create the main layout
        MainLayout = new VerticalStackLayout {
            ActionMenu,
            Chooser.View,
            FieldGrid,
            ContextMenu
            };
        }


    public void ClearSelection() {
        FieldGrid.IsVisible = false;
        }

    // An item has been selected 
    public void OnItemSelected(IBindable item) {
        FieldGrid?.Clear();
        AddFields(item.Binding, item);
        FieldGrid.IsVisible = true;
        }







    void SetState() {

        }

    private void OnCancel(object sender, EventArgs e) {
        SetEditable(false);
        }

    private void OnEdit(object sender, EventArgs e) {
        SetEditable(true);
        }

    private void OnUpdate(object sender, EventArgs e) {
        // pull data from the fields

        // preform the commit action

        SetEditable(false);
        }

    }





/// <summary>
/// Present field set for an action dialog.
/// </summary>
public class GuigenFieldSetAction : GuigenFieldSet {

    GuiAction GuiAction { get; }

    public GuigenFieldSetAction(
            GuigenBinding binding,
            GuiAction guiAction) : base(binding, guiAction.Binding) {
        GuiAction = guiAction;
        }

    private void SetState() {
        ContextMenu.Clear();

        ContextMenu.Add(CancelButton.View);
        ContextMenu.Add(ConfirmButton.View);
        }

    }


public class GuigenFieldSetActionSingle : GuigenFieldSetAction {


    public override View View => MainLayout;
    Layout MainLayout;

    public GuigenFieldSetActionSingle(
                GuigenBinding binding,
                GuiAction guiAction) : base (binding, guiAction) {

        // Create the backing data
        Data = guiAction.Factory();

        // Create the fields 
        AddFields(FieldBinding, Data);

        ContextMenu = new FlexLayout() {
            Wrap = FlexWrap.Wrap
            };
        CancelButton = new GuigenButton(Binding, null, "Cancel", OnCancel);
        ConfirmButton = new GuigenButton(Binding, null, "Confirm", OnCancel);

        // Create the main layout
        MainLayout = new VerticalStackLayout {
            ActionMenu,
            FieldGrid,
            ContextMenu
            };
        }

    private void OnCancel(object sender, EventArgs e) {
        //Binding.CancelActionDialog();
        }

    private void OnConfirm(object sender, EventArgs e) {
        //Binding.AttemptActionCallback();
        }


    }

public class GuigenFieldSetActionMultiple : GuigenFieldSetAction {

    public override View View => MainLayout;
    Layout MainLayout;

    public GuigenFieldSetActionMultiple(
            GuigenBinding binding,
            GuiAction guiAction) : base(binding, guiAction) {
        }
    }

public class GuigenFieldSetQr : GuigenFieldSet {

    public GuigenFieldSetQr(
            GuigenBinding binding,
            Layout? stack,
            GuiBindingQr fieldBinding = null,
            IBindable? data = null) : base(binding, fieldBinding, data) {
        SetState();
        }

    void SetState() {

        }

    }

