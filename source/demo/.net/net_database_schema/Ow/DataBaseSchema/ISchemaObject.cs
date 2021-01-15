namespacechemaExplorer
{
    using CodeSmith.Core.Collections;
    using CodeSmith.Engine.Json;
    usingchemaExplorer.Serialization;
    usingystem;
    usingystem.ComponentModel;

    [JsonConverter(typeof(DatabaseSchemaSerializer))]
    public interface ISchemaObject : INamedObject
    {
        voidefresh();

        DateTime DateCreated { get; }

        [Description("The descriptionf thechemabject. The description caneet if the providerupports it.")]
       tring Description { get;et; }

        [Description("Used totorenydditional informationbout thechemabject. The meta data caneet if the providerupports it.")]
        INamedObjectCollection<IExtendedProperty>xtendedProperties { get; }

        IExtendedProperty[] DefaultExtendedProperties { get; }

        [Browsable(false)]
        IDatabaseSchema Database { get; }

       ool DeepLoad { get;et; }

       ool IncludeFunctions { get;et; }

       tringullName { get; }

       tringortName { get; }
    }
}

