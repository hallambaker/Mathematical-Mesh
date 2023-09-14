﻿using System;
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



public class GuigenBinding(Gui gui, DisplayMode display = DisplayMode.Default) {
    public Gui Gui { get; } = gui;
    public DisplayMode DisplayMode { get; } = display;


    public int IconHeight = 20;
    public int IconWidth = 20;
    public Page GetMain() {
        return new GuigenMainFlyout(this).Page;
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

    Gui Gui => Binding.Gui;

    public GuigenMainFlyout(GuigenBinding binding) {
        Binding = binding;
        SectionMenu = new GuigenSectionMenu(this);

        FlyoutPage = new FlyoutPage() {
            Title = "Fred",
            Flyout = SectionMenu.Page
            };

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
            FlyoutPage.Detail = new GuigenDetailSection(this, section).Page;
            return;
            }

        // Call refresh only if the window is newly created.
        detail.Refresh();
        FlyoutPage.Detail = detail;
        }

    /// <summary>
    /// Event callback. Display the  detail window associated with <paramref name="action"/>
    /// if it exists, otherwise create a new detail window.
    /// </summary>
    /// <param name="action">The action window to raise.</param>
    public void SetDetailWindow(GuiAction action) {
        if (action.Presentation is not GuigenDetailSection detail) {
            FlyoutPage.Detail = new GuigenDetailAction(this, action).Page;
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

    public void FormatFieldEntry(View view) {
        }

    public void FormatFeedback(Label view) {
        view.TextColor = Colors.Red;
        }

    public void DisableView(View view) {
        throw new NotImplementedException();
        }
    }









