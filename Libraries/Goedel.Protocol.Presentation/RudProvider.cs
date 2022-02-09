#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
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
#endregion

namespace Goedel.Protocol.Presentation;





/// <summary>
/// Service provider class.
/// </summary>
public class RudProvider : Disposable, IConfguredService {
    #region // Properties
    ///<summary>The provider interface.</summary> 
    public JpcInterface JpcInterface { get; }



    ///<summary>The service endpoints.</summary> 
    public List<Endpoint> Endpoints { get; }

    #endregion
    #region // Constructor
    /// <summary>
    /// Constructor, returns an instance servicing the endpoints <paramref name="endpoints"/>
    /// </summary>
    /// <param name="endpoints">The endpoints to be serviced.</param>
    /// <param name="jpcProvider">The service provider.</param>
    public RudProvider(List<Endpoint> endpoints, JpcInterface jpcProvider) {
        JpcInterface = jpcProvider;
        Endpoints = endpoints;
        }

    #endregion
    #region // Convenience Methods



    #endregion

    }
