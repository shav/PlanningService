using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicroSungero.Planning.Domain.Entities;
using MicroSungero.Kernel.Data.EntityFramework;
using MicroSungero.Planning.Domain.Entities.Validators;

namespace MicroSungero.Planning.Data.EntityFramework
{
  /// <summary>
  /// Object-relational mapping for TodoList entity to database table.
  /// </summary>
  public class TodoListToTableMapping : EntityTypeToTableMapping<TodoList>
  {
    #region EntityTypeToTableMapping

    protected override string ModuleName => Planning.Module.Name;

    public override void Configure(EntityTypeBuilder<TodoList> builder)
    {
      base.Configure(builder);

      builder.Property(t => t.Title)
        .HasMaxLength(TodoListBaseValidator.MAX_TITLE_LENGTH)
        .IsRequired();

      builder.Property(t => t.Description)
        .HasMaxLength(TodoListBaseValidator.MAX_DESCRIPTION_LENGTH);

      builder.Property(t => t.AuthorId)
        .IsRequired();

      builder.Property(t => t.CompletedDate);

      builder.Property(t => t.CreatedDate)
        .IsRequired();

      builder.Property(t => t.Deadline);

      builder.Property(t => t.IsCompleted)
        .IsRequired();
    }

    #endregion
  }
}
