using Goedel.Cryptography.Dare;

using System.Collections;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

using static System.Runtime.InteropServices.JavaScript.JSType;

using Contact = Goedel.Mesh.Contact;

namespace Goedel.Everything;





public partial class EverythingMaui {

    ///<inheritdoc/>
    public override async Task<IResult> AddPerson(AddPerson data) {
        var uid = Udf.Nonce();
        var entry = new CatalogedContact() {
            Uid = uid
            };

        await CurrentAccount.Contacts.AddAsync(entry);

        return NullResult.Completed;
        }
    ///<inheritdoc/>
    public override async Task<IResult> AddOrganization(AddOrganization data) {
        CurrentAccount.AssertNotNull(NYI.Throw);

        var uid = Udf.Nonce();
        var entry = new CatalogedContact() {
            Uid = uid
            };



        await CurrentAccount.Contacts.AddAsync(entry);

        return NullResult.Completed;
        }

    ///<inheritdoc/>
    public override async Task<IResult> AddLocation(AddLocation data) {
        CurrentAccount.AssertNotNull(NYI.Throw);

        var uid = Udf.Nonce();
        var entry = new CatalogedContact() {
            Uid = uid
            };

        await CurrentAccount.Contacts.AddAsync(entry);

        return NullResult.Completed;
        }


    /////<inheritdoc/>
    //public override async Task<IResult> ContactUpdate(BoundContact entry) {
    //    CurrentAccount.AssertNotNull(NYI.Throw);

    //    entry.SetBound();

    //    await CurrentAccount.Contacts.UpdateAsync(entry);

    //    return NullResult.Completed;
    //    }

    /////<inheritdoc/>
    //public override async Task<IResult> ContactDelete(BoundContact entry) {
    //    CurrentAccount.AssertNotNull(NYI.Throw);

    //    await CurrentAccount.Contacts.DeleteAsync(entry);

    //    return NullResult.Completed;
    //    }


    // Focus: 020 Engage QR code dialogs



    ///<inheritdoc/>
    public override async Task<IResult> QrContact(QrContact data) => await NotYetImplemented();

    // This is in messages
    //public override async Task<IResult> RequestContact(RequestContact data) => await NotYetImplemented();

    // Focus: 021 Engage Mesh messaging dialogs


    ///<inheritdoc/>
    public override Task<IResult> ContactAddNetwork(
                ContactAddNetwork parameters)  {

            var entry = new ContactNetworkIdentifier() {
                Protocol = parameters.Protocol,
                Address = parameters.Address,
                Fingerprint = parameters.Fingerprint
                };

            //parameters.Context.NetworkAddresses.Add(entry);

            return Task.FromResult <IResult> (NullResult.Completed);
        }
       


    ///<inheritdoc/>
    public override async Task<IResult> ContactAddCredential(BoundContactPerson data) {

        return NullResult.Completed;
        }
    ///<inheritdoc/>
    public override async Task<IResult> ContactAddPostal(BoundContactPerson data) {

        return NullResult.Completed;
        }

    /////<inheritdoc/>
    //public override async Task<IResult> ContactInteractAddress(ContactNetworkAddress data) => await NotYetImplemented();


    // Focus: 022 Engage handoff to other applications.

    ///<inheritdoc/>
    public override async Task<IResult> CreateMail(CreateMail data) => await NotYetImplemented();

    ///<inheritdoc/>
    public override async Task<IResult> CreateChat(CreateChat data) => await NotYetImplemented();

    ///<inheritdoc/>
    public override async Task<IResult> StartVoice(StartVoice data) => await NotYetImplemented();

    ///<inheritdoc/>
    public override async Task<IResult> StartVideo(StartVideo data) => await NotYetImplemented();

    async Task<IResult>NotYetImplemented() {
        try {
            await Task.Delay(0);
            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, null, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }



    }





