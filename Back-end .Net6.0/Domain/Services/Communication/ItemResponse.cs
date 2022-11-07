namespace prueba_back.Domain.Services.Communication
{
    public class ItemResponse: BaseResponse<Model.Item>
    {
        public ItemResponse(string message) : base(message) { }

        public ItemResponse(Model.Item item) : base(item) { }
    }
}