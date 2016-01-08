namespace OnlineGameDataStructure
{
    public class User
    {
        public string UserName { get; protected set; }

        public User(string userName)
        {
            UserName = userName;
        }
    }
}
