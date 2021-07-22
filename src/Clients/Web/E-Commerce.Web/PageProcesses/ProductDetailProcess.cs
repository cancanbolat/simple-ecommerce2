using AntDesign;
using Blazored.Modal;
using Blazored.Modal.Services;
using E_Commerce.Application.DTOs;
using E_Commerce.Application.Features.Commands.Cart;
using E_Commerce.Application.Wrappers;
using E_Commerce.Web.CustomComponents;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_Commerce.Web.PageProcesses
{
    public class ProductDetailProcess : ComponentBase
    {

        [Inject]
        public HttpClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [CascadingParameter]
        public IModalService Modal { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; }

        [Parameter]
        public string Slug { get; set; }

        public int editionId = 256925214;

        public ProductDetailDto product { get; set; } = new ProductDetailDto();
        public int EditionId { get => editionId; set => editionId = value; }

        protected override async Task OnInitializedAsync()
        {
            product = (await HttpClient.GetFromJsonAsync<ServiceResponse<ProductDetailDto>>($"api/v1/product/{Slug}")).Value;

            if (product.Prices.Count > 0)
            {
                editionId = product.Prices[0].EditionId;
            }
        }

        protected ProductPriceDto GetSelectedPrice()
        {
            ProductPriceDto selectedProduct = product.Prices.FirstOrDefault(p => p.EditionId == editionId);
            return selectedProduct;
        }

        protected async Task AddCart()
        {
            AuthenticationState authState = await AuthenticationStateTask;
            ClaimsPrincipal user = authState.User;

            try
            {
                await HttpClient.PostAsJsonAsync("api/v1/cart", new AddCartCommand()
                {
                    EditionId = GetSelectedPrice().EditionId,
                    ProductId = product.Id,
                    Quantity = 1,
                    UserId = user.Claims.FirstOrDefault(x => x.Type == "sub").Value
                });

                IModalReference moviesModal = Modal.Show<CartComponent>("Product added to cart");
            }
            catch (Exception ex)
            {
                _ = Modal.Show<CartComponent>($"Error: {ex.Message}");
            }

        }
    }
}
