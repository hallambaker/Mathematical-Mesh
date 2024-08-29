namespace Goedel.Guigen.Maui;

public class GuigenFieldIcon : GuigenField, IWidget {


    GuiBoundPropertyIcon TypedBinding => PropertyBinding as GuiBoundPropertyIcon;



    public GuigenFieldIcon(
                GuigenFieldSet fieldsSet,
                GuiBoundPropertyIcon binding,
                IBindable? data = null) : base(fieldsSet, binding) {

        }

    ///<inheritdoc/>
    public override void SetEditable() {

        }

    public override void GetField(IBindable data) {
        //var binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyList;
        //ValueField.Text = binding.Get(data).ToString();
        }

    public override void SetField(IBindable data) {
        //var binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyList;
        //int? fieldValue = Int32.TryParse(ValueField.Text, out var result) ? result : null;
        //binding.Set(data, fieldValue);
        }

    }





