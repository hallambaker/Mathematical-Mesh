//  Copyright © 2021 by Threshold Secrets Llc.
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.

using Goedel.Cryptography.Dare;
using Goedel.Mesh.Client;
using Goedel.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Goedel.Callsign.Resolver;


/// <summary>
/// The resolver server.
/// </summary>
public class ResolverServer  {
    #region // Properties

    ///<summary>The resolver client context.</summary> 
    ContextResolver ContextResolver { get; }

    ///<summary>Resolver client configuration.</summary> 
    CatalogedMachine CatalogedMachine { get; }

    #endregion
    #region // Constructors

    /// <summary>
    /// Constructs an instance of a Callsign resolver service bound to the registry 
    /// specified in <paramref name="catalogedMachine"/>.
    /// </summary>
    /// <param name="meshHost">The Mesh host.</param>
    /// <param name="catalogedMachine">The resolver client description.</param>
    public ResolverServer  (
                MeshHost meshHost,
                CatalogedService catalogedMachine) {



        // pull up client here.
        ContextResolver = new ContextResolver(meshHost, catalogedMachine);
        }



    #endregion
    #region // Implement Inteface $$$
    #endregion
    #region // Override Methods
    #endregion
    #region // Methods

    /// <summary>
    /// Update dispatch
    /// </summary>
    public void Update() {

        //Synchronize client
        ContextResolver.Update();

        }

    /// <summary>
    /// Resolver dispatch.
    /// </summary>
    /// <param name="callsign">The callsign to resolve.</param>
    /// <returns>The resolution result.</returns>
    public Enveloped<Registration> Resolve(string callsign) {
        
        // Get callsign data and return.
        
        return ContextResolver.Resolve (callsign);
        }


    #endregion
    }
