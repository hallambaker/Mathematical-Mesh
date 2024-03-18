using static System.Collections.Specialized.BitVector32;

namespace Goedel.Guigen.Maui;

public class GuigenButton {
    GuigenBinding Binding { get; }
    public View View => Stack;
    Layout Stack { get; }
    ImageButton ImageButton { get; }
    Button TextButton { get; }

    IGetState Backing;

    public bool IsVisible {
        get => ImageButton.IsVisible;
        set {
            ImageButton.IsVisible = value;
            TextButton.IsVisible = value;
            } 
        }

    public GuigenButton(
                GuigenBinding binding,
                string icon,
                string text,
                EventHandler callback) {

        Binding = binding;

        ImageButton = new ImageButton {
            Source = icon.GetFilename(),
            WidthRequest = Binding.IconWidth,
            HeightRequest = Binding.IconHeight,
            };
        ImageButton.Clicked += callback;
        //var file = icon.GetFilename();
        //var image = new FileImageSource() {
        //    //File = icon.GetFilename(),
           
        //    //WidthRequest = Binding.IconWidth,
        //    //HeightRequest = Binding.IconHeight,
        //    };


        TextButton = new Button {
            Text = text,
            //ImageSource = image,
            HeightRequest = Binding.ButtonHeight,
            
            };
        TextButton.Clicked += callback;

        Stack = new HorizontalStackLayout() { ImageButton, TextButton };
        }


    public GuigenButton(
                GuigenBinding binding, GuiSection section, EventHandler callback) :
            this(binding, section.Icon, section.Prompt, callback) {
        Backing = section;
        //Reformat();
        }

    public void Reformat() {
        if (Backing != null) {
            var state = Backing.GetButton();
            SetState(state);
            }
        }


    public void SetState (ButtonState state) {
        Binding.SetState(state, ImageButton);
        Binding.SetState(state, TextButton);
        }


    }









