using System;
using System.Collections.Generic;
using System.Threading;

namespace Goedel.Utilities {

    /// <summary>
    /// Wrapper for system wide lock with convenience accessors.
    /// </summary>
    public class LockGlobal : Disposable {


        Mutex WriteLock;
        //Semaphore ReadLock;

        bool HaveWrite = false;
        //bool HaveRead = false;
        int MillisecondsTimeout;

        ///<summary>Maximum number of readers</summary>
        public int MaxRead { get; private set; }

        /// <summary>
        /// Dispose the lock releasing all mutexes and disposing the resources correctly.
        /// </summary>
        protected override void Disposing() {
            if (HaveWrite) {
                WriteLock?.ReleaseMutex();
                }

            WriteLock.Dispose();
            }

        /// <summary>
        /// Constructor returning a lock on the resource <paramref name="resource"/> with a
        /// timeout value of <paramref name="millisecondsTimeout"/>
        /// </summary>
        /// <param name="resource">The resource to lock.</param>
        /// <param name="millisecondsTimeout">The timeout value (it less than zero wait forever).</param>
        public LockGlobal(string resource, int millisecondsTimeout = -1) {
            MillisecondsTimeout = millisecondsTimeout;
            //MaxRead = maxRead;

            try {
                WriteLock = Mutex.OpenExisting(resource);
                }
            catch (WaitHandleCannotBeOpenedException) {
                WriteLock = new Mutex(false, resource);
                }
            catch (AbandonedMutexException) {
                // When an AbandonedMutexException is raised, this means that a previous thread aborted
                // without releasing the lock. Since the thread cannot access the container, we can simply
                // reissue the request.
                WriteLock = new Mutex(false, resource);
                }
            catch (Exception exception) {
                throw exception;
                }

            }


        /// <summary>
        /// Enter the lock.
        /// </summary>
        public void Enter() {
            if (HaveWrite) {
                return; // Do not try to reacquire the lock.
                }
            WriteLock.WaitOne();
            }

        /// <summary>
        /// Exit the lock.
        /// </summary>
        public void Exit() {
            if (HaveWrite) {
                WriteLock.ReleaseMutex();
                }
            }

        }
    }
