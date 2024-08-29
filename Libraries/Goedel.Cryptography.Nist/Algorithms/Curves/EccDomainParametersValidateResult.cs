﻿namespace Goedel.Cryptography.Nist;
public class EccDomainParametersValidateResult : IDomainParametersValidateResult {
    public string ErrorMessage { get; }

    public EccDomainParametersValidateResult() { }

    public EccDomainParametersValidateResult(string errorMessage) {
        ErrorMessage = errorMessage;
        }

    public bool Success => string.IsNullOrEmpty(ErrorMessage);
    }

