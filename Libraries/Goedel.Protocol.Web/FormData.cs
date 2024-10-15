namespace Goedel.Protocol.Web;

/// <summary>
/// The Form entry types
/// </summary>
public enum FormEntryType {
    ///<summary>String form entry</summary> 
    String,
    ///<summary>File form entry</summary> 
    File,
    ///<summary>Binary data form entry</summary> 
    Binary
    }


/// <summary>
/// Form item accessor describes the backer class for a form item.
/// </summary>
/// <param name="Name">The form entry name.</param>
/// <param name="FormEntryType">The type of the data item.</param>
/// <param name="Setter">Setter method setting the value in the form.</param>
public record FormItem(
        string Name,
        FormEntryType FormEntryType,
        Action<FormData, object> Setter
        ) {
    }

/// <summary>
/// Backer record describing a file read from an input field.
/// </summary>
/// <param name="Id">Unique identifier.</param>
/// <param name="Filename">The filename used on the source machine.</param>
/// <param name="ContentType">The content type.</param>
/// <param name="Data">The binary file data.</param>
public record FileField(
        string? Id,
        string? Filename,
        string? ContentType,
        byte[]? Data

        ) {
    }

/// <summary>
/// Root class for form data descriptors.
/// </summary>
public abstract class FormData {

    ///<summary>The form field descriptors.</summary> 
    protected virtual FormItem[] Items { get; }

    ///<summary>Return the form item for the form field named 
    ///<paramref name="name"/></summary> 
    ///<param name="name">The form field name.</param>
    ///<returns>The form item.</returns>
    public FormItem? GetFormItem(string name) {
        foreach (var item in Items) {
            if (item.Name == name) {
                return item;
                }
            }
        return null;
        }

    }
