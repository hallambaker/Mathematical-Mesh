﻿namespace Goedel.Guigen.Maui;

public class GuigenMainFlyout : IReformat, IMainWindow {

    public StyleSheet StyleSheet => StyleSheet.DefaultStyleSheet;
    public GuigenBinding Binding { get; }

    ///<summary>The Maui widget for this page (A FlyoutPage).</summary> 
    public Page Page => FlyoutPage;
    FlyoutPage FlyoutPage { get; }

    ContentPage ContentPage { get; }


    public GuigenFieldSet FieldSet { get; set; }

    ///<summary>The section menu.</summary> 
    public GuigenSectionMenu SectionMenu { get; }



    ///<summary>The current action.</summary> 
    GuiAction? CurrentAction { get; set; } = null;



    public Gui Gui => Binding.Gui;

    //public GuigenDetailAction CurrentActionOld { get; set; }

    public GuigenMainFlyout(GuigenBinding binding) {

        Binding = binding;
        binding.MainWindow = this; // Hack!!! Ugh!!!
        SectionMenu = new GuigenSectionMenu(Binding);

        ContentPage = new ContentPage();

        FlyoutPage = new FlyoutPage() {
            Title = "Fred",
            Flyout = SectionMenu.Page,
            Detail = ContentPage
            };

        GotoSection(Gui.DefaultSection);
        }

    public void GotoSection(GuiSection section) {
        Gui.CurrentSection = section;
        SetDetailWindow(section);
        }


    public void CompleteAction() {
        if (FieldSet.Return is not null) {
            FieldSet = FieldSet.Return;
            FieldSet.SetFields(FieldSet.Data);
            ContentPage.Content = FieldSet.View;
            return;
            }

        SetDetailWindow(Gui.CurrentSection);

        }


    public void Reformat() {
        //SectionMenu.Reformat();
        }

    public int GetDetailWidth() => (int)FlyoutPage.Window.Width;


    public void PresentActionDialog(
                    GuigenFieldSetAction guigenFieldSetAction) {
        }






    /// <summary>
    /// Event callback. Display the cached detail window associated with <paramref name="section"/>
    /// if it exists, otherwise create a new detail window.
    /// </summary>
    /// <param name="section"></param>
    public void SetDetailWindow(GuiSection section = null) {
        Gui.CurrentSection = section;
        SectionMenu.Reformat();

        if (section.Presentation is GuigenFieldSet fieldSet) { // Attempt to use cached field set.
            FieldSet = fieldSet;
            FieldSet.SetFields(section.Data);
            }
        else { // create new field set and cache.
            switch (section.Binding) {
                case GuiBindingSingle singleBinding: {
                    FieldSet = new GuigenFieldSetSectionSingle(Binding, singleBinding, section.Data, guiSection: section);
                    break;
                    }
                case GuiBindingMultiple multipleBinding: {
                    FieldSet = new GuigenFieldSetSectionMultiple(Binding, multipleBinding, guiSection: section, data: section.Data);
                    break;
                    }
                default: {
                    break;
                    }
                }
            section.Presentation = FieldSet;
            }

        // update the display
        ContentPage.Content = FieldSet.View;
        }



    /// <summary>
    /// Event callback. Display the  detail window associated with <paramref name="action"/>
    /// if it exists, otherwise create a new detail window.
    /// </summary>
    /// <param name="action">The action window to raise.</param>
    /// <param name="context"></param>
    public void SetDetailWindow(GuiAction action, IBindable context = null) {
        switch (action.Binding) {
            case GuiBindingSingle singleBinding: {
                FieldSet = new GuigenFieldSetActionSingle(Binding, action, FieldSet, context);
                break;
                }
            case GuiBindingMultiple multipleBinding: {
                FieldSet = new GuigenFieldSetActionMultiple(Binding, action, FieldSet, context);
                break;
                }
            case GuiBindingQr qrBinding: {
                FieldSet = new GuigenFieldSetQr(Binding, action, FieldSet, context);
                break;
                }
            }

        ContentPage.Content = FieldSet.View;
        }





    /// <summary>
    /// Event callback, MUST be called on the main display thread. Displays the result values
    /// held in <paramref name="result"/>. Since these vary from call to call, they are not cached.
    /// </summary>
    /// <param name="result">The result to present.</param>
    public void SetResultWindow(IResult result) {
        FieldSet = new GuigenFieldSetResult(Binding, result);
        ContentPage.Content = FieldSet.View;
        }


    public void SetEntryWindow(IBindable data, bool editMode = false) {
        FieldSet = new GuigenFieldSetEntry(Binding, data, editMode);
        ContentPage.Content = FieldSet.View;
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









