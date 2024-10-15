using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EverythingWeb.Pages; 



public class AddedModel : PageModel {

    //[BindProperty]
    public string? FileUpload { get; set; }
    public int UploadedBytes { get; set; }

    public void OnGet() {
        }

    [ValidateAntiForgeryToken]
    public IActionResult OnPost() {
        //FileUpload = Request.Form["fileUpload"];
        //UploadedBytes = FileUpload?.Length ?? 0;


        return Page();
        }

    }

