using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Validation;

using FluentAssertions;

namespace CleanArchMVC.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "CreateCategory_WithValidParameters_ResultObjectValidState")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () =>
            {
                new Category(1, "Category name");
            };

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "CreateCategory_WithNullName_ThrowInvalidNameException")]
        public void CreateCategory_WithNullName_ThrowInvalidNameException()
        {
            Action action = () =>
            {
                new Category(1, null);
            };

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "CreateCategory_WithNegativeId_ThrowInvalidIdValueException")]
        public void CreateCategory_WithNegativeId_ThrowInvalidIdValueException()
        {
            Action action = () =>
            {
                new Category(-1, "Category Name");
            };

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "CreateCategory_WithShortNameValue_ThrowShotNameValueException")]
        public void CreateCategory_WithShortNameValue_ThrowShotNameValueException()
        {
            Action action = () =>
            {
                new Category(1, "Na");
            };

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name. Too short, minimum 3 characters");
        }
    }
}