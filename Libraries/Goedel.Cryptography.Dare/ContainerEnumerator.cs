using System;
using System.Collections;
using System.Collections.Generic;

namespace Goedel.Cryptography.Dare {

    /// <summary>
    /// Enumerator that returns the raw, unencrypted container data.
    /// </summary>
    public class ContainerEnumeratorRaw : IEnumerator<DareEnvelope> {

        Sequence container;
        int lowIndex;
        bool reverse;
        bool active;

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
        public ContainerEnumeratorRaw(Sequence container, int lowIndex = 0, bool reverse = false) {
            this.container = container;
            this.lowIndex = lowIndex;
            this.reverse = reverse;
            Reset();
            }

        /// <summary>
        /// When called on an instance of this class, returns the instance. Thus allowing
        /// selectors to be used in sub classes.
        /// </summary>
        /// <returns>This instance</returns>
        public ContainerEnumeratorRaw GetEnumerator() => this;

        object IEnumerator.Current => Current;

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
            if (!reverse) {
                Current = container.ReadDirect();
                return Current != null;
                }
            if (!active) {
                return false;
                }
            Current = container.ReadDirectReverse();
            if (Current == null) {
                return false;
                }

            var header = Current.Header;
            return header.SequenceInfo.Index >= lowIndex;
            }

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element 
        /// in the collection.
        /// </summary>
        public void Reset() {
            if (reverse) {
                active = container.MoveToLast();
                }
            else {

                container.MoveToIndex(lowIndex);
                }
            }
        }

    /// <summary>
    /// Enumerator for frames in a container beginning with frame 1.
    /// </summary>
    public class ContainerEnumerator : IEnumerator<SequenceFrameIndex> {

        Sequence container;

        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        public SequenceFrameIndex Current { get; set; }



        /// <summary>
        /// Create an enumerator for <paramref name="container"/>.
        /// </summary>
        /// <param name="container">The container to enumerate.</param>
        public ContainerEnumerator(Sequence container) {
            this.container = container;
            Reset();
            }

        /// <summary>
        /// When called on an instance of this class, returns the instance. Thus allowing
        /// selectors to be used in sub classes.
        /// </summary>
        /// <returns>This instance</returns>
        public ContainerEnumerator GetEnumerator() => this;


        object IEnumerator.Current => throw new NotImplementedException();

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// 
        public void Dispose() { }

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns><code>true</code> if the enumerator was successfully advanced to the next element; 
        /// <code>false</code> if the enumerator has passed the end of the collection.</returns>
        public bool MoveNext() {
            var Result = container.NextFrame();
            Current = Result ? container.GetContainerFrameIndex() : null;
            return Result;
            }
        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the collection.
        /// </summary>
        public void Reset() {

            

            container.Start();
            
            // Hack - should pull the container frame index from the dictionary.
            
            Current = container.GetContainerFrameIndex();
            }
        }

    }
