namespace Goedel.Guigen.Maui;

// All the code in this file is included in all platforms.
public static class Extensions {


    public static string GetFilename(this string icon) => icon + ".png";



    public static string AsToken(this DeviceIdiom deviceIdiom) => deviceIdiom.ToString();

    public static string AsToken(this DevicePlatform devicePlatform) {
        if (devicePlatform == DevicePlatform.WinUI) {
            return "Windows";
            }
        if (devicePlatform == DevicePlatform.MacCatalyst) {
            return DevicePlatform.macOS.ToString();
            }
        return devicePlatform.ToString();


        }


    }



