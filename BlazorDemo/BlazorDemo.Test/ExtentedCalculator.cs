using BlazorDemo.Pages;
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
        [InlineData("cuberoot", "CubeRoot (^(1/3))")]
        [InlineData("xroot", "x-root (^(1/x))")]
        [InlineData("power", "Power (^)")]
        
        public void CanFindButtons(string buttonCssId, string buttonText)
        {
            var component = RenderComponent<Calculator>();
            var button = component.Find($"button#{operations[buttonCssId]}");
            Assert.Equal(buttonText, button.TextContent);
        }
        [Theory]
        [InlineData("xroot", "4", "2", "2")]
        [InlineData("xroot", "64", "3", "4")]
        [InlineData("power", "10", "3", "1000")]
        [InlineData("power", "8", "2", "64")]
        [InlineData("power", "1", "1", "1")]
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
        [InlineData("cuberoot", "64", "4")]
        [InlineData("cuberoot", "8", "2")]
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
