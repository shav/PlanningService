using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicroSungero.Kernel.Data.EntityFramework;
using MicroSungero.Planning.Domain;
using MicroSungero.Planning.Domain.Entities;
using MicroSungero.Planning.Domain.Entities.Validators;
using MicroSungero.System.Domain;

namespace MicroSungero.Planning.Data.EntityFramework
{
  /// <summary>
  /// Object-relational mapping for Todo item to database table.
  /// </summary>
  public class TodoToTableMapping : ChildEntityTypeToTableMapping<Todo>
  {
    #region ChildEntityTypeToTableMapping

    protected override string ModuleName => Planning.Module.Name;

    public override void Configure(EntityTypeBuilder<Todo> builder)
    {
      base.Configure(builder);

      builder.Property(t => t.Title)
        .HasMaxLength(TodoBaseValidator.MAX_TITLE_LENGTH)
        .IsRequired();

      builder.Property(t => t.Description)
        .HasMaxLength(TodoBaseValidator.MAX_DESCRIPTION_LENGTH);

      builder.Property(t => t.CreatedDate)
       .IsRequired();

      builder.Property(t => t.Deadline);

      builder.Property(t => t.CompletedDate);

      builder.Property(t => t.IsCompleted)
        .IsRequired();

      builder.Property(t => t.PerformerId);

      builder.Property(t => t.Priority)
        .HasConversion(new EnumerationValueConverter<Priority>());

      //builder.OwnsOne(t => (EntityTag)t.Tag, b =>
      //{
      //  b.Property(t => t.Name).IsRequired();
      //  b.Property(t => t.Color).HasConversion(new EnumerationValueConverter<Color>()).IsRequired();
      //});
      builder.Ignore(t => t.Tag);

      builder.Property(t => t.TodoListId)
        .IsRequired();

      builder
        .HasOne(p => (TodoList)p.TodoList)
        .WithMany(b => (IEnumerable<Todo>)b.TodoItems)
        .HasForeignKey(p => p.TodoListId);
    }

    #endregion
  }
}
