<!--[![Build status](https://dev.azure.com/palmund/Typesafe.With/_apis/build/status/Typesafe.With)](https://dev.azure.com/palmund/Typesafe.With/_build/latest?definitionId=9)-->
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![NuGet version](https://badge.fury.io/nu/AutoFixture.Community.Optional.svg)](https://www.nuget.org/packages/AutoFixture.Community.Optional)

# AutoFixture.Community.Optional

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
