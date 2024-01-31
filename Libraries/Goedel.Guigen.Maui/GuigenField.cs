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


public partial record FieldIcon(string File) : IFieldIcon {
    public string Source => File + ".png";


    }

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

    public IBindable Data { get; set; }

    public GuigenFieldSet(IMainWindow mainWindow, List<IGuiEntry> fields, Layout? stack, bool isEntry=true) {
        MainWindow = mainWindow;
        Fields = fields;

        //stack ??= new VerticalStackLayout();
        //View = stack;

        View = new Grid();
        View.AddColumnDefinition(new ColumnDefinition(GridLength.Auto));
        View.AddColumnDefinition(new ColumnDefinition(GridLength.Star));
        stack?.Add(View);


        FieldMap = new int[fields.Count];
        int index = 0;
       foreach (var entry in fields) {
            switch (entry) {
                case GuiText text: {
                    var field = new GuigenFieldString(MainWindow, text, this);
                    MauiFields.Add(field);
                    FieldMap[index++] = field.Index;
                    break;
                    }
                case GuiTextArea text: {
                    var field = new GuigenFieldTextArea(MainWindow, text, this);
                    MauiFields.Add(field);
                    FieldMap[index++] = field.Index;
                    break;
                    }
                case GuiInteger integer: {
                    var field = new GuigenFieldInteger(MainWindow, integer, this);
                    MauiFields.Add(field);
                    FieldMap[index++] = field.Index;
                    break;
                    }
                case GuiChooser chooser: {
                    var field = new GuigenFieldChooser(MainWindow, chooser, this);
                    MauiFields.Add(field);
                    //stack.Add(field.ListView);
                    FieldMap[index++] = field.Index;
                    break;
                    }
                case GuiQRScan qrscan: {
                    var field = new GuigenFieldQr(MainWindow, qrscan, this);
                    MauiFields.Add(field);
                    //stack.Add(field.ListView);
                    FieldMap[index++] = field.Index;
                    break;
                    }
                case GuiList list: {
                    var field = new GuigenFieldList(MainWindow, list, this);
                    MauiFields.Add(field);
                    FieldMap[index++] = field.Index;
                    break;
                    }
                case GuiIcon icon: {
                    if (isEntry) {
                        FieldMap[index++] = -1;
                        }
                    else {
                        var field = new GuigenFieldIcon(MainWindow, icon, this);
                        MauiFields.Add(field);
                        FieldMap[index++] = field.Index;
                        break;
                        }
                    break;
                    }
                default : {
                    FieldMap[index++] = -1;
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


    public void AddField(IView label, IView child, IView? feedback=null) {

        //var stack = new HorizontalStackLayout();
        //stack.Add(label);
        //stack.Add(child);
        //View.Add(stack);
        //View.Add(feedback);

        View.Add(label, 0, GridRow);
        View.Add(child, 1, GridRow++);
        if (feedback != null) {
            View.Add(feedback, 2, GridRow++);
            }
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



