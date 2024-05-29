using FluentAssertions;
using Interview.Samples.Application.Strings;

namespace Interview.Samples.Tests
{
    [TestClass]
    public class StringTests
    {
        [DataTestMethod]
        [DataRow("3[a]2[bc]", "aaabcbc")]
        [DataRow("3[a2[c]]", "accaccacc")]
        [DataRow("2[abc]3[cd]ef", "abcabccdcdcdef")]
        [DataRow("12[a]ef", "aaaaaaaaaaaaef")]
        [DataRow("102[a]ef", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaef")]
        public void DecodeString(string input, string expectedOutput)
        {
            var output = DecodeStringService.Decode(input);

            output.Should().Be(expectedOutput);
        }

        [DataTestMethod]
        [DataRow("abccccdd", 7)]
        [DataRow("a", 1)]
        [DataRow("AaBbCc", 1)]
        public void LongLengthPalindrome(string input, int expectedLength)
        {
            var length = PalindromService.CalculateLongestPalindrome(input);

            length.Should().Be(expectedLength);
        }

        [DataTestMethod]
        [DataRow("abccccdd", "ccdadcc")]
        //[DataRow("a", "a")]
        //[DataRow("AaBbCc", "A")]
        public void ExpectPalindrome(string input, string expectedLength)
        {
            var result = PalindromService.GetPalindrome(input);

            result.Should().Be(expectedLength);
        }
    }
}
