
using Goedel.Everything;
using Goedel.Guigen;

namespace Everything;

public partial class MainPage : ContentPage {


    public Gui Gui = new EverythingMaui();
    int count = 0;

    public MainPage() {
        InitializeComponent();
        }

    private void OnCounterClicked(object sender, EventArgs e) {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

