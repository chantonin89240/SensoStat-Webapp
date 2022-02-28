namespace SensoStat.Models.HttpResponse
{
    using SensoStat.Entities;
    public class ResponseResponse
    {
        public int idInstruction { get; set; }
        
        public int idProduct { get; set; }

        public int idPanelist { get; set; }
        
        public string response { get; set; }

        public DateTime DateResponse { get; set; }


        public ResponseResponse(int idinstru, int idProdu, int idPane, string repon, DateTime date)
        {
            
        }

        public ResponseResponse()
        {
        }
    }
}
