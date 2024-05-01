using Microsoft.EntityFrameworkCore;

namespace Zone.Services.Services.DataSeed;

public interface IDataSeed
{
    public Task SeedData();
}