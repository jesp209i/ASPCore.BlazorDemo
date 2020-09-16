using BlazorDemo.Pages;
using Bunit;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BlazorDemo.Tests
{
    public class ExtendedCalculator : TestContext
    {
        [Theory]
        [InlineData("64", "4")]
        [InlineData("8", "2")]
        public void CalculatorCubeRoot_tng(string number1, string expected)
        {
            // Arrange
            var component = RenderComponent<Calculator>();
            var input1 = component.Find("input[placeholder=\"Enter First Number\"]");
            var input2 = component.Find("input[placeholder=\"Enter Second Number\"]");
            var result = component.Find("input[readonly]");
            // result is empty
            result.MarkupMatches("<input readonly=\"\">");
            // Act

            input1.Change(number1);
            var addButton = component.Find("button#btn-cuberoot");
            Assert.Equal("CubeRoot (^(1/3))", addButton.TextContent);
            addButton.Click();

            // Assert
            result.MarkupMatches($"<input readonly=\"\" value=\"{expected}\">");
        }
        [Theory]
        [InlineData("4", "2", "2")]
        [InlineData("64", "3", "4")]
        public void CalculatorXRoot_tng(string number1, string number2, string expected)
        {
            // Arrange
            var component = RenderComponent<Calculator>();
            var input1 = component.Find("input[placeholder=\"Enter First Number\"]");
            var input2 = component.Find("input[placeholder=\"Enter Second Number\"]");
            var result = component.Find("input[readonly]");
            // result is empty
            result.MarkupMatches("<input readonly=\"\">");
            // Act

            input1.Change(number1);
            input2.Change(number2);
            var button = component.Find("button#btn-xroot");
            Assert.Equal("x-root (^(1/x))", button.TextContent);
            button.Click();

            // Assert
            result.MarkupMatches($"<input readonly=\"\" value=\"{expected}\">");
        }
        [Theory]
        [InlineData("10", "3", "1000")]
        [InlineData("8", "2", "64")]
        [InlineData("1", "1", "1")]
        public void CalculatorPower_tng(string number1, string number2, string expected)
        {
            // Arrange
            var component = RenderComponent<Calculator>();
            var input1 = component.Find("input[placeholder=\"Enter First Number\"]");
            var input2 = component.Find("input[placeholder=\"Enter Second Number\"]");
            var result = component.Find("input[readonly]");
            // result is empty
            result.MarkupMatches("<input readonly=\"\">");
            // Act

            input1.Change(number1);
            input2.Change(number2);
            var button = component.Find("button#btn-power");
            Assert.Equal("Power (^)", button.TextContent);
            button.Click();

            // Assert
            result.MarkupMatches($"<input readonly=\"\" value=\"{expected}\">");
        }
    }
}
