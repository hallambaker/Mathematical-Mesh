namespace Goedel.Cryptography.Oauth;

/// <summary>
/// Interface permitting selection by key using <see cref="Extensions.TryGetValue"/>
/// </summary>
public interface IKeyed {
    
    ///<summary>The keyed identifier</summary> 
    string? Id { get; }
    }

/// <summary>
/// Extensions class
/// </summary>
public static class Extensions {

    /// <summary>
    /// Append the path <paramref name="path"/> to the method/domain prefix
    /// <paramref name="first"/> adding a slash separator if required.
    /// </summary>
    /// <param name="first">The method/domain prefix</param>
    /// <param name="path">The path to append.</param>
    /// <returns>The constructed URI</returns>
    public static string AddPath(this string first, string path) =>
        (first[first.Length - 1] == '/') ? first + path : first + "/" + path;

    /// <summary>
    /// Search the list <paramref name="list"/> for the first instance matching the
    /// condition <see cref="IKeyed.Id"/> == <paramref name="key"/>. If found, the 
    /// instance is returned in <paramref name="value"/> and true is returned. Otherwise
    /// <paramref name="value"/> is null and false is returned.
    /// </summary>
    /// <typeparam name="T">The type of the list items.</typeparam>
    /// <param name="list">The list to search</param>
    /// <param name="key">The key to find</param>
    /// <param name="value">The value if found, otherwise null</param>
    /// <returns>True if the value is found, otherwise false.</returns>
    public static bool TryGetValue<T>(
                this List<T> list, string key, out T value) where T: IKeyed{
        foreach (var item in list) {
            if (key == item.Id) {
                value = item;
                return true;
                }
            }

        value = default;
        return false;
        }

    }