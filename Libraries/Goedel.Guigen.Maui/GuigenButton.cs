using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                EventHandler? callback=null) {

        Binding = binding;

        TextButton = new Button {
            Text = text,
            //ImageSource = image,
            HeightRequest = Binding.ButtonHeight,

            };

        if (callback is not null) {
            TextButton.Clicked += callback;
            }

        if (icon is null) {
            View = TextButton;
            return;
            }

        ImageButton = new ImageButton {
            Source = icon.GetFilename(),
            WidthRequest = Binding.IconWidth,
            HeightRequest = Binding.IconHeight,
            };


        if (callback is not null) {
            ImageButton.Clicked += callback;
            }
        Stack = new HorizontalStackLayout() { ImageButton, TextButton };
        View = Stack;
        }



    public GuigenButton(
                GuigenBinding binding, GuiSection section, EventHandler callback) :
            this(binding, section.Icon, section.Prompt, callback) {
        Backing = section;
        //Reformat();
        }

    public void BindCallback(EventHandler callback) {
        if (TextButton is not null) {
            TextButton.Clicked += callback;
            }
        if (ImageButton is not null) {
            ImageButton.Clicked += callback;
            }
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


public class GuigenButtonDataAction : GuigenButton {

    GuiDataAction Action { get; }
    IBindable Data { get; }

    public GuigenButtonDataAction(GuigenBinding binding, IBindable data, GuiDataAction action) : 
                base (binding, action.Icon, action.Prompt) {
        BindCallback(OnAction);
        Action = action;
        Data = data;
        }

    public async void OnAction(object? sender, EventArgs e) {
        if (Action?.Callback is not null) {
            await Action.Callback(Action, Data);
            }


        }

    }


public class GuigenButton<T> : GuigenButton where T : IButtonTarget {

    T Data;
    Action<T> Action;

    public GuigenButton(GuigenBinding binding,
                T data,
                Action<T> callback) : base(binding, data.Icon, data.Prompt) {
        Data = data;
        Action = callback;
        BindCallback(OnClick);
        }

    private void OnClick(object sender, EventArgs e) {
        Action(Data);
        }

    }








