//using Microsoft.UI.Xaml.Controls;
using Camera.MAUI;

namespace Goedel.Guigen.Maui;

// https://developer.apple.com/documentation/xcode/defining-a-custom-url-scheme-for-your-app

public class GuigenFieldQr : GuigenField {

    public IMainWindow MainWindow { get; }
    public IView View => Layout;
    //public ListView ListView { get; } = new();

    BarcodeImage QrImage;
    Label QrLabel;
    Entry QrEntry;

    Layout Layout;

    public GuiQR SelectCollection;
    GuiBoundPropertyQRScan Binding;

    public GuigenFieldQr(IMainWindow mainWindow, GuiQRScan chooser, GuigenFieldSet fieldsSet) : base(chooser) {
        // Generate a random 
        QrImage = new() {
            WidthRequest = 400,
            HeightRequest = 400,
            BarcodeHeight = 400,
            BarcodeWidth = 400,
            BarcodeMargin = 5,
            BarcodeFormat = ZXing.BarcodeFormat.QR_CODE
            };
        QrLabel = new();
        QrEntry = new();


        Layout = new VerticalStackLayout() { QrImage , QrLabel , QrEntry };

        fieldsSet.AddField(Layout);
        }



    public override void SetField(IBindable data) {
        Binding = data.Binding.BoundProperties[Index] as GuiBoundPropertyQRScan;
        var guiQr = Binding.Get(data);

        QrLabel.Text = guiQr.Offer;
        QrImage.Barcode = guiQr.Offer;
        }

    public override void GetField(IBindable data) {
        }


    }


