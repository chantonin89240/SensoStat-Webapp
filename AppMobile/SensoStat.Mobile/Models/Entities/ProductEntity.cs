using System;
using SensoStat.Mobile.Models.Dtos;
using SensoStat.Mobile.Models.Entities.Interfaces;
using SQLite;

namespace SensoStat.Mobile.Models.Entities
{
    public class ProductEntity : IProductEntity
    {
        [PrimaryKey] [AutoIncrement] public int Id { get; set; }

        public string IdProduct { get; set; }

        public string Code { get; set; }

        public ProductEntity()
        {
        }

        public ProductEntity(ProductDownDto product)
        {
            IdProduct = product.Id;
            Code = product.Code;
        }
    }
}
