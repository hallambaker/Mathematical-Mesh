




namespace Everything;

/// <summary>
/// The application.
/// </summary>
public partial class App : Application {

    Gui Gui = new EverythingMaui();

    /// <summary>
    /// Constructor, returns an instance with components initialized and a Gui binding snf
    /// raises the main window.
    /// </summary>
    public App() {
        InitializeComponent();

        var binding = new GuigenBinding(Gui);
        MainPage = binding.GetMain();
        }

    }
