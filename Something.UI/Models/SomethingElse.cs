using System.Collections.Generic;

namespace Something.Domain.Models
{
    public class SomethingElse
    {
        public string Name { get; set; }
        public List<Something> Somethings { get; set; } = new List<Something>();
        public int Id { get; set; }
        public string Tag { get; set; }
    }
}
