using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entity;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddInclude(x=>x.ProductType);
            AddInclude(x=>x.ProductBrand);
        }

        /*
         public ProductsWithTypesAndBrandsSpecification(Expression<Func<Product, bool>> criteria) : base(criteria)
        {
            ues "int id" to replace Expression<Func<Product, bool>> criteria
            use "x=>x.Id==id" as criteria replace the parameter
        }

        */
        public ProductsWithTypesAndBrandsSpecification(int id) : base(x=>x.Id==id) // x.Id== int id x->Product
        {
            AddInclude(x=>x.ProductType);
            AddInclude(x=>x.ProductBrand);
        }
    }
}