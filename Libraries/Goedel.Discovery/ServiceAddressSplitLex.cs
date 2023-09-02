//  Copyright (c) 2023 by Threshold Secrets
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
//  
//  

using Goedel.FSR;

using Microsoft.Extensions.Primitives;

using System.Runtime.CompilerServices;

namespace Goedel.Discovery;

/// <summary>
/// FSM parser to break down 
/// </summary>
public partial class ServiceAddressSplitLex {


    ServiceAddressType serviceAddressType = ServiceAddressType.Invalid;


    ///<summary>The builer we build to.</summary>
    readonly StringBuilder buildActive = new();

    ///<summary>The accumulated account</summary> 
    readonly StringBuilder buildAccount = new();


    ///<summary>The accumulated account</summary> 
    readonly StringBuilder buildService = new();



    bool isNumeric;

    ///<summary>Numeric result</summary> 
    string numeric;

    ///<summary>Last segment completed, not yet determined .</summary> 
    string last;


    record LexOutput(Token Token, string Value) {
        }

    /// <summary>
    /// Construct a parser to read from a string to be specified in GetToken (data)
    /// </summary>
    public ServiceAddressSplitLex() {

        }

    /*
     * Valid addresses
     * 
     * IPv4     Numeric Dot Numeric Dot Numeric Dot Numeric
     *          Numeric Dot Numeric Dot Numeric Dot Numeric Colon Numeric
     *          
     * Ipv6     HexNumeric Colon HexNumeric Colon HexNumeric Colon .. HexNumeric
     *          HexNumeric Colon HexNumeric Colon Colon HexNumeric Colon .. HexNumeric
     *          [Need to start from the last and work back]
     * 
     */


    /// <summary>
    /// Parse the string <paramref name="text"/> and return the result.
    /// </summary>
    /// <param name="text">The service address in text form.</param>
    /// <returns>The parse result.</returns>
    public static bool TryParse(string text, out ServiceAddress? serviceAddress) {
        serviceAddress = null;

        if (text == null | text.Length > 256) {
            return false;
            }

        var tokenList = new List<LexOutput>();

        //Lexer.Trace = true;

        var lexer = new ServiceAddressSplitLex(new LexReader(new StringReader(text)));
        for (var token = lexer.GetToken(); token != Token.Empty; token = lexer.GetToken()) {
            var lexOutput = new LexOutput (token, lexer.buildActive.ToString());
            tokenList.Add(lexOutput);

            //Console.WriteLine($"{lexOutput.Token} = {lexOutput.Value}");
            }
        if (tokenList.Count <1) {
            return false; 
            }

        if (TryCallSignOrDns(tokenList, ref serviceAddress)) {
            return true;
            }

        if (TryIPv4(tokenList, ref serviceAddress)) {
            return true;
            }

        if (TryIPv6(tokenList, ref serviceAddress)) {
            return true;
            }



        serviceAddress = null;
        return serviceAddress != null;
        }

    static bool TryCallSignOrDns(List<LexOutput> tokens, ref ServiceAddress? serviceAddress) {
        var count = tokens.Count;
        var iscallsign = false;
        var isDNS = false;
        int? version = null;

        // Check for trailing mm--
        if (tokens[count - 1].Token == Token.Label) {
            if (tokens[count - 1].Value == ServiceAddress.MeshTopLevelDirectory) {
                if (count < 3) {
                    return false;
                    }
                if (tokens[count - 2].Token != Token.Dot) {
                    return false;
                    }
                count -= 2;
                iscallsign = true;
                }
            }

        // Check for trailing numeric version,  


        if (tokens[count - 1].Token == Token.Numeric) {

            if (count < 3) {
                return false;
                }
            if (tokens[count - 2].Token != Token.Dot) {
                return false;
                }
            if (!int.TryParse(tokens[count - 1].Value, out var pversion)) {
                return false;
                }
            version = pversion;
            count -= 2;
            iscallsign = true;
            }



        // If it starts with @, it is always a callsign.
        var i = 0;
        if (tokens[0].Token == Token.At) {
            i = 1;
            iscallsign = true;
            }

        var state = 0;
        for (; i < count; i++) {
            var token = tokens[i].Token;

            switch (state) {
                case 0: {
                    if (token == Token.Label) {
                        state = 1; break;
                        }
                    return false;
                    }

                case 1: {
                    if (token == Token.Dot) {
                        state = 0; break;
                        }
                    if (token == Token.At) {
                        state = 2; break;
                        }
                    return false;
                    }

                case 2: {
                    if (token == Token.Label) {
                        state = 3; break;
                        }
                    return false;
                    }

                case 3: {
                    if (token == Token.Dot) {
                        state = 2; break;
                        }
                    return false;
                    }
                }
            }

        string service = null;
        string account = null;
        if (state == 1) { // service only
            
            }
        else if (state == 3) { // account@service
            
            }
        else {
            return false;
            }


        iscallsign |= !isDNS;
        serviceAddress = new ServiceAddress() {
            ServiceAddressType = iscallsign ? ServiceAddressType.Callsign : ServiceAddressType.DNS,
            Service = service,
            Account = account,
            Version = version
            };

        return true;
        }



    /// <summary>
    /// Attempt to interpret <paramref name="tokens"/> as an IPv4 address or address with 
    /// port specification.
    /// </summary>
    /// <param name="tokens"></param>
    /// <param name="serviceAddress"></param>
    /// <returns></returns>
    static bool TryIPv4(List<LexOutput> tokens, ref ServiceAddress? serviceAddress) {
        if ((tokens.Count != 7) & (tokens.Count != 9)) {
            return false;
            }

        if (NotIPv4Segment(tokens[0]) | (tokens[1].Token != Token.Dot) |
            NotIPv4Segment(tokens[2]) | (tokens[3].Token != Token.Dot) |
            NotIPv4Segment(tokens[4]) | (tokens[5].Token != Token.Dot) |
            NotIPv4Segment(tokens[6])) {
            return false;
            }

        if (tokens.Count == 7) {
            // No port value, return the verified address
            serviceAddress = new ServiceAddress() {
                Service = $"{tokens[0].Value}.{tokens[2].Value}.{tokens[4].Value}.{tokens[6].Value}"
                };
            return true;
            }

        if ((tokens[8].Token != Token.Numeric) | (tokens[7].Token != Token.Colon)) {
            return false;
            }


        if (!int.TryParse(tokens[8].Value, out var port)) {
            return false;
            }
        serviceAddress = new ServiceAddress() {
            Service = $"{tokens[0].Value}.{tokens[2].Value}.{tokens[4].Value}.{tokens[6].Value}",
            Port = port
            };

        return true;
        }


    static bool TryIPv6(List<LexOutput> tokens, ref ServiceAddress? serviceAddress) {

        var count = tokens.Count;

        if (tokens[0].Token == Token.Left) {
            if (tokens[count-1].Token == Token.Numeric) {
                if (count < 5) {
                    return false;
                    }

                if (tokens[count - 3].Token != Token.Right) {
                    return false;
                    }
                if (tokens[count - 2].Token != Token.Colon) {
                    return false;
                    }
                if (NotPort(tokens[count - 1], out var port)) {
                    return false;
                    }

                return TryIPv6(tokens, ref serviceAddress, 1, count-4, port);  // [1:2:3]:wev
                }
            if (tokens[count - 1].Token != Token.Right) {
                return false;
                }
            return TryIPv6(tokens, ref serviceAddress, 1, count - 2);   // [1::2:3]
            }
        return TryIPv6(tokens, ref serviceAddress, 0, tokens.Count);
        }


    static bool TryIPv6(List<LexOutput> tokens, ref ServiceAddress? serviceAddress, int start, int count, int? port = null) {
        var state = 0;
        var segments = 0;
        var wildcard = false;

        var builder = new StringBuilder();
        for (var i = 0; i < count; i++) {
            var token = tokens[i + start];
            var isColon = token.Token == Token.Colon;

            Console.WriteLine($"{state} : {token.Token} = {token.Value}");

            if ((token.Token == Token.Numeric) | (token.Token == Token.Hexadecimal)) {
                if (NotIPv6Segment(token)) {
                    return false;
                    }
                if (segments++ > 8) {
                    return false;
                    }
                }
            else if (!isColon) {
                return false;
                }

            state = state switch {
                0 => isColon ? 1 : 3,
                1 => isColon ? 2 : 0,
                2 => isColon ? 0 : 3,
                3 => isColon ? 4 : 0,
                4 => isColon ? 5 : 3,
                5 => isColon ? 0 : 3,
                _ => 0
                };

            if (state == 0) {
                return false;
                }
            if (state == 2 | state == 5) {
                wildcard = true;
                }

            if (isColon) {
                builder.Append(':');
                }
            else {
                builder.Append(token.Value);
                }
            }
        // Must have a wildcard or exactly 8 segments



        if (!wildcard & segments != 8) {
            return false;
            }

        serviceAddress = new ServiceAddress() {
            Service = builder.ToString(),
            Port = port
            };
        return true;
        }

    static bool NotPort(LexOutput token, out int port) {
        port = -1;
        if (token.Token != Token.Numeric) {
            return true;
            }
        if (!int.TryParse(token.Value, out port)) {
            return true;
            }

        if (port < 0 | port > 65535) {
            return true;
            }
        return false;
        }

    static bool NotIPv4Segment(LexOutput token) {
        if (token.Token != Token.Numeric) {
            return true;
            }
        if (!int.TryParse(token.Value, out var value)) {
            return true;
            }
        if (value < 0 | value > 255) {
            return true;
            }
        return false;
        }


    static bool NotIPv6Segment(LexOutput token) {
        // Token must either be decimal or hexadecimal
        if ((token.Token != Token.Numeric) & (token.Token != Token.Hexadecimal)) {
            return true;
            }
        // Segments must have four characters or less
        if (token.Value.Length > 4) {
            return true;
            }
        
        // If the token is correctly parsed, it MUST be within range.
        return false;
        }


    ///<inheritdoc/>
    public override void Reset() {
        buildActive.Clear();
        buildAccount.Clear();
        buildService.Clear();
        isNumeric = false;
        numeric = null;
        last = null;
        }


    //(string, string) GetService() {
    //    if (buildAccount.Length == 0) {
    //        if (last != null) {
    //            buildActive.Append('.');
    //            buildActive.Append(last);
    //            }
    //        return (buildActive.ToString(), null);
    //        }

    //    if (buildAccount.ToString() == "mm--") {
    //        return (last, buildActive.ToString());
    //        }

    //    buildActive.Append('.');
    //    buildActive.Append(last);
    //    return (buildAccount.ToString(), buildActive.ToString());
    //    }

    //ServiceAddress Complete() {
    //    var token = Tokens[StateInt];

    //    var active = buildActive.ToString();


    //    if (active == ServiceAddress.MeshTopLevelDirectory) {     // If it ends in mm-- it is ALWAYS a callsign
    //        active = null;
    //        token = Token.Callsign;
    //        }
    //    else if (isNumeric) {       // If it ends in a number, it is ALWAYS a callsign.
    //        if (numeric != null) { // @alice.0.0 is invalid
    //            return null;
    //            }
    //        numeric = active;
    //        active = null;
    //        token = Token.Callsign;
    //        }

    //    if (last != null) {
    //        buildService.Append(".");
    //        buildService.Append(last);
    //        }
    //    if (active != null) {
    //        buildService.Append(".");
    //        buildService.Append(active);
    //        }
    //    var service = buildService.ToString();

    //    var account = buildAccount.Length == 0 ? null : buildAccount.ToString();

    //    int? version = null;
    //    if (numeric != null && int.TryParse(numeric.ToString(), out var versionParsed)) {
    //        version = versionParsed;
    //        }


    //    switch (token) {
    //        case Token.Callsign: {
    //            return new ServiceAddress() {
    //                ServiceAddressType = ServiceAddressType.Callsign,
    //                Service = service,
    //                Account = account,
    //                Version = version
    //                };
    //            }
    //        case Token.DnsMultiple: {
    //            return new ServiceAddress() {
    //                ServiceAddressType = ServiceAddressType.DNS,
    //                Service = service,
    //                Account = account
    //                };
    //            }
    //        case Token.IPv4: {
    //            return new ServiceAddress() {
    //                ServiceAddressType = ServiceAddressType.IPv4,
    //                Service = service,
    //                };
    //            }
    //        case Token.IPv6: {
    //            return new ServiceAddress() {
    //                ServiceAddressType = ServiceAddressType.IPv6,
    //                Service = service,
    //                };
    //            }
    //        //case Token.SingleCallsign:
    //        //case Token.SingleLabel: {
    //        //    return new ServiceAddress() {
    //        //        ServiceAddressType = ServiceAddressType.Callsign,
    //        //        Service = buildActive.ToString()
    //        //        };
    //        //    }
    //        //case Token.DnsMultiple: {
    //        //    return new ServiceAddress() {
    //        //        ServiceAddressType = ServiceAddressType.DNS,
    //        //        Service = buildActive.ToString()
    //        //        };
    //        //    }

    //        //case Token.CallsignVersion: {
    //        //    var validVersion = int.TryParse(buildNumeric.ToString(), out var version);
    //        //    var (service, account) = GetService();
    //        //    return new ServiceAddress() {
    //        //        ServiceAddressType = ServiceAddressType.DNS,
    //        //        Service = service,
    //        //        Account = account,
    //        //        Version = validVersion ? version : null
    //        //        };
    //        //    }

    //        //case Token.CallsignVersionCheck: {

    //        //    if (buildAccount.ToString().ToLower() != "mm--") {
    //        //        return null;
    //        //        }

    //        //    var validVersion = int.TryParse(buildNumeric.ToString(), out var version);
    //        //    var account = buildActive.ToString();
    //        //    var service = last;

    //        //    return new ServiceAddress() {
    //        //        ServiceAddressType = ServiceAddressType.DNS,
    //        //        Service = service,
    //        //        Account = account,
    //        //        Version = validVersion ? version : null
    //        //        };
    //        //    }

    //        default: {
    //            return null;
    //            }


    //        }
    //    }





    void Start(int c) {
        Reset();
        }


    void Skip(int c) {
        }


    void AddToken(int c) {
        buildActive.Append((char)c);
        }

    void Terminal(int c) {
        }
    }


