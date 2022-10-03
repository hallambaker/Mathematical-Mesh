
using Goedel.Test;
using Goedel.Mesh.Test;
using Goedel.Utilities;
using Goedel.Presence.Client;
using Goedel.Mesh.Client;
using Goedel.Mesh.Shell;
using System;

namespace Goedel.XUnit;


public class TestMini : Disposable{
    public string CallerMethod { get; }
    public TestRandom Random { get; }

    
    public TestMini(string parameters = null, int count = 0) {
        CallerMethod = AssemblyStack.GetMethodCallingConstructorName();
        Random = new(CallerMethod, parameters, count);
        }

    public byte[] GetBytes(int length, string tag = null) =>
            Random.GetBytes(length, tag);

    }


public class TestEnvironmentPresence : TestEnvironmentCommon {

    public string CallerMethod { get; }
    public TestRandom Random { get; }

    protected override void Disposing() {
        // Shutdown
        }

    public TestEnvironmentPresence(string parameters=null, int count=0) {
        CallerMethod = AssemblyStack.GetMethodCallingConstructorName();
        Random = new (CallerMethod, parameters, count);
        }


    public byte[] GetBytes(int length, string tag = null) =>
        Random.GetBytes(length, tag);


    /// <summary>
    /// Make an account for address <paramref name="address"/> and establishn a presence 
    /// provider context.
    /// </summary>
    /// <param name="address">That address of the account.</param>
    /// <param name="contextAccount">The account context.</param>
    /// <param name="contextPresence">The presence context.</param>
    /// <returns>The account CLI.</returns>
    public TestCLI MakeAccount(string address, 
                out ContextUser contextAccount,
                out ContextPresence contextPresence) {

        address.SplitAccountIDService(out _, out var user);

        var cli = GetTestCLI(user + "-Admin");

        cli.ExampleNoCatch("account create {address}");
        cli.Account = address;

        contextAccount = cli.ContextUser;
        contextPresence = contextAccount.GetPresence();


        return cli;
        }

    /// <summary>
    /// Convenience constructor for all things Alice.
    /// </summary>
    /// <param name="contextAccount">The account context.</param>
    /// <param name="contextPresence">The presence context.</param>
    /// <returns></returns>
    public TestCLI GetAlice(
                out ContextUser contextAccount, 
                out ContextPresence contextPresence) =>
                        MakeAccount("alice@example.com", out contextAccount, out contextPresence);

    /// <summary>
    /// Convenience constructor for all things Bob.
    /// </summary>
    /// <param name="contextAccount">The account context.</param>
    /// <param name="contextPresence">The presence context.</param>
    public TestCLI GetBob(
                out ContextUser contextAccount,
                out ContextPresence contextPresence) =>
                MakeAccount("bob@example.com", out contextAccount, out contextPresence);


    /// <summary>
    /// Perform a contact exchange started by <paramref name="initiator"/> and returned by
    /// <paramref name="responder"/>. The URI mechanism is used. At completeion, each party has the up
    /// to date credentials of the other.
    /// </summary>
    /// <param name="initiator">The initiator of the exchange.</param>
    /// <param name="responder">The responder.</param>
    public void ExchangeContacts(
                TestCLI initiator,
                TestCLI responder
                ) {
        var resultcuri = initiator.Dispatch($"contact dynamic") as ResultPublish;

        var uri = resultcuri.Uri;
        responder.Dispatch($"contact exchange {uri}");
        initiator.Dispatch($"account sync /auto");
        }





    }
