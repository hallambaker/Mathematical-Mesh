namespace Goedel.Guigen.Maui;

public class GuigenDetailAction : ContentPage, IPresentation {

    public Button ConfirmButton;
    public Button CancelButton;

    public List<View> ActionViews = new();


    IMainWindow MainWindow { get; }
    GuigenBinding Binding => MainWindow.Binding;

    public Page Page => this;


    GuiAction Action { get; }
    Gui Gui => Binding.Gui;

    //List<GuigenField> Fields = new();

    IBindable BoundValue;
    FieldSet FieldSet { get; }

    public GuigenDetailAction(IMainWindow mainWindow, GuiAction action) {

        MainWindow = mainWindow;
        Action = action;

        BoundValue = action.Factory();

        action.Presentation = this;

        Title = action.Prompt;

        var stack = new VerticalStackLayout();

        var label = new Label() {
            Text = action.Prompt,
            };
        stack.Add(label);

        FieldSet = new FieldSet(action.Entries, stack);

        var view = new HorizontalStackLayout();

        ConfirmButton = new Button() {
            Text = "Accept"
            };
        ConfirmButton.Clicked += OnClickConfirm;

        CancelButton = new Button() {
            Text = "Cancel",
            };
        CancelButton.Clicked += OnClickCancel;

        ActionViews.Add(ConfirmButton);
        ActionViews.Add(CancelButton);

        EnableActions();

        view.Add(ConfirmButton);
        view.Add(CancelButton);
        stack.Add(view);

        Content = stack;
        }

    private void OnClickCancel(object sender, EventArgs e) {
        MainWindow.SetDetailWindow();
        }

    private void OnClickConfirm(object sender, EventArgs e) {
        var result = Action.Factory();
        FieldSet.GetFields(result);



        if (Action.Callback != null) {
            DisableActions();

            var task = Action.Callback(result, ActionMode.Execute);

            // here we need to lock the UI to prevent further actions until it returns, except for the cancel command.
            //task.Wait();

            task.ContinueWith(Continue, null);
            }


        }

    public Task<IResult> Continue(Task<IResult> task, object? fred) {
        MainThread.BeginInvokeOnMainThread(() => {
            EnableActions();
            MainWindow.SetDetailWindow();
            });
        return task;
        }


    public void DisableActions() {
        foreach (var action in ActionViews) {
            if (action != null) {
                action.IsEnabled = false;
                MainWindow.FormatView(action);
                }
            }
        }

    public void EnableActions() {
        foreach (var action in ActionViews) {
            if (action != null) {
                action.IsEnabled = true;
                MainWindow.FormatView(action);
                }
            }
        }


    public void Refresh() {
        }
    }






