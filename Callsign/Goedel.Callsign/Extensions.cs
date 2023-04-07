using Goedel.Cryptography.Dare;
using Goedel.Mesh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Callsign;




public enum CallsignState {
    
    Unregistered,

    Registered,

    Bound,

    Hold
    
    }



public class ContextResolver : IResolver {

    ContextAccount ContextAccount { get; }


    public 
        ResolverServiceClient ResolverServiceClient { get; set; }

    public ContextResolver(
                ContextAccount contextAccount
                ) {
        ContextAccount = contextAccount;

        //contextAccount.CallsignResolver = this;
        }

    public bool TryResolveCallsign(string callsign, out CallsignBinding callsignBinding) {
        throw new NotImplementedException();
        }

    }



/// <summary>
/// Extensions class. Provides static convenience extensions.
/// </summary>
public static class Extensions {


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
    public static CallsignRegistrationRequest CallsignRequest(
                this ContextUser contextAccount,
                string callsign,
                string display = null,
                bool bind = false, 
                ProfileAccount transfer = null) {

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


    public static Registration ResolveCallsign(
                this ContextAccount contextAccount,
                string callsign) {

        // Make request to resolver



        throw new NYI();
        }


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

    public static CatalogedApplicationCallsign CallsignTransfer(
            this ContextAccount contextAccount,
            string callsign,
            string recipient) {

        // pull the contact entry for the recipient


        // create the transfer request


        throw new NYI();
        }


    public static List<CatalogedApplicationCallsign> ListCallsigns(
                this ContextAccount contextAccount) {

        // get the application catalog

        // print the entry for everything that is a callsign entry.



        throw new NYI();
        }


    }


