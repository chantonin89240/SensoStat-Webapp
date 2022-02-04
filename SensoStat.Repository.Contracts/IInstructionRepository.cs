namespace SensoStat.Repository.Contracts
{
    using SensoStat.Entities;

    /// <summary>
    /// Interface pour les instructions.
    /// </summary>
    public interface IInstructionRepository
    {
        /// <summary>
        /// Ajoute un nouvelle instruction.
        /// </summary>
        /// <param name="instruction">Instruction à ajouter.</param>
        void Add(Instruction instruction);

        /// <summary>
        /// Supprime une instruction.
        /// </summary>
        /// <param name="instruction">Instruction à supprimmer.</param>
        void Delete(Instruction instruction);

        /// <summary>
        /// Retourne l'instruction demandée.
        /// </summary>
        /// <param name="id">Id de l'instruction à trouver.</param>
        /// <returns>L'intruction ayant l'id demandé si celui-ci est trouvé sinon renvoie null.</returns>
        Instruction Find(int id);

        /// <summary>
        /// Retourne toutes les instructions.
        /// </summary>
        /// <returns>Une collection contenant toutes les instructions.</returns>
        IEnumerable<Instruction> FindAll();

        /// <summary>
        /// Met à jour une instruction.
        /// </summary>
        /// <param name="instruction">Instruction à modifier.</param>
        void Update(Instruction instruction);
    }
}
