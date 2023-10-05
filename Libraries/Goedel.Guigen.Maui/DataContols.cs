namespace Goedel.Guigen.Maui;


/// <summary>
/// Extends the <see cref="Button"/> control to add an untyped field to bind callback
/// data.
/// </summary>
public class DataButton : Button {

    ///<summary>The bound data.</summary> 
    public object Data;

    /// <summary>
    /// Constructor, create a new button bound to callback data <paramref name="data"/>.
    /// </summary>
    /// <param name="data">The callback data to be bound to <see cref="Data"/></param>
    public DataButton( object data) {
        Data = data;
        }

    }


