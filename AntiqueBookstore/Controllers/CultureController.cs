using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace AntiqueBookstore.Controllers
{
    public class CultureController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Set(string culture, string returnUrl)
        {
            // Protect from open redirects
            if (string.IsNullOrWhiteSpace(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                returnUrl = Url.Action("Index", "Home") ?? "/";
            }

            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions
                {
                    IsEssential = true,
                    Expires = DateTimeOffset.UtcNow.AddDays(7)
                });

            return LocalRedirect(returnUrl);
        }
    }
}
