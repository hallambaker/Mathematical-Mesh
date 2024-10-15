using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EverythingWeb.Model;
namespace EverythingWeb.Pages;


public class IndexModel : PageModel {
    private  ILogger<IndexModel> Logger { get; }
    private  ForumModel Model { get; }


    public string Name = "fred";

    public IndexModel(ForumModel model,
                ILogger<IndexModel> logger) {
        Logger = logger;
        Model = model;
        }

    public void OnGet() {

        }
    }
