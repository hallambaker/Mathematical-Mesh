namespace Goedel.Guigen.Maui;

public class GuigenFieldTextArea : GuigenFieldSimple, IWidget {

    GuiBoundTextArea TypedBinding => Binding as GuiBoundTextArea;

    Editor ValueField;

    public GuigenFieldTextArea(
                IMainWindow mainWindow,
                GuigenFieldSet fieldsSet,
                GuiBoundTextArea binding) : base(mainWindow, fieldsSet, binding) {

        ValueField = new Editor() {
            AutoSize = EditorAutoSizeOption.TextChanges,
            IsSpellCheckEnabled = true,
            IsTextPredictionEnabled = false,
            Keyboard = Keyboard.Text,
            Placeholder = "Infinite monkeys with typewriters say"
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



