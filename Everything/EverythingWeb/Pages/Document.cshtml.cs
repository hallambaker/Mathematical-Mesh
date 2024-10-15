using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EverythingWeb.Pages;
public class DocumentModel : PageModel {
    private readonly ILogger<DocumentModel> _logger;

    public DocumentModel(ILogger<DocumentModel> logger) {
        _logger = logger;
        }

    public void OnGet() {

        }
    }
