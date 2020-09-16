using System;
using Xunit;
using Bunit;
using Bunit.TestDoubles.JSInterop;
using static Bunit.ComponentParameterFactory;
using BlazorDemo.Pages;
using AngleSharp.Dom;
using System.Collections.Generic;

namespace BlazorDemo.Tests
{
    /// <summary>
    /// These tests are written entirely in C#.
    /// Learn more at https://bunit.egilhansen.com/docs/
    /// </summary>
    public class CalculatorTest : TestContext
    {
        [Theory]
        [InlineData("4","4","8")]
        [InlineData("8", "4", "12")]
        [InlineData("1", "1", "2")]
        public void CalculatorAdds_tng(string number1, string number2, string expected)
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
            input1.MarkupMatches($"<input placeholder=\"Enter First Number\" value=\"{number1}\">");
            input2.Change(number2);
            input2.MarkupMatches($"<input placeholder=\"Enter Second Number\" value=\"{number2}\">");
            var addButton = component.Find("button.btn-light");
            Assert.Equal("Add (+)", addButton.TextContent);
            addButton.Click();

            // Assert
            result.MarkupMatches($"<input readonly=\"\" value=\"{expected}\">");
        }
        [Theory]
        [InlineData("10", "4", "6")]
        [InlineData("8", "4", "4")]
        [InlineData("1", "1", "0")]
        public void CalculatorSubtracts_tng(string number1, string number2, string expected)
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
            input1.MarkupMatches($"<input placeholder=\"Enter First Number\" value=\"{number1}\">");
            input2.Change(number2);
            input2.MarkupMatches($"<input placeholder=\"Enter Second Number\" value=\"{number2}\">");
            var addButton = component.Find("button.btn-primary");
            Assert.Equal("Subtract (−)", addButton.TextContent);
            addButton.Click();

            // Assert
            result.MarkupMatches($"<input readonly=\"\" value=\"{expected}\">");
        }
        [Theory]
        [InlineData("10", "4", "40")]
        [InlineData("8", "4", "32")]
        [InlineData("1", "1", "1")]
        public void CalculatorMultiply_tng(string number1, string number2, string expected)
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
            input1.MarkupMatches($"<input placeholder=\"Enter First Number\" value=\"{number1}\">");
            input2.Change(number2);
            input2.MarkupMatches($"<input placeholder=\"Enter Second Number\" value=\"{number2}\">");
            var addButton = component.Find("button.btn-success");
            Assert.Equal("Multiply (X)", addButton.TextContent);
            addButton.Click();

            // Assert
            result.MarkupMatches($"<input readonly=\"\" value=\"{expected}\">");
        }
        [Theory]
        [InlineData("10", "2", "5")]
        [InlineData("8", "4", "2")]
        [InlineData("1", "1", "1")]
        public void CalculatorDivide_tng(string number1, string number2, string expected)
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
            input1.MarkupMatches($"<input placeholder=\"Enter First Number\" value=\"{number1}\">");
            input2.Change(number2);
            input2.MarkupMatches($"<input placeholder=\"Enter Second Number\" value=\"{number2}\">");
            var addButton = component.Find("button.btn-info");
            Assert.Equal("Divide (/)", addButton.TextContent);
            addButton.Click();

            // Assert
            result.MarkupMatches($"<input readonly=\"\" value=\"{expected}\">");
        }
    }
}
