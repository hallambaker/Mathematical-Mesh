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


/// <summary>
/// Extensions class. Provides static convenience extensions.
/// </summary>
public static class Extensions {


    /// <summary>
    /// Make a callsign registration, binding or transfer request
    /// </summary>
    /// <param name="callsign">The presentation of the callsign to be registered.</param>
    /// <param name="bind">If true bind to the account context.</param>
    /// <param name="transfer">Transfer the callsign to the specified address.</param>
    /// <param name="contextAccount">The account context in which to make the request.</param>
    /// <param name="display">The display form of the callsign.</param>
    public static CallsignRegistrationRequest CallsignRequest(
                this ContextAccount contextAccount,
                string callsign,
                string display = null,
                bool bind = false, 
                ProfileAccount transfer = null) {


        callsign = CallsignMapping.Default.Canonicalize(CallsignMapping.Strip(callsign));
        display = display == null ? callsign : CallsignMapping.Strip(display);


        (CallsignMapping.Default.Canonicalize(display) == callsign).AssertTrue(CanonicalFormInvalid.Throw);

        var profile = transfer ?? contextAccount.Profile as ProfileAccount;

        var registry = contextAccount.CallsignRegistry;

        var callsignBinding = new CallsignBinding() {
            Canonical = callsign,
            Display = display,
            ProfileUdf = profile.UdfString
            };


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

        var enveloped = new Enveloped<Profile> (contextAccount.Profile.DareEnvelope);

        var message = new CallsignRegistrationRequest() {
            EnvelopedCallsignBinding = new Enveloped<CallsignBinding>(envelopedBinding),
            Profiles = new List<Enveloped<Profile>> () { enveloped }
            };

        using (var transact = contextAccount.TransactBegin()) {
            transact.OutboundMessageAdmin(registry, message);
            contextAccount.Transact(transact);
            }


        return message;
        }


    public static CatalogedRegistration ResolveCallsign(
            string callsign) {


        throw new NYI();
        }

    }
