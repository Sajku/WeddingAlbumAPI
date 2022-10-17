using System.Threading.Tasks;

namespace WeddingAlbum.Common.CQRS
{
    public interface ICommandDispatcher
    {
        Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
