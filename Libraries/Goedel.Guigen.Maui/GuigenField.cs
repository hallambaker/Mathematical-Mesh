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

    public GuigenBinding Binding => MainWindow.Binding;
    public GuiBoundProperty PropertyBinding { get; } = binding;

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



