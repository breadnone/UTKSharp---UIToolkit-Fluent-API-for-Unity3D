/*
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
using System;
using UnityEngine.UIElements;

namespace UITKsharp
{
    public interface ISharpCommonProp
    {
        public void SetName(string name);
        public void SetParent(VisualElement child, VisualElement parent, bool markDirtyRepaint = false);
        public VisualElement GetContentContainer();
        public Rect GetContentRect();
        public bool IsEnabledInHierarchy();
        public bool IsEnabledSelf();
        public void SetSchedule(VisualElement scheduledVisualElement, VisualElement waitedVisualElement, Action act, float delayTime = 1f);
        public Rect GetLayout();
        public VisualElement GetElementAt(int index);
        public void InsertElementAt(int index);
        public void RemoveVisualElement(UISharpValType<float> executeAfter = null, Action onComplete = null);
        public void RemoveVisualElementAt(UISharpValType<float> executeAfter = null, Action onComplete = null);
        public VisualElement GetPanel(VisualElement visualElement);
        public ITransform GetTransform(VisualElement visualElement);
        public void SetTooltip(VisualElement visualElement, string stringValue);
        public VisualElement GetChildAtIndex(VisualElement visualElement, int childIndex);
        public void SetPickingMode(VisualElement visualElement, PickingMode mousePickingMode);
        public Matrix4x4 GetWorldTransform(VisualElement visualElement);
        public UsageHints GetUsageHints(VisualElement visualElement);
        public Rect GetLocalBound(VisualElement visualElement);
        public string GetViewDataKey(VisualElement visualElement);
    }
}