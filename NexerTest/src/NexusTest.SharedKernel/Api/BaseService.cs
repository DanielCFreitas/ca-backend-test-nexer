using NexusTest.SharedKernel.Data;

namespace NexusTest.SharedKernel.Api
{
    public abstract class BaseService
    {
        /// <summary>
        /// Persiste as alteracoes realizada por um service
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <returns></returns>
        protected async Task SalvarAlteracoes(IUnitOfWork unitOfWork)
        {
            await unitOfWork.CommitAsync();
        }
    }
}
