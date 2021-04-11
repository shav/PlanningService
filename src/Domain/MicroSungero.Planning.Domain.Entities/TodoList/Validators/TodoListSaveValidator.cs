using System;
using System.Linq.Expressions;
using MicroSungero.Kernel.Data;
using MicroSungero.Kernel.Domain.Entities;
using MicroSungero.Kernel.Domain.Validation;

namespace MicroSungero.Planning.Domain.Entities.Validators
{
  /// <summary>
  /// Validator that validates TodoList before saving it.
  /// </summary>
  public class TodoListSaveValidator : BaseErrorValidator<ITodoList>, ISaveEntityValidator<ITodoList>
  {
    /// <summary>
    /// TodoList repository.
    /// </summary>
    private readonly IEntityRepository<ITodoList> repository;

    /// <summary>
    /// Create TodoList saving validator.
    /// </summary>
    /// <param name="repository">TodoList repository.</param>
    public TodoListSaveValidator(IEntityRepository<ITodoList> repository)
    {
      this.repository = repository;

      RuleFor(t => t.Title)
        .Validate_TitleLength()
        .Validate_TitleUnique(t => t.Id, this.repository);

      RuleFor(t => t.Description)
        .Validate_DescriptionLength();

      RuleFor(t => t.Deadline)
        .Validate_DeadlineAfterCreation(t => t.CreatedDate);

      RuleFor(t => t.CompletedDate)
        .Validate_CompletionAfterCreation(t => t.CreatedDate);
    }

    /// <summary>
    /// Get validator for TodoList property.
    /// </summary>
    /// <typeparam name="TProperty">Typeof property.</typeparam>
    /// <param name="property">Property name.</param>
    /// <returns>Validator for property.</returns>
    public new TodoListBaseValidator<ITodoList, TProperty> RuleFor<TProperty>(Expression<Func<ITodoList, TProperty>> property)
    {
      return new TodoListBaseValidator<ITodoList, TProperty>(base.RuleFor(property));
    }
  }
}
