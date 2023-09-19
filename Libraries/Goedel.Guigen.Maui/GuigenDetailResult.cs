using Microsoft.Maui.Controls;

namespace Goedel.Guigen.Maui;

/// <summary>
/// Extension of a ContentPage to allow binding of the result data to the instance.
/// </summary>

public class GuigenDetailResult : GuigenDetaiPage {

    public Button DismissButton;

    public GuigenDetailResult(IMainWindow mainWindow, IResult result) : base(mainWindow) {

        var stack = new VerticalStackLayout();

        if (result is IFail fail) {
            var label = new Label() {
                Text = fail.Message,
                };
            stack.Add(label);
            }
        else {
            foreach (var entry in result.Binding.BoundProperties) {
                switch (entry) {
                    case GuiBoundPropertyString text: {

                        var view = new HorizontalStackLayout();
                        var label = new Label() {
                            Text = text.Label
                            };
                        var field = new Label() {
                            Text = text.Get(result)
                            };
                        stack.Add(view);

                        break;
                        }
                    }
                }
            }

        var hview = new HorizontalStackLayout();
        DismissButton = new Button() {
            Text = "Accept"
            };
        DismissButton.Clicked += OnClickDismiss;

        hview.Add(DismissButton);
        stack.Add(hview);
        Content = stack;
        }

    private void OnClickDismiss(object sender, EventArgs e) {
        MainWindow.SetDetailWindow();
        }


    public void Refresh() {
        }


    }