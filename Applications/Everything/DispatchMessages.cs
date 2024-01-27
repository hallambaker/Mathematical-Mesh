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



    /// <summary>
    /// GUI action
    /// </summary>
    public override Task<IResult> QrContact(QrContact data) {
        throw new NYI();
        }


    #region Contact
    ///<inheritdoc/>
    public override async Task<IResult> ContactAccept(BoundMessageContactRequest data) =>
        await Process(data, true, true);

    ///<inheritdoc/>
    public override async Task<IResult> ContactReject(BoundMessageContactRequest data) =>
        await Process(data, false, true);

    #endregion
    #region Confirmation
    ///<inheritdoc/>
    public override async Task<IResult> ConfirmationAccept(BoundMessageConfirmationRequest data) =>
        await Process(data, true);

    ///<inheritdoc/>
    public override async Task<IResult> ConfirmationReject(BoundMessageConfirmationRequest data) =>
        await Process(data, false);

    #endregion
    #region Device
    ///<inheritdoc/>
    public override async Task<IResult> ConnectAccept(BoundMessageConnectionRequest data) =>
        await Process(data, true);

    ///<inheritdoc/>
    public override async Task<IResult> ConnectReject(BoundMessageConnectionRequest data) =>
        await Process(data, false);
    #endregion
    #region Group
    ///<inheritdoc/>
    public override async Task<IResult> GroupAccept(BoundMessageGroupInvitation data) =>
        await Process(data, true);

    ///<inheritdoc/>
    public override async Task<IResult> GroupReject(BoundMessageGroupInvitation data) =>
        await Process(data, false);
    #endregion
    #region Task
    ///<inheritdoc/>
    public override async Task<IResult> TaskAccept(BoundMessageTaskRequest data) =>
        await Process(data, true);

    ///<inheritdoc/>
    public override async Task<IResult> TaskReject(BoundMessageTaskRequest data) =>
        await Process(data, false);
    #endregion

    async Task<IResult> Process(BoundMessage data, bool accept, bool reciprocate = false) {
        var index = data.Bound as SpoolIndexEntry;
        var message = index?.Message;
        await ContextUser.ProcessAsync(message, accept, reciprocate);

        return NullResult.Completed;
        }






    }
