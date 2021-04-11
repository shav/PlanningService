using System;
using System.Linq;
using FluentValidation;
using MicroSungero.Kernel.Data;

namespace MicroSungero.Planning.Domain.Entities.Validators
{
  /// <summary>
  /// Base validator for TodoList.
  /// </summary>
  public abstract class TodoListBaseValidator
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
  }

  /// <summary>
  /// Base validator for TodoList property.
  /// </summary>
  /// <typeparam name="T">Type of TodoList-like object for validation.</typeparam>
  /// <typeparam name="TProperty">Type of TodoList-like object property for validation.</typeparam>
  public class TodoListBaseValidator<T, TProperty> : TodoListBaseValidator
  {
    #region Properties and fields

    /// <summary>
    /// Validation rules for property.
    /// </summary>
    public IRuleBuilder<T, TProperty> Rule { get; private set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Create base validator for TodoList property.
    /// </summary>
    /// <param name="rule">Validation rules for property.</param>
    public TodoListBaseValidator(IRuleBuilder<T, TProperty> rule)
    {
      this.Rule = rule;
    }

    #endregion
  }

  /// <summary>
  /// Common validation rules for TodoList.
  /// </summary>
  public static class TodoListBaseValidatorExtensions
  {
    /// <summary>
    /// Add validation rule for length of TodoList title.
    /// </summary>
    /// <typeparam name="T">Type of TodoList-like object for validation.</typeparam>
    /// <param name="validator">Validator for TodoList string property.</param>
    public static TodoListBaseValidator<T, string> Validate_TitleLength<T>(this TodoListBaseValidator<T, string> validator)
    {
      validator.Rule
        .NotEmpty().WithMessage($"{nameof(TodoList.Title)} of {nameof(TodoList)} is required.")
        .MaximumLength(TodoListBaseValidator.MAX_TITLE_LENGTH).WithMessage($"{nameof(TodoList.Title)} of {nameof(TodoList)} should not exceed {TodoListBaseValidator.MAX_TITLE_LENGTH} characters.");

      return validator;
    }

    /// <summary>
    /// Add validation rule for TodoList title uniqueness.
    /// </summary>
    /// <typeparam name="T">Type of TodoList-like object for validation.</typeparam>
    /// <param name="validator">Validator for TodoList string property.</param>
    /// <param name="todoListId">Getter for TodoList Id.</param>
    /// <param name="repository">TodoList repository.</param>
    public static TodoListBaseValidator<T, string> Validate_TitleUnique<T>(this TodoListBaseValidator<T, string> validator, Func<T, int> todoListId, IEntityRepository<ITodoList> repository)
    {
      validator.Rule
        .Must((t, title) => BeUniqueTitle<T>(title, todoListId(t), repository)).WithMessage($"The {nameof(TodoList)} with specified {nameof(TodoList.Title)} already exists.");

      return validator;
    }

    /// <summary>
    /// Add validation rule for length of TodoList description.
    /// </summary>
    /// <typeparam name="T">Type of TodoList-like object for validation.</typeparam>
    /// <param name="validator">Validator for TodoList string property.</param>
    public static TodoListBaseValidator<T, string> Validate_DescriptionLength<T>(this TodoListBaseValidator<T, string> validator)
    {
      validator.Rule
        .MaximumLength(TodoListBaseValidator.MAX_DESCRIPTION_LENGTH).WithMessage($"{nameof(TodoList.Description)} of {nameof(TodoList)} should not exceed {TodoListBaseValidator.MAX_DESCRIPTION_LENGTH} characters.");

      return validator;
    }

    /// <summary>
    /// Add validation rule that TodoList deadline is after creation date.
    /// </summary>
    /// <typeparam name="T">Type of TodoList-like object for validation.</typeparam>
    /// <param name="validator">Validator for TodoList datetime property.</param>
    /// <param name="createdDate">Getter for TodoList creation date.</param>
    public static TodoListBaseValidator<T, DateTime?> Validate_DeadlineAfterCreation<T>(this TodoListBaseValidator<T, DateTime?> validator, Func<T, DateTime?> createdDate)
    {
      validator.Rule
        .GreaterThan(t => createdDate(t)).WithMessage($"Deadline of {nameof(TodoList)} should be after creation date.");

      return validator;
    }

    /// <summary>
    /// Add validation rule that TodoList completion date is after creation date.
    /// </summary>
    /// <typeparam name="T">Type of TodoList-like object for validation.</typeparam>
    /// <param name="validator">Validator for TodoList datetime property.</param>
    /// <param name="createdDate">Getter for TodoList creation date.</param>
    public static TodoListBaseValidator<T, DateTime?> Validate_CompletionAfterCreation<T>(this TodoListBaseValidator<T, DateTime?> validator, Func<T, DateTime?> createdDate)
    {
      validator.Rule
        .GreaterThan(t => createdDate(t)).WithMessage($"Completion date of {nameof(TodoList)} should be after creation date.");

      return validator;
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
  }
}
