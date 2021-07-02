﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mango.Services.ProductAPI.Models.Dto;
using Mango.Services.ProductAPI.Repository;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private readonly IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
                _response.Result = productDtos;

            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() {e.ToString()};
            }

            return _response;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseDto> GetProductById(int id)
        {
            try
            {
                ProductDto productDto = await _productRepository.GetProductById(id);
                _response.Result = productDto;

            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }

            return _response;
        }

        [HttpPost]
        public async Task<ResponseDto> Post([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = model;

            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }

            return _response;
        }

        [HttpPut]
        public async Task<ResponseDto> Put([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = model;

            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }

            return _response;
        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<ResponseDto> Delete(int id)
        {
            try
            {
                var isSuccess = await _productRepository.DeleteProduct(id);
                _response.Result = isSuccess;

            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }

            return _response;
        }





    }
}
