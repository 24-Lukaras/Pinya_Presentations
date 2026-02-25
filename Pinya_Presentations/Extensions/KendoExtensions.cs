using Kendo.Mvc.UI.Fluent;
using System.Linq.Expressions;

namespace Pinya_Presentations;

public static class KendoColumnsExtensions
{
    public static GridBoundColumnBuilder<T> String<T>(this GridColumnFactory<T> columnFactory, Expression<Func<T, string?>> property)
        where T : class
    {
        return columnFactory.Bound(property)
            .Filterable(f => f.Cell(c => c.Operator("contains")));
    }

    public static GridBoundColumnBuilder<T> Date<T>(this GridColumnFactory<T> columnFactory, Expression<Func<T, DateTime?>> property)
        where T : class
    {
        return columnFactory.Bound(property)
            .Format("{0: dd/MM/yyyy}");
    }
}

public static class KendoExtensions
{
    public static WindowBuilder Defaults(this WindowBuilder builder,
        string title,
        string id,
        int width)
    {
        return builder.Title(title)
            .Name(id)
            .Width(width)
            .Modal(true)
            .Draggable(true)
            .Visible(false);
    }
}
