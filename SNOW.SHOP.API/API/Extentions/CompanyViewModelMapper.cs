using SNOW.SHOP.API.API.ViewModel;
using SNOW.SHOP.API.src.Model;

namespace SNOW.SHOP.API.API.Extentions
{
    public static class CompanyViewModelMapper
    {
        public static CompanyViewModel ToViewModel(this Company entity)
        {
            return entity == null ? null : new CompanyViewModel
            {
                ID = entity.Id,
                Name = entity.Name
            };
        }

        public static Company ToEntity(this CompanyViewModel viewModel)
        {
            return viewModel == null ? null : new Company
            {
                Id = (int) viewModel.ID,
                Name = viewModel.Name
            };
        }
    }
}
