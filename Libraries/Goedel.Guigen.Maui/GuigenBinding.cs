using Goedel.Utilities;

using Microsoft.Maui;

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

public interface IReformat{

    void Reformat() {
        }

    }


public record BoundFieldSet (
            GuiFieldSet FieldSet,
            IBindable   Data){

    }


public class GuigenBinding {
    public Gui Gui { get; }

    public DisplayMode Display { get; set; }

    public int IconHeight = 20;
    public int IconWidth = 20;

    public int ListIconHeight = 10;
    public int ListIconWidth = 10;

    public int ButtonHeight = 30;

    public Page Page =>MainWindow.Page;

    public IMainWindow MainWindow { get; set; }

    public GuiSection CurrentSection { get; set; }


    //IMainWindow MainWindow => GuigenMainFlyout;
    public IDispatcher Dispatcher => Page.Dispatcher;

    public GuigenBinding(Gui gui) {
        Gui = gui;

        // Can't use this because it isn't supported on Windows.
        //OnDisplayChanged(null, null);
        //DeviceDisplay.MainDisplayInfoChanged += OnDisplayChanged;

        Display = DisplayMode.Mobile;
        if (DeviceInfo.Current.Idiom == DeviceIdiom.Desktop) {
            Display = DisplayMode.Desktop;
            }

        //Display = DisplayMode.Mobile;
        }



    /// <summary>
    /// Event is called to reset the display parameters when the display characteristics change.
    /// The arguments are ignored.
    /// </summary>
    /// <param name="sender">Sender, always this class, ignored.</param>
    /// <param name="args">Arguments, always report the DeviceDisplay.Current.MainDisplayInfo</param>
    private void OnDisplayChanged(object? sender, DisplayInfoChangedEventArgs args) {
        var displayInfo = DeviceDisplay.Current.MainDisplayInfo;



        }



    public GuigenButton MakeButton(
                string icon,
                string text,
                EventHandler callback) => new GuigenButton (this, icon, text, callback);






    public void GotoSection(GuiSection section) {
        CurrentSection = section;
        MainWindow.SetDetailWindow(section);

        }

    public void MakeSelection(IBindable Data) {
        }

    public void BeginAction(GuiAction action, IBindable data) {
        // Do we need parameters for this action?

        // No, just begin the task.
        }

    public async Task BeginTask(GuiAction action, IBindable data) {

        try {
            await action.Callback(data);
            }
        catch (Exception e) {
            }
        }

    public void CancelTask () { 
        }

    public void EndAction(IResult result) {
        // Is there a message to display


        // return to the previous state

        }





    public Layout GetSectionMenuLayout() => Display switch {
        DisplayMode.Desktop => new VerticalStackLayout(),
        _ => new FlexLayout() {
            Wrap = FlexWrap.Wrap,
            JustifyContent = FlexJustify.Start
            }
        };






    public Page GetMain() {

        //MainWindow = new GuigenDesktop(this);


        MainWindow = new GuigenMainFlyout(this);

        return Page;
        }


    public string Resolve(ResourceId resourceId) =>
        resourceId?.GetString();

    public string Resolve(string resourceId) =>
        ResourceResolver.GetString(resourceId);



    public void SetResult(IResult result) {

        if (result.ReturnResult == ReturnResult.Home) {
            GotoSection(Gui.DefaultSection);
            }

        }

    }



public class GuigenButton {
    GuigenBinding Binding { get; }
    public View View => Stack;
    Layout Stack { get; }
    ImageButton ImageButton { get; }
    Button TextButton { get; }

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

        TextButton = new Button {
            Text = text,
            HeightRequest = Binding.ButtonHeight
            };
        TextButton.Clicked += callback;

        Stack = new HorizontalStackLayout() { ImageButton, TextButton };
        }


    public GuigenButton(
                GuigenBinding binding, GuiSection section, EventHandler callback) :
            this(binding, section.Icon, section.Prompt, callback) {
        }

    public void SetState (ButtonState state) {
        switch (state) {
            case ButtonState.Enabled: {
                ImageButton.IsEnabled = true;
                TextButton.IsEnabled = true;
                break;
                }
            case ButtonState.Active: {
                ImageButton.IsEnabled = false; 
                TextButton.IsEnabled = false;
                break;
                }
            case ButtonState.Disabled: {
                ImageButton.IsEnabled = false;
                TextButton.IsEnabled = false;
                break;
                }
            }

        }


    }



public class GuigenMainFlyout : IReformat, IMainWindow {
    
    public StyleSheet StyleSheet => StyleSheet.DefaultStyleSheet;
    public GuigenBinding Binding { get; }

    ///<summary>The Maui widget for this page (A FlyoutPage).</summary> 
    public Page Page => FlyoutPage;
    FlyoutPage FlyoutPage { get; }
    ///<summary>The section menu.</summary> 
    public GuigenSectionMenu SectionMenu { get; }

    ///<summary>The current section.</summary> 
    GuiSection CurrentSection { get; set; }

    public Gui Gui => Binding.Gui;

    public GuigenDetailAction CurrentAction { get; set; }

    public GuigenMainFlyout(GuigenBinding binding) {

        Binding = binding;
        binding.MainWindow = this; // Hack!!! Ugh!!!
        SectionMenu = new GuigenSectionMenu(Binding);



        FlyoutPage = new FlyoutPage() {
            Title = "Fred",
            Flyout = SectionMenu.Page
            };

        Binding.GotoSection(Gui.DefaultSection);


        }

    public int GetDetailWidth() => (int) FlyoutPage.Window.Width;


    /// <summary>
    /// Event callback. Display the cached detail window associated with <paramref name="section"/>
    /// if it exists, otherwise create a new detail window.
    /// </summary>
    /// <param name="section"></param>
    public void SetDetailWindow(GuiSection section = null) {
        if (CurrentAction != null) {
            CurrentAction.TearDown();
            }

        section ??= CurrentSection;

        CurrentSection = section;

        // Do we have this presentation cached?
        if (section.Presentation is not GuigenDetailSection detail) {
            FlyoutPage.Detail = new GuigenDetailSection(this.Binding, section).Page;
            return;
            }

        detail.Refresh();
        FlyoutPage.Detail = detail;
        }







    /// <summary>
    /// Event callback, MUST be called on the main display thread. Displays the result values
    /// held in <paramref name="result"/>. Since these vary from call to call, they are not cached.
    /// </summary>
    /// <param name="result">The result to present.</param>
    public void SetResultWindow(IResult result) {
        FlyoutPage.Detail = new GuigenDetailResult(this.Binding, result);
        }



    /// <summary>
    /// Event callback. Display the  detail window associated with <paramref name="action"/>
    /// if it exists, otherwise create a new detail window.
    /// </summary>
    /// <param name="action">The action window to raise.</param>
    public void SetDetailWindow(GuiAction action) {
        if (action.Presentation is not GuigenDetailSection detail) {
            FlyoutPage.Detail = new GuigenDetailAction(this.Binding, action).Page;
            return;
            }

        // Call refresh only if the window is newly created.
        detail.Refresh();
        FlyoutPage.Detail = detail;
        }

    public void FormatAction(View view) {
        switch (view) {
            case Button button: {
                button.BackgroundColor = StyleSheet.BackgroundColor;
                button.BorderColor = StyleSheet.BorderColor;
                button.TextColor = button.IsEnabled ? StyleSheet.TextColor : StyleSheet.InactiveTextColor;
                break;
                }
            }
        }


    public void FormatFieldLabel(Label view) {
        view.WidthRequest = 150;
        }

    public void FormatFieldEntry(View view, GuiBoundProperty boundProperty) {
        }

    public void FormatFeedback(Label view) {
        view.TextColor = Colors.Red;
        }

    public void DisableView(View view) {
        throw new NotImplementedException();
        }


    }









