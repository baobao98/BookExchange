using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookExchange.Models.DBModels;
using BookExchange.Models.DBModelsP;

namespace BookExchange.ViewComponents
{
    public class bookCatalogViewComponent : ViewComponent
    {
        private BookExchangeDBContext _context = new BookExchangeDBContext();
        public bookCatalogViewComponent()
        {
            
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<CatalogItem> catalogItems = new List<CatalogItem>();
            // after calling group by we will get a serial of group Sach then every group sach has its own key and also iz an inumerable sach
            // therefore just call key and count and we will get what we want
            var catalog = _context.Sach.GroupBy(sach => sach.MaTlNavigation)
                                        .Select(group =>
                                        new
                                        {
                                            id = group.Key.MaTl,
                                            name = group.Key.TenTl,
                                            Count = group.Count()
                                        });
            foreach(var item in catalog)
            {
                catalogItems.Add(new CatalogItem { matl = item.id, tentl = item.name, soLuong = item.Count });
            }

            return View(catalogItems);
        }
    }
}
