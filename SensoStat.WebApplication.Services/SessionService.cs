namespace SensoStat.WebApplication.Services
{
    using CsvHelper;
    using Microsoft.AspNetCore.Http;
    using SensoStat.WebApplication.Services.Contracts;
    using System.Globalization;

    public class SessionService : ISessionService
    {
        public void LoadFile(IFormFile file)
        {
            using (var fileStream = file.OpenReadStream())
            using (var reader = new StreamReader(fileStream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<dynamic>();
            }
        }
    }
}