using System;
using Goedel.Mesh;
using Goedel.Protocol;

namespace Goedel.Catalog {
    /// <summary>
    ///
    /// Mesh profile for Recrypt applications.
    /// </summary>
    public abstract partial class MeshCatalog {

        static bool _Initialized = false;

        /// <summary>Initialize the Mesh/Recrypt libraries.</summary>
        public static void Initialize() {
            if (!_Initialized) {
                MeshItem.Append(MeshCatalogData._TagDictionary);
                MeshItem.Append(_TagDictionary);
                }
            _Initialized = true;
            }

        }
    }
