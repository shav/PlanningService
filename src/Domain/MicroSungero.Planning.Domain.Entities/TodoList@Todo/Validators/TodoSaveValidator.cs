using System;
using System.Linq.Expressions;
using MicroSungero.Kernel.Domain.Entities;
using MicroSungero.Kernel.Domain.Validation;

namespace MicroSungero.Planning.Domain.Entities.Validators
{
  /// <summary>
  /// Validator that validates Todo before saving it.
  /// </summary>
  public class TodoSaveValidator : BaseErrorValidator<ITodo>, ISaveEntityValidator<ITodo>
  {
    /// <summary>
    /// Create Todo saving validator.
    /// </summary>
    public TodoSaveValidator()
    {
      RuleFor(t => t.Title)
        .Validate_TitleLength();

      RuleFor(t => t.Description)
        .Validate_DescriptionLength();

      RuleFor(t => t.Deadline)
        .Validate_DeadlineAfterCreation(t => t.CreatedDate);

      RuleFor(t => t.CompletedDate)
        .Validate_CompletionAfterCreation(t => t.CreatedDate);
    }

    /// <summary>
    /// Get validator for Todo item property.
    /// </summary>
    /// <typeparam name="TProperty">Typeof property.</typeparam>
    /// <param name="property">Property name.</param>
    /// <returns>Validator for property.</returns>
    private new TodoBaseValidator<ITodo, TProperty> RuleFor<TProperty>(Expression<Func<ITodo, TProperty>> property)
    {
      return new TodoBaseValidator<ITodo, TProperty>(base.RuleFor(property));
    }
  }
}
