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

namespace Goedel.Utilities;

/// <summary>
/// Utility functions using reflection to extract information from the stack.
/// </summary>
public static class AssemblyStack {

    /// <summary>
    /// Return the name of the calling method.
    /// </summary>
    /// <returns>The name of the calling method.</returns>
    public static string GetMethodName() {
        var stack = new StackTrace();
        var frame = stack.GetFrame(1);
        var method = frame.GetMethod();

        return method.Name;
        }

    /// <summary>
    /// Return the name of the caller of the calling method.
    /// </summary>
    /// <returns>The name of the caller of the calling method.</returns>
    public static string GetCallerMethodName() {
        var stack = new StackTrace();
        var frame = stack.GetFrame(2);
        var method = frame.GetMethod();

        return method.Name;
        }

    /// <summary>
    /// Return the name of the caller of the calling method.
    /// </summary>
    /// <returns>The name of the caller of the calling method.</returns>
    public static string GetMethodCallingConstructorName() {
        var stack = new StackTrace();

        int index = 1;
        var frame = stack.GetFrame(index);

        while (frame != null) {
            var method = frame.GetMethod();
            if (!method.IsConstructor) {
                return method.Name;
                }

            frame = stack.GetFrame(++index);
            }

        return "Error";
        }
    }
