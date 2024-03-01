using Microsoft.Maui.Controls.Compatibility.Platform.UWP;

using static System.Collections.Specialized.BitVector32;

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
    //Gui Gui { get; }

    public GuigenDetailAction(IMainWindow mainWindow, GuiAction action) : base (mainWindow) {
        mainWindow.CurrentAction = this;

        Action = action;



        action.Presentation = this;

        Title = action.Prompt;

        var stack = new VerticalStackLayout();

        var label = new Label() {
            Text = action.Prompt,
        };
        stack.Add(label);

        FieldSet = new GuigenFieldSet(MainWindow, action.Entries, stack, action.Binding);

        var view = new HorizontalStackLayout();

        if (FieldSet.IsChooser) {
            ActionViews.Add(FieldSet.ButtonBox);
            //ConfirmButton = new Button() {
            //    Text = "Hyperspace"
            //    };
            //FieldSet.ButtonBox.Add(ConfirmButton);
            }
        else {
            ConfirmButton = new Button() {
                Text = "Accept"
                };
            ConfirmButton.Clicked += OnClickConfirm;
            ActionViews.Add(ConfirmButton);
            }



        CancelButton = new Button() {
            Text = "Cancel",
            };
        CancelButton.Clicked += OnClickCancel;


        ActionViews.Add(CancelButton);

        Result = Action.Factory() as IParameter;
        Result.Initialize(Gui);
        FieldSet.SetFields(Result);

        EnableActions();

        view.Add(FieldSet.ButtonBox);
        view.Add(CancelButton);
        stack.Add(view);

        Content = stack;
        }

    public void TearDown() {
        Result?.TearDown(Gui);
        MainWindow.CurrentAction = null;
        }

    private void OnClickCancel(object sender, EventArgs e) {
        TearDown();
        MainWindow.SetDetailWindow();
        }

    private void OnClickConfirm(object sender, EventArgs e) {
        //var result = Action.Factory() as IParameter;


        FieldSet.GetFields(Result);

        var verify = Result.Validate(Gui);

        switch (verify) {
            case ValidResult: {

                if (Action.Callback != null) {
                    MainWindow.CurrentAction = null;
                    DisableActions();
                    var task = Action.Callback(Result);
                    task.ContinueWith(Continue, null);
                    }
                else {
                    TearDown();
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
