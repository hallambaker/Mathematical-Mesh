namespace Goedel.Guigen.Maui;


public interface IWidget {
    IMainWindow MainWindow { get; }


    }


public interface IMainWindow  {
    GuigenBinding Binding { get; }

    public StyleSheet StyleSheet { get; }


    public GuigenDetailAction CurrentAction { get; set; }


    public void SetDetailWindow(GuiSection section = null);

    public void SetDetailWindow(GuiAction action);


    public void SetResultWindow(IResult result);
    /// <summary>
    /// Method called to style the action button <paramref name="view"/> according to the 
    /// current stylesheet and the activation state.
    /// </summary>
    /// <param name="view">The button or other interface element to format.</param>
    public void FormatAction(View view);

    public void FormatFieldLabel(Label view);

    public void FormatFieldEntry(View view, GuiBoundProperty boundProperty);

    public void FormatFeedback(Label view);





    }






