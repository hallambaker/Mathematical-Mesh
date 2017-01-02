//   Copyright © 2015 by Comodo Group Inc.
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
//  
//  

using System.Collections.Generic;
using Goedel.Mesh;

namespace Goedel.Mesh.Platform.Windows {

    /// <summary>
    /// Base class for Mail Client integration classes.
    /// </summary>
    public abstract class IntegratorMailClient {

        /// <summary>
        /// The catalog to connect to.
        /// </summary>
        public MailClientCatalogPlatform Catalog;

        /// <summary>
        /// Enumerate the accounts supported by the client.
        /// </summary>
        public abstract void EnumerateAccounts();
        }


    public partial class MailClientCatalogPlatform : Goedel.Mesh.MailClientCatalog {

        /// <summary>
        /// Search local application configuration files to discover account 
        /// details.
        /// </summary>
        /// <returns>List of the accounts found.</returns>
        public static List<MailAccountInfo> FindLocal () {
            var MailClientCatalog = new MailClientCatalogPlatform();
            MailClientCatalog.ImportWindowsLiveMail();
            return MailClientCatalog.Accounts;
            }

        }


    }
