namespace NexerTest.SharedKernel.Validations.CommomExceptions
{
    /// <summary>
    /// Exception field is less than a value
    /// </summary>
    /// <param name="message"></param>
    internal class FieldMustBeLessThan(string message) : Exception(message) { }
}
