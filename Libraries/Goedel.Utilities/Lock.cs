using System;
using System.Collections.Generic;
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
                throw exception;
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
