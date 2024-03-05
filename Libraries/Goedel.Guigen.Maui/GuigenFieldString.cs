namespace Goedel.Guigen.Maui;

public class GuigenFieldString : GuigenFieldSimple, IWidget {

    GuiBoundPropertyString TypedBinding => PropertyBinding as GuiBoundPropertyString;

    public override bool IsEditable => (TypedBinding.Set is not null);


    IView ViewField;

    Entry EntryField => ViewField as Entry;
    Label LabelField => ViewField as Label;
    public GuigenFieldString(IMainWindow mainWindow, 
                GuigenFieldSet fieldsSet,
                GuiBoundPropertyString binding) : base(mainWindow, fieldsSet, binding) {

        ViewField = IsEditable ? new Entry() : new Label();

        MainWindow.FormatFieldEntry(EntryField, binding);

        View = new HorizontalStackLayout() { FieldLabel, EntryField };
        fieldsSet.AddField(FieldLabel, ViewField, Feedback);
        }

    ///<inheritdoc/>
    public override void SetField(IBindable data) {
        if (IsEditable) {
            EntryField.Text = TypedBinding.Get(data);
            }
        else {
            LabelField.Text = TypedBinding.Get(data);
            }
        }

    ///<inheritdoc/>
    public override void GetField(IBindable data) {
        if (IsEditable) {
            TypedBinding.Set(data, EntryField.Text);
            }
        }

    }



