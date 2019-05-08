using System;
using System.Collections.Generic;
using System.Threading;

namespace Goedel.Utilities {
    public class LockGlobal : Disposable {


        Mutex WriteLock;
        //Semaphore ReadLock;

        bool HaveWrite = false;
        //bool HaveRead = false;
        int MillisecondsTimeout;

        public int MaxRead { get; private set; }

        protected override void Disposing() {
            if (HaveWrite) {
                WriteLock?.ReleaseMutex();
                }

            WriteLock.Dispose();
            }


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


        //public void EnterReadLock() => EnterWriteLock();
        public void Enter() {
            if (HaveWrite) {
                return; // Do not try to reacquire the lock.
                }
            WriteLock.WaitOne();
            }


        public void Exit() {
            if (HaveWrite) {
                WriteLock.ReleaseMutex();
                }
            }

        }
    }
