#pragma warning disable IDE0022
#pragma warning disable IDE0060
#pragma warning disable IDE1006
using System.IO;
namespace ExampleGenerator {
    public partial class CreateExamples : global::Goedel.Registry.Script {



        //
        // MakeProtocolExamples
        //
        public void MakeProtocolExamples(CreateExamples Example) {
            ProtocolHello(Example);
            ProtocolAccountCreate(Example);
            ProtocolCreateGroup(Example);
            ProtocolStatus(Example);
            ProtocolPostClientService(Example);
            ProtocolClaim(Example);
            ProtocolPollClaim(Example);
            ProtocolCryptoKeyShare(Example);
            ProtocolCryptoKeyAgree(Example);
            ProtocolMessagePIN(Example);
            ProtocolContactRemote(Example);
            ProtocolContactQR(Example);
            ProtocolContactStatic(Example);
            ProtocolGroupInvite(Example);
            ProtocolConfirmation(Example);
            ProtocolConnect(Example);
            ProtocolConnectEARL(Example);
            ProtocolMessageCompletion(Example);
            ProtocolHelloRequest(Example);
            ProtocolHelloResponse(Example);
            ProtocolAccountDelete(Example);
            ProtocolPostServiceService(Example);
            ProtocolConnectPIN(Example);
            ProtocolDownload(Example);
            ProtocolUpload(Example);
            }


        //
        // ProtocolHelloRequest
        //
        public static void ProtocolHelloRequest(CreateExamples Example) { /* XFile  */
            using var _Output = new StreamWriter("Examples\\ProtocolHelloRequest.md");
            Example._Output = _Output;
            Example._ProtocolHelloRequest(Example);
            }
        public void _ProtocolHelloRequest(CreateExamples Example) {

            // This is to show the binding
            _Output.Write("\n{0}", _Indent);
            DescribeRequestBinding(Service.Hello?[0].Traces[0]);
            _Output.Write("\n{0}", _Indent);
            }


        //
        // ProtocolHelloResponse
        //
        public static void ProtocolHelloResponse(CreateExamples Example) { /* XFile  */
            using var _Output = new StreamWriter("Examples\\ProtocolHelloResponse.md");
            Example._Output = _Output;
            Example._ProtocolHelloResponse(Example);
            }
        public void _ProtocolHelloResponse(CreateExamples Example) {

            // This is to show the binding
            _Output.Write("\n{0}", _Indent);
            DescribeResponseBinding(Service.Hello?[0].Traces[0]);
            _Output.Write("\n{0}", _Indent);
            }


        //
        // ProtocolHello
        //
        public static void ProtocolHello(CreateExamples Example) { /* XFile  */
            using var _Output = new StreamWriter("Examples\\ProtocolHello.md");
            Example._Output = _Output;
            Example._ProtocolHello(Example);
            }
        public void _ProtocolHello(CreateExamples Example) {

            _Output.Write("\n{0}", _Indent);
            _Output.Write("The request payload:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeRequest(Service?.Hello?[0].Traces[0]);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The response payload:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeResponse(Service?.Hello?[0].Traces[0]);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            }


        //
        // ProtocolAccountCreate
        //
        public static void ProtocolAccountCreate(CreateExamples Example) { /* XFile  */
            using var _Output = new StreamWriter("Examples\\ProtocolAccountCreate.md");
            Example._Output = _Output;
            Example._ProtocolAccountCreate(Example);
            }
        public void _ProtocolAccountCreate(CreateExamples Example) {

            _Output.Write("\n{0}", _Indent);
            _Output.Write("The request payload:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeRequest(Account?.CreateAlice?[0].Traces?[0]);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The response payload:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeResponse(Account?.CreateAlice?[0].Traces?[0]);
            _Output.Write("\n{0}", _Indent);
            }


        //
        // ProtocolCreateGroup
        //
        public static void ProtocolCreateGroup(CreateExamples Example) { /* XFile  */
            using var _Output = new StreamWriter("Examples\\ProtocolCreateGroup.md");
            Example._Output = _Output;
            Example._ProtocolCreateGroup(Example);
            }
        public void _ProtocolCreateGroup(CreateExamples Example) {

            _Output.Write("\n{0}", _Indent);
            _Output.Write("The request payload:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeRequest(Group?.GroupCreate?[0].Traces?[0]);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The response payload:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeResponse(Group?.GroupCreate?[0].Traces?[0]);
            _Output.Write("\n{0}", _Indent);
            }


        //
        // ProtocolAccountDelete
        //
        public static void ProtocolAccountDelete(CreateExamples Example) { /* XFile  */
            using var _Output = new StreamWriter("Examples\\ProtocolAccountDelete.md");
            Example._Output = _Output;
            Example._ProtocolAccountDelete(Example);
            }
        public void _ProtocolAccountDelete(CreateExamples Example) {

            _Output.Write("\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The request payload:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeRequest(Account?.DeleteAlice?[0].Traces?[0]);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The response payload:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeResponse(Account?.DeleteAlice?[0].Traces?[0]);
            _Output.Write("\n{0}", _Indent);
            }


        //
        // ProtocolStatus
        //
        public static void ProtocolStatus(CreateExamples Example) { /* XFile  */
            using var _Output = new StreamWriter("Examples\\ProtocolStatus.md");
            Example._Output = _Output;
            Example._ProtocolStatus(Example);
            }
        public void _ProtocolStatus(CreateExamples Example) {

            _Output.Write("\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The request payload:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeRequest(Account?.SyncAlice?[0].Traces?[0]);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The response payload:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeResponse(Account?.SyncAlice?[0].Traces?[0]);
            _Output.Write("\n{0}", _Indent);
            }


        //
        // ProtocolDownload
        //
        public static void ProtocolDownload(CreateExamples Example) { /* XFile  */
            using var _Output = new StreamWriter("Examples\\ProtocolDownload.md");
            Example._Output = _Output;
            Example._ProtocolDownload(Example);
            }
        public void _ProtocolDownload(CreateExamples Example) {

            ReportObsoleteExample();
            _Output.Write("\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            }


        //
        // ProtocolUpload
        //
        public static void ProtocolUpload(CreateExamples Example) { /* XFile  */
            using var _Output = new StreamWriter("Examples\\ProtocolUpload.md");
            Example._Output = _Output;
            Example._ProtocolUpload(Example);
            }
        public void _ProtocolUpload(CreateExamples Example) {

            ReportObsoleteExample();
            _Output.Write("\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            }


        //
        // ProtocolPostClientService
        //
        public static void ProtocolPostClientService(CreateExamples Example) { /* XFile  */
            using var _Output = new StreamWriter("Examples\\ProtocolPostClientService.md");
            Example._Output = _Output;
            Example._ProtocolPostClientService(Example);
            }
        public void _ProtocolPostClientService(CreateExamples Example) {

            _Output.Write("\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The request payload:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeRequest(Connect?.ConnectRequest?[0].Traces?[0]);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The response payload:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeResponse(Connect?.ConnectRequest?[0].Traces?[0]);
            _Output.Write("\n{0}", _Indent);
            }


        //
        // ProtocolPostServiceService
        //
        public static void ProtocolPostServiceService(CreateExamples Example) { /* XFile  */
            using var _Output = new StreamWriter("Examples\\ProtocolPostServiceService.md");
            Example._Output = _Output;
            Example._ProtocolPostServiceService(Example);
            }
        public void _ProtocolPostServiceService(CreateExamples Example) {

            ReportMissingExample();
            _Output.Write("\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            }


        //
        // ProtocolCryptoKeyShare
        //
        public static void ProtocolCryptoKeyShare(CreateExamples Example) { /* XFile  */
            using var _Output = new StreamWriter("Examples\\ProtocolCryptoKeyShare.md");
            Example._Output = _Output;
            Example._ProtocolCryptoKeyShare(Example);
            }
        public void _ProtocolCryptoKeyShare(CreateExamples Example) {

            _Output.Write("The request payload:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeRequest(Group?.GroupAddBob?[0].Traces?[1]);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The response payload:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeResponse(Group?.GroupAddBob?[0].Traces?[1]);
            }


        //
        // ProtocolCryptoKeyAgree
        //
        public static void ProtocolCryptoKeyAgree(CreateExamples Example) { /* XFile  */
            using var _Output = new StreamWriter("Examples\\ProtocolCryptoKeyAgree.md");
            Example._Output = _Output;
            Example._ProtocolCryptoKeyAgree(Example);
            }
        public void _ProtocolCryptoKeyAgree(CreateExamples Example) {

            _Output.Write("The request payload:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeRequest(Group?.GroupDecryptBobSuccess?[0].Traces?[1]);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The response payload:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeResponse(Group?.GroupDecryptBobSuccess?[0].Traces?[1]);
            }


        //
        // ProtocolMessagePIN
        //
        public static void ProtocolMessagePIN(CreateExamples Example) { /* XFile  */
            using var _Output = new StreamWriter("Examples\\ProtocolMessagePIN.md");
            Example._Output = _Output;
            Example._ProtocolMessagePIN(Example);
            }
        public void _ProtocolMessagePIN(CreateExamples Example) {

            _Output.Write("\n{0}", _Indent);
            _Output.Write("Alice connects a device using a QR code presented by her administrative device.\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The administration device creates a PIN code and records it to the Local spool:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeMessage(Connect.ConnectPINMessagePin);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("This pin value is used to authenticate the connection request from the device:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeMessage(Connect.ConnectRequestPIN);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The administration device can now use the PIN Identifier to retreive the \n{0}", _Indent);
            _Output.Write("MessagePIN from the Local spool and use it to verify the request.\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            }


        //
        // ProtocolMessageCompletion
        //
        public static void ProtocolMessageCompletion(CreateExamples Example) { /* XFile  */
            using var _Output = new StreamWriter("Examples\\ProtocolMessageCompletion.md");
            Example._Output = _Output;
            Example._ProtocolMessageCompletion(Example);
            }
        public void _ProtocolMessageCompletion(CreateExamples Example) {

            _Output.Write("\n{0}", _Indent);
            _Output.Write("After using the PIN code to authenticate connection of a device in the previous \n{0}", _Indent);
            _Output.Write("example, the corresponding MessagePin is marked as having been used by appending \n{0}", _Indent);
            _Output.Write("a completion message to the Local spool.\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeMessage(Connect.ConnectPINCompleteMessage);
            _Output.Write("\n{0}", _Indent);
            }


        //
        // ProtocolContactRemote
        //
        public static void ProtocolContactRemote(CreateExamples Example) { /* XFile  */
            using var _Output = new StreamWriter("Examples\\ProtocolContactRemote.md");
            Example._Output = _Output;
            Example._ProtocolContactRemote(Example);
            }
        public void _ProtocolContactRemote(CreateExamples Example) {

            _Output.Write("\n{0}", _Indent);
            DescribeMessage(Contact.BobRequest);
            _Output.Write("\n{0}", _Indent);
            }


        //
        // ProtocolContactQR
        //
        public static void ProtocolContactQR(CreateExamples Example) { /* XFile  */
            using var _Output = new StreamWriter("Examples\\ProtocolContactQR.md");
            Example._Output = _Output;
            Example._ProtocolContactQR(Example);
            }
        public void _ProtocolContactQR(CreateExamples Example) {

            _Output.Write("\n{0}", _Indent);
            _Output.Write("When they meet in person, Alice creates a pin code and presents it to Bob on her mobile.\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("QR code is {1} yadda yaddda\n{0}", _Indent, Contact.AliceDynamicQRCode);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The resulting contact exchange does not change the contact data itself but does change\n{0}", _Indent);
            _Output.Write("the valudation method. It is more difficult and riskier to falsify an in-person exchange\n{0}", _Indent);
            _Output.Write("than a remote one.\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            }


        //
        // ProtocolContactStatic
        //
        public static void ProtocolContactStatic(CreateExamples Example) { /* XFile  */
            using var _Output = new StreamWriter("Examples\\ProtocolContactStatic.md");
            Example._Output = _Output;
            Example._ProtocolContactStatic(Example);
            }
        public void _ProtocolContactStatic(CreateExamples Example) {

            _Output.Write("\n{0}", _Indent);
            _Output.Write("Alice creates a contact and publishes it through her service.\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("QR code is {1} yadda yaddda\n{0}", _Indent, Contact.AliceStaticQRCode);
            _Output.Write("\n{0}", _Indent);
            }


        //
        // ProtocolGroupInvite
        //
        public static void ProtocolGroupInvite(CreateExamples Example) { /* XFile  */
            using var _Output = new StreamWriter("Examples\\ProtocolGroupInvite.md");
            Example._Output = _Output;
            Example._ProtocolGroupInvite(Example);
            }
        public void _ProtocolGroupInvite(CreateExamples Example) {

            _Output.Write("\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            Format(Group.GroupInvitation);
            }


        //
        // ProtocolClaim
        //
        public static void ProtocolClaim(CreateExamples Example) { /* XFile  */
            using var _Output = new StreamWriter("Examples\\ProtocolClaim.md");
            Example._Output = _Output;
            Example._ProtocolClaim(Example);
            }
        public void _ProtocolClaim(CreateExamples Example) {

            _Output.Write("\n{0}", _Indent);
            _Output.Write("A device is preconfigured during manufacture and a Device Description published to the\n{0}", _Indent);
            _Output.Write("EARL:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("{1}\n{0}", _Indent, Connect.ClaimUri);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The client claiming the publication creates a claim message specifying the \n{0}", _Indent);
            _Output.Write("resource being claimed and the address of the Mesh account making the claim.\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeMessage(Connect.MessageClaim);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The message is signed by the claimant to make a RequestClaim to the service:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeRequest(Connect.RequestClaim);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The publication is found and the claim is accepted, the publication  is returned\n{0}", _Indent);
            _Output.Write("in the response.\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeResponse(Connect.ResponseClaim);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The device waiting to be connected uses the PollClaim transaction to receive notification\n{0}", _Indent);
            _Output.Write("of a claim having been posted.\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            }


        //
        // ProtocolPollClaim
        //
        public static void ProtocolPollClaim(CreateExamples Example) { /* XFile  */
            using var _Output = new StreamWriter("Examples\\ProtocolPollClaim.md");
            Example._Output = _Output;
            Example._ProtocolPollClaim(Example);
            }
        public void _ProtocolPollClaim(CreateExamples Example) {

            _Output.Write("\n{0}", _Indent);
            _Output.Write("The device in the example above periodically polls the service to which the device \n{0}", _Indent);
            _Output.Write("description is published to find if a claim has been registered.\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The PollClaimRequest contains the account to which the document is published\n{0}", _Indent);
            _Output.Write("and the publication ID:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeRequest(Connect.RequestPollClaim);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The response returns the latest claim made as signed message:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeResponse(Connect.ResponsePollClaim);
            _Output.Write("\n{0}", _Indent);
            }


        //
        // ProtocolConfirmation
        //
        public static void ProtocolConfirmation(CreateExamples Example) { /* XFile  */
            using var _Output = new StreamWriter("Examples\\ProtocolConfirmation.md");
            Example._Output = _Output;
            Example._ProtocolConfirmation(Example);
            }
        public void _ProtocolConfirmation(CreateExamples Example) {

            _Output.Write("\n{0}", _Indent);
            _Output.Write("The service sends out the following request:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeMessage(Confirm.RequestConfirmation);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("Alice accepts the request and returns the following response:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeMessage(Confirm.ResponseConfirmation);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            }


        //
        // ProtocolConnectPIN
        //
        public static void ProtocolConnectPIN(CreateExamples Example) { /* XFile  */
            using var _Output = new StreamWriter("Examples\\ProtocolConnectPIN.md");
            Example._Output = _Output;
            Example._ProtocolConnectPIN(Example);
            }
        public void _ProtocolConnectPIN(CreateExamples Example) {

            _Output.Write("\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("### Phase 1:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            ConsoleExample(Connect.ConnectPINCreate);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The registration of this PIN value was shown earlier in section $$$\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The URI containing the account address and PIN is:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("~~~~\n{0}", _Indent);
            _Output.Write("{1}\n{0}", _Indent, Connect.ConnectDynamicURI);
            _Output.Write("~~~~\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("### Phase 2:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The onboarding device scans the QR code to obtain the account address and PIN code.\n{0}", _Indent);
            _Output.Write("The PIN code is used to authenticate a connection request:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            ConsoleExample(Connect.ConnectPINRequest);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The device issues a connection request to the service corresponding to the account. \n{0}", _Indent);
            _Output.Write("This specifies the device profile, the account to which the device is to be \n{0}", _Indent);
            _Output.Write("connected and the client nonce value:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeRequest(Connect.ConnectPINRequestConnection);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The service generates the service nonce value and uses it to create the \n{0}", _Indent);
            _Output.Write("AcknowledgeConnection message.\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeMessage(Connect.ConnectPINAcknowledgeConnection);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The AcknowledgeConnection message is appended to the Inbound spool of the account\n{0}", _Indent);
            _Output.Write("to which connection was requested so that the user can approve the request. The\n{0}", _Indent);
            _Output.Write("ConnectResponse message is returned to the device containing the AcknowledgeConnection \n{0}", _Indent);
            _Output.Write("message and the profile of the account.\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeResponse(Connect.ConnectPINResponseConnection);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The device generates the witness value and presents it to the user as shown above.\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("### Phase 3:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The user synchronizes their pending messages:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            ConsoleExample(Connect.ConnectPINPending);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The administration device determines that the device connection request is authenticated\n{0}", _Indent);
            _Output.Write("by a PIN code. The PIN code is retrieved and the message authenticated. This is shown in\n{0}", _Indent);
            _Output.Write("the PIN registration interation example in section $$$ above.\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            Format(Connect.ConnectPINActivationDevice);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The Cataloged device record is created from the public key values corresponding to the\n{0}", _Indent);
            _Output.Write("combination of the public keys in the device profile and those defined by the activation:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            Format(Connect.ConnectPINCatalogedDevice);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The ActivationDevice and CatalogedDevice records are ???\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("### Phase 4\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The device periodically polls for completion of the connection request using the\n{0}", _Indent);
            _Output.Write("Complete transaction.\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("To provide a final check on the process, the command line tool presents the UDF of \n{0}", _Indent);
            _Output.Write("the account profile to which the device has connected if successful:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            ConsoleExample(Connect.ConnectPINComplete);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The completion request specified the device requesting completion:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeRequest(Connect.ConnectPINRequestComplete);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The response contains the information the device requires to complete the connection\n{0}", _Indent);
            _Output.Write("to the mesh:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            DescribeRequest(Connect.ConnectPINRespondComplete);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            }


        //
        // ProtocolConnect
        //
        public static void ProtocolConnect(CreateExamples Example) { /* XFile  */
            using var _Output = new StreamWriter("Examples\\ProtocolConnect.md");
            Example._Output = _Output;
            Example._ProtocolConnect(Example);
            }
        public void _ProtocolConnect(CreateExamples Example) {

            _Output.Write("\n{0}", _Indent);
            _Output.Write("### Phase 1:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("There are no first phase actions.\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("### Phase 2:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("Alice enters the connection request on the device to be connected. This specifies the \n{0}", _Indent);
            _Output.Write("address of the account to which she wishes to connect:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            ConsoleExample(Connect.ConnectRequest);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("### Phase 3:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The user reviews their pending messages:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            ConsoleExample(Connect.ConnectPending);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The administration device receives the AcknowledgeConnection message from the service \n{0}", _Indent);
            _Output.Write("and verifies that the signature is valid and the witness value correctly computed.\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The user verifies that the witness value presented in the AcknowledgeConnection message\n{0}", _Indent);
            _Output.Write("matches the one presented on the device. Since they match, the request is accepted:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            ConsoleExample(Connect.ConnectAccept);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("### Phase 4\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The device completes the connection as before:\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            ConsoleExample(Connect.ConnectComplete);
            _Output.Write("\n{0}", _Indent);
            }


        //
        // ProtocolConnectEARL
        //
        public static void ProtocolConnectEARL(CreateExamples Example) { /* XFile  */
            using var _Output = new StreamWriter("Examples\\ProtocolConnectEARL.md");
            Example._Output = _Output;
            Example._ProtocolConnectEARL(Example);
            }
        public void _ProtocolConnectEARL(CreateExamples Example) {

            _Output.Write("\n{0}", _Indent);
            _Output.Write("### Phase 1\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The device is prepopulated with a Device description, this is shown in section $$$ of\n{0}", _Indent);
            _Output.Write("Schema.\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("### Phase 2\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The administration device scans the QR code and obtains the Device Description using\n{0}", _Indent);
            _Output.Write("the Claim transaction as shown in section $$$$.\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("### Phase 3\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("Tha administration device creates the ActivationDevice and CatalogedDevice records\n{0}", _Indent);
            _Output.Write("and populates the service as before.\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("### Phase 4\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The device polls the publication service until a claim message is returned. This \n{0}", _Indent);
            _Output.Write("interaction is shown in section $$$$ above.\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            }
        }
    }
