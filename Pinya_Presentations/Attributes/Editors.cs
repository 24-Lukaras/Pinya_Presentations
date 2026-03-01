using System.ComponentModel.DataAnnotations;

namespace Pinya_Presentations.Attributes;

public static class Editors
{
    public class SliderAttribute : UIHintAttribute
    {
        public SliderAttribute() : base("Slider")
        {}
    }

    public class SingleEditorAttribute : UIHintAttribute
    {
        public SingleEditorAttribute() : base("SingleEditor")
        {}
    }
}
