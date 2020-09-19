using BlazorDemo.Pages;
using BlazorDemo.Test.Data;
using Bunit;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BlazorDemo.Test
{
    public class ExtentedCalculator : TestContext
    {
        Dictionary<string, string> operations;
        public ExtentedCalculator()
        {
            operations = new Dictionary<string, string>();
            operations.Add("cuberoot", "btn-cuberoot");
            operations.Add("xroot", "btn-xroot");
            operations.Add("power", "btn-power");
        }
        [Theory]
        [MemberData(nameof(ExtentedCalculatorData.GetButtons),
            MemberType =typeof(ExtentedCalculatorData))]
        public void CanFindButtons(string buttonCssId, string buttonText)
        {
            var component = RenderComponent<Calculator>();
            var button = component.Find($"button#{operations[buttonCssId]}");
            Assert.Equal(buttonText, button.TextContent);
        }
        [Theory]
        [ClassData(typeof(ExtentedCalculatorXRoot))]
        [MemberData(nameof(ExtentedCalculatorData.GetPowerCalculations),
            MemberType = typeof(ExtentedCalculatorData))]
        public void ExtentedCalculatorTest(string operation, string number1, string number2, string expected)
        {
            // Arrange
            var component = RenderComponent<Calculator>();
            var input1 = component.Find("input[placeholder=\"Enter First Number\"]");
            var input2 = component.Find("input[placeholder=\"Enter Second Number\"]");
            var result = component.Find("input[readonly]");
            // Act
            input1.Change(number1);
            input2.Change(number2);

            var button = component.Find($"button#{operations[operation]}");
            button.Click();

            // Assert
            result.MarkupMatches($"<input readonly=\"\" value=\"{expected}\">");
        }
        [Theory]
        [MemberData(nameof(ExtentedCalculatorData.GetCubeRootCalculations),
            MemberType = typeof(ExtentedCalculatorData))]
        public void ExtentedCalculator_CubeRoot_Test(string operation, string number1, string expected)
        {
            // Arrange
            var component = RenderComponent<Calculator>();
            var input1 = component.Find("input[placeholder=\"Enter First Number\"]");
            var input2 = component.Find("input[placeholder=\"Enter Second Number\"]");
            var result = component.Find("input[readonly]");
            // Act
            input1.Change(number1);

            var button = component.Find($"button#{operations[operation]}");
            button.Click();

            // Assert
            result.MarkupMatches($"<input readonly=\"\" value=\"{expected}\">");
        }
    }
}
