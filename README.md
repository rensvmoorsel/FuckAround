# FuckAround

FuckAround is a library to use a funny notation for try and catch blocks.
Examples:
```
using FuckAroundFindOut;

new FuckAround(() =>
    {
        throw new Exception("This is an exception");
    })
    .FindOut(() =>
    {
        Console.WriteLine($"sytem exception: {e.Message}");
    })
    .Yolo();
```

```
using FuckAroundFindOut;

FuckAround fuckAround = new FuckAround(() =>
    {
        throw new SystemException("This is an exception");
    })
    .FindOut<Exception>(e =>
    {
        Console.WriteLine($"Exception: {e.Message}");
    })
    .FindOut<SystemException>(e =>
    {
        Console.WriteLine($"System exception: {e.Message}");
    });
    
fuckAround.Yolo();
```

```
using FuckAroundFindOut;

FuckAround fuckAround = new FuckAround(() =>
    {
        throw new SystemException("This is an exception");
    });
    
fuckAround.FindOut<Exception>(e =>
    {
        Console.WriteLine($"Exception: {e.Message}");
    });
    
fuckAround.Yolo();
```

Based on https://classic.yarnpkg.com/en/package/fuck-around-and-find-out