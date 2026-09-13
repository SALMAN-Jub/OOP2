using Hotel_Management_System.Models;

namespace Hotel_Management_System.Utilities
{
    public static class SessionManager
    {
        public static User CurrentUser { get; private set; }

        public static void SetCurrentUser(User user)
        {
            CurrentUser = user;
        }

        public static void Clear()
        {
            CurrentUser = null;
        }
    }
}
