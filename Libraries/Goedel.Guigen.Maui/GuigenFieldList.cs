namespace Goedel.Guigen.Maui;

public class GuigenFieldList : GuigenField, IWidget {

    GuiBoundPropertyList TypedBinding => PropertyBinding as GuiBoundPropertyList;
    GuigenBinding MainBinding => MainWindow.Binding;

    public IView View { get; private set; }

    Label FieldLabel;
    Microsoft.Maui.Controls.Grid InputField = new();
    Microsoft.Maui.Controls.Grid ValueField = new();
    ImageButton AddButton ;


    IBindable entryField;

    public GuigenFieldList(IMainWindow mainWindow,
                GuigenFieldSet fieldsSet,
                GuiBoundPropertyList binding) : base(mainWindow, binding) {

        FieldLabel = new Label() {
            Text = binding.Prompt
            };
        //AddButton = new() {
        //    Source = "plus.png",
        //    WidthRequest = MainBinding.ListIconWidth,
        //    HeightRequest = MainBinding.ListIconHeight
        //    };
        //AddButton.Clicked += OnClickAdd;

        //var layout = new HorizontalStackLayout() { FieldLabel, AddButton };

        //var vlayout = new VerticalStackLayout() { ValueField, InputField};
        //InputField.IsVisible = false;
        //FillGrid();

        fieldsSet.AddField(FieldLabel, ValueField);
        }

    public void OnClickAdd(object sender, EventArgs e) {
        InputField.IsVisible = true;
        // add row to grid

        // set row in edit mode

        // 
        }

    public void FillGrid() {
        var col = 0;

        var add_icon = new ImageButton() {
            Source = "item_delete_minus.png",
            WidthRequest = MainBinding.ListIconWidth,
            HeightRequest = MainBinding.ListIconHeight
            };
        ValueField.Add(add_icon, col++, 0);

        foreach (var property in TypedBinding.EntryBinding.BoundProperties) {
            if (property is GuiBoundPropertyIcon icon) {
                }
            if (property is GuiBoundPropertyString text) {
                var cell = new Entry();
                InputField.Add(cell, col, 0);
                col++;
                }
            }
        var add_icon2 = new ImageButton() {
            Source = "item_delete_minus.png",
            WidthRequest = MainBinding.ListIconWidth,
            HeightRequest = MainBinding.ListIconHeight
            };
        ValueField.Add(add_icon2, col++, 0);

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
        foreach (var entry in value.Entries) {
            MakeRow(value, row++, entry);
            }

        entryField = TypedBinding.EntryBinding.Factory();
        MakeRow(value, row++, entryField, true);
        }

    private int MakeRow(ISelectCollection collection, int row, IBindable entry, bool isEntry=false) {
        var col = 0;
        foreach (var property in entry.Binding.BoundProperties) {
            if (property is GuiBoundPropertyIcon icon) {
                var evalue = icon.Get(entry);


                var cell = new Microsoft.Maui.Controls.Image() {
                    Source = evalue?.Source ?? "messages.png",
                    WidthRequest = MainBinding.IconWidth,
                    HeightRequest = MainBinding.IconHeight
                    };
                ValueField.Add(cell, col, row);
                col++;
                }
            if (property is GuiBoundPropertyString text) {
                var evalue = text.Get(entry);
                var cell = new Entry() {
                    Text = evalue
                    };
                ValueField.Add(cell, col, row);
                col++;
                }
            }

        //var iconSource = isEntry ? "item_add.png" : "item_delete_minus.png";

        //var delete_icon = new ImageButton() {
        //    Source = iconSource,
        //    WidthRequest = MainBinding.ListIconWidth,
        //    HeightRequest = MainBinding.ListIconHeight
        //    };


        ImageButton delete_icon = isEntry ? new AddItemButton(MainBinding, collection, row) :
                new DeleteItemButton(MainBinding, collection, row);

        ValueField.Add(delete_icon, col, row);

        return col;
        }
    }

public class DeleteItemButton : ImageButton {
    ISelectCollection Collection { get; }
    int Row { get; }
    public DeleteItemButton(GuigenBinding binding, ISelectCollection collection, int row) { 
        Collection = collection;
        Row = row;
        Clicked += OnClickDelete;
        Source = "item_delete_minus.png";
        WidthRequest = binding.IconWidth;
        HeightRequest = binding.IconHeight;
        }

    public void OnClickDelete(object sender, EventArgs e) {
        Collection.Entries.RemoveAt(Row);
        // refresh the display here.
        }


    }

public class AddItemButton : ImageButton {
    ISelectCollection Collection { get; }
    int Row { get; }
    public AddItemButton(GuigenBinding binding, ISelectCollection collection, int row) {
        Collection = collection;
        Row = row;

        Clicked += OnClickAdd;
        Source = "item_add.png";
        WidthRequest = binding.IconWidth;
        HeightRequest = binding.IconHeight;
        }

    public void OnClickAdd(object sender, EventArgs e) {
        }


    }



public class BoundEntry : Entry {
    GuiBoundPropertyString Property { get; }
    IBindable Entry { get; }

    public BoundEntry(GuiBoundPropertyString property, IBindable entry) { 
        Property = property;
        Entry = entry;
        }





    }
