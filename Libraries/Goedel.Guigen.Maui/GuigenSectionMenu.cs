namespace Goedel.Guigen.Maui;

public class GuigenSectionMenu : ContentPage, IReformat, IWidget {

    public IMainWindow MainWindow { get; }

    public Page Page => ContentPage;
    ContentPage ContentPage;

    GuigenBinding Binding => MainWindow.Binding;
    Gui Gui => Binding.Gui;


    public GuigenSectionMenu(IMainWindow mainWindow) {
        MainWindow = mainWindow;

        var stack = new VerticalStackLayout();
        foreach (var section in Gui.Sections) {
            var button = new GuigenSectionButton(mainWindow, section);
            stack.Add(button.View);
            }

        // The content page
        ContentPage = new ContentPage() {
            Content = stack,
            Title = "Main"
            };
        }

    public void Reformat() {
        }


    }



public class GuigenSectionButton : IWidget {
    public IMainWindow MainWindow { get; }
    GuigenBinding Binding => MainWindow.Binding;
    GuiSection Section { get; }

    ImageButton ImageButton { get; }
    Button TextButton { get; }
    Layout Stack { get; }

    public View View => Stack;

    public GuigenSectionButton(IMainWindow mainWindow, GuiSection section) {
        MainWindow = mainWindow;
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


        //Text = section.Prompt;
        //ImageSource = section.Icon.GetFilename();
     
        //HeightRequest = Binding.IconHeight * 2;
        //VerticalOptions = new LayoutOptions(LayoutAlignment.Start, true);
        //ContentLayout = new ButtonContentLayout(ButtonContentLayout.ImagePosition.Left, 0);
        //Scale = 0.5;
        //WidthRequest = Binding.IconWidth * 2;



        }

    private void OnClick(object sender, EventArgs e) {
        MainWindow.SetDetailWindow(Section);
        }


    }



