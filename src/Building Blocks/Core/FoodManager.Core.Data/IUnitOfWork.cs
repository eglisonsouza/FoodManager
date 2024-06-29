namespace FoodManager.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}