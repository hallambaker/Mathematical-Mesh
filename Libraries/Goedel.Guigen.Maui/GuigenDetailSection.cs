using static System.Collections.Specialized.BitVector32;

namespace Goedel.Guigen.Maui;

public class GuigenDetailSection : ContentPage, IPresentation, IWidget {
    public IMainWindow MainWindow { get; }
    GuigenBinding Binding => MainWindow.Binding;

    public Page Page => this;



    GuiSection Section { get; }
    Gui Gui => Binding.Gui;
    GuigenFieldSet FieldSet { get; }

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



        FieldSet = new GuigenFieldSet(MainWindow, section.Entries, stack);

        FieldSet.SetFields(section.Data);

        Content = stack;
        }


    IView AddButton(GuiButton button) {

        switch (button.Target) {

            case GuiSection section: {
                return new GuigenSectionButton (MainWindow, section).View;
                }
            case GuiAction action: {
                return new GuigenActionButton(MainWindow, action).View;
                }


            }
        throw new NotImplementedException();


        }

    public void Refresh() {
        }
    }



public class GuigenActionButton : IWidget {
    public IMainWindow MainWindow { get; }
    GuigenBinding Binding => MainWindow.Binding;
    GuiAction Action { get; }

    ImageButton ImageButton { get; }
    Button TextButton { get; }
    Layout Stack { get; }

    public View View => Stack;


    public GuigenActionButton(IMainWindow mainWindow, GuiAction action) {
        MainWindow = mainWindow;
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

        //Text = action.Prompt;
        //ImageSource = action.Icon.GetFilename();
        //HeightRequest = Binding.IconHeight * 2;

        //Clicked += OnClick;

        }

    private void OnClick(object sender, EventArgs e) {
        MainWindow.SetDetailWindow(Action);
        }


    }



