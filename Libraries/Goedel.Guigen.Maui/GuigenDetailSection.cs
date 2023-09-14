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



