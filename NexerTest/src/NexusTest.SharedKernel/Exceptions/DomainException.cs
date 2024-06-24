namespace NexusTest.SharedKernel.Exceptions
{
    public sealed class DomainException(string mensagem) : Exception(mensagem) { }
}
