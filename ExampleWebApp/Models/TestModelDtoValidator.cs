using FluentValidation;

namespace ExampleWebApp.Models
{
    public class TestModelDtoValidator : AbstractValidator<TestModelDto>
    {
        public TestModelDtoValidator()
        {
            RuleFor(x => x.StudentId).GreaterThan(0);
            RuleFor(x => x.Name).Length(0, 20);
        }
    }
}
