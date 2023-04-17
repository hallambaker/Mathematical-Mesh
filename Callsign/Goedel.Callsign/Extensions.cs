using Goedel.Cryptography.Dare;
using Goedel.Mesh;
using Goedel.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Callsign;



/// <summary>
/// Callsign state values.
/// </summary>
public enum CallsignState {
    ///<summary>The callsign is not registered.</summary> 
    Unregistered,

    ///<summary>The callsign is registered but not bound to a service address.</summary> 
    Registered,

    ///<summary>The callsign is registered and bound to a service address.</summary> 
    Bound,

    ///<summary>The callsign is registered but the registration is on hold.</summary> 
    Hold

    }


/// <summary>
/// Context resolver class, binds a 
/// </summary>
public class ContextResolver : IResolver {


    ContextAccount ContextAccount { get; }

    ///<summary></summary> 
    public  ResolverServiceClient ResolverServiceClient { get; set; }

    /// <summary>
    /// Constructor returning an instance bound to the account context <paramref name="contextAccount"/>.
    /// </summary>
    /// <param name="contextAccount">The account context using the resolver.</param>
    public ContextResolver(
                ContextAccount contextAccount
                ) {
        ContextAccount = contextAccount;

        //contextAccount.CallsignResolver = this;
        }

    ///<inheritdoc/>
    public bool TryResolveCallsign(string callsign, out CallsignBinding callsignBinding) {
        throw new NotImplementedException();
        }

    }



/// <summary>
/// Extensions class. Provides static convenience extensions.
/// </summary>
public static class Extensions {



#pragma warning disable CA2255 // The 'ModuleInitializer' attribute should be used in libraries!
    [ModuleInitializer]
    internal static void Initialize() {
        ContextUser.ProcessDictionary.Add(typeof(CallsignRegistrationResponse), ProcessMessage);
        }
#pragma warning restore CA2255 // The 'ModuleInitializer' attribute should be used in libraries!

    /// <summary>
    /// Return the callsign resolver for the account context <paramref name="contextAccount"/>.
    /// </summary>
    /// <param name="contextAccount">Account context.</param>
    /// <returns>The resolver.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IResolver GetResolver(
                this ContextAccount contextAccount) {
        if (contextAccount == null) {
            throw new ArgumentNullException(paramName: nameof(contextAccount));
            }
        if (contextAccount.CallsignResolver != null) {
            return contextAccount.CallsignResolver;
            }

        return new ContextResolver(contextAccount);

        }

    /// <summary>
    /// Attempt resolution of the callsign <paramref name="callsign"/> from the account context
    /// <paramref name="contextAccount"/>. If successful, the value true is returned and 
    /// the binding returned in <paramref name="callsignBinding"/>. Otherwise the value
    /// false is returned and null.
    /// </summary>
    /// <param name="contextAccount">Account context.</param>
    /// <param name="callsign">The callsign to query.</param>
    /// <param name="callsignBinding">The result of attempting to resolve the callsign.</param>
    /// <returns>True if the callsign resolved to a registration, otherwise false.</returns>
    public static bool TryResolveCallsign(
                this ContextAccount contextAccount,
                string callsign, 
                out CallsignBinding callsignBinding) {
        var resolver = contextAccount.GetResolver();
        return resolver.TryResolveCallsign(callsign, out callsignBinding);
        }



    /// <summary>
    /// Make a callsign registration, binding or transfer request
    /// </summary>
    /// <param name="callsign">The presentation of the callsign to be registered.</param>
    /// <param name="bind">If true bind to the account context.</param>
    /// <param name="transfer">Transfer the callsign to the specified address.</param>
    /// <param name="contextAccount">The account context in which to make the request.</param>
    /// <param name="display">The display form of the callsign.</param>
    /// <param name="transferUdf">UDF of party to be given ability to control the callsign binding.</param>
    public static CallsignRegistrationRequest CallsignRequest(
                this ContextUser contextAccount,
                string callsign,
                string display = null,
                bool bind = false, 
                ProfileAccount transfer = null,
                string transferUdf = null) {

        display = CallsignMapping.Strip(display ?? callsign);
        callsign = CallsignMapping.Default.Canonicalize(CallsignMapping.Strip(callsign));



        (CallsignMapping.Default.Canonicalize(display) == callsign).AssertTrue(CanonicalFormInvalid.Throw);

        var profile = transfer ?? contextAccount.Profile as ProfileAccount;

        var registry = contextAccount.CallsignRegistry;

        var callsignBinding = new CallsignBinding() {
            Canonical = callsign,
            Display = display,
            ServiceAddress = contextAccount.AccountAddress,
            };

        if (contextAccount.Profile is ProfileAccount profileAccount) {
            callsignBinding.CommonEncryption = profileAccount.CommonEncryption;
            }

        if (transfer == null) {
            callsignBinding.ProfileUdf = contextAccount.Profile.UdfString;
            callsignBinding.TransferUdf = transferUdf;
            }
        else {
            callsignBinding.TransferUdf = transfer.UdfString;
            }



        if (bind) {
            var service = profile.AccountAddress.GetService();
            callsignBinding.Services = new() {
                new NamedService() {
                    Prefix = MeshService.WellKnown,
                    Endpoints = new() { service }
                    }
                };
            }
        var envelopedBinding = callsignBinding.Envelope(signingKey: contextAccount.KeyAdministratorSign);

        var envelopedProfile = new Enveloped<Profile> (contextAccount.Profile.DareEnvelope);

        var message = new CallsignRegistrationRequest() {
            EnvelopedCallsignBinding = new Enveloped<CallsignBinding>(envelopedBinding),
            Profiles = new List<Enveloped<Profile>> () { envelopedProfile }
            };




        using (var transact = contextAccount.TransactBegin()) {
            // need to add copy to self here!
            transact.OutboundMessageAdmin(registry, message);

            var envelopedBindingTyped = new Enveloped<CallsignBinding>(envelopedBinding);
            var application = new CatalogedApplicationCallsign {
                CallSign = callsign,
                RequestId = message.MessageId,
                EnvelopedCallsignBinding = envelopedBindingTyped
                };

            var applicationCatalog = transact.GetCatalogApplication();
            transact.CatalogUpdate(applicationCatalog, application);

            contextAccount.Transact(transact);
            }


        return message;
        }


    /// <summary>
    /// Resolve the callsign <paramref name="callsign"/> using the account context
    /// <paramref name="contextAccount"/>.
    /// </summary>
    /// <param name="contextAccount">The account context.</param>
    /// <param name="callsign">The callsign to resolve.</param>
    /// <returns>The callsign registration.</returns>
    public static Registration ResolveCallsign(
                this ContextAccount contextAccount,
                string callsign) {

        // Make request to resolver



        throw new NYI();
        }

    /// <summary>
    /// Return the status of the callsign registration <paramref name="callsign"/> within the 
    /// account context <paramref name="contextAccount"/>.
    /// </summary>
    /// <param name="contextAccount">The account context.</param>
    /// <param name="callsign">The callsign to query.</param>
    /// <returns></returns>
    public static CatalogedApplicationCallsign CallsignRequestStatus(
                this ContextUser contextAccount,
                string callsign) {

        contextAccount.Sync();
        contextAccount.ProcessAutomatics();

        // synchronize the account and process messages
        var canonical = CallsignMapping.Default.Canonicalize(CallsignMapping.Strip(callsign));
        var key = CatalogedApplicationCallsign.GetKey(canonical);
        var catalogedApplication = contextAccount.GetApplication(key);
        // pull the application entry

        return catalogedApplication as CatalogedApplicationCallsign;
        }

    /// <summary>
    /// Transfer the callsign <paramref name="callsign"/> to <paramref name="recipient"/>.
    /// </summary>
    /// <param name="contextAccount">The account context to which the callsikgn is currently bound.</param>
    /// <param name="callsign">The callsign to transfer.</param>
    /// <param name="recipient">The party to receive the callsign.</param>
    /// <returns>The resulting registration request (if successful), otherwise
    /// throws an exception.</returns>
    public static CallsignRegistrationRequest CallsignTransfer(
            this ContextUser contextAccount,
            string callsign,
            string recipient) {

        // pull the contact entry for the recipient
        var contact = contextAccount.GetContact (recipient);

        var profile = GetProfile (contact.Contact, recipient);
        // create the transfer request
        return contextAccount.CallsignRequest(callsign, bind:false, transfer: profile );

        }

    /// <summary>
    /// Return the Mesh profile bound to the address <paramref name="address"/>
    /// in the contact assertion <paramref name="contact"/>.
    /// </summary>
    /// <param name="contact">The contact assertion to return.</param>
    /// <param name="address">The address (used to disambiguate multiple 
    /// profiles bound to the same contact).</param>
    /// <returns>The account profile.</returns>
    static ProfileAccount GetProfile(Contact contact, string address) {
        foreach (var entry in contact.NetworkAddresses) {
            if (entry.Address == address) {
                var profile = entry.EnvelopedProfileAccount.Decode();
                return profile;

                }
            }

        return null;
        }

    /// <summary>
    /// List the callsigns owned by <paramref name="contextAccount"/>.
    /// </summary>
    /// <param name="contextAccount">The account context.</param>
    /// <returns>The list of callsign application bindings.</returns>
    public static List<CatalogedApplicationCallsign> ListCallsigns(
                this ContextUser contextAccount) {

        // get the application catalog
        var catalog = contextAccount.GetStore(CatalogApplication.Label) as CatalogApplication;

        var result = new List<CatalogedApplicationCallsign>();

        // print the entry for everything that is a callsign entry.
        foreach (var application in catalog) {
            if (application is CatalogedApplicationCallsign applicationCallsign) {
                result.Add(applicationCallsign);
                // ToDo: here we will eventually YIELD
                }

            }


        return result;
        }

    /// <summary>
    /// Process CallsignRegistrationResponse messages in context.
    /// </summary>
    /// <param name="contextUser">The user context to process the message.</param>
    /// <param name="meshMessage">The message to process, must be of type CallsignRegistrationResponse.</param>
    /// <param name="accept">Ignored</param>
    /// <param name="reciprocate">Ignored</param>
    /// <param name="roles">Ignored</param>
    /// <returns>The result of processing the message.</returns>
    public static ProcessResult ProcessMessage(
                ContextUser contextUser,
                Message meshMessage, bool accept = true, bool reciprocate = true,
                List<string> roles = null) {

        ProcessResult result;

        // here we need to:
        var message = meshMessage as CallsignRegistrationResponse;

        // fetch the corresponding request

        // mark the status of the request


        // return the result of processing.
        using var transact = contextUser.TransactBegin();
        var applicationCatalog = transact.GetCatalogApplication();


        var key = CatalogedApplicationCallsign.GetKey(message.Callsign);
        if (applicationCatalog.TryLocate(key, out var application)) {
            var applicationCallsign = application as CatalogedApplicationCallsign;

            result = new ProcessResultCallsign() {
                CatalogedApplicationCallsign = applicationCallsign,
                };
            if (message.Registered != true) {
                //applicationCallsign
                applicationCallsign.RequestId = null;
                applicationCallsign.Reason = message.Reason;
                result.Success = false;
                result.ErrorReport = message.Reason;
                }
            else {
                applicationCallsign.CatalogedRegistration = message.CatalogedRegistration;
                result.Success = true;
                }
            applicationCatalog.Update(applicationCallsign);


            }

        else {
            // Response received for unknown callsign request.

            // This could be a transfer of course.


            result = new ProcessResultNotFound() {
                };
            }

        result.MessageId = message.MessageId;
        result.Sender = message.Sender;
        result.Recipient = message.Recipient;

        transact.InboundComplete(StateSpoolMessage.Closed, meshMessage);
        transact.Transact();


        return result;
        }


    }


