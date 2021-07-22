using E_Commerce.Application.DTOs;
using E_Commerce.Application.Features.Commands.Cart;
using E_Commerce.Application.Wrappers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_Commerce.Web.PageProcesses
{
    public class CartItemsProcess : ComponentBase
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; }

        protected List<CartItemDto> CartItemDto = new List<CartItemDto>();

        public decimal totalCartPrice;
        public int totalCartQuantity;

        protected override async Task OnInitializedAsync()
        {
            await Load();
        }

        protected async Task Load()
        {
            AuthenticationState authState = await AuthenticationStateTask;
            ClaimsPrincipal user = authState.User;

            string sub_id = user.Claims.FirstOrDefault(x => x.Type == "sub").Value;

            var response = await HttpClient.GetFromJsonAsync
                    <ServiceResponse<List<CartItemDto>>>($"api/v1/cart/{sub_id}");

            CartItemDto = response.Value;

            totalCartPrice = 0;
            totalCartQuantity = 0;

            foreach (CartItemDto p in CartItemDto)
            {
                totalCartPrice += p.Quantity * p.Price;
                totalCartQuantity += p.Quantity;
            }
        }

        protected async Task IncreaseQuantity(int id)
        {
            HttpResponseMessage response = await HttpClient.PostAsJsonAsync($"api/v1/cart/{id}/1", new UpdateCartCommand() { Id = id, QuantityActionType = 1 });
            await Load();
        }

        protected async Task DecreaseQuantity(int id)
        {
            await HttpClient.PostAsJsonAsync($"api/v1/cart/{id}/0", new UpdateCartCommand() { Id = id, QuantityActionType = 0 });
            await Load();
        }

        protected async Task DeleteCartItem(int id)
        {
            await HttpClient.DeleteAsync($"api/v1/cart/{id}");
            await Load();
        }


        protected void NavigateToProducts()
        {
            NavigationManager.NavigateTo("products");
        }
    }
}
