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

global using Goedel.Cryptography;
global using Goedel.Cryptography.Dare;
global using Goedel.Cryptography.Jose;
global using Goedel.Cryptography.PKIX;
global using Goedel.IO;
global using Goedel.Mesh;
global using Goedel.Protocol;
global using Goedel.Protocol.Presentation;
global using Goedel.Utilities;
global using Microsoft.Extensions.Logging;
global using System;
global using System.Collections;
global using System.Collections.Generic;
global using System.IO;
global using System.Text;

#if !(_Github_)
[assembly: System.Reflection.AssemblyKeyName("SigningKeyDeveloper")]
#endif




namespace Goedel.Mesh;

/// <summary>
/// Mesh Protocol and Profile Definition.
/// </summary>

[System.Runtime.CompilerServices.CompilerGenerated]
class NamespaceDoc {
    }


internal class Component : IComponent {

    ///<summary> default logger for the assembly</summary> 
    public static ILogger Logger = new AssemblyLogger("Goedel.Mesh.Client") {
        LogLevel = Screen.LogLevel
        };

    ///<inheritdoc/>
    public void Initialize() {
        }

    ///<inheritdoc/>
    public void Terminate() {
        }
    }