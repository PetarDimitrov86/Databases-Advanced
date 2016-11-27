namespace PhotoShare.Test
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Client.Core;
    using Client.Interfaces;
    using Data.Interfaces;
    using Data.Mocks;

    [TestClass]
    public class AddTagTest
    {
        private CommandDispatcher disptacher;
        private IUnitOfWork unit;

        [TestInitialize]
        public void Initialize()
        {
            this.unit = new MockUnitOfWork();
            this.disptacher = new CommandDispatcher(unit);
        }

        [TestMethod]
        public void TestCountChanged()
        {
            IExecutable exec = this.disptacher.DispatchCommand("AddTag", new string[] {"AddTag", "tagzzzz"});
            exec.Execute();
            Assert.AreNotSame(0, this.unit.Tags.GetAll().Count());          
        }

        [TestMethod]
        public void TestTagMissingHashtag()
        {
            IExecutable exec = this.disptacher.DispatchCommand("AddTag", new string[] {"AddTag", "wrongTag"});
            exec.Execute();
            Assert.AreEqual("#wrongTag", unit.Tags.FirstOrDefault().Name);
        }

        [TestMethod]
        public void TestTagWithLotsOfWhiteSpaces()
        {
            IExecutable exec = this.disptacher.DispatchCommand("AddTag", new string[] { "AddTag", "s p a c e s" });
            exec.Execute();
            Assert.AreEqual("#spaces", unit.Tags.FirstOrDefault().Name);
        }

        [TestMethod]
        public void TestHashtagTooLong()
        {
            IExecutable exec = this.disptacher.DispatchCommand("AddTag", new string[] { "AddTag", "I'm way over 20 symbols long. Cut me out, please!" });
            exec.Execute();
            Assert.AreEqual("#I'mwayover20symbols", unit.Tags.FirstOrDefault().Name);
        }
    }
}