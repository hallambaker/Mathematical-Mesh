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
