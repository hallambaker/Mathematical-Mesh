
using System.Net.NetworkInformation;

using ZXing.QrCode.Internal;

namespace Goedel.Everything;





public partial class EverythingMaui {

    public override async Task<IResult> DeviceUpdate(BoundDevice entry) {
        entry.SetBound();

        await CurrentAccount.Devices.UpdateAsync(entry);

        return NullResult.Completed;
        }
    ///<inheritdoc/>
    public override async Task<IResult> DeviceDelete(BoundDevice entry) {


        await CurrentAccount.Devices.DeleteAsync(entry);

        return NullResult.Completed;
        }


    ///<inheritdoc/>
    public override async Task<IResult> AccountGetPin(AccountGetPin data) {

        var rights = ParseRights(data.Rights);
        var bits = 120 + 20 * data.Security ?? 120;
        var expire = (data.Expire ?? 24) * TimeSpan.TicksPerHour;

        var messageConnectionPIN = await ContextUser.GetPinAsync(MeshConstants.MessagePINActionDevice,
                    validity: expire * TimeSpan.TicksPerHour, roles: rights, bits: bits);

        return new ReportPinValue() {
            Pin = messageConnectionPIN.Pin,
            Expiry = messageConnectionPIN.Expires.ToRFC3339()
            };

        }




    ///<inheritdoc/>
    public override async Task<IResult> DeviceConnectQR(DeviceConnectQR data) {
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

    }


public partial class DeviceConnectQR : IMessageable {


    // Focus: 020 Device Connect QR

    ///<inheritdoc/>
    public IResult MessageReceived() {
        throw new NYI();
        }

    ///<inheritdoc/>
    public override IResult TearDown(Gui gui) {
        if (QrCode != null) {
            var everything = gui as EverythingMaui;
            everything.UnRegister(QrCode);
            }

        return NullResult.Teardown;
        }

    ///<inheritdoc/>
    public override IResult Initialize(Gui gui) {
        var everything = gui as EverythingMaui;
        QrCode = everything.GetQrDevice(this);

        return NullResult.Initialized;
        }

    }