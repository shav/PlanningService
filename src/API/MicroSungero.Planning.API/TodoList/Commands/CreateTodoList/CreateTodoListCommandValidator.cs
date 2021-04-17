using System;
using System.Linq.Expressions;
using MicroSungero.Kernel.API.Validation;
using MicroSungero.Kernel.Domain.Validation;
using MicroSungero.Planning.Domain.Entities.Validators;

namespace MicroSungero.Planning.API.Commands
{
  /// <summary>
  /// Input validator for CreateTodoList command.
  /// </summary>
  public class CreateTodoListCommandValidator : BaseErrorValidator<CreateTodoListCommand>, ICommandValidator<CreateTodoListCommand>
  {
    /// <summary>
    /// Create input validator with rules for CreateTodoList command.
    /// </summary>
    public CreateTodoListCommandValidator()
    {
      RuleFor(t => t.Title)
        .Validate_TitleLength();

      RuleFor(t => t.Description)
        .Validate_DescriptionLength();
    }

    /// <summary>
    /// Get validator for command property.
    /// </summary>
    /// <typeparam name="TProperty">Typeof property.</typeparam>
    /// <param name="property">Property name.</param>
    /// <returns>Validator for property.</returns>
    private new TodoListBaseValidator<CreateTodoListCommand, TProperty> RuleFor<TProperty>(Expression<Func<CreateTodoListCommand, TProperty>> property)
    {
      return new TodoListBaseValidator<CreateTodoListCommand, TProperty>(base.RuleFor(property));
    }
  }
}
