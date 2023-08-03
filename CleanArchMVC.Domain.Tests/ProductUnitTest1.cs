using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Validation;

using FluentAssertions;

namespace CleanArchMVC.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "CreateProduct_WithValidParameters_ResultObjectValidState")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () =>
            {
                new Product(1, "Product Name", "Product Description", 10.2m, 99, "Product Image");
            };

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "CreateProduct_WithNegativeIdValue_ThrowInvalidIdValueException")]
        public void CreateProduct_WithNegativeIdValue_ThrowInvalidIdValueException()
        {
            Action action = () =>
            {
                new Product(-1, "Product Name", "Product Description", 10.2m, 99, "Product Image");
            };

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "CreateProduct_WithNullOrEmptyNameValue_ThrowNameIsRequiredException")]
        public void CreateProduct_WithNullOrEmptyNameValue_ThrowNameRequiredException()
        {
            Action actionNull = () =>
            {
                new Product(1, null, "Product Description", 10.2m, 99, "Product Image");
            };

            Action actionEmpty = () =>
            {
                new Product(1, "", "Product Description", 10.2m, 99, "Product Image");
            };

            actionNull.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
            actionEmpty.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "CreateProduct_WithShortNameValue_ThrowNameTooShortException")]
        public void CreateProduct_WithShortNameValue_ThrowNameTooShortException()
        {
            Action action = () =>
            {
                new Product(1, "Pr", "Product Description", 10.2m, 99, "Product Image");
            };

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name. Too short, minimum 3 characters");
        }

        [Fact(DisplayName = "CreateProduct_WithNullOrEmptyDescriptionValue_ThrowDescriptionIsRequiredException")]
        public void CreateProduct_WithNullOrEmptyDescriptionValue_ThrowDescriptionIsRequiredException()
        {
            Action actionNull = () =>
            {
                new Product(1, "Product Name", null, 10.2m, 99, "Product Image");
            };

            Action actionEmpty = () =>
            {
                new Product(1, "Product Name", "", 10.2m, 99, "Product Image");
            };

            actionNull.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description. Description is required");
            actionEmpty.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description. Description is required");
        }

        [Fact(DisplayName = "CreateProduct_WithShortDescriptionValue_ThrowDescriptionTooShortException")]
        public void CreateProduct_WithShortDescriptionValue_ThrowDescriptionTooShortException()
        {
            Action action = () =>
            {
                new Product(1, "Product Name", "Prod", 10.2m, 99, "Product Image");
            };

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description. Too short, minimum 5 characters");
        }

        [Fact(DisplayName = "CreateProduct_WithInvalidPriceValue_ThrowInvalidPriceException")]
        public void CreateProduct_WithInvalidPriceValue_ThrowInvalidPriceException()
        {
            Action action = () =>
            {
                new Product(1, "Product Name", "Product Description", -100.2m, 99, "Product Image");
            };

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid price value");
        }

        [Fact(DisplayName = "CreateProduct_WithInvalidStockValue_ThrowInvalidStockException")]
        public void CreateProduct_WithInvalidStockValue_ThrowInvalidStockException()
        {
            Action action = () =>
            {
                new Product(1, "Product Name", "Product Description", 100.2m, -2, "Product Image");
            };

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid stock value");
        }

        [Fact(DisplayName = "CreateProduct_WithLongImageNameValue_ThrowInvalidImageException")]
        public void CreateProduct_WithLongImageNameValue_ThrowInvalidImageException()
        {
            Action action = () =>
            {
                new Product(1, "Product Name", "Product Description", 100.2m, 2, "Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image");
            };

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid image name. Too long, maximum 250 characters");
        }

        [Fact(DisplayName = "CreateProduct_WithNullImageName_NoDomainException")]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () =>
            {
                new Product(1, "Product Name", "Product Description", 100.2m, 2, null);
            };

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "CreateProduct_WithNullImageName_NoNullReferenceException")]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () =>
            {
                new Product(1, "Product Name", "Product Description", 100.2m, 2, null);
            };

            action.Should().NotThrow<NullReferenceException>();
        }
    }
}