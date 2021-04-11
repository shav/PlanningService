using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicroSungero.Planning.Domain.Entities;
using MicroSungero.Kernel.Data.EntityFramework;
using System.Collections.Generic;

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
        .HasMaxLength(100)
        .IsRequired();

      builder.Property(t => t.Description)
        .HasMaxLength(250);

      builder.Property(t => t.CreatedDate)
       .IsRequired();

      builder.Property(t => t.Deadline);

      builder.Property(t => t.CompletedDate);

      builder.Property(t => t.IsCompleted)
        .IsRequired();

      builder.Property(t => t.PerformerId);

      builder.Property(t => t.Priority);

      builder.OwnsOne(t => t.Tag);

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
