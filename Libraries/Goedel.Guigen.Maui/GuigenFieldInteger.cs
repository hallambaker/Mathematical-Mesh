namespace Goedel.Guigen.Maui;

public class GuigenFieldInteger : GuigenField, IWidget {
    public IMainWindow MainWindow { get; }
    public IView View { get; private set; }

    public Entry ValueField;
    Label FieldLabel;
    Label Feedback = new() {
        IsVisible = false
        };

    public GuigenFieldInteger(IMainWindow mainWindow, GuiInteger text, GuigenFieldSet fieldsSet) : base(text) {
        MainWindow = mainWindow;

        var view = new HorizontalStackLayout();
        FieldLabel = new Label() {
            Text = text.Prompt
            };
        ValueField = new Entry() {
            };

        view.Add(FieldLabel);
        view.Add(ValueField);
        View = view;

        MainWindow.FormatFieldLabel(FieldLabel);
        MainWindow.FormatFieldEntry(ValueField);
        MainWindow.FormatFeedback(Feedback);

        //stack.Add(View);
        //stack.Add(Feedback);

        fieldsSet.AddField(FieldLabel, ValueField, Feedback);
        }



    public override void SetField(IBindable data) {
        var binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyInteger;
        ValueField.Text = binding.Get(data).ToString();

        }

    public override void GetField(IBindable data) {
        var binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyInteger;
        int? fieldValue = Int32.TryParse(ValueField.Text, out var result) ? result : null;
        binding.Set(data, fieldValue);
        }


    public override void ClearFeedback() {
        Feedback.IsVisible = false;
        }

    public override void SetFeedback(IndexedMessage message) {
        Feedback.IsVisible = true;
        Feedback.Text = message.Text;
        }

    }





//class Person {
//    public Person(string name, DateTime birthday) {
//        this.Name = name;
//        this.Birthday = birthday;
//        this.FavoriteColor = Color.FromArgb("00f00f");
//        }

//    public string Name { private set; get; }

//    public DateTime Birthday { private set; get; }

//    public Color FavoriteColor { private set; get; }
//    };


