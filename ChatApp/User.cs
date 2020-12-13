namespace ChatApp
{
    public class User
    {
        private string _name;
        private string _password;

        public User(string name, string password)
        {
            _name = name;
            _password = password;
        }

        public string Name => _name;

        public bool Authenticate(string uName, string uPass)
        {
            return uName.Equals(_name) && uPass.Equals(_password);
        }

        public bool checkName(string uName)
        {
            return uName.Equals(_name);
        }
    }
}