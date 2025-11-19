# 🛒 Supermarket Basket -- Heaviest-First Strategy

This project implements a simple strategy for deciding which items to
place into a shopping basket with a fixed weight limit. The basket can
hold up to **20 kilograms**, and the algorithm follows a straightforward
rule:

> **Always add the heaviest items first, then continue with lighter ones
> as long as they still fit.**

## Technologies Used

- **C#**

- **.NET 10**\
  Project created using:

      dotnet new console

## Algorithm Description

The basket receives a list of products, each with a name and a weight.\
Before adding them, the list is sorted **in descending order by
weight**:

```csharp
productsToAddList.Sort((a, b) => b.Weight.CompareTo(a.Weight));
```

The algorithm then iterates through the sorted list and adds each
product as long as the basket does not exceed the maximum allowed
weight.

This approach is known as the **heaviest-first strategy**, a simple
heuristic for weight-based selection problems.

## Project Structure

- **Product**\
  Represents an item with a `Name` and `Weight`.

- **Basket**\
  Holds the maximum allowed weight and implements the heaviest-first
  selection logic.

- **Program**\
  Entry point that creates a basket, defines sample items, tests the
  functionality, and prints results.

## Included Testing

The `Main` method provides a minimal test scenario: - A 20 kg basket is
created. - Several products with different weights are defined. - The
heaviest-first strategy is applied. - Items successfully added to the
basket are printed.

Example output:

    Items in basket:
    Sliced bread: 12 kg
    Whole chicken: 5 kg
    Potatoes: 3 kg

Items are inserted from heaviest to lightest, as long as they fit within
the limit.

## Note on Limitations

This project **does not** attempt to compute the optimal solution to the
knapsack problem.\
It strictly implements the heaviest-first specific strategy:

## Running the Project

```bash
dotnet run
```
