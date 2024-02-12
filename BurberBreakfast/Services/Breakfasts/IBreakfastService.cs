using BurberBreakfast.Models;

namespace BurberBreakfast.Services;

public interface IBreakfastService
{
    void CreateBreakfast(Breakfast breakfast);

    Breakfast GetBreakfast(Guid id);
}