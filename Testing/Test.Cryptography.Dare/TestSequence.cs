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

namespace Goedel.XUnit;


public record TestBasicParams(
            int Records = 1, int Size = 100, bool Randomsize = true,
            int RandomChecks = 0, int AdditionalChunks = 0) {

    public override string ToString() {
        return $"{Records}-{Size}-{Randomsize}-{RandomChecks}-{AdditionalChunks}";
        }

    }






public record TestSequence : TestBase {


    public SequenceType SequenceType { get; }

    List<SequenceIndexEntry> Entries = new();

    public string Filename { get; }
    public int Records { get; }
    public int Size { get; }
    public bool Randomsize { get; }

    bool IsPlaintext => TestContext.Encrypt == ModeEnhance.None;

    public TestSequence(
                    TestContext context,
                    SequenceType sequenceType = SequenceType.Merkle,
                    int records = 1,
                    int size = 100,
                    bool randomsize = true,
                    int additionalChunks = 1,
                    bool checkSignatures = false,
                    string file = "sequence") : base(context) {

        Records = records;
        Size = size;
        Randomsize = randomsize;
        SequenceType = sequenceType;

        Filename = Seed.GetFilename(file);


        using (var sequence = Sequence.NewSequence(Filename, FileStatus.Overwrite, sequenceType)) {
            for (var i = 0; i < records; i++) {
                (sequence.FrameCount == i + 1).TestTrue();

                var header = new DareHeader() {
                    };
                //var recordSize = RecordSize(sequence.FrameCount);
                //var payload = Seed.GetTestBytes( size, i);
                var payload = GetPlaintext(sequence.FrameCount);
                var entry = sequence.Append(payload);
                }
            }
        if (checkSignatures) {
            ValidateSignature();
            }

        if (additionalChunks > 0) {
            for (var chunk = 0; chunk < additionalChunks; chunk++) {
                MakeAdditionalChunk(chunk);
                }
            if (checkSignatures) {
                ValidateSignature();
                }
            }
        }


    public void MakeAdditionalChunk(int chunk) {

        var additionalRecords = Seed.GetRandomInt(Records, chunk, "additionalChunks");

        using (var sequence = Sequence.OpenExisting(Filename, fileStatus: FileStatus.Append)) {
            var frameCount = sequence.FrameCount;
            for (var i = 0; i < additionalRecords; i++) {
                (sequence.FrameCount == frameCount + i).TestTrue();

                var header = new DareHeader() {
                    };
                //var recordSize = RecordSize(sequence.FrameCount);
                //var payload = Seed.GetTestBytes( Length, i);
                var payload = GetPlaintext(sequence.FrameCount);
                var entry = sequence.Append(payload);
                }
            }
        }



    byte[] GetPlaintext(long frame) {
        var recordSize = RecordSize(frame);
        return Seed.GetTestBytes(recordSize, frame);
        }

    int RecordSize(long frame) => Randomsize ? Seed.GetRandomInt(Size, (int)frame) : Size;

    public void ValidatePayload() {

        using var stream = Filename.OpenFileRead();
        foreach (var entry in Entries) {

            var payload = GetPlaintext(entry.Index);
            Validate(stream, entry, payload);
            }

        }

    public void RandomCheck(int frame) {
        using var sequence = Sequence.OpenExisting(Filename);
        var entry = sequence.Frame(frame);
        var plaintext = GetPlaintext(entry.Index);

        var payload = entry.GetPayload();

        payload.TestEqual(plaintext);
        }



    void Validate(
               FileStream stream,
               SequenceIndexEntry entry,
               byte[] data
               ) {

        // check frame boundaries
        (entry.FramePosition < entry.DataPosition).TestTrue();
        (entry.FrameLength > entry.DataLength).TestTrue();

        // check data boundaries
        (entry.DataLength == data.Length).TestTrue();

        // check data segment
        stream.Position = entry.DataPosition;

        var equal = CheckEqual(stream, entry.DataLength, data);
        (equal == IsPlaintext).TestTrue();

        // No, cannot use a switch here.
        if (entry.Sequence.GetType() == typeof(SequenceChain) |
            entry.Sequence.GetType() == typeof(SequenceDigest) |
            entry.Sequence.GetType() == typeof(SequenceMerkleTree)) {
            ValidateDigest(entry, data);
            }
        }


    static bool CheckEqual(FileStream stream, long length, byte[] data) {
        for (var i = 0; i < length; i++) {
            var b = stream.ReadByte();
            if (data[i] != b) {
                return false;
                }
            }

        return true;
        }



    static void ValidateDigest(SequenceIndexEntry entry, byte[] data) {
        var payloadDigest = entry.PayloadDigest;
        payloadDigest.TestNotNull();


        var digestAlgorithm = entry.Header.DigestAlgorithm;
        var digestAlgorithmId = digestAlgorithm.FromJoseIDDigest();

        var hashAlgorithm = digestAlgorithmId.CreateDigest();


        var digest = hashAlgorithm.ComputeHash(data);

        digest.TestEqual(payloadDigest);

        }

    public void CheckChain() {
        if (Entries.Count == 0) {
            return;
            }

        byte[] lastDigest = null;

        var digestAlgorithm = Entries[0].Header.DigestAlgorithm;
        var digestAlgorithmId = digestAlgorithm.FromJoseIDDigest();
        var hashAlgorithm = digestAlgorithmId.CreateDigest();

        foreach (var entry in Entries) {
            var payloadDigest = entry.PayloadDigest;
            var chainDigest = entry.ChainDigest;
            chainDigest.TestNotNull();

            var buffer = Add(hashAlgorithm.HashSize, lastDigest, payloadDigest);
            var digest = hashAlgorithm.ComputeHash(buffer);

            digest.TestEqual(chainDigest);
            }
        }




    static byte[] Add(int size, byte[] first, byte[] second) {
        var length = size / 8;

        var result = new byte[length * 2];

        if (first is not null) {
            (first.Length == length).TestTrue();
            Array.Copy(first, result, length);
            }
        if (second is not null) {
            (second.Length == length).TestTrue();
            Array.Copy(second, 0, result, length, length);
            }
        return result;
        }




    public void CheckDecryptCorruptData(int tests) {
        (TestContext.Corruption == ModeCorruption.Data).TestTrue();

        for (var i = 0; i < tests; i++) {
            var frame = Seed.GetRandomInt(Records, i, "randomAccess1");

            CorruptFrame(frame);

            using var sequence = OpenSequence();
            DecryptFail(sequence, frame);
            }
        }

    public void CheckDecryptCorruptKey(int tests) {
        (TestContext.Corruption == ModeCorruption.Key).TestTrue();

        for (var i = 0; i < tests; i++) {
            var frame = Seed.GetRandomInt(Records, i, "randomAccess2");
            using var sequence = OpenSequence(TestContext.BadKeyCollection);
            DecryptFail(sequence, frame);
            }

        }

    public void CheckSignCorruptData(int tests) {
        (TestContext.Corruption == ModeCorruption.Data).TestTrue();

        for (var i = 0; i < tests; i++) {
            var frame = Seed.GetRandomInt(Records, i, "randomAccess3");

            CorruptFrame(frame);

            using var sequence = OpenSequence();
            VerifyFail(sequence, frame);
            }
        }

    public void CheckSignCorruptKey(int tests) {
        (TestContext.Corruption == ModeCorruption.Key).TestTrue();

        for (var i = 0; i < tests; i++) {
            var frame = Seed.GetRandomInt(Records, i, "randomAccess4");
            using var sequence = OpenSequence(TestContext.BadKeyCollection);
            VerifyFail(sequence, frame);
            }

        }


    /* ************** To be implemented ************** */

    public void CheckTree() {
        foreach (var entry in Entries) {
            }
        }

    public void CheckMerkle() {
        foreach (var entry in Entries) {

            }
        }


    public void CheckProofs(int tests) {
        //throw new NYI();
        }


    Sequence OpenSequence(IKeyLocate keyCollection = null) =>
            Sequence.OpenExisting(Filename, keyCollection: keyCollection);

    public void ValidateCiphertext() {
        //throw new NYI();
        }
    public void ValidatePlaintext() {
        //throw new NYI();
        }
    public void ValidateSignature() {
        //throw new NYI();
        }

    void CorruptFrame(int frame) {
        //throw new NYI();
        }

    void DecryptFail(Sequence sequence, int frame) {
        //throw new NYI;
        }

    void VerifyFail(Sequence sequence, int frame) {
        //throw new NYI();
        }

    }
