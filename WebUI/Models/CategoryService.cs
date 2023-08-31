using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WebUI.Hubs;

namespace WebUI.Models
{
    public class CategoryService
    {
        private readonly Context _context;
        private readonly IHubContext<CategoryHub> _hubContext;

        public CategoryService(Context context, IHubContext<CategoryHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public async Task AddCategory(Category newCategory)
        {
            // Kategori ekleme işlemleri...
            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();

            // Kategori sayısını güncelle ve istemcilere gönder
            int categoryCount = await _context.Categories.CountAsync();
            await _hubContext.Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);
        }

      
    }
}
