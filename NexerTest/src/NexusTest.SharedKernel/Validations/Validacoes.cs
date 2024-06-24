using NexusTest.SharedKernel.Exceptions;

namespace NexusTest.SharedKernel.Validations
{
    /// <summary>
    /// Classe responsável por fazer as validacoes do sistema
    /// </summary>
    public static class Validacoes
    {
        /// <summary>
        /// Metodo para validar se o campo esta vazio ou nulo
        /// </summary>
        /// <param name="campo">Campo que sera testado</param>
        /// <param name="mensagem">Mensagem de erro para o desenvolvedor</param>
        /// <exception cref="DomainException">Estoura uma exception de dominio</exception>
        public static void CampoEstaVazioOuNulo(string campo, string mensagem)
        {
            if (string.IsNullOrEmpty(campo))
                throw new DomainException(mensagem);
        }
    }
}
