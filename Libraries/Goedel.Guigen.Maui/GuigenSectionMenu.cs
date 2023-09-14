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



public class GuigenSectionButton : Button, IWidget {
    public IMainWindow MainWindow { get; }
    GuigenBinding Binding => MainWindow.Binding;
    GuiSection Section { get; }


    public View View => this;

    public GuigenSectionButton(IMainWindow mainWindow, GuiSection section) {
        MainWindow = mainWindow;
        Section = section;

        Text = section.Prompt;
        ImageSource = section.Icon.GetFilename();
        HeightRequest = Binding.IconHeight * 2;

        Clicked += OnClick;

        }

    private void OnClick(object sender, EventArgs e) {
        MainWindow.SetDetailWindow(Section);
        }


    }



