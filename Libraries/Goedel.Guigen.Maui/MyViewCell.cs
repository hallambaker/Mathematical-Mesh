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

    Grid Grid { get; } = new Grid() {
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
        HeightRequest = 60,
        WidthRequest = 60};
    Label MainLabel = new Label();
    Label SecondaryLabel = new Label();

    public MyViewCell(GuigenFieldChooser chooser) { 
        Chooser = chooser;
        BindingContextChanged += OnBindingChanged;
        PropertyChanged += OnPropertyChanged;
        Appearing += OnAppearing;
        Disappearing += OnDisappearing;
        View = Grid;

        Grid.Add(EntryImage);
        Grid.SetColumnSpan((IView)EntryImage, 2);
        Grid.Add(MainLabel);
        Grid.SetColumn((IView)MainLabel, 1);
        Grid.Add(SecondaryLabel);
        Grid.SetColumn((IView)SecondaryLabel, 1);
        Grid.SetRow((IView)SecondaryLabel, 1);
        //FieldBinding = new FieldBinding(this);
        }


    public void OnAppearing(object? sender, EventArgs e) {
        Visible = true;
        }

    public void OnDisappearing(object? sender, EventArgs e) {
        Visible = false;
        }

    public void OnBindingChanged(object? sender, EventArgs e) {

        if (BindingContext is ISelectSummary summary) {
            EntryImage.Source = summary.IconValue;
            MainLabel.Text = summary.LabelValue;
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


