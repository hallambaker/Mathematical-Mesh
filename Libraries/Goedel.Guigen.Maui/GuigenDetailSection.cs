namespace Goedel.Guigen.Maui;

public class GuigenDetailSection : ContentPage, IPresentation, IWidget {
    ///<summary>The bound UI</summary> 
    public GuigenBinding Binding { get; }

    ///<summary>The main window.</summary> 
    public IMainWindow MainWindow => Binding.MainWindow;

    public Page Page => this;



    GuiSection Section { get; }
    Gui Gui => Binding.Gui;
    public GuigenFieldSet FieldSet { get; }

    GuigenButton ButtonEdit { get; }
    GuigenButton ButtonUpdate { get; }

    Layout UpdateMenu { get; }

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

        switch (section.Binding) {
            case GuiBindingSingle singleBinding: {
                FieldSet = new GuigenFieldSetSectionSingle(Binding, singleBinding, Section.Data, guiSection: section);
                break;
                }
            case GuiBindingMultiple multipleBinding: {
                FieldSet = new GuigenFieldSetSectionMultiple(Binding, multipleBinding, guiSection: section, data: Section.Data);
                break;
                }
            }


        Content = FieldSet.View;
        }

    private void OnUpdate(object sender, EventArgs e) {

        }
    private void OnEdit(object sender, EventArgs e) {

        }

    IView AddButton(GuiButton button) {

        switch (button.Target) {

            case GuiSection section: {
                return new GuigenSectionButton(Binding, section).View;
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


    private async void OnClick(object sender, EventArgs e) {

        if (Action.IsSelect) {
            await Binding.PerformActionAsync(Action, Data);
            return;
            }
        MainWindow.SetDetailWindow(Action);
        }
    }

public class GuigenDataActionButton : IWidget {
    public IMainWindow MainWindow { get; }
    GuigenBinding Binding => MainWindow.Binding;
    GuiAction Action { get; }

    Layout Stack { get; }

    ImageButton ImageButton { get; }
    Button TextButton { get; }
    IBindable Data { get; }
    public View View => Stack;
    public GuigenDataActionButton(IMainWindow mainWindow, GuiAction action,
                    IBindable data) {
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


    private async void OnClick(object sender, EventArgs e) {

        if (Action.IsSelect) {
            await Binding.PerformActionAsync(Action, Data);
            return;
            }


        MainWindow.SetDetailWindow(Action, Data);


        }
    }