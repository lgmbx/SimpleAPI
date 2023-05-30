namespace SimpleApi.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Commit();

        
    }
}
