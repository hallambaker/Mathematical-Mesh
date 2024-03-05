//using Microsoft.UI.Xaml.Controls;
using Camera.MAUI;

namespace Goedel.Guigen.Maui;

// https://developer.apple.com/documentation/xcode/defining-a-custom-url-scheme-for-your-app

public class GuigenFieldQr : GuigenField {


    GuiBoundPropertyQRScan TypedBinding => PropertyBinding as GuiBoundPropertyQRScan;


    BarcodeImage QrImage;
    Label QrLabel;
    Entry QrEntry;

    Layout Layout;

    public GuiQR SelectCollection;


    public GuigenFieldQr(IMainWindow mainWindow,
                GuigenFieldSet fieldsSet,
                GuiBoundPropertyQRScan binding) : base(mainWindow, binding) {

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
        var guiQr = TypedBinding.Get(data);

        QrLabel.Text = guiQr.Offer;
        QrImage.Barcode = guiQr.Offer;
        }

    public override void GetField(IBindable data) {
        }


    }


