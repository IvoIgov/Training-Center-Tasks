using NUnit.Framework;
using System;
using Training_Center_Task_4;

namespace Training_Center_Task_4_Tests
{
    public class UnitTests
    {
        private User _user;
        [SetUp]
        public void Setup()
        {
            _user = new User("Ivo");
        }

        [Test]
        public void CtorWindowAllValidData()
        {
            Window window = new Window("main", "20", "20", "20", "20");
            _user.Windows.Add(window);
            Assert.AreEqual(1, _user.Windows.Count);
        }

        [Test]
        public void CtorWindowEmptyTitle()
        {
            Assert.Throws<Exception>(() => new Window("", "20", "20", "20", "20"));
        }

        [Test]
        public void CtorWindowTopValueEmpty()
        {
            Window window = new Window("main", "", "20", "20", "20");
            _user.Windows.Add(window);
            Assert.AreEqual("?", _user.Windows[0].Top);
        }

        [Test]
        public void CtorWindowTopValueNegative()
        {
            Assert.Throws<Exception>(() => new Window("main", "-10", "20", "20", "20"));
        }

        [Test]
        public void CtorWindowLeftValueEmpty()
        {
            Window window = new Window("main", "10", "", "20", "20");
            _user.Windows.Add(window);
            Assert.AreEqual("?", _user.Windows[0].Left);
        }

        [Test]
        public void CtorWindowLeftValueNegative()
        {
            Assert.Throws<Exception>(() => new Window("main", "10", "-20", "20", "20"));
        }

        [Test]
        public void CtorWindowWidthValueEmpty()
        {
            Window window = new Window("main", "10", "20", "", "20");
            _user.Windows.Add(window);
            Assert.AreEqual("?", _user.Windows[0].Width);
        }

        [Test]
        public void CtorWindowWidthValueNegative()
        {
            Assert.Throws<Exception>(() => new Window("main", "10", "20", "-20", "20"));
        }

        [Test]
        public void CtorWindowHeightValueEmpty()
        {
            Window window = new Window("main", "10", "20", "20", "");
            _user.Windows.Add(window);
            Assert.AreEqual("?", _user.Windows[0].Height);
        }

        [Test]
        public void CtorWindowHeightValueNegative()
        {
            Assert.Throws<Exception>(() => new Window("main", "10", "20", "20", "-20"));
        }
    }
}