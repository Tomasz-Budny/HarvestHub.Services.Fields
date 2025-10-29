namespace HarvestHub.Services.Fields.Application.RPC
{
    public interface ICultivationHistoryClient
    {
        Task CreateCulticationHistory(Guid fieldId);
    }
}
