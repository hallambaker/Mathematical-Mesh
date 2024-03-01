
namespace Goedel.Guigen.Maui;

public class GuigenDesktop : IMainWindow {

    public GuigenBinding Binding { get; }

    public Gui Gui => Binding.Gui;

    public Page Page => throw new NotImplementedException();





    public StyleSheet StyleSheet => throw new NotImplementedException();

    public GuigenDetailAction CurrentAction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }




    public GuigenDesktop(GuigenBinding binding) {
        Binding = binding;
        }









    public void FormatAction(View view) {
        throw new NotImplementedException();
        }

    public void FormatFeedback(Label view) {
        throw new NotImplementedException();
        }

    public void FormatFieldEntry(View view, GuiBoundProperty boundProperty) {
        throw new NotImplementedException();
        }

    public void FormatFieldLabel(Label view) {
        throw new NotImplementedException();
        }

    public int GetDetailWidth() {
        throw new NotImplementedException();
        }

    public void SetDetailWindow(GuiSection section = null) {
        throw new NotImplementedException();
        }

    public void SetDetailWindow(GuiAction action) {
        throw new NotImplementedException();
        }

    public void SetResultWindow(IResult result) {
        throw new NotImplementedException();
        }
    }









