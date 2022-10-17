using System.Threading.Tasks;

namespace WeddingAlbum.Common.CQRS
{
    public interface IQueryDispatcher
    {
        Task<TResult> Dispatch<TResult>(IQuery<TResult> query);
    }
}
