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
using UnityEngine.UIElements;
using System;

#if UNITY_EDITOR
using UnityEditor.UIElements;
#endif

namespace UITKsharp
{
    public class UISharpDropDownField : UISharp
    {
        public DropdownField dropDownField { get; set; }

        public UISharpDropDownField(DropdownField dropdownField, List<string> list, int selectedDefault = 0) : base(dropdownField)
        {
            if (list == null || list.Count == 0)
                throw new Exception("UISharp : IList can't be null or empty");

            if (selectedDefault > list.Count - 1)
                throw new Exception("UISharp : Selected default out of range! Make sure it's not bigger than the list's count");

            dropDownField = dropdownField;
            dropDownField.choices = list;
            dropDownField.value = list[selectedDefault];
        }

        public UISharpDropDownField MarkDirtyRepaint()
        {
            dropDownField.MarkDirtyRepaint();
            return this;
        }
        public UISharpDropDownField RegisterValueChanged(Action<string> callback)
        {
            dropDownField.RegisterValueChangedCallback(x =>
            {
                callback.Invoke(x.newValue);
            });
            return this;
        }
    }
    public class UISharpLabel : UISharp
    {
        public Label label { get; set; }

        public UISharpLabel(Label labelElement, string labelText = "") : base(labelElement)
        {
            if (labelElement == null)
                throw new Exception("UISharp : Label element can't be null or empty");

            label = labelElement;
            label.text = labelText;
        }

        public UISharpLabel MarkDirtyRepaint()
        {
            label.MarkDirtyRepaint();
            return this;
        }
    }
    public class UISharpRadioGroup : UISharp
    {
        public RadioButtonGroup radioButtonGroup { get; set; }

        public UISharpRadioGroup(RadioButtonGroup radioGroupElement, List<string> choices, int defaultSelected = 0, string labelText = "") : base(radioGroupElement)
        {
            if (radioGroupElement == null || choices == null || choices.Count == 0)
                throw new Exception("UISharp : RadioButtonGroup element and choices can't be null or empty");

            radioButtonGroup = radioGroupElement;
            radioButtonGroup.labelElement.text = labelText;
            radioButtonGroup.choices = choices;
            radioButtonGroup.value = defaultSelected;
        }

        public UISharpRadioGroup MarkDirtyRepaint()
        {
            radioButtonGroup.MarkDirtyRepaint();
            return this;
        }
        public UISharpRadioGroup SetValueChangedEvent(Action<int> callback)
        {
            radioButtonGroup.RegisterValueChangedCallback(x =>
            {
                callback.Invoke(x.newValue);
            });
            return this;
        }
    }
    public class UISharpRadioButton : UISharp
    {
        public RadioButton radioButton { get; set; }

        public UISharpRadioButton(RadioButton radioElement, bool defaultValue, string labelText = "") : base(radioElement)
        {
            if (radioElement == null)
                throw new Exception("UISharp : RadioButton element can't be null or empty");

            radioButton = radioElement;
            radioButton.text = labelText;
            radioButton.value = defaultValue;
        }

        public UISharpRadioButton MarkDirtyRepaint()
        {
            radioButton.MarkDirtyRepaint();
            return this;
        }
        public UISharpRadioButton SetLabelBcgColor(StyleColor color)
        {
            radioButton.labelElement.style.backgroundColor = color;
            return this;
        }
        public UISharpRadioButton SetBinding(IBinding bindingObject)
        {
            radioButton.binding = bindingObject;
            return this;
        }
        public UISharpRadioButton SetBindingPath(string bindingpath)
        {
            radioButton.bindingPath = bindingpath;
            return this;
        }
        public UISharpRadioButton SetValueChangedEvent(Action<bool> callback)
        {
            radioButton.RegisterValueChangedCallback(x =>
            {
                callback.Invoke(x.newValue);
            });
            return this;
        }
        public RadioButton ReturnAsType()
        {
            return visualElement as RadioButton;
        }
    }
    public class UISharpPopUpWindow : UISharp
    {
        public PopupWindow popupWindow { get; set; }

        public UISharpPopUpWindow(PopupWindow popUpElement, string labelText = "") : base(popUpElement)
        {
            if (popUpElement == null)
                throw new Exception("UISharp : PopUpWindow element can't be null or empty");

            popupWindow = popUpElement;
            popupWindow.text = labelText;
        }

        public UISharpPopUpWindow MarkDirtyRepaint()
        {
            popupWindow.MarkDirtyRepaint();
            return this;
        }
        public UISharpPopUpWindow SetBinding(IBinding bindingObject)
        {
            popupWindow.binding = bindingObject;
            return this;
        }
        public UISharpPopUpWindow SetBindingPath(string bindingpath)
        {
            popupWindow.bindingPath = bindingpath;
            return this;
        }
        public PopupWindow ReturnAsType()
        {
            return visualElement as PopupWindow;
        }
    }
    public class UISharpTextField : UISharp
    {
        public TextField textField { get; set; }

        public UISharpTextField(TextField textFieldElement, string defaultValue = "", string labelField = "") : base(textFieldElement)
        {
            if (textFieldElement == null)
                throw new Exception("UISharp : TextField element can't be null or empty");

            textField = textFieldElement;
            textField.value = defaultValue;
            textField.labelElement.text = labelField;
        }

        public UISharpTextField MarkDirtyRepaint()
        {
            textField.MarkDirtyRepaint();
            return this;
        }
        public UISharpTextField SetValueChangedEvent(Action<string> callback)
        {
            textField.RegisterValueChangedCallback(x =>
            {
                callback.Invoke(x.newValue);
            });
            return this;
        }
        public UISharpTextField SetKeyPressEvent(Action<KeyDownEvent> callback)
        {
            textField.RegisterCallback<KeyDownEvent>(x =>
            {
                callback.Invoke(x);
            });
            return this;
        }
        public UISharpTextField SetMultiline(bool state)
        {
            textField.multiline = state;
            return this;
        }
        public UISharpTextField SetLabelFieldColor(StyleColor color)
        {
            textField.labelElement.style.backgroundColor = color;
            return this;
        }
        public UISharpTextField SetLabelFieldTextColor(StyleColor color)
        {
            textField.labelElement.style.color = color;
            return this;
        }
        public UISharpTextField SetMaskChar(char maskChar)
        {
            textField.maskChar = maskChar;
            return this;
        }
        public UISharpTextField SetDoubleClickSelect(bool state)
        {
            textField.doubleClickSelectsWord = state;
            return this;
        }
        public UISharpTextField SetMaxLength(int maxlength)
        {
            textField.maxLength = maxlength;
            return this;
        }
        public UISharpTextField SetTrippleClickSelect(bool state)
        {
            textField.tripleClickSelectsLine = state;
            return this;
        }
        public UISharpTextField SetBinding(IBinding bindingObject)
        {
            textField.binding = bindingObject;
            return this;
        }
        public UISharpTextField SetBindingPath(string bindingpath)
        {
            textField.bindingPath = bindingpath;
            return this;
        }
        public TextField ReturnAsType()
        {
            return visualElement as TextField;
        }
    }
    public class UISharpBox : UISharp
    {
        public Box box { get; set; }

        public UISharpBox(Box boxElement) : base(boxElement)
        {
            if (boxElement == null)
                throw new Exception("UISharp : Box element can't be null or empty");

            box = boxElement;
        }

        public UISharpBox MarkDirtyRepaint()
        {
            box.MarkDirtyRepaint();
            return this;
        }
        public Box ReturnAsType()
        {
            return visualElement as Box;
        }
    }
    public class UISharpMinMaxSlider : UISharp
    {
        public MinMaxSlider minMaxSlider { get; set; }

        public UISharpMinMaxSlider(MinMaxSlider minMaxElement, float lowLimit, float highLimit, float minValue, float maxValue, string textfield = "") : base(minMaxElement)
        {
            if (minMaxElement == null)
                throw new Exception("UISharp : MinMaxSlider element can't be null or empty");

            minMaxSlider = minMaxElement;
            minMaxSlider.lowLimit = lowLimit;
            minMaxSlider.highLimit = highLimit;
            minMaxSlider.minValue = minValue;
            minMaxSlider.maxValue = maxValue;
        }

        public UISharpMinMaxSlider MarkDirtyRepaint()
        {
            minMaxSlider.MarkDirtyRepaint();
            return this;
        }
        public UISharpMinMaxSlider SetDefaultValue(Vector2 value)
        {
            minMaxSlider.value = value;
            return this;
        }
        public UISharpMinMaxSlider SetTextField(string value)
        {
            minMaxSlider.labelElement.text = value;
            return this;
        }
        public UISharpMinMaxSlider SetLabelFieldColor(StyleColor color)
        {
            minMaxSlider.labelElement.style.backgroundColor = color;
            return this;
        }
        public UISharpMinMaxSlider SetLabelFieldTextColor(StyleColor color)
        {
            minMaxSlider.labelElement.style.color = color;
            return this;
        }
        public UISharpMinMaxSlider SetBinding(IBinding bindingObject)
        {
            minMaxSlider.binding = bindingObject;
            return this;
        }
        public UISharpMinMaxSlider SetBindingPath(string bindingpath)
        {
            minMaxSlider.bindingPath = bindingpath;
            return this;
        }
        public MinMaxSlider ReturnAsType()
        {
            return visualElement as MinMaxSlider;
        }
    }
    public class UISharpSlider : UISharp
    {
        public Slider slider { get; set; }

        public UISharpSlider(Slider sliderElement, float minValue, float maxValue, string textField = "", SliderDirection direction = SliderDirection.Horizontal) : base(sliderElement)
        {
            if (sliderElement == null)
                throw new Exception("UISharp : Slider element and min/max values can't be null or empty");

            slider = sliderElement;
            slider.direction = direction;
            slider.lowValue = minValue;
            slider.highValue = maxValue;

            if (!String.IsNullOrEmpty(textField))
            {
                slider.labelElement.text = textField;
            }
        }

        public UISharpSlider MarkDirtyRepaint()
        {
            slider.MarkDirtyRepaint();
            return this;
        }
        public UISharpSlider SetInverted(bool state)
        {
            slider.inverted = state;
            return this;
        }
        public UISharpSlider SetPageSize(float value)
        {
            slider.pageSize = value;
            return this;
        }
        public UISharpSlider ShowInputField(bool state)
        {
            slider.showInputField = state;
            return this;
        }
        public UISharpSlider ShowMixedValue(bool state)
        {
            slider.showMixedValue = state;
            return this;
        }
        public UISharpSlider SetBinding(IBinding bindingObject)
        {
            slider.binding = bindingObject;
            return this;
        }
        public UISharpSlider SetBindingPath(string bindingpath)
        {
            slider.bindingPath = bindingpath;
            return this;
        }
        public UISharpSlider SetValueChangedEvent(Action<float> callback)
        {
            slider.RegisterValueChangedCallback(x =>
            {
                callback.Invoke(x.newValue);
            });
            return this;
        }
        public Slider ReturnAsType()
        {
            return visualElement as Slider;
        }
    }
    public class UISharpToggle : UISharp
    {
        public Toggle toggle { get; set; }

        public UISharpToggle(Toggle toggleElement, bool defaultValue = false, string toggleText = "") : base(toggleElement)
        {
            if (toggleElement == null)
                throw new Exception("UISharp : Toggle element can't be null or empty");

            toggle = toggleElement;
            toggle.text = toggleText;
            toggle.value = defaultValue;
        }

        public UISharpToggle MarkDirtyRepaint()
        {
            toggle.MarkDirtyRepaint();
            return this;
        }
        public UISharpToggle SetStateChangedEvent(Action<bool> state)
        {
            toggle.RegisterValueChangedCallback(x =>
            {
                state.Invoke(x.newValue);
            });
            return this;
        }
        public UISharpToggle SetBinding(IBinding bindingObject)
        {
            toggle.binding = bindingObject;
            return this;
        }
        public UISharpToggle SetBindingPath(string bindingpath)
        {
            toggle.bindingPath = bindingpath;
            return this;
        }
        public Toggle ReturnAsType()
        {
            return visualElement as Toggle;
        }
    }
    public class UISharpButton : UISharp
    {
        public Button button { get; set; }

        public UISharpButton(Button buttonElement, string buttonText = "") : base(buttonElement)
        {
            if (buttonElement == null)
                throw new Exception("UISharp : Button element can't be null or empty");

            button = buttonElement;
            button.text = buttonText;
        }

        public UISharpButton MarkDirtyRepaint()
        {
            button.MarkDirtyRepaint();
            return this;
        }
        public UISharpButton SetClicked(Action callback)
        {
            button.clicked += () =>
            {
                callback.Invoke();
            };
            return this;
        }
        public Button ReturnAsType()
        {
            return visualElement as Button;
        }
    }
    public class UISharpImage : UISharp
    {
        public Image image { get; set; }

        public UISharpImage(Image imageElement) : base(imageElement)
        {
            if (imageElement == null)
                throw new Exception("UISharp : Image element can't be null or empty");

            image = imageElement;
        }

        public UISharpImage MarkDirtyRepaint()
        {
            image.MarkDirtyRepaint();
            return this;
        }
        public UISharpImage SetImage(Texture texture)
        {
            image.image = texture;
            return this;
        }
        public UISharpImage SetSprite(Sprite sprite)
        {
            image.sprite = sprite;
            return this;
        }
        public UISharpImage SetVectorImage(VectorImage vectorImage)
        {
            image.vectorImage = vectorImage;
            return this;
        }
        public UISharpImage SetUV(Rect uvRect)
        {
            image.uv = uvRect;
            return this;
        }
        public UISharpImage SetTintColor(Color color)
        {
            image.tintColor = color;
            return this;
        }
        public UISharpImage SetSourceRect(Rect sourceRect)
        {
            image.sourceRect = sourceRect;
            return this;
        }
        public UISharpImage SetScaleMode(ScaleMode scaleMode)
        {
            image.scaleMode = scaleMode;
            return this;
        }
        public Image ReturnAsType()
        {
            return visualElement as Image;
        }
    }
    public class UISharpScrollView : UISharp
    {
        public ScrollView scrollView { get; set; }

        public UISharpScrollView(ScrollView scrollview, VisualElement[] visualElements) : base(scrollview)
        {
            if (scrollview == null)
                throw new Exception("UISharp : ScrollView can't be null or empty");

            scrollView = scrollview;

            if (visualElements != null)
            {
                for (int i = 0; i < visualElements.Length; i++)
                {
                    if (visualElements[i] == null)
                        continue;

                    scrollView.Add(visualElements[i]);
                }
            }
        }

        public UISharpScrollView SetElasticity(float value)
        {
            scrollView.elasticity = value;
            return this;
        }
        public UISharpScrollView ScrollTo(VisualElement visualElement)
        {
            scrollView.ScrollTo(visualElement);
            return this;
        }
        public UISharpScrollView SetMode(ScrollViewMode mode)
        {
            scrollView.mode = mode;
            return this;
        }
        public UISharpScrollView NestedInteraction(ScrollView.NestedInteractionKind nestedInteractionKind)
        {
            scrollView.nestedInteractionKind = nestedInteractionKind;
            return this;
        }
        public UISharpScrollView SetHorizontalScrollerVisibility(ScrollerVisibility state)
        {
            scrollView.horizontalScrollerVisibility = state;
            return this;
        }
        public UISharpScrollView SetHorizontalPageSize(float value)
        {
            scrollView.horizontalPageSize = value;
            return this;
        }
        public UISharpScrollView SetDecelerationRate(float value)
        {
            scrollView.scrollDecelerationRate = value;
            return this;
        }
        public UISharpScrollView SetScrollOffset(Vector2 value)
        {
            scrollView.scrollOffset = value;
            return this;
        }
        public UISharpScrollView SetTouchScrollBehavior(ScrollView.TouchScrollBehavior scrollBehavior)
        {
            scrollView.touchScrollBehavior = scrollBehavior;
            return this;
        }
        public UISharpScrollView SetVerticalPageSize(float value)
        {
            scrollView.verticalPageSize = value;
            return this;
        }
        public UISharpScrollView SetVerticalScrollerVisibility(ScrollerVisibility state)
        {
            scrollView.verticalScrollerVisibility = state;
            return this;
        }
        public ScrollView ReturnAsType()
        {
            return visualElement as ScrollView;
        }
    }
    public class UISharpListView : UISharp
    {
        public ListView listView { get; set; }

        public UISharpListView(ListView listview, IList itemSource, Func<VisualElement> makeItem, Action<VisualElement, int> bindItem, int itemHeight = 35) : base(listview)
        {
            if (listview == null || itemSource == null || makeItem == null || bindItem == null)
                throw new Exception("UISharp : ListView can't be null or empty");

            listView = listview;
            listView.itemsSource = itemSource;
            listView.makeItem = makeItem;
            listView.bindItem = bindItem;
            listView.fixedItemHeight = itemHeight;
            listView.Rebuild();
        }

        public UISharpListView MarkDirtyRepaint()
        {
            listView.MarkDirtyRepaint();
            return this;
        }
        public UISharpListView SetHorizontalScroll(bool state)
        {
            listView.horizontalScrollingEnabled = state;
            return this;
        }
        public UISharpListView SetVirtualization(CollectionVirtualizationMethod virtualizationMethod)
        {
            listView.virtualizationMethod = virtualizationMethod;
            return this;
        }
        public UISharpListView SetReorderable(bool state)
        {
            listView.reorderable = state;
            return this;
        }
        public UISharpListView SetReorderMode(ListViewReorderMode state)
        {
            listView.reorderMode = state;
            return this;
        }
        public UISharpListView SetBorder(bool state)
        {
            listView.showBorder = state;
            return this;
        }
        public UISharpListView SetSelectionType(SelectionType state)
        {
            listView.selectionType = state;
            return this;
        }
        public UISharpListView OnItemIndexChanged(Action<int, int> action)
        {
            listView.itemIndexChanged += action;
            return this;
        }
        public UISharpListView OnItemSourceChanged(Action action)
        {
            listView.itemsSourceChanged += action;
            return this;
        }
        public UISharpListView OnItemChosen(Action<IEnumerable<object>> action)
        {
            listView.onItemsChosen += action;
            return this;
        }
        public UISharpListView OnSelectedIndicesChange(Action<IEnumerable<int>> action)
        {
            listView.onSelectedIndicesChange += action;
            return this;
        }
        public UISharpListView OnSelectionChange(Action<IEnumerable<object>> action)
        {
            listView.onSelectionChange += action;
            return this;
        }
        public UISharpListView ShowAlternatingRow(AlternatingRowBackground state)
        {
            listView.showAlternatingRowBackgrounds = state;
            return this;
        }
        public UISharpListView ShowFoldoutHeader(bool state)
        {
            listView.showFoldoutHeader = state;
            return this;
        }
        public UISharpListView ShowAddRemoveFooter(bool state)
        {
            listView.showAddRemoveFooter = state;
            return this;
        }
        public UISharpListView ShowBoundCollectionSize(bool state)
        {
            listView.showBoundCollectionSize = state;
            return this;
        }
        public UISharpListView DestroyedItem(Action<VisualElement> value)
        {
            listView.destroyItem += value;
            return this;
        }
        public UISharpListView UnbindItem(Action<VisualElement, int> value)
        {
            listView.unbindItem += value;
            return this;
        }
        public UISharpListView ScrollTo(VisualElement value)
        {
            listView.ScrollTo(value);
            return this;
        }
        public UISharpListView ScrollToId(int id)
        {
            listView.ScrollToId(id);
            return this;
        }
        public UISharpListView ScrollToIndex(int index)
        {
            listView.ScrollToItem(index);
            return this;
        }
        public ListView ReturnAsType()
        {
            return visualElement as ListView;
        }
    }
}


#if UNITY_EDITOR
namespace UITKsharp.Editor
{    
    public class UISharpIntField : UISharp
    {
        private IntegerField intField;

        public UISharpIntField (IntegerField integerField): base(integerField)
        {
            intField = integerField;
        }
        public UISharpIntField SetValueChangedEvent(Action<int> callback)
        {
            intField.RegisterValueChangedCallback(x =>
            {
                callback.Invoke(x.newValue);
            });
            return this;
        }
        public UISharpIntField SetTrippleClickSelect(bool state)
        {
            intField.tripleClickSelectsLine = state;
            return this;
        }
        public UISharpIntField SetDoubleClickSelect(bool state)
        {
            intField.doubleClickSelectsWord = state;
            return this;
        }
        public UISharpIntField SetMaxLength(int maxlength)
        {
            intField.maxLength = maxlength;
            return this;
        }
        public UISharpIntField SetMaskChar(char maskChar)
        {
            intField.maskChar = maskChar;
            return this;
        }
        public IntegerField ReturnAsType()
        {
            return intField;
        }
    }
    public class UISharpVector2Field : UISharp
    {
        private Vector2Field vec2Field;

        public UISharpVector2Field (Vector2Field vector2Field): base(vector2Field)
        {
            vec2Field = vector2Field;
        }
        public UISharpVector2Field SetValueChangedEvent(Action<Vector2> callback)
        {
            vec2Field.RegisterValueChangedCallback(x =>
            {
                callback.Invoke(x.newValue);
            });
            return this;
        }
        public Vector2Field ReturnAsType()
        {
            return vec2Field;
        }
    }
    public class UISharpVector3Field : UISharp
    {
        private Vector3Field vec3Field;

        public UISharpVector3Field (Vector3Field vector3Field): base(vector3Field)
        {
            vec3Field = vector3Field;
        }
        public UISharpVector3Field SetValueChangedEvent(Action<Vector3> callback)
        {
            vec3Field.RegisterValueChangedCallback(x =>
            {
                callback.Invoke(x.newValue);
            });
            return this;
        }
        public Vector3Field ReturnAsType()
        {
            return vec3Field;
        }
    }
    public class UISharpVector4Field : UISharp
    {
        private Vector4Field vec4Field;

        public UISharpVector4Field (Vector4Field vector4Field): base(vector4Field)
        {
            vec4Field = vector4Field;
        }
        public UISharpVector4Field SetValueChangedEvent(Action<Vector4> callback)
        {
            vec4Field.RegisterValueChangedCallback(x =>
            {
                callback.Invoke(x.newValue);
            });
            return this;
        }
        public Vector4Field ReturnAsType()
        {
            return vec4Field;
        }
    }
    public class UISharpDoubleField : UISharp
    {
        private DoubleField doubleField;

        public UISharpDoubleField (DoubleField doublefield): base(doublefield)
        {
            doubleField = doublefield;
        }
        public UISharpDoubleField SetValueChangedEvent(Action<double> callback)
        {
            doubleField.RegisterValueChangedCallback(x =>
            {
                callback.Invoke(x.newValue);
            });
            return this;
        }
        public DoubleField ReturnAsType()
        {
            return doubleField;
        }
    }
    public class UISharpFloatField : UISharp
    {
        private FloatField floatField;

        public UISharpFloatField (FloatField floatfield): base(floatfield)
        {
            floatField = floatfield;
        }
        public UISharpFloatField SetValueChangedEvent(Action<double> callback)
        {
            floatField.RegisterValueChangedCallback(x =>
            {
                callback.Invoke(x.newValue);
            });
            return this;
        }
        public FloatField ReturnAsType()
        {
            return floatField;
        }
        public UISharpFloatField SetBinding(IBinding bindingObject)
        {
            floatField.binding = bindingObject;
            return this;
        }
        public UISharpFloatField SetBindingPath(string bindingpath)
        {
            floatField.bindingPath = bindingpath;
            return this;
        }
    }
    public class UISharpColorField : UISharp
    {
        private ColorField colorField;

        public UISharpColorField (ColorField colorfield): base(colorfield)
        {
            colorField = colorfield;
        }
        public UISharpColorField SetHDR(bool state)
        {
            colorField.hdr = state;
            return this;
        }
        public UISharpColorField SetShowAlpha(bool state)
        {
            colorField.showAlpha = state;
            return this;
        }
        public UISharpColorField SetShowEyeDropper(bool state)
        {
            colorField.showEyeDropper = state;
            return this;
        }
        public UISharpColorField SetValueChangedEvent(Action<Color> callback)
        {
            colorField.RegisterValueChangedCallback(x =>
            {
                callback.Invoke(x.newValue);
            });
            return this;
        }
        public ColorField ReturnAsType()
        {
            return colorField;
        }
        public UISharpColorField SetBinding(IBinding bindingObject)
        {
            colorField.binding = bindingObject;
            return this;
        }
        public UISharpColorField SetBindingPath(string bindingpath)
        {
            colorField.bindingPath = bindingpath;
            return this;
        }
    }
    public class UISharpCurveField : UISharp
    {
        private CurveField curveField;

        public UISharpCurveField (CurveField curvefield): base(curvefield)
        {
            curveField = curvefield;
        }
        public UISharpCurveField SetValueChangedEvent(Action<AnimationCurve> callback)
        {
            curveField.RegisterValueChangedCallback(x =>
            {
                callback.Invoke(x.newValue);
            });
            return this;
        }
        public UISharpCurveField SetRange(Rect rect)
        {
            curveField.ranges = rect;
            return this;
        }
        public UISharpCurveField SetRenderMode(CurveField.RenderMode renderMode)
        {
            curveField.renderMode = renderMode;
            return this;
        }
        public CurveField ReturnAsType()
        {
            return curveField;
        }
        public UISharpCurveField SetBinding(IBinding bindingObject)
        {
            curveField.binding = bindingObject;
            return this;
        }
        public UISharpCurveField SetBindingPath(string bindingpath)
        {
            curveField.bindingPath = bindingpath;
            return this;
        }
    }
    public class UISharpEnumField : UISharp
    {
        private EnumField enumField;

        public UISharpEnumField (EnumField enumfield): base(enumfield)
        {
            enumField = enumfield;
        }
        public UISharpEnumField SetValueChangedEvent(Action<Enum> callback)
        {
            enumField.RegisterValueChangedCallback(x =>
            {
                callback.Invoke(x.newValue);
            });
            return this;
        }
        public EnumField ReturnAsType()
        {
            return enumField;
        }
        public UISharpEnumField SetBinding(IBinding bindingObject)
        {
            enumField.binding = bindingObject;
            return this;
        }
        public UISharpEnumField SetBindingPath(string bindingpath)
        {
            enumField.bindingPath = bindingpath;
            return this;
        }
    }
    public class UISharpEnumFlagsField : UISharp
    {
        private EnumFlagsField enumFlagsField;

        public UISharpEnumFlagsField(EnumFlagsField enumflagsfield, List<string> choice): base(enumflagsfield)
        {
            enumFlagsField = enumflagsfield;
            enumFlagsField.choices = choice;
        }
        public UISharpEnumFlagsField SetValueChangedEvent(Action<Enum> callback)
        {
            enumFlagsField.RegisterValueChangedCallback(x =>
            {
                callback.Invoke(x.newValue);
            });
            return this;
        }
        public EnumFlagsField ReturnAsType()
        {
            return enumFlagsField;
        }
        public UISharpEnumFlagsField SetBinding(IBinding bindingObject)
        {
            enumFlagsField.binding = bindingObject;
            return this;
        }
        public UISharpEnumFlagsField SetBindingPath(string bindingpath)
        {
            enumFlagsField.bindingPath = bindingpath;
            return this;
        }
    }
    public class UISharpGradientField : UISharp
    {
        private GradientField gradientField;
        public UISharpGradientField(GradientField gradientfield): base(gradientfield)
        {
            gradientField = gradientfield;
        }
        public UISharpGradientField SetColorSpace(ColorSpace colorSpace)
        {
            gradientField.colorSpace = colorSpace;
            return this;
        }
        public UISharpGradientField SetValueChangedEvent(Action<Gradient> callback)
        {
            gradientField.RegisterValueChangedCallback(x =>
            {
                callback.Invoke(x.newValue);
            });
            return this;
        }
        public GradientField ReturnAsType()
        {
            return gradientField;
        }
        public UISharpGradientField SetBinding(IBinding bindingObject)
        {
            gradientField.binding = bindingObject;
            return this;
        }
        public UISharpGradientField SetBindingPath(string bindingpath)
        {
            gradientField.bindingPath = bindingpath;
            return this;
        }
    }
    public class UISharpHash128Field : UISharp
    {
        private Hash128Field hashField;
        public UISharpHash128Field(Hash128Field hashfield): base(hashfield)
        {
            hashField = hashfield;
        }
        public Hash128Field ReturnAsType()
        {
            return hashField;
        }

        public UISharpHash128Field SetValueChangedEvent(Action<Hash128> callback)
        {
            hashField.RegisterValueChangedCallback(x =>
            {
                callback.Invoke(x.newValue);
            });

            return this;
        }
        public UISharpHash128Field SetBinding(IBinding bindingObject)
        {
            hashField.binding = bindingObject;
            return this;
        }
        public UISharpHash128Field SetBindingPath(string bindingpath)
        {
            hashField.bindingPath = bindingpath;
            return this;
        }
    }
    public class UISharpObjectField : UISharp
    {
        private ObjectField objectField;
        public UISharpObjectField(ObjectField objectfield, Type type = null): base(objectfield)
        {
            objectField = objectfield;
            
            if(type != null)
                objectField.objectType = type;
        }
        public ObjectField ReturnAsType()
        {
            return objectField;
        }
        public UISharpObjectField SetObjectType(Type type)
        {
            objectField.objectType = type;
            return this;
        }
        public UISharpObjectField SetAllowSceneObject(bool state)
        {
            objectField.allowSceneObjects = state;
            return this;
        }
        public UISharpObjectField SetValueChangedEvent(Action<UnityEngine.Object> callback)
        {
            objectField.RegisterValueChangedCallback(x =>
            {
                callback.Invoke(x.newValue);
            });

            return this;
        }
        public UISharpObjectField SetBinding(IBinding bindingObject)
        {
            objectField.binding = bindingObject;
            return this;
        }
        public UISharpObjectField SetBindingPath(string bindingpath)
        {
            objectField.bindingPath = bindingpath;
            return this;
        }
    }
    public class UISharpPropertyField : UISharp
    {
        private PropertyField propertyField;
        public UISharpPropertyField(PropertyField propertyfield): base(propertyfield)
        {
            propertyField = propertyfield;
        }
        public UISharpPropertyField SetBinding(IBinding bindingObject)
        {
            propertyField.binding = bindingObject;
            return this;
        }
        public UISharpPropertyField SetBindingPath(string bindingpath)
        {
            propertyField.bindingPath = bindingpath;
            return this;
        }
        public PropertyField ReturnAsType()
        {
            return propertyField;
        }
    }
    public class UISharpRectField : UISharp
    {
        private RectField propertyField;
        public UISharpRectField(RectField rectfield): base(rectfield)
        {
            propertyField = rectfield;
        }
        public UISharpRectField SetBinding(IBinding bindingObject)
        {
            propertyField.binding = bindingObject;
            return this;
        }
        public UISharpRectField SetBindingPath(string bindingpath)
        {
            propertyField.bindingPath = bindingpath;
            return this;
        }
    }
    public class UISharpRectIntField : UISharp
    {
        private RectIntField rectIntField;
        public UISharpRectIntField(RectIntField rectintfield): base(rectintfield)
        {
            rectIntField = rectintfield;
        }
        public UISharpRectIntField SetBinding(IBinding bindingObject)
        {
            rectIntField.binding = bindingObject;
            return this;
        }
        public UISharpRectIntField SetBindingPath(string bindingpath)
        {
            rectIntField.bindingPath = bindingpath;
            return this;
        }
        public RectIntField ReturnAsType()
        {
            return rectIntField;
        }
    }
}
#endif