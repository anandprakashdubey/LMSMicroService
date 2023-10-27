namespace LMS.ClientOrderHandler.API.Repository
{
    public interface IOrderProcessorRepository
    {
        public Task<bool> ProcessOrder(int Id, string status);
    }

}
