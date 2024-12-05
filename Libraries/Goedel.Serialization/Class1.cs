namespace Goedel.Serialization;

/// <summary>
/// The Form entry types
/// </summary>
public enum FormEntryType {
    Boolean,
    ArrayBoolean,
    Integer,
    ArrayInteger,
    String,
    ArrayString,
    Object,
    ArrayStruct
    }




public interface ISerializable {
    FormFields[] Fields { get; } 
    }

public record FormFields(
            string Name,
            FormEntryType FormEntryType,
            Action<ISerializable, object> Setter,
            Func<ISerializable, object?>? Getter=null,
            Func<ISerializable>? factory = null
            ) {
    }





