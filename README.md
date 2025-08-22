# Azimzada.StringSimilarity

A powerful .NET library for calculating string similarities and performing fuzzy searches. This library implements popular string similarity algorithms like Levenshtein Distance and Jaro-Winkler, making it perfect for tasks such as spell checking, search suggestions, and data matching.

## Features

- 🚀 Fast and efficient implementation
- 📊 Percentage-based similarity scores (0-100%)
- 🔍 Multiple similarity algorithms
- 🎯 Easy to use API
- ✨ Support for .NET 9.0+

## Installation

Install via NuGet Package Manager:

```sh
Install-Package Azimzada.StringSimilarity
```

Or via .NET CLI:

```sh
dotnet add package Azimzada.StringSimilarity
```

Current version: 1.0.3

## Usage

First, add the namespace to your code:

```csharp
using Azimzada.StringSimilarity;
```

### Levenshtein Distance

The Levenshtein distance measures the minimum number of single-character edits required to change one string into another. The similarity score is returned as a percentage (0-100%).

```csharp
double similarity = StringSimilarity.Levenshtein("hello", "hallo");
// Returns: 80.0 (because only one character is different)

double similarity2 = StringSimilarity.Levenshtein("kitten", "sitting");
// Returns a percentage showing how similar the words are
```

### Jaro-Winkler Similarity

The Jaro-Winkler similarity is particularly good for short strings such as person names. It returns a percentage score (0-100%).

```csharp
double similarity = StringSimilarity.JaroWinkler("martha", "marhta");
// Returns: A high percentage as these are very similar

double similarity2 = StringSimilarity.JaroWinkler("dwayne", "duane");
// Returns: A good match score due to common characters
```

## Examples

Here are some real-world examples:

```csharp
// Check if user input matches a correct word
double score = StringSimilarity.Levenshtein("programming", "programing");
if (score > 90)
{
    Console.WriteLine("Did you mean 'programming'?");
}

// Compare two names
double nameMatch = StringSimilarity.JaroWinkler("John Smith", "Jon Smith");
if (nameMatch > 85)
{
    Console.WriteLine("Names are likely to refer to the same person");
}
```

## Algorithm Details

### Levenshtein Distance
- Measures the minimum number of single-character edits needed to change one string into another
- Handles insertions, deletions, and substitutions
- Returns a normalized percentage score (0-100%)

### Jaro-Winkler
- Designed for short strings like names and passwords
- Accounts for character transpositions
- Gives more favorable ratings to strings that match from the beginning
- Returns a percentage score (0-100%)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contributing

Contributions are welcome! Feel free to submit issues and pull requests.
