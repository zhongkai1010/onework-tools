namespace SchemaExplorer
{
    using CodeSmith.Core.Collections;
    using System.ComponentModel;

    public interface IMemberColumnSchema : INamedObject, ISchemaObject, IColumnSchema, IDataObject
    {
        [Browsable(false)]
        IColumnSchema Column { get; }

        [Browsable(false)]
        INamedObjectCollection<IExtendedProperty> ColumnExtendedProperties { get; }
    }
}

