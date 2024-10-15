namespace EverythingWeb.Model;



public sealed class ForumModel {

    public string Name { get; set; } = "Fred";


    private static readonly Lazy<ForumModel> lazy =
    new Lazy<ForumModel>(() => new ForumModel());

    public static ForumModel Instance { get { return lazy.Value; } }

    private ForumModel() {
        }

    }



public class Forum {


    public int Id { get; set; }

    public String? Title { get; set; }

    public String? User { get; set; }


    }



public class Document {
    public int Id { get; set; }

    public string? Title {get; set;}
    
    }



public class Comments {
    public int Id { get; set; }
    public string? Anchor {get; set;}
    public string? Text { get; set; }


    }
