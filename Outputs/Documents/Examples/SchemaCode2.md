~~~~
static string MakeID(string udf, string content) {
    var (code, bds) = Udf.Parse(udf);
    return code switch
        {
            UdfTypeIdentifier.Digest_SHA_3_512 => 
                Udf.ContentDigestOfDataString(
                bds, content, cryptoAlgorithmId: 
                    CryptoAlgorithmId.SHA_3_512),
            _ => Udf.ContentDigestOfDataString(
            bds, content, cryptoAlgorithmId: 
                    CryptoAlgorithmId.SHA_2_512),
            };
~~~~
