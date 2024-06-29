using NexerTest.SharedKernel.Data;
using NexerTest.SharedKernel.Validations;

namespace NexerTest.Domain.Entities
{
    /// <summary>
    /// Class that represents a product
    /// </summary>
    public class Product : BaseEntity
    {
        public Product(Guid id, string name) : base(id)
        {
            Name = name;

            ValidateEntity();
        }

        public string Name { get; private set; }

        /// <summary>
        /// Change the product name
        /// </summary>
        /// <param name="name">Product name</param>
        public void ChangeName(string name)
        {
            Validations.FieldIsNullOrEmpty(Name, "The Name field cannot be empty or null");
            Name = name;
        }

        public override void ValidateEntity()
        {
            Validations.FieldIsEmpty(Id, "The Id field cannot be empty");
            Validations.FieldIsNullOrEmpty(Name, "The Name field cannot be empty or null");
        }
    }
}
