using static System.Net.Mime.MediaTypeNames;

namespace Goedel.Guigen.Maui;

public class GuigenFieldIcon : GuigenField, IWidget {


    public IMainWindow MainWindow { get; }
    public IView View { get; private set; }

    Label Feedback = new() {
        IsVisible = false
    };

    public GuigenFieldIcon(IMainWindow mainWindow, GuiIcon icon, GuigenFieldSet fieldsSet) : base(icon) {
        MainWindow = mainWindow;

        var view = new HorizontalStackLayout();
        //FieldLabel = new Label() {
        //    Text = text.Prompt
        //    };
        //ValueField = new Entry() {
        //    };

        //view.Add(FieldLabel);
        //view.Add(ValueField);
        //View = view;

        //MainWindow.FormatFieldLabel(FieldLabel);
        //MainWindow.FormatFieldEntry(ValueField);
        //MainWindow.FormatFeedback(Feedback);

        ////stack.Add(View);
        ////stack.Add(Feedback);

        //fieldsSet.AddField(FieldLabel, ValueField, Feedback);
        }



    public override void GetField(IBindable data) {
        var binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyList;
        //ValueField.Text = binding.Get(data).ToString();
        }

    public override void SetField(IBindable data) {
        var binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyList;
        //int? fieldValue = Int32.TryParse(ValueField.Text, out var result) ? result : null;
        //binding.Set(data, fieldValue);
        }


    public override void ClearFeedback() {
        Feedback.IsVisible = false;
        }

    public override void SetFeedback(IndexedMessage message) {
        Feedback.IsVisible = true;
        Feedback.Text = message.Text;
        }
    }





