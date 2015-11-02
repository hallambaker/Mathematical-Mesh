using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Goedel.Trojan {


    /// <summary>
    /// Parent class for all data classes
    /// </summary>
    public abstract class Data {


        public virtual Page Page {
            get { return null; }
            }


        public virtual void Initialize() {
            }

        public virtual void Enter() {
            }

        public virtual  bool Validate() {
            return true;
            }

        /// <summary>
        /// Exit method, will be called when the dialog is exited.
        /// </summary>
        /// <returns>True if exit was successful. If false, there was an error and
        /// the exit must be aborted.</returns>
        public virtual bool Exit() {
            return true;
            }
        }
    }
