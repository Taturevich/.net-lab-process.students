namespace Demo_3.Tests
{
    using System;
    using System.Collections.Generic;

    using Demo_3;

    using NUnit.Framework;

    [TestFixture]
    public class UserTests
    {
        [Test]
        public void GetByName_UserName_GetNewUserRoles()
        {

            // Arrange
            var repo = new FakeRepository();
            repo.Save(new User("Iron man", new List<string> { "Admin", "User", "Moderator" }));
            repo.Save(new User("James bond", new List<string> { "Agent", "User" }));

            // Act
            var user = repo.GetByName("Iron man");

            // Assert
            Assert.AreEqual(3, user.GetAllRoles().Length);
        }

        [Test]
        public void Save_AddExistingUser_GetException()
        {
            // Arrange
            var repo = new FakeRepository();
            repo.Save(new User("Iron man", new List<string> { "Admin", "User", "Moderator" }));
            repo.Save(new User("James bond", new List<string> { "Agent", "User" }));

            // Act - delegate. Assert
            Assert.Throws<InvalidOperationException>(
                () => repo.Save(new User("Iron man", new List<string> { "Admin", "User", "Moderator" })));
        }

        [Test]
        public void Save_AddNewUser_GetSavedUser()
        {
            // Arrange
            var repo = new FakeRepository();
            repo.Save(new User("Iron man", new List<string> { "Admin", "User", "Moderator" }));
            repo.Save(new User("James bond", new List<string> { "Agent", "User" }));

            // Act
            repo.Save(new User("John Doe", new List<string> { "Admin", "User", "Moderator" }));

            // Assert
            var user = repo.GetByName("John Doe");
            Assert.NotNull(user);
        }
    }
}
