using System;

namespace Goedel.Guigen.Maui;

public enum DialogMode {
    Display,
    Add,
    Update

    }



/// <summary>
/// Backer class for a bound presentation, the object that the Add / Accept buttons interact with.
/// </summary>
/// <param name="Chooser"></param>
/// <param name="Dialog"></param>
public record BoundPresentation{



    GuigenFieldChooser Chooser;
    public GuiDialog Dialog;
    public View Layout { get; set;  }
    StackBase StackBase { get; }
    //    => layout ?? MakeLayout().CacheValue(out layout);
    //StackBase layout;
    GuigenFieldSet fieldSet;

    public IBoundPresentation Data { get => data;
        set {
            data = value;
            SetFields();
            }
        }
    IBoundPresentation data;
    public DialogMode DialogMode { 
        get => dialogMode;
        set => dialogMode = SetDialogMode(value); }
    DialogMode dialogMode;

    Button Accept;
    Button Update;
    Button Delete;
    Button Cancel;

    public BoundPresentation(
            GuigenFieldChooser chooser,
            GuiDialog dialog) {
        Chooser = chooser;
        Dialog = dialog;
        StackBase = MakeLayout();
        Layout = new ScrollView() {
            Content = StackBase,
            VerticalScrollBarVisibility = ScrollBarVisibility.Always
            };
        }


    StackBase MakeLayout(DialogMode dialogMode = DialogMode.Add) {
        var stack = new VerticalStackLayout();
        fieldSet = new GuigenFieldSet(Chooser.MainWindow, Dialog.Entries, stack, Dialog.Binding);

        Accept = new Button() {
            Text = "Add"
            };
        Accept.Clicked += OnClickAdd;

        Update = new Button() {
            Text = "Update"
            };
        Update.Clicked += OnClickUpdate;

        Delete = new Button() {
            Text = "Delete"
            };
        Delete.Clicked += OnClickDelete;

        Cancel = new Button() {
            Text = "Cancel"
            };
        Cancel.Clicked += OnClickCancel;
        var buttons = new HorizontalStackLayout() { Accept, Update, Delete, Cancel };
        stack.Add(buttons);


        DialogMode = dialogMode;
        return stack;
        }

    public void Initialize() {
        Data = Dialog.Factory() as IBoundPresentation;
        fieldSet.SetFields(Data);
        }


    void SetFields () => fieldSet.SetFields(Data);


    public void OnClickAdd(object sender, EventArgs e) {
        Chooser.RestoreView();

        // need to validate the input fields here and respond accordingly

        fieldSet.GetFields(Data);
        Chooser.AddItem(Data);

        Data = null; // prevent reuse of this item as it has been incorporated in the list
        }

    public void OnClickUpdate(object sender, EventArgs e) {
        fieldSet.GetFields(Data);
        Chooser.UpdateItem(Data);
        }
    public void OnClickDelete(object sender, EventArgs e) {
        Chooser.DeleteItem(Data);
        }

    public void OnClickCancel(object sender, EventArgs e) {
        Chooser.RestoreView();
        }

    public DialogMode SetDialogMode(DialogMode dialogMode) {
        switch (dialogMode) {
            case DialogMode.Display: {
                Accept.IsVisible = false;
                Update.IsVisible = false;
                Delete.IsVisible = false;
                break;
                }
            case DialogMode.Add: {
                Accept.IsVisible = true;
                Update.IsVisible = false;
                Delete.IsVisible = false;
                break;
                }
            case DialogMode.Update: {
                Accept.IsVisible = false;
                Update.IsVisible = true;
                Delete.IsVisible = true;
                break;
                }
            }


        return dialogMode;
        }

    }


