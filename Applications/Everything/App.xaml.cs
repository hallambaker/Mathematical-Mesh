


using Goedel.Everything;


namespace Everything;

public partial class App : Application {

    Gui Gui = new EverythingMaui();

    public App() {
        InitializeComponent();

        //var NavPage = new NavigationPage(new MyFlyoutPage());
        //NavigationPage.SetHasNavigationBar(NavPage,false); 



        var binding = new GuigenBinding(Gui);
        MainPage = binding.GetMain();


        //var menuPage = new GuigenSectionMenu(binding) {
        //    Title = "Menu"
        //    };






        //var detailPage = new ContentPage() {
        //    Title = "Detail"
        //    };

        //var flyoutPage = new FlyoutPage() {
        //    Flyout = menuPage,
        //    Detail = detailPage,
        //    Title = "Fred"
        //    };

        //MainPage = flyoutPage;

        //MainPage = new MyFlyoutPage();

        }

    }
