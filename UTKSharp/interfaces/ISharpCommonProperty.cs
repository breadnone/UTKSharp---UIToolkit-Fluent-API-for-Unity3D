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

using UnityEngine;
using System;
using UnityEngine.UIElements;

namespace UITKsharp
{
    public interface ISharpCommonProp <T> where T : UISharp
    {
        public VisualElement GetContentContainer(VisualElement visualElement)
        {
            return visualElement.contentContainer;
        }
        public Rect GetContentRect(VisualElement visualElement)
        {
            return visualElement.contentRect;
        }
        public bool IsEnabledInHierarchy(VisualElement visualElement)
        {
            return visualElement.enabledInHierarchy;
        }
        public bool IsEnabledSelf(VisualElement visualElement)
        {
            return visualElement.enabledSelf;
        }
        public Rect GetLayout(VisualElement visualElement)
        {
            return visualElement.layout;
        }
        public void InsertElementAt(VisualElement visualElement, int index)
        {
            visualElement.Insert(index, visualElement);
        }
        public IPanel Panel(VisualElement visualElement)
        {
            return visualElement.panel;
        }
        public ITransform GetTransform(VisualElement visualElement)
        {
            return visualElement.transform;
        }
        public void SetTooltip(VisualElement visualElement, string stringValue)
        {
            visualElement.tooltip = stringValue;
        }
        public VisualElement GetChildAtIndex(VisualElement visualElement, int childIndex)
        {
            return visualElement.ElementAt(childIndex);
        }
        public void SetPickingMode(VisualElement visualElement, PickingMode mousePickingMode)
        {
            visualElement.pickingMode = mousePickingMode;
        }
        public Matrix4x4 GetWorldTransform(VisualElement visualElement)
        {
            return visualElement.worldTransform;
        }
        public UsageHints GetUsageHints(VisualElement visualElement)
        {
            return visualElement.usageHints;
        }
        public Rect GetLocalBound(VisualElement visualElement)
        {
            return visualElement.localBound;
        }
        public string GetViewDataKey(VisualElement visualElement)
        {
            return visualElement.viewDataKey;
        }
        public ICustomStyle CustomStyle(VisualElement visualElement)
        {
            return visualElement.customStyle;
        }
    }
    public interface ISharpBinding
    {
        public UISharp BindingPath(string bindingpath);
        public UISharp Binding(IBinding ibind);
    
    }
}