using  System.Text;
using  Goedel.Mesh;
using  Goedel.Protocol;
using  Goedel.Utilities;
using  Goedel.Cryptography;
using  Goedel.Cryptography.Dare;
 #pragma warning disable IDE0022
 #pragma warning disable IDE0060
 #pragma warning disable IDE1006
using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Registry;
namespace ExampleGenerator {
	public partial class CreateExamples : global::Goedel.Registry.Script {

		

		//
		// MakeProtocolExamples
		//
		public void MakeProtocolExamples (CreateExamples Example) {
			 ProtocolHello(Example);
			 ProtocolAccountCreate(Example);
			 ProtocolCreateGroup(Example);
			 ProtocolStatus(Example);
			 ProtocolConnectRequest(Example);
			 ProtocolConnectComplete(Example);
			 ProtocolClaim(Example);
			 ProtocolPublishPreconfig(Example);
			 ProtocolPollClaim(Example);
			 ProtocolCryptoKeyShare(Example);
			 ProtocolCryptoKeyAgree(Example);
			 ProtocolMessagePIN(Example);
			 ProtocolContactRemote(Example);
			 ProtocolContactQR(Example);
			 ProtocolContactStatic(Example);
			 ProtocolGroupInvite(Example);
			 ProtocolConfirmation(Example);
			 ProtocolConnectEARL(Example);
			 ProtocolMessageCompletion(Example);
			 ProtocolAccountDelete(Example);
			 ProtocolAccountRecover(Example);
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
				_Output.Write ("\n{0}", _Indent);
				  DescribeRequestBinding (Service.Hello?[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
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
				_Output.Write ("\n{0}", _Indent);
				  DescribeResponseBinding (Service.Hello?[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
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

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The request payload only specifies that is is a request for the service description:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeRequest(Service?.Hello?[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The response payload describes the service and the host providing that service:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeResponse(Service?.Hello?[0].Traces[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
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

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice requests creation of the account {1}. The request payload is:\n{0}", _Indent, AliceAccount);
				_Output.Write ("\n{0}", _Indent);
				  DescribeRequest (Account?.CreateAlice?[0].Traces?[1]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The response payload currently reports the success or failure of the bind operation:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeResponse (Account?.CreateAlice?[0].Traces?[1]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("It is likely that a future revisions of the specification will specify the host(s) to \n{0}", _Indent);
				_Output.Write ("which future account service operations are to be directed. This would allow the\n{0}", _Indent);
				_Output.Write ("account management operations to be separated from the account maintenance operations\n{0}", _Indent);
				_Output.Write ("without requiring the traditional tiered architecture in which every interaction with \n{0}", _Indent);
				_Output.Write ("a service is first routed to a host that cannot perform the required action so that\n{0}", _Indent);
				_Output.Write ("it can be directed to the host that can.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
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

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The request payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeRequest (Group?.GroupCreate?[0].Traces?[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The response payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeResponse (Group?.GroupCreate?[0].Traces?[0]);
				_Output.Write ("\n{0}", _Indent);
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

				_Output.Write ("{1}\n{0}", _Indent, Unfinished ("ProtocolAccountDelete"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The request payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeRequest (Account?.DeleteAlice?[0].Traces?[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The response payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeResponse (Account?.DeleteAlice?[0].Traces?[0]);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ProtocolAccountRecover
		//
		public static void ProtocolAccountRecover(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolAccountRecover.md");
			Example._Output = _Output;
			Example._ProtocolAccountRecover(Example);
			}
		public void _ProtocolAccountRecover(CreateExamples Example) {

				_Output.Write ("{1}\n{0}", _Indent, Unfinished ("ProtocolAccountRecover"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("[TBS]\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
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

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice adds an entry to her bookmark catalog. Before the bookmark can be \n{0}", _Indent);
				_Output.Write ("added, the device synchronizes to the service. The synchronization process\n{0}", _Indent);
				_Output.Write ("begins with a request for the status of all the stores associated with the \n{0}", _Indent);
				_Output.Write ("account that it has access rights for:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeRequest (Connect.AddPasswordToDevice2BySync?[0].Traces?[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("If the account has a very large number of stores, the device might only \n{0}", _Indent);
				_Output.Write ("ask for the status of specific stores of interest.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The response specifies the status of each store specifying the index and\n{0}", _Indent);
				_Output.Write ("Merkle tree apex digest values for each:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeResponse (Connect.AddPasswordToDevice2BySync?[0].Traces?[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Bug: The current version of the reference code is only returning the digest \n{0}", _Indent);
				_Output.Write ("values for the outbound store.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
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

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The previous status operation has reported that a new envelope has been added to\n{0}", _Indent);
				_Output.Write ("the credential store. The device requests this data from the service:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeRequest (Connect.AddPasswordToDevice2BySync?[0].Traces?[1]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The response contains the requested envelope:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeResponse (Connect.AddPasswordToDevice2BySync?[0].Traces?[1]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Future: The current implementation of the download operation is limited by the\n{0}", _Indent);
				_Output.Write ("capabilities of the HTTP binding of the RUD transport. A future binding allowing \n{0}", _Indent);
				_Output.Write ("operations that consist of a single request followed by a sequence of responses \n{0}", _Indent);
				_Output.Write ("will allow much greater flexibility.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
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

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The request payload specifies the data to be appended to the stores.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeRequest (Connect.AddPasswordToDevice2BySync?[1].Traces?[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The response reports successful completion:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeResponse (Connect.AddPasswordToDevice2BySync?[1].Traces?[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ProtocolConnectRequest
		//
		public static void ProtocolConnectRequest(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolConnectRequest.md");
			Example._Output = _Output;
			Example._ProtocolConnectRequest(Example);
			}
		public void _ProtocolConnectRequest(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The connect request is made to the service, not the account. The payload contains the \n{0}", _Indent);
				_Output.Write ("enveloped connection request:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeRequest (Connect?.ConnectPINRequest?[0].Traces?[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The response payload contains the information the device requires to compute\n{0}", _Indent);
				_Output.Write ("the witness value and to poll for completion. This is a copy of the request\n{0}", _Indent);
				_Output.Write ("acknowledgement and a copy of the profile of the account the device has\n{0}", _Indent);
				_Output.Write ("requested connection to:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeResponse (Connect?.ConnectPINRequest?[0].Traces?[0]);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ProtocolConnectComplete
		//
		public static void ProtocolConnectComplete(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolConnectComplete.md");
			Example._Output = _Output;
			Example._ProtocolConnectComplete(Example);
			}
		public void _ProtocolConnectComplete(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The complete request is made to the service, not the account. The payload specifies\n{0}", _Indent);
				_Output.Write ("the account the device is requesting completion for and the identifier of the completion \n{0}", _Indent);
				_Output.Write ("message.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeRequest (Connect?.ConnectPINComplete?[0].Traces?[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The response payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeResponse (Connect?.ConnectPINComplete?[0].Traces?[0]);
				_Output.Write ("\n{0}", _Indent);
					}
		

		//
		// ProtocolPublishPreconfig
		//
		public static void ProtocolPublishPreconfig(CreateExamples Example) { /* XFile  */
				using var _Output = new StreamWriter("Examples\\ProtocolPublishPreconfig.md");
			Example._Output = _Output;
			Example._ProtocolPublishPreconfig(Example);
			}
		public void _ProtocolPublishPreconfig(CreateExamples Example) {

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("[not used]\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
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

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("A device is preconfigured during manufacture and a Device Description published to the\n{0}", _Indent);
				_Output.Write ("EARL:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Connect.ClaimUri);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The client claiming the publication creates a claim message specifying the \n{0}", _Indent);
				_Output.Write ("resource being claimed and the address of the Mesh account making the claim.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 DescribeMessage(Connect.MessageClaim);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The message is signed by the claimant to make a RequestClaim to the service:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 DescribeRequest(Connect.RequestClaim);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The publication is found and the claim is accepted, the publication  is returned\n{0}", _Indent);
				_Output.Write ("in the response.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 DescribeResponse(Connect.ResponseClaim);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The device waiting to be connected uses the PollClaim transaction to receive notification\n{0}", _Indent);
				_Output.Write ("of a claim having been posted.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
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

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The device in the example above periodically polls the service to which the device \n{0}", _Indent);
				_Output.Write ("description is published to find if a claim has been registered.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The PollClaimRequest contains the account to which the document is published\n{0}", _Indent);
				_Output.Write ("and the publication ID:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 DescribeRequest(Connect.RequestPollClaim);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The response returns the latest claim made as signed message:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 DescribeResponse(Connect.ResponsePollClaim);
				_Output.Write ("\n{0}", _Indent);
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

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice added Bob to {1} as a member. This resulted in Bob receiving the\n{0}", _Indent, GroupAccount);
				_Output.Write ("invitation described in section ??? and the following access entry being added\n{0}", _Indent);
				_Output.Write ("to the Access catalog of the group account:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Format(Group.BobAccessEntry);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The private key (in this case a key share) is encrypted under the service key.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To make use of the access entry, a request is made that specifies the key share\n{0}", _Indent);
				_Output.Write ("to be operated on and the public key parameters to perform the agreement with.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The request payload:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeRequest (Group?.GroupDecryptBobSuccess?[1].Traces?[0]);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The service checks to see if the request is authorized and if so, performs the\n{0}", _Indent);
				_Output.Write ("operation and returns the result:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeResponse (Group?.GroupDecryptBobSuccess?[1].Traces?[0]);
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

				_Output.Write ("{1}\n{0}", _Indent, Unfinished ("ProtocolCryptoKeyShare"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("[Not Yet Implemented]\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
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

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Unfinished ("ProtocolPostServiceService"));
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("[Not Yet Implemented]\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
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

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice connects a device using a QR code presented by her administrative device.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The administration device creates a PIN code and records it to the Local spool. The\n{0}", _Indent);
				_Output.Write ("message specifies the salted pin value used to verify attempts to use the PIN, the\n{0}", _Indent);
				_Output.Write ("action for which it is authorized. Since this PIN has been issued to authorize a device\n{0}", _Indent);
				_Output.Write ("connection, the roles for which the device are authorized as well. This allows the \n{0}", _Indent);
				_Output.Write ("connection request to be accepted without asking for further input from the user.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeMessage (Connect.ConnectPINMessagePin);
				_Output.Write ("\n{0}", _Indent);
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

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("After using the PIN code to authenticate connection of a device in the previous \n{0}", _Indent);
				_Output.Write ("example, the corresponding MessagePin is marked as having been used by appending \n{0}", _Indent);
				_Output.Write ("a completion message to the Local spool.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeMessage (Connect.ConnectPINCompleteMessage);
				_Output.Write ("\n{0}", _Indent);
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

				_Output.Write ("\n{0}", _Indent);
				  DescribeMessage (Contact.BobRequest);
				_Output.Write ("\n{0}", _Indent);
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

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Unfinished ("ProtocolGroupInvite"));
				_Output.Write ("\n{0}", _Indent);
				 DescribeMessage (Group.GroupInvitation);
				_Output.Write ("\n{0}", _Indent);
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

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The service sends out the following request:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 DescribeMessage(Confirm.RequestConfirmation);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice accepts the request and returns the following response:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 DescribeMessage(Confirm.ResponseConfirmation);
				_Output.Write ("\n{0}", _Indent);
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

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("When they meet in person, Alice creates a pin code and presents it to Bob on her mobile.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("QR code is {1} yadda yaddda\n{0}", _Indent, Contact.AliceDynamicQRCode);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The resulting contact exchange does not change the contact data itself but does change\n{0}", _Indent);
				_Output.Write ("the valudation method. It is more difficult and riskier to falsify an in-person exchange\n{0}", _Indent);
				_Output.Write ("than a remote one.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
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

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Alice creates a contact and publishes it through her service.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("QR code is {1} yadda yaddda\n{0}", _Indent, Contact.AliceStaticQRCode);
				_Output.Write ("\n{0}", _Indent);
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

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("### Phase 1:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Connect.ConnectPINCreate);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The registration of this PIN value was shown earlier in section $$$\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The URI containing the account address and PIN is:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("{1}\n{0}", _Indent, Connect.ConnectDynamicURI);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("### Phase 2:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The onboarding device scans the QR code to obtain the account address and PIN code.\n{0}", _Indent);
				_Output.Write ("The PIN code is used to authenticate a connection request:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Connect.ConnectPINRequest);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The device generates a RequestConnect message as follows:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Format (Connect.ConnectRequestPIN );
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The service receives the conenct request and authenticates the message under the\n{0}", _Indent);
				_Output.Write ("device key. The service cannot authenticate the message under the PIN code because\n{0}", _Indent);
				_Output.Write ("that is not know to the service as the service cannot decrypt the local spool.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Having authenticated the connect request, the service generates a random nonce value.\n{0}", _Indent);
				_Output.Write ("The random nonce together with the device and account profiles are used to calculate\n{0}", _Indent);
				_Output.Write ("the witness value.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The AcknowledgeConnection message is created by the service:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeMessage (Connect.ConnectPINAcknowledgeConnection);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The AcknowledgeConnection message is appended to the Inbound spool of the account\n{0}", _Indent);
				_Output.Write ("to which connection was requested so that the user can approve the request. The\n{0}", _Indent);
				_Output.Write ("ConnectResponse message is returned to the device containing the AcknowledgeConnection \n{0}", _Indent);
				_Output.Write ("message and the profile of the account.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The device generates the witness value, verifies it against the value provided by the server\n{0}", _Indent);
				_Output.Write ("and presents it to the user as seen in the console example above.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("### Phase 3:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The user synchronizes their pending messages:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Connect.ConnectPINPending);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The administration device determines that the device connection request is authenticated\n{0}", _Indent);
				_Output.Write ("by a PIN code. The PIN code is retrieved and the message authenticated. This is shown in\n{0}", _Indent);
				_Output.Write ("the PIN registration interation example in section $$$ above.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Bug: This command is currently showing superflous pending messages due to the failure to\n{0}", _Indent);
				_Output.Write ("clear messages processed in earlier examples.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Cataloged device record is created from the public key values corresponding to the\n{0}", _Indent);
				_Output.Write ("combination of the public keys in the device profile and those defined by the activation.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("This is returned to the onboarding device by wrapping it in a RespondConnection message\n{0}", _Indent);
				_Output.Write ("posted to the local spool of the account.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Format (Connect.RespondConnectionPIN );
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("### Phase 4\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The device periodically polls for completion of the connection request using the\n{0}", _Indent);
				_Output.Write ("Complete transaction.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("To provide a final check on the process, the command line tool presents the UDF of \n{0}", _Indent);
				_Output.Write ("the account profile to which the device has connected if successful:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Connect.ConnectPINComplete);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The completion request specifies the witness value for the transaction whose completion\n{0}", _Indent);
				_Output.Write ("is being queried:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  DescribeRequest (Connect.ConnectPINRequestComplete);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The Service responds to the complete request by checking to see if an entry has been \n{0}", _Indent);
				_Output.Write ("added to the local spool. If so, this contains the RespondConnection message \n{0}", _Indent);
				_Output.Write ("created by the administration device.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
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

				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("### Phase 1\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The manufacturer preconfigures the device\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Connect.ConnectStaticPrepare);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("This results in the creation of a primary secret which is used to compute a ProfileDevice\n{0}", _Indent);
				_Output.Write ("and corresponding connection records signed by the manufacturer's administrator key.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The data is combined to create a DevicePreconfiguration record that is provisioned to\n{0}", _Indent);
				_Output.Write ("the firmware of the device being preconfigured.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				 Format(Connect.ConnectStaticPreconfig);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("An EARL is created specifying the means by which an administration device can acquire the\n{0}", _Indent);
				_Output.Write ("information required to complete a connection to the device:\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("QR = {{Connect.ConnectEARL}}\n{0}", _Indent);
				_Output.Write ("~~~~\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The preconfigured ProfileDevice is encrypted under the encryption key and published to\n{0}", _Indent);
				_Output.Write ("the location key derived from the EARL.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("### Phase 2 & 3\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The administration device scans the QR code and obtains the Device Description using\n{0}", _Indent);
				_Output.Write ("the Claim operation as shown in section $$$$. The administration device creates the \n{0}", _Indent);
				_Output.Write ("ActivationDevice and CatalogedDevice records and populates the service as before.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Connect.ConnectStaticClaim);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("### Phase 4\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("The device polls the publication service until a claim message is returned.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				  ConsoleExample (Connect.ConnectStaticPollSuccess);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("### Phase 5\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
				_Output.Write ("Having been advised that an account has published a claim to bind to it, the device\n{0}", _Indent);
				_Output.Write ("posts a connection Complete request to the specified account and completes the\n{0}", _Indent);
				_Output.Write ("connection process as before.\n{0}", _Indent);
				_Output.Write ("\n{0}", _Indent);
					}
		}
	}
