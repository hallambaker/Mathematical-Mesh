namespace Goedel.Guigen.Maui;

public class GuigenFieldInteger : GuigenFieldSimple, IWidget {
    GuiBoundPropertyInteger TypedBinding => PropertyBinding as GuiBoundPropertyInteger;

    Entry ValueField;


    public GuigenFieldInteger(IMainWindow mainWindow,
                GuigenFieldSet fieldsSet,
                GuiBoundPropertyInteger binding) : base(mainWindow, fieldsSet, binding) {


        ValueField = new Entry() {
            };
        MainWindow.FormatFieldEntry(ValueField, binding);

        View = new HorizontalStackLayout() { FieldLabel, ValueField };
        fieldsSet.AddField(FieldLabel, ValueField, Feedback);
        }

    ///<inheritdoc/>
    public override void SetField(IBindable data) {
        ValueField.Text = TypedBinding.Get(data).ToString();
        }

    ///<inheritdoc/>
    public override void GetField(IBindable data) {
        int? fieldValue = Int32.TryParse(ValueField.Text, out var result) ? result : null;
        TypedBinding.Set(data, fieldValue);
        }

    }

public class GuigenFieldColor : GuigenFieldSimple, IWidget {
    GuiBoundPropertyColor TypedBinding => PropertyBinding as GuiBoundPropertyColor;

    Entry ValueField;


    public GuigenFieldColor(IMainWindow mainWindow,
                GuigenFieldSet fieldsSet,
                GuiBoundPropertyColor binding) : base(mainWindow, fieldsSet, binding) {


        ValueField = new Entry() {
            };
        MainWindow.FormatFieldEntry(ValueField, binding);

        View = new HorizontalStackLayout() { FieldLabel, ValueField };
        fieldsSet.AddField(FieldLabel, ValueField, Feedback);
        }

    ///<inheritdoc/>
    public override void SetField(IBindable data) {
        //ValueField.Text = TypedBinding.Get(data).ToString();
        }

    ///<inheritdoc/>
    public override void GetField(IBindable data) {
        //int? fieldValue = Float32.TryParse(ValueField.Text, out var result) ? result : null;
        //TypedBinding.Set(data, fieldValue);
        }

    }


public class GuigenFieldSize : GuigenFieldSimple, IWidget {
    GuiBoundPropertySize TypedBinding => PropertyBinding as GuiBoundPropertySize;

    Entry ValueField;


    public GuigenFieldSize(IMainWindow mainWindow,
                GuigenFieldSet fieldsSet,
                GuiBoundPropertySize binding) : base(mainWindow, fieldsSet, binding) {


        ValueField = new Entry() {
            };
        MainWindow.FormatFieldEntry(ValueField, binding);

        View = new HorizontalStackLayout() { FieldLabel, ValueField };
        fieldsSet.AddField(FieldLabel, ValueField, Feedback);
        }

    ///<inheritdoc/>
    public override void SetField(IBindable data) {
        //ValueField.Text = TypedBinding.Get(data).ToString();
        }

    ///<inheritdoc/>
    public override void GetField(IBindable data) {
        //int? fieldValue = Int32.TryParse(ValueField.Text, out var result) ? result : null;
        //TypedBinding.Set(data, fieldValue);
        }

    }



public class GuigenFieldDecimal : GuigenFieldSimple, IWidget {
    GuiBoundPropertyDecimal TypedBinding => PropertyBinding as GuiBoundPropertyDecimal;

    Entry ValueField;


    public GuigenFieldDecimal(IMainWindow mainWindow,
                GuigenFieldSet fieldsSet,
                GuiBoundPropertyDecimal binding) : base(mainWindow, fieldsSet, binding) {


        ValueField = new Entry() {
            };
        MainWindow.FormatFieldEntry(ValueField, binding);

        View = new HorizontalStackLayout() { FieldLabel, ValueField };
        fieldsSet.AddField(FieldLabel, ValueField, Feedback);
        }

    ///<inheritdoc/>
    public override void SetField(IBindable data) {
        //ValueField.Text = TypedBinding.Get(data).ToString();
        }

    ///<inheritdoc/>
    public override void GetField(IBindable data) {
        //int? fieldValue = Int32.TryParse(ValueField.Text, out var result) ? result : null;
        //TypedBinding.Set(data, fieldValue);
        }

    }