using System;
namespace SensoStat.Mobile.Models.Entities.Interfaces
{
    public interface IProductEntity
    {
        int Id { get; set; }

        string IdProduct { get; set; }

        string Code { get; set; }
    }
}
