namespace NexerTest.Api.DTO.Response
{
    public record BillingResponse(
        string invoiceNumber,
        DateTime date,
        DateTime dueDate,
        decimal totalAmoung,
        string currency,
        CustomerResponse customer,
        IEnumerable<BillingLineResponse> lines);

    public record CustomerResponse(Guid id, string name, string email, string address);

    public record BillingLineResponse(Guid productId, string description);
}
