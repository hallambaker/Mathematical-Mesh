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

public abstract class GuigenField(IMainWindow mainWindow, GuiBoundProperty binding) {

    public IMainWindow MainWindow { get; } = mainWindow;
    public GuiBoundProperty Binding { get; } = binding;

    public abstract void SetField(IBindable data);

    public abstract void GetField(IBindable data);


    public virtual void ClearFeedback() {
        }

    public virtual void SetFeedback(IndexedMessage message) {
        }
    }



public abstract class GuigenFieldSimple : GuigenField, IWidget {
    public IView View { get; protected set; }

    public virtual bool IsEditable => true;


    protected Label FieldLabel;
    protected Label Feedback = new() {
        IsVisible = false
        };

    public GuigenFieldSimple(
            IMainWindow mainWindow,
            GuigenFieldSet fieldsSet,
            GuiBoundPropertyPrompted binding) : base(mainWindow, binding) {

        FieldLabel = new Label() {
            Text = binding.Prompt
            };

        MainWindow.FormatFieldLabel(FieldLabel);

        MainWindow.FormatFeedback(Feedback);

        }

    ///<inheritdoc/>
    public override void ClearFeedback() {
        Feedback.IsVisible = false;
        }

    ///<inheritdoc/>
    public override void SetFeedback(IndexedMessage message) {
        Feedback.IsVisible = true;
        Feedback.Text = message.Text;
        }

    }






public class GuigenFieldSet : IWidget {

    public IMainWindow MainWindow { get; }
    //public Layout View { get; private set; }

    public Grid View { get; private set; }

    View? summary = null;
    public List<IGuiEntry> Fields { get; }
    public List<GuigenField> MauiFields { get; } = new();

    //int[] FieldMap;

    int GridRow { get; set; } = 0;
    int GridColumn { get; set; } = 0;

    public IBindable Data { get; set; }

    public GuigenFieldSet(IMainWindow mainWindow, List<IGuiEntry> fields, Layout? stack, GuiBinding binding = null, bool isEntry = true) {
        MainWindow = mainWindow;
        Fields = fields;

        View = new Grid();
        View.AddColumnDefinition(new ColumnDefinition(GridLength.Auto));
        View.AddColumnDefinition(new ColumnDefinition(GridLength.Star));
        stack?.Add(View);

        foreach (var entry in binding.BoundProperties) {
            switch (entry) {
                case GuiBoundPropertyBoolean bound: {
                    var field = new GuigenFieldBoolean(MainWindow, this, bound);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundPropertyString bound: {
                    var field = new GuigenFieldString(MainWindow, this, bound);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundTextArea bound: {
                    var field = new GuigenFieldTextArea(MainWindow, this, bound);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundPropertyColor bound: {
                    var field = new GuigenFieldColor(MainWindow, this, bound);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundPropertySize bound: {
                    var field = new GuigenFieldSize(MainWindow, this, bound);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundPropertyDecimal bound: {
                    var field = new GuigenFieldDecimal(MainWindow, this, bound);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundPropertyInteger bound: {
                    var field = new GuigenFieldInteger(MainWindow, this, bound);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundPropertyQRScan bound: {
                    var field = new GuigenFieldQr(MainWindow, this, bound);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundPropertyIcon bound: {
                    if (isEntry) {
                        }
                    else {
                        var field = new GuigenFieldIcon(MainWindow, this, bound);
                        MauiFields.Add(field);
                        break;
                        }
                    break;
                    }
                case GuiBoundPropertyChooser bound: {
                    var field = new GuigenFieldChooser(MainWindow, this, bound);
                    MauiFields.Add(field);
                    break;
                    }
                case GuiBoundPropertyList bound: {
                    var field = new GuigenFieldList(MainWindow, this, bound);
                    MauiFields.Add(field);
                    break;
                    }
                default: {
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
            //var index = FieldMap[message.Index];
            //if (index != -1) {
            //    MauiFields[index].SetFeedback(message);
            //    }
            }
        }


    public void AddField(IView label, IView child, IView? feedback=null) {


        View.Add(label, 0, GridRow);
        View.Add(child, 1, GridRow++);
        if (feedback != null) {
            View.Add(feedback, 2, GridRow++);
            }
        }

    public void AddField(IView child) {
        View.Add(child, 0, GridRow++);
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



