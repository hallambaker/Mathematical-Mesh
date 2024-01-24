using System;

using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;
using Goedel.Utilities;
using static System.Collections.Specialized.BitVector32;
using System.Collections.Generic;


using Image = Microsoft.Maui.Controls.Image;
using Microsoft.UI.Xaml.Controls.Primitives;

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
    //public Layout View { get; private set; }

    public Grid View { get; private set; }

    View? summary = null;
    public List<IGuiEntry> Fields { get; }
    public List<GuigenField> MauiFields { get; } = new();

    int[] FieldMap;

    int GridRow { get; set; } = 0;
    int GridColumn { get; set; } = 0;

    IBindable Data { get; set; }

    public GuigenFieldSet(IMainWindow mainWindow, List<IGuiEntry> fields, Layout? stack) {
        MainWindow = mainWindow;
        Fields = fields;

        //stack ??= new VerticalStackLayout();
        //View = stack;

        View = new Grid();
        View.AddColumnDefinition(new ColumnDefinition(GridLength.Auto));
        View.AddColumnDefinition(new ColumnDefinition(GridLength.Star));
        stack?.Add(View);


        FieldMap = new int[fields.Count];
        int i = 0;
        foreach (var entry in fields) {
            switch (entry) {
                case GuiText text: {
                    var field = new GuigenFieldString(MainWindow, text, this);
                    MauiFields.Add(field);
                    FieldMap[i++] = field.Index;
                    break;
                    }
                case GuiInteger integer: {
                    var field = new GuigenFieldInteger(MainWindow, integer, this);
                    MauiFields.Add(field);
                    FieldMap[i++] = field.Index;
                    break;
                    }
                case GuiChooser chooser: {
                    var field = new GuigenFieldChooser(MainWindow, chooser, this);
                    MauiFields.Add(field);
                    //stack.Add(field.ListView);
                    FieldMap[i++] = field.Index;
                    break;
                    }
                case GuiQRScan qrscan: {
                    //var label = new Label() {
                    //    Text = "Flopple"};
                    //Fields.Add(label);

                    var field = new GuigenFieldQr(MainWindow, qrscan, this);
                    MauiFields.Add(field);
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
        Data = data;
        if (data == null) {
            return;
            }
        if (!data.Binding.IsType(data)) {
            return;
            }
        foreach (var field in MauiFields) {
            field.SetField(data);
            }
        }

    public void GetFields(IBindable data) {
        if (data == null) {
            return;
            }

        foreach (var field in MauiFields) {
            field.GetField(data);
            }
        }


    public void Feedback(GuiResultInvalid feedback) {
        foreach (var field in MauiFields) {
            field.ClearFeedback();
            }

        foreach (var message in feedback.Messages) {
            var index = FieldMap[message.Index];
            if (index != -1) {
                MauiFields[index].SetFeedback(message);
                }
            }
        }


    public void AddField(IView label, IView child, IView feedback) {

        //var stack = new HorizontalStackLayout();
        //stack.Add(label);
        //stack.Add(child);
        //View.Add(stack);
        //View.Add(feedback);

        View.Add(label, 0, GridRow);
        View.Add(child, 1, GridRow++);
        View.Add(feedback, 2, GridRow++);
        }

    public void AddField(IView child) {
        View.Add(child, 0, GridRow++);
        //View.Add(child);
        }


    public void AddButtons(Layout layout) {

        foreach (var entry in Fields) {
            switch (entry) {
                case GuiButton button: {
                    layout.Add(AddButton(button));
                    break;
                    }
                }
            }

        }

    IView AddButton(GuiButton button) {

        switch (button.Target) {

            case GuiSection section: {
                return new GuigenSectionButton(MainWindow, section).View;
                }
            case GuiAction action: {
                return new GuigenActionButton(MainWindow, action) {
                    FieldSet = this}.View;
                }
            }
        throw new NotImplementedException();


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

    public GuigenFieldString(IMainWindow mainWindow, GuiText text, GuigenFieldSet fieldsSet) : base(text) {
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

        //stack.Add(View);
        //stack.Add(Feedback);

        fieldsSet.AddField(FieldLabel, ValueField, Feedback);
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

    public GuigenFieldInteger(IMainWindow mainWindow, GuiInteger text, GuigenFieldSet fieldsSet) : base(text) {
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

        //stack.Add(View);
        //stack.Add(Feedback);

        fieldsSet.AddField(FieldLabel, ValueField, Feedback);
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


public class FieldBinding {
    MyViewCell Cell;
    IBindable Data => Cell.Data;
    GuiBinding Binding => Data?.Binding;
    Label[] Labels;

    public FieldBinding(MyViewCell cell) {
        Cell = cell;

        foreach (var field in Binding.BoundProperties) {
            }


        //var stack = new HorizontalStackLayout();
        //cell.View = stack;

        //var chooser = cell.Chooser.Chooser;
        //foreach (var entry in chooser.Entries) {
        //    switch (entry) {
        //        case GuiView view: {
        //            Binding ??= view.Binding;

        //            break;
        //            }
        //        }
        //    }

        //int i = 0;
        //Labels = new Label[Binding.BoundProperties.Length];
        //foreach (var property in Binding.BoundProperties) {
        //    var label = new Label();
        //    Labels[i++] = label;
        //    stack.Add(label);
        //    }
        }

    //public void Bind(object data) {
    //    if (data == null) {
    //        return;
    //        }

    //    for (var i = 0; i < Binding.BoundProperties.Length; i++) {
    //        var field = Binding.BoundProperties[i] as GuiBoundPropertyString;
    //        var value = field.Get(data);

    //        Labels[i].Text = value;
    //        }

    //    }


    }



public class SummaryView : HorizontalStackLayout {

    Image Image = new();
    Label Label = new();

    public SummaryView() {
        Add(Image);
        Add(Label);
        }

    public void Set(ISelectSummary summary) {
        Image.Source = summary.IconValue;
        Image.IsVisible = Image.Source is not null;
        Label.Text = summary.LabelValue;
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


