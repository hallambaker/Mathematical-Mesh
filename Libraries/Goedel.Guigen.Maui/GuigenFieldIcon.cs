﻿using static System.Net.Mime.MediaTypeNames;

namespace Goedel.Guigen.Maui;

public class GuigenFieldIcon : GuigenField, IWidget {


    GuiBoundPropertyIcon TypedBinding => Binding as GuiBoundPropertyIcon;



    public GuigenFieldIcon(IMainWindow mainWindow,
                GuigenFieldSet fieldsSet,
                GuiBoundPropertyIcon binding) : base(mainWindow, binding) {

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





