using System.ComponentModel;
using System.ComponentModel.Design;

namespace CustomControlsLibrary
{
    public class RadiobuttonGroupActionList : DesignerActionList
    {
        private RadioButtonGroup component;
        private DesignerActionUIService designerActionUIService = null;

        public RadiobuttonGroupActionList(IComponent comp) : base(comp)
        {
            component = comp as RadioButtonGroup;
            designerActionUIService = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }

        private PropertyDescriptor GetPropertyByName(string propName)
        {
            PropertyDescriptor prop;
            prop = TypeDescriptor.GetProperties(component)[propName];

            if (prop == null) throw new InvalidEnumArgumentException($"Property not found {propName}");
            else return prop;
        }

        public string Title
        {
            get => component.Title;
            set => GetPropertyByName(nameof(Title)).SetValue(component, value);
        }

        //public override DesignerActionItemCollection GetSortedActionItems()
        //{
        //    DesignerActionItemCollection items = new DesignerActionItemCollection()
        //    {
        //        new DesignerActionHeaderItem("Appearance"),
        //        new DesignerActionPropertyItem(nameof(Title), "Radiogroup Title", "Appearance", "Text at the top of the group"),
        //    };

        //    return items;
        //}
    }
}
