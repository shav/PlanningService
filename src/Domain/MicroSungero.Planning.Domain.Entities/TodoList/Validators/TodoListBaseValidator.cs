using System;
using System.Linq;
using FluentValidation;
using MicroSungero.Kernel.Data;

namespace MicroSungero.Planning.Domain.Entities.Validators
{
  /// <summary>
  /// Common validation rules for TodoList.
  /// </summary>
  public static class TodoListBaseValidator
  {
    #region Constants

    /// <summary>
    /// Max length of TodoList title.
    /// </summary>
    public const int MAX_TITLE_LENGTH = 100;

    /// <summary>
    /// Max length of TodoList description.
    /// </summary>
    public const int MAX_DESCRIPTION_LENGTH = 250;

    #endregion

    #region Methods

    /// <summary>
    /// Add validation rule for length of TodoList title.
    /// </summary>
    /// <typeparam name="T">Type of TodoList-like object for validation.</typeparam>
    /// <param name="rule">Validation rules collection.</param>
    public static IRuleBuilderOptions<T, string> Validate_TitleLength<T>(this IRuleBuilder<T, string> rule)
    {
      return rule
        .NotEmpty().WithMessage($"{nameof(ITodoList.Title)} of todo is required.")
        .MaximumLength(MAX_TITLE_LENGTH).WithMessage($"{nameof(ITodoList.Title)} of todo should not exceed {MAX_TITLE_LENGTH} characters.");
    }

    /// <summary>
    /// Add validation rule for TodoList title uniqueness.
    /// </summary>
    /// <typeparam name="T">Type of TodoList-like object for validation.</typeparam>
    /// <param name="rule">Validation rules collection.</param>
    /// <param name="todoListId">Getter for TodoList Id.</param>
    /// <param name="repository">TodoList repository.</param>
    public static IRuleBuilderOptions<T, string> Validate_TitleUnique<T>(this IRuleBuilder<T, string> rule, Func<T, int> todoListId, IEntityRepository<ITodoList> repository)
    {
      return rule
        .Must((t, title) => BeUniqueTitle<T>(title, todoListId(t), repository)).WithMessage($"The todo with specified {nameof(ITodoList.Title)} already exists.");
    }

    /// <summary>
    /// Add validation rule for length of TodoList description.
    /// </summary>
    /// <typeparam name="T">Type of TodoList-like object for validation.</typeparam>
    /// <param name="rule">Validation rules collection.</param>
    public static IRuleBuilderOptions<T, string> Validate_DescriptionLength<T>(this IRuleBuilder<T, string> rule)
    {
      return rule
        .MaximumLength(MAX_DESCRIPTION_LENGTH).WithMessage($"{nameof(ITodoList.Description)} of todo should not exceed {MAX_DESCRIPTION_LENGTH} characters.");
    }

    /// <summary>
    /// Add validation rule that TodoList deadline is after creation date.
    /// </summary>
    /// <typeparam name="T">Type of TodoList-like object for validation.</typeparam>
    /// <param name="rule">Validation rules collection.</param>
    /// <param name="createdDate">Getter for TodoList creation date.</param>
    public static IRuleBuilderOptions<T, DateTime?> Validate_DeadlineAfterCreation<T>(this IRuleBuilder<T, DateTime?> rule, Func<T, DateTime?> createdDate)
    {
      return rule
        .GreaterThan(t => createdDate(t)).WithMessage("Deadline of todo should be after creation date.");
    }

    /// <summary>
    /// Add validation rule that TodoList completion date is after creation date.
    /// </summary>
    /// <typeparam name="T">Type of TodoList-like object for validation.</typeparam>
    /// <param name="rule">Validation rules collection.</param>
    /// <param name="createdDate">Getter for TodoList creation date.</param>
    public static IRuleBuilderOptions<T, DateTime?> Validate_CompletionAfterCreation<T>(this IRuleBuilder<T, DateTime?> rule, Func<T, DateTime?> createdDate)
    {
      return rule
        .GreaterThan(t => createdDate(t)).WithMessage("Completion date of todo should be after creation date.");
    }

    /// <summary>
    /// Check if title of TodoList is unique.
    /// </summary>
    /// <typeparam name="T">Type of TodoList-like object for validation.</typeparam>
    /// <param name="title">TodoList title.</param>
    /// <param name="todoListId">TodoList Id.</param>
    /// <param name="repository">TodoList repository.</param>
    /// <returns>True if title of TodoList is unique, else False.</returns>
    private static bool BeUniqueTitle<T>(string title, int todoListId, IEntityRepository<ITodoList> repository)
    {
      return !repository.GetAll().Any(todo => todo.Title == title && todo.Id != todoListId);
    }

    #endregion
  }
}
