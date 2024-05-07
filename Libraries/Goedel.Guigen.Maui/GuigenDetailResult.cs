
//namespace Goedel.Guigen.Maui;

///// <summary>
///// Extension of a ContentPage to allow binding of the result data to the instance.
///// </summary>

//public class GuigenDetailResult : GuigenDetaiPage {

//    public Button DismissButton;
//    int GridRow { get; set; } = 0;

//    public GuigenDetailResult(GuigenBinding binding, IResult result) : base(binding) {

//        var stack = new VerticalStackLayout();


//        string source = (result is IFail) ? "result_fail.pb" : "";


//        if (result is IFail fail) {

//            var values = result.GetValues();
//            var format = Binding.Resolve(fail.ResourceId) ?? fail.Message;

//            var text = values.Length > 0 ? String.Format(format, values) : format;

//            var view = GetTitle("result_fail.png", text);
//            stack.Add(view);
//            }
//        else {
//            var titleText = Binding.Resolve(result.ResourceId) ?? result.Message;
//            var title = GetTitle("result_success.png", titleText);
//            stack.Add(title);

//            var grid = new Grid();
//            grid.AddColumnDefinition(new ColumnDefinition(GridLength.Auto));
//            grid.AddColumnDefinition(new ColumnDefinition(GridLength.Star));
//            stack.Add(grid);

//            foreach (var entry in result.Binding.BoundProperties) {
//                switch (entry) {
//                    case GuiBoundPropertyString text: {

//                        var value = text.Get(result);
//                        if (value != null) {

//                            var view = new HorizontalStackLayout();
//                            var label = new Label() {
//                                Text = text.Label
//                                };
//                            var field = new Label() {
//                                Text = text.Get(result)
//                                };

//                            //view.Add(label);
//                            //view.Add(field);
//                            //stack.Add(view);

//                            MainWindow.FormatFieldLabel(label);
//                            MainWindow.FormatFieldEntry(field, text);

//                            grid.Add(label, 0, GridRow);
//                            grid.Add(field, 1, GridRow++);
//                            }

//                        break;
//                        }
//                    case GuiBoundPropertyInteger text: {
//                        var fieldValue = text.Get(result);
//                        if (fieldValue != null) {
//                            var view = new HorizontalStackLayout();
//                            var label = new Label() {
//                                Text = text.Label
//                                };


//                            var field = new Label() {
//                                Text = fieldValue.ToString()
//                                };

//                            //view.Add(label);
//                            //view.Add(field);
//                            //stack.Add(view);

//                            MainWindow.FormatFieldLabel(label);
//                            MainWindow.FormatFieldEntry(field, text);

//                            grid.Add(label, 0, GridRow);
//                            grid.Add(field, 1, GridRow++);
//                            }
//                        break;
//                        }
//                    }
//                }
//            }

//        var hview = new HorizontalStackLayout();
//        DismissButton = new Button() {
//            Text = "OK"
//            };
//        DismissButton.Clicked += OnClickDismiss;

//        hview.Add(DismissButton);

//        stack.Add(hview);
//        Content = stack;
//        }


//    IView GetTitle(string icon, string text) {
//        var view = new HorizontalStackLayout();
//        var image = new Image() {
//            Source = icon,
//            HeightRequest = Binding.IconHeight * 2
//            };
//        var label = new Label() {
//            Text = text
//            };

//        view.Add(image);
//        view.Add(label);

//        return view;
//        }

//    private void OnClickDismiss(object sender, EventArgs e) {
//        MainWindow.SetDetailWindow();
//        }


//    public void Refresh() {
//        }


//    }