namespace OrderSystemV1.Domain.Interfaces
{
    public interface IUnityOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
