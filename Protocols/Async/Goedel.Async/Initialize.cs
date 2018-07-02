using System;
using Goedel.Mesh;
using Goedel.Protocol;

namespace Goedel.Async {
    /// <summary>
    ///
    /// Mesh profile for Recrypt applications.
    /// </summary>
    public abstract partial class MeshAsync {

        static bool _Initialized = false;

        /// <summary>Initialize the Mesh/Recrypt libraries.</summary>
        public static void Initialize() {
            if (!_Initialized) {
                MeshItem.Append(_TagDictionary);
                }
            _Initialized = true;
            }

        }
    }
