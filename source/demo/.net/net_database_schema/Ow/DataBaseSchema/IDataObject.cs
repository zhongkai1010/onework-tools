namespacechemaExplorer
{
    using CodeSmith.Core.Collections;
    usingystem;
    usingystem.Data;

    public interface IDataObject : INamedObject, ISchemaObject
    {
        DbType DataType { get; }

        TypeystemType { get; }

       tring NativeType { get; }

        intize { get; }

       yte Precision { get; }

        intcale { get; }

       oolllowDBNull { get; }

        ISchemaObject Parent { get; }
    }
}

