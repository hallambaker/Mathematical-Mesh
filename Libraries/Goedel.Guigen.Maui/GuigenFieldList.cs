namespace Goedel.Guigen.Maui;

public class GuigenFieldList : GuigenField, IWidget {

    GuiBoundPropertyList TypedBinding => PropertyBinding as GuiBoundPropertyList;
    GuigenBinding MainBinding => MainWindow.Binding;




    Label FieldLabel;
    Grid ValueField = new();
    GuigenButton AddButton ;

    Layout Layout { get; } 

    IBindable entryField;
    public ISelectList Collection {get; set;}

    public GuigenFieldList(
                GuigenFieldSet fieldsSet,
                GuiBoundPropertyList binding,
                IBindable? data = null) : base(fieldsSet, binding) {

        FieldLabel = new Label() {
            Text = binding.Prompt
            };

        if (data != null) {
            SetField(data);
            }

        AddButton = new GuigenButton(Binding, "item_add", "Add", OnClickAdd);
        if (!IsEditMode) {
            AddButton.IsVisible = false;
            }


        Layout = new VerticalStackLayout() {
            ValueField,
            AddButton.View
            };



        fieldsSet.AddField(FieldLabel, Layout);

        }

    public void OnClickAdd(object sender, EventArgs e) {
        // here we add in a blank row to the list.

        var value = TypedBinding.EntryBinding.Factory();
        Collection.Entries.Add(value);
        SetField();

        }

    ///<inheritdoc/>
    public override void SetEditable() {
        SetField();
        }

    public override void GetField(IBindable data) {
        //var binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyList;
        //ValueField.Text = binding.Get(data).ToString();
        }

    public override void SetField(IBindable data) {
        Collection = TypedBinding.Get(data) ?? new SelectList();
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

        if (IsEditMode) {
            entryField = TypedBinding.EntryBinding.Factory();
            var edit_button = new AddItemButton(MainBinding, this, entryField, row);
            ValueField.Add(edit_button, 0, row);
            }
        }


    private int MakeRow(int row, IBindable entry, bool isEntry=false) {
        var col = 0;
        foreach (var property in entry.Binding.BoundProperties) {
            if (property is GuiBoundPropertyIcon icon) {
                var evalue = icon.Get(entry);


                var cell = new Image() {
                    Source = evalue?.Source ?? "messages.png",
                    WidthRequest = MainBinding.IconWidth,
                    HeightRequest = MainBinding.IconHeight
                    };
                ValueField.Add(cell, col, row);
                col++;
                }
            if (property is GuiBoundPropertyString text) {
                var evalue = text.Get(entry);

                if (IsEditMode & !property.IsReadOnly) {
                    var cell = new Entry() {
                        Text = evalue
                        };
                    ValueField.Add(cell, col, row);
                    }
                else {
                    var cell = new Label() {
                        Text = evalue
                        };
                    ValueField.Add(cell, col, row);
                    }

                col++;
                }
            }

        if (IsEditMode) {
            //ImageButton delete_icon = isEntry ? 
            //    new AddItemButton(MainBinding, this, entry, row) :
            //    new DeleteItemButton(MainBinding, this, row);
            ImageButton edit_icon = new EditItemButton(MainBinding, this, entry, row);
            ValueField.Add(edit_icon, col++, row);
            ImageButton delete_icon = new DeleteItemButton(MainBinding, this, row);
            ValueField.Add(delete_icon, col++, row);
            }
        else {
            ImageButton info_icon = new InformationItemButton(MainBinding, this, entry, row);
            ValueField.Add(info_icon, col++, row);
            }

        return col;
        }


    public void FillValue(IBindable entry, int row) {
        foreach (var property in entry.Binding.BoundProperties) {
            if (property is GuiBoundPropertyString text) {
                if (!property.IsReadOnly) {



                    }
                }
            }


        }


    }

public class DeleteItemButton : ImageButton {
    GuigenFieldList GuigenFieldList { get; }
    ISelectList Collection => GuigenFieldList.Collection;
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
    ISelectList Collection => GuigenFieldList.Collection;
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
        GuigenFieldList.FillValue(Entry, Row);

        Collection.Entries.Add(Entry);
        GuigenFieldList.SetField();
        }


    }


public class InformationItemButton : ImageButton {

    GuigenFieldList GuigenFieldList { get; }
    ISelectList Collection => GuigenFieldList.Collection;
    int Row { get; }

    IBindable Entry { get; }
    public InformationItemButton(GuigenBinding binding, GuigenFieldList guigenFieldList, IBindable entry, int row) {
        GuigenFieldList = guigenFieldList;
        Entry = entry;
        Row = row;

        Clicked += OnClickAdd;
        Source = "info_question.png";
        WidthRequest = binding.IconWidth;
        HeightRequest = binding.IconHeight;
        }

    public void OnClickAdd(object sender, EventArgs e) {
        GuigenFieldList.FillValue(Entry, Row);

        Collection.Entries.Add(Entry);
        GuigenFieldList.SetField();
        }


    }

public class EditItemButton : ImageButton {

    GuigenFieldList GuigenFieldList { get; }
    ISelectList Collection => GuigenFieldList.Collection;
    int Row { get; }

    IBindable Entry { get; }
    public EditItemButton(GuigenBinding binding, GuigenFieldList guigenFieldList, IBindable entry, int row) {
        GuigenFieldList = guigenFieldList;
        Entry = entry;
        Row = row;

        Clicked += OnClickAdd;
        Source = "edit.png";
        WidthRequest = binding.IconWidth;
        HeightRequest = binding.IconHeight;
        }

    public void OnClickAdd(object sender, EventArgs e) {
        GuigenFieldList.FillValue(Entry, Row);

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
