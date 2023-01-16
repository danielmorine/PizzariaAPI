using FluentAssertions;
using Pizzaria.Domain.Entities;
using Pizzaria.Domain.Messges;
using Pizzaria.Domain.Validation;
using Xunit;

namespace Pizzaria.Tests;

public class IngredientTest
{
    [Fact]
    public void CreateIngredient_WithValidParameters_ShouldByOk()
    {
        Action action = () => new Ingredient(Guid.NewGuid(), "Frango", DateTimeOffset.UtcNow);
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateIngredient_WithInvalidId_ShouldByException()
    {
        Action action = () => new Ingredient(Guid.Empty, "Frango", DateTimeOffset.UtcNow);
        action.Should().Throw<DomainExceptionValidation>().WithMessage(MessageValidation.InvalidId);
    }

    [Fact]
    public void CreateIngredient_WithNameEmpty_ShouldByException()
    {
        Action action = () => new Ingredient(Guid.Empty, "", DateTimeOffset.UtcNow);
        action.Should().Throw<DomainExceptionValidation>().WithMessage(MessageValidation.IngredientNameIsRequired);
    }

    [Fact]
    public void CreateIngredient_WithNameToLarge_ShouldByException()
    {
        var name = "Super frango com alho especial, cebola, com queijo, camarão e carne de porco";

        Action action = () => new Ingredient(Guid.Empty, name, DateTimeOffset.UtcNow);
        action.Should().Throw<DomainExceptionValidation>().WithMessage(MessageValidation.IngredientNameIsToLarge);
    }

    [Fact]
    public void UpdateIngredient_WithValidValid_ShouldByOk()
    {
        Action action = () => new Ingredient(Guid.NewGuid(), "FRANGO ", DateTimeOffset.UtcNow).Update("frango");
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void UpdateIngredient_WithNameEmpty_ShouldByException()
    {
        Action action = () => new Ingredient(Guid.NewGuid(), "FRANGO", DateTimeOffset.UtcNow).Update("");
        action.Should().Throw<DomainExceptionValidation>().WithMessage(MessageValidation.IngredientNameIsRequired);
    }

    [Fact]
    public void UpdateIngredient_WithNameToLarge_ShouldByException()
    {
        var name = "Super frango com alho especial, cebola, com queijo, camarão e carne de porco";

        Action action = () => new Ingredient(Guid.NewGuid(), "frango ", DateTimeOffset.UtcNow).Update(name);
        action.Should().Throw<DomainExceptionValidation>().WithMessage(MessageValidation.IngredientNameIsToLarge);
    }
}