using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Orange.Web.Models;
using Orange.Web.Services.IServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Orange.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductDto> productDtoList = new List<ProductDto>();
            var response  = await this._productService.GetAllProductsAsync<ResponseDto>("");
            if(response!=null && response.IsSuccess)
            {

                productDtoList = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            return View(productDtoList);
        }


        [Authorize]
        public async Task<IActionResult> Details(int productId)
        {
            ProductDto model = new ProductDto();
            var response = await this._productService.GetProductByIdAsync<ResponseDto>(productId,"");
            if (response != null && response.IsSuccess)
            {

                model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("Details")]
        [Authorize]
        public async Task<IActionResult> DetailsPost(ProductDto productDto)
        {
            //CartDto cartDto = new()
            //{
            //    CartHeader = new CartHeaderDto
            //    {
            //        UserId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value
            //    }
            //};

            //CartDetailsDto cartDetails = new CartDetailsDto()
            //{
            //    Count = productDto.Count,
            //    ProductId = productDto.ProductId
            //};

            //var resp = await _productService.GetProductByIdAsync<ResponseDto>(productDto.ProductId, "");
            //if (resp != null && resp.IsSuccess)
            //{
            //    cartDetails.Product = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(resp.Result));
            //}
            //List<CartDetailsDto> cartDetailsDtos = new();
            //cartDetailsDtos.Add(cartDetails);
            //cartDto.CartDetails = cartDetailsDtos;

            //var accessToken = await HttpContext.GetTokenAsync("access_token");
            //var addToCartResp = await _cartService.AddToCartAsync<ResponseDto>(cartDto, accessToken);
            //if (addToCartResp != null && addToCartResp.IsSuccess)
            //{
            //    return RedirectToAction(nameof(Index));
            //}

            return View(productDto);
        }

        [Authorize]
        public async Task<IActionResult> LoginAsync()
        {

            
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
