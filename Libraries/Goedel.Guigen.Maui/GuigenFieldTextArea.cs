namespace Goedel.Guigen.Maui;

public class GuigenFieldTextArea : GuigenField, IWidget {
    public IMainWindow MainWindow { get; }
    public IView View { get; private set; }

    public Editor ValueField;
    Label FieldLabel;
    Label Feedback = new() {
        IsVisible = false
        };

    public GuigenFieldTextArea(IMainWindow mainWindow, GuiTextArea text, GuigenFieldSet fieldsSet) : base(text) {
        MainWindow = mainWindow;

        var view = new HorizontalStackLayout();
        FieldLabel = new Label() {
            Text = text.Prompt
            };
        ValueField = new Editor() {
            AutoSize = EditorAutoSizeOption.TextChanges,
            IsSpellCheckEnabled = true,
            IsTextPredictionEnabled = false,
            Keyboard = Keyboard.Text,
            Placeholder = "Infinite monkeys with typewriters say"
            };

        view.Add(FieldLabel);
        view.Add(ValueField);
        View = view;

        MainWindow.FormatFieldLabel(FieldLabel);
        MainWindow.FormatFieldEntry(ValueField, Field, null);
        MainWindow.FormatFeedback(Feedback);


        fieldsSet.AddField(FieldLabel, ValueField, Feedback);
        }



    public override void SetField(IBindable data) {
        var binding = data.Binding.BoundProperties[Index] as GuiBoundTextArea;
        ValueField.Text = binding.Get(data);

        }

    public override void GetField(IBindable data) {
        var binding = data.Binding.BoundProperties[Index] as GuiBoundTextArea;
        if (binding.Set is not null) {
            binding.Set(data, ValueField.Text);
            }
        }


    public override void ClearFeedback() {
        Feedback.IsVisible =false;
        }

    public override void SetFeedback(IndexedMessage message) {
        Feedback.IsVisible = true;
        Feedback.Text = message.Text;
        }

    }



