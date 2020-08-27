using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;
using Goedel.Utilities;

using System;
using System.Text;

namespace Goedel.Mesh {


    /// <summary>
    /// Results of a processing operation.
    /// </summary>
    public enum ProcessingResult {
        ///<summary>Processing failed: The pin is invalid because it was never issued.</summary> 
        PinNotIssued,
        ///<summary>Processing failed: The pin is invalid because validation checks failed.</summary> 
        PinInvalid,
        ///<summary>Processing failed: The pin is invalid because it has expired</summary> 
        PinExpired,
        ///<summary>Processing failed: The pin is invalid because it was already used.</summary> 
        PinUsed,


        ///<summary>Processing was not performed  because the action requires explicit aproval.</summary> 
        ExplicitApprovalRequired,
        ///<summary>Processing was not performed because it required threshold approval.</summary> 
        Threshold,
        ///<summary>Processing was not performed because the sender is unknown.</summary> 
        UnknownSender,
        ///<summary>Processing was not performed because the sender is blocked.</summary> 
        BlockedSender,
        ///<summary>Processing failed because the contact data is missing or invalid</summary> 
        ContactInvalid,


        ///<summary>Processing succeded</summary> 
        Success
        }




    public partial class ProcessResult {

        /// <summary>The message that caused this result</summary>
        public virtual Message RequestMessage { get; }

        /// <summary>The message that caused this result</summary>
        public virtual string InboundMessageId => RequestMessage.MessageId;

        /// <summary>The new message status (<see cref="MessageStatus.None"/> if unchanged)</summary>
        public virtual MessageStatus InboundMessageStatus { get; set; } = MessageStatus.None;

        /// <summary>The message that caused this result</summary>
        public virtual MessagePIN MessagePin { get;}

        /// <summary>The message that caused this result</summary>
        public virtual string MessagePinId => MessagePin?.MessageId;

        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        public ProcessResult() {
            }

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="message">The request message that led to this result.</param>
        /// <param name="messagePIN">The registration of the PIN code that supported this request.</param>
        /// <param name="success">If true, the processing was successful.</param>
        public ProcessResult(Message message, MessagePIN messagePIN, bool success=true) {
            RequestMessage = message;
            MessagePin = messagePIN;
            Success = success;
            }
        }


    ///<summary>The authorization specified is insufficient.</summary>
    public class InsufficientAuthorization : ProcessResult {

        /// <summary>
        /// Constructor, report that the request <paramref name="request"/> could not be performed 
        /// because it was not sufficientlyh authorized.
        /// </summary>
        /// <param name="request">The request that failed.</param>
        public InsufficientAuthorization(Message request):
                    base (request, null, false) {
            }
        }


    ///<summary>Invalid PIN result.</summary>
    public class ProcessResultError : ProcessResult {

        /// <summary>
        /// Constructor, report that the request <paramref name="request"/> could not be performed 
        /// because the specified pin code did not match the record <paramref name="messagePIN"/>
        /// resulting in the error report <paramref name="processingResult"/>.
        /// </summary>
        /// <param name="request">The request that failed.</param>
        /// <param name="processingResult">The result of processing.</param>
        /// <param name="messagePIN">PIN code registration, to be marked as used</param>
        public ProcessResultError(Message request, ProcessingResult processingResult, MessagePIN messagePIN = null) :
                    base(request, messagePIN, false) => ErrorReport = processingResult.ToString();


        }


    /// <summary>
    /// Report refusal of a message. This is a success response because the request is 
    /// successfully dealt with.
    /// </summary>
    public class ResultInvalid : ProcessResult {
        /// <summary>
        /// Constructor, return an instance reporting the successful processing of 
        /// <paramref name="request"/>.
        /// </summary>
        /// <param name="request">The request that failed.</param>
        /// <param name="messagePIN">PIN code registration, to be marked as used</param>
        public ResultInvalid(Message request, MessagePIN messagePIN = null) :
                    base(request, messagePIN, false) => ErrorReport = "InvalidContact";

        }


    /// <summary>
    /// Report refusal of a message. This is a success response because the request is 
    /// successfully dealt with.
    /// </summary>
    public class ResultRefused: ProcessResult {

        /// <summary>
        /// Constructor, return an instance reporting the successful processing of 
        /// <paramref name="request"/>.
        /// </summary>
        /// <param name="request">The request that failed.</param>
        /// <param name="messagePIN">PIN code registration, to be marked as used</param>
        public ResultRefused(Message request, MessagePIN messagePIN = null) :
                    base(request, messagePIN) {  }

        }


    /*
     * The following results are currently stubs. They may be expanded at a later date to 
     * describe the result of any successful operation.
     * 
     * In particular, when data from the contacts file is used to authenticate requests,
     * need to attach that information as well.
     */ 


    /// <summary>
    /// Report successful handling of a <see cref="GroupInvitation"/> message.
    /// </summary>
    public class ResultGroupInvitation : ProcessResult {

        /// <summary>The message that caused this result</summary>
        public GroupInvitation GroupInvitation;

        /// <summary>The message that caused this result</summary>
        public override Message RequestMessage => GroupInvitation;

        /// <summary>
        /// Constructor, return an instance reporting the successful processing of 
        /// <paramref name="request"/>.
        /// </summary>
        /// <param name="request">The request message.</param>
        /// <param name="messagePIN">PIN code registration, to be marked as used</param>
        public ResultGroupInvitation(GroupInvitation request, MessagePIN messagePIN = null) :
                    base(request, messagePIN) { }

        }

    /// <summary>
    /// Report successful handling of a <see cref="AcknowledgeConnection"/> message.
    /// </summary>
    public class ResultAcknowledgeConnection : ProcessResult {

        /// <summary>The message that caused this result</summary>
        public AcknowledgeConnection AcknowledgeConnection;

        /// <summary>The message that caused this result</summary>
        public override Message RequestMessage => AcknowledgeConnection;

        /// <summary>Result of the transaction</summary>
        public TransactResponse TransactResponse;

        /// <summary>
        /// Constructor, return an instance reporting the successful processing of 
        /// <paramref name="request"/>.
        /// </summary>
        /// <param name="request">The request message.</param>
        /// <param name="messagePIN">PIN code registration, to be marked as used</param>
        /// <param name="transactResponse">The transaction response</param>
        public ResultAcknowledgeConnection(
                AcknowledgeConnection request, MessagePIN messagePIN,
                TransactResponse transactResponse) :
                    base(request, messagePIN) { }


        }

    /// <summary>
    /// Report successful handling of a <see cref="ReplyContact"/> message.
    /// </summary>
    public class ResultReplyContact : ProcessResult {

        /// <summary>The message that caused this result</summary>
        public ReplyContact ReplyContact => RequestMessage as ReplyContact;

        /// <summary>
        /// Constructor, return an instance reporting the successful processing of 
        /// <paramref name="request"/>.
        /// </summary>
        /// <param name="request">The request message.</param>
        /// <param name="messagePIN">PIN code registration, to be marked as used</param>
        public ResultReplyContact(ReplyContact request, MessagePIN messagePIN = null) :
                    base(request, messagePIN) { }

        }

    /// <summary>
    /// Report successful handling of a <see cref="ReplyContact"/> message.
    /// </summary>
    public class ResultRequestContact : ProcessResult {

        /// <summary>The message that caused this result</summary>
        public RequestContact RequestContact => RequestMessage as RequestContact;

        /// <summary>The response to the request.</summary>     
        public ReplyContact ReplyContact { get; }


        /// <summary>
        /// Constructor, return an instance reporting the successful processing of 
        /// <paramref name="request"/>.
        /// </summary>
        /// <param name="request">The request message.</param>
        /// <param name="replyContact">The message sent in reply.</param>
        /// <param name="messagePIN">PIN code registration, to be marked as used</param>
        public ResultRequestContact(
                            RequestContact request,
                            ReplyContact replyContact,
                            MessagePIN messagePIN = null) :
                    base(request, messagePIN) => ReplyContact = replyContact;

        }


    }