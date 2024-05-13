using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Documents;

using System;
using System.Reflection;
using System.Security.Cryptography;

using Windows.ApplicationModel.VoiceCommands;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Guigen.Maui;


public interface IBound {
    public bool IsEditMode { get; }

    public GuigenBinding Binding { get; }
    public void ReplaceField(IView current, IView replacement, int gridRow);

    public void FieldChanged(GuigenField field);
    }


public interface IBoundChooser : IBound {


    public void OnItemSelected(IBindable item);

    }

public class GuigenFieldSet : IWidget, IPresentation, IBound {


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

    public bool IsEditMode { get; set; } = false;


    public bool IsEditable { get; private set; } = false;


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

    public GuigenFieldSet Return { get; set; }


    public GuigenFieldSet(
                GuigenBinding binding,
                GuiBinding fieldBinding = null,
                IBindable? data = null,
                GuigenFieldSet fieldSet = null) {
        Binding = binding;
        FieldBinding = fieldBinding;
        FieldGrid = MakeFieldGrid();
        IsEditable = false;
        IsEditMode = false;
        Return = fieldSet;
        }

    private Grid MakeFieldGrid() {
        var fieldGrid = new Grid();
        fieldGrid.AddColumnDefinition(new ColumnDefinition(GridLength.Auto));
        fieldGrid.AddColumnDefinition(new ColumnDefinition(GridLength.Star));
        return fieldGrid;
        }

    protected void AddFields(GuiBinding fieldBinding, IBindable data) {

        foreach (var entry in fieldBinding.BoundProperties) {
            IsEditable |= !entry.IsReadOnly;
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
                case GuiBoundPropertyIcon bound: {
                    var field = new GuigenFieldIcon(this, bound, data);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundPropertyList bound: {
                    var field = new GuigenFieldList(this, bound, data);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundPropertyDataActions bound: {
                    var field = new GuigenFieldDataActions(this, bound, data);
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

    public virtual void Reset() {
        }


    protected void ClearFields () {
        MauiFields?.Clear(); 
        FieldGrid?.Clear();
        }



    public virtual void SetFields(IBindable data) {
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


    protected void ClearFeedback() {
        foreach (var field in MauiFields) {
            field.ClearFeedback();
            }
        }

    public void Feedback(GuiResultInvalid feedback) {


        ClearFeedback();

        foreach (var message in feedback.Messages) {
            if (message.Index >= 0) {
                MauiFields[message.Index].SetFeedback(message);
                }

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
    public void AddButtons(Layout layout, GuiBinding binding) {

        foreach (var field in binding.BoundProperties) {
            switch (field) {
                case GuiBoundPropertyButton button1: {
                    if (MainWindow.Gui.Actions.TryGetValue(button1.Label, out var action)) {
                        var button = new GuigenDataActionButton(MainWindow, action, Data);
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

    public virtual void FieldChanged(GuigenField field) {
        }

    }

public class GuigenFieldSetEntry : GuigenFieldSet {

    public override View View => MainLayout;
    Layout MainLayout;

    public GuigenFieldSetEntry(
                GuigenBinding binding,
                IBindable data, 
                bool editMode = false) : base(binding, data.Binding, data) {

        IsEditMode = editMode;
        // Create the fields 
        AddFields(data.Binding, data);

        SetEditable(editMode);
        // Create the Context Menu for the Bottom
        CancelButton = new GuigenButton(Binding, null, "OK", OnCancel);

        ContextMenu = new FlexLayout() {
            Wrap = FlexWrap.Wrap
            };

        ContextMenu.Add(CancelButton.View);

        // Create the main layout
        MainLayout = new VerticalStackLayout {
            FieldGrid,
            ContextMenu
            };

        }

    private void OnCancel(object sender, EventArgs e) {
        Binding.CompleteAction();
        }

    }


public class GuigenFieldSetResult : GuigenFieldSet {

    public override View View => MainLayout;
    Layout MainLayout;

    Layout MessageBox { get; }

    public GuigenFieldSetResult(
            GuigenBinding binding,
            IResult result) : base(binding, result.Binding, result) {

        MessageBox = Binding.GetResultMessage(result); 


        // Create the fields 
        AddFields(result.Binding, result);

        SetEditable(false);
        // Create the Context Menu for the Bottom
        CancelButton = new GuigenButton(Binding, null, "OK", OnCancel);

        ContextMenu = new FlexLayout() {
            Wrap = FlexWrap.Wrap
            };

        ContextMenu.Add(CancelButton.View);

        // Create the main layout
        MainLayout = new VerticalStackLayout {
            MessageBox,
            FieldGrid,
            ContextMenu
            };
        }


    private void OnCancel(object sender, EventArgs e) {
        Binding.CompleteAction();
        }

    }





public class GuigenFieldSetSectionSingle : GuigenFieldSet {
    
    public override View View => MainLayout;
    Layout MainLayout;
    GuiSection? GuiSection;
    public GuigenFieldSetSectionSingle(
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
        UpdateButton = new GuigenButton(Binding, null, "Update", OnUpdate);
        EditButton = new GuigenButton(Binding, null, "Edit", OnEdit);
        
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




    public override void SetFields(IBindable data) {
        SetEditable(false);
        SetState();

        base.SetFields(data);
        }
    void SetState() {
        ContextMenu.Clear();

        if (!IsSection | IsEditMode) {
            ContextMenu.Add(CancelButton.View);
            }
        if (IsEditable) {
            ContextMenu.Add(IsEditMode ? UpdateButton.View: EditButton.View);
            }
        }

    private void OnCancel(object sender, EventArgs e) {
        // here we have to reinitialize the values to those of the data.

        SetEditable(false);
        SetState();
        }

    private void OnEdit(object sender, EventArgs e) {
        SetEditable(true);
        SetState();
        }

    private void OnUpdate(object sender, EventArgs e) {
        // pull data from the fields

        // preform the commit action

        SetEditable(false);
        SetState();

        if (GuiSection?.UpdateData != null) {
            GuiSection.UpdateData();
            }
        }



    }


public class GuigenFieldSetSectionMultiple : GuigenFieldSet, IBoundChooser {

    public override View View => MainLayout;
    Layout MainLayout;

    ///<summary>The chooser section (if present)</summary> 
    public GuigenFieldChooser Chooser { get; set; }

    IBindable SelectedItem {get; set; }

    public GuigenFieldSetSectionMultiple(
            GuigenBinding binding,
            GuiBindingMultiple fieldBinding = null,
            GuiSection guiSection = null,
            IBindable? data = null) : base(binding, fieldBinding, data) {

        ActionMenu = new FlexLayout() {
            Wrap = FlexWrap.Wrap
            };
        AddStaticButtons(guiSection?.Entries);

        Chooser = new GuigenFieldChooser(this, fieldBinding.Chooser, data);

        CancelButton = new GuigenButton(Binding, null, "Cancel", OnCancel);
        UpdateButton = new GuigenButton(Binding, null, "Update", OnUpdate);
        EditButton = new GuigenButton(Binding, null, "Edit", OnEdit);


        ContextMenu = new FlexLayout() {
            Wrap = FlexWrap.Wrap
            };
        ContextMenu.IsVisible = false;



        // Create the main layout
        MainLayout = new VerticalStackLayout {
            ActionMenu,
            Chooser.View,
            FieldGrid,
            ContextMenu
            };
        }



    // An item has been selected 
    public void OnItemSelected(IBindable item) {
        SelectedItem = item;
        IsEditMode = false;
        Data = item;

        ClearFields();
        if (item is null) {
            FieldGrid.IsVisible = false;
            ContextMenu.IsVisible = false;
            return;
            }

        AddFields(item.Binding, item);
        FieldGrid.IsVisible = true;

        ContextMenu.Clear();
        ContextMenu.Add(CancelButton.View);
        ContextMenu.Add(EditButton.View);
        AddButtons(ContextMenu, item.Binding);
        ContextMenu.IsVisible = true;
        }

    public void OnItemEdit(IBindable item) {
        //SetEditable(true);
        IsEditMode = true;
        SetEditable(true);
        //AddFields(item.Binding, item);
        FieldGrid.IsVisible = true;

        ContextMenu.Clear();
        ContextMenu.Add(CancelButton.View);
        ContextMenu.Add(UpdateButton.View);
        ContextMenu.IsVisible = true;
        }



    public override void SetFields(IBindable data) {
        FieldGrid.IsVisible = false;
        ContextMenu.IsVisible = false;
        Chooser.ClearSelection();
        }


    private void OnCancel(object sender, EventArgs e) {
        FieldGrid.IsVisible = false;
        ContextMenu.IsVisible = false;

        // here reset the backer data of SelectedItem to the original

        Chooser.ClearSelection();
        }

    private void OnEdit(object sender, EventArgs e) {
        
        
        OnItemEdit (SelectedItem);

        }

    private async void OnUpdate(object sender, EventArgs e) {

        GetFields(SelectedItem);
        await Chooser.SelectCollection.Update(SelectedItem as IBoundPresentation);
        OnItemSelected(SelectedItem);
        }

    }





/// <summary>
/// Present field set for an action dialog.
/// </summary>
public class GuigenFieldSetAction : GuigenFieldSet {

    GuiAction GuiAction { get; }



    public GuigenFieldSetAction(
            GuigenBinding binding,
            GuiAction guiAction,
                GuigenFieldSet fieldSet= null) : base(binding, guiAction.Binding, fieldSet: fieldSet) {
        GuiAction = guiAction;

        }


    }


public class GuigenFieldSetActionSingle : GuigenFieldSetAction {
    GuiAction GuiAction { get; }

    public override View View => MainLayout;
    Layout MainLayout;

    public GuigenFieldSetActionSingle(
                GuigenBinding binding,
                GuiAction guiAction,
                GuigenFieldSet fieldSet, 
                IBindable context = null) : base (binding, guiAction, fieldSet) {
        GuiAction = guiAction;
        // Create the backing data
        Data = guiAction.Factory();
        if (guiAction.setContext != null) {
            guiAction.setContext(Data, context);
            }
        IsEditMode = true;
        // Create the fields 
        AddFields(FieldBinding, Data);

        ContextMenu = new FlexLayout() {
            Wrap = FlexWrap.Wrap
            };
        CancelButton = new GuigenButton(Binding, null, "Cancel", OnCancel);
        ConfirmButton = new GuigenButton(Binding, null, "Confirm", OnConfirm);

        ContextMenu.Add(CancelButton.View);
        ContextMenu.Add(ConfirmButton.View);
        // Create the main layout
        MainLayout = new VerticalStackLayout {
            ActionMenu,
            FieldGrid,
            ContextMenu
            };


        }

    private void OnCancel(object sender, EventArgs e) {
        Binding.CancelAction();
        }

    private async void OnConfirm(object sender, EventArgs e) {
        ConfirmButton.SetState(ButtonState.Disabled);

        GetFields(Data);
        if (Data is IParameter parameter) {
            var verify = parameter.Validate(Binding.Gui);

            if (verify is GuiResultInvalid invalid) {
                Feedback (invalid);

                return;
                }
            }
        ClearFeedback();
        await Binding.PerformActionAsync(GuiAction, Data);
        }

    public override void FieldChanged(GuigenField field) {
        if (IsEditMode) {
            ConfirmButton.SetState(ButtonState.Enabled);
            }
        }
    }

public class GuigenFieldSetActionMultiple : GuigenFieldSetAction, IBoundChooser {
    GuiAction GuiAction { get; }
    public override View View => MainLayout;
    Layout MainLayout;

    public GuigenFieldChooser Chooser { get; set; }

    IBindable SelectedItem;

    public GuigenFieldSetActionMultiple(
            GuigenBinding binding,

            GuiAction guiAction,
                GuigenFieldSet fieldSet,
                IBindable context = null) : base(binding, guiAction, fieldSet) {
        GuiAction = guiAction;
        var fieldBinding = guiAction.Binding as GuiBindingMultiple;
        // Create the backing data
        var data = guiAction.Factory() as IParameter;
        Data = data;
        data.Initialize(Binding.Gui);

        Chooser = new GuigenFieldChooser(this, fieldBinding.Chooser, Data);

        ContextMenu = new FlexLayout() {
            Wrap = FlexWrap.Wrap,
            };

        CancelButton = new GuigenButton(Binding, null, "Cancel", OnCancel);

        ContextMenu.Add(CancelButton.View);


        // Create the main layout
        MainLayout = new VerticalStackLayout {
            Chooser.View,
            FieldGrid,
            ContextMenu
            };
        }

    // An item has been selected 
    public void OnItemSelected(IBindable item) {
        SelectedItem = item;
        ClearFields();
        AddFields(item.Binding, item);
        FieldGrid.IsVisible = true;

        // nope, here have to fill in the confirm box with the data specific actions.

        //ConfirmButton.SetState(ButtonState.Enabled);

        ContextMenu.Clear();
        ContextMenu.Add(CancelButton.View);
        AddButtons(ContextMenu, item.Binding);

        }

    private void OnCancel(object sender, EventArgs e) {
        Binding.CancelAction();
        }

    private async void OnConfirm(object sender, EventArgs e) {
        ConfirmButton.SetState(ButtonState.Disabled);
        await Binding.PerformActionAsync(GuiAction, SelectedItem);
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

