namespace Goedel.Guigen.Maui;

public class GuigenFieldOutputSet : IWidget {

    public IMainWindow MainWindow { get; }
    public Layout View { get; private set; }


    public List<GuigenField> Fields { get; } = new();


    public GuigenFieldOutputSet(IMainWindow mainWindow, IEnumerable<IGuiEntry> fields, Layout stack) {
        MainWindow = mainWindow;
        stack ??= new VerticalStackLayout();
        View = stack;

        foreach (var entry in fields) {
            switch (entry) {
                case GuiText text: {
                    var field = new GuigenFieldOutputString(MainWindow, text, stack);
                    Fields.Add(field);

                    break;
                    }
                }
            }
        }

    public void SetFields(IBindable data) {
        if (data == null) {
            return;
            }

        foreach (var field in Fields) {
            field.SetField(data);
            }
        }

    public void GetFields(IBindable data) {
        if (data == null) {
            return;
            }

        foreach (var field in Fields) {
            field.GetField(data);
            }
        }


    }


public class GuigenFieldOutputString : GuigenField, IWidget {
    public IMainWindow MainWindow { get; }
    public IView View { get; private set; }

    Label ValueField;
    Label FieldLabel;
    Label Feedback = new() {
        IsVisible = false
        };

    public GuigenFieldOutputString(IMainWindow mainWindow, GuiText text, Layout stack) : base(text) {
        MainWindow = mainWindow;

        var view = new HorizontalStackLayout();
        FieldLabel = new Label() {
            Text = text.Prompt
            };
        ValueField = new Label() {
            };

        view.Add(FieldLabel);
        view.Add(ValueField);
        View = view;

        MainWindow.FormatFieldLabel(FieldLabel);
        MainWindow.FormatFieldEntry(ValueField);
        MainWindow.FormatFeedback(Feedback);

        stack.Add(View);
        stack.Add(Feedback);
        }

    public override void SetField(IBindable data) {
        var binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyString;
        ValueField.Text = binding.Get(data);
        }

    public override void GetField(IBindable data) {
        }

    public void SetMessage(string message) {
        Feedback.IsVisible = message != null;
        Feedback.Text = message;
        }


    }
