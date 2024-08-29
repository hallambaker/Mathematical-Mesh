namespace Goedel.Cryptography.Nist;
public interface IEccCurveFactory {
        IEccCurve GetCurve(Curve curve);
        }
    
