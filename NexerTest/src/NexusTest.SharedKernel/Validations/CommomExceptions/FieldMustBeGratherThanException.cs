namespace NexerTest.SharedKernel.Validations.CommomExceptions
{
    /// <summary>
    /// Exception field is greather than a value
    /// </summary>
    /// <param name="message"></param>
    internal class FieldMustBeGratherThanException(string message) : Exception(message) { }
}
