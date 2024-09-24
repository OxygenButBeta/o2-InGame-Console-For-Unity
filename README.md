# O2 Console

**O2 Console** is an in-game, attribute-driven debug console for Unity that allows developers to define and execute commands easily. Built using the **Reflection API**, it dynamically discovers scene objects and registers command methods at runtime, making it incredibly flexible. With its real-time command execution and robust exception handling, O2 Console provides a powerful way to interact with and debug your game, enhancing your development experience.

---

## Features

- **Command Attribute System**: Mark methods as console commands using `[ConsoleCommand("Command Key")]`, and O2 Console automatically registers them.
- **Reflection-Based Command Registration**: O2 Console scans and registers commands from methods, properties, and fields (both public and private) at runtime.
- **Dynamic Command Execution**: Execute commands in-game directly through the console interface.
- **Static and Instance Methods**: Supports executing both static and instance methods.
- **Real-Time Object Discovery**: Automatically detects and interacts with scene objects during gameplay.
- **Supports Parameter Passing**: Command methods can accept parameters, and the console automatically converts inputs to match method signatures.
- **Exception Handling**: Automatically catches and logs exceptions from commands and the console, without crashing or pausing the game.
- **Built-in Commands**: Includes commands like `/Clear` to clear console logs, with additional built-in functionality to interact with the game.

---

## Getting Started

### Installation

1. Clone or download the **O2 Console** repository or download the unity package.
2. Import the O2 Console scripts into your Unity project.
3. **Set up the Console UI**: The project includes a ready-to-use prefab for the console. Simply drag and drop the prefab into your scene to integrate the in-game console with an input field and log display.

4. Optionally, configure a hotkey to toggle the console (e.g., `~` key).

### Usage

To define a console command, simply use the `[ConsoleCommand]` attribute above any static or instance method, as well as public or private properties. The console will automatically register it for in-game use.

```csharp
// Method Example
[ConsoleCommand("SomeFunction")]
static void SomeFunction()
{
    // Do Something
}

// Property Example (Public)
public class ExampleClass
{
    private int _value;

    [ConsoleCommand("GetValue")]
    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }
}

// Property Example (Private)
public class ExampleClass
{
    private int _privateValue;

    [ConsoleCommand("GetPrivateValue")]
    private int PrivateValue
    {
        get { return _privateValue; }
    }
}

// Instance Method Example
public class ExampleInstance
{
    [ConsoleCommand("InstanceMethod")]
    public void InstanceMethod()
    {
        // Do Something
    }
}

// Static Property Example
public class StaticExample
{
    private static int _staticValue;

    [ConsoleCommand("GetStaticValue")]
    public static int StaticValue
    {
        get { return _staticValue; }
        set { _staticValue = value; }
    }
}
```````
