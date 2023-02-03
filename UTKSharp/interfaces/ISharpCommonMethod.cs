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

using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;

namespace UITKsharp
{
    public interface ISharpCommonMethod
    {
        public VisualElement visualElement{get;set;}
        public int GetChildCount()
        {
            return visualElement.childCount;
        }
        public IEnumerable<VisualElement> GetChildren()
        {
            return visualElement.Children();
        }
        public VisualElement GetChild(string nameIdentifier, string uid)
        {
            if (visualElement == null || (String.IsNullOrEmpty(nameIdentifier) && String.IsNullOrEmpty(uid)))
                throw new System.Exception("UISharp : VisualElement and nameIdentifier/uid can't be null!");

            VisualElement child = null;

            foreach(var cld in visualElement.Children())
            {
                if(nameIdentifier != null)
                {
                    if(cld.name == nameIdentifier)
                        child = cld;
                }
                else if(uid != null)
                {
                    throw new Exception("UISharp : Child finding based on UID not yet implemented!");
                }
            }
            return child;
        }
        public void ClearChildren()
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.Clear();
        }
        public bool IsParentContainsChild(VisualElement child)
        {
            if (visualElement == null || child == null)
                throw new System.Exception("UISharp : VisualElement and child can't be null!");

            return visualElement.Contains(child);
        }
        public VisualElement GetChildAtIndex(int? index)
        {
            if (visualElement == null || !index.HasValue)
                throw new System.Exception("UISharp : VisualElement and index can't be null!");

            return visualElement.ElementAt(index.Value);
        }
        public int GetChildIndex(VisualElement child)
        {
            if (visualElement == null || child == null)
                throw new System.Exception("UISharp : VisualElement and child can't be null!");

            return visualElement.IndexOf(child);
        }
        public bool IsContainPoints(Vector2? localPoint)
        {
            if (visualElement == null || !localPoint.HasValue)
                throw new System.Exception("UISharp : VisualElement and localPoint can't be null!");

            return visualElement.ContainsPoint(localPoint.Value);
        }
        public void InsertElementAt(VisualElement child, int? index)
        {
            if (visualElement == null || child == null || !index.HasValue)
                throw new System.Exception("UISharp : VisualElement and nameIdentifier/uid can't be null!");

            visualElement.Insert(index.Value, child);
        }
        public void PlaceInFront(VisualElement thatVisualElement)
        {
            if (visualElement == null || thatVisualElement == null)
                throw new System.Exception("UISharp : VisualElements can't be null!");

            visualElement.PlaceInFront(thatVisualElement);
        }
        public void PlaceBehind(VisualElement thatVisualElement)
        {
            if (visualElement == null || thatVisualElement == null)
                throw new System.Exception("UISharp : VisualElements can't be null!");

            visualElement.PlaceBehind(thatVisualElement);
        }
        public void Remove(VisualElement childToBeRemoved)
        {
            if (visualElement == null || childToBeRemoved == null)
                throw new System.Exception("UISharp : VisualElements can't be null!");

            visualElement.Remove(childToBeRemoved);
        }
        public void RemoveAt(int? index)
        {
            if (visualElement == null || !index.HasValue)
                throw new System.Exception("UISharp : VisualElement and index can't be null!");

            visualElement.RemoveAt(index.Value);
        }
        public void RemoveFromHierarchy()
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.RemoveFromHierarchy();
        }
        public void SendToBack()
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.SendToBack();
        }
        public void Focus()
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.Focus();
        }
        public void Blur()
        {
            if (visualElement == null)
                throw new System.Exception("UISharp : VisualElement can't be null!");

            visualElement.Blur();
        }
    }
}