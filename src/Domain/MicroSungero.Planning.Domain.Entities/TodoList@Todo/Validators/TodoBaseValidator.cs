using System;
using FluentValidation;

namespace MicroSungero.Planning.Domain.Entities.Validators
{
  /// <summary>
  /// Base validator for Todo item.
  /// </summary>
  public abstract class TodoBaseValidator
  {
    #region Constants

    /// <summary>
    /// Max length of Todo title.
    /// </summary>
    public const int MAX_TITLE_LENGTH = 100;

    /// <summary>
    /// Max length of Todo description.
    /// </summary>
    public const int MAX_DESCRIPTION_LENGTH = 250;

    #endregion
  }

  /// <summary>
  /// Base validator for Todo item property.
  /// </summary>
  /// <typeparam name="T">Type of Todo-like object for validation.</typeparam>
  /// <typeparam name="TProperty">Type of Todo-like object property for validation.</typeparam>
  public class TodoBaseValidator<T, TProperty>: TodoBaseValidator
  {
    #region Properties and fields

    /// <summary>
    /// Validation rules for property.
    /// </summary>
    public IRuleBuilder<T, TProperty> Rule { get; private set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Create base validator for Todo item property.
    /// </summary>
    /// <param name="rule">Validation rules for property.</param>
    public TodoBaseValidator(IRuleBuilder<T, TProperty> rule)
    {
      this.Rule = rule;
    }

    #endregion
  }

  /// <summary>
  /// Common validation rules for Todo item.
  /// </summary>
  public static class TodoBaseValidatorExtensions
  {
    /// <summary>
    /// Add validation rule for length of Todo title.
    /// </summary>
    /// <typeparam name="T">Type of Todo-like object for validation.</typeparam>
    /// <param name="validator">Validator for Todo item string property.</param>
    public static TodoBaseValidator<T, string> Validate_TitleLength<T>(this TodoBaseValidator<T, string> validator)
    {
      validator.Rule
        .NotEmpty().WithMessage($"{nameof(Todo.Title)} of {nameof(Todo)} is required.")
        .MaximumLength(TodoBaseValidator.MAX_TITLE_LENGTH).WithMessage($"{nameof(Todo.Title)} of {nameof(Todo)} should not exceed {TodoBaseValidator.MAX_TITLE_LENGTH} characters.");

      return validator;
    }

    /// <summary>
    /// Add validation rule for length of Todo description.
    /// </summary>
    /// <typeparam name="T">Type of Todo-like object for validation.</typeparam>
    /// <param name="validator">Validator for Todo item string property.</param>
    public static TodoBaseValidator<T, string> Validate_DescriptionLength<T>(this TodoBaseValidator<T, string> validator)
    {
      validator.Rule
        .MaximumLength(TodoBaseValidator.MAX_DESCRIPTION_LENGTH).WithMessage($"{nameof(Todo.Description)} of {nameof(Todo)} should not exceed {TodoBaseValidator.MAX_DESCRIPTION_LENGTH} characters.");

      return validator;
    }

    /// <summary>
    /// Add validation rule that Todo deadline is after creation date.
    /// </summary>
    /// <typeparam name="T">Type of Todo-like object for validation.</typeparam>
    /// <param name="validator">Validator for Todo item datetime property.</param>
    /// <param name="createdDate">Getter for Todo creation date.</param>
    public static TodoBaseValidator<T, DateTime?> Validate_DeadlineAfterCreation<T>(this TodoBaseValidator<T, DateTime?> validator, Func<T, DateTime?> createdDate)
    {
      validator.Rule
        .GreaterThan(t => createdDate(t)).WithMessage($"Deadline of {nameof(Todo)} should be after creation date.");

      return validator;
    }

    /// <summary>
    /// Add validation rule that Todo completion date is after creation date.
    /// </summary>
    /// <typeparam name="T">Type of Todo-like object for validation.</typeparam>
    /// <param name="validator">Validator for Todo item datetime property.</param>
    /// <param name="createdDate">Getter for Todo creation date.</param>
    public static TodoBaseValidator<T, DateTime?> Validate_CompletionAfterCreation<T>(this TodoBaseValidator<T, DateTime?> validator, Func<T, DateTime?> createdDate)
    {
      validator.Rule
        .GreaterThan(t => createdDate(t)).WithMessage($"Completion date of {nameof(Todo)} should be after creation date.");

      return validator;
    }
  }
}
