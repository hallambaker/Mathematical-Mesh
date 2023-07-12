using System;

using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;

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

        foreach (var entry in fields) {
            switch (entry) {
                case GuiText text: {
                    var field = new GuigenFieldString(text);
                    Fields.Add(field);
                    stack.Add(field.View);
                    break;
                    }
                case GuiChooser chooser: {
                    var field = new GuigenFieldChooser(chooser);
                    Fields.Add(field);
                    stack.Add(field.ListView);
                    break;
                    }
                }
            }

        }

    public void SetFields(IBindable data) {
        if (data == null) {
            return;
            }

        foreach (var field in Fields) {
            field.SetField(data);
            }
        }

    public void GetFields(IBindable data) {
        if (data == null) {
            return;
            }

        foreach (var field in Fields) {
            field.GetField(data);
            }
        }


    }


public class FieldBinding {

    GuiBinding Binding;
    Label[] Labels;

    public FieldBinding(MyViewCell cell) {
        var stack = new HorizontalStackLayout();
        cell.View = stack;

        var chooser = cell.Chooser.Chooser;
        foreach (var entry in chooser.Entries) {
            switch (entry) {
                case GuiView view: {
                    Binding ??= view.Binding;

                    break;
                    }


                }

            }

        int i = 0;
        Labels = new Label[Binding.BoundProperties.Length];
        foreach (var property in Binding.BoundProperties) {
            var label = new Label();
            Labels[i++] = label;
            stack.Add(label);
            }
        }


    public void Bind(object data) {
        if (data == null) {
            return;
            }

        for (var i=0; i< Binding.BoundProperties.Length; i++) {
            var field = Binding.BoundProperties[i] as GuiBoundPropertyString;
            var value = field.Get(data);

            Labels[i].Text = value;
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




public class GuigenFieldChooser : GuigenField {
    public IView View => ListView;
    public GuiChooser Chooser => Field as GuiChooser;

    public Entry ValueField;
    public ListView ListView;





    public GuigenFieldChooser(GuiChooser chooser) : base(chooser) {
        //List<Person> people = new List<Person> {
        //        new Person("Abigail", new DateTime(1975, 1, 15)),
        //        new Person("Bob", new DateTime(1976, 2, 20)),
        //        // ...etc.,...
        //        new Person("Yvonne", new DateTime(1987, 1, 10)),
        //        new Person("Zachary", new DateTime(1988, 2, 5))
        //    };


        ListView = new ListView {
            ItemTemplate = new BindableTemplate(this)
            };


        }


    public override void SetField(IBindable data) {
        //ListView.ItemsSource = new string[] { "Alice", "Bob", "Carol", "Doug", "Mallet" };
        ListView.ItemsSource = data as IEnumerable;



        var binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyChooser;
        var selector = binding.Get(data);
        ListView.ItemsSource = selector;
        }

    public override void GetField(IBindable data) {
        }



   


    static object GetCell() {


        throw new NotImplementedException();
        }
    }


public class MyViewCell : ViewCell {

    public bool Visible { get; set; }
    public GuigenFieldChooser Chooser { get; }
    ISelectCollection value;

    FieldBinding FieldBinding { get; set; }


    public MyViewCell(GuigenFieldChooser chooser) { 
        Chooser = chooser;
        BindingContextChanged += OnBindingChanged;
        PropertyChanged += OnPropertyChanged;
        Appearing += OnAppearing;
        Disappearing += OnDisappearing;
        }


    public void OnAppearing(object? sender, EventArgs e) {
        Visible = true;
        }

    public void OnDisappearing(object? sender, EventArgs e) {
        Visible = false;
        }

    public void OnBindingChanged(object? sender, EventArgs e) {

        value = Chooser.ListView.ItemsSource as ISelectCollection;
        FieldBinding ??= new FieldBinding(this);

        FieldBinding.Bind(BindingContext);
        }


    public void OnPropertyChanged(object? sender, EventArgs e) {
        if (BindingContext != null) {
            }

        }





    }

public class BindableTemplate : DataTemplate {
    GuigenFieldChooser FieldChooser { get; }

    public BindableTemplate(GuigenFieldChooser fieldChooser) : base ( () => new MyViewCell (fieldChooser)) {
        FieldChooser = fieldChooser;
        }

    }








/// <summary>
/// Can't use this because ListView does not support ItemTemplateSelector
/// </summary>
public class TemplateSelector : DataTemplateSelector {
    GuigenFieldChooser FieldChooser { get; }

    public TemplateSelector (GuigenFieldChooser fieldChooser) { 
        FieldChooser = fieldChooser;
        }
    protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
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


