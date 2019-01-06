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
        public override ShellResult ContainerCreate(ContainerCreate Options) {
            var inputFile = Options.Output.Value;

            using (var container = Container.Open(
                inputFile, containerType: ContainerType.MerkleTree)) {
                }

            return new ResultFile() {
                Filename = inputFile
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContainerArchive(ContainerArchive Options) {
            var inputFile = Options.Output.Value;

            using (var container = Container.Open(
                inputFile, containerType: ContainerType.MerkleTree)) {
                }

            return new ResultFile() {
                Filename = inputFile
                };
            }

        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContainerAppend(ContainerAppend Options) {
            var inputFile = Options.Output.Value;

            using (var container = Container.Open(
                inputFile, containerType: ContainerType.MerkleTree)) {
                }

            return new ResultFile() {
                Filename = inputFile
                };
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContainerIndex(ContainerIndex Options) {
            var inputFile = Options.Input.Value;

            using (var container = Container.Open(
                inputFile, containerType: ContainerType.MerkleTree)) {
                }

            return new ResultFile() {
                Filename = inputFile
                };
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContainerExtract(ContainerExtract Options) {
            var inputFile = Options.Input.Value;
            var outputFile = Options.Output.Value;

            using (var container = Container.Open(
                inputFile, containerType: ContainerType.MerkleTree)) {
                }

            return new ResultFile() {
                Filename = inputFile
                };
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContainerCopy(ContainerCopy Options) {
            var inputFile = Options.Input.Value;
            var outputFile = Options.Output.Value;

            using (var container = Container.Open(
                inputFile, containerType: ContainerType.MerkleTree)) {
                }

            return new ResultFile() {
                Filename = inputFile
                };
            }


        /// <summary>
        /// Dispatch method
        /// </summary>
        /// <param name="Options">The command line options.</param>
        /// <returns>Mesh result instance</returns>
        public override ShellResult ContainerVerify(ContainerVerify Options) {
            var inputFile = Options.Input.Value;

            using (var container = Container.Open(
                inputFile, containerType: ContainerType.MerkleTree)) {
                }

            return new ResultFile() {
                Filename = inputFile
                };
            }




        }
    }
