using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicroSungero.Kernel.Data;
using MicroSungero.Kernel.Data.EntityFramework;
using MicroSungero.Planning.Domain.Entities;
using MicroSungero.System.Domain;

namespace MicroSungero.Planning.Data.EntityFramework
{
  /// <summary>
  /// Object-relational mapping for user todo tag to database table.
  /// </summary>
  public class TodoTagTableMapping : ChildEntityTypeTableMapping<TodoTag>
  {
    #region ChildEntityTypeTableMapping

    protected override string ModuleName => Planning.Module.Name;

    protected override EntityTypeTableModel BuildEntityModel(EntityTypeBuilder<TodoTag> builder)
    {
      var model = base.BuildEntityModel(builder);

      builder.OwnsOne(t => (EntityTag)t.Tag, b =>
      {
        var TagName = b.Property(t => t.Name).IsRequired();
        var TagColor = b.Property(t => t.Color).HasConversion(new EnumerationValueConverter<Color>()).IsRequired();

        model.Properties.Add(TagName);
        model.Properties.Add(TagColor);
      });

      var TodoId = builder.Property(t => t.TodoId)
        .IsRequired();

      builder
        .HasOne(t => (Todo)t.Todo)
        .WithMany(t => (IEnumerable<TodoTag>)t.Tags)
        .HasForeignKey(t => t.TodoId);

      model.Properties.Add(TodoId);
      return model;
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Create object-relational mapping for user todo tag.
    /// </summary>
    /// <param name="connectionSettings">Database connection settings.</param>
    public TodoTagTableMapping(IDatabaseConnectionSettings connectionSettings)
      : base(connectionSettings)
    {
    }

    #endregion
  }
}
