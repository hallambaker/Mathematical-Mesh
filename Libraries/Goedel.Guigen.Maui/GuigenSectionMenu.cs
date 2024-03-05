using static System.Collections.Specialized.BitVector32;

namespace Goedel.Guigen.Maui;

public class GuigenSectionMenu : ContentPage, IReformat{

    GuigenBinding Binding { get; }
    Gui Gui => Binding.Gui;

    public Page Page => ContentPage;
    ContentPage ContentPage;

    //GuigenBinding Binding => MainWindow.Binding;

    Layout MenuLayout { get; set; }

    public GuigenSectionMenu(GuigenBinding binding) {
        Binding = binding;

        MenuLayout = binding.GetSectionMenuLayout();

        foreach (var section in Gui.Sections) {

            void callback(object sender, EventArgs e) { 
                Binding.GotoSection(section); 
                }

            var button = new GuigenButton(Binding, section, callback);
            MenuLayout.Add(button.View);
            }

        // The content page
        ContentPage = new ContentPage() {
            Content = MenuLayout,
            Title = "Main"
            };
        }

    public void Reformat() {
        }





    }



public class GuigenSectionButton {

    GuigenBinding Binding { get; }
    GuiSection Section { get; }

    ImageButton ImageButton { get; }
    Button TextButton { get; }
    Layout Stack { get; }

    public View View => Stack;

    public GuigenSectionButton(GuigenBinding binding, GuiSection section) {

        Binding = binding;
        Section = section;

        ImageButton = new ImageButton {
            Source = section.Icon.GetFilename(),
            WidthRequest = Binding.IconWidth ,
            HeightRequest = Binding.IconHeight,
            };
        ImageButton.Clicked += OnClick;

        TextButton = new Button {
            Text = section.Prompt,
            HeightRequest = Binding.ButtonHeight 
            };
        TextButton.Clicked += OnClick;

        Stack = new HorizontalStackLayout() { ImageButton , TextButton};


        }

    private void OnClick(object sender, EventArgs e) {
        //MainWindow.SetDetailWindow(Section);

        Binding.GotoSection(Section);
        }


    }



