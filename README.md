### Old Phone Keypad Decoder

A C# implementation that simulates the text input mechanism of old mobile phone keypads, where users had to press number keys multiple times to type letters.

### Problem Description
Old mobile phones had numeric keypads where each number key (2-9) was associated with multiple letters. To type text, users had to press the same key multiple times to cycle through its associated letters.

### Key Features:
- Multiple key presses: Press a key multiple times to cycle through letters (e.g., pressing `2` three times produces `C`)
- Space separator: Pause (represented by space ` `) to type two letters from the same key (e.g., `2 2` produces `AA`)
- Backspace: Use `*` to delete the last character
- Send/Terminate: Use `#` to send/finish the input

### Keypad Mapping:
```
0 → Space
1 → &'(
2 → ABC
3 → DEF
4 → GHI
5 → JKL
6 → MNO
7 → PQRS
8 → TUV
9 → WXYZ
* → Backspace
# → Send
```
### Getting Started
### Prerequisites
- [.NET SDK 6.0](https://dotnet.microsoft.com/download) or higher

### Installation & Running
1. Clone the repository:
   - git clone https://github.com/kyawthethtwe/OldPhonePad.git
   - cd OldPhonePad

2. Run the program:
   - dotnet run

3. Build the project (optional):
   - dotnet build

### Testing
The program includes built-in test cases that run automatically when you start the application. These tests verify:
- Basic single character input
- Multiple presses on the same key
- Space separators for same-key characters
- Backspace functionality
- Cycling behavior (e.g., `2222` cycles back to `A`)
- Complex combinations

### Test Results Example:
Running Test Cases:
PASS | Input: "33#" => Expected: "E" | Got: "E"
PASS | Input: "227*#" => Expected: "B" | Got: "B"
PASS | Input: "4433555 555666#" => Expected: "HELLO" | Got: "HELLO"
PASS | Input: "8 88777444666*664#" => Expected: "TURING" | Got: "TURING"

### Code Structure

`OldPhonePad.cs`

OldPhonePadDecoder class
   KeyMappings (Dictionary) - Maps keys to letters
      OldPhonePad(string input) - Main decoding logic
   Program class
   Main() - Entry point with test cases
   RunTestCases() - Automated test suite


### Core Algorithm
The `OldPhonePad` method processes the input string character by character:

1. Termination Check: Stop when encountering `#`
2. Backspace Handling: Remove last character when encountering `*`
3. Space Handling: Skip spaces (used as separators)
4. Number Key Processing:
   - Count consecutive presses of the same key
   - Calculate letter index using modulo (for cycling)
   - Append the corresponding letter to result


### Simplified logic
int letterIndex = (count - 1) % letters.Length;
result.Append(letters[letterIndex]);

### Design Decisions
1. Dictionary for Key Mappings: Provides O(1) lookup time and makes the mapping easy to understand and modify

2. Modulo for Cycling: Using `(count - 1) % letters.Length` allows unlimited key presses that cycle through available letters

3. StringBuilder: More efficient than string concatenation for building the result

4. Null Safety: Handles empty or null input gracefully

5. Comprehensive Documentation: XML comments for IntelliSense support in IDEs

### Interactive Mode
After running test cases, the program enters interactive mode where you can test your own inputs:

Enter your input string (or 'exit' to quit):
> 44 33555#
Output: HEL

> 777666#
Output: RO

> exit

### Method: `OldPhonePadDecoder.OldPhonePad(string input)`
#### Parameters:
- `input` (string): The input string containing number keys (0-9), spaces, asterisks (*), and ending with hash (#)

### Returns:
- `string`: The decoded text

### Example Usage:
string result = OldPhonePadDecoder.OldPhonePad("4433555 555666#");
Console.WriteLine(result); // Output: HELLO

### Contributing
This project was created as a coding challenge for Iron Software. Feel free to:
- Report bugs
- Suggest enhancements
- Submit pull requests

### Contact
For questions or feedback, please contact: kyawthethtwe595@gmail.com


Author: Kyaw Thet Htwe  
Created: October 2025  
Repository: https://github.com/kyawthethtwe/OldPhonePad
