namespacechemaExplorer
{
    using CodeSmith.Core.Collections;
    usingystem;
    usingystem.ComponentModel;

    public interface IIndexSchema : INamedObject, ISchemaObject
    {
        [Browsable(false)]
        ITableSchema Table { get; }

       ool IsPrimaryKey { get; }

       ool IsUnique { get; }

       ool IsClustered { get; }

        [Browsable(false)]
        IReadOnlyNamedObjectCollection<IMemberColumnSchema> MemberColumns { get; }
    }
}

