# PasswordKit

Small .NET library for generating secure passwords and memorable passphrases, as well as hashing and verifying passwords with BCrypt.

## Features

* Cryptographically secure random password generation
* Memorable passphrase generation
* Password hashing with BCrypt
* Password verification
* Simple API
* No external configuration required for hashing

## Installation

Install the package from NuGet:

```bash
dotnet add package PasswordKit
```

Or add the package reference to your `.csproj`:

```xml
<PackageReference Include="PasswordKit" Version="0.1.0" />
```

## Usage

### Password generation

Generate a secure random password:

```csharp
using PasswordKit.Generators;

var generator = new PasswordGenerator();

var password = generator.Generate(12);

Console.WriteLine(password);
```

Example output:

```text
x7@Kp2#Lm9Q!
```

The password generator uses `RandomNumberGenerator` from `System.Security.Cryptography` to generate cryptographically secure random values.

### Passphrase generation

Generate a memorable passphrase:

```csharp
using PasswordKit.Generators;

var generator = new PassphraseGenerator();

var passphrase = generator.Generate(3);

Console.WriteLine(passphrase);
```

Example output:

```text
blue-river-tiger-427
```

The number passed to `Generate()` specifies how many words should be included in the passphrase.

### Password hashing

Hash a password using BCrypt:

```csharp
using PasswordKit.Hashing;

var hasher = new PasswordHasher();

var hash = hasher.Hash("MyPassword123");

Console.WriteLine(hash);
```

The generated hash can be safely stored in a database instead of storing the original password.

BCrypt automatically generates and stores a unique salt for each password hash. No manual salt configuration is required.

### Password verification

Verify a password against a previously generated hash:

```csharp
var isValid = hasher.Verify(
    "MyPassword123",
    hash
);

Console.WriteLine(isValid);
```

Output:

```text
True
```

An incorrect password returns `false`:

```csharp
var isValid = hasher.Verify(
    "WrongPassword",
    hash
);
```

## Project structure

```text
PasswordKit/
├── src/
│   └── PasswordKit/
│       ├── Generators/
│       │   ├── IPassGenerator.cs
│       │   ├── PasswordGenerator.cs
│       │   └── PassphraseGenerator.cs
│       │
│       └── Hashing/
│           ├── IPasswordHasher.cs
│           └── PasswordHasher.cs
│
├── tests/
│   └── PasswordKit.Tests/
│       ├── Generators/
│       └── Hashing/
│
└── README.md
```

## Requirements

- .NET 10

## Security

PasswordKit does not store or manage passwords.

Generated passwords should be shown to the user only when necessary and should not be logged or stored in plain text.

For password storage, store the generated BCrypt hash instead of the original password.

## License

MIT License

Copyright (c) 2026

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files, to deal in the Software
without restriction, including without limitation the rights to use, copy,
modify, merge, publish, distribute, sublicense, and/or sell copies of the
Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
