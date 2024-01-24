using Goedel.Utilities;

using Microsoft.Maui.Controls;
using System.Runtime.CompilerServices;

using static System.Collections.Specialized.BitVector32;

namespace Goedel.Guigen.Maui;

/// <summary>
/// Instance class for chooser and associated add/update/delete interactions.
/// </summary>
public class GuigenFieldChooser : GuigenField {

    public IMainWindow MainWindow { get; }
    public IView View => ListView;
    public GuiChooser Chooser => Field as GuiChooser;

    public Entry ValueField;
    public ListView ListView { get; } = new ();
    RefreshView RefreshView { get; } = new();
    ScrollView ScrollView { get; } = new();

    public Button AddButton;
    public Entry FilterInput;
    public Button FilterButton;
    public ISelectCollection SelectCollection;
    GuiBoundPropertyChooser Binding;

    public StackBase CommandButtons { get; }
    public HorizontalStackLayout MainLayout;
    List<BoundPresentation> BoundPresentations = new();

    public GuiBinding SelectionBinding { get; set; } = null;
    public List<GridLength> Widths { get; } = new();
    public Grid GridHeadings { get; } = new();


    public VerticalStackLayout EntryForm { get; } = new();
    public HorizontalStackLayout ButtonBar = new();
    public GuigenFieldChooser(IMainWindow mainWindow, GuiChooser chooser, GuigenFieldSet fieldsSet) : base(chooser) {

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

        ListView.ItemTemplate = new BindableTemplate(this);
        ListView.ItemSelected += OnClickSelect;
        ListView.VerticalScrollBarVisibility = ScrollBarVisibility.Always;
        ListView.HeightRequest = 200;
        ListView.WidthRequest = 500;

        //ScrollView.Content = ListView;
        RefreshView.Content = ListView;

        //stack.Add(CommandButtons);

        MainLayout = new();


        //stack.Add(MainLayout);

        var Layout = new VerticalStackLayout() { CommandButtons, MainLayout, EntryForm, ButtonBar };
        fieldsSet.AddField(Layout);

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
        MainLayout.Add(RefreshView);
        }

    public void SetView(View view) {
        CommandButtons.IsVisible = false;
        MainLayout.Clear();
        MainLayout.Add(view);
        }

    public void AddItem(IBoundPresentation data) {

        ListView.BeginRefresh();
        SelectCollection.Add(data);
        ListView.EndRefresh();

        }

    public void DeleteItem(IBoundPresentation data) {
        SelectCollection.Remove(data);
        }

    public void UpdateItem(IBoundPresentation data) {
        SelectCollection.Update(data);
        }

    public override void SetField(IBindable data) {
        if (data is IHeadedSelection headed) {
            if (SelectionBinding is null) {
                MakeHeadings(headed.SelectionBinding);
                }
            }

        Binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyChooser;
        SelectCollection = Binding.Get(data);

        if (SelectCollection == null) {
            SelectCollection = new SelectList();
            Binding.Set(data, SelectCollection);
            }

        ListView.ItemsSource = SelectCollection.Entries;
        }

    public void MakeHeadings(GuiBinding selectionBinding) {
        SelectionBinding = selectionBinding;
        var col = 0;
        foreach (var item in SelectionBinding.BoundProperties) {
            switch (item) {
                case GuiBoundPropertyString propertyString : {
                    var width = new GridLength(100);
                    Widths.Add (width);
                    var label = new Label() {
                        Text = propertyString.Label,

                        };
                    GridHeadings.AddColumnDefinition(new ColumnDefinition(width));
                    GridHeadings.Add(label, col++);

                    break;
                    }
                
                }

            }
        ListView.Header = GridHeadings;
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


        var dialog = selectEvent.SelectedItem as IDialog;



        var bindable = selectEvent.SelectedItem as IBindable;
        var gui = MainWindow.Binding.Gui;
        var entries = dialog.Dialog(gui).Entries;

        var fieldSet = new GuigenFieldSet(MainWindow, entries, EntryForm);
        fieldSet.SetFields(bindable);
        ButtonBar.Clear();
        fieldSet.AddButtons(ButtonBar);



        // now add in all the buttons from entries.


        }





    }


