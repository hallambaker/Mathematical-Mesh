
using System.Threading.Tasks;

namespace Goedel.Utilities;



/// <summary>
/// Injection interface to allow declaration of component modules.
/// </summary>
public interface IComponent {

    /// <summary>
    /// Initialization method, is called by the dependency builder method during host
    /// configuration.
    /// </summary>
    void Initialize();


    }

