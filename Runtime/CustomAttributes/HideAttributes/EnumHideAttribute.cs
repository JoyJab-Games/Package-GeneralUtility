using System;

namespace JescoDev.Utility.CustomAttributes.HideAttributes {

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct)]
    public class EnumHideAttribute : HideAttribute {

        /// <summary> The Value the enum field will be checked against </summary>
        public int[] ComparedEnumValue;

        public EnumHideAttribute(string conditionalSourceField, params int[] comparedEnumValue)
            : base(conditionalSourceField) {
            
            ComparedEnumValue = comparedEnumValue;
        }

        public EnumHideAttribute(string conditionalSourceField, bool invert, params int[] comparedEnumValue) 
            : base(conditionalSourceField, true, invert) {
            ComparedEnumValue = comparedEnumValue;
        }
        
        public EnumHideAttribute(string conditionalSourceField, bool hideInInspector, bool invert, params int[] comparedEnumValue) 
            : base(conditionalSourceField, hideInInspector, invert) {
            
            ComparedEnumValue = comparedEnumValue;
        }
    }

}