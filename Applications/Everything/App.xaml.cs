


using Goedel.Everything;


namespace Everything;

public partial class App : Application {

    Gui Gui = new EverythingMaui();

    public App() {
        InitializeComponent();

        var binding = new GuigenBinding(Gui);
        MainPage = binding.GetMain();



        }

    }
