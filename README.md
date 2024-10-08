# o2 InGame Console

**o2 Console** is an in-game, attribute-driven debug console for Unity that allows developers to define and execute commands easily. Built using the **Reflection API**, it dynamically discovers scene objects and registers command methods at runtime, making it incredibly flexible. With its real-time command execution and robust exception handling, O2 Console provides a powerful way to interact with and debug your game, enhancing your development experience.

---

## Features

- **Command Attribute System**: Mark methods as console commands using `[ConsoleCommand("Command Key")]`, and O2 Console automatically registers them.
- **Reflection-Based Command Registration**: O2 Console scans and registers commands from methods, properties, and fields (both public and private) during scene initialization.
- **Supports Single Parameter Methods**: Currently, O2 Console supports methods with up to one parameter. Support for multiple parameters may be added in the future.
- **Dynamic Command Execution**: Execute commands in-game directly through the console interface.
- **Static and Instance Methods**: Supports executing both static and instance methods.
- **Scene Discovery on Initialization**: O2 Console scans and interacts with objects present at scene load. For objects created during runtime, manual subscription to the console is required.
- **Supports Parameter Passing**: Command methods can accept one parameter, and the console automatically converts the input to match the method signature.
- **Exception Handling**: Automatically catches logs & exceptions and print it out to the console.
- **Built-in Commands**: Includes commands like `/Clear` to clear console logs, with additional built-in functionality to interact with the game and the engine.


---
## Ready-to-use user interface
![O2 Console Screenshot](Console%20UI%20Images/ConsoleIM%20(5).png)
### Additional Screenshots
- [Screenshot 1](Console%UI%Images/ConsoleIM%(2).png)
- [Screenshot 2](Console%UI%Images/ConsoleIM%(4).png)
- [Screenshot 3](Console%UI%Images/ConsoleIM%(6).png)

## Getting Started

### Installation

1. Clone the **O2 Console** repository or download the unity package.
2. Import the O2 Console scripts into your Unity project.
3. **Set up the Console UI**: The project includes a ready-to-use prefab for the console. Simply drag and drop the prefab into your scene to integrate the in-game console with an input field and log display.
4. Optionally, configure a hotkey to toggle the console (e.g., `~` key).

### Usage

To define a console command, simply use the `[ConsoleCommand]` attribute above any static or instance method, as well as public or private properties. The console will automatically register it for in-game use.

Property & Field Example (Public & private)
```csharp
    [ConsoleCommand("GetValue")]
    public int Value {get; set;}

    [ConsoleCommand("GetStaticValue")]
    public static int StaticValue {get; set;}

    [ConsoleCommand("GetPrivateValue")]
    private int PrivateValue;
```````
Instance & Static Method Example
```csharp

    [ConsoleCommand("InstanceMethod")]
    public void InstanceMethod()
    {
        // Do Something
    }
    
    [ConsoleCommand("SomeFunction")]
    static string SomeFunction()
    {
       return // Do Something
    }
```````
