using Goedel.Utilities;

using Microsoft.Maui.Controls;

using System.Runtime.CompilerServices;

namespace Goedel.Guigen.Maui;


/// <summary>
/// Backer class for a bound presentation, the object that the Add / Accept buttons interact with.
/// </summary>
/// <param name="Chooser"></param>
/// <param name="Dialog"></param>
public record BoundPresentation{

    GuigenFieldChooser Chooser;
    GuiDialog Dialog;
    public StackBase Layout { get; }
    //    => layout ?? MakeLayout().CacheValue(out layout);
    //StackBase layout;
    GuigenFieldSet fieldSet;

    IBindable data;


    public BoundPresentation(
            GuigenFieldChooser chooser,
            GuiDialog dialog) {
        Chooser = chooser;
        Dialog = dialog;
        Layout = MakeLayout(); 
        }


    StackBase MakeLayout() {
        var stack = new VerticalStackLayout();
        fieldSet = new GuigenFieldSet(Chooser.MainWindow, Dialog.Entries, stack);

        var accept = new Button() {
            Text = "Accept"
            };
        accept.Clicked += OnClickAccept;

        var cancel = new Button() {
            Text = "Cancel"
            };
        cancel.Clicked += OnClickCancel;
        var buttons = new HorizontalStackLayout() { accept, cancel};
        stack.Add(buttons);

        return stack;
        }

    public void Initialize() {
        data = Dialog.Factory();
        fieldSet.SetFields(data);
        }


    public void OnClickAccept(object sender, EventArgs e) {
        Chooser.RestoreView();

        // need to validate the input fields here and respond accordingly

        fieldSet.GetFields(data);
        Chooser.AddItem(data);

        data = null; // prevent reuse of this item as it has been incorporated in the list
        }

    public void OnClickCancel(object sender, EventArgs e) {
        Chooser.RestoreView();
        }


    }


/// <summary>
/// Instance class for chooser and associated add/update/delete interactions.
/// </summary>
public class GuigenFieldChooser : GuigenField {

    public IMainWindow MainWindow { get; }
    public IView View => ListView;
    public GuiChooser Chooser => Field as GuiChooser;

    public Entry ValueField;
    public ListView ListView;



    public Button AddButton;
    public Entry FilterInput;
    public Button FilterButton;
    public ISelectCollection SelectCollection;
    GuiBoundPropertyChooser Binding;

    public StackBase CommandButtons { get; }
    public HorizontalStackLayout MainLayout;

    public GuigenFieldChooser(IMainWindow mainWindow, GuiChooser chooser, Layout stack) : base(chooser) {

        MainWindow = mainWindow;

        CommandButtons = new HorizontalStackLayout() {
            FilterInput,
            FilterButton
            };

        foreach (var entry in Chooser.Entries) {
            switch (entry) {
                case GuiViewDialog viewDialog: {
                    var dialog = viewDialog.Dialog;
                    var presentation = new BoundPresentation(this, dialog);


                    var text = "Add " + (mainWindow.Binding.Resolve(dialog.Id) ?? dialog.Prompt);

                    var addButton = new DataButton(presentation) {
                        Text = text
                        };
                    addButton.Clicked += OnClickAdd;

                    CommandButtons.Add(addButton);
                    break;
                    }
                }
            }

        FilterInput = new Entry() {
            };
        FilterButton = new Button() {
            Text = "Filter"
            };
        FilterButton.Clicked += OnClickFilter;


        CommandButtons.Add(FilterInput);
        CommandButtons.Add(FilterButton);


        ListView = new ListView {
            ItemTemplate = new BindableTemplate(this)
            };
        ListView.ItemSelected += OnClickSelect;
        stack.Add(CommandButtons);

        MainLayout = new();
        stack.Add(MainLayout);

        RestoreView();

        }

    public void RestoreView() {
        CommandButtons.IsVisible = true;
        MainLayout.Clear();
        MainLayout.Add(ListView);
        }

    public void SetView(View view) {
        CommandButtons.IsVisible = false;
        MainLayout.Clear();
        MainLayout.Add(view);
        }

    public void AddItem(IBindable data) {

        ListView.BeginRefresh();
        SelectCollection.Add(data);
        ListView.EndRefresh();

        }


    public override void SetField(IBindable data) {
        Binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyChooser;
        SelectCollection = Binding.Get(data);

        if (SelectCollection == null) {
            SelectCollection = new SelectList();
            Binding.Set(data, SelectCollection);
            }

        ListView.ItemsSource = SelectCollection.Entries;
        }




    public override void GetField(IBindable data) {
        }

    public void OnClickAdd(object sender, EventArgs e) {
        var addButton = sender as DataButton;
        var presentation = addButton.Data as BoundPresentation;
        presentation.Initialize();


        SetView(presentation.Layout);
        }


    public void OnClickFilter(object sender, EventArgs e) { 
        }

    public void OnClickSelect(object sender, EventArgs e) {

        // Here we want to create a view dialog below the list box.
        // Buttons are Update / Delete


        }

    public void OnClickDelete(object sender, EventArgs e) {
        }

    public void OnClickUpdate(object sender, EventArgs e) {
        }
    }


