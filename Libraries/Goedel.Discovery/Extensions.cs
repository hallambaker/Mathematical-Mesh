//  This file was automatically generated at 8/30/2023 5:04:13 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  fsrgen version 3.0.0.865
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.22621.0
//  
//  


// Goedel.Discovery
namespace Goedel.Discovery;

/// <summary>
/// Extensions class. Provides static convenience extensions.
/// </summary>
public static class Extensions {


    /// <summary>
    /// Attempt to parse <paramref name="identifier"/> returning
    /// <code>true</code> if it is a valid service address and <code>false</code> otherwise.
    /// </summary>
    /// <param name="identifier">The address to parse.</param>
    /// <returns><code>true</code> if <paramref name="identifier"/> is a valid service address 
    /// and <code>false</code> otherwise.</returns>
    public static bool TryParseServiceAddress(
            this string identifier) => ServiceAddress.TryParse(identifier, out _);

    /// <summary>
    /// Attempt to parse <paramref name="identifier"/> returning
    /// <code>true</code> if it is a valid service address and <code>false</code> otherwise.
    /// </summary>
    /// <param name="serviceAddress">The parsed value.</param>
    /// <param name="identifier">The address to parse.</param>
    /// <returns><code>true</code> if <paramref name="identifier"/> is a valid service address 
    /// and <code>false</code> otherwise.</returns>
    public static bool TryParseServiceAddress(
                    this string identifier,
                    out ServiceAddress serviceAddress) => ServiceAddress.TryParse(identifier, out serviceAddress);



    }