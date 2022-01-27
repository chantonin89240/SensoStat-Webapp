namespace SensoStat.WebApplication.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SensoStat.WebApplication.ViewModels;
    using System.IO;
    using System;

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

        public IActionResult Create()
        {
            return this.View();
        }
        
        // Probleme droit d'acces fichier
        // Alternative Upload le fichier sur le server -> risque sécurité
        public void LoadCSV(string filePath)
        {
            var reader = new StreamReader(System.IO.File.OpenRead(filePath));
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                listA.Add(values[0]);
                listB.Add(values[1]);
                foreach (var coloumn1 in listA)
                {
                    Console.WriteLine(coloumn1);
                }
                foreach (var coloumn2 in listA)
                {
                    Console.WriteLine(coloumn2);
                }
            }
        }

        public async Task<IActionResult> OnPostUploadAsync()
        {
            using (var memoryStream = new MemoryStream())
            {
                await FileUpload.FormFile.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    var file = new ImportPlanSessionViewModel()
                    {
                        Instruction = memoryStream.ToArray()
                    };

                    // _dbContext.File.Add(file);

                    // await _dbContext.SaveChangesAsync();
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
            }

            return View();
        }
    }
}
