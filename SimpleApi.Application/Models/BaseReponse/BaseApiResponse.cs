namespace SimpleApi.Application.Models.BaseReponse
{
    public class BaseApiResponse<T> : BaseResponse
    {
        public T? Response { get; set; }

        public BaseApiResponse()
        {
            Response = default;
        }
        public BaseApiResponse(T? response)
        {
            Response = response;
        }

    }
}
