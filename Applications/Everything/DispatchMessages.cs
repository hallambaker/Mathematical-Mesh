namespace Goedel.Everything;
public partial class EverythingMaui {

    ///<inheritdoc/>
    public override async Task<IResult> RequestContact(RequestContact data, ActionMode mode = ActionMode.Execute) {
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
                AccountName = "Fred",
                Identifier = "Id"
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
    public override async Task<IResult> RequestConfirmation(RequestConfirmation data, ActionMode mode = ActionMode.Execute) {
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

    ///<inheritdoc/>
    public override async Task<IResult> CreateMail(CreateMail data, ActionMode mode = ActionMode.Execute) {
        try {
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

    ///<inheritdoc/>
    public override async Task<IResult> CreateChat(CreateChat data, ActionMode mode = ActionMode.Execute) {
        try {
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

    ///<inheritdoc/>
    public override async Task<IResult> StartVoice(StartVoice data, ActionMode mode = ActionMode.Execute) {
        try {
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

    ///<inheritdoc/>
    public override async Task<IResult> StartVideo(StartVideo data, ActionMode mode = ActionMode.Execute) {
        try {
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

    }
