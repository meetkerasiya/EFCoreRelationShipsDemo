using System.Text.Json.Serialization;

namespace EFCoreRelationShipsDemo
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; }

        [JsonIgnore]
        public List<Character> characters { get; set; }
    }
}
