using System.Collections.Generic;
using NUnit.Framework;
using MindstormsSharp.Core.Helpers;

namespace MindstormsSharp.Core.Tests.Helpers
{
    [TestFixture]
    public class GuardTests
    {
        #region Guard.AgainstNull Tests

        [Test]
        public void GivenANullObject_WhenGuardingAgainstNull_ThenExceptionIsThrown()
        {
            var testObject = new TestObject();

            Assert.That(() => Guard.AgainstNull<TestObject>(null!, nameof(testObject)),
                Throws.ArgumentNullException.With.Property("ParamName").EqualTo("testObject"));
        }

        [Test]
        public void GivenAnObject_WhenGuardingAgainstNull_ThenNoExceptionThrown()
        {
            var testObject = new TestObject();

            Assert.That(() => Guard.AgainstNull(testObject, nameof(testObject)), Throws.Nothing);
        }

        #endregion

        #region Guard.AgainstNullAndEmpty (String) Tests

        [TestCaseSource(nameof(NullStringCases))]
        public void GivenAnInvalidStringValue_WhenGuardingAgainstNullAndEmpty_ThenExceptionIsThrown(string value, string paramName)
        {
            Assert.That(() => Guard.AgainstNullAndEmpty(value, paramName), 
                Throws.ArgumentNullException.With.Property("ParamName").EqualTo(paramName));
        }

        private static IEnumerable<TestCaseData> NullStringCases()
        {
            yield return new TestCaseData(null, "nullValue").SetName("Null string value test");
            yield return new TestCaseData("", "emptyValue").SetName("Empty string value test");
            yield return new TestCaseData("     ", "whitespaceValue").SetName("Whitespace string value test");
        }

        [Test]
        public void GivenAValidStringValue_WhenGuardingAgainstNullAndEmpty_ThenNoExceptionIsThrown()
        {
            Assert.That(() => Guard.AgainstNullAndEmpty("some string value", "some param name"), Throws.Nothing);
        }

        #endregion

        #region Test Helpers

        private class TestObject
        {
            public bool BooleanProperty => false;
            public string StringProperty => "some string value";
        }

        #endregion
    }
}