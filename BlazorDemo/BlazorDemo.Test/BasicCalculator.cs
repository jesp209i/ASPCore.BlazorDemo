using BlazorDemo.Pages;
using BlazorDemo.Test.Attribute;
using BlazorDemo.Test.Data;
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
        /*[MemberData(nameof(BasicCalculatorData.GetButtons), 
            MemberType = typeof(BasicCalculatorData))]*/
        [CsvData(@"C:\Users\Jesper\source\repos\ASPCore.BlazorDemo\BlazorDemo\BlazorDemo.Test\Data\basicButtons.csv", true)]
        public void CanFindButtons(string buttonCssClass, string buttonText)
        {
            var component = RenderComponent<Calculator>();
            var button = component.Find($"button.{operation[buttonCssClass]}");
            Assert.Equal(buttonText, button.TextContent);
        }
        [Theory]
        /*[MemberData(nameof(BasicCalculatorData.GetAddCalculations), 
            MemberType=typeof(BasicCalculatorData)),
        MemberData(nameof(BasicCalculatorData.GetSubtractCalculations),
            MemberType = typeof(BasicCalculatorData)),
        MemberData(nameof(BasicCalculatorData.GetMultiplyCalculations),
            MemberType = typeof(BasicCalculatorData)),
        MemberData(nameof(BasicCalculatorData.GetDivideCalculations),
            MemberType = typeof(BasicCalculatorData))]*/
        [CsvData(@"C:\Users\Jesper\source\repos\ASPCore.BlazorDemo\BlazorDemo\BlazorDemo.Test\Data\basicCalculations.csv", true)]
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
