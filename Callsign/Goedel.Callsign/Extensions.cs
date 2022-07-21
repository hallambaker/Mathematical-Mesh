using Goedel.Cryptography.Dare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Callsign;


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
    /// <param name="registry">The registry address.</param>
    public static CallsignRegistrationRequest CallsignRequest(
                this ContextAccount contextAccount,
                string callsign,
                bool bind = false,
                string registry = null,
                string transfer = null) {

        registry ??= contextAccount.CallsignRegistry;

        var callsignBinding = new CallsignBinding() {
            Canonical = callsign.CannonicalAccountAddress(),
            Display = callsign,
            ProfileUdf = contextAccount.Profile.Udf
            };


        if (bind) {
            callsignBinding.Services = new() {
                new NamedService() {
                    Prefix = MeshService.WellKnown
                    }
                };
            }
        var envelopedBinding = callsignBinding.Envelope(signingKey: contextAccount.KeyAdministratorSign);

        var message = new CallsignRegistrationRequest() {
            Recipient = registry,
            EnvelopedCallsignBinding = new Enveloped<CallsignBinding>(envelopedBinding)
            };

        using (var transact = contextAccount.TransactBegin()) {
            transact.OutboundMessage(registry, message);
            contextAccount.Transact(transact);
            }


        return message;
        }


    ///// <summary>
    ///// Return the status of a callsign managed through this account.
    ///// </summary>
    ///// <param name="callsign"></param>
    //public void CallsignStatus(
    //            string callsign) {

    //    }

    }
