using shalemServer.Models;

namespace shalemServer.Interfaces
{
    public interface IManaRepository
    {
        Task<IEnumerable<ListSkinny>> GetAllManaAsync();
    }
}
