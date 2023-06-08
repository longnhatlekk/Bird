namespace BirdPlatForm.Product
{
    public interface IHomeViewProductService
    {
        Task<List<HomeViewProduct>> GetAllByQuantitySold();
        Task<List<HomeViewProduct>> GetProductByRateAndQuantitySold();

        Task<DetailProductViewModel> GetProductById(int id);
    }
}
