using BirdPlatForm.BirdPlatform;
using Microsoft.EntityFrameworkCore;

namespace BirdPlatForm.Product
{
    public class HomeViewProductService : IHomeViewProductService
    {
        private readonly BirdPlatFormContext _context;

        public HomeViewProductService(BirdPlatFormContext context)
        {
           _context = context;
        }
        public async Task<List<HomeViewProduct>> GetAllByQuantitySold()
        {
            var query = from p in _context.TbProducts
                        join s in _context.TbShops on p.ShopId equals s.ShopId
                        join c in _context.TbProductCategories on p.CateId equals c.CateId
                        join dc in _context.TbDiscounts on p.DiscountId equals dc.Id
                        orderby p.QuantitySold descending
                        select new { p, dc };

            var data = await query.Select(x => new HomeViewProduct()
            {
                ProductId = x.p.ProductId,
                Name = x.p.Name,
                Status = x.p.Status,
                Price = x.p.Price,
                DiscountPercent = (int)x.p.Price - x.p.Price * x.dc.DiscountPercent  ,
                Decription = x.p.Decription,
                QuantitySold = x.p.QuantitySold,
                Rate = x.p.Rate,
                Image = x.p.Image
            }).ToListAsync();
            return data;





        }

       

        public async Task<List<HomeViewProduct>> GetProductByRateAndQuantitySold()
        {
            var query = from p in _context.TbProducts
                        join s in _context.TbShops on p.ShopId equals s.ShopId
                        join c in _context.TbProductCategories on p.CateId equals c.CateId
                        join dc in _context.TbDiscounts on p.DiscountId equals dc.Id
                        orderby p.Rate descending, p.QuantitySold descending
                        select new { p, dc };

            var data = await query.Select(x => new HomeViewProduct()
            {
                ProductId = x.p.ProductId,
                Name = x.p.Name,
                Status = x.p.Status,
                Price = x.p.Price,
                DiscountPercent = (int)x.p.Price - x.p.Price * x.dc.DiscountPercent ,
                Decription = x.p.Decription,
                QuantitySold = x.p.QuantitySold,
                Rate = x.p.Rate,
                Image = x.p.Image
            }).ToListAsync();
            return data;
        }

        public async Task<DetailProductViewModel> GetProductById(int productId)
        {
            var product = await _context.TbProducts.FindAsync(productId);
            var discount = await _context.TbDiscounts.FirstOrDefaultAsync(x => x.ProductId == productId);
      //   var post = await _context.TbPosts.FirstOrDefaultAsync(x => x.ProductId == productId);

            //var query = from p in _context.TbProducts
            //            join s in _context.TbShops on p.ShopId equals s.ShopId
            //            join c in _context.TbProductCategories on p.CateId equals c.CateId
            //            join dc in _context.TbDiscounts on p.DiscountId equals dc.Id
            //            join fb in _context.TbFeedbacks on p.ProductId equals fb.ProductId

            //            select new { p, s, dc };

            var detailProductViewModel =  new DetailProductViewModel()
            {
                ProductId = product.ProductId,
                Name = product.Name,
    //            CreateDate = post.CreateDate,
                Status = product.Status,
                Price = product.Price,
                DiscountPercent = (int)product.Price - product.Price * discount.DiscountPercent,
                Decription = product !=null ? product.Decription : null,
                Detail= product != null ? product.Detail : null,
                QuantitySold = product.QuantitySold,
                ShopId = product.ShopId,
                Rate = product.Rate,
                Video = product.Video,
                Image = product.Image,
                Image1 = product.Image1,
                Image2 = product.Image2,
                Image3 = product.Image3,
                Image4 = product.Image4
            };
            return detailProductViewModel;
        }

        public async Task<List<HomeViewProduct>> GetProductByShopId(int shopId)
        {
            var product = await _context.TbShops.FindAsync(shopId);
            if (shopId == 0) throw new Exception("Can not find shopId");
            var query = from p in _context.TbProducts
                        join s in _context.TbShops on p.ShopId equals s.ShopId
                        join c in _context.TbProductCategories on p.CateId equals c.CateId
                        join dc in _context.TbDiscounts on p.DiscountId equals dc.Id
                        where p.ShopId.Equals(shopId)
                        select new { p, dc };
            
         
            
            var data = await query.Select(x => new HomeViewProduct()
            {
                ProductId = x.p.ProductId,
                Name = x.p.Name,
                Status = x.p.Status,
                Price = x.p.Price,
                DiscountPercent = (int)x.p.Price - x.p.Price * x.dc.DiscountPercent,
                Decription = x.p.Decription,
                QuantitySold = x.p.QuantitySold,
                Rate = x.p.Rate,
                Image = x.p.Image
            }).ToListAsync();
            return data;
        }
    }
}
