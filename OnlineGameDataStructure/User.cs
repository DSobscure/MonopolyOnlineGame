namespace OnlineGameDataStructure
{
    public class User
    {
        public string UserName { get; protected set; }
        public UserGroup UserGroup { get; set; }

        public User(string userName)
        {
            UserName = userName;
        }
    }
}
