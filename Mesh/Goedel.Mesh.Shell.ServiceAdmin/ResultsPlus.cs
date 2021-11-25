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

using System.Text;


namespace Goedel.Mesh.Shell.ServiceAdmin;

public partial class ShellResult {

    /// <summary>
    /// Converts the value of this instance to a <see langword="String"/> with 
    /// additional details.
    /// </summary>
    /// <returns>The string value.</returns>
    public virtual string Verbose() => ToString();
    }

public partial class Result {

    /// <summary>
    /// Default constructor, initialize the value <see cref="Success"/> to <see langword="true"/>.
    /// </summary>
    public Result() => Success = true;

    /// <summary>
    /// Returns a <see cref="StringBuilder"/> instance initialized with the success value and
    /// the expanded error message reason (if relevant).
    /// </summary>
    /// <returns>The <see cref="StringBuilder"/> instance.</returns>
    public virtual StringBuilder StringBuilder() {
        var Builder = new StringBuilder();

        if (!Success) {
            Builder.Append("ERROR");
            if (Reason != null) {
                Builder.Append(" - ");
                Builder.Append(Reason);
                }
            Builder.Append("\n");
            }
        return Builder;

        }

    /// <summary>
    /// Converts the value of this instance to a <see langword="String"/>.
    /// </summary>
    /// <returns>The current string.</returns>
    public override string ToString() {
        var Builder = StringBuilder();

        return Builder.ToString();
        }



    }
