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
using System;
using System.Threading;

namespace Goedel.Utilities {

    /// <summary>
    /// Wrapper for system wide lock with convenience accessors.
    /// </summary>
    public class LockGlobal : Disposable {


        Mutex writeLock;
        //Semaphore ReadLock;

        bool haveWrite = false;
        //bool HaveRead = false;
        int millisecondsTimeout;

        ///<summary>Maximum number of readers</summary>
        public int MaxRead { get; private set; }

        /// <summary>
        /// Dispose the lock releasing all mutexes and disposing the resources correctly.
        /// </summary>
        protected override void Disposing() {
            if (haveWrite) {
                writeLock?.ReleaseMutex();
                }

            writeLock.Dispose();
            }

        /// <summary>
        /// Constructor returning a lock on the resource <paramref name="resource"/> with a
        /// timeout value of <paramref name="millisecondsTimeout"/>
        /// </summary>
        /// <param name="resource">The resource to lock.</param>
        /// <param name="millisecondsTimeout">The timeout value (it less than zero wait forever).</param>
        public LockGlobal(string resource, int millisecondsTimeout = -1) {
            this.millisecondsTimeout = millisecondsTimeout;
            //MaxRead = maxRead;

            try {
                writeLock = Mutex.OpenExisting(resource);
                }
            catch (WaitHandleCannotBeOpenedException) {
                writeLock = new Mutex(false, resource);
                }
            catch (AbandonedMutexException) {
                // When an AbandonedMutexException is raised, this means that a previous thread aborted
                // without releasing the lock. Since the thread cannot access the container, we can simply
                // reissue the request.
                writeLock = new Mutex(false, resource);
                }
            catch (Exception exception) {
                exception.Future();
                throw;
                }

            }


        /// <summary>
        /// Enter the lock.
        /// </summary>
        public void Enter() {
            if (haveWrite) {
                return; // Do not try to reacquire the lock.
                }
            writeLock.WaitOne(millisecondsTimeout);
            }

        /// <summary>
        /// Exit the lock.
        /// </summary>
        public void Exit() {
            if (haveWrite) {
                writeLock.ReleaseMutex();
                }
            }

        }
    }
