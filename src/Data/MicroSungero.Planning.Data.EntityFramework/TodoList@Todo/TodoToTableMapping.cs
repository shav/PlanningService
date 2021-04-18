using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicroSungero.Kernel.Data;
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

    protected override EntityTypeTableModel BuildEntityModel(EntityTypeBuilder<Todo> builder)
    {
      var model = base.BuildEntityModel(builder);

      var Title = builder.Property(t => t.Title)
        .HasMaxLength(TodoBaseValidator.MAX_TITLE_LENGTH)
        .IsRequired();

      var Description = builder.Property(t => t.Description)
        .HasMaxLength(TodoBaseValidator.MAX_DESCRIPTION_LENGTH);

      var Note = builder.Property(t => t.Note)
        .HasMaxLength(TodoBaseValidator.MAX_NOTE_LENGTH);

      var CreatedDate = builder.Property(t => t.CreatedDate).IsRequired();

      var Deadline = builder.Property(t => t.Deadline);

      var CompletedDate = builder.Property(t => t.CompletedDate);

      var IsCompleted = builder.Property(t => t.IsCompleted).IsRequired();

      var PerformerId = builder.Property(t => t.PerformerId);

      var Priority = builder.Property(t => t.Priority)
        .HasConversion(new EnumerationValueConverter<Priority>());

      //builder.OwnsOne(t => (EntityTag)t.Tag, b =>
      //{
      //  b.Property(t => t.Name).IsRequired();
      //  b.Property(t => t.Color).HasConversion(new EnumerationValueConverter<Color>()).IsRequired();
      //});
      builder.Ignore(t => t.Tag);

      var TodoListId = builder.Property(t => t.TodoListId)
        .IsRequired();

      builder
        .HasOne(p => (TodoList)p.TodoList)
        .WithMany(b => (IEnumerable<Todo>)b.TodoItems)
        .HasForeignKey(p => p.TodoListId);

      model.Properties.Add(Title);
      model.Properties.Add(Description);
      model.Properties.Add(Note);
      model.Properties.Add(PerformerId);
      model.Properties.Add(Priority);
      model.Properties.Add(CompletedDate);
      model.Properties.Add(CreatedDate);
      model.Properties.Add(Deadline);
      model.Properties.Add(IsCompleted);
      model.Properties.Add(TodoListId);
      return model;
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Create object-relational mapping for todo item.
    /// </summary>
    /// <param name="connectionSettings">Database connection settings.</param>
    public TodoToTableMapping(IDatabaseConnectionSettings connectionSettings)
      : base(connectionSettings)
    {
    }

    #endregion
  }
}
