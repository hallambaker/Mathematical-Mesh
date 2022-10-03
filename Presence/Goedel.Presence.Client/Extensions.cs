using Goedel.Mesh.Client;

namespace Goedel.Presence.Client;

public static class Extensions {
    
    public static ContextPresence GetPresence( this ContextUser contextAccount) =>
        ContextPresence.GetContext (contextAccount);


    }