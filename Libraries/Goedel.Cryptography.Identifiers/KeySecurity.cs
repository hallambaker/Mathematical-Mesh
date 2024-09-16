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


namespace Goedel.Cryptography;

///<summary>Enumeration specifying whether the key is public or private and if private,
///the storage model.</summary>
[Flags]
public enum KeySecurity {

    ///<summary>Null Flags.</summary>
    Null = 0,

    ///<summary>Flag indicating that the private key has been persisted to the local machine</summary>
    Persisted = 0b0001,

    ///<summary>Flag indicating that the private key may be persisted to the local machine.</summary>
    Persistable = 0b0010,

    ///<summary>Flag indicating that the private key may be stored in an in-memory
    ///structure (e.g. key collection) but not persisted.</summary>
    Session = 0b0100,

    ///<summary>Flag indicating that the private key may be exported.</summary>
    Exportable = 0b01000,


    ///<summary>Private key that cannot be exported or persisted.</summary>
    Ephemeral = Null,

    ///<summary>Private key that is stored on the local machine and cannot be exported.</summary>
    Bound = Persistable,

    ///<summary>Flag indicating that the private key has been store and may be exported.</summary>
    ExportableStored = Persistable | Exportable,

    ///<summary>Key is public only.</summary>
    Public = 0b10000,

    /// <summary>
    /// Key is a Mesh master key and will be stored in a key container marked 
    /// as archivable and user protected. Master keys SHOULD be deleted after 
    /// being escrowed and recovery verified.
    /// </summary>
    Master = ExportableStored,

    /// <summary>
    /// Key is a Mesh administration key and will be  stored in a key container marked as non 
    /// exportable and user protected.
    /// </summary>
    Admin = Bound,

    /// <summary>
    /// Key is Mesh a device key and will be  stored in a key container bound to 
    /// the current machine that cannot be exported or archived.
    /// </summary>
    Device = Bound

    }
