# Azimzada.StringSimilarity

A .NET 6+ library for string similarity and fuzzy search. Implements Levenshtein and Jaro-Winkler algorithms, returns percentage scores, and supports fuzzy search.

## Installation

Add the NuGet source for GitHub Packages to your `nuget.config`:

```xml
<configuration>
  <packageSources>
    <add key="github" value="https://nuget.pkg.github.com/MrAzimzada/index.json" />
  </packageSources>
</configuration>
```

Install via dotnet CLI:

```sh
dotnet add package Azimzada.StringSimilarity --version 1.0.0
```

## Usage

```csharp
using Azimzada.StringSimilarity;

// Levenshtein similarity
var score = StringSimilarity.Levenshtein("kitten", "sitting"); // returns percentage

// Jaro-Winkler similarity
var jwScore = StringSimilarity.JaroWinkler("dwayne", "duane"); // returns percentage

// Fuzzy search
var results = StringSimilarity.FuzzySearch("appl", new[] { "apple", "apply", "ape", "maple" });
// returns best matches with scores
```

## Algorithms
- Levenshtein Distance
- Jaro-Winkler Similarity
- Fuzzy Search (returns best matches)

## Publishing

To publish to GitHub Packages:

```sh
dotnet pack
# Authenticate with GitHub Packages
# Then:
dotnet nuget push bin/Debug/Azimzada.StringSimilarity.1.0.0.nupkg --source "github"
```

## License
MIT
# Azimzada-StringSimilarity
