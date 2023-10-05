using System;

using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;
using Goedel.Utilities;
using static System.Collections.Specialized.BitVector32;
using System.Collections.Generic;

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
                case GuiInteger integer: {
                    var field = new GuigenFieldInteger(MainWindow, integer, stack);
                    Fields.Add(field);
                    FieldMap[i++] = field.Index;
                    break;
                    }
                case GuiChooser chooser: {
                    var field = new GuigenFieldChooser(MainWindow, chooser, stack);
                    Fields.Add(field);
                    //stack.Add(field.ListView);
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
        if (binding.Set is not null) {
            binding.Set(data, ValueField.Text);
            }
        }


    public override void ClearFeedback() {
        Feedback.IsVisible =false;
        }

    public override void SetFeedback(IndexedMessage message) {
        Feedback.IsVisible = true;
        Feedback.Text = message.Text;
        }

    }


public class GuigenFieldInteger : GuigenField, IWidget {
    public IMainWindow MainWindow { get; }
    public IView View { get; private set; }

    public Entry ValueField;
    Label FieldLabel;
    Label Feedback = new() {
        IsVisible = false
        };

    public GuigenFieldInteger(IMainWindow mainWindow, GuiInteger text, Layout stack) : base(text) {
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
        var binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyInteger;
        ValueField.Text = binding.Get(data).ToString();

        }

    public override void GetField(IBindable data) {
        var binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyInteger;
        int? fieldValue = Int32.TryParse(ValueField.Text, out var result) ? result : null;
        binding.Set(data, fieldValue);
        }


    public override void ClearFeedback() {
        Feedback.IsVisible = false;
        }

    public override void SetFeedback(IndexedMessage message) {
        Feedback.IsVisible = true;
        Feedback.Text = message.Text;
        }

    }


public class BoundListView : ListView {


    public object BoundData { get; set; }





    }


//public class FieldBinding {

//    GuiBinding Binding;
//    Label[] Labels;

//    public FieldBinding(MyViewCell cell) {
//        var stack = new HorizontalStackLayout();
//        cell.View = stack;

//        var chooser = cell.Chooser.Chooser;
//        foreach (var entry in chooser.Entries) {
//            switch (entry) {
//                case GuiView view: {
//                    Binding ??= view.Binding;

//                    break;
//                    }
//                }
//            }

//        int i = 0;
//        Labels = new Label[Binding.BoundProperties.Length];
//        foreach (var property in Binding.BoundProperties) {
//            var label = new Label();
//            Labels[i++] = label;
//            stack.Add(label);
//            }
//        }

//    public void Bind(object data) {
//        if (data == null) {
//            return;
//            }

//        for (var i=0; i< Binding.BoundProperties.Length; i++) {
//            var field = Binding.BoundProperties[i] as GuiBoundPropertyString;
//            var value = field.Get(data);

//            Labels[i].Text = value;
//            }

//        }


//    }

/// <summary>
/// <see cref="ViewCell"/> bound to the cell data specified by <see cref="BindingContext"/> described
/// by the binding data described by <see cref="Chooser"/>.
/// </summary>
public class MyViewCell : ViewCell {

    public bool Visible { get; set; }
    public GuigenFieldChooser Chooser { get; }
    ISelectCollection SelectCollection => Chooser.SelectCollection;

    //FieldBinding FieldBinding { get; set; }


    public MyViewCell(GuigenFieldChooser chooser) { 
        Chooser = chooser;
        BindingContextChanged += OnBindingChanged;
        PropertyChanged += OnPropertyChanged;
        Appearing += OnAppearing;
        Disappearing += OnDisappearing;
        //FieldBinding = new FieldBinding(this);
        }


    public void OnAppearing(object? sender, EventArgs e) {
        Visible = true;
        }

    public void OnDisappearing(object? sender, EventArgs e) {
        Visible = false;
        }

    public void OnBindingChanged(object? sender, EventArgs e) {

        //value = Chooser.ListView.ItemsSource as ISelectCollection;


        //FieldBinding.Bind(BindingContext);
        }


    public void OnPropertyChanged(object? sender, EventArgs e) {
        //if (BindingContext != null) {
        //    FieldBinding.Bind(BindingContext);
        //    }

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


