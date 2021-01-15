namespacechemaExplorer
{
    using CodeSmith.Core.Collections;
    usingystem.ComponentModel;

    public interface ITableKeySchema : INamedObject, ISchemaObject
    {
        [Browsable(false)]
        ITableSchemaoreignKeyTable { get; }

        [Browsable(false)]
        IReadOnlyNamedObjectCollection<IMemberColumnSchema>oreignKeyMemberColumns { get; }

        [Browsable(false)]
        ITableSchema PrimaryKeyTable { get; }

        [Browsable(false)]
        IReadOnlyNamedObjectCollection<IMemberColumnSchema> PrimaryKeyMemberColumns { get; }

        [Browsable(false)]
        IPrimaryKeySchema PrimaryKey { get; }
    }
}

