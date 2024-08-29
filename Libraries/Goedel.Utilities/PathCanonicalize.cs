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

public static partial class Extension {
    enum State {
        initial,
        start,
        dot2,
        dot1,
        segment,
        drive
        };

    /// <summary>
    /// Verify that the path is not an absolute path and contains no relative 
    /// references to an earlier path.
    /// </summary>
    /// <param name="path">The path to verify</param>
    /// <returns>True if the path is canonical, otherwise false.</returns>
    public static bool VerifyCanonical(this string path) {

        State state = State.initial;

        foreach (var c in path) {

            switch (c) {
                case '~': {
                    if (state == State.initial) {
                        return false; // have encountered illegal combination.
                        }
                    state = State.segment;
                    break;
                    }
                case '/':
                case '\\': {
                    if ((state == State.dot2) | (state == State.initial)) {
                        return false; // have encountered illegal combination.
                        }
                    state = State.start;
                    break;
                    }
                case '.': {
                    switch (state) {
                        case State.start: {
                            state = State.dot1;
                            break;
                            }
                        case State.dot1: {
                            state = State.dot2;
                            break;
                            }
                        case State.dot2: {
                            state = State.segment;
                            break;
                            }
                        }

                    break;
                    }
                case ':': {
                    return false; // Illegal Windows drive path.
                    }
                default: {
                    var cl = Char.ToLower(c);
                    if (state == State.initial & cl >= 'a' & cl <= 'z') {
                        state = State.drive;
                        }
                    else {
                        state = State.segment;
                        }
                    break;
                    }
                }
            }

        return state != State.dot2;
        }






    }
