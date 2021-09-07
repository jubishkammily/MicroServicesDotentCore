using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Orange.Web.Models;
using Orange.Web.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orange.Web.Controllers
{
    public class ProductController : Controller
    {
        public readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;

        }
        public async Task<IActionResult> ProductIndex()
        {
            var acces_token = await HttpContext.GetTokenAsync("access_token");
            List<ProductDto> productDtoList = new List<ProductDto>();

            var response = await productService.GetAllProductsAsync<ResponseDto>(acces_token);

            if (response != null && response.IsSuccess)
            {
                productDtoList = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }

            return View(productDtoList);
        }

        public async Task<IActionResult> ProductEdit(int productId)
        {
            var acces_token = await HttpContext.GetTokenAsync("access_token");
            var response = await productService.GetProductByIdAsync<ResponseDto>(productId, acces_token);
            if (response != null && response.IsSuccess)
            {
                ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEdit(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                var acces_token = await HttpContext.GetTokenAsync("access_token");
                var response = await productService.UpdateProductAsync<ResponseDto>(model, acces_token);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }

            return View(model);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                var acces_token = await HttpContext.GetTokenAsync("access_token");
                var response = await productService.CreateProductAsync<ResponseDto>(model, acces_token);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }

            return View(model);
        }



        public async Task<IActionResult> ProductDelete(int productId)
        {
            var acces_token = await HttpContext.GetTokenAsync("access_token");
            var response = await productService.GetProductByIdAsync<ResponseDto>(productId, acces_token);

                if (response != null && response.IsSuccess)
                {
                ProductDto productDto = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(productDto);
                }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductDelete(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                var acces_token = await HttpContext.GetTokenAsync("access_token");
                var response = await productService.DeleteProductAsync<ResponseDto>(model.ProductId, acces_token);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }

            return View(model);
        }

    }
}
