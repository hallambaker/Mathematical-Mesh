﻿#region // Copyright - MIT License
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


namespace Goedel.Protocol;

// Transaction Classes
/// <summary>
/// The base class for transaction requests
/// </summary>
public abstract partial class Request {


    }

/// <summary>
/// Base class for all responses.
/// </summary>
public abstract partial class Response {

    /// <summary>
    /// Numeric status return code value
    /// </summary>
    public virtual int StatusCode {
        get => Status;
        set => Status = value;
        }

    /// <summary>
    /// Description of the status code (for debugging).
    /// </summary>
    public virtual string StatusDescriptionCode {
        get => StatusDescription;
        set => StatusDescription = value;
        }

    }


/// <summary>
/// 
/// </summary>
public interface IVerifiedAccount {
    #region // Properties
    /// <summary>
    /// The account identifier.
    /// </summary>
    string AccountAddress { get; }

    /// <summary>
    /// The profile identifer.
    /// </summary>
    string AuthenticatedProfileUDF { get; }

    /// <summary>
    /// The authentication key identifier.
    /// </summary>
    string AuthenticationKeyIdentifier { get; }
    #endregion

    }
