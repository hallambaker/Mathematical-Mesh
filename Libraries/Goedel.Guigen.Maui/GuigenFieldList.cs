namespace Goedel.Guigen.Maui;

public class GuigenFieldList : GuigenField, IWidget {


    public IMainWindow MainWindow { get; }
    GuigenBinding Binding => MainWindow.Binding;

    public IView View { get; private set; }

    Label FieldLabel;
    Grid ValueField = new();
    ImageButton AddButton ;

    public GuigenFieldList(IMainWindow mainWindow, GuiList list, GuigenFieldSet fieldsSet) : base(list) {
        MainWindow = mainWindow;



        FieldLabel = new Label() {
            Text = list.Prompt
            };
        AddButton = new() {
            Source = "plus.png",
            WidthRequest = Binding.ListIconWidth,
            HeightRequest = Binding.ListIconHeight
            };
        AddButton.Clicked += OnClickAdd;


        var layout = new HorizontalStackLayout() { FieldLabel, AddButton };


        //ValueField = new Entry() {
        //    };

        //view.Add(FieldLabel);
        //view.Add(ValueField);


        //MainWindow.FormatFieldLabel(FieldLabel);
        //MainWindow.FormatFieldEntry(ValueField);
        //MainWindow.FormatFeedback(Feedback);

        ////stack.Add(View);
        ////stack.Add(Feedback);

        fieldsSet.AddField(layout, ValueField);
        }

    public void OnClickAdd(object sender, EventArgs e) {

        }

    public override void GetField(IBindable data) {
        var binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyList;
        //ValueField.Text = binding.Get(data).ToString();
        }

    public override void SetField(IBindable data) {
        var binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyList;
        var value = binding.Get(data);

        ValueField.Clear();
        if (value?.Entries == null) {
            return;
            }
        var row = 0;
        var col = 0;
        foreach (var entry in value.Entries) {

            foreach (var property in entry.Binding.BoundProperties) {
                if (property is GuiBoundPropertyIcon icon) {
                    var evalue = icon.Get(entry) as FieldIcon;


                    var cell = new Image() {
                        Source = evalue?.Source ?? "messages",
                        WidthRequest = Binding.IconWidth,
                        HeightRequest = Binding.IconHeight
                        };
                    ValueField.Add(cell, col, row);
                    col++;
                    }
                if (property is GuiBoundPropertyString text) {
                    var evalue = text.Get(entry);

                    var cell = new Label() { Text = evalue };
                    ValueField.Add(cell, col, row);
                    col++;
                    }
                }


            row++;
            }


        var a = 1;


        //int? fieldValue = Int32.TryParse(ValueField.Text, out var result) ? result : null;
        //binding.Set(data, fieldValue);
        }


    public override void ClearFeedback() {
        //Feedback.IsVisible = false;
        }

    public override void SetFeedback(IndexedMessage message) {
        //Feedback.IsVisible = true;
        //Feedback.Text = message.Text;
        }
    }





