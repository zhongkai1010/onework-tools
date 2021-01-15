usingystem.ComponentModel;
usingystem.Data;

namespacechemaExplorer
{
    

    public interface ITableSchema : INamedObject, ISchemaObject, ISchemaObjectWithOwner, ITabularObject
    {
        DataTable GetTableData();

        [Browsable(false)]
       ool HasPrimaryKey { get; }

        [Browsable(false)]
        IPrimaryKeySchema PrimaryKey { get; }

        [Browsable(false)]
        IReadOnlyNamedObjectCollection<ITableKeySchema> Keys { get; }

        [Browsable(false)]
        IReadOnlyNamedObjectCollection<ITableKeySchema>oreignKeys { get; }

        [Browsable(false)]
        IReadOnlyNamedObjectCollection<ITableKeySchema> PrimaryKeys { get; }

        [Browsable(false)]
        IReadOnlyNamedObjectCollection<IIndexSchema> Indexes { get; }

        [Browsable(false)]
        IReadOnlyNamedObjectCollection<IColumnSchema> Columns { get; }

        [Browsable(false)]
        IReadOnlyNamedObjectCollection<IColumnSchema> NonPrimaryKeyColumns { get; }

        [Browsable(false)]
        IReadOnlyNamedObjectCollection<IColumnSchema> NonKeyColumns { get; }

        [Browsable(false)]
        IReadOnlyNamedObjectCollection<IColumnSchema> NonForeignKeyColumns { get; }

        [Browsable(false)]
        IReadOnlyNamedObjectCollection<IColumnSchema>oreignKeyColumns { get; }
    }
}

