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

    public Color BorderColor = Colors.Purple;
    public Color ColorSelected = Colors.Purple;
    public Color ColorEnabled = Colors.White;
    public Color ColorInactive = Colors.Grey;
    public Color TextSelected = Colors.White;
    public Color TextEnabled = Colors.White;
    public Color TextInactive = Colors.Grey;

    public Page Page => MainWindow.Page;

    public IMainWindow MainWindow { get; set; }




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


    public void SetState(ButtonState state, ImageButton imageButton) {
        switch (state) {
            case ButtonState.Enabled: {
                imageButton.IsEnabled = true;
                imageButton.BorderColor = BorderColor;
                imageButton.BackgroundColor = ColorSelected;
                break;
                }
            case ButtonState.Selected: {
                imageButton.IsEnabled = false;
                imageButton.BorderColor = BorderColor;
                imageButton.BackgroundColor = ColorSelected;
                break;
                }
            case ButtonState.Disabled: {
                imageButton.IsEnabled = false;
                imageButton.BorderColor = ColorInactive;
                imageButton.BackgroundColor = ColorInactive;
                break;
                }
            }
        }

    public void SetState(ButtonState state, Button imageButton) {
        switch (state) {
            case ButtonState.Enabled: {
                imageButton.IsEnabled = true;
                imageButton.BorderColor = BorderColor;
                imageButton.BackgroundColor = ColorSelected;
                imageButton.TextColor = TextEnabled;
                break;
                }
            case ButtonState.Selected: {
                imageButton.IsEnabled = false;
                imageButton.BorderColor = BorderColor;
                imageButton.BackgroundColor = ColorSelected;
                imageButton.TextColor = TextSelected;
                break;
                }
            case ButtonState.Disabled: {
                imageButton.IsEnabled = false;
                imageButton.BorderColor = ColorInactive;
                imageButton.BackgroundColor = ColorInactive;
                imageButton.TextColor = ColorInactive;
                break;
                }
            }
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
                EventHandler callback) => new GuigenButton(this, icon, text, callback);


    public Entry GetEntry() => new();

    public Editor GetEditor() => new() {
        AutoSize = EditorAutoSizeOption.TextChanges,
        IsSpellCheckEnabled = true,
        IsTextPredictionEnabled = false,
        Keyboard = Keyboard.Text,
        Placeholder = "Infinite monkeys with typewriters say"
        };

    public Label GetFeedback() => new() {
        IsVisible = false
        };
    public Label GetLabel() => new();

    public Label GetPrompt(string? prompt = null) => new() {
        Text = prompt
        };
    public CheckBox GetCheckBox() => new();


    /// <summary>
    /// Return a button whose callback either causes the section to change or initiates
    /// an action interaction.
    /// </summary>
    /// <param name="buttonTarget">The button target</param>
    /// <returns>The created button</returns>
    /// <exception cref="NYI"></exception>
    public GuigenButton GetButton(IButtonTarget buttonTarget) =>
        buttonTarget switch {
            GuiAction action => new GuigenButton<GuiAction>(this, action, OnActionClick),
            GuiSection section => new GuigenButton<GuiSection>(this, section, OnSectionClick),
            _ => throw new NotImplementedException()
            };

    private void OnActionClick(GuiAction action) {
        Gui.CurrentAction = action;

        if (!action.IsConfirmation) {
            // Action does not require parameters, it runs automatically
            }
        else {
            MainWindow.SetDetailWindow(action);
            }


        }

    private void OnSectionClick(GuiSection section) =>
                GotoSection (section);
     


    public void GotoSection(GuiSection section) {
        Gui.CurrentSection = section;
        MainWindow.SetDetailWindow(section);
        }

    /// <summary>
    /// Dispatch the action <paramref name="action"/> on  data <paramref name="data"/>.
    /// All action callback dispatch should be directed through here after the parameters 
    /// are fully assembled and validated.
    /// <para>
    /// If the action completes normally, the results are presented. Otherwise the exception 
    /// result is presented.
    /// </para>
    /// </summary>
    /// <param name="action">The action to perform.</param>
    /// <param name="data">The data parameters.</param>
    /// <returns>Task descriptor.</returns>
    public async Task BeginTask(GuiAction action, IBindable data) {

        try {
            var result = await action.Callback(data);
            SetResult(result);
            }
        catch (Exception e) {
            }
        }



    public void MakeSelection(IBindable Data) {
        }



    /*  The new way to handle everything */
    public void PushActionDialog() {
        }

    public void CancelActionDialog() {
        }


    public void AttemptActionCallback() {
        }






    public void BeginAction(GuiAction action, IBindable data) {
        // Do we need parameters for this action?

        // No, just begin the task.
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









