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


namespace Goedel.Mesh;

public partial class MeshProtocol {

    /////<summary>Initialization property. Access this property to force initialization 
    /////of the static method.</summary>
    //public static object Initialize => null;

    //[ModuleInitializer]
    //internal static void Initializer() {
    //    AddDictionary(ref Goedel.Protocol.Message._TagDictionary);
    //    AddDictionary(ref _TagDictionary);
    //    }

    //static MeshProtocol() {
    //    Initializer();
    //    }
    }


public partial class MeshResponse {

    /// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
    public new static Dictionary<string, JsonFactoryDelegate> _TagDictionary { get; set; } =
            MeshProtocol._TagDictionary;


    /// <summary>
    /// Default constructor
    /// </summary>

    public MeshResponse(Exception exception = null) {
        if (exception == null) {
            StatusCode = 201;
            StatusDescriptionCode = "Operation completed successfully";
            return;
            }

        // Goal: extend Exceptional preprocessor to enable these to be handled internally

        StatusCode = 400;
        StatusDescriptionCode = "Error occurred";

        switch (exception) {
            case ObjectIdentifierNotUnique e: {
                    StatusDescriptionCode = MeshConstants.MeshServerStatusAccountRegisteredTag;
                    StatusExtended = (int)MeshServerStatus.AccountRegistered;
                    return;
                    }
            case NotAuthenticated e: {
                    StatusDescriptionCode = MeshConstants.MeshServerStatusNotAuthorizedTag;
                    StatusExtended = (int)MeshServerStatus.NotAuthorized;
                    return;
                    }
            case NotAdministrator e: {
                    StatusDescriptionCode = MeshConstants.MeshServerStatusNotAdministratorTag;
                    StatusExtended = (int)MeshServerStatus.NotAdministrator;
                    return;
                    }
            case NotAuthorized e: {
                    StatusDescriptionCode = MeshConstants.MeshServerStatusNotAuthorizedTag;
                    StatusExtended = (int)MeshServerStatus.NotAuthorized;
                    return;
                    }
            default:
                break;
            }

        }

    /// <summary>
    /// Convenience method testing that the response succeeded and throwing the 
    /// exception <paramref name="throwDelegate"/> or <see cref="ServerOperationFailed"/>
    /// otherwise with the response instance as the parameter.
    /// </summary>
    /// <param name="throwDelegate">Delegate that throws the required exception.</param>
    public void AssertSuccess(ThrowDelegate throwDelegate = null) =>
        Success().AssertTrue(throwDelegate ?? ServerOperationFailed.Throw, this);


    /// <summary>
    /// Performs a deep recursive copy of the structure.
    /// </summary>
    /// <returns>Deep copy of the object with all referenced objects
    /// copied.</returns>
    public override JsonObject DeepCopy() {
        // Convert this object to text:
        var Text = ToString();

        // Convert text back to an object:
        var Result = MeshResponse.FromJson(Text.JsonReader());

        return Result;
        }
    }

public partial class MeshRequest {

    /// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
    public static new Dictionary<string, JsonFactoryDelegate> _TagDictionary { get; set; } =
            MeshProtocol._TagDictionary;

    /// <summary>
    /// Performs a deep recursive copy of the structure.
    /// </summary>
    /// <returns>Deep copy of the object with all referenced objects
    /// copied.</returns>
    public override JsonObject DeepCopy() {
        // Convert this object to text:
        var Text = ToString();

        // Convert text back to an object:
        var Result = MeshRequest.FromJson(Text.JsonReader());

        return Result;
        }
    }


public partial class BindResponse {

    /// <summary>
    /// Default constructor. 
    /// </summary>
    /// <param name="exception">Optional exception specifier.</param>
    public BindResponse(Exception exception = null) : base(exception) {
        }
    }


public partial class UnbindResponse {

    /// <summary>
    /// Default constructor. 
    /// </summary>
    /// <param name="exception">Optional exception specifier.</param>
    public UnbindResponse(Exception exception = null) : base(exception) {
        }
    }


public partial class StatusResponse {

    /// <summary>
    /// Default constructor. 
    /// </summary>
    /// <param name="exception">Optional exception specifier.</param>
    public StatusResponse(Exception exception = null) : base(exception) {
        }

    /// <summary>
    /// Append the response description to <paramref name="builder"/> at an indentation
    /// level of <paramref name="indent"/>.
    /// </summary>
    /// <param name="builder">The string builder to append the description to.</param>
    /// <param name="indent">The indentation level.</param>
    public override void ToBuilder(StringBuilder builder, int indent = 0) {
        builder.AppendIndent(indent, "Status");
        if (ContainerStatus != null) {
            foreach (var status in ContainerStatus) {
                status.ToBuilder(builder, indent + 1);
                }
            }

        }


    }

public partial class ContainerStatus {

    /// <summary>
    /// Append the response description to <paramref name="builder"/> at an indentation
    /// level of <paramref name="indent"/>.
    /// </summary>
    /// <param name="builder">The string builder to append the description to.</param>
    /// <param name="indent">The indentation level.</param>
    public override void ToBuilder(StringBuilder builder, int indent = 0) =>
        builder.AppendIndent(indent, $"{Container}:  {Index} {Digest?.ToStringBase64url()}");
    }


public partial class ContainerUpdate {

    /// <summary>
    /// Append the response description to <paramref name="builder"/> at an indentation
    /// level of <paramref name="indent"/>.
    /// </summary>
    /// <param name="builder">The string builder to append the description to.</param>
    /// <param name="indent">The indentation level.</param>
    public override void ToBuilder(StringBuilder builder, int indent = 0) =>
        builder.AppendIndent(indent, $"{Container}:  {Index}+{Envelopes.Count} {Digest?.ToStringBase64url()}");
    }



public partial class TransactRequest {

    }

public partial class TransactResponse {
    /// <summary>
    /// Default constructor. 
    /// </summary>
    /// <param name="exception">Optional exception specifier.</param>
    public TransactResponse(Exception exception = null) : base(exception) {
        }
    }

public partial class PostResponse {
    /// <summary>
    /// Default constructor. 
    /// </summary>
    /// <param name="exception">Optional exception specifier.</param>
    public PostResponse(Exception exception = null) : base(exception) {
        }
    }

public partial class DownloadResponse {
    /// <summary>
    /// Default constructor. 
    /// </summary>
    /// <param name="exception">Optional exception specifier.</param>
    public DownloadResponse(Exception exception = null) : base(exception) {
        }
    }

public partial class ConnectResponse {
    /// <summary>
    /// Default constructor. 
    /// </summary>
    /// <param name="exception">Optional exception specifier.</param>
    public ConnectResponse(Exception exception = null) : base(exception) {
        }
    }

public partial class CompleteResponse {
    /// <summary>
    /// Default constructor. 
    /// </summary>
    /// <param name="exception">Optional exception specifier.</param>
    public CompleteResponse(Exception exception = null) : base(exception) {
        }
    }
public partial class ClaimResponse {
    /// <summary>
    /// Default constructor. 
    /// </summary>
    /// <param name="exception">Optional exception specifier.</param>
    public ClaimResponse(Exception exception = null) : base(exception) {
        }
    }

public partial class PollClaimResponse {
    /// <summary>
    /// Default constructor. 
    /// </summary>
    /// <param name="exception">Optional exception specifier.</param>
    public PollClaimResponse(Exception exception = null) : base(exception) {
        }
    }

public partial class OperateResponse {
    /// <summary>
    /// Default constructor. 
    /// </summary>
    /// <param name="exception">Optional exception specifier.</param>
    public OperateResponse(Exception exception = null) : base(exception) {
        }
    }
