using System.Text;

public class OldPhonePadDecoder
    {
        private static readonly Dictionary<char, string> KeyMappings = new Dictionary<char, string>
        {
            { '0', " " },       
            { '1', "&'(" },     
            { '2', "ABC" },     
            { '3', "DEF" },     
            { '4', "GHI" },
            { '5', "JKL" },
            { '6', "MNO" },
            { '7', "PQRS" },
            { '8', "TUV" },     
            { '9', "WXYZ" } 
        };

        public static string OldPhonePad(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            StringBuilder result = new StringBuilder();
            int i = 0;

            while (i < input.Length)
            {
                char currentChar = input[i];

                // Check for send command - terminate processing
                if (currentChar == '#')
                {
                    break;
                }
                // Check for backspace - remove last character
                else if (currentChar == '*')
                {
                    if (result.Length > 0)
                    {
                        result.Remove(result.Length - 1, 1);
                    }
                    i++;
                }
                // Check for space - separator between same key presses
                else if (currentChar == ' ')
                {
                    i++;
                }
                // Process number key presses
                else if (KeyMappings.ContainsKey(currentChar))
                {
                    // Count consecutive presses of the same key
                    int count = 1;
                    while (i + 1 < input.Length && input[i + 1] == currentChar)
                    {
                        count++;
                        i++;
                    }

                    // Get the corresponding letter based on press count
                    string letters = KeyMappings[currentChar];
                    int letterIndex = (count - 1) % letters.Length;
                    result.Append(letters[letterIndex]);
                    i++;
                }
                else
                {
                    // Skip unknown characters
                    i++;
                }
            }

            return result.ToString();
        }
    }


public class Program
{
    public static void Main(string[] args)
    {        
        // Run test cases
        RunTestCases();
        
        Console.WriteLine("Enter your input string (or 'exit' to quit):");
        
        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();
            
            if (string.IsNullOrEmpty(input) || input.ToLower() == "exit")
                break;
            
            // Add # if not present
            if (!input.Contains('#'))
                input += "#";

            string output = OldPhonePadDecoder.OldPhonePad(input);
            Console.WriteLine($"Output: {output}\n");
        }
    }
    
    private static void RunTestCases()
    {
        Console.WriteLine("Running Test Cases:\n");
        
        var testCases = new Dictionary<string, string>
        {
            { "33#", "E" },
            { "227*#", "B" },
            { "4433555 555666#", "HELLO" },
            { "8 88777444666*664#", "TURING" },
            { "2#", "A" },
            { "22#", "B" },
            { "222#", "C" },
            { "2222#", "A" }, 
            { "2 2#", "AA" }, 
            { "222 2 22#", "CAB" }, 
            { "777 7#", "RP" }, 
            { "9999#", "Z" }, 
            { "0#", " " },
            { "44 444#", "HI" },
            { "222*#", "" },
            { "2223*3#", "CD" }
        };
        
        int passed = 0;
        int failed = 0;
        
        foreach (var testCase in testCases)
        {
            string input = testCase.Key;
            string expected = testCase.Value;
            string actual = OldPhonePadDecoder.OldPhonePad(input);
            
            bool isPassed = actual == expected;
            
            if (isPassed)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("PASS");
                passed++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("FAIL");
                failed++;
            }
            
            Console.ResetColor();
            Console.WriteLine($" | Input: \"{input}\" => Expected: \"{expected}\" | Got: \"{actual}\"");
        }
        
        Console.WriteLine($"\n{passed} passed, {failed} failed out of {testCases.Count} tests.\n");
    }
}
