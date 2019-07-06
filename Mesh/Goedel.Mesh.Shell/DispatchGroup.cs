using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.IO;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh.Shell {
    public partial class Shell {

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult GroupAdd(GroupAdd Options) {
            using (var contextAccount = GetContextAccount(Options)) {

                var result = new Result() {

                    };
                throw new NYI();
                //return result;
                }
            
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult GroupCreate(GroupCreate Options) {
            using (var contextAccount = GetContextAccount(Options)) {

                var result = new Result() {

                    };
                throw new NYI();
                //return result;
                }
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult GroupDelete(GroupDelete Options) {
            using (var contextAccount = GetContextAccount(Options)) {

                var result = new Result() {

                    };
                throw new NYI();
                //return result;
                }
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult GroupList(GroupList Options) {
            using (var contextAccount = GetContextAccount(Options)) {

                var result = new Result() {

                    };
                throw new NYI();
                //return result;
                }
            }


        }
    }
