/*MIT License
Copyright (c) 2023 UTKSharp

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.*/

using UnityEngine;
using UnityEngine.UIElements;
using System;
using System.Collections;
using System.Collections.Generic;

namespace UITKsharp
{
    public interface ISharpStyle
    {
        public VisualElement visualElement{get;set;}
    }
    public interface ISharpResolvedStyle : ISharpStyle
    {
        //public UISharp GetSourceVisualElement(T visualElement, float value, bool dynamic = false);
        public float ResolveWidth()
        {
            return visualElement.resolvedStyle.width;
        }
        public Color ResolveColor(StyleColor color)
        {
            return visualElement.resolvedStyle.color;
        }
        public float ResolveHeight()
        {
            return visualElement.resolvedStyle.height;
        }
        public (float left, float right, float top, float bottom) ResolveMargin()
        {
            var res = visualElement.resolvedStyle;
            return (res.left, res.right, res.top, res.bottom);
        }
        public (float left, float right, float top, float bottom) ResolvePadding()
        {
            var res = visualElement.resolvedStyle;
            return (res.paddingLeft, res.paddingRight, res.paddingTop, res.paddingBottom);
        }
        public Color ResolveBackgroundColor(StyleColor color)
        {
            return visualElement.resolvedStyle.backgroundColor;
        }
        public Align ResolveAlignContent()
        {
            return visualElement.resolvedStyle.alignContent;
        }
        public Align ResolveAlignSelf()
        {
            return visualElement.resolvedStyle.alignSelf;
        }
        public Align ResolveAlignItems()
        {
            return visualElement.resolvedStyle.alignItems;
        }
        public (float leftWidth, float rightWidth, float topWidth, float bottomWidth, Color leftColor, Color rightColor, Color topColor, Color bottomColor) ResolveBorder()
        {
            var res = visualElement.resolvedStyle;
            return (res.borderLeftWidth, res.borderRightWidth, res.borderTopWidth, res.borderBottomWidth, res.borderLeftColor, res.borderRightColor, res.borderTopColor, res.borderBottomColor);
        }
        public Visibility ResolveVisibility()
        {
            return visualElement.resolvedStyle.visibility;
        }
        public DisplayStyle ResolveDisplay()
        {
            return visualElement.resolvedStyle.display;
        }
        public FlexDirection ResolveFlexDirection()
        {
            return visualElement.resolvedStyle.flexDirection;
        }
        public float ResolveFlexGrow()
        {
            return visualElement.resolvedStyle.flexGrow;
        }
        public float ResolveFlexShrink()
        {
            return visualElement.resolvedStyle.flexShrink;
        }
        public Wrap ResolveFlexWrap()
        {
            return visualElement.resolvedStyle.flexWrap;
        }
        public float ResolveFontSize()
        {
            return visualElement.resolvedStyle.fontSize;
        }
        public Position ResolvePosition()
        {
            return visualElement.resolvedStyle.position;
        }
        public float ResolveOpacity()
        {
            return visualElement.resolvedStyle.opacity;
        }
        public TextOverflow ResolveTextOverflow()
        {
            return visualElement.resolvedStyle.textOverflow;
        }
        public StyleFloat ResolveMaxHeight()
        {
            return visualElement.resolvedStyle.maxHeight;
        }
        public StyleFloat ResolveMinHeight()
        {
            return visualElement.resolvedStyle.minHeight;
        }
        public StyleFloat ResolveMaxWidth()
        {
            return visualElement.resolvedStyle.maxWidth;
        }
        public StyleFloat ResolveMinWidth()
        {
            return visualElement.resolvedStyle.minWidth;
        }
        public Rotate ResolveRotation()
        {
            return visualElement.resolvedStyle.rotate;
        }
        public Justify ResolveJustifyContent()
        {
            return visualElement.resolvedStyle.justifyContent;
        }
        public float ResolveLeft()
        {
            return visualElement.resolvedStyle.left;
        }
        public float ResolveRight()
        {
            return visualElement.resolvedStyle.right;
        }
        public float ResolveTop()
        {
            return visualElement.resolvedStyle.top;
        }
        public float ResolveBottom()
        {
            return visualElement.resolvedStyle.bottom;
        }
        public StyleScale ResolveScale()
        {
            return visualElement.resolvedStyle.scale;
        }
        public WhiteSpace ResolveWhiteSpace()
        {
            return visualElement.resolvedStyle.whiteSpace;
        }
        public Vector3 ResolveTranslate()
        {
            return visualElement.resolvedStyle.translate;
        }
        public float ResolveWordSpacing()
        {
            return visualElement.resolvedStyle.wordSpacing;
        }
        public Vector3 ResolveTransformOrigin()
        {
            return visualElement.resolvedStyle.transformOrigin;
        }
        public IEnumerable<TimeValue> ResolveTransitionDelay()
        {
            return visualElement.resolvedStyle.transitionDelay;
        }
        public IEnumerable<TimeValue> ResolveTransitionDuration()
        {
            return visualElement.resolvedStyle.transitionDuration;
        }
        public IEnumerable<StylePropertyName> ResolveTransitionProperty()
        {
            return visualElement.resolvedStyle.transitionProperty;
        }
        public IEnumerable<EasingFunction> ResolveTransitionTimingFunction()
        {
            return visualElement.resolvedStyle.transitionTimingFunction;
        }
        
        //Unity sets
        public Color ResolveUnityBackgroundImageTint()
        {
            return visualElement.resolvedStyle.unityBackgroundImageTintColor;
        }
        public ScaleMode ResolveUnityBackgroundScaleMode()
        {
            return visualElement.resolvedStyle.unityBackgroundScaleMode;
        }
        public Font ResolveUnityFont()
        {
            return visualElement.resolvedStyle.unityFont;
        }
        public FontDefinition ResolveUnityFontDefinition()
        {
            return visualElement.resolvedStyle.unityFontDefinition;
        }
        public FontStyle ResolveUnityFontStyleAndWeight()
        {
            return visualElement.resolvedStyle.unityFontStyleAndWeight;
        }
        public float ResolveUnityParagraphSpacing()
        {
            return visualElement.resolvedStyle.unityParagraphSpacing;
        }
        public int ResolveUnitySliceLeft()
        {
            return visualElement.resolvedStyle.unitySliceLeft;
        }
        public int ResolveUnitySliceRight()
        {
            return visualElement.resolvedStyle.unitySliceRight;
        }
        public int ResolveUnitySliceTop()
        {
            return visualElement.resolvedStyle.unitySliceTop;
        }
        public int ResolveUnitySliceBottom()
        {
            return visualElement.resolvedStyle.unitySliceBottom;
        }
        public TextAnchor ResolveUnityTextAlign()
        {
            return visualElement.resolvedStyle.unityTextAlign;
        }
        public Color ResolveUnityTextOutlineColor()
        {
            return visualElement.resolvedStyle.unityTextOutlineColor;
        }
        public float ResolveUnityTextOutlineWidth()
        {
            return visualElement.resolvedStyle.unityTextOutlineWidth;
        }
        public TextOverflowPosition ResolveUnityTextOverflowPosition()
        {
            return visualElement.resolvedStyle.unityTextOverflowPosition;
        }
    }
    
}