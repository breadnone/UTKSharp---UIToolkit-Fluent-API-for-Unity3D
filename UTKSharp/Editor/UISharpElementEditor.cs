/* MIT License
Copyright (c) 2023 UTKSharp

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;


// UTKSharp support for custom editor.
namespace UITKsharp.Editor
{
    public static class UTKEditor
    {
        public static UISharpFloatField addFloatField(FloatField custom = null)
        {
            return new UISharpFloatField(custom);
        }
        public static UISharpIntegerField addIntegerField(IntegerField custom = null)
        {
            return new UISharpIntegerField(custom);
        }
        public static UISharpDoubleField addIntegerField(DoubleField custom = null)
        {
            return new UISharpDoubleField(custom);
        }
        public static UISharpVector2Field addVector2Field(Vector2Field custom = null)
        {
            return new UISharpVector2Field(custom);
        }
        public static UISharpVector3Field addVector3Field(Vector3Field custom = null)
        {
            return new UISharpVector3Field(custom);
        }
        public static UISharpVector4Field addVector4Field(Vector4Field custom = null)
        {
            return new UISharpVector4Field(custom);
        }
        public static UISharpEnumField addEnumField(EnumField custom = null)
        {
            return new UISharpEnumField(custom);
        }
        public static UISharpEnumFlagsField addVector2Field(EnumFlagsField custom = null)
        {
            return new UISharpEnumFlagsField(custom);
        }
        public static UISharpBoundsField addBoundsField(BoundsField custom = null)
        {
            return new UISharpBoundsField(custom);
        }
        public static UISharpBoundsIntField addBoundsIntField(BoundsIntField custom = null)
        {
            return new UISharpBoundsIntField(custom);
        }
        public static UISharpColorField addColorField(ColorField custom = null)
        {
            return new UISharpColorField(custom);
        }
        public static UISharpGradientField addGradientField(GradientField custom = null, string text = "")
        {
            return new UISharpGradientField(custom, text);
        }
        public static UISharpCurveField addCurveField(CurveField custom)
        {
            return new UISharpCurveField(custom);
        }
        public static UISharpLongField addLongField(LongField custom = null)
        {
            return new UISharpLongField(custom);
        }
        public static UISharpObjectField addObjecField(ObjectField custom = null)
        {
            return new UISharpObjectField(custom);
        }
        public static UISharpPropertyField addPropertyField(PropertyField custom = null)
        {
            return new UISharpPropertyField(custom);
        }
        public static UISharpRectField addRectField(RectField custom = null)
        {
            return new UISharpRectField(custom);
        }
        public static UISharpRectIntField addRectIntField(RectIntField custom = null)
        {
            return new UISharpRectIntField(custom);
        }
        public static UISharpToolbar addToolbar(ToolbarMenu[] menus)
        {
            return new UISharpToolbar(menus);
        }
        public static UISharpToolbarButton addToolbarButton(ToolbarButton custom)
        {
            return new UISharpToolbarButton(custom);
        }
        public static UISharpVector2IntField addVector2IntField(Vector2IntField custom = null)
        {
            return new UISharpVector2IntField(custom);
        }
        public static UISharpVector3IntField addVector3IntField(Vector3IntField custom = null)
        {
            return new UISharpVector3IntField(custom);
        }
    }

    public class UISharpToolbar : UISharp
    {
        private Toolbar toolBar;

        public UISharpToolbar(ToolbarMenu[] toolbarMenus = null) : base(null)
        {
            toolBar = new Toolbar();

            if(toolbarMenus != null && toolbarMenus.Length > 0)
            {
                foreach(var item in toolbarMenus)
                {
                    if(item == null)
                        continue;
                    
                    toolBar.Add(item);
                }
            }
        }

        public UISharpToolbar Menu(ToolbarMenu[] toolbarMenus)
        {
            if(toolbarMenus == null || toolbarMenus.Length == 0)
                throw new Exception("ToolbarMenus can't be empty or null!");

            for(int i = 0; i < toolbarMenus.Length; i++)
            {
                if(toolbarMenus[i] == null)
                    continue;
                
                toolBar.Add(toolbarMenus[i]);
            }

            return this;
        }
    }
    public class UISharpFloatField : UISharp
    {
        private FloatField floatField;

        public UISharpFloatField(FloatField customFloatField = null) : base(null)
        {
            if(customFloatField == null)
                floatField = new FloatField();
            else
                floatField = customFloatField;

            base.visualElement = floatField;
        }
        public UISharpFloatField Value(float value)
        {
            floatField.value = value;
            return this;
        }
        public FloatField ReturnAsFloatField()
        {
            return floatField;
        }
        public UISharpFloatField SetValueChanged(Action<float> callback)
        {
            floatField.RegisterValueChangedCallback((x)=> callback.Invoke(x.newValue));
            return this;
        }
    }
    public class UISharpIntegerField : UISharp
    {
        private IntegerField integerField;

        public UISharpIntegerField(IntegerField customIntegerField = null) : base(null)
        {
            if(customIntegerField == null)
                integerField = new IntegerField();
            else
                integerField = customIntegerField;

            base.visualElement = integerField;
        }
        public UISharpIntegerField Value(int value)
        {
            integerField.value = value;
            return this;
        }
        public IntegerField ReturnAsIntegerField()
        {
            return integerField;
        }
        public UISharpIntegerField SetValueChanged(Action<int> callback)
        {
            integerField.RegisterValueChangedCallback((x)=> callback.Invoke(x.newValue));
            return this;
        }
    }
    public class UISharpLongField : UISharp
    {
        private LongField integerField;

        public UISharpLongField(LongField customIntegerField = null) : base(null)
        {
            if(customIntegerField == null)
                integerField = new LongField();
            else
                integerField = customIntegerField;

            base.visualElement = integerField;
        }
        public UISharpLongField Value(int value)
        {
            integerField.value = value;
            return this;
        }
        public LongField ReturnAsLongField()
        {
            return integerField;
        }
        public UISharpLongField SetValueChanged(Action<long> callback)
        {
            integerField.RegisterValueChangedCallback((x)=> callback.Invoke(x.newValue));
            return this;
        }
    }
    public class UISharpDoubleField : UISharp
    {
        private DoubleField doubleField;

        public UISharpDoubleField(DoubleField customDoubleField = null) : base(null)
        {
            if(customDoubleField == null)
                doubleField = new DoubleField();
            else
                doubleField = customDoubleField;

            base.visualElement = doubleField;
        }
        public UISharpDoubleField Value(Double value)
        {
            doubleField.value = value;
            return this;
        }
        public DoubleField ReturnAsDoubleField()
        {
            return doubleField;
        }
        public UISharpDoubleField SetValueChanged(Action<double> callback)
        {
            doubleField.RegisterValueChangedCallback((x)=> callback.Invoke(x.newValue));
            return this;
        }
    }
    public class UISharpVector2Field : UISharp
    {
        private Vector2Field vector2Field;

        public UISharpVector2Field(Vector2Field customVector2Field = null) : base(null)
        {
            if(customVector2Field == null)
                vector2Field = new Vector2Field();
            else
                vector2Field = customVector2Field;

            base.visualElement = vector2Field;
        }
        public UISharpVector2Field Value(Vector2 value)
        {
            vector2Field.value = value;
            return this;
        }
        public Vector2Field ReturnAsVector2Field()
        {
            return vector2Field;
        }
        public UISharpVector2Field SetValueChanged(Action<Vector2> callback)
        {
            vector2Field.RegisterValueChangedCallback((x)=> callback.Invoke(x.newValue));
            return this;
        }
    }
    public class UISharpVector3Field : UISharp
    {
        private Vector3Field vector3Field;

        public UISharpVector3Field(Vector3Field customVector3Field = null) : base(null)
        {
            if(customVector3Field == null)
                vector3Field = new Vector3Field();
            else
                vector3Field = customVector3Field;

            base.visualElement = vector3Field;
        }
        public UISharpVector3Field Value(Vector3 value)
        {
            vector3Field.value = value;
            return this;
        }
        public Vector3Field ReturnAsVector3Field()
        {
            return vector3Field;
        }
        public UISharpVector3Field SetValueChanged(Action<Vector3> callback)
        {
            vector3Field.RegisterValueChangedCallback((x)=> callback.Invoke(x.newValue));
            return this;
        }
    }
    public class UISharpVector4Field : UISharp
    {
        private Vector4Field vector4Field;

        public UISharpVector4Field(Vector4Field customVector4Field = null) : base(null)
        {
            if(customVector4Field == null)
                vector4Field = new Vector4Field();
            else
                vector4Field = customVector4Field;

            base.visualElement = vector4Field;
        }
        public UISharpVector4Field Value(Vector4 value)
        {
            vector4Field.value = value;
            return this;
        }
        public Vector4Field ReturnAsVector4Field()
        {
            return vector4Field;
        }
        public UISharpVector4Field SetValueChanged(Action<Vector4> callback)
        {
            vector4Field.RegisterValueChangedCallback((x)=> callback.Invoke(x.newValue));
            return this;
        }
    }
    public class UISharpColorField : UISharp
    {
        private ColorField colorField;

        public UISharpColorField(ColorField customColorField = null) : base(null)
        {
            if(customColorField == null)
                colorField = new ColorField();
            else
                colorField = customColorField;

            base.visualElement = colorField;
        }
        public UISharpColorField Value(Color value)
        {
            colorField.value = value;
            return this;
        }
        public ColorField ReturnAsColorField()
        {
            return colorField;
        }
        public UISharpColorField SetValueChanged(Action<Color> callback)
        {
            colorField.RegisterValueChangedCallback((x)=> callback.Invoke(x.newValue));
            return this;
        }
    }
    public class UISharpEnumField : UISharp
    {
        private EnumField enumField;

        public UISharpEnumField(EnumField customEnumField = null) : base(null)
        {
            if(customEnumField == null)
                enumField = new EnumField();
            else
                enumField = customEnumField;

            base.visualElement = enumField;
        }
        public UISharpEnumField Init(Enum enumobject)
        {
            enumField.Init(enumobject);
            return this;
        }
        public UISharpEnumField Value(Enum value)
        {
            enumField.value = value;
            return this;
        }
        public EnumField ReturnAsEnumField()
        {
            return enumField;
        }
        public UISharpEnumField SetValueChanged(Action<Enum> callback)
        {
            enumField.RegisterValueChangedCallback((x)=> callback.Invoke(x.newValue));
            return this;
        }
    }
    public class UISharpObjectField : UISharp
    {
        private ObjectField objectField;

        public UISharpObjectField(ObjectField customObjectField = null) : base(null)
        {
            if(customObjectField == null)
                objectField = new ObjectField();
            else
                objectField = customObjectField;

            base.visualElement = objectField;
        }
        public UISharpObjectField Value(UnityEngine.Object value)
        {
            objectField.value = value;
            return this;
        }
        public UISharpObjectField SetObjectType(Type type)
        {
            objectField.objectType = type;
            return this;
        }
        public ObjectField ReturnAsObjectField()
        {
            return objectField;
        }
        public UISharpObjectField SetValueChanged(Action<UnityEngine.Object> callback)
        {
            objectField.RegisterValueChangedCallback((x)=> callback.Invoke(x.newValue));
            return this;
        }
    }
    public class UISharpGradientField : UISharp
    {
        private GradientField gradientField;

        public UISharpGradientField(GradientField customGradientField = null, string text = "") : base(null)
        {
            if(customGradientField == null)
                gradientField = new GradientField();
            else
                gradientField = customGradientField;

            gradientField.label = text;
            base.visualElement = gradientField;
        }
        public UISharpGradientField SetLabel(string value)
        {
            gradientField.label = value;
            return this;
        }
        public UISharpGradientField Value(Gradient value)
        {
            gradientField.value = value;
            return this;
        }
        public GradientField ReturnAsGradientField()
        {
            return gradientField;
        }
        public UISharpGradientField SetValueChanged(Action<Gradient> callback)
        {
            gradientField.RegisterValueChangedCallback((x)=> callback.Invoke(x.newValue));
            return this;
        }
    }
    public class UISharpRectField : UISharp
    {
        private RectField rectField;

        public UISharpRectField(RectField customRectField = null) : base(null)
        {
            if(customRectField == null)
                rectField = new RectField();
            else
                rectField = customRectField;

            base.visualElement = rectField;
        }
        public UISharpRectField Value(Rect value)
        {
            rectField.value = value;
            return this;
        }
        public RectField ReturnAsRectField()
        {
            return rectField;
        }
        public UISharpRectField SetValueChanged(Action<Rect> callback)
        {
            rectField.RegisterValueChangedCallback((x)=> callback.Invoke(x.newValue));
            return this;
        }
    }
    public class UISharpRectIntField : UISharp
    {
        private RectIntField rectIntField;

        public UISharpRectIntField(RectIntField customRectIntField = null) : base(null)
        {
            if(customRectIntField == null)
                rectIntField = new RectIntField();
            else
                rectIntField = customRectIntField;

            base.visualElement = rectIntField;
        }
        public UISharpRectIntField Value(RectInt value)
        {
            rectIntField.value = value;
            return this;
        }
        public RectIntField ReturnAsRectIntField()
        {
            return rectIntField;
        }
        public UISharpRectIntField SetValueChanged(Action<RectInt> callback)
        {
            rectIntField.RegisterValueChangedCallback((x)=> callback.Invoke(x.newValue));
            return this;
        }
    }
    public class UISharpCurveField : UISharp
    {
        private CurveField curveField;

        public UISharpCurveField(CurveField customCurveField = null) : base(null)
        {
            if(customCurveField == null)
                curveField = new CurveField();
            else
                curveField = customCurveField;

            base.visualElement = curveField;
        }
        public UISharpCurveField Value(AnimationCurve value)
        {
            curveField.value = value;
            return this;
        }
        public CurveField ReturnAsCurveField()
        {
            return curveField;
        }
        public UISharpCurveField SetValueChanged(Action<AnimationCurve> callback)
        {
            curveField.RegisterValueChangedCallback((x)=> callback.Invoke(x.newValue));
            return this;
        }
    }
    public class UISharpPropertyField : UISharp
    {
        private PropertyField propertyField;

        public UISharpPropertyField(PropertyField customPropertyField = null) : base(null)
        {
            if(customPropertyField == null)
                propertyField = new PropertyField();
            else
                propertyField = customPropertyField;

            base.visualElement = propertyField;
        }
        public UISharpPropertyField SetLabel(string value)
        {
            propertyField.label = value;
            return this;
        }
        public UISharpPropertyField SetPropertyBinding(IBinding value)
        {
            propertyField.binding = value;
            return this;
        }
        public UISharpPropertyField SetPropertyBindingPath(string value)
        {
            propertyField.bindingPath = value;
            return this;
        }
        public PropertyField ReturnAsPropertyField()
        {
            return propertyField;
        }
        public UISharpPropertyField SetValueChanged(Action<SerializedPropertyChangeEvent> callback)
        {
            propertyField.RegisterValueChangeCallback(x => callback.Invoke(x));
            return this;
        }
    }
    public class UISharpBoundsField : UISharp
    {
        private BoundsField boundsField;

        public UISharpBoundsField(BoundsField customBoundsField = null) : base(null)
        {
            if(customBoundsField == null)
                boundsField = new BoundsField();
            else
                boundsField = customBoundsField;

            base.visualElement = boundsField;
        }
        public UISharpBoundsField SetLabel(string value)
        {
            boundsField.label = value;
            return this;
        }
        public UISharpBoundsField Value(Bounds value)
        {
            boundsField.value = value;
            return this;
        }
        public BoundsField ReturnAsBoundsField()
        {
            return boundsField;
        }
        public UISharpBoundsField SetValueChanged(Action<Bounds> callback)
        {
            boundsField.RegisterValueChangedCallback((x)=> callback.Invoke(x.newValue));
            return this;
        }
    }
    public class UISharpBoundsIntField : UISharp
    {
        private BoundsIntField boundsField;

        public UISharpBoundsIntField(BoundsIntField customBoundsField = null) : base(null)
        {
            if(customBoundsField == null)
                boundsField = new BoundsIntField();
            else
                boundsField = customBoundsField;

            base.visualElement = boundsField;
        }
        public UISharpBoundsIntField SetLabel(string value)
        {
            boundsField.label = value;
            return this;
        }
        public UISharpBoundsIntField Value(BoundsInt value)
        {
            boundsField.value = value;
            return this;
        }
        public BoundsIntField ReturnAsBoundsIntField()
        {
            return boundsField;
        }
        public UISharpBoundsIntField SetValueChanged(Action<BoundsInt> callback)
        {
            boundsField.RegisterValueChangedCallback((x)=> callback.Invoke(x.newValue));
            return this;
        }
    }
    public class UISharpEnumFlagsField : UISharp
    {
        private EnumFlagsField enumField;

        public UISharpEnumFlagsField(EnumFlagsField customEnumField = null) : base(null)
        {
            if(customEnumField == null)
                enumField = new EnumFlagsField();
            else
                enumField = customEnumField;

            base.visualElement = enumField;
        }
        public UISharpEnumFlagsField Choices(List<string> choices)
        {
            enumField.choices = choices;
            return this;
        }
        public UISharpEnumFlagsField ChoicesMask(List<int> choices)
        {
            enumField.choicesMasks = choices;
            return this;
        }
        public UISharpEnumFlagsField Init(Enum enumobject)
        {
            enumField.Init(enumobject);
            return this;
        }
        public UISharpEnumFlagsField Value(Enum value)
        {
            enumField.value = value;
            return this;
        }
        public EnumFlagsField ReturnAsEnumFlagsField()
        {
            return enumField;
        }
        public UISharpEnumFlagsField SetValueChanged(Action<Enum> callback)
        {
            enumField.RegisterValueChangedCallback((x)=> callback.Invoke(x.newValue));
            return this;
        }
    }
    public class UISharpToolbarButton : UISharp
    {
        private ToolbarButton toolbarButton;

        public UISharpToolbarButton(ToolbarButton customToolbarButton = null) : base(null)
        {
            if(customToolbarButton == null)
                toolbarButton = new ToolbarButton();
            else
                toolbarButton = customToolbarButton;

            base.visualElement = toolbarButton;
        }
        public UISharpToolbarButton Clicked(Action eventCallback)
        {
            toolbarButton.clicked += ()=>
            {
                eventCallback.Invoke();
            };
            return this;
        }

        public ToolbarButton ReturnAsToolbarButton()
        {
            return toolbarButton;
        }
        public UISharpToolbarButton SetValueChanged(Action<string> callback)
        {
            toolbarButton.RegisterValueChangedCallback((x)=> callback.Invoke(x.newValue));
            return this;
        }
    }
    public class UISharpVector2IntField : UISharp
    {
        private Vector2IntField vectorField;

        public UISharpVector2IntField(Vector2IntField customVectorField = null) : base(null)
        {
            if(customVectorField == null)
                vectorField = new Vector2IntField();
            else
                vectorField = customVectorField;

            base.visualElement = vectorField;
        }
        public UISharpVector2IntField Value(Vector2Int value)
        {
            vectorField.value = value;
            return this;
        }
        public Vector2IntField ReturnAsVector4Field()
        {
            return vectorField;
        }
        public UISharpVector2IntField SetValueChanged(Action<Vector2Int> callback)
        {
            vectorField.RegisterValueChangedCallback((x)=> callback.Invoke(x.newValue));
            return this;
        }
    }
    public class UISharpVector3IntField : UISharp
    {
        private Vector3IntField vectorField;

        public UISharpVector3IntField(Vector3IntField customVectorField = null) : base(null)
        {
            if(customVectorField == null)
                vectorField = new Vector3IntField();
            else
                vectorField = customVectorField;

            base.visualElement = vectorField;
        }
        public UISharpVector3IntField Value(Vector3Int value)
        {
            vectorField.value = value;
            return this;
        }
        public Vector3IntField ReturnAsVector3IntField()
        {
            return vectorField;
        }
        public UISharpVector3IntField SetValueChanged(Action<Vector3Int> callback)
        {
            vectorField.RegisterValueChangedCallback((x)=> callback.Invoke(x.newValue));
            return this;
        }
    }
}