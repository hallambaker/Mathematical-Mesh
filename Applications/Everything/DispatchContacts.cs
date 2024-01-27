using Goedel.Cryptography.Dare;

using System.Collections;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

using static System.Runtime.InteropServices.JavaScript.JSType;

using Contact = Goedel.Mesh.Contact;

namespace Goedel.Everything;





public partial class EverythingMaui {


    ///<inheritdoc/>
    public override async Task<IResult> CreateMail(CreateMail data) => await NotYetImplemented();


    ///<inheritdoc/>
    public override async Task<IResult> CreateChat(CreateChat data) => await NotYetImplemented();


    ///<inheritdoc/>
    public override async Task<IResult> StartVoice(StartVoice data) => await NotYetImplemented();


    ///<inheritdoc/>
    public override async Task<IResult> StartVideo(StartVideo data) => await NotYetImplemented();

    async Task<IResult>NotYetImplemented() {
        try {
            await Task.Delay(0);
            return new NotYetImplemented() {
                };
            }
        catch (Exception exception) {
            if (TryProcessException(exception, null, out var result)) {
                return result;
                }
            return new ErrorResult(exception);
            }
        }



    }





