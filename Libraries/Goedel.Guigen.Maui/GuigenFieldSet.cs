using Microsoft.UI.Xaml.Documents;

using System.Security.Cryptography;

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


    public bool IsReadOnly { get; set; } = true;

    public bool IsEditable { get; set; } = false;


    public GuigenFieldSet(
                GuigenBinding uiBinding, 
                List<IGuiEntry> fields, 
                Layout? stack, 
                GuiBinding fieldBinding = null, 
                bool isEntry = true) {
        Binding = uiBinding;
        FieldBinding = fieldBinding;

        View = new Grid();
        View.AddColumnDefinition(new ColumnDefinition(GridLength.Auto));
        View.AddColumnDefinition(new ColumnDefinition(GridLength.Star));
        stack?.Add(View);

        foreach (var entry in fieldBinding.BoundProperties) {
            switch (entry) {
                case GuiBoundPropertyBoolean bound: {
                    var field = new GuigenFieldBoolean(MainWindow, this, bound);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundPropertyString bound: {
                    var field = new GuigenFieldString(MainWindow, this, bound);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundTextArea bound: {
                    var field = new GuigenFieldTextArea(MainWindow, this, bound);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundPropertyColor bound: {
                    var field = new GuigenFieldColor(MainWindow, this, bound);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundPropertySize bound: {
                    var field = new GuigenFieldSize(MainWindow, this, bound);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundPropertyDecimal bound: {
                    var field = new GuigenFieldDecimal(MainWindow, this, bound);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundPropertyInteger bound: {
                    var field = new GuigenFieldInteger(MainWindow, this, bound);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundPropertyQRScan bound: {
                    var field = new GuigenFieldQr(MainWindow, this, bound);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundPropertyIcon bound: {
                    if (isEntry) {
                        }
                    else {
                        var field = new GuigenFieldIcon(MainWindow, this, bound);
                        MauiFields.Add(field);
                        break;
                        }
                    break;
                    }
                case GuiBoundPropertyChooser bound: {
                    var field = new GuigenFieldChooser(MainWindow, this, bound);
                    MauiFields.Add(field);
                    ButtonBox = new HorizontalStackLayout();
                    IsChooser = true;
                    break;
                    }
                case GuiBoundPropertyList bound: {
                    var field = new GuigenFieldList(MainWindow, this, bound);
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
        IsEditable = isEditable;
        foreach (var field in MauiFields) {
            field.SetEditable(isEditable);
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


    public void AddField(IView label, IView child, IView? feedback=null) {


        View.Add(label, 0, GridRow);
        View.Add(child, 1, GridRow++);
        if (feedback != null) {
            View.Add(feedback, 2, GridRow++);
            }
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



