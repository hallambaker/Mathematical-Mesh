//Sample license text.
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Goedel.Trojan {


    /// <summary>
    /// Parent class for all data classes
    /// </summary>
    public abstract class Data {

        /// <summary>
        /// Return the corresponding WPF Page.
        /// </summary>
        public virtual Page Page {
            get { return null; }
            }

        /// <summary>
        /// This method is called whenever a new data class is created. Can be 
        /// overriden to implement desired functionality.
        /// </summary>
        public virtual void Initialize() {
            }

        /// <summary>
        /// This method is called whenever a page is entered or rentered. Can be 
        /// overriden to implement desired functionality.
        /// </summary>
        public virtual void Enter() {
            }

        /// <summary>
        /// This method is called whenever a page is left. Can be 
        /// overriden to implement desired functionality.
        /// </summary>
        /// <returns>If the function returns false, the sequencer will ignore
        /// the next page indicated by the generator. This allows exceptions to
        /// the generator behavior to be specified.</returns>
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
