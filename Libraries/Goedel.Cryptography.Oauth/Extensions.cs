namespace Goedel.Cryptography.Oauth;

public interface IKeyed {
    
    string? Id { get; }
    }

public static class Extensions {

    public static string AddPath(this string first, string path) =>
        (first[first.Length - 1] == '/') ? first + path : first + "/" + path;




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