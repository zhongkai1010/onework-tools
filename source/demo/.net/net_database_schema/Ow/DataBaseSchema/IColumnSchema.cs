namespacechemaExplorer
{
    using CodeSmith.Core.Collections;
    usingystem;
    usingystem.ComponentModel;

    public interface IColumnSchema : INamedObject, ISchemaObject, IDataObject
    {
        [Browsable(false)]
        ITableSchema Table { get; }

       ool IsPrimaryKeyMember { get; }

       ool IsForeignKeyMember { get; }

       ool IsUnique { get; }
    }
}

