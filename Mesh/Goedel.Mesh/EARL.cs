using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Mesh {

    ///<summary>Encrypted Authenticated Resource Locator support.</summary>
    public class EARL {

        /// <summary>
        /// Encode an EARL
        /// </summary>
        /// <param name="input"></param>
        /// <param name="outputDirectory"></param>
        /// <param name="outputFile"></param>
        /// <param name="domain"></param>
        /// <param name="log"></param>
        /// <param name="recipient">The recipient account under which the </param>
        /// <returns>The EARL</returns>
        public static string Encode(
                    string input,
                    out string outputFile,
                    string domain = null,
                    string outputDirectory = null,
                    string log = null,
                    string recipient = null) {

            throw new NYI();
            }


        }
    }
