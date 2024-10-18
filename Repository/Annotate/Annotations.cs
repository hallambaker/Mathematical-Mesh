using Goedel.Cryptography;
using Goedel.Protocol;

using System.IO;
using System.Net;
using System.Text.Json;

namespace Annotate;


public class Annotation  {
    public string User { get; set; }
    public string Anchor { get; set; }

    public string Semantic { get; set; }

    public string Text { get; set; }

    public bool Written { get; set; } = false;


    public List<string> References { get; set; }

    public Annotation() {
        }

    public Annotation(string user, string anchor, string text, string semantic = null) {
        User = user;
        Anchor = anchor;
        Semantic = semantic;
        References = new List<string>();
        Text = text;
        }


    }


public partial class Annotations {

    public AnnotationService Annotation { get; init; }
    public HttpListenerContext Context { get; init; }

    HttpListenerResponse Response => Context.Response;

    public PageOptions pageOptions = new PageOptions();


    public string UserName { get; set; } = "Fred";

    public byte[] PostData { get; set; }


    public static void PostComment(
                AnnotationService annotation,
                HttpListenerContext context) {

        var comment = JsonSerializer.Deserialize<Annotation>(context.Request.InputStream);

        }


    public static Annotations Get(
                AnnotationService annotation,
                HttpListenerContext context) {
        var writer = new StreamWriter(context.Response.OutputStream);
        var result = new Annotations() {
            Annotation = annotation,
            Context = context,
            _Output = writer
            };

        result.Start();
        return result;
        }


    public static Annotations PostForm(
            AnnotationService annotation,
            HttpListenerContext context,
            FormData formData
            ) {
        var result = Get(annotation, context);
        ParsedMultipart.Parse(context.Request.InputStream, formData);
        return result;
        }






     void Start () {
        StartPage();
        }

    public void End() {
        EndPage();
        _Output.Flush();
        Response.OutputStream.Close();
        }


    }