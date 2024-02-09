namespace Goedel.Guigen.Maui;

public class GuigenFieldBoolean: GuigenFieldSimple, IWidget {

    GuiBoundPropertyBoolean TypedBinding => Binding as GuiBoundPropertyBoolean;

    CheckBox ValueField;

    public GuigenFieldBoolean(
                IMainWindow mainWindow, 
                GuigenFieldSet fieldsSet,
                GuiBoundPropertyBoolean binding) : base(mainWindow, fieldsSet, binding) {

        ValueField = new CheckBox() {
            };
        MainWindow.FormatFieldEntry(ValueField, binding);

        View = new HorizontalStackLayout() { FieldLabel, ValueField };
        fieldsSet.AddField(FieldLabel, ValueField, Feedback);
        }


    ///<inheritdoc/>
    public override void SetField(IBindable data) {
        ValueField.IsChecked = TypedBinding.Get(data);

        }

    ///<inheritdoc/>
    public override void GetField(IBindable data) {
        if (TypedBinding.Set is not null) {
            TypedBinding.Set(data, ValueField.IsChecked);
            }
        }

    }



