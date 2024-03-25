using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Guigen.Maui;


/// <summary>
/// Backing class for an integer entry field.
/// </summary>
public class GuigenFieldInteger : GuigenFieldSimple, IWidget {
    GuiBoundPropertyInteger TypedBinding => PropertyBinding as GuiBoundPropertyInteger;
    ///<inheritdoc/>
    public override bool IsEditable => IsEditMode & (TypedBinding.Set is not null);

    Entry ValueField;


    public GuigenFieldInteger(
                GuigenFieldSet fieldsSet,
                GuiBoundPropertyInteger binding,
                IBindable? data = null) : base(fieldsSet, binding) {

        ValueField = Binding.GetEntry();
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
        ValueField.Text = TypedBinding.Get(data).ToString();
        }

    ///<inheritdoc/>
    public override void GetField(IBindable data) {
        int? fieldValue = Int32.TryParse(ValueField.Text, out var result) ? result : null;
        TypedBinding.Set(data, fieldValue);
        }

    }

public class GuigenFieldColor : GuigenFieldSimple, IWidget {
    GuiBoundPropertyColor TypedBinding => PropertyBinding as GuiBoundPropertyColor;
    ///<inheritdoc/>
    public override bool IsEditable => IsEditMode & (TypedBinding.Set is not null);

    Entry ValueField;


    public GuigenFieldColor(
                GuigenFieldSet fieldsSet,
                GuiBoundPropertyColor binding,
                IBindable? data = null) : base(fieldsSet, binding) {


        ValueField = Binding.GetEntry();
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
        //ValueField.Text = TypedBinding.Get(data).ToString();
        }

    ///<inheritdoc/>
    public override void GetField(IBindable data) {
        //int? fieldValue = Float32.TryParse(ValueField.Text, out var result) ? result : null;
        //TypedBinding.Set(data, fieldValue);
        }

    }


public class GuigenFieldSize : GuigenFieldSimple, IWidget {
    GuiBoundPropertySize TypedBinding => PropertyBinding as GuiBoundPropertySize;
    ///<inheritdoc/>
    public override bool IsEditable => IsEditMode & (TypedBinding.Set is not null);

    Entry ValueField;


    public GuigenFieldSize(
                GuigenFieldSet fieldsSet,
                GuiBoundPropertySize binding,
                IBindable? data = null) : base(fieldsSet, binding) {


        ValueField = Binding.GetEntry();
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
        //ValueField.Text = TypedBinding.Get(data).ToString();
        }

    ///<inheritdoc/>
    public override void GetField(IBindable data) {
        //int? fieldValue = Int32.TryParse(ValueField.Text, out var result) ? result : null;
        //TypedBinding.Set(data, fieldValue);
        }

    }



public class GuigenFieldDecimal : GuigenFieldSimple, IWidget {
    GuiBoundPropertyDecimal TypedBinding => PropertyBinding as GuiBoundPropertyDecimal;
    ///<inheritdoc/>
    public override bool IsEditable => IsEditMode & (TypedBinding.Set is not null);

    Entry ValueField;


    public GuigenFieldDecimal(
                GuigenFieldSet fieldsSet,
                GuiBoundPropertyDecimal binding,
                IBindable? data = null) : base(fieldsSet, binding) {


        ValueField = Binding.GetEntry();
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
        //ValueField.Text = TypedBinding.Get(data).ToString();
        }

    ///<inheritdoc/>
    public override void GetField(IBindable data) {
        //int? fieldValue = Int32.TryParse(ValueField.Text, out var result) ? result : null;
        //TypedBinding.Set(data, fieldValue);
        }

    }