using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Guigen.Maui;

public class GuigenFieldDataActions : GuigenField, IWidget {
    GuiBoundPropertyDataActions TypedBinding => PropertyBinding as GuiBoundPropertyDataActions;
    Label FieldLabel;
    Layout Layout { get; }
    GuigenFieldSet FieldsSet;
    GuigenBinding Binding => FieldsSet.Binding;
    IBindable Data;

    public GuigenFieldDataActions(
             GuigenFieldSet fieldsSet,
             GuiBoundPropertyDataActions binding,
             IBindable? data = null) : base(fieldsSet, binding) {

        FieldsSet = fieldsSet;



        FieldLabel = new Label() {
            Text = binding.Prompt
            };

        Layout = new VerticalStackLayout();
        if (data != null) {
            SetField(data);
            }


        fieldsSet.AddField(FieldLabel, Layout);

        }

    ///<inheritdoc/>
    ///<remarks>This field does not support editing and so the command is always ignored.</remarks>
    public override void SetEditable() {
        }

    public override void GetField(IBindable data) {
        //var binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyList;
        //ValueField.Text = binding.Get(data).ToString();
        }

    public override void SetField(IBindable data) {
        Data = data;
        Layout.Clear();

        var item = TypedBinding.Get(data);
        if (item is null) {
            return;
            }
        var actions = Binding.Gui.GetDataActions(item);
        foreach (var action in actions) {
            var row = new GuigenButtonDataAction(Binding, Data, action);
            Layout.Add(row.View);
            }
        }


    }
