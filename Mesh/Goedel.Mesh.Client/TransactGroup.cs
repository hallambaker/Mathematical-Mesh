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


namespace Goedel.Mesh.Client {
    /// <summary>
    /// Transaction on a Mesh group account. Provides access to the account catalogs and spools.
    /// </summary>
    public partial class TransactGroup : Transaction<ContextGroup> {

        /// <summary>The account context in which this transaction takes place.</summary>
        public override ContextGroup ContextAccount => ContextGroup;

        /// <summary>The account context in which this transaction takes place.</summary>
        public ContextGroup ContextGroup { get; }

        /// <summary>
        /// Constructor creating transaction instance under the account context
        /// <paramref name="contextGroup"/>
        /// </summary>
        /// <param name="contextGroup">The account context in which the update
        /// is to be applied.</param>
        public TransactGroup(ContextGroup contextGroup) => ContextGroup = contextGroup;

        ///<summary>Returns the network catalog for the account</summary>
        public CatalogMember GetCatalogMember() => ContextGroup.GetStore(CatalogMember.Label) as CatalogMember;

        }
    }
