
namespace Library.Repositories
{
    internal interface IUnitOfWork: IDisposable
    {
        IBookRepository Book { get; }
        int Complete();
    }
}
