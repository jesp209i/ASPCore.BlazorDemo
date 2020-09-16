using System;
using Xunit;
using Bunit;
using Bunit.TestDoubles.JSInterop;
using static Bunit.ComponentParameterFactory;
using BlazorDemo.Pages;

namespace BlazorDemo.Tests
{
    /// <summary>
    /// These tests are written entirely in C#.
    /// Learn more at https://bunit.egilhansen.com/docs/
    /// </summary>
    public class CalculatorTest : TestContext
    {
        [Fact]
        public void CalculatorAdds()
        {
            // Arrange
            var component = RenderComponent<Calculator>();
            component.Find("input#final-result").MarkupMatches("<input id=\"final-result\" readonly=\"\">");

            // Act
            var num1 = component.Find("input#num1");
            num1.Change("4");
            var num2 = component.Find("input#num2");
            num2.Change("4");
            component.Find("button#btn-add-numbers").Click();

            // Assert
            component.Find("input#final-result").MarkupMatches("<input id=\"final-result\" readonly=\"\" value=\"8\">");
        }

        [Fact]
        public void CalculatorSubtracts()
        {
            // Arrange
            var component = RenderComponent<Calculator>();
            component.Find("input#final-result").MarkupMatches("<input id=\"final-result\" readonly=\"\">");
            // Act
            var num1 = component.Find("input#num1");
            num1.Change("4");
            var num2 = component.Find("input#num2");
            num2.Change("4");
            component.Find("button#btn-sub-numbers").Click();

            // Assert
            component.Find("input#final-result").MarkupMatches("<input id=\"final-result\" readonly=\"\" value=\"0\">");
        }
        [Fact]
        public void CalculatorMultiply()
        {
            // Arrange
            var component = RenderComponent<Calculator>();
            component.Find("input#final-result").MarkupMatches("<input id=\"final-result\" readonly=\"\">");
            // Act
            var num1 = component.Find("input#num1");
            num1.Change("4");
            var num2 = component.Find("input#num2");
            num2.Change("4");
            component.Find("button#btn-mul-numbers").Click();

            // Assert
            component.Find("input#final-result").MarkupMatches("<input id=\"final-result\" readonly=\"\" value=\"16\">");
        }
        [Theory]
        [InlineData(4,2,2)]
        [InlineData(10,2,5)]
        [InlineData(100, 25, 4)]
        public void CalculatorDivide(int number1, int number2, int expected)
        {
            // Arrange
            var component = RenderComponent<Calculator>();
            component.Find("input#final-result").MarkupMatches("<input id=\"final-result\" readonly=\"\">");
            // Act
            var num1 = component.Find("input#num1");
            num1.Change($"{number1}");
            var num2 = component.Find("input#num2");
            num2.Change($"{number2}");
            component.Find("button#btn-div-numbers").Click();

            // Assert
            component.Find("input#final-result").MarkupMatches($"<input id=\"final-result\" readonly=\"\" value=\"{expected}\">");
        }
    }
}
