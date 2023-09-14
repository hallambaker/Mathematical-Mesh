// From Cillié Malan
// https://medium.com/@cilliemalan/how-to-await-a-cancellation-token-in-c-cbfc88f28fa2
// License is public domain
// https://creativecommons.org/publicdomain/zero/1.0/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Utilities;

public static partial class Extension {

    /// <summary>
    /// Wait for the task <paramref name="task"/> to complete and return the result.
    /// </summary>
    /// <param name="task"></param>
    /// <returns></returns>
    public static void Sync(this Task task) => task.Wait();


    /// <summary>
    /// Wait for the task <paramref name="task"/> to complete and return the result.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="task"></param>
    /// <returns></returns>
    public static T Sync<T>(this Task<T> task) {

        try {
            task.Wait();
            }
        catch {
            }

        if (task.Exception != null) {
            if (task.Exception is System.AggregateException aggregateException) {
                throw aggregateException.InnerException;
                }
            throw task.Exception;
            }


        return task.Result;
        }


    /// <summary>
    /// Wrap the synchronous task result <paramref name="result"/> with a Task result
    /// wrapper.
    /// </summary>
    /// <typeparam name="T">The result type.</typeparam>
    /// <param name="result">The result.</param>
    /// <returns>The result.</returns>
    public static Task<T> Async<T>(this T result) => Task.FromResult(result);



    /// <summary>
    /// Allows a cancellation token to be awaited.
    /// </summary>
    /// <param name="ct">The cancellation token.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static CancellationTokenAwaiter GetAwaiter(this CancellationToken ct) {
        // return our special awaiter
        return new CancellationTokenAwaiter {
            CancellationToken = ct
            };
        }

    /// <summary>
    /// The awaiter for cancellation tokens.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct CancellationTokenAwaiter : INotifyCompletion, ICriticalNotifyCompletion {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        public CancellationTokenAwaiter(CancellationToken cancellationToken) {
            CancellationToken = cancellationToken;
            }

        internal CancellationToken CancellationToken;

        ///<inheritdoc/>
        public object GetResult() {
            // this is called by compiler generated methods when the
            // task has completed. Instead of returning a result, we 
            // just throw an exception.
            if (IsCompleted) throw new OperationCanceledException();
            else throw new InvalidOperationException("The cancellation token has not yet been cancelled.");
            }

        ///<inheritdoc/>
        public readonly bool IsCompleted => CancellationToken.IsCancellationRequested;

        ///<inheritdoc/>
        public readonly void OnCompleted(Action continuation) =>
            CancellationToken.Register(continuation);

        ///<inheritdoc/>
        public readonly void UnsafeOnCompleted(Action continuation) =>
            CancellationToken.Register(continuation);
        }

    }
