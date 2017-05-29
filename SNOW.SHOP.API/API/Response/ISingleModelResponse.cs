namespace SNOW.SHOP.API.API.Response
{
    public interface ISingleModelResponse<TModel> : IResponse
    {
        TModel Model { get; set; }
    }
}
