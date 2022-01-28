namespace SensoStat.WebApplication.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    public class SessionViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Etat { get; set; } = "Non-publié";

        public DateTime DateCreate { get; set; }

        public DateTime DateUpdate { get; set; }

        public DateTime DateClose { get; set; }
    }
}