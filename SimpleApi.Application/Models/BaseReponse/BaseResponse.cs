using System.Collections.ObjectModel;

namespace SimpleApi.Application.Models.BaseReponse
{
    public class BaseResponse
    {
        public bool IsSuccessful { get; set; } = true;

        private  IList<string> _errors = new List<string>();

        public IList<string> Errors { get => new ReadOnlyCollection<string>(_errors); set => _errors = value; }

        public BaseResponse() { }

        public void AddErrors(string error)
        {
            IsSuccessful = false;
            _errors.Add(error);
        }
    }
}
