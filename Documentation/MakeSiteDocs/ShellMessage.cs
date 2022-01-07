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

using System.Collections.Generic;

using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Utilities;

namespace ExampleGenerator;

public class ShellMessage : ExampleSet {

    //public List<ExampleResult> ContactRequest;
    //public List<ExampleResult> ContactPending;
    //public List<ExampleResult> ContactAccept;
    //public List<ExampleResult> ContactCatalogList;
    //public List<ExampleResult> ContactGetResponse;
    //public List<ExampleResult> ContactReject;
    //public List<ExampleResult> ContactBlock;




    public const string BobPurchase = "Purchase equipment for $6,000?";

    public List<ExampleResult> ConfirmRequest, ConfirmRequestMallet;
    public List<ExampleResult> ConfirmPending;
    public List<ExampleResult> ConfirmAccept;
    public List<ExampleResult> ConfirmGetAccept;
    public List<ExampleResult> ConfirmReject;
    public List<ExampleResult> ConfirmGetReject;
    public List<ExampleResult> ConfirmMallet;




    public ShellMessage(CreateExamples createExamples) :
            base(createExamples) {


        //ContactRequest = Bob1.Example($"message contact {AliceAccount}");
        //ContactPending = Alice1.Example($"message pending");
        //var resultPending = (ContactPending[0].Result as ResultPending);
        //var id1 = resultPending.Messages[0].MessageId;
        //var id2 = resultPending.Messages[1].MessageId;

        //ContactAccept = Alice1.Example($"message accept {id1}");

        //ContactCatalogList = Alice1.Example($"contact list");
        //ContactGetResponse = Bob1.Example($"message status {id1}");
        //ContactReject = Alice1.Example($"message reject {id2}");
        //ContactBlock = Alice1.Example($"message block {MalletAccount}");

        ConfirmRequest = Bob1.Example($"message confirm {AliceAccount} \"{ShellMessage.BobPurchase}\"");

        ConfirmRequestMallet = Mallet1.Example($"message confirm {AliceAccount} \"{ShellMessage.BobPurchase}\"");
        ConfirmPending = Alice1.Example($"message pending");
        var confirmPending = (ConfirmPending[0].Result as ResultPending);

        var id1 = confirmPending.Messages[0].MessageId;
        var id2 = confirmPending.Messages[1].MessageId;

        ConfirmAccept = Alice1.Example($"message accept {id1}");
        ConfirmGetAccept = Bob1.Example($"message status {id1}");
        ConfirmReject = Alice1.Example($"message reject {id2}");
        ConfirmGetReject = Mallet1.Example($"message status {id2}");

        //ConfirmMallet = Mallet1.Example($"!message confirm {AliceAccount} \"{BobPurchase}\"");
        }

    }
