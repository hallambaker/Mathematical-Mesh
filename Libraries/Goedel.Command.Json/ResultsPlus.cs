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


using System.Reflection.Metadata;

namespace Goedel.Command.Json;

public partial class ShellResult {

    /// <summary>
    /// Default constructor, initialize the value <see cref="Success"/> to <see langword="true"/>.
    /// </summary>
    public ShellResult() => Success = true;

    /// <summary>
    /// Returns a <see cref="StringBuilder"/> instance initialized with the success value and
    /// the expanded error message reason (if relevant).
    /// </summary>
    /// <returns>The <see cref="StringBuilder"/> instance.</returns>
    public virtual StringBuilder StringBuilder() {
        var builder = new StringBuilder();

        if (!Success == true) {
            builder.Append("ERROR");
            if (Reason != null) {
                builder.Append(" - ");
                builder.Append(Reason);
                }
            builder.Append('\n');
            }
        return builder;

        }

    ///<inheritdoc/>
    public override string ToString() {
        var builder = StringBuilder();
        ToBuilder(builder);
        return builder.ToString();
        }

    /// <summary>
    /// Converts the value of this instance to a <see langword="String"/> with 
    /// additional details.
    /// </summary>
    /// <returns>The string value.</returns>
    public virtual string Verbose() => ToString();


    /// <summary>
    /// Append the description of the report to <paramref name="builder"/>.
    /// </summary>
    /// <param name="builder">The builder to return the report to.</param>
    /// <param name="verbosity">The level of detail to return.</param>
    public virtual void ToBuilder(StringBuilder builder, Verbosity verbosity = Verbosity.Standard) {
        }
    }
