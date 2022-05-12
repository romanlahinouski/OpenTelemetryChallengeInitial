namespace Gateway.Infrastructure.Configuration
{
    public class Group
    {
        public Group(string name, string id)
        {
            this.Name = name;
            this.Id = id;

        }
        public string Name { get; set; }

        public string Id { get; set; }

    }
}