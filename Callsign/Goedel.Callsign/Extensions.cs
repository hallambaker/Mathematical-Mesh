using Goedel.Cryptography.Dare;
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
    /// <param name="registry">The registry address.</param>
    public static CallsignRegistrationRequest CallsignRequest(
                this ContextAccount contextAccount,
                string callsign,
                bool bind = false,
                ProfileAccount transfer = null) {

        
        var profile = transfer ?? contextAccount.Profile as ProfileAccount;


        var registry = contextAccount.ProfileRegistryCallsign;

        var callsignBinding = new CallsignBinding() {
            Canonical = callsign.CannonicalAccountAddress(),
            Display = callsign,
            ProfileUdf = profile.Udf
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

        var message = new CallsignRegistrationRequest() {
            EnvelopedCallsignBinding = new Enveloped<CallsignBinding>(envelopedBinding)
            };

        using (var transact = contextAccount.TransactBegin()) {
            transact.OutboundMessage(registry.AccountAddress, message);
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
