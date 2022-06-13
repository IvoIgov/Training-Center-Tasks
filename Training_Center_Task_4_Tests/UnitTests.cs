using NUnit.Framework;
using System;
using Training_Center_Task_4;

namespace Training_Center_Task_4_Tests
{
    public class UnitTests
    {
        private User _user;
        private string _username = "Ivo";
        private string _mainWindowTitle = "main";
        private string _validWindowTopValue = "20";
        private string _validWindowLeftValue = "20";
        private string _validWindowWidthValue = "20";
        private string _validWindowHeightValue = "20";


        [SetUp]
        public void Setup()
        {
            _user = new User(_username);
        }

        [Test]
        public void CtorUserValidName()
        {
            Assert.AreEqual(_username, _user.Name);
        }

        [Test]
        public void CtorUserEmptyName()
        {
            Assert.Throws<Exception>(() => new User(""));
        }

        [Test]
        public void CtorWindowAllValidData()
        {
            Window window = new Window(_mainWindowTitle, _validWindowTopValue, _validWindowLeftValue, _validWindowWidthValue, _validWindowHeightValue);
            _user.Windows.Add(window);
            Assert.AreEqual(1, _user.Windows.Count);
        }

        [Test]
        public void CtorWindowEmptyTitle()
        {
            Assert.Throws<Exception>(() => new Window("", _validWindowTopValue, _validWindowLeftValue, _validWindowWidthValue, _validWindowHeightValue));
        }

        [Test]
        public void CtorWindowTopValueEmpty()
        {
            Window window = new Window(_mainWindowTitle, "", _validWindowLeftValue, _validWindowWidthValue, _validWindowHeightValue);
            _user.Windows.Add(window);
            Assert.AreEqual("?", _user.Windows[0].Top);
        }

        [Test]
        public void CtorWindowTopValueNegative()
        {
            Assert.Throws<Exception>(() => new Window(_mainWindowTitle, "-10", _validWindowLeftValue, _validWindowWidthValue, _validWindowHeightValue));
        }

        [Test]
        public void CtorWindowLeftValueEmpty()
        {
            Window window = new Window(_mainWindowTitle, _validWindowTopValue, "", _validWindowWidthValue, _validWindowHeightValue);
            _user.Windows.Add(window);
            Assert.AreEqual("?", _user.Windows[0].Left);
        }

        [Test]
        public void CtorWindowLeftValueNegative()
        {
            Assert.Throws<Exception>(() => new Window(_mainWindowTitle, _validWindowTopValue, "-20", _validWindowWidthValue, _validWindowHeightValue));
        }

        [Test]
        public void CtorWindowWidthValueEmpty()
        {
            Window window = new Window(_mainWindowTitle, _validWindowTopValue, _validWindowLeftValue, "", _validWindowHeightValue);
            _user.Windows.Add(window);
            Assert.AreEqual("?", _user.Windows[0].Width);
        }

        [Test]
        public void CtorWindowWidthValueNegative()
        {
            Assert.Throws<Exception>(() => new Window(_mainWindowTitle, _validWindowTopValue, _validWindowLeftValue, "-20", _validWindowHeightValue));
        }

        [Test]
        public void CtorWindowHeightValueEmpty()
        {
            Window window = new Window(_mainWindowTitle, _validWindowTopValue, _validWindowLeftValue, _validWindowWidthValue, "");
            _user.Windows.Add(window);
            Assert.AreEqual("?", _user.Windows[0].Height);
        }

        [Test]
        public void CtorWindowHeightValueNegative()
        {
            Assert.Throws<Exception>(() => new Window(_mainWindowTitle, _validWindowTopValue, _validWindowLeftValue, _validWindowWidthValue, "-20"));
        }
    }
}