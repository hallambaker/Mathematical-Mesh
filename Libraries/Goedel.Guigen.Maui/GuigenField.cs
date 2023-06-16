using System;

using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;
namespace Goedel.Guigen.Maui;

public abstract class GuigenField{
    public IBindable Value { get; set; }

    public GuiField Field { get; }
    public int Index => Field.Index;


    public GuigenField(GuiField field) {
        Field = field;
        }

    public abstract void SetField(IBindable data);

    public abstract void GetField(IBindable data);

    }

public class FieldSet {
    public Layout View { get; private set; }


    public List<GuigenField> Fields { get; } = new();


    public FieldSet(IEnumerable<IGuiEntry> fields, Layout stack) {
        stack ??= new VerticalStackLayout();
        View = stack;

        //if (prompt != null) {
        //    var label = new Label() {
        //        Text = prompt
        //        };

        //    stack.Add(label);
        //    }

        foreach (var entry in fields) {
            switch (entry) {
                case GuiText text: {
                    var field = new GuigenFieldString(text);
                    Fields.Add(field);
                    stack.Add(field.View);
                    break;
                    }
                case GuiChooser chooser: {
                    var field = new GuigenFieldChooserx(chooser);
                    //var fieldLabel = new Label() {
                    //    Text = "splonk"
                    //    };
                    //stack.Add(fieldLabel);


                    Fields.Add(field);
                    stack.Add(field.ListView);


                    var view = new NewContent1();
                    stack.Add(view);

                    var demo = new ListViewDemoPage1();
                    stack.Add(demo.ListView);

                    //stack.Add(view);
                    break;
                    }
                }
            }




        }

    public void SetFields(IBindable data) {
        foreach (var field in Fields) {
            field.SetField(data);
            }
        }

    public void GetFields(IBindable data) {
        foreach (var field in Fields) {
            field.GetField(data);
            }
        }


    }





public class GuigenFieldString : GuigenField {

    public IView View { get; private set; }

    public Entry ValueField;

    public GuigenFieldString(GuiText text) : base (text){
        var view = new HorizontalStackLayout();
        var fieldLabel = new Label() {
            Text = text.Prompt
            };
        ValueField = new Entry() {
            };


        view.Add(fieldLabel);
        view.Add(ValueField);
        View = view;
        }
    public override void SetField(IBindable data) {
        var binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyString;
        ValueField.Text = binding.Get(data);

        }

    public override void GetField(IBindable data) {
        var binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyString;
        binding.Set(data, ValueField.Text);
        }



    }




public class GuigenFieldChooserx : GuigenField {
    public IView View => ListView;
    public Entry ValueField;
    ISelectCollection SelectCollection;

    public ListView ListView;

    public GuigenFieldChooserx(GuiChooser chooser) : base(chooser) {
        List<Person> people = new List<Person> {
                new Person("Abigail", new DateTime(1975, 1, 15)),
                new Person("Bob", new DateTime(1976, 2, 20)),
                // ...etc.,...
                new Person("Yvonne", new DateTime(1987, 1, 10)),
                new Person("Zachary", new DateTime(1988, 2, 5))
            };


        var binding = 


        ListView = new ListView {
            ItemsSource = people,
            ItemTemplate = new DataTemplate(() => {
                // Create views with bindings for displaying each property.
                Label nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, "Name");

                Label birthdayLabel = new Label();
                birthdayLabel.SetBinding(Label.TextProperty,
                    new Binding("Birthday", BindingMode.OneWay,
                        null, null, "Born {0:d}"));

                BoxView boxView = new BoxView();
                boxView.SetBinding(BoxView.ColorProperty, "FavoriteColor");

                var xx = nameLabel.BindingContext;

                // Return an assembled ViewCell.
                var x = new ViewCell {
                    View = new StackLayout {
                        Padding = new Thickness(0, 5),
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                                    boxView,
                                    new StackLayout
                                    {
                                        VerticalOptions = LayoutOptions.Center,
                                        Spacing = 0,
                                        Children =
                                        {
                                            nameLabel,
                                            birthdayLabel
                                        }
                                        }
                                }
                        }
                    };
                return x;
            })
            };

        }

    public override void SetField(IBindable data) {
        //ListView.ItemsSource = new string[] { "Alice", "Bob", "Carol", "Doug", "Mallet" };
        }

    public override void GetField(IBindable data) {
        }



   


    static object GetCell() {


        throw new NotImplementedException();
        }
    }


public class BoundObject {

    public string Binding { get; set; }

    public BoundObject(string binding) {
        Binding = binding;
        }

    public object GetCell() {


        throw new NotImplementedException();
        }
    }



public class BoundViewCell : ViewCell {

    public BoundViewCell() {



        }
    }


class ListViewDemoPage : ContentPage {

    public ListView ListView;

    public ListViewDemoPage() {

        List<Person> people = new List<Person>
        {
                new Person("Abigail", new DateTime(1975, 1, 15)),
                new Person("Bob", new DateTime(1976, 2, 20)),
                // ...etc.,...
                new Person("Yvonne", new DateTime(1987, 1, 10)),
                new Person("Zachary", new DateTime(1988, 2, 5))
            };

        // Create the ListView.
        ListView = new ListView {
            ItemsSource = people
            };
        }
    }
class Person {
    public Person(string name, DateTime birthday) {
        this.Name = name;
        this.Birthday = birthday;
        this.FavoriteColor = Color.FromHex("00f00f");
        }

    public string Name { private set; get; }

    public DateTime Birthday { private set; get; }

    public Color FavoriteColor { private set; get; }
    };



public class GuigenFieldChooser : GuigenField {
    public IView View => ListView;


    public Entry ValueField;

    public ListView ListView;
    //Func<GuiBinding, object> BindingDelegate { get; }

    ISelectCollection SelectCollection;


    class Person {
        public Person(string name, DateTime birthday) {
            this.Name = name;
            this.Birthday = birthday;
            this.FavoriteColor = Color.FromHex("00f00f");
            }

        public string Name { private set; get; }

        public DateTime Birthday { private set; get; }

        public Color FavoriteColor { private set; get; }
        };

    public GuigenFieldChooser(GuiChooser chooser) : base(chooser) {

        //var DataList = new string[] { "Alice", "Bob", "Carol", "Doug", "Mallet" };

        List<Person> people = new List<Person> {
                new Person("Abigail", new DateTime(1975, 1, 15)),
                new Person("Bob", new DateTime(1976, 2, 20)),
                // ...etc.,...
                new Person("Yvonne", new DateTime(1987, 1, 10)),
                new Person("Zachary", new DateTime(1988, 2, 5))
            };


        ListView = new ListView {
            //ItemTemplate = new DataTemplate(GetCell),
            HeightRequest = 200,
            WidthRequest = 200,
            ItemsSource = people
            };

        //ObservableCollection<string> Collection = new ObservableCollection<string>(DataList);
        //ListView.ItemsSource = Collection;
        //ListView.SetBinding(ItemsView.ItemsSourceProperty, "Collection");
        }

    public override void SetField(IBindable data) {
        ListView.ItemsSource = SelectCollection;
        }

    public override void GetField(IBindable data) {
        }



    static object GetCell() {


        throw new NotImplementedException();
        }
    }



class ListViewDemoPage1 : ContentPage {

    public ListView ListView;
    //class Person {
    //    public Person(string name, DateTime birthday) {
    //        this.Name = name;
    //        this.Birthday = birthday;
    //        this.FavoriteColor = Color.FromHex ("00f00f");
    //        }

    //    public string Name { private set; get; }

    //    public DateTime Birthday { private set; get; }

    //    public Color FavoriteColor { private set; get; }
    //    };

    public ListViewDemoPage1() {
        //Label header = new Label {
        //    Text = "ListView",
        //    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
        //    HorizontalOptions = LayoutOptions.Center
        //    };

        // Define some data.
        List<Person> people = new List<Person>
        {
                new Person("Abigail", new DateTime(1975, 1, 15)),
                new Person("Bob", new DateTime(1976, 2, 20)),
                // ...etc.,...
                new Person("Yvonne", new DateTime(1987, 1, 10)),
                new Person("Zachary", new DateTime(1988, 2, 5))
            };

        // Create the ListView.
        ListView = new ListView {
            // Source of data items.
            //DataType = "Person",
            ItemsSource = people,

            // Define template for displaying each item.
            // (Argument of DataTemplate constructor is called for 
            //      each item; it must return a Cell derivative.)
            ItemTemplate = new DataTemplate(() => {
                // Create views with bindings for displaying each property.
                Label nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, "Name");

                Label birthdayLabel = new Label();
                birthdayLabel.SetBinding(Label.TextProperty,
                    new Binding("Birthday", BindingMode.OneWay,
                        null, null, "Born {0:d}"));

                BoxView boxView = new BoxView();
                boxView.SetBinding(BoxView.ColorProperty, "FavoriteColor");

                // Return an assembled ViewCell.
                var x = new ViewCell {
                    View = new StackLayout {
                        Padding = new Thickness(0, 5),
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                                    boxView,
                                    new StackLayout
                                    {
                                        VerticalOptions = LayoutOptions.Center,
                                        Spacing = 0,
                                        Children =
                                        {
                                            nameLabel,
                                            birthdayLabel
                                        }
                                        }
                                }
                        }
                    };
                return x;
            })
            };



        //// Build the page.
        //this.Content = new StackLayout {
        //    Children =
        //    {
        //            header,
        //            ListView
        //        }
        //    };
        }
    }
