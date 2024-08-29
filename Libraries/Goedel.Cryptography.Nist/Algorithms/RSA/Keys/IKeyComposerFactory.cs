
namespace Goedel.Cryptography.Nist;

public interface IKeyComposerFactory {
        IRsaKeyComposer GetKeyComposer(PrivateKeyModes privateKeyModes);
        }
    
