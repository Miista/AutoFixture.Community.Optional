# AutoFixture.Optional

Creating optional specimens.

Supports **.NET Core** (.NET Standard 1.5+)

## Installation

```
PM> Install-Package AutoFixture.Community.Optional
```

## Usage
```csharp
var fixture = new Fixture().Customize(new OptionalCustomization());
var optionalString = fixture.Create<Option<string>>();
```
