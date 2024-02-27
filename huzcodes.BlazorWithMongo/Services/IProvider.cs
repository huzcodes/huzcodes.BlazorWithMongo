using huzcodes.BlazorWithMongo.Models;

namespace huzcodes.BlazorWithMongo.Services
{
    public interface IProvider
    {
        ValueTask Create(int counterNumber);
    }
}
