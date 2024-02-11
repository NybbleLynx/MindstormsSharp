using System;
using System.Collections.Generic;
using MindstormsSharp.Core.Extensions;
using NUnit.Framework;

namespace MindstormsSharp.Core.Tests.Extensions
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [TestCaseSource(nameof(AnyOfStringTests))]
        public void GivenAString_WhenCheckingIfIsAnyOfASetOfStringValues_ThenReturnCorrectValue(string value, List<string> comparisonValues, bool expectedResult)
        {
            Assert.That(value.AnyOf(comparisonValues), Is.EqualTo(expectedResult));
        }

        private static IEnumerable<TestCaseData> AnyOfStringTests()
        {
            var listOfValues = new List<string> {"value1", "value2", "someValue2", "someValue5", "value6"};

            yield return new TestCaseData("value1", listOfValues, true);
            yield return new TestCaseData("someValue1", listOfValues, false);
            yield return new TestCaseData("value2", listOfValues, true);
            yield return new TestCaseData("value1000", listOfValues, false);
        }

        [TestCaseSource(nameof(CaseSensitivityTests))]
        public void GivenAString_WhenCheckingIfIsAnyOfASetOfStringValues_WithCaseSensitivity_ThenReturnCorrectValue(string value, List<string> comparisonValues, StringComparison comparisonType, bool expectedResult)
        {
            Assert.That(value.AnyOf(comparisonValues, comparisonType), Is.EqualTo(expectedResult));
        }

        private static IEnumerable<TestCaseData> CaseSensitivityTests()
        {
            var listOfValues = new List<string> {"value1", "value2"};

            yield return new TestCaseData("value1", listOfValues, StringComparison.CurrentCulture, true);
            yield return new TestCaseData("value2", listOfValues, StringComparison.InvariantCulture, true);
            yield return new TestCaseData("value1", listOfValues, StringComparison.Ordinal, true);
            yield return new TestCaseData("VaLuE2", listOfValues, StringComparison.CurrentCulture, false);
            yield return new TestCaseData("Value1", listOfValues, StringComparison.InvariantCulture, false);
            yield return new TestCaseData("VALUE2", listOfValues, StringComparison.Ordinal, false);
        }

        [TestCaseSource(nameof(CaseInsensitivityTests))]
        public void GivenAString_WhenCheckingIfIsAnyOfASetOfStringValues_WithCaseInsensitivity_ThenReturnCorrectValue(string value, List<string> comparisonValues, StringComparison comparisonType, bool expectedResult)
        {
            Assert.That(value.AnyOf(comparisonValues, comparisonType), Is.EqualTo(expectedResult));
        }

        private static IEnumerable<TestCaseData> CaseInsensitivityTests()
        {
            var listOfValues = new List<string> {"value1", "value2"};
            
            yield return new TestCaseData("value1", listOfValues, StringComparison.CurrentCultureIgnoreCase, true);
            yield return new TestCaseData("value2", listOfValues, StringComparison.InvariantCultureIgnoreCase, true);
            yield return new TestCaseData("value1", listOfValues, StringComparison.OrdinalIgnoreCase, true);
            yield return new TestCaseData("VaLuE2", listOfValues, StringComparison.CurrentCultureIgnoreCase, true);
            yield return new TestCaseData("Value1", listOfValues, StringComparison.InvariantCultureIgnoreCase, true);
            yield return new TestCaseData("VALUE2", listOfValues, StringComparison.OrdinalIgnoreCase, true);
        }
    }
}