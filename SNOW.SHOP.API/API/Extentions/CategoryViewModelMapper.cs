using SNOW.SHOP.API.API.ViewModel;
using SNOW.SHOP.API.src.Model;

namespace SNOW.SHOP.API.API.Extentions
{
    public static class CategoryViewModelMapper
    {
        public static CategoryViewModel ToViewModel(this Category entity)
        {
            return entity == null ? null : new CategoryViewModel
            {
                ID = entity.Id,
                Name = entity.Name,
               // Company = entity.Company
            };
        }

        public static Category ToEntity(this CategoryViewModel viewModel)
        {
            return viewModel == null ? null : new Category
            {
                Id = (int) viewModel.ID,
                Name = viewModel.Name
              //  Company = viewModel.Company
            };
        }
    }
}
