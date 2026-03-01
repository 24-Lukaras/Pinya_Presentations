using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Pinya_Presentations.Attributes;

public static class Editors
{
    public class SliderAttribute : UIHintAttribute
    {
        public int Min { get; set; } = 0;
        public int Max { get; set; } = 100;
        public SliderAttribute() : base("Slider")
        {}
    }

    public abstract class SingleEditorAttribute : UIHintAttribute
    {
        public SingleEditorAttribute() : base("SingleEditor")
        {}

        public abstract Task<IEnumerable<SelectListItem>> GetListItemsAsync(HttpContext ctx);
    }

    public class EnumDropdownAttribute<T> : SingleEditorAttribute where T : Enum
    {
        private IEnumerable<SelectListItem> _items;
        public EnumDropdownAttribute() : base()
        {
            var type = typeof(T);
            var values = Enum.GetValues(typeof(T));
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var value in values)
            {
                list.Add(new SelectListItem()
                {
                    Text = type.GetField(value.ToString() ?? "")?
                        .GetCustomAttributes(false)
                        .OfType<DisplayAttribute>()
                        .FirstOrDefault()?.Name ?? Enum.GetName(type, value),
                    Value = ((int)value).ToString()
                });
            }
            _items = list;
        }

        public override Task<IEnumerable<SelectListItem>> GetListItemsAsync(HttpContext ctx) =>
            Task.FromResult(_items);
    }
}
