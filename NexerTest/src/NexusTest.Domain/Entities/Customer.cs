using NexerTest.SharedKernel.Data;
using NexerTest.SharedKernel.Validations;

namespace NexerTest.Domain.Entities
{
    /// <summary>
    /// Class that represents a Customer
    /// </summary>
    public class Customer : BaseEntity
    {
        public Customer(Guid id, string name, string email, string address) : base(id)
        {
            Name = name;
            Email = email;
            Address = address;

            ValidateEntity();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }

        /// <summary>
        /// Change the Customer Name
        /// </summary>
        /// <param name="name">Customer Name</param>
        public void ChangeName(string name)
        {
            Validations.FieldIsNullOrEmpty(name, "The Name field cannot be empty or null");
            Name = name;
        }

        /// <summary>
        /// Change the Customer Email
        /// </summary>
        /// <param name="email">Customer Email</param>
        public void ChangeEmail(string email)
        {
            Validations.FieldIsNullOrEmpty(email, "The Email field cannot be empty or null");
            Email = email;
        }

        /// <summary>
        /// Change the Customer Address
        /// </summary>
        /// <param name="address">Customer Address</param>
        public void ChangeAddress(string address)
        {
            Validations.FieldIsNullOrEmpty(address, "The Address field cannot be empty or null");
            Address = address;
        }


        public override void ValidateEntity()
        {
            Validations.FieldIsEmpty(Id, "The Id field cannot be empty");
            Validations.FieldIsNullOrEmpty(Name, "The Name field cannot be empty or null");
            Validations.FieldIsNullOrEmpty(Address, "The Address field cannot be empty or null");
            Validations.FieldIsNullOrEmpty(Email, "The Email field cannot be empty or null");
        }
    }
}
