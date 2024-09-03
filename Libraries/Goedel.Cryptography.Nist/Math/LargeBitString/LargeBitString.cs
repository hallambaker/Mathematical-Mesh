﻿namespace Goedel.Cryptography.Nist;
public class LargeBitString {
    public BitString Content { get; set; }
    public int ContentLength => Content?.BitLength ?? 0;
    public long FullLength { get; set; }
    public ExpansionMode ExpansionTechnique { get; set; }
    }
