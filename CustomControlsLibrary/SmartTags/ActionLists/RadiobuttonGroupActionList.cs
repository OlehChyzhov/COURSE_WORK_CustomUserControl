using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace CustomControlsLibrary
{
    // DOES NOT WORK IN WPF

    public class RadiobuttonGroupActionList : DesignerActionList
    {
        private RadioButtonGroup radiobuttonGroup;
        private DesignerActionUIService designerActionSvc = null;

        public RadiobuttonGroupActionList(IComponent comp) : base(comp)
        {
            radiobuttonGroup = (RadioButtonGroup)comp;
            designerActionSvc = (DesignerActionUIService)GetService(typeof(DesignerActionUIService));
        }

        private PropertyDescriptor GetPropertyByName(string propName)
        {
            PropertyDescriptor prop = default(PropertyDescriptor);
            prop = TypeDescriptor.GetProperties(radiobuttonGroup)[propName];
            if (prop == null)
            {
                throw new ArgumentException("Invalid Property", propName);
            }
            else
            {
                return prop;
            }
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection()
            {
                new DesignerActionHeaderItem("Appearance"),
                new DesignerActionPropertyItem(nameof(Title), "Title", "Appearance"),
            };
            return items;
        }

        public string Title
        {
            get 
            {
                return radiobuttonGroup.Title; 
            }
            set 
            {
                GetPropertyByName(nameof(Title)).SetValue(radiobuttonGroup, value);
            }
        }
    }
}
