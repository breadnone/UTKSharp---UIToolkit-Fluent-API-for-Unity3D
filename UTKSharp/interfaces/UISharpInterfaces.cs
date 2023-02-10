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

namespace UITKsharp
{
    public enum UISharpType
    {
        isVisualElement,
        isLabel,
        isDropDownField,
        isListview,
        isTextField,
        isIntegerField,
        isVector2Field,
        isVector3Field,
        isVector4Field,
        isFloatField,
        isDoubleField,
        isObjectField,
        isScrollView,
        isButton,
        isToggle,
        isToolbar,
        isSlider,
        isBox,
        isDropDownMenu,
        isToolbarMenu,
        isImage,
        isRadioButton,
        isRadioButtonGroup,
        isScroller,
        isSliderInt,
        isTwoPaneSplitView,
        isDropDownMenuItem,
        isDropDownMenuAction

    }

    public class UISharpValType<T> where T : struct
    {
        public T Value { get; set; }
    }
    public interface ISharpBulkCreate
    {
        public UISharpType UTKType();
        public void CreateArrayElement();
    }
    public class ConstructType
    {
        public VisualElement visualElement;
        public string id;
        public int index;
        public bool isParent = false;
    }
}