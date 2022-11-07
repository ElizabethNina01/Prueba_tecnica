

namespace prueba_back.Domain.Services.Communication
{
    public class SaveItemResponse : BaseResponse<Model.Item>
    {
        public Model.Item item {get; private set;}
        public SaveItemResponse(Model.Item resource) : base(resource) { }
        public SaveItemResponse(string message = null) : base(message) { }

    }
}