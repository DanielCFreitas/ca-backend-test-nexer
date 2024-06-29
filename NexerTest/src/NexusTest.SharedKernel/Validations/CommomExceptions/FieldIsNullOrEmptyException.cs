namespace NexerTest.SharedKernel.Validations.CommomExceptions
{
    /// <summary>
    /// Exception for when a field is null or empty
    /// </summary>
    /// <param name="message">Message</param>
    internal class FieldIsNullOrEmptyException(string message) : Exception(message) { }
}
