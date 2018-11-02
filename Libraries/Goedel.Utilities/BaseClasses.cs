using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Utilities {

    /// <summary>
    /// Base class for an object that implements the standard IDisposable pattern.
    /// </summary>
    public abstract class Disposable : IDisposable {

        /// <summary>
        /// Dispose method, frees all resources.
        /// </summary>
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
            }

        bool disposed = false;
        /// <summary>
        /// Dispose method, frees resources when disposing, 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing) {
            if (disposed) {
                return;
                }

            if (disposing) {
                Disposing();
                }

            disposed = true;
            }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~Disposable() {
            Dispose(false);
            }

        /// <summary>
        /// The class specific disposal routine.
        /// </summary>
        protected virtual void Disposing() {
            }
        }



    }
