namespace FrameworklessApp
{
    public class User
    {
        private string _name;
        private int _id;
        public User(string name, int id)
        {
            _name = name;
            _id = id;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }
    }
}