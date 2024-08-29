// From Cillié Malan
// https://medium.com/@cilliemalan/how-to-await-a-cancellation-token-in-c-cbfc88f28fa2
// License is public domain
// https://creativecommons.org/publicdomain/zero/1.0/

using System.Resources;

namespace Goedel.Utilities;


/// <summary>
/// Provide a means of strongly typing a resource identifier.
/// </summary>
/// <param name="Id">The resource identifier.</param>
public record ResourceId(
            string Id) {
    }

/// <summary>
/// Resource resolution utilities.
/// </summary>
public static partial class ResourceResolver {

    ///<summary>The project wide resource manager.</summary> 
    public static ResourceManager ResourceManager { get; set; }

    ///<summary>The current culture.</summary> 
    public static CultureInfo CultureInfo { get; set; }

    /// <summary>
    /// Set the resource manager and culture.
    /// </summary>
    /// <param name="resourceManager"></param>
    /// <param name="cultureInfo"></param>
    public static void SetResourceManager(
        ResourceManager resourceManager,
        CultureInfo cultureInfo) {
        ResourceManager = resourceManager;
        CultureInfo = cultureInfo;
        }


    /// <summary>
    /// Returns the value of the specified string resource.
    /// </summary>
    /// <param name="Id">The name of the resource to retrieve.</param>
    /// <returns>The value of the resource localized for the caller's current UI culture, 
    /// or null if name cannot be found in a resource set.</returns>
    public static string GetString(string Id) => ResourceManager.GetString(Id, CultureInfo);

    /// <summary>
    /// Strongly typed means of resolving the resource identifier <paramref name="Id"/> to
    /// the corresponding resource.
    /// </summary>
    /// <param name="Id">The name of the resource to retrieve.</param>
    /// <returns>The value of the resource localized for the caller's current UI culture, 
    /// or null if name cannot be found in a resource set.</returns>
    public static string GetString(this ResourceId Id) => ResourceManager.GetString(Id.Id, CultureInfo);

    }
