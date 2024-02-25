using ErrorOr;

namespace BurberBreakfast.ServiceErrors;

public static class Errors 
{
    public static class Breakfast
    {
        public static Error InValidName => Error.Validation(
            code:"Breakfast.InValidName",
            description: $"Breakfast name must be at least {Models.Breakfast.MinNameLength} characters long and at most {Models.Breakfast.MaxNameLength} characters long."
        );

        public static Error InValidDescription => Error.Validation(
            code: "Breakfast.InValidDescription",
            description: $
        )
        public static Error NotFound => Error.NotFound(
            code: "Breakfast.NotFound",
            description: $"Breakfast description must be at least {Models.Breakfast.MinDescriptionLength} characters long and at most {Models.Breakfast.MaxDescriptionLength} characters long."
        );
    }
}