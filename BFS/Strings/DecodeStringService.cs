using System.Text;

namespace Interview.Samples.Application.Strings
{
    public static class DecodeStringService
    {
        public static string Decode(string input)
        {
            Stack<int> numberStack = new Stack<int>();
            Stack<string> resultStack = new Stack<string>();
            StringBuilder currentString = new StringBuilder();

            int startIndex = 0;
            while (startIndex < input.Length)
            {
                if (char.IsDigit(input[startIndex]))
                {
                    int.TryParse(input[startIndex].ToString(), out var theNumber);
                    startIndex++;

                    // in case of multi-number, like 12 example we have to push the whole number
                    while (char.IsDigit(input[startIndex]))
                    {
                        var stringChar = input[startIndex].ToString();
                        if (int.TryParse(stringChar, out int digit))
                        {
                            theNumber = (theNumber * 10) + digit;
                        }

                        startIndex++;
                    }

                    // add to digit stack
                    numberStack.Push(theNumber);
                }
                else if (input[startIndex] == '[')
                {
                    // start of pattern
                    resultStack.Push(currentString.ToString());
                    currentString = new StringBuilder();

                    startIndex++;
                }
                else if (input[startIndex] == ']')
                {
                    // end of string pattern
                    var stringToDecode = new StringBuilder(resultStack.Pop());
                    var repeatTimes = numberStack.Pop();
                    for (int i = 0; i < repeatTimes; i++)
                    {
                        stringToDecode.Append(currentString);
                    }

                    currentString = stringToDecode;
                    startIndex++;
                }
                else {
                    // build string
                    currentString.Append(input[startIndex]);
                    startIndex++;
                }
            }

            return currentString.ToString();
        }
    }
}
