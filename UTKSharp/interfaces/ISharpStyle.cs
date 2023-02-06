/*MIT License
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

namespace UITKsharp
{
    public interface ISharpStyle
    {
        //public UISharp GetSourceVisualElement(T visualElement, float value, bool dynamic = false);
        public UISharp SetWidth(float? value, bool dynamic = false);
        public UISharp SetColor(StyleColor color);
        public UISharp SetHeight(float? value, bool dynamic = false);
        public UISharp SetMargin(float? leftValue, float? rightValue, float? topValue, float? bottomValue);
        public UISharp SetPadding(float? left, float? right, float? top, float? bottom);
        public UISharp SetBcgColor(StyleColor color);
        public UISharp SetAlignContent(Align alignment);
        public UISharp SetAlignSelf(Align alignment);
        public UISharp SetAlignItems(Align alignment);
        public UISharp SetBorder(StyleColor color, float width);
        public UISharp SetVisibility(bool isVisible = true);
        public UISharp SetDisplay(DisplayStyle displayType);
        public UISharp SetFlexDirection(FlexDirection flexType);
        public UISharp SetFlexGrow(StyleFloat value);
        public UISharp SetFlexShrink(StyleFloat value);
        public UISharp SetFlexWrap(Wrap wrap);
        public UISharp SetFontSize(StyleLength size);
        public UISharp SetPosition(StyleEnum<Position> pos);
        public UISharp SetOpacity(StyleFloat opacity);
        public UISharp SetOverflow(Overflow overflowType);
        public UISharp SetMaxHeight(StyleLength height);
        public UISharp SetMinHeight(StyleLength height);
        public UISharp SetMaxWidth(StyleLength width);
        public UISharp SetMinWidth(StyleLength width);
        public UISharp SetRotation(StyleRotate rotateValue);
        public UISharp SetJustifyContent(StyleEnum<Justify> justifyType);
        public UISharp SetLeft(StyleLength leftPosition);
        public UISharp SetRight(StyleLength rightPosition);
        public UISharp SetTop(StyleLength topPosition);
        public UISharp SetBottom(StyleLength bottomPosition);
        public UISharp SetScale(StyleScale scale);
        public UISharp SetCursor(StyleCursor cursor);
        public UISharp SetTextShadow(StyleTextShadow shadowType);
        public UISharp SetEnabled(bool enable = true);
        public UISharp SetWhiteSpace(StyleEnum<WhiteSpace> whiteSpace);
        public UISharp SetTranslate(StyleTranslate styleTranslate);
        public UISharp SetWordSpacing(StyleLength spacing);
        public UISharp SetText(string value, bool ignoreTypeMismatchError = true);
        public UISharp SetTransformOrigin(StyleTransformOrigin transformOrigin);
        public UISharp SetTransitionDelay(StyleList<TimeValue> value);
        public UISharp SetTransitionDuration(StyleList<TimeValue> value);
        public UISharp SetTransitionProperty(StyleList<StylePropertyName> value);
        public UISharp SetTransitionTiming(StyleList<EasingFunction> easeValue);
        
        //Unity sets
        public UISharp SetUBcgImageTint(StyleColor color);
        public UISharp SetUBcgScaleMode(StyleEnum<ScaleMode> scaleMode);
        public UISharp SetUFont(StyleFont font);
        public UISharp SetUFontDefinition(StyleFontDefinition styleFontDefinition);
        public UISharp SetUFontStyleAndWeight(StyleEnum<FontStyle> fontStyle);
        public UISharp SetUOverflowClipbox(StyleEnum<OverflowClipBox> overflowClipBox);
        public UISharp SetUParagraphSpacing(StyleLength styleLength);
        public UISharp SetUSliceLeft(StyleInt styleInt);
        public UISharp SetUSliceRight(StyleInt styleInt);
        public UISharp SetUSliceTop(StyleInt styleInt);
        public UISharp SetUSliceBottom(StyleInt styleInt);
        public UISharp SetUTextAlign(StyleEnum<TextAnchor> alignment);
        public UISharp SetUTextOutlineColor(StyleColor color);
        public UISharp SetUTextOutlineWidth(StyleFloat fontSize);
        public UISharp SetUTextOverflowPosition(StyleEnum<TextOverflowPosition> textOverflowPosition);
    }
}