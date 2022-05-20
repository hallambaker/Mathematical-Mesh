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

namespace Goedel.Mesh.Shell;

public partial class Shell {

    ///<inheritdoc/>
    public override ShellResult CallsignRegister(CallsignRegister options) {
        var callsign = options.Identifier.Value;

        var contextAccount = GetContextUser(options);
        var message = contextAccount.CallsignRequest(callsign);

        var result = new ResultSent() {
            Success = true,
            Message = message
            };
        return result;
        }

    ///<inheritdoc/>
    public override ShellResult CallsignBind(CallsignBind options) {
        var callsign = options.Identifier.Value;

        var contextAccount = GetContextUser(options);
        var message = contextAccount.CallsignRequest(callsign, true);

        var result = new ResultSent() {
            Success = true,
            Message = message
            };
        return result;
        }


    ///<inheritdoc/>
    public override ShellResult CallsignResolve(CallsignResolve options) {

        throw new NYI();
        }

    ///<inheritdoc/>
    public override ShellResult CallsignTransfer(CallsignTransfer options) {

        throw new NYI();
        }

    ///<inheritdoc/>
    public override ShellResult CallsignList(CallsignList options) {

        throw new NYI();
        }


    }