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
    /// <param name="callsign"></param>
    /// <param name="bind"></param>
    /// <param name="transfer"></param>
    public static CallsignRegistrationRequest CallsignRequest(
                this ContextAccount contextAccount,
                string callsign,
                bool bind = false,
                string registry = null,
                string transfer = null) {



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
