using System;
using System.Security.Cryptography.X509Certificates;

using static System.Collections.Specialized.BitVector32;

namespace Goedel.Guigen.Maui;



public record StyleSheet {

    public Color TextColor;
    public Color InactiveTextColor;
    public Color BorderColor;
    public Color BackgroundColor;
    public Color HighlightColor = Colors.Purple;

    public static StyleSheet DefaultStyleSheet => TestStyleSheet;

    public static StyleSheet TestStyleSheet { get; } =
        new StyleSheet() {
            TextColor = Colors.DarkGreen,
            InactiveTextColor = Colors.DarkRed,
            BorderColor = Colors.Black,
            BackgroundColor = Colors.White,
            };


    public static StyleSheet MonochromeStyleSheet { get; } = 
            new StyleSheet() {
                TextColor = Colors.Black,
                InactiveTextColor = Colors.Grey,
                BorderColor = Colors.Black,
                BackgroundColor = Colors.White,
                };

    public static StyleSheet DarkStyleSheet { get; } =
        new StyleSheet() {
            TextColor = Colors.White,
            InactiveTextColor = Colors.Grey,
            BorderColor = Colors.White,
            BackgroundColor = Colors.Black,
            };

    }


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

    public StyleSheet StyleSheet { get; }

    public void SetDetailWindow(GuiSection section = null);

    public void SetDetailWindow(GuiAction action);

    /// <summary>
    /// Method called to style <paramref name="view"/> according to the current stylesheet
    /// and the activation state.
    /// </summary>
    /// <param name="view">The button or other interface element to format.</param>
    public void FormatView(View view);



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

    public StyleSheet StyleSheet => StyleSheet.DefaultStyleSheet;
    public GuigenBinding Binding { get; }


    GuiSection CurrentSection { get; set; }


    public Page Page => this;
    Gui Gui => Binding.Gui;

    public GuigenMainFlyout(GuigenBinding binding) {
        Binding = binding;
        Title = "Fred";

        Flyout = new GuigenSectionMenu(this).Page;
        SetDetailWindow(Gui.DefaultSection);
        }

    /// <summary>
    /// Event callback. Display the cached detail window associated with <paramref name="section"/>
    /// if it exists, otherwise create a new detail window.
    /// </summary>
    /// <param name="section"></param>
    public void SetDetailWindow(GuiSection section = null) {
        section ??= CurrentSection;

        CurrentSection = section;

        if (section.Presentation is not GuigenDetailSection detail) {
            Detail = new GuigenDetailSection(this, section).Page;
            return;
            }

        // Call refresh only if the window is newly created.
        detail.Refresh();
        Detail = detail;
        }

    /// <summary>
    /// Event callback. Display the  detail window associated with <paramref name="action"/>
    /// if it exists, otherwise create a new detail window.
    /// </summary>
    /// <param name="action">The action window to raise.</param>
    public void SetDetailWindow(GuiAction action) {
        if (action.Presentation is not GuigenDetailSection detail) {
            Detail = new GuigenDetailAction(this, action).Page;
            return;
            }

        // Call refresh only if the window is newly created.
        detail.Refresh();
        Detail = detail;
        }

    public void FormatView(View view) {
        switch (view) {
            case Button button: {
                button.BackgroundColor = StyleSheet.BackgroundColor;
                button.BorderColor = StyleSheet.BorderColor;
                button.TextColor = button.IsEnabled ? StyleSheet.TextColor : StyleSheet.InactiveTextColor;
                break;
                }
            }


        }

    public void DisableView(View view) {
        throw new NotImplementedException();
        }
    }



public class GuigenSectionMenu : ContentPage, IReformat {

    IMainWindow MainWindow { get; }

    GuigenBinding Binding => MainWindow.Binding;
    Gui Gui => Binding.Gui;

    List<VisualElement> Items = new();

    public Page Page => this;

    public GuigenSectionMenu(IMainWindow mainWindow) {
        MainWindow = mainWindow;
        Title = "Main";

        var stack = new VerticalStackLayout();
        foreach (var section in Gui.Sections) {
            var button = new GuigenSectionButton(mainWindow, section);
            stack.Add(button.View);
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


    public View View => this;

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

public class GuigenActionButton : Button {
    IMainWindow MainWindow { get; }
    GuigenBinding Binding => MainWindow.Binding;
    GuiAction Action { get; }

    public GuigenActionButton(IMainWindow mainWindow, GuiAction action) {
        MainWindow = mainWindow;
        Action = action;

        Text = action.Prompt;
        ImageSource = action.Icon.GetFilename();
        HeightRequest = Binding.IconHeight * 2;

        Clicked += OnClick;

        }

    private void OnClick(object sender, EventArgs e) {
        MainWindow.SetDetailWindow(Action);
        }


    }


public class GuigenDetailSection : ContentPage, IPresentation {
    IMainWindow MainWindow { get; }
    GuigenBinding Binding => MainWindow.Binding;

    public Page Page => this;



    GuiSection Section { get; }
    Gui Gui => Binding.Gui;
    FieldSet FieldSet { get; }

    public GuigenDetailSection(IMainWindow mainWindow, GuiSection section) {
        MainWindow = mainWindow;
        Section = section;

        section.Presentation = this;

        Title = section.Prompt;
        var stack = new VerticalStackLayout();
        HorizontalStackLayout buttonbar = null;

        var label = new Label() {
            Text = section.Prompt,
            };

        stack.Add(label);

        foreach (var entry in section.Entries) {
            switch (entry) {
                case GuiButton button: {
                    buttonbar ??= new HorizontalStackLayout();
                    buttonbar.Add(AddButton(button));
                    break;
                    }
                }
            }
        if (buttonbar != null) {
            stack.Add(buttonbar);
            }



        FieldSet = new FieldSet(section.Entries, stack);

        FieldSet.SetFields(section.Data);

        Content = stack;
        }


    IView AddButton(GuiButton button) {

        switch (button.Target) {

            case GuiSection section: {
                return new GuigenSectionButton (MainWindow, section);
                }
            case GuiAction action: {
                return new GuigenActionButton(MainWindow, action);
                }


            }
        throw new NotImplementedException();


        }

    public void Refresh() {
        }
    }






