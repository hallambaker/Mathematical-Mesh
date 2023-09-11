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

using System;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace Goedel.Discovery;

/// <summary>
/// FSM parser to break down 
/// </summary>
public partial class ServiceAddressSplitLex {

    ///<summary>The builer we build to.</summary>
    readonly StringBuilder buildActive = new();

    int accountSeparatorPosition = 0;
    int countSeparators = 0;

    LexStringReader StringReader => Reader as LexStringReader;
    int Position => StringReader.Count - 1;

    record LexOutput(Token Token, string Value) {

        }

    /// <summary>
    /// Construct a parser to read from a string to be specified in GetToken (data)
    /// </summary>
    public ServiceAddressSplitLex(LexStringReader reader) {
        Reader = reader;

        }

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

        var reader = new LexStringReader(text);

        var lexer = new ServiceAddressSplitLex(reader);
        //Lexer.Trace = true;
        for (var token = lexer.GetToken(); token != Token.Empty; token = lexer.GetToken()) {
            var lexOutput = new LexOutput(token, lexer.buildActive.ToString());
            tokenList.Add(lexOutput);

            //Console.WriteLine($"{lexOutput.Token} = {lexOutput.Value}");
            }
        if (tokenList.Count < 1) {
            return false;
            }



        if (TryIPv4(tokenList, ref serviceAddress)) {
            return true;
            }

        if (TryIPv6(tokenList, ref serviceAddress)) {
            return true;
            }

        if (TryCallSignOrDns(tokenList, ref serviceAddress)) {
            return true;
            }

        serviceAddress = null;
        return serviceAddress != null;
        }

    static bool TryCallSignOrDns(List<LexOutput> tokens, ref ServiceAddress? serviceAddress) {
        serviceAddress = null;

        // scan through to detect @ separators
        int i = 0;
        int accountStart = -1;
        int accountCount = 0;
        int serviceStart = 0;
        int serviceCount = 0;
        bool forceCallsign = false;
        ParsedAddressType addressType = ParsedAddressType.Empty;


        foreach (var token in tokens) {
            if (token.Token == Token.At) {
                if (i == 0) {
                    serviceStart = 1;
                    forceCallsign = true;
                    addressType = ParsedAddressType.Callsign;
                    }
                else {
                    if (accountStart > -1) {
                        // can't have account path @alice@bob@carol or alice@bob@carol.
                        return false;
                        }
                    accountStart = serviceStart;
                    accountCount = serviceCount;
                    serviceCount = 0;
                    serviceStart = i + 1;
                    }
                }
            else {
                serviceCount++;
                }

            i++;
            }



        var service = ParseAddress(tokens, serviceStart, serviceCount, forceCallsign, addressType); ;
        if (service.AddressType == ParsedAddressType.Invalid) {
            return false;
            }

        if (accountStart >= 0) {
            var account = ParseAddress(tokens, accountStart, accountCount, forceCallsign, serviceType: service.AddressType);
            if (account.AddressType == ParsedAddressType.Invalid) {
                return false;
                }

            serviceAddress = new ServiceAddress(account, service);
            }
        else {
            serviceAddress = new ServiceAddress(service);
            }



        return true;

        }


    static ParsedAddress? ParseAddress(List<LexOutput> tokens, int start, int count,
                    bool force, ParsedAddressType serviceType = ParsedAddressType.Empty) {
        int? version = null;
        //ParsedAddressType addressType = (force | serviceType == ParsedAddressType.Callsign) ? 
        //    ParsedAddressType.Callsign : ParsedAddressType.Empty;

        ParsedAddressType addressType = ParsedAddressType.Empty;

        if (start < 0) {
            return ParsedAddress.Invalid;
            }

        var end = start + count-1;
        if (tokens[end].Token == Token.Label) {
            if (tokens[end].Value == ServiceAddress.MeshTopLevelDirectory) {
                if (count < 3) {
                    return ParsedAddress.Invalid;
                    }
                if (tokens[end - 1].Token != Token.Dot) {
                    return ParsedAddress.Invalid;
                    }
                count -= 2;

                addressType = ParsedAddressType.Callsign;
                }
            }

        end = start + count - 1;
        // Check for trailing numeric version,  
        if (tokens[end].Token == Token.Numeric) {

            if (count < 3) {
                return ParsedAddress.Invalid;
                }
            if (tokens[end - 1].Token != Token.Dot) {
                return ParsedAddress.Invalid;
                }
            if (!int.TryParse(tokens[end].Value, out var pversion)) {
                return ParsedAddress.Invalid;
                }
            version = pversion;
            count -= 2; 

            addressType = ParsedAddressType.Callsign;
            }

        end = start + count - 1;
        var state = 0;
        var builder = new StringBuilder();
        for (var i=start; i <= end; i++) {
            var token = tokens[i].Token;
            var value = tokens[i].Value;
            switch (state) {
                case 0: {
                    if (token == Token.Label) {
                        builder.Append(value);
                        state = 1; 
                        break;
                        }
                    return ParsedAddress.Invalid;
                    }

                case 1: {
                    if (token == Token.Dot) {
                        builder.Append('.');
                        state = 0;
                        addressType = ParsedAddressType.Dns;
                        break;
                        }
                    return ParsedAddress.Invalid;
                    }
                } 
            }
        if (state != 1) {
            return ParsedAddress.Invalid;
            }


        if (serviceType == ParsedAddressType.Callsign) {
            addressType = ParsedAddressType.Callsign;
            }
        else if (addressType == ParsedAddressType.Empty) {
            addressType = serviceType == ParsedAddressType.Dns ?
                 ParsedAddressType.Dns : ParsedAddressType.Callsign;
            }


            //switch (serviceType) {
            //case ParsedAddressType.Callsign: {
            //    addressType = ParsedAddressType.Callsign;
            //    break;
            //    }
            //case ParsedAddressType.Dns: {
            //    if (addressType == ParsedAddressType.Empty) {
            //        // alice@example.com is a DNS Account
            //        addressType = ParsedAddressType.Dns;
            //        }
            //    break;
            //    }
            //default: {
            //    if (addressType == ParsedAddressType.Empty) {
            //        // example.com is a DNS Service
            //        addressType = ParsedAddressType.Callsign;
            //        }
            //    break;
            //    }
            //}


        return new ParsedAddress() {
            AddressType = addressType,
            Address = builder.ToString(),
            Version = version
            };
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

        var service = new ParsedAddress() {
            AddressType = ParsedAddressType.IPv4,
            Address = $"{tokens[0].Value}.{tokens[2].Value}.{tokens[4].Value}.{tokens[6].Value}"
            };

        if (tokens.Count == 7) {
            // No port value, return the verified address
            serviceAddress = new ServiceAddress(service);
            return true;
            }

        if ((tokens[8].Token != Token.Numeric) | (tokens[7].Token != Token.Colon)) {
            return false;
            }

        if (!int.TryParse(tokens[8].Value, out var port)) {
            return false;
            }
        serviceAddress = new ServiceAddress(service) { 
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

            //Console.WriteLine($"{state} : {token.Token} = {token.Value}");

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

        var service = new ParsedAddress() {
            AddressType = ParsedAddressType.IPv6,
            Address = builder.ToString(),
            };

        serviceAddress = new ServiceAddress(service) {
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
        }




    void Start(int c) {
        Reset();
        }


    void IsAt(int c) {
        if (Position > 0) {
            countSeparators++;
            accountSeparatorPosition = Position;
            }
        }


    void AddToken(int c) {
        buildActive.Append((char)c);
        }

    void Terminal(int c) {
        }
    }


