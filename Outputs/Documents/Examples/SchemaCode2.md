~~~~
static string MakeID(string udf, string content) {
    var (code, bds) = UDF.Parse(udf);
    return code switch
        {
            UdfTypeIdentifier.Digest_SHA_3_512 => 
                UDF.ContentDigestOfDataString(
                bds, content, cryptoAlgorithmId: 
                    CryptoAlgorithmId.SHA_3_512),
            _ => UDF.ContentDigestOfDataString(
            bds, content, cryptoAlgorithmId: 
                    CryptoAlgorithmId.SHA_2_512),
            };
~~~~
