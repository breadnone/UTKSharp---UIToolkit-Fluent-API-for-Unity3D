using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq.Expressions;
using System.Reflection;
using UnityEngine.UIElements;
using System.Linq;

#if UNITY_EDITOR

#endif

namespace UITKsharp
{
    [System.Serializable]
    public class UTKStyleTemplate
    {
        public UISharp templateStyle;
        public IStyle styleInterface; 
        public string templateName;
        public string templateId;
    }
    [System.Serializable]
    public class SharpStyleClass : ScriptableObject
    {
        public List<UTKStyleTemplate> templates = new List<UTKStyleTemplate>();
    }
    public static class UISharpUtil
    {
        public static void CopyStyle(IStyle source, IStyle target)
        {
            target.alignContent = source.alignContent;
            target.alignItems = source.alignItems;
            target.alignSelf = source.alignSelf;

            target.backgroundColor = source.backgroundColor;
            target.backgroundImage = source.backgroundImage;
            target.borderBottomColor = source.borderBottomColor;
            target.borderLeftColor = source.borderLeftColor;
            target.borderRightColor = source.borderRightColor;
            target.borderTopColor = source.borderTopColor;

            target.borderBottomLeftRadius = source.borderBottomLeftRadius;
            target.borderBottomRightRadius = source.borderBottomRightRadius;
            target.borderTopWidth = source.borderTopWidth;
            target.borderBottomWidth = source.borderBottomWidth;
            target.borderLeftWidth = source.borderLeftWidth;
            target.borderRightWidth = source.borderRightWidth;

            target.color = source.color;
            target.cursor = source.cursor;
            target.display = source.display;
            
            target.flexBasis = source.flexBasis;
            target.flexDirection = source.flexDirection;
            target.flexGrow = source.flexGrow;
            target.flexShrink = source.flexShrink;
            target.flexWrap = source.flexWrap;
            
            target.fontSize = source.fontSize;
            target.height = source.height;
            target.width = source.width;
            target.justifyContent = source.justifyContent;
            
            target.left = source.left;
            target.right = source.right;
            target.top = source.top;
            target.bottom = source.bottom;

            target.letterSpacing = source.letterSpacing;

            target.marginBottom = source.marginBottom;
            target.marginLeft = source.marginLeft;
            target.marginRight = source.marginRight;
            target.marginTop = source.marginTop;

            target.maxWidth = source.maxWidth;
            target.maxHeight = source.maxHeight;
            target.minHeight = source.minHeight;

            target.opacity = source.opacity;
            target.overflow = source.overflow;

            target.paddingBottom = source.paddingBottom;
            target.paddingLeft = source.paddingLeft;
            target.paddingRight = source.paddingRight;
            target.paddingTop = source.paddingTop;

            target.position = source.position;
            target.rotate = source.rotate;
            target.scale = source.scale;
            target.textOverflow = source.textOverflow;
            target.textShadow = source.textShadow;
            target.transformOrigin = source.transformOrigin;
            target.transitionDelay = source.transitionDelay;
            target.transitionDuration = source.transitionDuration;
            target.transitionProperty = source.transitionProperty;
            target.transitionTimingFunction = source.transitionTimingFunction;
            target.translate = source.translate;

            target.unityBackgroundImageTintColor = source.unityBackgroundImageTintColor;
            target.unityBackgroundScaleMode = source.unityBackgroundScaleMode;
            target.unityFont = source.unityFont;
            target.unityFontDefinition = source.unityFontDefinition;
            target.unityFontStyleAndWeight = source.unityFontStyleAndWeight;
            target.unityOverflowClipBox = source.unityOverflowClipBox;
            target.unityParagraphSpacing = source.unityParagraphSpacing;
            target.unitySliceBottom = source.unitySliceBottom;
            target.unitySliceLeft = source.unitySliceLeft;
            target.unitySliceRight = source.unitySliceRight;
            target.unitySliceTop = source.unitySliceTop;
            target.unityTextAlign = source.unityTextAlign;
            target.unityTextOutlineColor = source.unityTextOutlineColor;
            target.unityTextOutlineWidth = source.unityTextOutlineWidth;
            target.unityTextOverflowPosition = source.unityTextOverflowPosition;
            target.visibility = source.visibility;
            target.whiteSpace = source.whiteSpace;
            target.wordSpacing = source.wordSpacing;
        }

        public static UISharp UseTemplate(this UISharp targetElement, string templateName, bool repaint = false)
        {
            if(String.IsNullOrEmpty(templateName) || targetElement == null)
                return null;
            
            (IStyle style, SharpStyleClass sharpStyle) source = (null, null);

            source = UTKManager.GetTemplate(templateName);
            var target = targetElement.visualElement.style;
            UISharpUtil.CopyStyle(source.style, target);

            if(repaint)
            {
                targetElement.visualElement.MarkDirtyRepaint();
            }

            return targetElement;
        }
    }
}