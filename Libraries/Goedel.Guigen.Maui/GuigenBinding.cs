using System.Security.Cryptography.X509Certificates;

using static System.Collections.Specialized.BitVector32;

namespace Goedel.Guigen.Maui;


/// <summary>
/// The display modes for the gui.
/// </summary>
public enum DisplayMode {

    ///<summary>Platform default, Mobile for IOS and Android, Desktop for everything else.</summary> 
    Default,

    ///<summary>Desktop mode, assume larger screen</summary> 
    Desktop,

    ///<summary>Mobile mode, use compact displays.</summary> 
    Mobile

    }


public interface IGuigenMain {
    }


public interface IReformat{

    void Reformat() {
        }

    }


public interface IMainWindow {
    GuigenBinding Binding { get; }

    public void SetDetailWindow(GuiSection section);

    }



public class GuigenBinding(Gui gui, DisplayMode display = DisplayMode.Default) {
    public Gui Gui { get; } = gui;
    public DisplayMode DisplayMode { get; } = display;


    public int IconHeight = 20;
    public int IconWidth = 20;
    public Page GetMain() {
        return new GuigenMainFlyout(this);
        }


    }






public class GuigenMainFlyout : FlyoutPage, IReformat, IMainWindow {
    public GuigenBinding Binding { get; }
    Gui Gui => Binding.Gui;

    public GuigenMainFlyout(GuigenBinding binding) {
        Binding = binding;
        Title = "Fred";

        Flyout = new GuigenSectionMenu(this);
        Detail = new GuigenDetailPane(this, Gui.DefaultSection);
        }

    /// <summary>
    /// Event callback. Display the cached detail window associated with <paramref name="section"/>
    /// if it exists, otherwise create a new detail window.
    /// </summary>
    /// <param name="section"></param>
    public void SetDetailWindow(GuiSection section) {
        var detail = section.Presentation as GuigenDetailPane;

        if (detail is null) {
            Detail = new GuigenDetailPane(this, section);
            return;
            }

        // Call refresh only if the window is newly created.
        detail.Refresh();
        Detail = detail;
        }

    }



public class GuigenSectionMenu : ContentPage, IReformat {

    IMainWindow MainWindow { get; }

    GuigenBinding Binding => MainWindow.Binding;
    Gui Gui => Binding.Gui;

    List<VisualElement> Items = new();

    public GuigenSectionMenu(IMainWindow mainWindow) {
        MainWindow = mainWindow;
        Title = "Fred";

        var count = 0;
        var stack = new VerticalStackLayout();
        foreach (var section in Gui.Sections) {
            var button = new GuigenSectionButton(mainWindow, section);
            stack.Add(button);
            }

        Content = stack;

        }

    public void Reformat() {
        }


    }


public class GuigenSectionButton : Button {
    IMainWindow MainWindow { get; }
    GuigenBinding Binding => MainWindow.Binding;
    GuiSection Section { get; }

    public GuigenSectionButton(IMainWindow mainWindow, GuiSection section) {
        MainWindow = mainWindow;
        Section = section;

        Text = section.Prompt;
        ImageSource = section.Icon.GetFilename();
        HeightRequest = Binding.IconHeight*2;

        Clicked += OnClick;

        }

    private void OnClick(object sender, EventArgs e) {
        MainWindow.SetDetailWindow(Section);
        }


    }




public class GuigenDetailPane : ContentPage, IPresentation {
    IMainWindow MainWindow { get; }
    GuigenBinding Binding => MainWindow.Binding;

    GuiSection Section { get; }
    Gui Gui => Binding.Gui;


    public GuigenDetailPane(IMainWindow mainWindow, GuiSection section) {
        MainWindow = mainWindow;
        Section = section;

        section.Presentation = this;

        Title = section.Prompt;
        var stack = new VerticalStackLayout();

        var label = new Label() {
            Text = section.Prompt,
            };

        stack.Add(label);

        Content = stack;
        }

    public void Refresh() {
        }
    }

