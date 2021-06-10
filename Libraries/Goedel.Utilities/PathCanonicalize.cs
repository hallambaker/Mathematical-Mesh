using System;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Utilities {
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


        ///// <summary>
        ///// Verify that the path contains no relative references to an earlier path.
        ///// </summary>
        ///// <param name="path">The path to verify</param>
        ///// <returns>True if the path is canonical, otherwise false.</returns>
        //public static string Canonicalize(this string path) {

        //    var builder = new StringBuilder();
        //    var state = State.start;

        //    foreach (var c in path) {

        //        switch (c) {
        //            case '/':
        //            case '\\': {
        //                if (state == State.dot2) {
        //                    return false; // have encountered illegal combination.
        //                    }
        //                state = State.start;
        //                break;
        //                }
        //            case '.': {
        //                switch (state) {
        //                    case State.start: {
        //                        state = State.dot1;
        //                        break;
        //                        }
        //                    case State.dot1: {
        //                        state = State.dot2;
        //                        break;
        //                        }
        //                    case State.dot2: {
        //                        state = State.segment;
        //                        break;
        //                        }
        //                    }

        //                break;
        //                }
        //            default: {
        //                state = State.segment;
        //                break;
        //                }
        //            }
        //        }

        //    return state != State.dot2;
            //}



        }
    }
