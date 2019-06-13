using System;
using System.Collections;
using System.Collections.Generic;

namespace Goedel.Cryptography.Dare {

    /// <summary>
    /// Enumerator that returns the raw, unencrypted container data.
    /// </summary>
    public class ContainerEnumeratorRaw : IEnumerator<DareEnvelope> {

        Container Container;
        int LowIndex;
        bool Reverse;
        bool Active;

        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        public DareEnvelope Current { get; private set; } = null;


        /// <summary>
        /// Create an enumerator for <paramref name="container"/>.
        /// </summary>
        /// <param name="lowIndex">The lowest index to be returned.</param>
        /// <param name="reverse">If true, enumeratre from the last item to <paramref name="lowIndex"/> (inclusive).
        /// otherwise, enumerate from <paramref name="lowIndex"/> to the first.</param>
        /// <param name="container">The container to enumerate.</param>
        public ContainerEnumeratorRaw(Container container, int lowIndex = 0, bool reverse = false) {
            this.Container = container;
            LowIndex = lowIndex;
            Reverse = reverse;
            Reset();
            }

        /// <summary>
        /// When called on an instance of this class, returns the instance. Thus allowing
        /// selectors to be used in sub classes.
        /// </summary>
        /// <returns>This instance</returns>
        public ContainerEnumeratorRaw GetEnumerator() => this;

        object IEnumerator.Current => throw new NotImplementedException();

        /// <summary>
        /// Dispose method.
        /// </summary>
        public void Dispose() { }

        /// <summary>
        /// Move to the next item in the enumeration.
        /// </summary>
        /// <returns>If true, the next item was found. Otherwise, the end of the enumeration 
        /// was reached.</returns>
        public bool MoveNext() {
            if (!Reverse) {
                Current = Container.ReadDirect();
                return Current != null;
                }
            if (!Active) {
                return false;
                }
            Current = Container.ReadDirectReverse();
            if (Current==null) {
                return false;
                }

            var header = Current.Header as ContainerHeader;
            return header.Index >= LowIndex;
            }

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element 
        /// in the collection.
        /// </summary>
        public void Reset() {
            if (Reverse) {
                Active = Container.MoveToLast();
                }
            else {

                Container.MoveToIndex(LowIndex);
                }
            }
        }

    /// <summary>
    /// Enumerator for frames in a container beginning with frame 1.
    /// </summary>
    public class ContainerEnumerator : IEnumerator<ContainerDataReader> {

        Container Container;

        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        public ContainerDataReader Current => _Current;
        ContainerFrameReader _Current = null;



        /// <summary>
        /// Create an enumerator for <paramref name="container"/>.
        /// </summary>
        /// <param name="container">The container to enumerate.</param>
        public ContainerEnumerator(Container container) {
            this.Container = container;
            Reset();
            }

        /// <summary>
        /// When called on an instance of this class, returns the instance. Thus allowing
        /// selectors to be used in sub classes.
        /// </summary>
        /// <returns>This instance</returns>
        public ContainerEnumerator GetEnumerator() => this;


        object IEnumerator.Current => throw new NotImplementedException();
        private object Current1 => Current;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() => _Current?.Close();

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns><code>true</code> if the enumerator was successfully advanced to the next element; 
        /// <code>false</code> if the enumerator has passed the end of the collection.</returns>
        public bool MoveNext() {
            var Result = Container.NextFrame();
            _Current = Result ? Container.GetFrameDataReader() : null;
            return Result;
            }
        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the collection.
        /// </summary>
        public void Reset() {
            Container.Start();
            _Current = Container.GetFrameDataReader();
            }
        }

    }
