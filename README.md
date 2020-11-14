# AutoFixture.Optional

Creating optional specimens.

## Installation

```
PM> Install-Package AutoFixture.Community.Optional
```

## Usage
```
var fixture = new Fixture().Customize(new OptionalCustomization());
var optionalString = fixture.Create<Option<string>>();
```
