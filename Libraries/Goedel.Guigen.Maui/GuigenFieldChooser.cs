using Goedel.Utilities;

using Microsoft.Maui.Controls;

using System.Runtime.CompilerServices;

namespace Goedel.Guigen.Maui;


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
    List<BoundPresentation> BoundPresentations = new();

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
                    BoundPresentations.Add(presentation);
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

    BoundPresentation GetPresentation(IBindable binding) {
        foreach (var presentation in BoundPresentations) {
            var dialog = presentation.Dialog;

            if (dialog?.IsBoundType(binding)==true) {
                return presentation;
                }

            }

        return null;
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
        // need a bound presentation of the 

        var selectEvent = e as SelectedItemChangedEventArgs;
        var selectedItem = selectEvent.SelectedItem as IBindable;
        var presentation = GetPresentation(selectedItem);

        presentation.SetDialogMode(DialogMode.Update);
        SetView(presentation.Layout);
        }

    public void OnClickDelete(object sender, EventArgs e) {
        }

    public void OnClickUpdate(object sender, EventArgs e) {
        }
    }


