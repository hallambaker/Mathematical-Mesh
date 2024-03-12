using Microsoft.Maui;

using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Guigen.Maui;

public class GuigenDetailSection : ContentPage, IPresentation, IWidget {
    ///<summary>The bound UI</summary> 
    public GuigenBinding Binding { get; }

    ///<summary>The main window.</summary> 
    public IMainWindow MainWindow => Binding.MainWindow;

    public Page Page => this;



    GuiSection Section { get; }
    Gui Gui => Binding.Gui;
    GuigenFieldSet FieldSet { get; }

    public GuigenDetailSection(GuigenBinding binding, GuiSection section) {
        Binding = binding;
        Section = section;

        section.Presentation = this;

        Title = section.Prompt;
        var stack = new VerticalStackLayout();
        HorizontalStackLayout buttonbar = null;

        //var label = new Label() {
        //    Text = section.Prompt,
        //    };

        //stack.Add(label);

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



        FieldSet = new GuigenFieldSet(Binding, section.Entries, stack, section.Binding);
        stack.Add (FieldSet.ButtonBox);

        Refresh();

        Content = stack;
        }


    IView AddButton(GuiButton button) {

        switch (button.Target) {

            case GuiSection section: {
                return new GuigenSectionButton (Binding, section).View;
                }
            case GuiAction action: {
                return new GuigenActionButton(Binding, action).View;
                }


            }
        throw new NotImplementedException();


        }

    public void Refresh() {
        FieldSet.SetFields(Section.Data);
        }
    }



public class GuigenActionButton : IWidget {
    ///<summary>The bound UI</summary> 
    public GuigenBinding Binding { get; }

    ///<summary>The main window.</summary> 
    public IMainWindow MainWindow => Binding.MainWindow;
    GuiAction Action { get; }

    ImageButton ImageButton { get; }
    Button TextButton { get; }
    Layout Stack { get; }

    public View View => Stack;
    public GuigenFieldSet FieldSet { get; init; }

    public GuigenActionButton(GuigenBinding binding, GuiAction action) {
        Binding = binding;
        Action = action;

        ImageButton = new ImageButton {
            Source = action.Icon.GetFilename(),
            WidthRequest = Binding.IconWidth ,
            HeightRequest = Binding.IconHeight ,
            };
        ImageButton.Clicked += OnClick;

        TextButton = new Button {
            Text = action.Prompt,
            HeightRequest = Binding.ButtonHeight
            };
        TextButton.Clicked += OnClick;

        Stack = new HorizontalStackLayout() { ImageButton, TextButton };
        }

    private void OnClick(object sender, EventArgs e) {
        if (Action.IsSelect) {
            Action.Callback(FieldSet.Data);

            return;
            }


        MainWindow.SetDetailWindow(Action);
        }


    }


public class GuigenSelectionButton : IWidget {
    public IMainWindow MainWindow { get; }
    GuigenBinding Binding => MainWindow.Binding;
    GuiAction Action { get; }

    Layout Stack { get; }

    ImageButton ImageButton { get; }
    Button TextButton { get; }
    IBindable Data { get; }
    public View View => Stack;
    public GuigenSelectionButton(IMainWindow mainWindow, GuiAction action, IBindable data) {
        MainWindow = mainWindow;
        Action = action;
        Data = data;

        ImageButton = new ImageButton {
            Source = action.Icon.GetFilename(),
            WidthRequest = Binding.IconWidth,
            HeightRequest = Binding.IconHeight,
            };
        ImageButton.Clicked += OnClick;

        TextButton = new Button {
            Text = action.Prompt,
            HeightRequest = Binding.ButtonHeight
            };
        TextButton.Clicked += OnClick;

        Stack = new HorizontalStackLayout() { ImageButton, TextButton };
        }


    private void OnClick(object sender, EventArgs e) {

        if (Action.IsSelect) {
            var x = Action.Callback(Data);
            x.Wait();
            Binding.SetResult(x.Result);
            return;
            }


        MainWindow.SetDetailWindow(Action);


        }
    }