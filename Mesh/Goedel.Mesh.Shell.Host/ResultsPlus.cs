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


namespace Goedel.Mesh.Shell.Host;



public partial class ResultAbout {

    ///<inheritdoc/>
    public override void ToBuilder(StringBuilder builder, Verbosity verbosity = Verbosity.Standard) {

        builder.AppendLine($"{AssemblyTitle}");
        builder.AppendLine($"    {AssemblyDescription}");
        builder.AppendLine($"    Copyright         : {AssemblyCopyright} {AssemblyCompany}");
        builder.AppendLine($"    Version           : {AssemblyVersion}");
        builder.AppendLine($"    Compiled          : {Build}");
        if (verbosity == Verbosity.Full) {
            builder.AppendLine($"    Directory Profile : {DirectoryMesh}");
            builder.AppendLine($"    Directory Keys    : {DirectoryKeys}");
            }


        }
    }

public partial class ResultStartService {

    ///<summary>The RUD service that was started.</summary> 
    public RudService RudService { get; set; }
    }
