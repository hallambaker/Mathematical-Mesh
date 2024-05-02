using System.Data;

namespace Goedel.Guigen.Maui;

/// <summary>
/// Backing class for a string entry field.
/// </summary>
public class GuigenFieldString : GuigenFieldSimple, IWidget {

    GuiBoundPropertyString TypedBinding => PropertyBinding as GuiBoundPropertyString;

    ///<inheritdoc/>
    public override bool IsEditable => IsEditMode & (TypedBinding.Set is not null);


    Entry FieldAsEntry { get; set; } 
    Label FieldAsLabel { get; set; }

    bool currentEditMode;

    IBindable Data;


    string Value { get; set; }

    int GridRow { get; set; }

    /// <summary>
    /// Return a new instance of a field to be displayed in the field set <paramref name="fieldsSet"/>
    /// with properties defined by <paramref name="fieldBinding"/> bound to the value <paramref name="data"/>.
    /// </summary>
    /// <param name="fieldsSet">The field set to present the field within</param>
    /// <param name="fieldBinding">Description of the field parameters.</param>
    /// <param name="data">Data to which the field is to be bound.</param>
    public GuigenFieldString(
                GuigenFieldSet fieldsSet,
                GuiBoundPropertyString fieldBinding,
                IBindable? data = null) : base(fieldsSet, fieldBinding) {
        GridRow = fieldsSet.AddField(FieldLabel, null, Feedback);
        SetEditable();
        SetField(data);
        }

    ///<inheritdoc/>
    public override void SetEditable() {
        if (IsEditable ) {
            if (FieldAsEntry == null) {
                FieldAsEntry = Binding.GetEntry(this);
                FieldAsEntry.Text = Value;

                FieldSet.ReplaceField(FieldAsLabel, FieldAsEntry, GridRow);
                return;
                }
            if (!currentEditMode) {
                FieldAsEntry.Text = Value;
                FieldSet.ReplaceField(FieldAsLabel, FieldAsEntry, GridRow);
                currentEditMode = true;
                }

            }
        else {
            if (FieldAsLabel == null) {
                FieldAsLabel = Binding.GetLabel();
                FieldSet.ReplaceField(FieldAsEntry, FieldAsLabel, GridRow);
                return;
                }
            if (currentEditMode) {
                FieldSet.ReplaceField(FieldAsEntry, FieldAsLabel, GridRow);
                currentEditMode = false;
                }
            }
        }

    ///<inheritdoc/>
    public override void SetField(IBindable? data) {
        Data = data;
        if (Data is null) {
            return;
            }

        Value = TypedBinding.Get(data);
        if (IsEditable) {
            FieldAsEntry.Text = Value;
            }
        else {
            FieldAsLabel.Text = Value;
            }
        }

    ///<inheritdoc/>
    public override void GetField(IBindable data) {
        if (IsEditable) {
            TypedBinding.Set(data, FieldAsEntry.Text);
            }
        }

    }



