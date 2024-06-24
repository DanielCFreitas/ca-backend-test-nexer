namespace NexusTest.SharedKernel.Data
{
    /// <summary>
    /// Classe abstrata que representa uma entidade dentro do sistema
    /// </summary>
    public abstract class BaseEntity
    {
        protected BaseEntity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }

        /// <summary>
        /// Método para realizar validacoes necessarias na entidade
        /// </summary>
        public abstract void ValidarEntidade();
    }
}
