using Newtonsoft.Json;

namespace Monkey_Api.Repository
{
    public interface IMonkeyShelter
    {
        IEnumerable<Monkey> GetMonkeysFromDB(string fileName);
        Array GetSpieces();
        Array GetSpiecesCount();
    }
}
