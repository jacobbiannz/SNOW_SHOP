using SNOW.SHOP.API.API.ViewModels;
using SNOW.SHOP.API.src.Model;

namespace SNOW.SHOP.API.API.Extentions
{
    public static class ProductViewModelMapper
    {
        public static ProductViewModel ToViewModel(this Product entity)
        {
            return entity == null ? null : new ProductViewModel
            {
                ID = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                MarketPrice = entity.MarketPrice,
                StockPrice = entity.StockPrice
            };
        }

        public static Product ToEntity(this ProductViewModel viewModel)
        {
            return viewModel == null ? null : new Product
            {
                Id = (int) viewModel.ID,
                Name = viewModel.Name,
                Description = viewModel.Description,
                MarketPrice = viewModel.MarketPrice,
                StockPrice = viewModel.StockPrice
            };
        }
    }
}
