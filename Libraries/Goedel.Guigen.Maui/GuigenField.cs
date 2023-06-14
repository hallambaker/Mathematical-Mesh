using System;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Guigen.Maui;

public abstract class GuigenField{
    public IBindable Value { get; set; }

    public GuiField Field { get; }
    public int Index => Field.Index;


    public GuigenField(GuiField field) {
        Field = field;
        }

    public abstract void SetField(IBindable data);

    public abstract void GetField(IBindable data);

    }

public class FieldSet {
    public Layout View { get; private set; }


    public List<GuigenField> Fields { get; } = new();


    public FieldSet(IEnumerable<IGuiEntry> fields, Layout stack) {
        stack ??= new VerticalStackLayout();
        View = stack;

        //if (prompt != null) {
        //    var label = new Label() {
        //        Text = prompt
        //        };

        //    stack.Add(label);
        //    }

        foreach (var entry in fields) {
            switch (entry) {
                case GuiText text: {
                    var field = new GuigenFieldString(text);
                    Fields.Add(field);
                    stack.Add(field.View);
                    break;
                    }
                case GuiChooser chooser: {
                    var field = new GuigenFieldChooser(chooser);
                    Fields.Add(field);
                    stack.Add(field.View);
                    break;
                    }
                }
            }




        }

    public void SetFields(IBindable data) {
        foreach (var field in Fields) {
            field.SetField(data);
            }
        }

    public void GetFields(IBindable data) {
        foreach (var field in Fields) {
            field.GetField(data);
            }
        }


    }





public class GuigenFieldString : GuigenField {

    public IView View { get; private set; }

    public Entry ValueField;

    public GuigenFieldString(GuiText text) : base (text){
        var view = new HorizontalStackLayout();
        var fieldLabel = new Label() {
            Text = text.Prompt
            };
        ValueField = new Entry() {
            };


        view.Add(fieldLabel);
        view.Add(ValueField);
        View = view;
        }
    public override void SetField(IBindable data) {
        var binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyString;
        ValueField.Text = binding.Get(data);

        }

    public override void GetField(IBindable data) {
        var binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyString;
        binding.Set(data, ValueField.Text);
        }



    }




public class GuigenFieldChooser : GuigenField {
    public IView View => ListView;


    public Entry ValueField;

    ListView ListView;
    Func<GuiBinding, object> BindingDelegate {get; }

    ISelectCollection SelectCollection;

    public GuigenFieldChooser(GuiChooser chooser) : base(chooser) {
        ListView = new ListView() {
            ItemTemplate = new DataTemplate(typeof(BoundViewCell))
            };

        }

    public override void SetField(IBindable data) {
        ListView.ItemsSource = SelectCollection;
        }

    public override void GetField(IBindable data) {
        }

    }


public class BoundViewCell : ViewCell {

    public BoundViewCell() {

        

        }
    }