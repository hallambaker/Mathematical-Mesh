using System.Diagnostics.Eventing.Reader;

using ZXing.QrCode.Internal;

namespace Goedel.Everything;
public partial class EverythingMaui {

    /////<inheritdoc/>
    //public override async Task<IResult> DeviceStaticUri(DeviceStaticUri data, ActionMode mode = ActionMode.Execute) {
    //    try {
    //        var rights = ParseRights(data.Rights);
    //        var catalogedDevice = await ContextUser.ConnectStaticUriAsync(
    //                data.ConnectionUri, rights, data.LocalName);

    //        return new NotYetImplemented() {
    //            };
    //        }
    //    catch (Exception exception) {
    //        if (TryProcessException(exception, data, out var result)) {
    //            return result;
    //            }
    //        return new ErrorResult(exception);
    //        }
    //    }

    ///<inheritdoc/>
    public override async Task<IResult> DeviceConnectQR(DeviceConnectQR data, ActionMode mode = ActionMode.Execute) {
        try {


            
            var rights = ParseRights(data.Rights);

            if (data.QrCode.CapturedByCamera is not null) {
                var catalogedDevice = await ContextUser.ConnectStaticUriAsync(
                        data.QrCode.CapturedByCamera, rights, data.LocalName);
                }
            else if (data.QrCode.ReceivedByMessage is not null) {
                // convert message to type
                // check is correct type
                // check pin

                // execute.

                }




            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }

    ///<inheritdoc/>
    public override async Task<IResult> AccountGetPin(AccountGetPin data, ActionMode mode = ActionMode.Execute) {
        try {

            var rights = ParseRights(data.Rights);
            var bits = 120 + 20 * data.Security ?? 120;
            var expire = (data.Expire ?? 24) * TimeSpan.TicksPerHour;

            var messageConnectionPIN = await ContextUser.GetPinAsync(MeshConstants.MessagePINActionDevice,
                        validity: expire * TimeSpan.TicksPerHour, roles: rights, bits: bits);

            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, data, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }

    }
