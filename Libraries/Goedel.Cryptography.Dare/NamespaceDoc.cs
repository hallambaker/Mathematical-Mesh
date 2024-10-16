﻿#region // Copyright - MIT License
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

global using System;
global using System.Collections;
global using System.Collections.Generic;
global using System.IO;
global using System.Security.Cryptography;
global using System.Text;
global using Goedel.Cryptography.Jose;
global using Goedel.Cryptography.PKIX;
global using Goedel.IO;
global using Goedel.Protocol;
global using Goedel.Utilities;

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
#if !(_Github_)
[assembly: System.Reflection.AssemblyKeyName("SigningKeyDeveloper")]
#endif

namespace Goedel.Cryptography.Dare;

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
