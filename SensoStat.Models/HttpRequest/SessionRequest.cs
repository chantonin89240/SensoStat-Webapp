using System.ComponentModel.DataAnnotations;
using SensoStat.Entities;

namespace SensoStat.Models.HttpRequest
{
    public class SessionRequest
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Etat { get; set; }

        [Required]
        public int IdPerson { get; set; }

        [Required]
        public string MsgAccueil { get; set; }

        [Required]
        public string MsgFinal { get; set; }

        public DateTime DateCreate { get; set; }

        public List<string> Types { get; set; }

        public List<string> Messages { get; set; }

        public List<InstructionRequest> Instructions { get; set; }

    }
}
