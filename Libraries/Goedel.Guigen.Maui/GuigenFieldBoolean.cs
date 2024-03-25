using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Guigen.Maui;

/// <summary>
/// Backing class for a checkbox entry field.
/// </summary>
public class GuigenFieldBoolean : GuigenFieldSimple, IWidget {

    GuiBoundPropertyBoolean TypedBinding => PropertyBinding as GuiBoundPropertyBoolean;

    ///<inheritdoc/>
    public override bool IsEditable => IsEditMode & (TypedBinding.Set is not null);


    CheckBox ValueField;

    /// <summary>
    /// Return a new instance of a field to be displayed in the field set <paramref name="fieldsSet"/>
    /// with properties defined by <paramref name="fieldBinding"/> bound to the value <paramref name="data"/>.
    /// </summary>
    /// <param name="fieldsSet">The field set to present the field within</param>
    /// <param name="fieldBinding">Description of the field parameters.</param>
    /// <param name="data">Data to which the field is to be bound.</param>
    public GuigenFieldBoolean(
                GuigenFieldSet fieldsSet,
                GuiBoundPropertyBoolean fieldBinding,
                IBindable? data = null) : base(fieldsSet, fieldBinding) {

        ValueField = Binding.GetCheckBox();
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
        ValueField.IsChecked = TypedBinding.Get(data) == true;
        }

    ///<inheritdoc/>
    public override void GetField(IBindable data) {
        if (TypedBinding.Set is not null) {
            TypedBinding.Set(data, ValueField.IsChecked);
            }
        }

    }



