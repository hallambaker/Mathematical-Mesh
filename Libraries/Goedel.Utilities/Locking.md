# File Locking Mechanism

Two locking mechanisms are supported, `LockWriter` and `LockReadWriter` Both
use named POSIX mutexes and semphores for inter-process communication.

When locking append-only files it is sufficient to only lock the file to 
perform writes and to read past the previously read end-of-file marker.
Thus `LockWriter` is prefered.

## LockReadWriter

To lock a file `file:/c:/Example` we first convert the canonical file path to 
a UDF using the content type `application/udf-lock`.

To gain read access to the file, we acquire a semaphore on the lock name, we perform
the write and release the lock. 

To gain write access to the file, we first acquire the write Mutex, then attempt 
to acquire the full set of read semaphores to prevent a read conflict. 

After performing the write, we release the read semaphores and then the write 
mutex.

The problem with this approach is that all the processes attempting to lock the resource
need to know how many read semaphores exist so that they can acquire exclusive access.
It does not appear that the POSIX interface provides the necessary information to do the job right.

## LockWriter

To lock a file `file:/c:/Example` we first convert the canonical file path to 
a UDF using the content type `application/udf-lock`.

The lock is then used to create a Mutex of the same name. Processes requiring
write access to the file or to obtain the high watermark of the file, wait
to acquire the mutex, perform the action and release.