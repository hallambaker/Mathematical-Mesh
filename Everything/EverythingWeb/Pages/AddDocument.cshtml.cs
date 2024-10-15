using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EverythingWeb.Pages;
public class AddDocument : PageModel {
    private readonly ILogger<AddDocument> _logger;

    public AddDocument(ILogger<AddDocument> logger) {
        _logger = logger;
        }

    public void OnGet() {

        }
    }
