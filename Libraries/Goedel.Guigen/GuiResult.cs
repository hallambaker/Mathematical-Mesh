using Goedel.Utilities;

using System.Reflection.Metadata;

namespace Goedel.Guigen;

public record GuiResult {

    public List<IGuiEntry> Entries { get; set; } = null!;



    public GuiResult() {
        }

    }


public record IndexedMessage (
        int Index,
        string Text){
    }

public record GuiResultInvalid : IResult {
    public ReturnResult ReturnResult => ReturnResult.Invalid;

    public GuiBinding Binding => Parameter.Binding;

    //public bool[] Invalid { get; }
    //public string[] Feedback { get; }


    public List<IndexedMessage> Messages { get; } = new();

    IParameter Parameter { get; }

    /// <summary>
    /// Constructor, returns new instance reporting validity of the specified fields
    /// in <paramref name="parameter"/>. The constructor MAY optionally specify a sequence
    /// of { field, Message } pairs specifying messages to be used to populate the return result.
    /// </summary>
    /// <param name="parameter"></param>
    /// <param name="parameters"></param>
    public GuiResultInvalid(IParameter parameter, params string[] parameters) {
        Parameter = parameter;

        //Invalid = new bool[Binding.BoundProperties.Length];
        //Feedback = new string[Binding.BoundProperties.Length];

        for (var i = 0; i+1 < parameters.Length; i += 2) {
            var field = parameters[i];
            var message = parameters[i+1];
            SetError(field, message);
            }

        
        }

    /// <summary>
    /// Set the error report for the field <paramref name="field"/> to 
    /// <paramref name="error"/>. This method is intended for use with the
    /// C# nameof function.
    /// </summary>
    /// <param name="field">The name of the field to set the error result for.</param>
    /// <param name="error">The error result to be set.</param>
    public void SetError(
                string field,
                string error,
                string? id=null) {

        //for (var i= 0; i < Binding.BoundProperties.Length; i++) {
        //    var binding = Binding.BoundProperties[i];
        //    if (binding.Label == field) {
        //        SetError(i, error);
        //        return;
        //        }
        //    }


        }

    public void SetError(
                int index, 
                string message,
                string? id = null) {

        id.Future(); // ToDo: Make use of resource strings.

        var idMessage = ResourceResolver.GetString(id);


        Messages.Add(new IndexedMessage(index, idMessage ?? message));
        }




    }