using System;
using SensoStat.Mobile.Models.Dtos;
using SensoStat.Mobile.Models.Entities.Interfaces;
using SQLite;

namespace SensoStat.Mobile.Models.Entities
{
    public class ProductEntity : IProductEntity
    {
        [PrimaryKey] public int Id { get; set; }

        public string CodeProduct { get; set; }

        public ProductEntity()
        {
        }

        public ProductEntity(ProductDownDto product)
        {
            Id = product.Id;
            CodeProduct = product.CodeProduct;
        }
    }
}
