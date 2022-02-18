using System;
using SensoStat.Entities;
using SensoStat.EntitiesContext;
using SensoStat.Repository.Contracts;

namespace SensoStat.Repository
{
    public class InstructionRepository : IInstructionRepository
    {
        private SensoStatDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionRepository"/> class.
        /// </summary>
        /// <param name="context">Context de la base de donnée.</param>
        public InstructionRepository(SensoStatDbContext context)
        {
            this._context = context;
        }

        public void Add(Instruction instruction)
        {
            throw new NotImplementedException();
        }

        public void Delete(Instruction instruction)
        {
            throw new NotImplementedException();
        }

        public void DeleteAllByIdSession(int idSession)
        {
            var instructions = this._context.Instructions.Where(i => i.IdSession == idSession);
            this._context.Instructions.RemoveRange(instructions);
            this._context.SaveChanges();
        }

        public Instruction Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Instruction> FindAll(int idSession)
        {
            return this._context.Instructions.ToList().FindAll(i => i.IdSession == idSession);
        }

        public void Update(Instruction instruction)
        {
            throw new NotImplementedException();
        }
    }
}