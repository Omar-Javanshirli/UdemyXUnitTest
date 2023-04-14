using Moq;
using UdemyUnitTest.APP;
using Xunit;

namespace UdemyUnitTest.Test
{
    public class CalculatorTest
    {


        //[Fact] //her test edeceyimiz method ucun mutleq bu atribut yazilmalidir. hemcinin methodumuz parametre qebul etmemlidir
        //public void AddTest()
        //{
        //    //Arange
        //    int x = 5;
        //    int y = 20;

        //    //Act
        //    var total = calculator.add(x, y);

        //    //Assert
        //    Assert.Equal<int>(25, total);


        //    //Conatins DoseNotContains

        //    //Assert.Contains("Fatih", "Fatih Cakiroglu"); //true
        //    //Assert.DoesNotContain("Fatih", "Fatih cakitogru");//false

        //    //var names = new List<string>() { "Omer", "Amin", "Leyla" };
        //    //Assert.Contains(names, x => x == "Fatih");

        //    ////True False

        //    //Assert.True(5 > 2);
        //    //Assert.True(5 < 2);

        //    ////Matches DoesNotMatch
        //    //var regEx = "^dog";
        //    //Assert.Matches(regEx, "dog fatih");//true
        //    //Assert.Matches(regEx, "fatih dog");//false

        //    ////Single

        //    //Assert.Single(new List<string>() { "Omer" });

        //    ////IsAssignableFrom
        //    //Assert.IsAssignableFrom<IEnumerable<string>>(new List<string>());//true
        //    //Assert.IsAssignableFrom<Object>("Omer");//true
        //    //Assert.IsAssignableFrom<Object>(5);//true

        //}


        public Calculator calculator { get; set; }
        public Mock<ICalculatorService> myMock { get; set; }

        public CalculatorTest()
        {
            myMock = new Mock<ICalculatorService>();
            this.calculator = new Calculator(myMock.Object);
        }

        [Theory]
        [InlineData(2, 5, 7)]
        [InlineData(10, 5, 15)]
        public void Add_simpleValues_ReturnTotalValues(int x, int y, int expectedTotal)
        {
            myMock.Setup(a => a.add(x, y)).Returns(expectedTotal);

            var actualTotal = calculator.add(x, y);
            Assert.Equal<int>(expectedTotal, actualTotal);
            myMock.Verify(a => a.add(x, y), Times.Once);
        }

        [Theory]
        [InlineData(0, 5, 0)]
        [InlineData(10, 0, 0)]
        public void Add_zoreValues_ReturnZeroValues(int x, int y, int expectedTotal)
        {
            var actualTotal = calculator.add(x, y);
            Assert.Equal<int>(expectedTotal, actualTotal);
        }

        [Theory]
        [InlineData(3, 5, 15)]
        public void Multip_SimpleValues_ReturnMultipValue(int x, int y, int expectedTotal)
        {
            myMock.Setup(a => a.multip(x, y)).Returns(expectedTotal);
            Assert.Equal<int>(15, calculator.multip(x, y));
        }

        [Theory]
        [InlineData(0, 5)]
        public void Multip_ZeroValues_ReturnMultipValue(int x, int y)
        {
            myMock.Setup(a => a.multip(x, y)).Throws(new Exception("a==0 olamaz"));
            var exception = Assert.Throws<Exception>(() => calculator.multip(x, y));
            Assert.Equal("a==0 olamaz", exception.Message);
        }
    }
}
