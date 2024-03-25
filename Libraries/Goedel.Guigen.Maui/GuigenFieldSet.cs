using Microsoft.UI.Xaml.Documents;

using System.Security.Cryptography;

using Windows.ApplicationModel.VoiceCommands;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Guigen.Maui;





public class GuigenFieldSet : IWidget {


    ///<summary>The bound UI</summary> 
    public GuigenBinding Binding { get; }

    ///<summary>The main window.</summary> 
    public IMainWindow MainWindow => Binding.MainWindow;

    public Grid View { get; private set; }

    View? summary = null;

    public List<GuigenField> MauiFields { get; } = new();

    //int[] FieldMap;

    int GridRow { get; set; } = 0;
    int GridColumn { get; set; } = 0;

    public IBindable Data { get; set; }
    public Layout ButtonBox { get; private set;  }

    public bool IsChooser { get; set; } = false;
    GuiBinding FieldBinding { get; }


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
     *      Fields
     *      ContextMenu
     */

    ///<summary>Container for the action section</summary> 
    public Layout ActionMenu            { get; set; }

    ///<summary>Container for the fields section</summary> 
    public Layout Fields                { get; set; }

    ///<summary>Container for the confirm/cancel/context section</summary> 
    public Layout ContextMenu          { get; set; }


    public GuigenButton ConfirmButton       { get; set; }

    public GuigenButton CancelButton        { get; set; }

    public GuigenButton EditButton          { get; set; }

    public GuigenButton UpdateButton        { get; set; }




    public GuigenFieldSet(
                GuigenBinding binding,
                Layout? stack,
                GuiBinding fieldBinding = null,
                IBindable? data = null) {
        Binding = binding;
        FieldBinding = fieldBinding;

        View = new Grid();
        View.AddColumnDefinition(new ColumnDefinition(GridLength.Auto));
        View.AddColumnDefinition(new ColumnDefinition(GridLength.Star));
        stack?.Add(View);

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
                case GuiBoundPropertyQRScan bound: {
                    var field = new GuigenFieldQr(this, bound, data);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundPropertyIcon bound: {
                    if (fieldBinding.IsReadOnly) {
                        }
                    else {
                        var field = new GuigenFieldIcon(this, bound, data);
                        MauiFields.Add(field);
                        break;
                        }
                    break;
                    }
                case GuiBoundPropertyChooser bound: {
                    var field = new GuigenFieldChooser(this, bound, data);
                    MauiFields.Add(field);
                    ButtonBox = new HorizontalStackLayout();
                    IsChooser = true;
                    break;
                    }
                case GuiBoundPropertyList bound: {
                    var field = new GuigenFieldList(this, bound, data);
                    MauiFields.Add(field);
                    break;
                    }
                default: {
                    break;
                    }

                }
            IsReadOnly &= entry.IsReadOnly;
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


    public int AddField(IView label, IView child, IView? feedback=null) {

        View.Add(label, 0, GridRow);
        if (child != null) {
            View.Add(child, 1, GridRow);
            }
        if (feedback != null) {
            View.Add(feedback, 2, GridRow);
            }
        return GridRow++;
        }

    public void ReplaceField(IView current, IView replacement, int gridRow) {
        View.Remove(current);
        View.Add(replacement, 1, gridRow);
        }


    public void AddField(IView child) {
        View.Add(child, 0, GridRow++);
        }
    

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

/// <summary>
/// Present field set for an action dialog.
/// </summary>
public class GuigenFieldSetAction : GuigenFieldSet {

    public GuigenFieldSetAction(
            GuigenBinding binding,
            Layout? stack,
            GuiBindingSingle fieldBinding = null,
            IBindable? data = null) : base(binding, stack, fieldBinding, data) {
        SetState();

        CancelButton = new GuigenButton(Binding, null, "Cancel", OnCancel);
        CancelButton = new GuigenButton(Binding, null, "Confirm", OnCancel);
        }

    private void SetState() {
        ContextMenu.Clear();

        ContextMenu.Add(CancelButton.View);
        ContextMenu.Add(ConfirmButton.View);
        }

    private void OnCancel(object sender, EventArgs e) {
        Binding.CancelActionDialog();
        }

    private void OnConfirm(object sender, EventArgs e) {
        Binding.AttemptActionCallback();
        }

    }

public class GuigenFieldSetSingle : GuigenFieldSet {

    public GuigenFieldSetSingle(
            GuigenBinding binding,
            Layout? stack,
            GuiBindingSingle fieldBinding = null,
            IBindable? data = null) : base(binding, stack, fieldBinding, data) {
        SetState();
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

    ///<summary>The chooser section (if present)</summary> 
    public GuigenFieldChooser Chooser { get; set; }

    public GuigenFieldSetMultiple(
            GuigenBinding binding,
            Layout? stack,
            GuiBindingMultiple fieldBinding = null,
            IBindable? data = null) : base(binding, stack, fieldBinding, data) {
        SetState();
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



public class GuigenFieldSetQr : GuigenFieldSet {

    public GuigenFieldSetQr(
            GuigenBinding binding,
            Layout? stack,
            GuiBindingQr fieldBinding = null,
            IBindable? data = null) : base(binding, stack, fieldBinding, data) {
        SetState();
        }

    void SetState() {

        }

    }

