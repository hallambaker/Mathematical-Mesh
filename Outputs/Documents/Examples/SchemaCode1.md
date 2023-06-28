~~~~
public static string GetEnvelopeId(string messageID) =>
            Udf.ContentDigestOfUDF(messageID);
~~~~
