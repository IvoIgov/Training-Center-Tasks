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
        private string _helpWindowTitle = "help";

        private string _validWindowTopValue = "10";
        private string _validWindowLeftValue = "20";
        private string _validWindowWidthValue = "30";
        private string _validWindowHeightValue = "40";


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

        [Test]
        public void CtorUserJsonOutputValidData()
        {
            UserJsonOutput userJsonOutput = new UserJsonOutput();

            userJsonOutput.Name = _username;

            userJsonOutput.WindowTitleMain = _mainWindowTitle;
            userJsonOutput.MainTop = _validWindowTopValue;
            userJsonOutput.MainLeft = _validWindowLeftValue;
            userJsonOutput.MainWidth = _validWindowWidthValue;
            userJsonOutput.MainHeight = _validWindowHeightValue;

            userJsonOutput.WindowTitleHelp = _helpWindowTitle;
            userJsonOutput.HelpTop = _validWindowTopValue;
            userJsonOutput.HelpLeft = _validWindowLeftValue;
            userJsonOutput.HelpWidth = _validWindowWidthValue;
            userJsonOutput.HelpHeight = _validWindowHeightValue;

            Assert.AreEqual(_username, userJsonOutput.Name);

            Assert.AreEqual(_mainWindowTitle, userJsonOutput.WindowTitleMain);
            Assert.AreEqual(_helpWindowTitle, userJsonOutput.WindowTitleHelp);

            Assert.AreEqual(_validWindowTopValue, userJsonOutput.MainTop);
            Assert.AreEqual(_validWindowLeftValue, userJsonOutput.MainLeft);
            Assert.AreEqual(_validWindowWidthValue, userJsonOutput.MainWidth);
            Assert.AreEqual(_validWindowHeightValue, userJsonOutput.MainHeight);

            Assert.AreEqual(_validWindowTopValue, userJsonOutput.HelpTop);
            Assert.AreEqual(_validWindowLeftValue, userJsonOutput.HelpLeft);
            Assert.AreEqual(_validWindowWidthValue, userJsonOutput.HelpWidth);
            Assert.AreEqual(_validWindowHeightValue, userJsonOutput.HelpHeight);
        }

        [Test]
        public void CtorUserJSONOutputEmptyUsername()
        {
            UserJsonOutput userJsonOutput = new UserJsonOutput();
            Assert.Throws<Exception>(() => userJsonOutput.Name = "");
        }

        [Test]
        public void CtorUserJSONOutputEmptyWindowTitleMain()
        {
            UserJsonOutput userJsonOutput = new UserJsonOutput();
            Assert.Throws<Exception>(() => userJsonOutput.WindowTitleMain = "");
        }

        [Test]
        public void CtorUserJSONOutputEmptyWindowTitleHelp()
        {
            UserJsonOutput userJsonOutput = new UserJsonOutput();
            Assert.Throws<Exception>(() => userJsonOutput.WindowTitleHelp = "");
        }

        [Test]
        public void CtorUserJSONOutputDefaultMainTopValue()
        {
            UserJsonOutput userJsonOutput = new UserJsonOutput();
            userJsonOutput.MainTop = JSONDataClass.TopDefaultValue;
            Assert.AreEqual("0", userJsonOutput.MainTop);
        }
    }
}