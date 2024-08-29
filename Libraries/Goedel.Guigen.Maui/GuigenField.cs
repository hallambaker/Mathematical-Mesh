using Image = Microsoft.Maui.Controls.Image;

namespace Goedel.Guigen.Maui;




public abstract class GuigenField(IBound fieldsSet, GuiBoundProperty fieldBinding) {

    public IMainWindow MainWindow => Binding.MainWindow;


    public IBound FieldSet { get; } = fieldsSet;
    public GuigenBinding Binding => FieldSet.Binding;
    public GuiBoundProperty PropertyBinding { get; } = fieldBinding;

    public bool IsEditMode => FieldSet.IsEditMode;




    public abstract void SetField(IBindable data);

    public abstract void GetField(IBindable data);
    public abstract void SetEditable();


    public virtual void ClearFeedback() {
        }

    public virtual void SetFeedback(IndexedMessage message) {
        }

    public virtual void OnEntryTextChanged(object sender, TextChangedEventArgs e) {
        FieldSet.FieldChanged(this);
        }
    }



public abstract class GuigenFieldSimple : GuigenField, IWidget {
    public virtual IView View { get; }

    public virtual bool IsEditable => true;

    protected Label FieldLabel { get; }
    protected Label Feedback { get; }



    public GuigenFieldSimple(
            GuigenFieldSet fieldsSet,
            GuiBoundPropertyPrompted fieldBinding) : base(fieldsSet, fieldBinding) {

        FieldLabel = Binding.GetPrompt(fieldBinding.Prompt);
        Feedback = Binding.GetFeedback();
        }

    ///<inheritdoc/>
    public override void ClearFeedback() {
        Feedback.IsVisible = false;
        }

    ///<inheritdoc/>
    public override void SetFeedback(IndexedMessage message) {
        if (Feedback is not null) {
            Feedback.IsVisible = true;
            Feedback.Text = message.Text;
            }
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


public class BindableTemplate(GuigenFieldChooser fieldChooser) : DataTemplate(() => new MyViewCell(fieldChooser)) {
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



