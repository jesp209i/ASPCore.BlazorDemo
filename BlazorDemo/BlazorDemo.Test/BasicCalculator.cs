using BlazorDemo.Pages;
using Bunit;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BlazorDemo.Test
{
    public class BasicCalculator : TestContext
    {

        Dictionary<string, string> operation;
        public BasicCalculator()
        {
            operation = new Dictionary<string, string>();
            operation.Add("add", "btn-light");
            operation.Add("subtract", "btn-primary");
            operation.Add("multiply", "btn-success");
            operation.Add("divide", "btn-info");
        }
        [Fact]
        public void ChangeValueInInputFieldWorks()
        {
            // arrange
            var component = RenderComponent<Calculator>();
            var input1 = component.Find(@"input[placeholder=""Enter First Number""]");
            var input2 = component.Find(@"input[placeholder=""Enter Second Number""]");
            // act
            input1.MarkupMatches(@"<input placeholder=""Enter First Number"">");
            input2.MarkupMatches(@"<input placeholder=""Enter Second Number"">");
            
            input1.Change("hello");
            input2.Change("from the other side");
            // assert
            input1.MarkupMatches(@"<input value=""hello"" placeholder=""Enter First Number"">");
            input2.MarkupMatches(@"<input value=""from the other side"" placeholder=""Enter Second Number"">");
        }
        [Fact]
        public void ResultInputFieldIsEmpty()
        {
            // Arrange
            var component = RenderComponent<Calculator>();
            var result = component.Find(@"input[readonly]");
            // Assert
            result.MarkupMatches(@"<input readonly="""">");
        }

        [Theory]
        [InlineData("add", "Add (+)")]
        [InlineData("subtract", "Subtract (−)")]
        [InlineData("multiply", "Multiply (X)")]
        [InlineData("divide","Divide (/)")]
        public void CanFindButtons(string buttonCssClass, string buttonText)
        {
            var component = RenderComponent<Calculator>();
            var button = component.Find($"button.{operation[buttonCssClass]}");
            Assert.Equal(buttonText, button.TextContent);
        }
        [Theory]
        [InlineData("add", "4", "4", "8")]
        [InlineData("add", "8", "4", "12")]
        [InlineData("add", "1", "1", "2")]
        [InlineData("subtract", "10", "4", "6")]
        [InlineData("subtract", "8", "4", "4")]
        [InlineData("subtract", "1", "1", "0")]
        [InlineData("multiply", "10", "4", "40")]
        [InlineData("multiply", "8", "4", "32")]
        [InlineData("multiply", "1", "1", "1")]
        [InlineData("divide", "10", "2", "5")]
        [InlineData("divide", "8", "4", "2")]
        [InlineData("divide", "1", "1", "1")]

        public void CalculatorOperation(string buttonToClick, string number1, string number2, string expected)
        {
            // Arrange
            var component = RenderComponent<Calculator>();
            var input1 = component.Find(@"input[placeholder=""Enter First Number""]");
            var input2 = component.Find(@"input[placeholder=""Enter Second Number""]");
            var result = component.Find(@"input[readonly]");
            // Act

            input1.Change(number1);
            input2.Change(number2);

            var button = component.Find($"button.{operation[buttonToClick]}");
            button.Click();

            // Assert
            result.MarkupMatches($"<input readonly=\"\" value=\"{expected}\">");
        }
    }
}
