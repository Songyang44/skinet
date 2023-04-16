using Infrastructure.Data;
using Core.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specifications;
using API.Dtos;
using AutoMapper;
using API.Errors;

namespace API.Controllers
{
    
    public class ProductsController : BaseApiController
    {

     
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController
        (
        IGenericRepository<Product> productsRepo,
        IGenericRepository<ProductBrand> productBrandRepo, 
        IGenericRepository<ProductType> productTypeRepo,
        IMapper mapper)
        {
            _productsRepo=productsRepo;
            _productBrandRepo=productBrandRepo;
            _productTypeRepo=productTypeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec=new ProductsWithTypesAndBrandsSpecification();
            var products=await _productsRepo.ListAsync(spec);
            return Ok(_mapper
            .Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        /*
        [ProducesResponseType(StatusCodes.Status200OK)] 是一个特性（attribute），
        可以应用于控制器的方法上。它指示控制器方法将返回一个 HTTP 响应，该响应的状态码是 200（OK）。
        这个特性通常用于帮助 Swagger 或其他 API 文档生成器生成正确的 API 文档。
        如果一个方法包含了这个特性，Swagger 将会在生成的文档中包括该方法返回值的相关信息，
        其中状态码为 200，表示该方法成功执行并返回了一些数据。
        如果方法返回值的类型不是 void，还可以指定其他的 [ProducesResponseType] 特性，
        以便在生成的文档中包括更多关于返回值类型的信息。
        */
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec=new ProductsWithTypesAndBrandsSpecification(id);
            var product= await _productsRepo.GetEntityWithSpec(spec);
            if(product == null) return NotFound(new ApiResponse(404));
            return _mapper.Map<Product,ProductToReturnDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());
        }

         [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }
    }
}