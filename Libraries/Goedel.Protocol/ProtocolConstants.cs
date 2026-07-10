
//  This file was automatically generated at 7/10/2026 12:40:43 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  constant version 3.0.0.1173
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.26200.0
//  
//  
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

using Goedel.Utilities;

namespace Goedel.Protocol ;


///<summary>Sequence Events</summary>
public enum SequenceEvent {
    ///<summary>Undefined type</summary>
    Unknown = -1,
    ///<summary>Initial</summary>
    Initial,
    ///<summary>Read</summary>
    Read,
    ///<summary>Update</summary>
    Update,
    ///<summary>Delete</summary>
    Delete,
    ///<summary>Erase</summary>
    Erase,
    ///<summary>Updates</summary>
    Updates,
    ///<summary>Index</summary>
    Index,
    ///<summary>Witness</summary>
    Witness
    }


///<summary>
///Constants specified in hallambaker-mesh-udf
///</summary>
public static partial class ProtocolConstants {

    // File: SequenceEvents


    ///<summary>Jose enumeration tag for SequenceEvent.Initial</summary>
    public const string  SequenceEventInitialTag = "Initial";
    ///<summary>Jose enumeration tag for SequenceEvent.Read</summary>
    public const string  SequenceEventReadTag = "Read";
    ///<summary>Jose enumeration tag for SequenceEvent.Update</summary>
    public const string  SequenceEventUpdateTag = "Update";
    ///<summary>Jose enumeration tag for SequenceEvent.Delete</summary>
    public const string  SequenceEventDeleteTag = "Delete";
    ///<summary>Jose enumeration tag for SequenceEvent.Erase</summary>
    public const string  SequenceEventEraseTag = "Erase";
    ///<summary>Jose enumeration tag for SequenceEvent.Updates</summary>
    public const string  SequenceEventUpdatesTag = "Updates";
    ///<summary>Jose enumeration tag for SequenceEvent.Index</summary>
    public const string  SequenceEventIndexTag = "Index";
    ///<summary>Jose enumeration tag for SequenceEvent.Witness</summary>
    public const string  SequenceEventWitnessTag = "Witness";

    /// <summary>
    /// Convert the string <paramref name="text"/> to the corresponding enumeration
    /// value.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The enumeration value.</returns>
    public static SequenceEvent ToSequenceEvent (this string text) =>
        text switch {
            SequenceEventInitialTag => SequenceEvent.Initial,
            SequenceEventReadTag => SequenceEvent.Read,
            SequenceEventUpdateTag => SequenceEvent.Update,
            SequenceEventDeleteTag => SequenceEvent.Delete,
            SequenceEventEraseTag => SequenceEvent.Erase,
            SequenceEventUpdatesTag => SequenceEvent.Updates,
            SequenceEventIndexTag => SequenceEvent.Index,
            SequenceEventWitnessTag => SequenceEvent.Witness,
            _ => SequenceEvent.Unknown
            };

    /// <summary>
    /// Convert the enumerated value <paramref name="data"/> to the corresponding string
    /// value.
    /// </summary>
    /// <param name="data">The enumerated value.</param>
    /// <returns>The text value.</returns>
    public static string ToLabel (this SequenceEvent data) =>
        data switch {
            SequenceEvent.Initial => SequenceEventInitialTag,
            SequenceEvent.Read => SequenceEventReadTag,
            SequenceEvent.Update => SequenceEventUpdateTag,
            SequenceEvent.Delete => SequenceEventDeleteTag,
            SequenceEvent.Erase => SequenceEventEraseTag,
            SequenceEvent.Updates => SequenceEventUpdatesTag,
            SequenceEvent.Index => SequenceEventIndexTag,
            SequenceEvent.Witness => SequenceEventWitnessTag,
            _ => null
            };

    }

