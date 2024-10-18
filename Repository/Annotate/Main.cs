using Goedel.Protocol;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Windows.ApplicationModel.DataTransfer;

using static System.Net.Mime.MediaTypeNames;

namespace Annotate;

internal sealed class Program {

    // We can decorate this with stuff later.
    static void Main(string[] args) {
        var AnnotationService = new AnnotationService();
        AnnotationService.Start();
        }





    }


public class AnnotationService: IWebService {

    private HttpListener HttpListener { get; set; }

    ///<inheritdoc/>
    public Dictionary<string, Resource> ResourceMap => resourceMap;
    
    static Dictionary<string, Resource> resourceMap = new() {
        { "/", new (GetHome) },
        { "/Upload", new (GetSelectUpload) },
        { "/Append", new (PostUploadDocument) },
        { "/Documents", new (GetListDocuments) },
        { "/Actions", new (GetListActions) },
        { "/Document", new (GetShowDocument) },
        { "/Comment", new (GetComment) },
        { "/CommentForm", new (MakeComment) },
        { "*", new (Error) }

        };


    public AnnotationService () {
        HttpListener = new();
        HttpListener.Prefixes.Add("http://+:15099/");
        }


    public void Start() {
        HttpListener.Start();
        Console.WriteLine("Listening...");
        while (true) {
            HttpListenerContext context = HttpListener.GetContext();

            var task = HandleRequest(context);
            }
        }


    public async Task HandleRequest(HttpListenerContext context) {

        var request = context.Request;
        var response = context.Response;

        // This should never happen.
        if (request.Url is null) {
            await Error(this, context);
            return; 
            }

        // Look for a dispatch method and use it if found.
        if (ResourceMap.TryGetValue(request.Url.LocalPath, out var callback)) {
            await callback.Method(this, context);
            }
        else {
            await Error(this, context);
            }
        }

    public static async Task GetHome(
                IWebService service,
                HttpListenerContext context) {
        var annotation = service as AnnotationService;
        var annotations = Annotations.Get(annotation, context);
        annotations.PageHome();
        annotations.End();
        }

    public static async Task GetSelectUpload(
                IWebService service,
                HttpListenerContext context) {
        var annotation = service as AnnotationService;
        var annotations = Annotations.Get(annotation, context);
        annotations.PageSelect();
        annotations.End();
        }


    public static async Task MakeComment(
            IWebService service,
            HttpListenerContext context) {
        var annotation = service as AnnotationService;
        var annotations = Annotations.Get(annotation, context);
        annotations.PageEnterComment();
        annotations.End();
        }


    public static async Task GetComment(
                IWebService service,
                HttpListenerContext context) {
        var annotation = service as AnnotationService;
        Annotations.PostComment(annotation, context);


        }


    public static async Task PostUploadDocument (
                IWebService service,
                HttpListenerContext context) {
        var annotation = service as AnnotationService;
        var fields = new FormDataUpload();

        var annotations = Annotations.PostForm(annotation, context, fields);

        //ParsedMultipart.Parse(annotations.PostData);


        annotations.PageUpload();
        annotations.End();
        }

    public static async Task GetListDocuments(
                IWebService service,
                HttpListenerContext context) {
        var annotation = service as AnnotationService;
        var annotations = Annotations.Get(annotation, context);
        annotations.PageDocuments();
        annotations.End();
        }

    public static async Task GetListActions(
                IWebService service,
                HttpListenerContext context) {
        var annotation = service as AnnotationService;
        var annotations = Annotations.Get(annotation, context);
        annotations.PageActions();
        annotations.End();
        }

    public static async Task GetShowDocument(
                IWebService service,
                HttpListenerContext context) {
        var annotation = service as AnnotationService;
        var annotations = Annotations.Get(annotation, context);
        annotations.PageDocument();
        annotations.End();
        }

    public static async Task Error(
                IWebService service,
                HttpListenerContext context) {
        var annotation = service as AnnotationService;
        var annotations = Annotations.Get(annotation, context);
        annotations.PageHome();
        annotations.End();
        }


    }






public class FormDataUpload : FormData {

    protected override FormItem[] Items => items;
    static readonly FormItem[] items = [
        new ("data", FormEntryType.File, (form, s) => ((FormDataUpload)form).Data = s as FileField),
        new ("format", FormEntryType.String, (form, s) => ((FormDataUpload)form).Format = s as string)
        ];

    string? Format {get; set; }
    FileField? Data { get; set; }
        

    }


public class FormDataComment : FormData {

    protected override FormItem[] Items => items;
    static readonly FormItem[] items = [
        new ("user", FormEntryType.String, (form, s) => ((FormDataComment)form).User = s as string),
        new ("semantic", FormEntryType.String, (form, s) => ((FormDataComment)form).Semantic = s as string),
        new ("comment", FormEntryType.String, (form, s) => ((FormDataComment)form).Comment = s as string)
        ];

    string? User { get; set; }
    string? Semantic { get; set; }
    string? Comment { get; set; }

    }




public class PageOptions {
    }
