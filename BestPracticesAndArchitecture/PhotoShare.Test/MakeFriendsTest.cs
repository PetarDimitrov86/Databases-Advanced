namespace PhotoShare.Test
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Client.Core;
    using Client.Interfaces;
    using Data.Interfaces;
    using Data.Mocks;
    using Models;

    [TestClass]
    public class MakeFriendsTest
    {
        private CommandDispatcher disptacher;
        private IUnitOfWork unit;

        [TestInitialize]
        public void Initialize()
        {
            this.unit = new MockUnitOfWork();
            this.disptacher = new CommandDispatcher(unit);
            this.unit.Users.Add(new User() { Username = "firstUsername", Password = "SeemsL3git!#", Email = "randomemail@gmail.com"});
            this.unit.Users.Add(new User() { Username = "secondUsername", Password = "SecondL3git!#", Email = "justanother@gmail.com" });
        }

        [TestMethod]
        public void TestIfBothUsersArePresent()
        {
            Assert.AreEqual(2, this.unit.Users.GetAll().Count());
        }

        [TestMethod]
        public void TestIfBothUsersHaveEachOtherAsFriends()
        {
            IExecutable exec = this.disptacher.DispatchCommand("MakeFriends", new string[] { "MakeFriends", "firstUsername", "secondUsername" });
            exec.Execute();
            Assert.IsTrue(this.unit.Users.FirstOrDefaultWhere(u => u.Username == "firstUsername").Friends.Any(u => u.Username == "secondUsername"));
            Assert.IsTrue(this.unit.Users.FirstOrDefaultWhere(u => u.Username == "secondUsername").Friends.Any(u => u.Username == "firstUsername"));
        }

        [TestMethod]
        public void TestIfWritingInvalidUsernameThrowsError()
        {
            IExecutable exec = this.disptacher.DispatchCommand("MakeFriends", new string[] { "MakeFriends", "missingUsername", "secondUsername" });
            string result = exec.Execute();
            Assert.AreEqual("One of the usernames is missing from the database", result);
        }
    }
}