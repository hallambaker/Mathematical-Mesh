using static System.Collections.Specialized.BitVector32;

namespace Goedel.Guigen.Maui;





public class GuigenButton {
    GuigenBinding Binding { get; }
    public View View { get; }
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

        TextButton = new Button {
            Text = text,
            //ImageSource = image,
            HeightRequest = Binding.ButtonHeight,

            };
        TextButton.Clicked += callback;

        if (icon is null) {
            View = TextButton;
            return;
            }

        ImageButton = new ImageButton {
            Source = icon.GetFilename(),
            WidthRequest = Binding.IconWidth,
            HeightRequest = Binding.IconHeight,
            };
        ImageButton.Clicked += callback;

        Stack = new HorizontalStackLayout() { ImageButton, TextButton };
        View = Stack;
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
        if (TextButton != null) {
            Binding.SetState(state, TextButton);
            }
        if (ImageButton != null) {
            Binding.SetState(state, ImageButton);
            }
        }


    }









