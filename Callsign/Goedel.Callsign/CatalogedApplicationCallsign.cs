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


namespace Goedel.Callsign;

public partial class CatalogedApplicationCallsign {


    /// <summary>
    /// The primary key used to catalog the entry.
    /// </summary>
    public override string _PrimaryKey => GetKey(CallSign);


    /// <summary>
    /// Return a catalog key for the SMTP mail account <paramref name="callsign"/>.
    /// </summary>
    /// <param name="callsign">The input, an RFC822 address.</param>
    /// <returns>The catalog key.</returns>
    public static string GetKey(string callsign) => $"Callsign:{callsign}";

    ///<inheritdoc/>
    public override void Activate(List<ApplicationEntry> activationEntry, ProfileDevice profileDevice, IKeyCollection keyCollection) {
        }

    ///<inheritdoc/>
    public override ApplicationEntry GetActivation(CatalogedDevice catalogedDevice) => null;



    ///<inheritdoc/>
    public override KeyData[] GetEscrow() => null;

    ///<inheritdoc/>
    public override void ToBuilder(StringBuilder output) {
        throw new NotImplementedException();
        }
    }
