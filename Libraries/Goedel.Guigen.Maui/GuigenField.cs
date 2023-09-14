using System;

using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;

namespace Goedel.Guigen.Maui;

public abstract class GuigenField(GuiField field) {
    public IBindable Value { get; set; }

    public GuiField Field { get; } = field;
    public int Index => Field.Index;

    public abstract void SetField(IBindable data);

    public abstract void GetField(IBindable data);


    public virtual void ClearFeedback() {
        }

    public virtual void SetFeedback(IndexedMessage message) {
        }
    }


public class GuigenFieldSet : IWidget {

    public IMainWindow MainWindow { get; }
    public Layout View { get; private set; }


    public List<GuigenField> Fields { get; } = new();

    int[] FieldMap;


    public GuigenFieldSet(IMainWindow mainWindow, List<IGuiEntry> fields, Layout stack) {
        MainWindow = mainWindow;
        stack ??= new VerticalStackLayout();
        View = stack;

        FieldMap = new int[fields.Count];
        int i = 0;
        foreach (var entry in fields) {
            switch (entry) {
                case GuiText text: {
                    var field = new GuigenFieldString(MainWindow, text, stack);
                    Fields.Add(field);
                    FieldMap[i++] = field.Index;
                    break;
                    }
                case GuiChooser chooser: {
                    var field = new GuigenFieldChooser(chooser);
                    Fields.Add(field);
                    stack.Add(field.ListView);
                    FieldMap[i++] = field.Index;
                    break;
                    }
                default : {
                    FieldMap[i++] = -1;
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


    public void Feedback(GuiResultInvalid feedback) {
        foreach (var field in Fields) {
            field.ClearFeedback();
            }

        foreach (var message in feedback.Messages) {
            var index = FieldMap[message.Index];
            if (index != -1) {
                Fields[index].SetFeedback(message);
                }
            }
        }

    }


public class GuigenFieldString : GuigenField, IWidget {
    public IMainWindow MainWindow { get; }
    public IView View { get; private set; }

    public Entry ValueField;
    Label FieldLabel;
    Label Feedback = new() {
        IsVisible = false
        };

    public GuigenFieldString(IMainWindow mainWindow, GuiText text, Layout stack) : base(text) {
        MainWindow = mainWindow;

        var view = new HorizontalStackLayout();
        FieldLabel = new Label() {
            Text = text.Prompt
            };
        ValueField = new Entry() {
            };

        view.Add(FieldLabel);
        view.Add(ValueField);
        View = view;

        MainWindow.FormatFieldLabel(FieldLabel);
        MainWindow.FormatFieldEntry(ValueField);
        MainWindow.FormatFeedback(Feedback);

        stack.Add(View);
        stack.Add(Feedback);
        }



    public override void SetField(IBindable data) {
        var binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyString;
        ValueField.Text = binding.Get(data);

        }

    public override void GetField(IBindable data) {
        var binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyString;
        binding.Set(data, ValueField.Text);
        }


    public override void ClearFeedback() {
        Feedback.IsVisible =false;
        }

    public override void SetFeedback(IndexedMessage message) {
        Feedback.IsVisible = true;
        Feedback.Text = message.Text;
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

public class BindableTemplate(GuigenFieldChooser fieldChooser) : DataTemplate( () => new MyViewCell (fieldChooser)) {
    GuigenFieldChooser FieldChooser { get; } = fieldChooser;
    }








/// <summary>
/// Can't use this because ListView does not support ItemTemplateSelector
/// </summary>
public class TemplateSelector(GuigenFieldChooser fieldChooser) : DataTemplateSelector {
    GuigenFieldChooser FieldChooser { get; } = fieldChooser;

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
        throw new NotImplementedException();
        }
    }



public class BoundObject(string binding) {

    public string Binding { get; set; } = binding;

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


