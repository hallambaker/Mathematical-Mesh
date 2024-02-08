namespace Goedel.Guigen.Maui;

public class GuigenFieldBoolean: GuigenField, IWidget {
    public IMainWindow MainWindow { get; }
    public IView View { get; private set; }

    public CheckBox ValueField;
    Label FieldLabel;
    Label Feedback = new() {
        IsVisible = false
        };

    public GuigenFieldBoolean(IMainWindow mainWindow, GuiBoolean text, GuigenFieldSet fieldsSet) : base(text) {
        MainWindow = mainWindow;

        var view = new HorizontalStackLayout();
        FieldLabel = new Label() {
            Text = text.Prompt
            };
        ValueField = new CheckBox() {
            };

        view.Add(FieldLabel);
        view.Add(ValueField);
        View = view;

        MainWindow.FormatFieldLabel(FieldLabel);
        MainWindow.FormatFieldEntry(ValueField, text, null);
        MainWindow.FormatFeedback(Feedback);

        //stack.Add(View);
        //stack.Add(Feedback);

        fieldsSet.AddField(FieldLabel, ValueField, Feedback);
        }



    public override void SetField(IBindable data) {
        var binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyBoolean;
        ValueField.IsChecked = binding.Get(data);

        }

    public override void GetField(IBindable data) {
        var binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyBoolean;
        if (binding.Set is not null) {
            binding.Set(data, ValueField.IsChecked);
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



