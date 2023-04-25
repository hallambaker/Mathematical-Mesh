
//  This file was automatically generated at 25-Apr-23 2:24:14 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  constant version 3.0.0.945
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.19042.0
//  
//  
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

using Goedel.Utilities;

namespace Goedel.Protocol.Service ;


///<summary>Payload tags</summary>
public enum PayloadTag {
    ///<summary>Undefined type</summary>
    Unknown = -1,
    ///<summary>Full message</summary>
    DataFull = 0,
    ///<summary>Message start unchunked</summary>
    DataStart = 1,
    ///<summary>Message start chunked</summary>
    DataStartChunked = 2,
    ///<summary>Message data</summary>
    Data = 3,
    ///<summary>Complete data send</summary>
    DataLast = 4,
    ///<summary>Abort data send</summary>
    DataAbort = 5,
    ///<summary>Open stream</summary>
    StreamOpen = 8,
    ///<summary>Close stream</summary>
    StreamClose = 9,
    ///<summary>Configure stream</summary>
    StreamConfigure = 10,
    ///<summary>Open connection</summary>
    ConnectionOpen = 16,
    ///<summary>Close connection</summary>
    ConnectionClose = 17,
    ///<summary>Configure connection</summary>
    ConnectionConfigure = 18,
    ///<summary>Issue tokens</summary>
    ConnectionTokensIssue = 19,
    ///<summary>Request additional tokens</summary>
    ConnectionTokensRequest = 20,
    ///<summary>Open additional endpoint</summary>
    EndpointOpen = 24,
    ///<summary>Close endpoint</summary>
    EndpointClose = 25,
    ///<summary>Configure endpoint</summary>
    EndpointConfigure = 26,
    ///<summary>Measure endpoint</summary>
    EndpointMeasure = 27,
    ///<summary>End of packet payload.</summary>
    EndOfPayload = 63    }


///<summary>
///Constants specified in hallambaker-mesh-rud
///</summary>
public static partial class ServiceConstants {

    // File: ServiceConstants


    ///<summary>Jose enumeration tag for PayloadTag.DataFull</summary>
    public const string  PayloadTagDataFullTag = "DataFull";
    ///<summary>Description for PayloadTag.DataFull</summary>
    public const string  PayloadTagDataFullTitle = "Full message";
    ///<summary>Jose enumeration tag for PayloadTag.DataStart</summary>
    public const string  PayloadTagDataStartTag = "DataStart";
    ///<summary>Description for PayloadTag.DataStart</summary>
    public const string  PayloadTagDataStartTitle = "Message start unchunked";
    ///<summary>Jose enumeration tag for PayloadTag.DataStartChunked</summary>
    public const string  PayloadTagDataStartChunkedTag = "DataStartChunked";
    ///<summary>Description for PayloadTag.DataStartChunked</summary>
    public const string  PayloadTagDataStartChunkedTitle = "Message start chunked";
    ///<summary>Jose enumeration tag for PayloadTag.Data</summary>
    public const string  PayloadTagDataTag = "Data";
    ///<summary>Description for PayloadTag.Data</summary>
    public const string  PayloadTagDataTitle = "Message data";
    ///<summary>Jose enumeration tag for PayloadTag.DataLast</summary>
    public const string  PayloadTagDataLastTag = "DataLast";
    ///<summary>Description for PayloadTag.DataLast</summary>
    public const string  PayloadTagDataLastTitle = "Complete data send";
    ///<summary>Jose enumeration tag for PayloadTag.DataAbort</summary>
    public const string  PayloadTagDataAbortTag = "DataAbort";
    ///<summary>Description for PayloadTag.DataAbort</summary>
    public const string  PayloadTagDataAbortTitle = "Abort data send";
    ///<summary>Jose enumeration tag for PayloadTag.StreamOpen</summary>
    public const string  PayloadTagStreamOpenTag = "StreamOpen";
    ///<summary>Description for PayloadTag.StreamOpen</summary>
    public const string  PayloadTagStreamOpenTitle = "Open stream";
    ///<summary>Jose enumeration tag for PayloadTag.StreamClose</summary>
    public const string  PayloadTagStreamCloseTag = "StreamClose";
    ///<summary>Description for PayloadTag.StreamClose</summary>
    public const string  PayloadTagStreamCloseTitle = "Close stream";
    ///<summary>Jose enumeration tag for PayloadTag.StreamConfigure</summary>
    public const string  PayloadTagStreamConfigureTag = "StreamConfigure";
    ///<summary>Description for PayloadTag.StreamConfigure</summary>
    public const string  PayloadTagStreamConfigureTitle = "Configure stream";
    ///<summary>Jose enumeration tag for PayloadTag.ConnectionOpen</summary>
    public const string  PayloadTagConnectionOpenTag = "ConnectionOpen";
    ///<summary>Description for PayloadTag.ConnectionOpen</summary>
    public const string  PayloadTagConnectionOpenTitle = "Open connection";
    ///<summary>Jose enumeration tag for PayloadTag.ConnectionClose</summary>
    public const string  PayloadTagConnectionCloseTag = "ConnectionClose";
    ///<summary>Description for PayloadTag.ConnectionClose</summary>
    public const string  PayloadTagConnectionCloseTitle = "Close connection";
    ///<summary>Jose enumeration tag for PayloadTag.ConnectionConfigure</summary>
    public const string  PayloadTagConnectionConfigureTag = "ConnectionConfigure";
    ///<summary>Description for PayloadTag.ConnectionConfigure</summary>
    public const string  PayloadTagConnectionConfigureTitle = "Configure connection";
    ///<summary>Jose enumeration tag for PayloadTag.ConnectionTokensIssue</summary>
    public const string  PayloadTagConnectionTokensIssueTag = "ConnectionTokensIssue";
    ///<summary>Description for PayloadTag.ConnectionTokensIssue</summary>
    public const string  PayloadTagConnectionTokensIssueTitle = "Issue tokens";
    ///<summary>Jose enumeration tag for PayloadTag.ConnectionTokensRequest</summary>
    public const string  PayloadTagConnectionTokensRequestTag = "ConnectionTokensRequest";
    ///<summary>Description for PayloadTag.ConnectionTokensRequest</summary>
    public const string  PayloadTagConnectionTokensRequestTitle = "Request additional tokens";
    ///<summary>Jose enumeration tag for PayloadTag.EndpointOpen</summary>
    public const string  PayloadTagEndpointOpenTag = "EndpointOpen";
    ///<summary>Description for PayloadTag.EndpointOpen</summary>
    public const string  PayloadTagEndpointOpenTitle = "Open additional endpoint";
    ///<summary>Jose enumeration tag for PayloadTag.EndpointClose</summary>
    public const string  PayloadTagEndpointCloseTag = "EndpointClose";
    ///<summary>Description for PayloadTag.EndpointClose</summary>
    public const string  PayloadTagEndpointCloseTitle = "Close endpoint";
    ///<summary>Jose enumeration tag for PayloadTag.EndpointConfigure</summary>
    public const string  PayloadTagEndpointConfigureTag = "EndpointConfigure";
    ///<summary>Description for PayloadTag.EndpointConfigure</summary>
    public const string  PayloadTagEndpointConfigureTitle = "Configure endpoint";
    ///<summary>Jose enumeration tag for PayloadTag.EndpointMeasure</summary>
    public const string  PayloadTagEndpointMeasureTag = "EndpointMeasure";
    ///<summary>Description for PayloadTag.EndpointMeasure</summary>
    public const string  PayloadTagEndpointMeasureTitle = "Measure endpoint";
    ///<summary>Jose enumeration tag for PayloadTag.EndOfPayload</summary>
    public const string  PayloadTagEndOfPayloadTag = "EndOfPayload";
    ///<summary>Description for PayloadTag.EndOfPayload</summary>
    public const string  PayloadTagEndOfPayloadTitle = "End of packet payload.";

    /// <summary>
    /// Convert the string <paramref name="text"/> to the corresponding enumeration
    /// value.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The enumeration value.</returns>
    public static PayloadTag ToPayloadTag (this string text) =>
        text switch {
            _ => PayloadTag.Unknown
            };

    /// <summary>
    /// Convert the enumerated value <paramref name="data"/> to the corresponding string
    /// value.
    /// </summary>
    /// <param name="data">The enumerated value.</param>
    /// <returns>The text value.</returns>
    public static string ToLabel (this PayloadTag data) =>
        data switch {
            _ => null
            };

    }

