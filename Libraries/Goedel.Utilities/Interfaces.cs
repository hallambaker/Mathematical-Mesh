namespace Goedel.Utilities;



/// <summary>
/// Injection interface to allow declaration of component modules.
/// </summary>
public interface IComponent {

    /// <summary>
    /// Initialization method, is called when the application is started.
    /// </summary>
    void Initialize();

    /// <summary>
    /// Termination method, is called when the application is shut down.
    /// </summary>
    void Terminate();
    }

/// <summary>
/// Application lifecycle management class. Automates initialization and graceful 
/// termination.
/// </summary>
public class LifeCycle : Disposable {

    IEnumerable<IComponent> Components { get; }

    ///<inheritdoc/>
    protected override void Disposing() {
        foreach (var component in Components) {
            component.Terminate();
            }
        }

    /// <summary>
    /// Default constructor. May be called directly or through dependency injection.
    /// </summary>
    /// <param name="components">The components to be managed.</param>
    public LifeCycle(
        IEnumerable<IComponent> components
        ) {
        Components = components;

        foreach (var component in Components) {
            component.Initialize();
            }
        }

    /// <summary>
    /// Add the component <paramref name="component"/> to be managed under the lifecycle.
    /// </summary>
    /// <param name="component">The component to add. </param>
    public void Add(IComponent component) {
        _ = Components.Append(component);
        }

    }