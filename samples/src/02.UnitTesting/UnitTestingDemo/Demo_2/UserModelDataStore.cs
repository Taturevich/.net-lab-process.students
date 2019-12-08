namespace Demo_2
{
    using System.Linq;
    using System.Xml.Linq;

    public class UserModelDataStore
    {
        private readonly string fileName;

        public UserModelDataStore()
        {
            this.fileName = "Users.xml";
        }

        public UserModel GetUserByUserName(string userName)
        {
            var xdoc = XDocument.Load(this.fileName);

            var xelem = xdoc.Root.Elements("User").Where(x => x.Attribute("UserName").Value == userName).FirstOrDefault();

            if (xelem == null)
            {
                return null;
            }

            return new UserModel(
                xelem.Attribute("UserName").Value,
                xelem.Element("Roles").Elements("Roles").Select(x => x.Value).ToArray());
        }

        public void SaveUser(UserModel model)
        {
            var xdoc = XDocument.Load(this.fileName);

            xdoc.Root.Add(
                new XElement(
                    "User",
                    new XAttribute("UserName", model.UserName),
                    new XElement(
                        "Roles",
                        model.GetAllRoles().Select(x => new XElement("Roles", x)))));

            xdoc.Save(this.fileName);
        }
    }
}
