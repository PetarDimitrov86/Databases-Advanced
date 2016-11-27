namespace PhotoShare.Test
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Client.Core;
    using Client.Interfaces;
    using Data.Interfaces;
    using Data.Mocks;

    [TestClass]
    public class RegisterUserTest
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
        public void TestSuccesfullyCreatedUser()
        {
            IExecutable exec = this.disptacher.DispatchCommand("RegisterUser", new string[] { "RegisterUser", "legitUsername", "Password!1", "Password!1", "validemail@gmail.com" });
            exec.Execute();
            Assert.AreEqual(1, unit.Users.GetAll().Count());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDifferentPasswordsShouldThrowError()
        {
            IExecutable exec = this.disptacher.DispatchCommand("RegisterUser", new string[] { "RegisterUser", "normalUsername", "Password!1", "Password!123", "validemail@gmail.com" });
            exec.Execute();
            Assert.AreNotEqual(1, unit.Users.GetAll().Count());
        }
    }
}