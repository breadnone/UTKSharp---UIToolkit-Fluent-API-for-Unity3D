/* MIT License
Copyright (c) 2023 UTKSharp

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.*/

using UnityEngine;
using UnityEngine.UIElements;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UITKsharp
{
    public static class UTKSharp
    {
        public static UISharp style(VisualElement visualElement)
        {
            return new UISharp(visualElement);
        }
        public static UIEvent addEvent(VisualElement visualElement)
        {
            var uievent = new UIEvent();
            uievent.cachedVisualElement = visualElement;
            return uievent;
        }
        public static UISharpDropDownField dropDownFieldElement(DropdownField dropdownField, List<string> list)
        {
            var uielement = new UISharpDropDownField(dropdownField, list);
            return uielement;
        }
        public static UISharpTextField textFieldElement(TextField textField)
        {
            var uielement = new UISharpTextField(textField);
            return uielement;
        }
        public static UISharpLabel labelElement(Label label, string labelField)
        {
            var uielement = new UISharpLabel(label, labelField);
            return uielement;
        }
        public static UISharpListView listViewElement(ListView listView, IList itemSource, Func<VisualElement> makeItem, Action<VisualElement, int> bindItem, int height = 35)
        {
            var uielement = new UISharpListView(listView, itemSource, makeItem, bindItem, height);
            return uielement;
        }
        public static UISharpScrollView scrollViewElement(ScrollView scrollView, VisualElement[] items)
        {
            var uielement = new UISharpScrollView(scrollView, items);
            return uielement;
        }
        public static UISharpImage imageElement(Image image)
        {
            var uielement = new UISharpImage(image);
            return uielement;
        }
        public static UISharpButton buttonElement(Button button)
        {
            var uielement = new UISharpButton(button);
            return uielement;
        }
        public static UISharpToggle toggleElement(Toggle toggle)
        {
            var uielement = new UISharpToggle(toggle);
            return uielement;
        }
        public static UISharpSlider sliderElement(Slider slider, float minValue, float maxValue, string labelField = "", SliderDirection sliderDirection = SliderDirection.Horizontal)
        {
            var uielement = new UISharpSlider(slider, minValue, maxValue, labelField, sliderDirection);
            return uielement;
        }
        public static UISharpMinMaxSlider minMaxSliderElement(MinMaxSlider slider, float lowLimit, float highLimit, float minValue, float maxValue, string labelField = "", SliderDirection sliderDirection = SliderDirection.Horizontal)
        {
            var uielement = new UISharpMinMaxSlider(slider, minValue, lowLimit, highLimit, maxValue, labelField);
            return uielement;
        }
        public static UISharpBox boxElement(Box box)
        {
            var uielement = new UISharpBox(box);
            return uielement;
        }
        public static UISharpPopUpWindow popUpWindowElement(PopupWindow popupWindow)
        {
            var uielement = new UISharpPopUpWindow(popupWindow);
            return uielement;
        }
        private static void SampleSyntaxes()
        {
            var parentVisualElement = new VisualElement();
            UTKSharp.style(new VisualElement()).SetBcgColor(Color.blue).SetParent(parentVisualElement);
            UTKSharp.addEvent(new VisualElement()).SetOnMouseDown((x)=> Debug.Log("KeyPressed!"));
            UTKSharp.boxElement(new Box()).SetWidth(100, dynamic: true).SetHeight(50, dynamic: true).SetAlignContent(Align.Center);
        }
    }

    public class UISharp : UIEvent, ISharpStyle, ISharpCommonMethod
    {
        public string UISharpID { get; set; }
        public VisualElement visualElement { get; set; }

        public UISharp(VisualElement visualelement)
        {
            UISharpID = Guid.NewGuid().ToString() + UnityEngine.Random.Range(int.MinValue, int.MaxValue);
            visualElement = visualelement;
        }
        public UISharp SetAlignContent(Align alignment = Align.Auto)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.alignContent = alignment;
            return this;
        }
        public UISharp SetAlignSelf(Align alignment = Align.Auto)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.alignSelf = alignment;
            return this;
        }
        public UISharp SetAlignItems(Align alignment = Align.Auto)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.alignItems = alignment;
            return this;
        }
        public UISharp SetBorder(StyleColor color, float width)
        {
            if (visualElement == null || color == null)
                throw new System.Exception("UISharp : VisualElement and Color can't be null!");

            visualElement.style.borderLeftColor = color;
            visualElement.style.borderRightColor = color;
            visualElement.style.borderTopColor = color;
            visualElement.style.borderBottomColor = color;

            if (width.HasValue)
            {
                visualElement.style.borderLeftWidth = width.Value;
                visualElement.style.borderRightWidth = width.Value;
                visualElement.style.borderTopWidth = width.Value;
                visualElement.style.borderBottomWidth = width.Value;
            }

            return this;
        }
        public UISharp SetPosition(StyleEnum<Position> value)
        {
            if (visualElement == null || value == null)
                throw new System.Exception("UISharp : VisualElement and position value can't be null!");

            visualElement.style.position = value;
            return this;
        }

        public UISharp SetOpacity(StyleFloat value)
        {
            if (visualElement == null || value == null)
                throw new System.Exception("UISharp : VisualElement and position value can't be null!");

            visualElement.style.opacity = value;
            return this;
        }
        public UISharp SetOverflow(Overflow overflow = Overflow.Visible)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.overflow = overflow;
            return this;
        }
        public UISharp SetMaxHeight(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.maxHeight = value;
            return this;
        }
        public UISharp SetMinHeight(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.minHeight = value;
            return this;
        }
        public UISharp SetMaxWidth(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.maxWidth = value;
            return this;
        }
        public UISharp SetMinWidth(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.minWidth = value;
            return this;
        }
        public UISharp SetRotation(StyleRotate value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.rotate = value;
            return this;
        }
        public UISharp SetJustifyContent(StyleEnum<Justify> value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.justifyContent = value;
            return this;
        }
        public UISharp SetLeft(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.left = value;
            return this;
        }
        public UISharp SetRight(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.right = value;
            return this;
        }
        public UISharp SetTop(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.top = value;
            return this;
        }
        public UISharp SetBottom(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.bottom = value;
            return this;
        }
        public UISharp SetScale(StyleScale value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.scale = value;
            return this;
        }
        public UISharp SetCursor(StyleCursor value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.cursor = value;
            return this;
        }
        public UISharp SetBcgScaleMode(StyleEnum<ScaleMode> value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.unityBackgroundScaleMode = value;
            return this;
        }
        public UISharp SetTextShadow(StyleTextShadow value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.textShadow = value;
            return this;
        }
        public UISharp SetWordSpacing(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.wordSpacing = value;
            return this;
        }
        public UISharp SetText(string value, bool ignoreTypeMismatchError = true)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            if (visualElement is Label)
                (visualElement as Label).text = value;
            else if (visualElement is DropdownField)
                (visualElement as DropdownField).value = value;
            else if (visualElement is Button)
                (visualElement as Button).text = value;
            else if (visualElement is TextField)
                (visualElement as TextField).value = value;
            else if (visualElement is Toggle)
                (visualElement as Toggle).text = value;
            else
            {
                if (!ignoreTypeMismatchError)
                    throw new Exception("UISHarp : VisualElement not compatible with text");
            }
            return this;
        }
        public UISharp SetTransitionDelay(StyleList<TimeValue> value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.transitionDelay = value;
            return this;
        }
        public UISharp SetTransitionProperty(StyleList<StylePropertyName> value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.transitionProperty = value;
            return this;
        }
        public UISharp SetTransformOrigin(StyleTransformOrigin value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.transformOrigin = value;
            return this;
        }
        public UISharp SetTransitionTiming(StyleList<EasingFunction> value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.transitionTimingFunction = value;
            return this;
        }
        public UISharp SetTransitionDuration(StyleList<TimeValue> value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.transitionDuration = value;
            return this;
        }
        public UISharp SetTransitionProperty(StyleList<EasingFunction> value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.transitionTimingFunction = value;
            return this;
        }
        public UISharp SetEnabled(bool value = true)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.SetEnabled(value);
            return this;
        }
        public UISharp SetWhiteSpace(StyleEnum<WhiteSpace> value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.whiteSpace = value;
            return this;
        }
        public UISharp SetPadding(float? left, float? right, float? top, float? bottom)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            if (left.HasValue)
                visualElement.style.paddingLeft = left.Value;
            if (right.HasValue)
                visualElement.style.paddingRight = right.Value;
            if (top.HasValue)
                visualElement.style.paddingTop = top.Value;
            if (bottom.HasValue)
                visualElement.style.paddingBottom = bottom.Value;

            return this;
        }
        public UISharp SetVisibility(bool enable = true)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            if (enable)
                visualElement.style.visibility = Visibility.Visible;
            else
                visualElement.style.visibility = Visibility.Hidden;
            return this;
        }
        public UISharp SetDisplay(DisplayStyle displayStyle = DisplayStyle.Flex)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.display = displayStyle;
            return this;
        }
        public UISharp SetTranslate(StyleTranslate value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.translate = value;
            return this;
        }
        public UISharp SetFlexDirection(FlexDirection flexDirection)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.flexDirection = flexDirection;
            return this;
        }
        public UISharp SetFlexGrow(StyleFloat value)
        {
            if (visualElement == null || value == null)
                throw new System.Exception("UISharp : VisualElement and float value can't be null!");

            visualElement.style.flexGrow = value;
            return this;
        }
        public UISharp SetBackgroundImageTint(StyleBackground value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement and float value can't be null!");

            visualElement.style.backgroundImage = value;
            return this;
        }
        public UISharp SetFlexShrink(StyleFloat value)
        {
            if (visualElement == null || value == null)
                throw new System.Exception("UISharp : VisualElement and float value can't be null!");

            visualElement.style.flexShrink = value;
            return this;
        }
        public UISharp SetFlexWrap(Wrap value = Wrap.NoWrap)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement value can't be null!");

            visualElement.style.flexWrap = value;
            return this;
        }
        public UISharp SetFontSize(StyleLength value)
        {
            if (visualElement == null || value == null)
                throw new System.Exception("UISharp : VisualElement and value can't be null!");

            visualElement.style.fontSize = value;
            return this;
        }
        public UISharp SetBcgColor(StyleColor color)
        {
            if (visualElement == null || color == null)
                throw new System.Exception("UISharp : VisualElement and Color can't be null!");

            visualElement.style.backgroundColor = color;
            return this;
        }
        public UISharp SetWidth(float? value, bool dynamic = false)
        {
            if (visualElement == null || !value.HasValue)
                throw new System.Exception("UISharp : VisualElement and value can't be null!");

            if (!dynamic)
                visualElement.style.width = value.Value;
            else
                visualElement.style.width = new StyleLength(new Length(value.Value, LengthUnit.Percent));

            return this;
        }
        public UISharp SetHeight(float? value, bool dynamic = false)
        {
            if (visualElement == null || !value.HasValue)
                throw new System.Exception("UISharp : VisualElement and float value can't be null!");

            if (!dynamic)
                visualElement.style.height = value.Value;
            else
                visualElement.style.height = new StyleLength(new Length(value.Value, LengthUnit.Percent));

            return this;
        }
        public UISharp SetMargin(float? leftValue, float? rightValue, float? topValue, float? bottomValue)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            if (leftValue.HasValue)
                visualElement.style.marginLeft = leftValue.Value;

            if (rightValue.HasValue)
                visualElement.style.marginRight = rightValue.Value;

            if (topValue.HasValue)
                visualElement.style.marginTop = topValue.Value;

            if (bottomValue.HasValue)
                visualElement.style.marginBottom = bottomValue.Value;

            return this;
        }
        public UISharp SetBcgColor(Color color)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.backgroundColor = color;
            return this;
        }

        public UISharp SetUserData(System.Object userData)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            if (userData == null)
                throw new System.Exception("UISharp : Object as userData can't be null!");

            visualElement.userData = userData;
            return this;
        }
        public UISharp SetParent(VisualElement parent, bool markDirtyRepaint = false)
        {
            if (visualElement == null || parent == null)
                throw new System.Exception("UISharp : Child and parent can't be null!");

            parent.Add(visualElement);

            if (markDirtyRepaint)
                parent.MarkDirtyRepaint();

            return this;
        }
        public UISharp SetName(string name)
        {
            if (visualElement == null || String.IsNullOrEmpty(name))
                throw new System.Exception("UISharp : VisualElement and VisualElement's name can't be null!");

            visualElement.name = name;
            return this;
        }
    }
    public static class UTKSharpElement
    {
        public static VisualElement GetParent(VisualElement visualElement)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            return visualElement.parent;
        }
        public static VisualElement GetChild(VisualElement visualElement, string childName, string utkId)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            if (visualElement.childCount == 0)
                return null;

            foreach (var child in visualElement.Children())
            {
                if (childName != null && child.name == childName)
                {
                    return child;
                }
                else if (utkId != null && child.name == utkId)
                {
                    return child;
                }
            }

            return null;
        }
        public static int GetChildCount(VisualElement visualElement)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            return visualElement.childCount;
        }
        public static VisualElement[] GetChildren(VisualElement visualElement)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            return visualElement.Children().ToArray();
        }
    }
    public class UIProperty
    {

    }
    public class UISharpCommonMethod : ISharpCommonMethod 
    { 
        public VisualElement visualElement{get;set;}

        public UISharpCommonMethod(VisualElement element)
        {
            visualElement = element;
        }
    }

    public class UIEvent : ISharpEvent
    {
        public VisualElement cachedVisualElement { get; set; }

        public UIEvent SetOnKeyDown(Action<KeyDownEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UISharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<KeyDownEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnMouseDown(Action<MouseDownEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UISharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<MouseDownEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnMouseOver(Action<MouseOverEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UISharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<MouseOverEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnFocusOut(Action<FocusOutEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UISharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<FocusOutEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnMouseEnter(Action<MouseEnterEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UISharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<MouseEnterEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnMouseExit(Action<MouseLeaveEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UISharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<MouseLeaveEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnFocusIn(Action<FocusInEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UISharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<FocusInEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnKeyUp(Action<KeyUpEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UISharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<KeyUpEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent ScheduleExecute(VisualElement visualElementToBeWaited,  Action callback, int delay = 0)
        {
            if (cachedVisualElement == null || visualElementToBeWaited == null)
                throw new System.Exception("UISharp : VisualElements can't be null!");
            
            cachedVisualElement.schedule.Execute(x =>
            {
                callback.Invoke();
            }).ExecuteLater(delay);
            return this;
        }
    }
}