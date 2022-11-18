using Newtonsoft.Json;

namespace Monkey_Api.Repository
{
    public class MonkeyShelter : IMonkeyShelter
    {
        private readonly string fileName = "monkeycollection" + ".json";
        
        public Array GetSpieces()
        {
            IEnumerable<Monkey> monkeys = GetMonkeysFromDB(fileName);

            Array displayedStoring =  monkeys.DistinctBy(x => x.species).Select(x => x.species).ToArray();
            return displayedStoring;
        }

        public Array GetSpiecesCount()
        {
            IEnumerable<Monkey> monkeys = GetMonkeysFromDB(fileName);

            Array SpiecesCount = monkeys.GroupBy(x => x.species)
                                .Select(g => new { Name = g.Key, Count = g.Count() })
                                .ToArray();
            return SpiecesCount;
        }

        public IEnumerable<Monkey> GetMonkeysFromDB(string fileName)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);
            List<Monkey>? monkeys = new List<Monkey>();
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                monkeys = JsonConvert.DeserializeObject<List<Monkey>>(json);
            }
            return monkeys.ToArray();
        }
    }
}
