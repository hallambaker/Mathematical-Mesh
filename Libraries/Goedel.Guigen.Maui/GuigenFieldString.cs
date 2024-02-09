namespace Goedel.Guigen.Maui;

public class GuigenFieldString : GuigenFieldSimple, IWidget {

    GuiBoundPropertyString TypedBinding => Binding as GuiBoundPropertyString;

    Entry ValueField;

    public GuigenFieldString(IMainWindow mainWindow, 
                GuigenFieldSet fieldsSet,
                GuiBoundPropertyString binding) : base(mainWindow, fieldsSet, binding) {

        ValueField = new Entry() {
            };
        MainWindow.FormatFieldEntry(ValueField, binding);

        View = new HorizontalStackLayout() { FieldLabel, ValueField };
        fieldsSet.AddField(FieldLabel, ValueField, Feedback);
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



