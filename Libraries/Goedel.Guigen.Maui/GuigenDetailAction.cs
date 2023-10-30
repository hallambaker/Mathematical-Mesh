namespace Goedel.Guigen.Maui;


public class GuigenDetaiPage : ContentPage, IPresentation {
    protected IMainWindow MainWindow { get; }

    protected GuigenBinding Binding => MainWindow.Binding;
    protected Gui Gui => Binding.Gui;

    public Page Page => this;

    public GuigenDetaiPage(IMainWindow mainWindow) {
        MainWindow = mainWindow;
        }
    }


/// <summary>
/// Extension of a ContentPage to allow binding of the action data to the instance.
/// </summary>
public class GuigenDetailAction : GuigenDetaiPage {
    GuiAction Action { get; }

    IBindable BoundValue;

    public Button ConfirmButton;
    public Button CancelButton;

    public List<View> ActionViews = new();

    GuigenFieldSet FieldSet { get; }

    IParameter Result { get; set; }
    Gui Gui { get; }

    public GuigenDetailAction(IMainWindow mainWindow, GuiAction action) : base (mainWindow) {
        Action = action;
        Gui = mainWindow.Binding.Gui;

        action.Presentation = this;

        Title = action.Prompt;

        var stack = new VerticalStackLayout();

        var label = new Label() {
            Text = action.Prompt,
            };
        stack.Add(label);

        FieldSet = new GuigenFieldSet(MainWindow, action.Entries, stack);

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

        Result = Action.Factory() as IParameter;
        Result.Initialize(Gui);

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
        var result = Action.Factory() as IParameter;


        FieldSet.GetFields(result);

        var verify = result.Validate(Gui);

        switch (verify) {
            case ValidResult: {
                if (Action.Callback != null) {
                    DisableActions();

                    var task = Action.Callback(result, ActionMode.Execute);
                    task.ContinueWith(Continue, null);
                    }
                break;
                }
            case GuiResultInvalid invalid: {
                // here we report back the failures.
                FieldSet.Feedback(invalid);
                break;
                }
            }
        }

    public Task<IResult> Continue(Task<IResult> task, object? fred) {

        // Check here to see if there is a result value!
        var result = task.Result;

        switch (result) {
            case CompletedResult: {
                MainThread.BeginInvokeOnMainThread(() => {
                    EnableActions();
                    MainWindow.SetDetailWindow();
                });
                break;
                }
            default: {
                MainThread.BeginInvokeOnMainThread(() => {
                    MainWindow.SetResultWindow(result);
                });
                break;
                }
        }
        return task;
        }


    public void DisableActions() {
        foreach (var action in ActionViews) {
            if (action != null) {
                action.IsEnabled = false;
                MainWindow.FormatAction(action);
                }
            }
        }

    public void EnableActions() {
        foreach (var action in ActionViews) {
            if (action != null) {
                action.IsEnabled = true;
                MainWindow.FormatAction(action);
                }
            }
        }


    public void Refresh() {
        }
    }
