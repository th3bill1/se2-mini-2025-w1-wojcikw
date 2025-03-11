namespace SE2;

[TestClass]
public class LongConverstionTest
{
    [TestMethod]
    public void EmptyStringTest()
    {
        //Given
        string s1 = "";
        int expected_result = 0;
        //When
        long result = LongConversion.calc(s1);
        //Then
        Assert.AreEqual(expected_result, result);
    }
    [TestMethod]
    public void OneNumberTest()
    {
        //Given
        Random random = new Random();
        long expected_result = random.NextInt64();
        //When
        long result = LongConversion.calc(expected_result.ToString());
        //Then
        Assert.AreEqual(expected_result, result);
    }
    [TestMethod]
    public void TwoNumberCommaTest()
    {
        //Given
        Random random = new Random();
        long n1 = random.NextInt64(1000), n2 = random.NextInt64(1000);
        string input = n1.ToString() + "," + n2.ToString();
        long expected_result = n1 + n2;
        //When
        long result = LongConversion.calc(input);
        //Then
        Assert.AreEqual(expected_result, result);
    }
    [TestMethod]
    public void TwoNumberNewLineTest()
    {
        //Given
        Random random = new Random();
        long n1 = random.NextInt64(1000), n2 = random.NextInt64(1000);
        string input = n1.ToString() + "\n" + n2.ToString();
        long expected_result = n1 + n2;
        //When
        long result = LongConversion.calc(input);
        //Then
        Assert.AreEqual(expected_result, result);
    }
    [TestMethod]
    public void ThreeNumberTest()
    {
        //Given
        Random random = new Random();
        long n1 = random.NextInt64(1000), n2 = random.NextInt64(1000), n3 = random.NextInt64(1000);
        string input1 = n1.ToString() + "\n" + n2.ToString() + "," + n3.ToString();
        string input2 = n1.ToString() + "," + n2.ToString() + "\n" + n3.ToString();
        string input3 = n1.ToString() + "\n" + n2.ToString() + "\n" + n3.ToString();
        string input4 = n1.ToString() + "," + n2.ToString() + "," + n3.ToString();
        long expected_result = n1 + n2 + n3;
        //When
        long result1 = LongConversion.calc(input1);
        long result2 = LongConversion.calc(input2);
        long result3 = LongConversion.calc(input3);
        long result4 = LongConversion.calc(input4);
        //Then
        Assert.AreEqual(expected_result, result1);
        Assert.AreEqual(expected_result, result2);
        Assert.AreEqual(expected_result, result3);
        Assert.AreEqual(expected_result, result4);
    }
    [TestMethod]
    public void NegativeNumbersTest() 
    {
        // Given
        Random random = new Random();
        long n = -random.NextInt64(1000);
        Console.WriteLine(n);
        // When
        Action a = () => LongConversion.calc(n.ToString());
        // Then
        Assert.ThrowsException<FormatException>(a);
    }
    [TestMethod]
    public void BigNumbersTest()
    {
        //Given
        long n1 = 2, n2 = 3, n3 = 1000;
        long n4 = 2, n5 = 3, n6 = 1002;
        string input1 = n1.ToString() + "\n" + n2.ToString() + "," + n3.ToString();
        string input2 = n4.ToString() + "," + n5.ToString() + "\n" + n6.ToString();
        long expected_result1 = n1 + n2 + n3;
        long expected_result2 = n4 + n5;
        //When
        long result1 = LongConversion.calc(input1);
        long result2 = LongConversion.calc(input2);
        //Then
        Assert.AreEqual(expected_result1, result1);
        Assert.AreEqual(expected_result2, result2);
    }
    [TestMethod]
    public void CharDelimiter()
    {
        //Given
        string input1 = "#5#10,20";
        long expected_result1 = 35;
        //When
        long result = LongConversion.calc(input1);
        //Then
        Assert.AreEqual(expected_result1, result);
    }
    /*[TestMethod]
    public void MultiCharDelimiterDefinedAtStartTest()
    {
        // Given
        string input1 = "[**][###]1**2###3";
        string input2 = "[!!][??][...]4!!5??6...7";
        long expected_result1 = 1 + 2 + 3;
        long expected_result2 = 4 + 5 + 6 + 7;
        // When
        long result1 = LongConversion.calc(input1);
        long result2 = LongConversion.calc(input2);
        // Then
        Assert.AreEqual(expected_result1, result1);
        Assert.AreEqual(expected_result2, result2);
    }*/

}