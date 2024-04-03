using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Guigen.Maui;

public class GuigenFieldTextArea : GuigenFieldSimple, IWidget {

    GuiBoundTextArea TypedBinding => PropertyBinding as GuiBoundTextArea;

    ///<inheritdoc/>
    public override bool IsEditable => IsEditMode & (TypedBinding.Set is not null);

    Editor ValueField;

    public GuigenFieldTextArea(
                GuigenFieldSet fieldsSet,
                GuiBoundTextArea binding,
                IBindable? data = null) : base(fieldsSet, binding) {

        ValueField = Binding.GetEditor(this);
        fieldsSet.AddField(FieldLabel, ValueField, Feedback);
        SetEditable();
        SetField(data);
        }

    ///<inheritdoc/>
    public override void SetEditable() {
        ValueField.IsEnabled = IsEditable;
        }

    ///<inheritdoc/>
    public override void SetField(IBindable data) {
        ValueField.Text = TypedBinding.Get(data);

        }

    ///<inheritdoc/>
    public override void GetField(IBindable data) {
        if (TypedBinding.Set is not null) {
            TypedBinding.Set(data, ValueField.Text);
            }
        }

    }



