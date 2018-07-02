#if !(__MonoCS__)
[assembly: System.Reflection.AssemblyKeyName("SigningKeyDeveloper")]
#endif

namespace Goedel.Cryptography.Dare {

    /// <summary>
    /// Classes to manage a JBCD Container file.
    /// 
    /// <para>All JBCD Containers support efficient append only access with 
    /// efficient read-only access in both the forward and the reverse 
    /// directions.</para>
    /// 
    /// <para>Setting the IsTree parameter to true when a container is 
    /// first created causes a binary tree structure to be embedded into
    /// the file as it is written. This incurs a modest (log n) performance
    /// penalty on write but enables efficient random access (log n).</para>
    /// 
    /// <para>Either type of container may be protected against an insertion
    /// attack with the use of a chained digest. If the container type if a 
    /// binary tree, a Merkle Tree is constructed. Otherwise, a simple chain 
    /// construction is used.</para>
    /// </summary>

    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc {
        }

    }
