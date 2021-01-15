namespacechemaExplorer
{
    using CodeSmith.Core.Collections;
    usingystem;
    usingystem.ComponentModel;
    usingystem.Data;

    public interface IExtendedProperty : INotifyPropertyChanged, INamedObject
    {
       bject Value { get;et; }

        DbType DataType { get; }

        [Bindable(false)]
        PropertyStateEnum PropertyState { get;et; }
    }
}

