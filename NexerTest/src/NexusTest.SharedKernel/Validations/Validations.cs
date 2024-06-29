using NexerTest.SharedKernel.Validations.CommomExceptions;

namespace NexerTest.SharedKernel.Validations
{
    /// <summary>
    /// Class responsible for performing system validations
    /// </summary>
    public static class Validations
    {
        /// <summary>
        /// Method to validate whether the field is empty or null
        /// </summary>
        /// <param name="field">Field to be tested</param>
        /// <param name="messageException">Error message</param>
        /// <exception cref="FieldIsNullOrEmptyException"></exception>
        public static void FieldIsNullOrEmpty(string field, string messageException)
        {
            if (string.IsNullOrEmpty(field))
                throw new FieldIsNullOrEmptyException(messageException);
        }

        /// <summary>
        /// Method to validate whether the field is empty or null
        /// </summary>
        /// <param name="field">Field to be tested</param>
        /// <param name="messageException">Error message</param>
        /// <exception cref="FieldIsNullOrEmptyException"></exception>
        public static void FieldIsNullOrEmpty(DateTime field, string messageException)
        {
            if (field == DateTime.MinValue)
                throw new FieldIsNullOrEmptyException(messageException);
        }


        /// <summary>
        /// Method to validate if the field is empty
        /// </summary>
        /// <param name="field">Field to be tested</param>
        /// <param name="messageException">Error message</param>
        /// <exception cref="FieldIsEmptyException"></exception>
        public static void FieldIsEmpty(Guid field, string messageException)
        {
            if (Guid.Empty == field)
                throw new FieldIsEmptyException(messageException);
        }

        /// <summary>
        /// Performs validation by comparing whether the value is less than the comparator
        /// </summary>
        /// <param name="field">Field to be tested</param>
        /// <param name="comparator">Reference value</param>
        /// <param name="messageException">Error message</param>
        /// <exception cref="FieldMustBeGratherThanException"></exception>
        public static void FieldMustBeGratherThan(int field, int comparator, string messageException)
        {
            if (field <= comparator)
                throw new FieldMustBeGratherThanException(messageException);
        }

        /// <summary>
        /// Performs validation by comparing whether the value is less than the comparator
        /// </summary>
        /// <param name="field">Field to be tested</param>
        /// <param name="comparator">Reference value</param>
        /// <param name="messageException">Error message</param>
        /// <exception cref="FieldMustBeGratherThanException"></exception>
        public static void FieldMustBeGratherThan(decimal field, decimal comparator, string messageException)
        {
            if (field <= comparator)
                throw new FieldMustBeGratherThanException(messageException);
        }

        /// <summary>
        /// Validates whether the date is before the date being compared
        /// </summary>
        /// <param name="field">Field to be tested</param>
        /// <param name="comparator">Reference value</param>
        /// <param name="messageException">Error message</param>
        /// <exception cref="FieldMustBeGratherThanException"></exception>
        public static void FieldMustBeLessThan(DateTime field, DateTime comparator, string messageException)
        {
            if (field > comparator)
                throw new FieldMustBeGratherThanException(messageException);
        }

        /// <summary>
        /// Validates whether the date is before the date being compared
        /// </summary>
        /// <param name="field">Field to be tested</param>
        /// <param name="comparator">Reference value</param>
        /// <param name="messageException">Error message</param>
        /// <exception cref="FieldMustBeGratherThanException"></exception>
        public static void FieldMustBeLessThan(int field, int comparator, string messageException)
        {
            if (field > comparator)
                throw new FieldMustBeGratherThanException(messageException);
        }
    }
}
