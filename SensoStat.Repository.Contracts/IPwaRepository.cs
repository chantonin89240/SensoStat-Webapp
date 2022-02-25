namespace SensoStat.Repository.Contracts
{
    using SensoStat.Models.HttpResponse;

    /// <summary>
    /// Interface pour une campagne.
    /// </summary>
    public interface IPwaRepository
    {
        public PwaSessionResponse getPwaResponsse(string hash);
    }
}