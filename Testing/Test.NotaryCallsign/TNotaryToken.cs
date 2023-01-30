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





using Goedel.Cryptography.Dare;
using Goedel.Test;
using Microsoft.VisualBasic;

namespace Goedel.XUnit;



public record ParametersClaim  {
    public int SequenceLength { get; }
    public int Claims { get; }
    public int Iteration { get; }
    public DeterministicSeed Seed { get; }


    public ParametersClaim(
            int sequenceLength = 10,
            int claims = 2,
            int iteration = 0) {
        SequenceLength = sequenceLength; 
        Claims = claims;
        Iteration = iteration;

        Seed = DeterministicSeed.CreateDeep(2, ToString());
        }


    public SequenceMerkleTree CreateChain() {
        throw new NYI();
        }

    public SequenceMerkleTree OpenChain() {
        throw new NYI();
        }

    public SequenceMerkleTree CorruptChain() {
        throw new NYI();
        }


    public DareEnvelope[] GetFrames(long[] frames) => throw new NYI();


    public ProofChain MakeCorrupted (ProofChain original) => throw new NYI();


    public DareEnvelope[] MakeCorrupted(DareEnvelope[] frames) => throw new NYI();


    public long[] GetCheckFrames() { 
            throw new NYI(); 
            }


    public override string ToString() => $"{SequenceLength}-{Claims}-{Iteration}";
    }



public partial class TClaimProof {

    public static TClaimProof Test() => new();


    /// <summary>
    /// Create and test a proof chain over a sequence.
    /// </summary>
    /// <param name="parameters"></param>
    [Theory(Skip = "Proof chain not yet implemented")]
    [InlineData()]
    public void TestProof(ParametersClaim parameters = null) {
        parameters ??= new();


        ProofChain proof;
        var checkFrames = parameters.GetCheckFrames();

        // Create chain of length parameters.SequenceLength
        using (var sequence = parameters.CreateChain()) {
            // Extract a proof chain 
            proof = sequence.GetProofChain(checkFrames);
            }

        // Check verification of the proof succeeds.
        proof.Verify().TestTrue() ;

        // Check verification of the proof envelopes succeeds.
        var frames = parameters.GetFrames(checkFrames);
        proof.Verify(frames).TestTrue();

        // Corrupt the frame data and check verification fails
        var corruptedFrames = parameters.MakeCorrupted(frames);
        proof.Verify(frames).TestFalse();

        // Corrupt the proof and check that it fails with and without the envelopes
        var corruptedProof = parameters.MakeCorrupted(proof);
        corruptedProof.Verify().TestFalse();
        corruptedProof.Verify(frames).TestFalse();
        }


    /// <summary>
    /// Construct and verify standalone notary token
    /// </summary>
    /// <param name="parameters"></param>
    [Theory(Skip = "Proof chain not yet implemented")]
    [InlineData()]
    public void TestNotaryToken(ParametersClaim parameters = null) => throw new NYI();


    /// <summary>
    /// Create two notary chains A, B. Construct a notary token on A. Enroll the token from A
    /// on B and create a notary token on B and enroll it on A.
    /// 
    /// Insert filler records in A and B such that the resulting chains are
    /// 
    /// A: [Filler1] Token-A1 [Filler2] Token-A2(B1) [Filler3]
    /// B: [Filler4] Token-B1(A1) [Filler5]
    /// 
    /// Select random frames and verify that:
    /// 
    /// Verify [Filler1] => [0..Token-A1], [..Token-B1(A1)]
    /// Verify [Filler2] => [Token-A1..Token-A2(B1)], [..Token-B1(A1)]
    /// Verify [Filler3] => [Token-A2(B1)..], [Token-B1(A1)..]
    /// Verify [Filler4], etc
    /// 
    /// Continue for N iterations on 
    /// 
    /// </summary>
    /// <param name="parameters"></param>
    [Theory(Skip = "Proof chain not yet implemented")]
    [InlineData()]
    public void TestEnrolledNotaryToken (ParametersClaim parameters = null) => throw new NYI();

    /// <summary>
    /// Create a notary spool, enroll documents in spool, at intervals create notary tokens and
    /// incorporate reference to the latest token in each signature.
    /// </summary>
    /// <param name="parameters"></param>
    /// <exception cref="NYI"></exception>
    [Theory(Skip = "Proof chain not yet implemented")]
    [InlineData()]
    public void TestNotarizedSignature(ParametersClaim parameters = null) => throw new NYI();

    /// <summary>
    /// The test <see cref="TestNotarizedSignature"/> but with a common Mesh Service Provider 
    /// servicing the Mesh accounts. 
    /// </summary>
    /// <param name="parameters"></param>
    /// <exception cref="NYI"></exception>
    [Theory(Skip = "Proof chain not yet implemented")]
    [InlineData()]
    public void TestServiceNotarizedSignature(ParametersClaim parameters = null) => throw new NYI();

    /// <summary>
    /// The test <see cref="TestServiceNotarizedSignature"/> but with a common Mesh Service Provider 
    /// servicing multile Mesh accounts. 
    /// </summary>
    /// <param name="parameters"></param>
    /// <exception cref="NYI"></exception>
    [Theory(Skip = "Proof chain not yet implemented")]
    [InlineData()]
    public void TestMultiNotarizedSignature(ParametersClaim parameters = null) => throw new NYI();


    /// <summary>
    /// The test <see cref="TestMultiNotarizedSignature"/> but with a central node servicing 
    /// multiple Mesh Service Providers, each servicing multile Mesh accounts. 
    /// </summary>
    /// <param name="parameters"></param>
    /// <exception cref="NYI"></exception>
    [Theory(Skip = "Proof chain not yet implemented")]
    [InlineData()]
    public void TestWebNotarizedSignature(ParametersClaim parameters = null) => throw new NYI();
    }
