#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion


namespace Goedel.Mesh.Shell;

public partial class Shell {

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult MessageContact(MessageContact options) {
        var contextAccount = GetContextUser(options);
        var recipient = options.Recipient.Value;

        var message = contextAccount.ContactRequest(recipient);

        var result = new ResultSent() {
            Success = true,
            Message = message
            };
        return result;
        }

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult MessageConfirm(MessageConfirm options) {
        var contextAccount = GetContextUser(options);
        var recipient = options.Recipient.Value;
        var text = options.Text.Value;


        var message = contextAccount.ConfirmationRequest(recipient, text);

        var result = new ResultSent() {
            Success = true,
            Message = message
            };

        return result;
        }

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult MessagePending(MessagePending options) {

        var contextAccount = GetContextUser(options);

        // this is failing to read in the inbound messages as it should.
        // The 


        contextAccount.Sync();
        var messages = contextAccount.GetOpenMessages();

        var result = new ResultPending() {
            Success = true,
            Messages = messages
            };

        return result;
        }

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult MessageStatus(MessageStatus options) {
        var contextAccount = GetContextUser(options);
        var messageID = options.RequestID.Value;

        // pull out the message here.

        Console.WriteLine($"Look for message {messageID}");


        //var message = contextAccount.GetPendingMessageByID(messageID, out var found);
        contextAccount.TryGetMessageById(messageID, out var index).AssertTrue(MessageIdNotFound.Throw);
        var message = index.Message;


        // return status as Pending / Accepted / Rejected

        var result = new ResultReceived() {
            Message = message,
            Status = index.MessageStatus.ToLabel()
            };
        return result;
        }


    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult MessageAccept(MessageAccept options) =>
        Process(options, options.RequestID.Value, true);

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult MessageReject(MessageReject options) =>
        Process(options, options.RequestID.Value, false);


    ShellResult Process(IAccountOptions options, string requestid, bool accept) {
        var contextAccount = GetContextUser(options);
        var processResult = contextAccount.Process(requestid, accept);


        var result = new ResultSent() {
            Success = true
            };
        return result;
        }

    /// <summary>
    /// Dispatch method
    /// </summary>
    /// <param name="options">The command line options.</param>
    /// <returns>Mesh result instance</returns>
    public override ShellResult MessageBlock(MessageBlock options) {
        var contextAccount = GetContextUser(options);
        var result = new ResultSent() {

            };
        return result;
        }


    }
