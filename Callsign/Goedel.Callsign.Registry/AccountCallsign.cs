

namespace Goedel.Callsign.Registry;

/// <summary>
/// Context for managing the callsign registry account.
/// </summary>
public class ContextCallsign : ContextAccount {

    ///<inheritdoc/>
    public override Profile Profile => throw new NotImplementedException();

    ///<inheritdoc/>
    public override Connection Connection => throw new NotImplementedException();

    ///<inheritdoc/>
    public override string AccountAddress => "@registry" ;


    /// <summary>
    /// Constructor, creates a <see cref="ContextUser"/> instance for the catalog entry 
    /// <paramref name="catalogedMachine"/> on machine <paramref name="meshHost"/>.
    /// </summary>
    /// <param name="catalogedMachine">Description of the device profile.</param>
    /// <param name="meshHost">The Mesh host to add the admin context to.</param>
    public ContextCallsign(
            MeshHost meshHost,
            CatalogedMachine catalogedMachine) : base (meshHost, catalogedMachine) {
        }



    public void Process() {

        }


    }
