using Castle.Core.Logging;
using E_Commerce.Api.Controllers;
using E_Commerce.Application.DTOs;
using E_Commerce.Application.Features.Queries.Product;
using E_Commerce.Application.Interfaces;
using E_Commerce.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace E_Commerce.Tests
{
    public class ProductControllerTests
    {
        private readonly Mock<IMediator> mediatorMock;
        private readonly Mock<ILogger<ProductController>> logMock;
        private readonly ProductController productController;

        private ServiceResponse<List<ProductDto>> products;
        private ServiceResponse<ProductDetailDto> product;

        public ProductControllerTests()
        {
            mediatorMock = new Mock<IMediator>();
            logMock = new Mock<ILogger<ProductController>>();
            productController = new ProductController(mediatorMock.Object, logMock.Object);

            products = new ServiceResponse<List<ProductDto>>()
            {
                Value = new List<ProductDto>()
                {
                    new ProductDto() {
                        Title= "SAMSUNG Galaxy S21+",
                        Slug= "samsung-galaxy-s21",
                        Price= 770.45m,
                        Image= "https://i.hizliresim.com/3xgesny.jpg",
                        Id= 256925260
                    },
                    new ProductDto() {
                        Title= "Samsung Galaxy S10",
                        Slug= "samsung-galaxy-s10",
                        Price= 1060.45m,
                        Image= "https://i.hizliresim.com/3bqzb8v.jpg",
                        Id= 256925261
                    }
                }
            };

            product = new ServiceResponse<ProductDetailDto>()
            {
                Value = new ProductDetailDto()
                {
                    Id = 256925260,
                    Title = "SAMSUNG Galaxy S21+",
                    Price = 770.45m,
                    Image = "https://i.hizliresim.com/3xgesny.jpg"
                }
            };
        }

        [Fact]
        public async void GetProductDetails_SendQuery_ReturnOkResultWithProducts()
        {
            mediatorMock.Setup(x => x.Send(It.IsAny<GetAllProductsQuery>(),
                default(CancellationToken))).ReturnsAsync(products);

            var result = await productController.GetProductDetails();
            
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnProducts = Assert.IsAssignableFrom<ServiceResponse<List<ProductDto>>>(okResult.Value);

            Assert.Equal<int>(2, returnProducts.Value.Count);
        }

        [Theory]
        [InlineData("samsung-galaxy-s21")]
        public async void GetProduct_SendQuery_ReturnokResultWithProduct(string slug)
        {
            mediatorMock.Setup(x => x.Send(It.Is<GetProductQuery>(x => x.Slug == slug),
                default(CancellationToken))).ReturnsAsync(product);

            var result = await productController.GetProduct(slug);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnProduct = Assert.IsAssignableFrom<ServiceResponse<ProductDetailDto>>(okResult.Value);

            Assert.Equal<int>(256925260, returnProduct.Value.Id);
        }
    }
}
