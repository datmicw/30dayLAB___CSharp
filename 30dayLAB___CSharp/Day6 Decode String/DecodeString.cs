//Day 6: Decode String
//Task:
//Input a string in the format 3[a] 2[bc].
//• Decode the string to aaabcbc.
//• Algorithm: Use a stack to decode the string.

namespace _30dayLAB___CSharp.Day6_Decode_String
{
    internal class DecodeString()
    {
       public string Decode()
        {
            Console.WriteLine("Input: ");
            string s = Console.ReadLine();
            Stack<string> stackString = new Stack<string>(); // khoi tao stack string
            Stack<int> stackNum = new Stack<int>(); // khoi tao stack num
            string currentString = "";  // khoi tao string hien tai
            int currentNum = 0; // khoi tao num hien tai
            foreach (char c in s)
            {
                if (char.IsDigit(c)) // kiem tra xem c co phai la so khong
                {
                    currentNum = currentNum * 10 + c - '0'; // chuyen c thanh so
                }
                else if (c == '[') // kiem tra xem c co phai la dau ngoac mo khong
                {
                    stackString.Push(currentString); // push currentString vao stackString
                    stackNum.Push(currentNum); // push currentNum vao stackNum
                    currentString = ""; // reset currentString
                    currentNum = 0; // reset currentNum
                }
                else if (c == ']') // kiem tra xem c co phai la dau ngoac dong khong
                {
                    string temp = stackString.Pop(); // lay phan tu dau tien cua stackString
                    int num = stackNum.Pop(); // lay phan tu dau tien cua stackNum
                    for (int i = 0; i < num; i++) // lap num lan
                    {
                        temp += currentString; // cong them currentString vao temp
                    }
                    currentString = temp; // gan temp cho currentString
                }
                else
                {
                    currentString += c; // cong c vao currentString
                }
            }
            Console.WriteLine(currentString);
            return currentString;
        }
    }
}
