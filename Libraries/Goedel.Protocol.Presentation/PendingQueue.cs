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



namespace Goedel.Protocol.Presentation;

/// <summary>
/// Implements a queue of pending items.
/// </summary>
/// <typeparam name="T"></typeparam>
public class PendingQueue<T> where T : IQueuableTask {

    #region // Properties.
    ///<summary>The wake time for the next item in the queue.</summary> 
    public DateTime WakeAt { get; private set; } = DateTime.MaxValue;

    /// <summary>
    /// Timespan giving the sleep time in ticks bounded by the Int32 maximum value
    /// so as to avoid timer length limit.
    /// </summary>
    public TimeSpan Sleep => new TimeSpan(
        (WakeAt - DateTime.Now).Ticks.BoundInt32());

    ///<summary>The number of items currently in the queue.</summary> 
    public int Count => Queue.Count;


    ///<summary>The queue itself.</summary> 
    SortedList<IQueuableTask, T> Queue { get; } = new();
    #endregion
    #region // Methods

    /// <summary>
    /// Insert the task <paramref name="task"/> in the queue with a wakeup time 
    /// of <paramref name="wakeAtTime"/> unless the item is already scheduled to be
    /// woken earlier.
    /// </summary>
    /// <param name="task">The task to queue.</param>
    /// <param name="wakeAtTime">The wakeup time.</param>
    public void Insert(T task, DateTime wakeAtTime) {
        lock (this) {
            if (Queue.TryGetValue(task, out var taskQueued)) {
                if (taskQueued.CompareTo(this) < 0) {
                    // new task is earlier, replace
                    Queue.Remove(taskQueued);
                    Add(task, wakeAtTime);
                    }
                }
            else {
                // No task is queued, add.
                Add(task, wakeAtTime);
                }
            }
        }

    /// <summary>
    /// Insert the task <paramref name="task"/> in the queue with a wakeup time 
    /// of <paramref name="wakeAtTicks"/> unless the item is already scheduled to be
    /// woken earlier.
    /// </summary>
    /// <param name="task">The task to queue.</param>
    /// <param name="wakeAtTicks">The wakeup time in ticks from the current time.</param>
    public void Insert(T task, int wakeAtTicks) =>
        Insert(task, DateTime.Now.AddTicks(wakeAtTicks));

    /// <summary>
    /// If the queue is not empty and either <paramref name="ifWoken"/> is false 
    /// or the next task in the queue is ready to run, remove the next task 
    /// in the queue and return it. Otherwise return null.
    /// </summary>
    /// <param name="ifWoken">If true, only return the next task if it is
    /// ready to be processed.</param>
    /// <returns>The next task or null if no items are pending.</returns>
    public T? Next(bool ifWoken = true) {
        lock (this) {
            if (Queue.Count == 0) {
                return default;
                }
            var next = Queue.GetValueAtIndex(0);
            if (ifWoken && next.WakeAt > DateTime.Now) {
                return default;
                }

            Queue.RemoveAt(0);
            return next;
            }
        }


    /// <summary>
    /// Remove the task <paramref name="task"/> from the queue.
    /// </summary>
    /// <param name="task">The task to remove.</param>
    public void Remove(T task) {
        lock (this) {
            if (Queue.TryGetValue(task, out var taskQueued)) {
                Queue.Remove(taskQueued);
                }
            }
        }

    /// <summary>
    /// Add the task to the queue.
    /// </summary>
    /// <param name="task"></param>
    /// <param name="wakeAt"></param>
    void Add(T task, DateTime wakeAt) {
        task.WakeAt = wakeAt;
        Queue.Add(task, task);
        if (wakeAt < WakeAt) {
            // reset the wake at time property.
            WakeAt = wakeAt;
            }
        }

    #endregion

    }


