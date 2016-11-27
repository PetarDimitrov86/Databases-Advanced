namespace PhotoShare.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Client.Core;
    using Data.Interfaces;
    using Data.Mocks;
    using System.Linq;
    using Client.Interfaces;
    using Models;

    [TestClass]
    public class AddTagToTest
    {
        private CommandDispatcher disptacher;
        private IUnitOfWork unit;

        [TestInitialize]
        public void Initialize()
        {
            this.unit = new MockUnitOfWork();
            this.disptacher = new CommandDispatcher(unit);
            this.unit.Albums.Add(new Album { Name = "albumName" });
        }

        [TestMethod]
        public void SuccessfullyAddTagToExistingAlbum()
        {
            IExecutable exec = this.disptacher.DispatchCommand("AddTagTo", new string[] {"AddTagTo", "albumName", "hashtagName"});
            exec.Execute();
            Assert.AreEqual("#hashtagName", unit.Albums.FirstOrDefault().Tags.First().Name);
        }

        [TestMethod]
        public void AddingHashtagToInvalidAlbumName()
        {
            IExecutable exec = this.disptacher.DispatchCommand("AddTagTo", new string[] { "AddTagTo", "nonExistingAlbum", "firsthashtag"});
            string result = exec.Execute();
            Assert.AreEqual("No such album name exists", result);
        }

        [TestMethod]
        public void TestExecutingCommandDoesNotCreateEntityWhenAlbumNameIsWrong()
        {
            IExecutable exec = this.disptacher.DispatchCommand("AddTagTo", new string[] { "AddTagTo", "nonExistingAlbum", "firsthashtag" });
            Assert.AreEqual(0, this.unit.Tags.GetAll().Count());
        }
    }
}
