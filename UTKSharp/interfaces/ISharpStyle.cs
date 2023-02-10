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
        public UISharp Width(float value, bool dynamic = false);
        public UISharp Color(StyleColor color);
        public UISharp Height(float value, bool dynamic = false);
        public UISharp Margin(float? leftValue, float? rightValue, float? topValue, float? bottomValue);
        public UISharp Padding(float? left, float? right, float? top, float? bottom);
        public UISharp BackgroundColor(StyleColor color);
        public UISharp AlignContent(Align alignment);
        public UISharp AlignSelf(Align alignment);
        public UISharp AlignItems(Align alignment);
        public UISharp Border(StyleColor color, float width);
        public UISharp Visibility(bool isVisible = true);
        public UISharp Display(DisplayStyle displayType);
        public UISharp FlexDirection(FlexDirection flexType);
        public UISharp FlexGrow(StyleFloat value);
        public UISharp FlexShrink(StyleFloat value);
        public UISharp FlexWrap(Wrap wrap);
        public UISharp FontSize(StyleLength size);
        public UISharp Position(StyleEnum<Position> pos);
        public UISharp Opacity(StyleFloat opacity);
        public UISharp Overflow(Overflow overflowType);
        public UISharp MaxHeight(StyleLength height);
        public UISharp MinHeight(StyleLength height);
        public UISharp MaxWidth(StyleLength width);
        public UISharp MinWidth(StyleLength width);
        public UISharp Rotation(StyleRotate rotateValue);
        public UISharp JustifyContent(StyleEnum<Justify> justifyType);
        public UISharp Left(StyleLength leftPosition);
        public UISharp Right(StyleLength rightPosition);
        public UISharp Top(StyleLength topPosition);
        public UISharp Bottom(StyleLength bottomPosition);
        public UISharp Scale(StyleScale scale);
        public UISharp Cursor(StyleCursor cursor);
        public UISharp TextShadow(StyleTextShadow shadowType);
        public UISharp SetEnabled(bool enable = true);
        public UISharp WhiteSpace(StyleEnum<WhiteSpace> whiteSpace);
        public UISharp Translate(StyleTranslate styleTranslate);
        public UISharp WordSpacing(StyleLength spacing);
        public UISharp Text(string value, bool ignoreTypeMismatchError = true);
        public UISharp TransformOrigin(StyleTransformOrigin transformOrigin);
        public UISharp TransitionDelay(StyleList<TimeValue> value);
        public UISharp TransitionDuration(StyleList<TimeValue> value);
        public UISharp TransitionProperty(StyleList<StylePropertyName> value);
        public UISharp TransitionTiming(StyleList<EasingFunction> easeValue);
        
        //Unity sets
        public UISharp UnityBackgroundImageTint(StyleColor color);
        public UISharp UnityBackgroundScaleMode(StyleEnum<ScaleMode> scaleMode);
        public UISharp UnityFont(StyleFont font);
        public UISharp UnityFontDefinition(StyleFontDefinition styleFontDefinition);
        public UISharp UnityFontStyleAndWeight(StyleEnum<FontStyle> fontStyle);
        public UISharp UnityOverflowClipbox(StyleEnum<OverflowClipBox> overflowClipBox);
        public UISharp UnityParagraphSpacing(StyleLength styleLength);
        public UISharp UnitySliceLeft(StyleInt styleInt);
        public UISharp UnitySliceRight(StyleInt styleInt);
        public UISharp UnitySliceTop(StyleInt styleInt);
        public UISharp UnitySliceBottom(StyleInt styleInt);
        public UISharp UnityTextAlign(StyleEnum<TextAnchor> alignment);
        public UISharp UnityTextOutlineColor(StyleColor color);
        public UISharp UnityTextOutlineWidth(StyleFloat fontSize);
        public UISharp UnityTextOverflowPosition(StyleEnum<TextOverflowPosition> textOverflowPosition);
    }
    public interface ISharpResolvedStyle
    {
        //public UISharp GetSourceVisualElement(T visualElement, float value, bool dynamic = false);
        public UISharp ResolveWidth(float value, bool dynamic = false);
        public UISharp ResolveColor(StyleColor color);
        public UISharp ResolveHeight(float value, bool dynamic = false);
        public UISharp ResolveMargin(float? leftValue, float? rightValue, float? topValue, float? bottomValue);
        public UISharp ResolvePadding(float? left, float? right, float? top, float? bottom);
        public UISharp ResolveBackgroundColor(StyleColor color);
        public UISharp ResolveAlignContent(Align alignment);
        public UISharp ResolveAlignSelf(Align alignment);
        public UISharp ResolveAlignItems(Align alignment);
        public UISharp ResolveBorder(StyleColor color, float width);
        public UISharp ResolveVisibility(bool isVisible = true);
        public UISharp ResolveDisplay(DisplayStyle displayType);
        public UISharp ResolveFlexDirection(FlexDirection flexType);
        public UISharp ResolveFlexGrow(StyleFloat value);
        public UISharp ResolveFlexShrink(StyleFloat value);
        public UISharp ResolveFlexWrap(Wrap wrap);
        public UISharp ResolveFontSize(StyleLength size);
        public UISharp ResolvePosition(StyleEnum<Position> pos);
        public UISharp ResolveOpacity(StyleFloat opacity);
        public UISharp ResolveOverflow(Overflow overflowType);
        public UISharp ResolveMaxHeight(StyleLength height);
        public UISharp ResolveMinHeight(StyleLength height);
        public UISharp ResolveMaxWidth(StyleLength width);
        public UISharp ResolveMinWidth(StyleLength width);
        public UISharp ResolveRotation(StyleRotate rotateValue);
        public UISharp ResolveJustifyContent(StyleEnum<Justify> justifyType);
        public UISharp ResolveLeft(StyleLength leftPosition);
        public UISharp ResolveRight(StyleLength rightPosition);
        public UISharp ResolveTop(StyleLength topPosition);
        public UISharp ResolveBottom(StyleLength bottomPosition);
        public UISharp ResolveScale(StyleScale scale);
        public UISharp ResolveCursor(StyleCursor cursor);
        public UISharp ResolveTextShadow(StyleTextShadow shadowType);
        public UISharp ResolveWhiteSpace(StyleEnum<WhiteSpace> whiteSpace);
        public UISharp ResolveTranslate(StyleTranslate styleTranslate);
        public UISharp ResolveWordSpacing(StyleLength spacing);
        public UISharp ResolveText(string value, bool ignoreTypeMismatchError = true);
        public UISharp ResolveTransformOrigin(StyleTransformOrigin transformOrigin);
        public UISharp ResolveTransitionDelay(StyleList<TimeValue> value);
        public UISharp ResolveTransitionDuration(StyleList<TimeValue> value);
        public UISharp ResolveTransitionProperty(StyleList<StylePropertyName> value);
        public UISharp ResolveTransitionTiming(StyleList<EasingFunction> easeValue);
        
        //Unity sets
        public UISharp ResolveUnityBackgroundImageTint(StyleColor color);
        public UISharp ResolveUnityBackgroundScaleMode(StyleEnum<ScaleMode> scaleMode);
        public UISharp ResolveUnityFont(StyleFont font);
        public UISharp ResolveUnityFontDefinition(StyleFontDefinition styleFontDefinition);
        public UISharp ResolveUnityFontStyleAndWeight(StyleEnum<FontStyle> fontStyle);
        public UISharp ResolveUnityOverflowClipbox(StyleEnum<OverflowClipBox> overflowClipBox);
        public UISharp ResolveUnityParagraphSpacing(StyleLength styleLength);
        public UISharp ResolveUnitySliceLeft(StyleInt styleInt);
        public UISharp ResolveUnitySliceRight(StyleInt styleInt);
        public UISharp ResolveUnitySliceTop(StyleInt styleInt);
        public UISharp ResolveUnitySliceBottom(StyleInt styleInt);
        public UISharp ResolveUnityTextAlign(StyleEnum<TextAnchor> alignment);
        public UISharp ResolveUnityTextOutlineColor(StyleColor color);
        public UISharp ResolveUnityTextOutlineWidth(StyleFloat fontSize);
        public UISharp ResolveUnityTextOverflowPosition(StyleEnum<TextOverflowPosition> textOverflowPosition);
    }
}