using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EverythingWeb.Pages;
public class NotificationsModel : PageModel {
    private readonly ILogger<NotificationsModel> _logger;

    public NotificationsModel(ILogger<NotificationsModel> logger) {
        _logger = logger;
        }

    public void OnGet() {

        }
    }
