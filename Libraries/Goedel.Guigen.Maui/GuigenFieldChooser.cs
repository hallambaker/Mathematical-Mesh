using Goedel.Utilities;

using Microsoft.Maui.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;

using System.Runtime.CompilerServices;

using static System.Collections.Specialized.BitVector32;

namespace Goedel.Guigen.Maui;

/// <summary>
/// Instance class for chooser and associated add/update/delete interactions.
/// </summary>
public class GuigenFieldChooser : GuigenField {


    GuiBoundPropertyChooser TypedBinding => PropertyBinding as GuiBoundPropertyChooser;

    ///<inheritdoc/>
    public bool IsEditable => IsEditMode & (TypedBinding.Set is not null);

    public Entry ValueField;

    public View View => Layout;
    public Layout Layout { get; }

    public ListView ListView { get; } = new ();
    RefreshView RefreshView { get; } = new();

    public Button AddButton;
    public Entry FilterInput;
    public Button FilterButton;
    public ISelectCollection SelectCollection;

    public StackBase CommandButtons { get; }
    //public HorizontalStackLayout MainLayout;

    public GuiBinding SelectionBinding { get; set; } = null;
    public List<GridLength> Widths { get; } = new();
    public Grid GridHeadings { get; } = new();


    public VerticalStackLayout EntryForm { get; } = new();
    public HorizontalStackLayout ButtonBar = new();

    GuigenFieldSet SelectionDialog { get; set; }
    GuigenFieldSetMultiple FieldSetMultiple => FieldSet as GuigenFieldSetMultiple;


    public GuigenFieldChooser(
                GuigenFieldSet fieldSet,
                GuiBoundPropertyChooser binding,
                IBindable? data = null) : base (fieldSet, binding) {


        //CommandButtons = new HorizontalStackLayout() {
        //    FilterInput,
        //    FilterButton
        //    };

        //FilterInput = new Entry() {
        //    };
        //FilterButton = new Button() {
        //    Text = "Filter"
        //    };
        //FilterButton.Clicked += OnClickFilter;

        //CommandButtons.Add(FilterInput);
        //CommandButtons.Add(FilterButton);

        ListView.ItemTemplate = new BindableTemplate(this);
        ListView.ItemSelected += OnClickSelect;
        ListView.VerticalScrollBarVisibility = ScrollBarVisibility.Always;
        ListView.HeightRequest = 200;

        RefreshView.Content = ListView;

        Layout = new VerticalStackLayout() { CommandButtons, ListView };

        if (data != null) {
            SetField(data);
            }

        //var Layout = new VerticalStackLayout() { CommandButtons, MainLayout, EntryForm};


        //RestoreView();
        }

    ///<inheritdoc/>
    public override void SetEditable() {

        }


    //public void RestoreView() {
    //    CommandButtons.IsVisible = true;
    //    MainLayout.Clear();
    //    MainLayout.Add(RefreshView);
    //    }

    public override void SetField(IBindable data) {
        if (data is IHeadedSelection headed) {
            if (SelectionBinding is null) {
                MakeHeadings(headed.SelectionBinding);
                }
            }

        SelectCollection = TypedBinding.Get(data);

        if (SelectCollection == null) {
            return;

            //SelectCollection = new SelectList();
            //TypedBinding.Set(data, SelectCollection);
            }

        ListView.ItemsSource = SelectCollection.Entries;
        }

    public void MakeHeadings(GuiBinding selectionBinding) {

        SelectionBinding = selectionBinding;
        var fixedWidth = 0;
        var relativeWidth = 0;
        foreach (var item in SelectionBinding.BoundProperties) {
            switch (item) {
                case GuiBoundPropertyString propertyString: {
                    relativeWidth++;
                    break;
                    }
                case GuiBoundPropertyIcon icon: {
                    fixedWidth += MainWindow.Binding.IconWidth;
                    break;
                    }
                }
            }

        var colWidth = (MainWindow.GetDetailWidth() - fixedWidth) / relativeWidth;

        var col = 0;
        foreach (var item in SelectionBinding.BoundProperties) {
            switch (item) {
                case GuiBoundPropertyString propertyString : {
                    var width = new GridLength(colWidth);
                    //width = GridLength.Auto;
                    Widths.Add (width);
                    var label = new Label() {
                        Text = propertyString.Label,

                        };
                    GridHeadings.AddColumnDefinition(new ColumnDefinition(width));
                    GridHeadings.Add(label, col++);

                    break;
                    }
                case GuiBoundPropertyIcon icon : {
                    var width = MainWindow.Binding.IconWidth;
                    var image = new Image() {
                        Source = "messages",
                        WidthRequest = width
                        };
                    GridHeadings.AddColumnDefinition(new ColumnDefinition(width));
                    GridHeadings.Add(image, col++);
                    break;
                    }
                }

            }
        ListView.Header = GridHeadings;
        }



    public override void GetField(IBindable data) {
        }


    public void OnClickFilter(object sender, EventArgs e) { 
        }

    public void OnClickSelect(object sender, EventArgs e) {

        // Here we want to create a view dialog below the list box.
        // Buttons are Update / Delete
        // need a bound presentation of the 

        var selectEvent = e as SelectedItemChangedEventArgs;


        var bindable = selectEvent.SelectedItem as IBindable;


        FieldSetMultiple.OnItemSelected(bindable);

        //EntryForm.Clear();
        //SelectionDialog = new GuigenFieldSet(Binding, bindable.Binding);
        ////ButtonBar.Clear();
        ////SelectionDialog.AddButtons(ButtonBar);
        //SelectionDialog.SetFields(bindable);
        //FieldSet.ButtonBox.Clear();
        //SelectionDialog.AddButtons(FieldSet.ButtonBox);



        }





    }


