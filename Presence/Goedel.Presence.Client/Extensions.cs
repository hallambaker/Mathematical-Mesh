namespace Goedel.Presence.Client;



/// <summary>
/// Class containing utility extension methods.
/// </summary>
public static class Extensions {

    /// <summary>
    /// Returns a presence context for the account context <paramref name="contextAccount"/>.
    /// </summary>
    /// <param name="contextAccount">The account context to return presence context for.</param>
    /// <returns>The presence context.</returns>
    public static ContextPresence GetPresence(this ContextUser contextAccount) =>
        ContextPresence.GetContext(contextAccount);


    }