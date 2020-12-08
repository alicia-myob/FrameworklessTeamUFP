namespace FrameworklessApp
{
    public class User
    {
        private string _name;
        private string _id;
        public User(string name, string id)
        {
            _name = name;
            _id = id;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Id
        {
            get => _id;
            set => _id = value;
        }
    }
}