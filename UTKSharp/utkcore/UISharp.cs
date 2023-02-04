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
        /// <summary>Gets children in hierarchy</summary>
        /// <param name="visualElement">The parent VisualElement to get the children.</param>
        public static VisualElement[] GetChildren(VisualElement visualElement)
        {
            return UTKSharpElement.GetChildren(visualElement);
        }
        /// <summary>Gets direct parent in hierarchy</summary>
        /// <param name="visualElement">The child VisualElement to get the parent.</param>
        public static VisualElement GetParent(VisualElement visualElement)
        {
            return UTKSharpElement.GetParent(visualElement);
        }
        /// <summary>Gets direct child from a parent VisualElement</summary>
        /// <param name="parent">The parent VisualElement.</param>
        /// <param name="childName">Child name to get from parent VisualElement</param>
        /// <param name="utkId">Child id to get from parent VisualElement</param>
        public static VisualElement GetChild(VisualElement parent, string childName = "", string utkId = "")
        {
            return UTKSharpElement.GetChild(parent, childName, utkId);
        }
        /// <summary>Sets style to a VisualElement.</summary>
        /// <param name="visualElement">The VisualElement to be styled.</param>
        public static UISharp style(VisualElement visualElement)
        {
            return new UISharp(visualElement);
        }
        /// <summary>Adds event to a VisualElement.</summary>
        /// <param name="visualElement">The VisualElement for the event to be added.</param>
        public static UIEvent addEvent(VisualElement visualElement)
        {
            var uievent = new UIEvent(visualElement);
            return uievent;
        }
        /// <summary>Instantiates DropDownField.</summary>
        /// <param name="dropdownField">Instance of a DropDownField.</param>
        /// <param name="list">Choices to be added to DropDownField.</param>
        public static UISharpDropDownField dropDownFieldElement(DropdownField dropdownField, List<string> list)
        {
            var uielement = new UISharpDropDownField(dropdownField, list);
            return uielement;
        }
        /// <summary>Instantiates TextField.</summary>
        /// <param name="visualElement">Instance of a TextField.</param>
        public static UISharpTextField textFieldElement(TextField textField)
        {
            var uielement = new UISharpTextField(textField);
            return uielement;
        }
        /// <summary>Instantiates Label UIElement.</summary>
        /// <param name="label">The instance of the Label.</param>
        /// <param name="visualElement">Title for the label</param>
        public static UISharpLabel labelElement(Label label, string labelField)
        {
            var uielement = new UISharpLabel(label, labelField);
            return uielement;
        }
        /// <summary>Instantiates ListView UIElement.</summary>
        /// <param name="listView">The instance of the ListView.</param>
        /// <param name="itemSource">Content as itemSource to be listed in a ListView</param>
        /// <param name="makeItem">VisualElement for the items shown in ListView</param>
        /// <param name="bindItem">Binding from itemSource to ListView</param>
        public static UISharpListView listViewElement(ListView listView, IList itemSource, Func<VisualElement> makeItem, Action<VisualElement, int> bindItem, int height = 35)
        {
            var uielement = new UISharpListView(listView, itemSource, makeItem, bindItem, height);
            return uielement;
        }
        /// <summary>Instantiates ScrollView UIElement.</summary>
        /// <param name="listView">The instance of the ScrollView.</param>
        /// <param name="items">Array to be shown in a ScrollView</param>
        public static UISharpScrollView scrollViewElement(ScrollView scrollView, VisualElement[] items)
        {
            var uielement = new UISharpScrollView(scrollView, items);
            return uielement;
        }
        /// <summary>Instantiates Image UIElement.</summary>
        /// <param name="image">The instance of the Image.</param>
        public static UISharpImage imageElement(Image image)
        {
            var uielement = new UISharpImage(image);
            return uielement;
        }
        /// <summary>Instantiates Button UIElement.</summary>
        /// <param name="button">The instance of the Button.</param>
        public static UISharpButton buttonElement(Button button)
        {
            var uielement = new UISharpButton(button);
            return uielement;
        }
        /// <summary>Instantiates Toggle UIElement.</summary>
        /// <param name="toggle">The instance of the Toggle.</param>
        public static UISharpToggle toggleElement(Toggle toggle)
        {
            var uielement = new UISharpToggle(toggle);
            return uielement;
        }
        /// <summary>Instantiates Slider UIElement.</summary>
        /// <param name="slider">The instance of the Toggle.</param>
        /// <param name="minValue">Lowest value of a Slider.</param>
        /// <param name="maxValue">Highest value of slider.</param>
        /// <param name="labelField">Title for a Slider.</param>
        /// <param name="sliderDirection">Horizontal or Vertical direction of a Slider.</param>
        public static UISharpSlider sliderElement(Slider slider, float minValue, float maxValue, string labelField = "", SliderDirection sliderDirection = SliderDirection.Horizontal)
        {
            var uielement = new UISharpSlider(slider, minValue, maxValue, labelField, sliderDirection);
            return uielement;
        }
        /// <summary>Instantiates Slider UIElement.</summary>
        /// <param name="slider">The instance of the Toggle.</param>
        /// <param name="lowLimit">Lowest limit of a Slider.</param>
        /// <param name="highLimit">Highest limit of slider.</param>
        /// <param name="minValue">Lowest value of a Slider.</param>
        /// <param name="maxValue">Highest value of slider.</param>
        /// <param name="labelField">Title for a Slider.</param>
        /// <param name="sliderDirection">Horizontal or Vertical direction of a Slider.</param>
        public static UISharpMinMaxSlider minMaxSliderElement(MinMaxSlider slider, float lowLimit, float highLimit, float minValue, float maxValue, string labelField = "", SliderDirection sliderDirection = SliderDirection.Horizontal)
        {
            var uielement = new UISharpMinMaxSlider(slider, minValue, lowLimit, highLimit, maxValue, labelField);
            return uielement;
        }
        /// <summary>Instantiates Box UIElement.</summary>
        /// <param name="box">The instance of the Box.</param>
        public static UISharpBox boxElement(Box box)
        {
            var uielement = new UISharpBox(box);
            return uielement;
        }
        /// <summary>Instantiates PopUpWindow UIElement.</summary>
        /// <param name="popupWindow">The instance of the PopUpWindow.</param>
        public static UISharpPopUpWindow popUpWindowElement(PopupWindow popupWindow)
        {
            var uielement = new UISharpPopUpWindow(popupWindow);
            return uielement;
        }
        /// <summary>Instantiates RadioButton UIElement.</summary>
        /// <param name="radioButton">The instance of the RadioButton.</param>
        /// <param name="defaultValue">Starting value when first intantiated.</param>
        /// <param name="lblField">Title of the RadioButton.</param>
        public static UISharpRadioButton radioButtonElement(RadioButton radioButton, bool defaultValue, string lblField = "")
        {
            var uielement = new UISharpRadioButton(radioButton, defaultValue, lblField);
            return uielement;
        }

        private static void SampleSyntaxes()
        {
            //VisualElement visualElement = new VisualElement();
            //var parentVisualElement = new VisualElement();
            //Sets style                ::  UTKSharp.style(visualElement).SetBcgColor(Color.blue).SetParent(parentVisualElement).SetName("childAsName");
            //Adds Event                ::  UTKSharp.addEvent(visualElement).SetOnMouseDown((x)=> Debug.Log("KeyPressed!"));
            //Instantiate Box element   ::  UTKSharp.boxElement(new Box()).SetWidth(100, dynamic: true).SetHeight(50, dynamic: true).SetAlignContent(Align.Center);
            //Gets child                ::  parentVisualElement = UTKSharp.GetChild(parentVisualElement, "childAsName");
        }
    }

    public class UISharp : UIEvent, ISharpStyle, ISharpCommonMethod
    {
        /// <summary>ID for every UTK instances</summary>
        public string UISharpID { get; set; }

        /// <summary>The VisualElement</summary>
        public VisualElement visualElement { get; set; }

        public UISharp(VisualElement visualelement): base(visualelement)
        {
            UISharpID = Guid.NewGuid().ToString() + UnityEngine.Random.Range(int.MinValue, int.MaxValue);
            visualElement = visualelement;
        }
        /// <summary>Set content alignment of VisualElement.</summary>
        /// <param name="alignment">Type of alignment.</param>
        public UISharp SetAlignContent(Align alignment = Align.Auto)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.alignContent = alignment;
            return this;
        }
        /// <summary>Sets self alignment of VisualElement.</summary>
        /// <param name="alignment">Type of alignment.</param>
        public UISharp SetAlignSelf(Align alignment = Align.Auto)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.alignSelf = alignment;
            return this;
        }
        /// <summary>Sets items alignment of VisualElement.</summary>
        /// <param name="alignment">Type of alignment.</param>
        public UISharp SetAlignItems(Align alignment = Align.Auto)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.alignItems = alignment;
            return this;
        }
        /// <summary>Sets border property of VisualElement.</summary>
        /// <param name="color">Color of the border.</param>
        /// <param name="width">Width of the border.</param>
        public UISharp SetBorder(StyleColor color, float width)
        {
            if (visualElement == null || color == null)
                throw new System.Exception("UISharp : VisualElement and Color can't be null!");

            visualElement.style.borderLeftColor = color;
            visualElement.style.borderRightColor = color;
            visualElement.style.borderTopColor = color;
            visualElement.style.borderBottomColor = color;

            visualElement.style.borderLeftWidth = width;
            visualElement.style.borderRightWidth = width;
            visualElement.style.borderTopWidth = width;
            visualElement.style.borderBottomWidth = width;
            return this;
        }
        /// <summary>Sets position of style.position property to VisualElement.</summary>
        /// <param name="value">New position to be assigned.</param>
        public UISharp SetPosition(StyleEnum<Position> value)
        {
            if (visualElement == null || value == null)
                throw new System.Exception("UISharp : VisualElement and position value can't be null!");

            visualElement.style.position = value;
            return this;
        }
        /// <summary>Sets opacity of style.opacity property to a VisualElement.</summary>
        /// <param name="value">New opacity value (0-1 min/max ratio) to be assigned.</param>
        public UISharp SetOpacity(StyleFloat value)
        {
            if (visualElement == null || value == null)
                throw new System.Exception("UISharp : VisualElement and position value can't be null!");

            visualElement.style.opacity = value;
            return this;
        }
        /// <summary>Sets overflow of style.overflow property to a VisualElement.</summary>
        /// <param name="overflow">New position to be assigned.</param>
        public UISharp SetOverflow(Overflow overflow = Overflow.Visible)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.overflow = overflow;
            return this;
        }
        /// <summary>Sets maximum height of style.maxHeight property to a VisualElement.</summary>
        /// <param name="value">New maxHeight value to be assigned.</param>
        public UISharp SetMaxHeight(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.maxHeight = value;
            return this;
        }
        /// <summary>Sets minimum height of style.maxHeight property to a VisualElement.</summary>
        /// <param name="value">New minHeight value to be assigned.</param>
        public UISharp SetMinHeight(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.minHeight = value;
            return this;
        }
        /// <summary>Sets maximum width of style.maxWidth property to a VisualElement.</summary>
        /// <param name="value">New maxWidth value to be assigned.</param>
        public UISharp SetMaxWidth(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.maxWidth = value;
            return this;
        }
        /// <summary>Sets minimum width of style.minWidth property to a VisualElement.</summary>
        /// <param name="value">New minWidth value to be assigned.</param>
        public UISharp SetMinWidth(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.minWidth = value;
            return this;
        }
        /// <summary>Sets rotation of style.rotate property to a VisualElement.</summary>
        /// <param name="value">Rotation value to be assigned.</param>
        public UISharp SetRotation(StyleRotate value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.rotate = value;
            return this;
        }
        /// <summary>Justifies content of a VisualElement.</summary>
        /// <param name="value">New minWidth value to be assigned.</param>
        public UISharp SetJustifyContent(StyleEnum<Justify> value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.justifyContent = value;
            return this;
        }
        /// <summary>Assign left value of a style.left to VisualElement.</summary>
        /// <param name="value">StyleLength value to be assigned.</param>
        public UISharp SetLeft(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.left = value;
            return this;
        }
        /// <summary>Assign right value of a style.right to VisualElement.</summary>
        /// <param name="value">StyleLength value to be assigned.</param>
        public UISharp SetRight(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.right = value;
            return this;
        }
        /// <summary>Assign top value of a style.top to VisualElement.</summary>
        /// <param name="value">StyleLength value to be assigned.</param>
        public UISharp SetTop(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.top = value;
            return this;
        }
        /// <summary>Assign bottom value of a style.bottom to VisualElement.</summary>
        /// <param name="value">StyleLength value to be assigned.</param>
        public UISharp SetBottom(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.bottom = value;
            return this;
        }
        /// <summary>Assign scale value of a style.scale to VisualElement.</summary>
        /// <param name="value">StyleScale value to be assigned.</param>
        public UISharp SetScale(StyleScale value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.scale = value;
            return this;
        }
        /// <summary>Sets cursor when overed on top of VisualElement.</summary>
        /// <param name="value">StyleCursor value to be assigned.</param>
        public UISharp SetCursor(StyleCursor value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.cursor = value;
            return this;
        }
        /// <summary>Sets bacground scale mode of VisualElement.</summary>
        /// <param name="value">StyleCursor value to be assigned.</param>
        public UISharp SetBcgScaleMode(StyleEnum<ScaleMode> value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.unityBackgroundScaleMode = value;
            return this;
        }
        /// <summary>Sets drop shadow of a TextElement.</summary>
        /// <param name="value">StyleTextShadow value to be assigned.</param>
        public UISharp SetTextShadow(StyleTextShadow value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.textShadow = value;
            return this;
        }
        /// <summary>Sets spacing of TextElement.</summary>
        /// <param name="value">StyleLength value to be assigned.</param>
        public UISharp SetWordSpacing(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.wordSpacing = value;
            return this;
        }
        /// <summary>Sets spacing of TextElement.</summary>
        /// <param name="value">String value to be assigned.</param>
        /// <param name="ignoreTypeMismatchError">Ignores type mismatch warnings/throws.</param>
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
        /// <summary>Sets transition delay of VisualElement.</summary>
        /// <param name="value">StyleList timeValue value to be assigned.</param>
        public UISharp SetTransitionDelay(StyleList<TimeValue> value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.transitionDelay = value;
            return this;
        }
        /// <summary>Sets transition property of VisualElement.</summary>
        /// <param name="value">StyleList propertyName value to be assigned.</param>
        public UISharp SetTransitionProperty(StyleList<StylePropertyName> value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.transitionProperty = value;
            return this;
        }
        /// <summary>Sets transition origin of VisualElement.</summary>
        /// <param name="value">StyleTransformOrigin value to be assigned.</param>
        public UISharp SetTransformOrigin(StyleTransformOrigin value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.transformOrigin = value;
            return this;
        }
        /// <summary>Sets transition easing option of VisualElement.</summary>
        /// <param name="value">Stylelist easingFunction value to be assigned.</param>
        public UISharp SetTransitionTiming(StyleList<EasingFunction> value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.transitionTimingFunction = value;
            return this;
        }
        /// <summary>Sets transition duration of VisualElement.</summary>
        /// <param name="value">StyleList timeValue value to be assigned.</param>
        public UISharp SetTransitionDuration(StyleList<TimeValue> value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.transitionDuration = value;
            return this;
        }
        /// <summary>Sets transition property of VisualElement.</summary>
        /// <param name="value">StyleList easingFunction  value to be assigned.</param>
        public UISharp SetTransitionProperty(StyleList<EasingFunction> value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.transitionTimingFunction = value;
            return this;
        }
        /// <summary>Enable/disable a VisualElement.</summary>
        /// <param name="value">Enable state of a VisualElement.</param>
        public UISharp SetEnabled(bool value = true)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.SetEnabled(value);
            return this;
        }
        /// <summary>Word wrapping over multiple lines if not enough space is available to draw the text of an element.</summary>
        /// <param name="value">Value to be assigned.</param>
        public UISharp SetWhiteSpace(StyleEnum<WhiteSpace> value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.whiteSpace = value;
            return this;
        }
        /// <summary>Sets padding of a VisualElement.</summary>
        /// <param name="left">Left side padding.</param>
        /// <param name="right">Right side padding.</param>
        /// <param name="top">Top side padding.</param>
        /// <param name="bottom">Bottom side padding.</param>
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
        /// <summary>Visibility of a VisualElement.</summary>
        /// <param name="enable">Visibility state of a VisualElement.</param>
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
        /// <summary>Defines how a VisualElement displayed in a layout.</summary>
        /// <param name="displayStyle">Display style of a VisualElement in a layout.</param>
        public UISharp SetDisplay(DisplayStyle displayStyle = DisplayStyle.Flex)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.display = displayStyle;
            return this;
        }
        /// <summary>Translate transformation.</summary>
        /// <param name="value">Translate value.</param>
        public UISharp SetTranslate(StyleTranslate value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.translate = value;
            return this;
        }
        /// <summary>Direction type of an axis.</summary>
        /// <param name="value">Directions type to the axis.</param>
        public UISharp SetFlexDirection(FlexDirection flexDirection)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.style.flexDirection = flexDirection;
            return this;
        }
        /// <summary>Direction type of an axis.</summary>
        /// <param name="value">Shrinks behavior in a container.</param>
        public UISharp SetFlexGrow(StyleFloat value)
        {
            if (visualElement == null || value == null)
                throw new System.Exception("UISharp : VisualElement and float value can't be null!");

            visualElement.style.flexGrow = value;
            return this;
        }
        /// <summary>Background image of VisualElement.</summary>
        /// <param name="value">Background value</param>
        public UISharp SetBcgImageTint(StyleBackground value)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement and float value can't be null!");

            visualElement.style.backgroundImage = value;
            return this;
        }
        /// <summary>Shrink relative to the rest of items in a container.</summary>
        /// <param name="value">Shrinks behavior in a container.</param>
        public UISharp SetFlexShrink(StyleFloat value)
        {
            if (visualElement == null || value == null)
                throw new System.Exception("UISharp : VisualElement and float value can't be null!");

            visualElement.style.flexShrink = value;
            return this;
        }
        /// <summary>Warps relative to the rest of items in a container.</summary>
        /// <param name="value">Warp mode behavior.</param>
        public UISharp SetFlexWrap(Wrap value = Wrap.NoWrap)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement value can't be null!");

            visualElement.style.flexWrap = value;
            return this;
        }
        /// <summary>Sets the size of a font.</summary>
        /// <param name="value">Font size value.</param>
        public UISharp SetFontSize(StyleLength value)
        {
            if (visualElement == null || value == null)
                throw new System.Exception("UISharp : VisualElement and value can't be null!");

            visualElement.style.fontSize = value;
            return this;
        }
        /// <summary>Determines background color of a VisualElement.</summary>
        /// <param name="value">Color value to assigned for the background.</param>
        public UISharp SetBcgColor(StyleColor color)
        {
            if (visualElement == null || color == null)
                throw new System.Exception("UISharp : VisualElement and Color can't be null!");

            visualElement.style.backgroundColor = color;
            return this;
        }
        /// <summary>Sets the width size of a VisualElement.</summary>
        /// <param name="value">Value in pixel if dynamic = false, in percent if dynamic = true.</param>
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
        /// <summary>Sets the height size of a VisualElement.</summary>
        /// <param name="value">Value in pixel if dynamic = false, in percent if dynamic = true.</param>
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
        /// <summary>Sets margins of a VisualElement.</summary>
        /// <param name="leftValue">Left side margin value.</param>
        /// <param name="rightValue">Right side margin value.</param>
        /// <param name="topValue">Top side margin value.</param>
        /// <param name="bottomValue">Bottom side margin value.</param>
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
        /// <summary>Sets userData as object type.</summary>
        /// <param name="userData">Left side margin value.</param>
        public UISharp SetUserData(System.Object userData)
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            if (userData == null)
                throw new System.Exception("UISharp : Object as userData can't be null!");

            visualElement.userData = userData;
            return this;
        }
        /// <summary>Sets the parent of VisualElement.</summary>
        /// <param name="parent">Parent VisualElement.</param>
        /// <param name="markDirtyRepaint">Dirties the layout to be repainted after reparenting.</param>
        public UISharp SetParent(VisualElement parent, bool markDirtyRepaint = false)
        {
            if (visualElement == null || parent == null)
                throw new System.Exception("UISharp : Child and parent can't be null!");

            parent.Add(visualElement);

            if (markDirtyRepaint)
                parent.MarkDirtyRepaint();

            return this;
        }
        /// <summary>Sets name property of a VisualElement.</summary>
        /// <param name="name">Name of the VisualElement to be assigned.</param>
        public UISharp SetName(string name)
        {
            if (visualElement == null || String.IsNullOrEmpty(name))
                throw new System.Exception("UISharp : VisualElement and VisualElement's name can't be null!");

            visualElement.name = name;
            return this;
        }
        /// <summary>Return the VisualElement that's being instantiated. Must be used at the very end of the method chain.</summary>
        /// <param name="name">Name of the VisualElement to be assigned.</param>
        public VisualElement Return()
        {
            return visualElement;
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
                if (!String.IsNullOrEmpty(childName) && child.name == childName)
                {
                    return child;
                }
                else if (!String.IsNullOrEmpty(utkId) && child.name == utkId)
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
        private VisualElement cachedVisualElement;
        
        public UIEvent(VisualElement vis)
        {
            cachedVisualElement = vis;
        }

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