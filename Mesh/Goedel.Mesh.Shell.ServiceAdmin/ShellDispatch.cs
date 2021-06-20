using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Mesh.Client;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Mesh.ServiceAdmin;

using System;
using System.Collections.Generic;
using System.IO;

namespace Goedel.Mesh.Shell.ServiceAdmin {

    public partial class CommandLineInterpreter {



        }



    /// <summary>
    /// The command shell.
    /// </summary>
    public partial class Shell : _Shell {

        /// <summary>
        /// Post processing action
        /// </summary>
        /// <param name="result"></param>
        public void _PostProcess(ShellResult result) {
            }

		///<inheritdoc/>
		public override ShellResult Create(Create Options) {



			return null;
			}
		
		///<inheritdoc/>
		public override ShellResult Start(Start Options) {
			CommandLineInterpreter.DescribeValues(Options);
			return null;
			}
		
		///<inheritdoc/>
		public override ShellResult Stop(Stop Options) {
			CommandLineInterpreter.DescribeValues(Options);
			return null;
			}
		
		///<inheritdoc/>
		public override ShellResult Pause(Pause Options) {
			CommandLineInterpreter.DescribeValues(Options);
			return null;
			}
		
		///<inheritdoc/>
		public override ShellResult Fetch(Fetch Options) {
			CommandLineInterpreter.DescribeValues(Options);
			return null;
			}
		
		///<inheritdoc/>
		public override ShellResult Update(Update Options) {
			CommandLineInterpreter.DescribeValues(Options);
			return null;
			}
		
		///<inheritdoc/>
		public override ShellResult Verify(Verify Options) {
			CommandLineInterpreter.DescribeValues(Options);
			return null;
			}
		
		///<inheritdoc/>
		public override ShellResult DNS(DNS Options) {
			CommandLineInterpreter.DescribeValues(Options);
			return null;
			}
		
		///<inheritdoc/>
		public override ShellResult Credential(Credential Options) {
			CommandLineInterpreter.DescribeValues(Options);
			return null;
			}


		}


    }
