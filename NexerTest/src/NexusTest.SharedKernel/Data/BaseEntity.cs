namespace NexerTest.SharedKernel.Data
{
    /// <summary>
    /// Abstract class that represents an entity within the system
    /// </summary>
    public abstract class BaseEntity
    {
        protected BaseEntity(Guid? id = null)
        {
            if (id is null)
                Id = Guid.NewGuid();
            else
                Id = (Guid)id;
        }

        public Guid Id { get; private set; }

        /// <summary>
        /// Method to perform necessary validations on the entity
        /// </summary>
        public abstract void ValidateEntity();
    }
}
