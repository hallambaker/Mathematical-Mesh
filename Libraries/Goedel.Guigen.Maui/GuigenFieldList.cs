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
    public ISelectCollection Collection {get; set;}

    public GuigenFieldList(IMainWindow mainWindow,
                GuigenFieldSet fieldsSet,
                GuiBoundPropertyList binding) : base(mainWindow, binding) {

        FieldLabel = new Label() {
            Text = binding.Prompt
            };
        fieldsSet.AddField(FieldLabel, ValueField);
        }

    public void OnClickAdd(object sender, EventArgs e) {
        InputField.IsVisible = true;
        // add row to grid

        // set row in edit mode

        // 
        }

    public override void GetField(IBindable data) {
        //var binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyList;
        //ValueField.Text = binding.Get(data).ToString();
        }

    public override void SetField(IBindable data) {
        Collection = TypedBinding.Get(data);
        SetField();
        }


    public void SetField() {
        ValueField.Clear();
        if (Collection?.Entries == null) {
            return;
            }

        var row = 0;
        foreach (var entry in Collection.Entries) {
            MakeRow(row++, entry);
            }

        entryField = TypedBinding.EntryBinding.Factory();
        MakeRow(row++, entryField, true);
        }


    private int MakeRow(int row, IBindable entry, bool isEntry=false) {
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

        ImageButton delete_icon = isEntry ? new AddItemButton(MainBinding, this, entry, row) :
                new DeleteItemButton(MainBinding, this, row);

        ValueField.Add(delete_icon, col, row);

        return col;
        }
    }

public class DeleteItemButton : ImageButton {
    GuigenFieldList GuigenFieldList { get; }
    ISelectCollection Collection => GuigenFieldList.Collection;
    int Row { get; }
    public DeleteItemButton(GuigenBinding binding, GuigenFieldList guigenFieldList, int row) {
        GuigenFieldList = guigenFieldList;
        Row = row;
        Clicked += OnClickDelete;
        Source = "item_delete_minus.png";
        WidthRequest = binding.IconWidth;
        HeightRequest = binding.IconHeight;
        }

    public void OnClickDelete(object sender, EventArgs e) {
        Collection.Entries.RemoveAt(Row);
        GuigenFieldList.SetField();
        }


    }

public class AddItemButton : ImageButton {

    GuigenFieldList GuigenFieldList { get; }
    ISelectCollection Collection => GuigenFieldList.Collection;
    int Row { get; }

    IBindable Entry { get; }
    public AddItemButton(GuigenBinding binding, GuigenFieldList guigenFieldList, IBindable entry, int row) {
        GuigenFieldList = guigenFieldList;
        Entry = entry;
        Row = row;

        Clicked += OnClickAdd;
        Source = "item_add.png";
        WidthRequest = binding.IconWidth;
        HeightRequest = binding.IconHeight;
        }

    public void OnClickAdd(object sender, EventArgs e) {
        Collection.Entries.Add(Entry);
        GuigenFieldList.SetField();
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
