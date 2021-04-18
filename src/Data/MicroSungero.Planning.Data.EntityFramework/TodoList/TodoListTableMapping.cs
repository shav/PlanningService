using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicroSungero.Planning.Domain.Entities;
using MicroSungero.Kernel.Data.EntityFramework;
using MicroSungero.Planning.Domain.Entities.Validators;
using MicroSungero.Kernel.Data;

namespace MicroSungero.Planning.Data.EntityFramework
{
  /// <summary>
  /// Object-relational mapping for TodoList entity to database table.
  /// </summary>
  public class TodoListTableMapping : EntityTypeTableMapping<TodoList>
  {
    #region EntityTypeTableMapping

    protected override string ModuleName => Planning.Module.Name;

    protected override EntityTypeTableModel BuildEntityModel(EntityTypeBuilder<TodoList> builder)
    {
      var model = base.BuildEntityModel(builder);

      var Title = builder.Property(t => t.Title)
        .HasMaxLength(TodoListBaseValidator.MAX_TITLE_LENGTH)
        .IsRequired();

      var Description = builder.Property(t => t.Description)
        .HasMaxLength(TodoListBaseValidator.MAX_DESCRIPTION_LENGTH);

      var AuthorId = builder.Property(t => t.AuthorId)
        .IsRequired();

      var CompletedDate = builder.Property(t => t.CompletedDate);

      var CreatedDate = builder.Property(t => t.CreatedDate)
        .IsRequired();

      var Deadline = builder.Property(t => t.Deadline);

      var IsCompleted = builder.Property(t => t.IsCompleted)
        .IsRequired();

      model.Properties.Add(Title);
      model.Properties.Add(Description);
      model.Properties.Add(AuthorId);
      model.Properties.Add(CompletedDate);
      model.Properties.Add(CreatedDate);
      model.Properties.Add(Deadline);
      model.Properties.Add(IsCompleted);
      return model;
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Create object-relational mapping for TodoList.
    /// </summary>
    /// <param name="connectionSettings">Database connection settings.</param>
    public TodoListTableMapping(IDatabaseConnectionSettings connectionSettings)
      : base(connectionSettings)
    {
    }

    #endregion
  }
}
