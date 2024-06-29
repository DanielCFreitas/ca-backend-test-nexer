using NexerTest.SharedKernel.Data;
using NexerTest.SharedKernel.Validations;

namespace NexerTest.Domain.Entities
{
    /// <summary>
    /// Class that represents a Customer
    /// </summary>
    public class Customer : BaseEntity
    {
        private IList<Billing> _billings;

        public Customer(Guid id, string name, string email, string address) : base(id)
        {
            Name = name;
            Email = email;
            Address = address;
            _billings = new List<Billing>();

            ValidateEntity();
        }

        public Customer()
        {
            _billings = new List<Billing>();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public IReadOnlyCollection<Billing> Billings => _billings.ToArray();

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

        /// <summary>
        /// Add Billings
        /// </summary>
        public void AddBilling(Billing billing)
        {
            ArgumentNullException.ThrowIfNull(billing);

            _billings.Add(billing);
            billing.SetCustomerId(Id);
        }


        public override void ValidateEntity()
        {
            Validations.FieldIsEmpty(Id, "The Id field cannot be empty");
            Validations.FieldIsNullOrEmpty(Name, "The Name field cannot be empty or null");
            Validations.FieldMustBeLessThan(Name.Length, 101, "The field must have a maximum of 100 characters");
            Validations.FieldIsNullOrEmpty(Address, "The Address field cannot be empty or null");
            Validations.FieldMustBeLessThan(Name.Length, 101, "The field must have a maximum of 100 characters");
            Validations.FieldIsNullOrEmpty(Email, "The Email field cannot be empty or null");
            Validations.FieldMustBeLessThan(Name.Length, 101, "The field must have a maximum of 100 characters");
        }
    }
}
