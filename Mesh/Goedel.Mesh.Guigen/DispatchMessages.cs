namespace Goedel.Everything;
public partial class EverythingMaui {

    ///<inheritdoc/>
    public override async Task<IResult> RequestContact(RequestContact data) {
        try {
            await Task.Delay(0);


            var recipient = data.Recipient;
            var message = data.Message;

            var response = await ContextUser.ContactRequestAsync(recipient, message: message);

            //var result = new ResultSent() {
            //    Success = true,
            //    Message = message
            //    };

            return new MessageSentContact() {
                AccountName = recipient,
                Identifier = response.MessageId
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
    public override async Task<IResult> RequestConfirmation(RequestConfirmation data) {
        try {


            var recipient = data.Recipient;
            var message = data.Message;

            var response = await ContextUser.ConfirmationRequestAsync(recipient, message);
            //var message = contextAccount.ConfirmationRequestAsync(recipient, text).Sync();

            //var result = new ResultSent() {
            //    Success = true,
            //    Message = message
            //};


            await Task.Delay(0);
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

    // *********************** NYI




    #region Process actions
    ///<inheritdoc/>
    public override async Task<IResult> ActionAccept(BoundMessageActionRequest data) =>
        await Process(data, true);

    ///<inheritdoc/>
    public override async Task<IResult> ActionReject(BoundMessageActionRequest data) =>
        await Process(data, false);

    #endregion

    async Task<IResult> Process(BoundMessage data, bool accept, bool reciprocate = false) {
        var index = data.Bound as SpoolIndexEntry;
        var message = index?.Message;
        await ContextUser.ProcessAsync(message, accept, reciprocate);

        return NullResult.Completed;
        }






    }
