using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace EasyAbp.GiftCardManagement.Pages
{
    public class IndexModel : GiftCardManagementPageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}