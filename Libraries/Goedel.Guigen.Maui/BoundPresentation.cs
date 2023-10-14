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
    public StackBase Layout { get; }
    //    => layout ?? MakeLayout().CacheValue(out layout);
    //StackBase layout;
    GuigenFieldSet fieldSet;

    IBindable data;

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
        Layout = MakeLayout(); 
        }


    StackBase MakeLayout(DialogMode dialogMode = DialogMode.Add) {
        var stack = new VerticalStackLayout();
        fieldSet = new GuigenFieldSet(Chooser.MainWindow, Dialog.Entries, stack);

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
        data = Dialog.Factory();
        fieldSet.SetFields(data);
        }


    public void OnClickAdd(object sender, EventArgs e) {
        Chooser.RestoreView();

        // need to validate the input fields here and respond accordingly

        fieldSet.GetFields(data);
        Chooser.AddItem(data);

        data = null; // prevent reuse of this item as it has been incorporated in the list
        }

    public void OnClickUpdate(object sender, EventArgs e) {
        }
    public void OnClickDelete(object sender, EventArgs e) {
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


