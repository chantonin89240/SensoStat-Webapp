namespace SensoStat.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using SensoStat.WebApplication.ViewModels;
    using System.IO;
    using CsvHelper;
    using System.Globalization;


    public class SessionController : Controller
    {
        private PresentationViewModel model;
        private FileUpload FileUpload;
        public SessionController()
        {
            this.model = new PresentationViewModel();
            this.FileUpload = new FileUpload();
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Archive()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Archive(int id)
        {
            return this.View();
        }


        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(SessionViewModel session)
        {
            
            return this.View();
        }

        public IActionResult Edit(int id)
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Edit(SessionViewModel session)
        {
            return this.View();
        }

        public IActionResult Delete()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Delete(SessionViewModel session)
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> LoadFile(IFormFile file)
        {
            using(var fileStream = file.OpenReadStream())
            using (var reader = new StreamReader(fileStream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<dynamic>();
            }
            return RedirectToAction("create");
        }

        [HttpPost]
        public async Task<IActionResult> CloneSession(int id)
        {
            return RedirectToAction("create");
        }
    }
}
