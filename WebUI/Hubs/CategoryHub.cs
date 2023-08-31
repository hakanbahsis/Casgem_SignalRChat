using Microsoft.AspNetCore.SignalR;
using WebUI.Models;

namespace WebUI.Hubs
{
    public class CategoryHub:Hub
    {
       private readonly Context _context;

        public CategoryHub(Context context)
        {
            _context = context;
        }

        public async Task UpdateCategoryCount()
        {
            var count = _context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount",count);
        }
    }
}
