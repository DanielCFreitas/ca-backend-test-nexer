namespace NexerTest.SharedKernel.Validations.CommomExceptions
{
    /// <summary>
    /// Exception for empty field
    /// </summary>
    /// <param name="message"></param>
    internal class FieldIsEmptyException(string message) : Exception(message) { }
}
