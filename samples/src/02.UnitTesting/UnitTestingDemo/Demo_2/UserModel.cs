namespace Demo_2
{
    using System.Collections.Generic;

    public class UserModel
    {
        private List<string> roles;

        public UserModel(string userName, IEnumerable<string> roles)
        {
            this.UserName = userName;
            this.roles = new List<string>(roles);
        }

        public string UserName { get; set; }

        public bool IsInRole(string role)
        {
            return this.roles.Exists(x => x == role);
        }

        public string[] GetAllRoles()
        {
            return this.roles.ToArray();
        }

        public static UserModel Get(string userName)
        {
            return new UserModelDataStore().GetUserByUserName(userName);
        }

        public void Save()
        {
            new UserModelDataStore().SaveUser(this);
        }
    }
}
