namespace Goedel.Guigen.Maui;

/// <summary>
/// <see cref="ViewCell"/> bound to the cell data specified by <see cref="BindingContext"/> described
/// by the binding data described by <see cref="Chooser"/>.
/// </summary>
public class MyViewCell : ViewCell {

    public bool Visible { get; set; }
    public GuigenFieldChooser Chooser { get; }
    ISelectCollection SelectCollection => Chooser.SelectCollection;

    public IBindable Data => BindingContext as IBindable;

    FieldBinding FieldBinding { get; set; }

    SummaryView? SummaryView;


    SelectGrid SelectGrid {get; set; }
    //ArrayGrid ArrayGrid { get; set; }
    public Grid GridCell { get; } = new();

    public MyViewCell(GuigenFieldChooser chooser) { 
        Chooser = chooser;
        BindingContextChanged += OnBindingChanged;
        //PropertyChanged += OnPropertyChanged;
        Appearing += OnAppearing;
        Disappearing += OnDisappearing;
        Tapped += OnTapped;
        View = null;


        //FieldBinding = new FieldBinding(this);
        }


    public void OnTapped(object? sender, EventArgs e) {

        }


    public void OnAppearing(object? sender, EventArgs e) {
        Visible = true;
        }

    public void OnDisappearing(object? sender, EventArgs e) {
        Visible = false;
        }

    public void OnBindingChanged(object? sender, EventArgs e) {

        if (BindingContext is ISelectSummary summary) {
            SelectGrid ??= new();
            SelectGrid.Set(summary);
            View = SelectGrid.Grid;
            return;
            }

        GridCell.ColumnDefinitions = Chooser.GridHeadings.ColumnDefinitions;
        GridCell.Clear();
        View = GridCell;

        if (!Chooser.SelectionBinding.IsType(BindingContext)) {
            return;
            }

        var col = 0;
        foreach (var item in Chooser.SelectionBinding.BoundProperties) {
            switch (item) {
                case GuiBoundPropertyString propertyString: {

                    var value = propertyString.Get(BindingContext);

                    var label = new Label() {
                        Text = value
                        };

                    GridCell.Add(label, col++);

                    break;
                    }

                }

            }




        }


    public void OnPropertyChanged(object? sender, EventArgs e) {
        //if (BindingContext != null) {
        //    FieldBinding.Bind(BindingContext);
        //    }
        //View = new Label() { Text = "Hello There" };
        var changedEvent = e as System.ComponentModel.PropertyChangedEventArgs;

        if (changedEvent.PropertyName == "BindingContext") {
            }
        }

    }


class SelectGrid {

    public Grid Grid { get; } = new Grid() {
        RowDefinitions = new RowDefinitionCollection(
                new RowDefinition() {
                    Height = GridLength.Auto
                    },
                new RowDefinition() {
                    Height = GridLength.Auto
                    }),
        ColumnDefinitions = new ColumnDefinitionCollection(
                new ColumnDefinition() {
                    Width = GridLength.Auto
                    },
                new ColumnDefinition() {
                    Width = GridLength.Auto
                    })
        };
    Image EntryImage = new Image() {
        HeightRequest = 30,
        WidthRequest = 30
        };
    Label MainLabel = new Label();
    Label SecondaryLabel = new Label();

    public SelectGrid() {
        Grid.Add(EntryImage);
        Grid.SetRowSpan((IView)EntryImage, 2);
        Grid.Add(MainLabel);
        Grid.SetColumn((IView)MainLabel, 1);
        Grid.Add(SecondaryLabel);
        Grid.SetColumn((IView)SecondaryLabel, 1);
        Grid.SetRow((IView)SecondaryLabel, 1);
        }




    public void Set(ISelectSummary summary) {
        EntryImage.Source = summary.IconValue;
        MainLabel.Text = summary.LabelValue;
        SecondaryLabel.Text = summary.SecondaryValue;
        }

    }

class ArrayGrid {
    List<GridLength> Widths { get; }
    public Grid Grid { get; set; } = new();

    

    public ArrayGrid(List<GridLength> widths) {
        Widths = widths;
        }


    public void Set(IBindable data) {
        // check if is of same type, if so, reuse
        Grid.Clear();

        var binding = data.Binding;

        var col = 0;
        foreach (var property in binding.BoundProperties) {
            }

        }

    public void Resize() {
        }


    }



//class Person {
//    public Person(string name, DateTime birthday) {
//        this.Name = name;
//        this.Birthday = birthday;
//        this.FavoriteColor = Color.FromArgb("00f00f");
//        }

//    public string Name { private set; get; }

//    public DateTime Birthday { private set; get; }

//    public Color FavoriteColor { private set; get; }
//    };


