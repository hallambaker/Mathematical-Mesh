namespace Goedel.Guigen.Maui;

public class GuigenFieldList : GuigenField, IWidget {

    GuiBoundPropertyList TypedBinding => PropertyBinding as GuiBoundPropertyList;
    GuigenBinding MainBinding => MainWindow.Binding;

    public IView View { get; private set; }

    Label FieldLabel;
    Grid ValueField = new();
    ImageButton AddButton ;

    public GuigenFieldList(IMainWindow mainWindow,
                GuigenFieldSet fieldsSet,
                GuiBoundPropertyList binding) : base(mainWindow, binding) {

        FieldLabel = new Label() {
            Text = binding.Prompt
            };
        AddButton = new() {
            Source = "plus.png",
            WidthRequest = MainBinding.ListIconWidth,
            HeightRequest = MainBinding.ListIconHeight
            };
        AddButton.Clicked += OnClickAdd;

        var layout = new HorizontalStackLayout() { FieldLabel, AddButton };

        fieldsSet.AddField(layout, ValueField);
        }

    public void OnClickAdd(object sender, EventArgs e) {

        }

    public override void GetField(IBindable data) {
        //var binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyList;
        //ValueField.Text = binding.Get(data).ToString();
        }

    public override void SetField(IBindable data) {
        var value = TypedBinding.Get(data);

        ValueField.Clear();
        if (value?.Entries == null) {
            return;
            }
        var row = 0;
        var col = 0;
        foreach (var entry in value.Entries) {

            foreach (var property in entry.Binding.BoundProperties) {
                if (property is GuiBoundPropertyIcon icon) {
                    var evalue = icon.Get(entry);


                    var cell = new Image() {
                        Source = evalue?.Source ?? "messages",
                        WidthRequest = MainBinding.IconWidth,
                        HeightRequest = MainBinding.IconHeight
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
        }
    }





