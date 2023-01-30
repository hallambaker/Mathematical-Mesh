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


using Goedel.Test;
using System.Security.Claims;

namespace Goedel.XUnit;


public record ParametersCallsign {
    public DeterministicSeed Seed { get; }
    public int Iteration { get; }

    public int Accounts { get; }

    public int Issue { get; }

    public int Updates { get; }


    public ParametersCallsign(
            int iteration = 0) {
        Iteration = iteration;

        Seed = DeterministicSeed.CreateDeep(2, ToString());
    }

    public override string ToString() => $"{Iteration}";

    }







public partial class TCallsign {

    public static TCallsign Test() => new();
    /// <summary>
    /// Create and test a proof chain over a sequence.
    /// </summary>
    /// <param name="parameters"></param>
    [Theory(Skip = "Callsign not yet implemented")]
    [InlineData()]
    public void TestIssue(ParametersClaim parameters = null) {
        parameters ??= new();


        // Create account


        // Register callsign


        // Validate registration


        // Update registration
        }


    /// <summary>
    /// Alice and Bob create accounts and exchange contacts using DNS and callsign
    /// addresses.
    /// </summary>
    /// <param name="parameters"></param>
    [Theory(Skip = "Callsign not yet implemented")]
    [InlineData()]
    public void TestResolve(ParametersClaim parameters = null) {
        parameters ??= new();


        }

    /// <summary>
    /// Alice buys a callsign token, exchanges it for a callsign.
    /// </summary>
    /// <param name="parameters"></param>
    [Theory(Skip = "Callsign not yet implemented")]
    [InlineData()]
    public void TestPurchase(ParametersClaim parameters = null) {
        parameters ??= new();


        }


    /// <summary>
    /// Alice buys a callsign token, passes it to Bob and Carol for use.
    /// Bob succeeds, Carol fails because it is spent.
    /// </summary>
    /// <param name="parameters"></param>
    [Theory(Skip = "Callsign not yet implemented")]
    [InlineData()]
    public void TestPurchaseIndirect(ParametersClaim parameters = null) {
        parameters ??= new();


        }



    /// <summary>
    /// Create multiple callsigns for multiple accounts and update
    /// </summary>
    /// <param name="parameters"></param>
    [Theory(Skip = "Callsign not yet implemented")]
    [InlineData()]
    public void TestIssueMulti(ParametersCallsign parameters = null) {
        parameters ??= new();


        // Create accounts


        var tasks = new int[] { parameters.Issue, parameters.Updates };

        // Note that this loop is set up so we always register a callsign.= before updating one.
        for (var task =0;  task >= 0; task = parameters.Seed.GetTask(tasks)) {

            switch (task) {
                case 0: {
                    // Register callsign
                    break;
                    }
                case 1: {
                    // Update callsign
                    break;
                    }
                }

            // Validate registration
            }
        }


    [Fact(Skip = "Callsign not yet implemented")]
    public void TestCallSignBadSignatureIssuer ()=> throw new NYI();

    [Fact(Skip = "Callsign not yet implemented")]
    public void TestCallSignBadSignatureRegistration() => throw new NYI();

    [Fact(Skip = "Callsign not yet implemented")]
    public void TestCallSignBadSignatureProfile() => throw new NYI();




    }
