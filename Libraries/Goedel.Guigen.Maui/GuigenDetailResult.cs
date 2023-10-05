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
            var view = new HorizontalStackLayout();
            var image = new Image() {
                Source = "triangle_exclamation_solid.png",
                HeightRequest = Binding.IconHeight * 2
                };

            var values = result.GetValues();
            var format = Binding.Resolve(fail.ResourceId);

            var text = values.Length > 0 ? String.Format(format, values) : format;

            var label = new Label() {
                Text = text
                };




            view.Add(image);
            view.Add(label);
            stack.Add(view);
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

                        view.Add(label);
                        view.Add(field);
                        stack.Add(view);

                        break;
                        }
                    case GuiBoundPropertyInteger text: {

                        var view = new HorizontalStackLayout();
                        var label = new Label() {
                            Text = text.Label
                            };

                        var fieldValue = text.Get(result);
                        var field = new Label() {
                            Text = fieldValue.ToString()
                            };

                        view.Add(label);
                        view.Add(field);
                        stack.Add(view);

                        break;
                        }
                    }
                }
            }

        var hview = new HorizontalStackLayout();
        DismissButton = new Button() {
            Text = "OK"
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