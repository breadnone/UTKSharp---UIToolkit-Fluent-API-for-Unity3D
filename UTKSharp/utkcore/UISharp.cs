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
using UnityEngine.UIElements;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

//VisualElement visualElement = new VisualElement();
//var parentVisualElement = new VisualElement();
//Sets style                ::  UTKSharp.style(visualElement).SetBcgColor(Color.blue).SetParent(parentVisualElement).Name("childAsName");
//Adds Event                ::  UTKSharp.addEvent(visualElement).SetOnMouseDown((x)=> Debug.Log("KeyPressed!"));
//Instantiate Box element   ::  UTKSharp.boxElement(new Box()).Width(100, dynamic: true).Height(50, dynamic: true).AlignContent(Align.Center);
//Gets child                ::  parentVisualElement = UTKSharp.GetChild(parentVisualElement, "childAsName");
//Returns self              ::  var vis =  UTKSharp.style(new VisualElement()).Name("viInstance").Return();

/* UTKSharp.construct
var parentOne = new VisualElement(); var childOne = new VisualElement();
var parentTwo = new VisualElement(); var childTwo = new VisualElement();

//Constructing layout based on the method chain
UTKSharp.construct().Parent(parentOne).Child(childOne).Child(childOne).Parent(parentTwo).Child(childTwo);

//Returns root of a hierarchy
var getRoot = UTKSharp.construct().Parent(parentOne).Child(childTwo).ReturnRoot();

//Parent as root, or else the default will be created
UTKSharp.construct().Parent(parentOne, asRoot: true).Child(childTwo);

//GetElement method to get the reference to visualElement in the current chain
var childOne = new VisualElement();
var childTwo = new VisualElement();
UTKSharp.construct().Parent(new VisualElement(), "parent").Child(childOne).GetElementAsParent("parent").Child(childTwo);

//Constructing custom splitView in single line.
var custom = UTKSharp.customSplitView(50, 50, 5, true).AddPanel(100, 100, id:1).SplitPanel(3, "custom-no", true);

//Returns sub-panels
VisualElement[] customSView = custom.ReturnSubPanels();
*///////////////////

namespace UITKsharp
{
    /// <summary>UTKSharp main class.</summary>
    public static class UTKSharp
    {
        /// <summary>Generates custom splitView.</summary>
        /// <param name="width">The width of the VisualElement.</param>
        /// <param name="height">The height of the VisualElement.</param>
        /// <param name="margin">The top, left, right, bottom margin in single value.</param>
        /// <param name="dynamic">Dynamic layout. Default is true.</param>
        public static UTKMakeSplit customSplitView(float width, float height, float margin, bool dynamic = true)
        {
            return new UTKMakeSplit(null, width, height, margin, dynamic);
        }

        /// <summary>Constructing layout in a method chain.</summary>
        /// <param name="customRoot">The parent VisualElement to get the children.</param>
        /// <param name="restrictive">Supresses warning.</param>
        public static UISharpConstruct construct(VisualElement customRoot = null, bool restrictive = false)
        {
            return new UISharpConstruct(customRoot, restrictive);
        }

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
        public static UISharpProgressBar progreeeBarElement(ProgressBar progressBar)
        {
            var uielement = new UISharpProgressBar(progressBar);
            return uielement;
        }

        /// <summary>Instantiates Box UIElement.</summary>
        /// <param name="box">The Box object.</param>
        public static UISharpBox boxElement(Box box)
        {
            var uielement = new UISharpBox(box);
            return uielement;
        }

        /// <summary>Instantiates PopUpWindow UIElement.</summary>
        /// <param name="popupWindow">The PopUpWindow object.</param>
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
    }

    /// <summary>Layouting class.</summary>
    /// <param name="customRoot">Custom root to be used instead of default</param>
    /// <param name="restrictive">Supress warnings.</param>
    public class UISharpConstruct
    {
        public string UISharpID { get; set; }
        private VisualElement root { get; set; }
        private List<(VisualElement visualElement, string visName, int? id)> elements = new List<(VisualElement visualElement, string visName, int? id)>();
        private bool startIsParent = false;
        private VisualElement currentParent;

        /// <summary>Layouting class.</summary>
        /// <param name="customRoot">Custom root to be used instead of default</param>
        /// <param name="restrictive">Supress warnings.</param>
        public UISharpConstruct(VisualElement customRoot = null, bool restrictive = false)
        {
            UISharpID = Guid.NewGuid().ToString() + UnityEngine.Random.Range(int.MinValue, int.MaxValue);
            root = customRoot;
        }
        
        /// <summary>Parent VisualElement that will be assigned to a child in the next chain.</summary>
        /// <param name="parentName">Name identifier for the parent</param>
        /// <param name="id">Unique identifier for the parent.</param>
        /// <param name="asRoot">Acts as root.</param>
        public UISharpConstruct Parent(VisualElement parentVisualElement, string parentName = "", int? id = null, bool asRoot = false)
        {
            if (!startIsParent)
            {
                startIsParent = true;

                if (!asRoot)
                    root.Add(parentVisualElement);
                else
                    root = parentVisualElement;
            }

            if (String.IsNullOrEmpty(parentName) && !id.HasValue)
                throw new Exception("UTKSharp : Either parentName or id must be filled!");

            if (parentVisualElement == null)
                throw new Exception("UTKSharp : Parent VisualElement can't be null");

            if (id.HasValue && !elements.Exists(x => x.id == id.Value))
            {
                elements.Add((parentVisualElement, null, id.Value));
            }
            else if (!String.IsNullOrEmpty(parentName) && !elements.Exists(x => x.visName == parentName))
            {
                elements.Add((parentVisualElement, parentName, null));
            }

            currentParent = parentVisualElement;

            if (root != parentVisualElement && !root.Contains(parentVisualElement))
                root.Add(parentVisualElement);

            return this;
        }

        /// <summary>Child VisualElement that will be assigned to a parent int the prev chain.</summary>
        /// <param name="childName">Name identifier for the child</param>
        /// <param name="id">Unique identifier for the child.</param>
        /// <param name="setAsParent">Acts as parent.Default is false</param>
        public UISharpConstruct Child(VisualElement childElement, string childName = "", int? id = null, bool setAsparent = false)
        {
            if (!startIsParent)
                throw new Exception("UTKsharp : The sequence/chain must be started with Parent method. e.g: Parent(parentVisualElement).Child(childVisualElement)...etc.");

            if (!currentParent.Contains(childElement))
            {
                currentParent.Add(childElement);
            }
            else
            {
                throw new Exception("UTKSharp : Child already parented to the same parent VisualElement");
            }

            if (setAsparent)
                currentParent = childElement;

            if (!elements.Exists(x => x.visualElement == childElement))
            {
                if (id.HasValue)
                    elements.Add((childElement, childName, id.Value));
                else
                    elements.Add((childElement, childName, null));
            }

            return this;
        }

        /// <summary>Gets VisualElement that will act as parent regardless their previous position in this chain.</summary>
        /// <param name="name">Get by name(must be assigned previously). The default behavior.</param>
        /// <param name="id">Get by id(must be assigned previously).</param>
        public UISharpConstruct GetAsParent(string name, int? id = null)
        {
            if (!String.IsNullOrEmpty(name))
            {
                currentParent = elements.Find(x => x.visName == name).visualElement;
            }
            else if (id.HasValue)
            {
                currentParent = elements.Find(x => x.id == id.Value).visualElement;
            }

            if (currentParent == null)
                throw new Exception("UTKSharp : Parent can't be found! Make sure the name/id is correct!");

            return this;
        }
        /// <summary>Returns the root VisualElement.</summary>
        public VisualElement ReturnRoot()
        {
            return root;
        }
        /// <summary>Returns the children of the root.</summary>
        public VisualElement[] ReturnChildren()
        {
            return root.Children().ToArray();
        }
    }
    public class UISharp : UIEvent, ISharpCommonMethod, ISharpBinding, ISharpStyle
    {
        /// <summary>ID for every UTK instances</summary>
        public string UISharpID { get; set; }

        /// <summary>The VisualElement</summary>
        public VisualElement visualElement { get; set; }

        public UISharp(VisualElement visualelement) : base(visualelement)
        {
            UISharpID = Guid.NewGuid().ToString() + UnityEngine.Random.Range(int.MinValue, int.MaxValue);
            visualElement = visualelement;
        }
        /// <summary>Color of VisualElement.</summary>
        /// <param name="color">Type of alignment.</param>
        public UISharp Color(StyleColor color)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.color = color;
            return this;
        }
        /// <summary>Set content alignment of VisualElement.</summary>
        /// <param name="alignment">Type of alignment.</param>
        public UISharp AlignContent(Align alignment = Align.Auto)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.alignContent = alignment;
            return this;
        }

        /// <summary>Sets self alignment of VisualElement.</summary>
        /// <param name="alignment">Type of alignment.</param>
        public UISharp AlignSelf(Align alignment = Align.Auto)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.alignSelf = alignment;
            return this;
        }

        /// <summary>Sets items alignment of VisualElement.</summary>
        /// <param name="alignment">Type of alignment.</param>
        public UISharp AlignItems(Align alignment = Align.Auto)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.alignItems = alignment;
            return this;
        }

        /// <summary>Sets border property of VisualElement.</summary>
        /// <param name="color">Color of the border.</param>
        /// <param name="width">Width of the border.</param>
        public UISharp Border(StyleColor color, float width)
        {
            if (visualElement == null || color == null)
                throw new System.Exception("UTKSharp : VisualElement and Color can't be null!");

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
        public UISharp Position(StyleEnum<Position> value)
        {
            if (visualElement == null || value == null)
                throw new System.Exception("UTKSharp : VisualElement and position value can't be null!");

            visualElement.style.position = value;
            return this;
        }

        /// <summary>Sets opacity of style.opacity property to a VisualElement.</summary>
        /// <param name="value">New opacity value (0-1 min/max ratio) to be assigned.</param>
        public UISharp Opacity(StyleFloat value)
        {
            if (visualElement == null || value == null)
                throw new System.Exception("UTKSharp : VisualElement and position value can't be null!");

            visualElement.style.opacity = value;
            return this;
        }

        /// <summary>Sets overflow of style.overflow property to a VisualElement.</summary>
        /// <param name="overflow">New position to be assigned.</param>
        public UISharp Overflow(Overflow overflow = UnityEngine.UIElements.Overflow.Visible)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.overflow = overflow;
            return this;
        }

        /// <summary>Sets maximum height of style.maxHeight property to a VisualElement.</summary>
        /// <param name="value">New maxHeight value to be assigned.</param>
        public UISharp MaxHeight(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.maxHeight = value;
            return this;
        }

        /// <summary>Sets minimum height of style.maxHeight property to a VisualElement.</summary>
        /// <param name="value">New minHeight value to be assigned.</param>
        public UISharp MinHeight(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.minHeight = value;
            return this;
        }

        /// <summary>Sets maximum width of style.maxWidth property to a VisualElement.</summary>
        /// <param name="value">New maxWidth value to be assigned.</param>
        public UISharp MaxWidth(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.maxWidth = value;
            return this;
        }
        /// <summary>Sets minimum width of style.minWidth property to a VisualElement.</summary>
        /// <param name="value">New minWidth value to be assigned.</param>
        public UISharp MinWidth(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.minWidth = value;
            return this;
        }

        /// <summary>Sets rotation of style.rotate property to a VisualElement.</summary>
        /// <param name="value">Rotation value to be assigned.</param>
        public UISharp Rotation(StyleRotate value)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.rotate = value;
            return this;
        }

        /// <summary>Justifies content of a VisualElement.</summary>
        /// <param name="value">New minWidth value to be assigned.</param>
        public UISharp JustifyContent(StyleEnum<Justify> value)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.justifyContent = value;
            return this;
        }

        /// <summary>Assign left value of a style.left to VisualElement.</summary>
        /// <param name="value">StyleLength value to be assigned.</param>
        public UISharp Left(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.left = value;
            return this;
        }

        /// <summary>Assign right value of a style.right to VisualElement.</summary>
        /// <param name="value">StyleLength value to be assigned.</param>
        public UISharp Right(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.right = value;
            return this;
        }

        /// <summary>Assign top value of a style.top to VisualElement.</summary>
        /// <param name="value">StyleLength value to be assigned.</param>
        public UISharp Top(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.top = value;
            return this;
        }

        /// <summary>Assign bottom value of a style.bottom to VisualElement.</summary>
        /// <param name="value">StyleLength value to be assigned.</param>
        public UISharp Bottom(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.bottom = value;
            return this;
        }

        /// <summary>Assign scale value of a style.scale to VisualElement.</summary>
        /// <param name="value">StyleScale value to be assigned.</param>
        public UISharp Scale(StyleScale value)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.scale = value;
            return this;
        }

        /// <summary>Sets cursor when overed on top of VisualElement.</summary>
        /// <param name="value">StyleCursor value to be assigned.</param>
        public UISharp Cursor(StyleCursor value)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.cursor = value;
            return this;
        }

        /// <summary>Sets bacground scale mode of VisualElement.</summary>
        /// <param name="value">StyleCursor value to be assigned.</param>
        public UISharp BackgroundScaleMode(StyleEnum<ScaleMode> value)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.unityBackgroundScaleMode = value;
            return this;
        }

        /// <summary>Sets drop shadow of a TextElement.</summary>
        /// <param name="value">StyleTextShadow value to be assigned.</param>
        public UISharp TextShadow(StyleTextShadow value)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.textShadow = value;
            return this;
        }

        /// <summary>Sets spacing of TextElement.</summary>
        /// <param name="value">StyleLength value to be assigned.</param>
        public UISharp WordSpacing(StyleLength value)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.wordSpacing = value;
            return this;
        }

        /// <summary>Sets spacing of TextElement.</summary>
        /// <param name="value">String value to be assigned.</param>
        /// <param name="ignoreTypeMismatchError">Ignores type mismatch warnings/throws.</param>
        public UISharp Text(string value, bool ignoreTypeMismatchError = true)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

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
                    throw new Exception("UTKSharp : VisualElement not compatible with text");
            }
            return this;
        }

        /// <summary>Sets transition delay of VisualElement.</summary>
        /// <param name="value">StyleList timeValue value to be assigned.</param>
        public UISharp TransitionDelay(StyleList<TimeValue> value)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.transitionDelay = value;
            return this;
        }

        /// <summary>Sets transition property of VisualElement.</summary>
        /// <param name="value">StyleList propertyName value to be assigned.</param>
        public UISharp TransitionProperty(StyleList<StylePropertyName> value)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.transitionProperty = value;
            return this;
        }

        /// <summary>Sets transition origin of VisualElement.</summary>
        /// <param name="value">StyleTransformOrigin value to be assigned.</param>
        public UISharp TransformOrigin(StyleTransformOrigin value)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.transformOrigin = value;
            return this;
        }

        /// <summary>Sets transition easing option of VisualElement.</summary>
        /// <param name="value">Stylelist easingFunction value to be assigned.</param>
        public UISharp TransitionTiming(StyleList<EasingFunction> value)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.transitionTimingFunction = value;
            return this;
        }

        /// <summary>Sets transition duration of VisualElement.</summary>
        /// <param name="value">StyleList timeValue value to be assigned.</param>
        public UISharp TransitionDuration(StyleList<TimeValue> value)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.transitionDuration = value;
            return this;
        }

        /// <summary>Sets transition property of VisualElement.</summary>
        /// <param name="value">StyleList easingFunction  value to be assigned.</param>
        public UISharp TransitionProperty(StyleList<EasingFunction> value)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.transitionTimingFunction = value;
            return this;
        }

        /// <summary>Enable/disable a VisualElement.</summary>
        /// <param name="value">Enable state of a VisualElement.</param>
        public UISharp SetEnabled(bool value = true)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.SetEnabled(value);
            return this;
        }

        /// <summary>Word wrapping over multiple lines if not enough space is available to draw the text of an element.</summary>
        /// <param name="value">Value to be assigned.</param>
        public UISharp WhiteSpace(StyleEnum<WhiteSpace> value)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.whiteSpace = value;
            return this;
        }

        /// <summary>Sets padding of a VisualElement.</summary>
        /// <param name="left">Left side padding.</param>
        /// <param name="right">Right side padding.</param>
        /// <param name="top">Top side padding.</param>
        /// <param name="bottom">Bottom side padding.</param>
        public UISharp Padding(float? left, float? right, float? top, float? bottom)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

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
        public UISharp Visibility(bool enable = true)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            if (enable)
                visualElement.style.visibility = UnityEngine.UIElements.Visibility.Visible;
            else
                visualElement.style.visibility = UnityEngine.UIElements.Visibility.Hidden;
            return this;
        }

        /// <summary>Defines how a VisualElement displayed in a layout.</summary>
        /// <param name="displayStyle">Display style of a VisualElement in a layout.</param>
        public UISharp Display(DisplayStyle displayStyle = DisplayStyle.Flex)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.display = displayStyle;
            return this;
        }

        /// <summary>Translate transformation.</summary>
        /// <param name="value">Translate value.</param>
        public UISharp Translate(StyleTranslate value)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.translate = value;
            return this;
        }

        /// <summary>Direction type of an axis.</summary>
        /// <param name="value">Directions type to the axis.</param>
        public UISharp FlexDirection(FlexDirection flexDirection)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            visualElement.style.flexDirection = flexDirection;
            return this;
        }

        /// <summary>Direction type of an axis.</summary>
        /// <param name="value">Shrinks behavior in a container.</param>
        public UISharp FlexGrow(StyleFloat value)
        {
            if (visualElement == null || value == null)
                throw new System.Exception("UTKSharp : VisualElement and float value can't be null!");

            visualElement.style.flexGrow = value;
            return this;
        }

        /// <summary>Background image of VisualElement.</summary>
        /// <param name="value">Background value</param>
        public UISharp BackgroundImageTint(StyleBackground value)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement and float value can't be null!");

            visualElement.style.backgroundImage = value;
            return this;
        }

        /// <summary>Shrink relative to the rest of items in a container.</summary>
        /// <param name="value">Shrinks behavior in a container.</param>
        public UISharp FlexShrink(StyleFloat value)
        {
            if (visualElement == null || value == null)
                throw new System.Exception("UTKSharp : VisualElement and float value can't be null!");

            visualElement.style.flexShrink = value;
            return this;
        }

        /// <summary>Warps relative to the rest of items in a container.</summary>
        /// <param name="value">Warp mode behavior.</param>
        public UISharp FlexWrap(Wrap value = Wrap.NoWrap)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement value can't be null!");

            visualElement.style.flexWrap = value;
            return this;
        }

        /// <summary>Sets the size of a font.</summary>
        /// <param name="value">Font size value.</param>
        public UISharp FontSize(StyleLength value)
        {
            if (visualElement == null || value == null)
                throw new System.Exception("UTKSharp : VisualElement and value can't be null!");

            visualElement.style.fontSize = value;
            return this;
        }

        /// <summary>Determines background color of a VisualElement.</summary>
        /// <param name="value">Color value to assigned for the background.</param>
        public UISharp BackgroundColor(StyleColor color)
        {
            if (visualElement == null || color == null)
                throw new System.Exception("UTKSharp : VisualElement and Color can't be null!");

            visualElement.style.backgroundColor = color;
            return this;
        }

        /// <summary>Sets the width size of a VisualElement.</summary>
        /// <param name="value">Width value.</param>
        /// <param name="dynamic">Value in pixel if dynamic = false, in percent if dynamic = true.</param>
        public UISharp Width(float value, bool dynamic = false)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement and value can't be null!");

            if (!dynamic)
                visualElement.style.width = value;
            else
                visualElement.style.width = new StyleLength(new Length(value, LengthUnit.Percent));

            return this;
        }
        /// <summary>Sets both width and height style of a VisualElement.</summary>
        /// <param name="width">Width value.</param>
        /// <param name="heigth">Height value.</param>
        /// <param name="dynamic">Value in pixel if dynamic = false, in percent if dynamic = true.</param>
        public UISharp Size(float width, float height, bool dynamic = false)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement and float value can't be null!");

            if (!dynamic)
            {
                visualElement.style.height = height;
                visualElement.style.width = width;
            }
            else
            {
                visualElement.style.height = new StyleLength(new Length(height, LengthUnit.Percent));
                visualElement.style.width = new StyleLength(new Length(width, LengthUnit.Percent));
            }

            return this;
        }
        /// <summary>Sets the height size of a VisualElement.</summary>
        /// <param name="value">Height value.</param>
        /// <param name="dynamic">Value in pixel if dynamic = false, in percent if dynamic = true.</param>
        public UISharp Height(float value, bool dynamic = false)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement and float value can't be null!");

            if (!dynamic)
                visualElement.style.height = value;
            else
                visualElement.style.height = new StyleLength(new Length(value, LengthUnit.Percent));

            return this;
        }

        /// <summary>Sets margins of a VisualElement.</summary>
        /// <param name="leftValue">Left side margin value.</param>
        /// <param name="rightValue">Right side margin value.</param>
        /// <param name="topValue">Top side margin value.</param>
        /// <param name="bottomValue">Bottom side margin value.</param>
        public UISharp Margin(float? leftValue, float? rightValue, float? topValue, float? bottomValue)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

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
        public UISharp UserData(System.Object userData)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            if (userData == null)
                throw new System.Exception("UTKSharp : Object as userData can't be null!");

            visualElement.userData = userData;
            return this;
        }

        /// <summary>Sets the parent of VisualElement.</summary>
        /// <param name="parent">Parent VisualElement.</param>
        /// <param name="markDirtyRepaint">Dirties the layout to be repainted after reparenting.</param>
        public UISharp Parent(VisualElement parent, bool markDirtyRepaint = false)
        {
            if (visualElement == null || parent == null)
                throw new System.Exception("UTKSharp : Child and parent can't be null!");

            parent.Add(visualElement);

            if (markDirtyRepaint)
                parent.MarkDirtyRepaint();

            return this;
        }

        /// <summary>Sets name property of a VisualElement.</summary>
        /// <param name="name">Name of the VisualElement to be assigned.</param>
        public UISharp Name(string name)
        {
            if (visualElement == null || String.IsNullOrEmpty(name))
                throw new System.Exception("UTKSharp : VisualElement and it's parameter can't be null!");

            visualElement.name = name;
            return this;
        }

        /// <summary>Tints image background.</summary>
        /// <param name="styleBackground">StyleColor to be assigned.</param>
        public UISharp UnityBackgroundImageTint(StyleColor styleBackground)
        {
            if (visualElement == null || styleBackground == null)
                throw new System.Exception("UTKSharp : VisualElement and it's parameter can't be null!");

            visualElement.style.unityBackgroundImageTintColor = styleBackground;
            return this;
        }

        /// <summary>Background scale mode.</summary>
        /// <param name="scaleMode">ScaleMode value to be assigned.</param>
        public UISharp UnityBackgroundScaleMode(StyleEnum<ScaleMode> scaleMode)
        {
            if (visualElement == null || scaleMode == null)
                throw new System.Exception("UTKSharp : VisualElement and it's parameter can't be null!");

            visualElement.style.unityBackgroundScaleMode = scaleMode;
            return this;
        }

        /// <summary>Sets custom font.</summary>
        /// <param name="styleFont">Font type to be assigned.</param>
        public UISharp UnityFont(StyleFont styleFont)
        {
            if (visualElement == null || styleFont == null)
                throw new System.Exception("UTKSharp : VisualElement and it's parameter can't be null!");

            visualElement.style.unityFont = styleFont;
            return this;
        }

        /// <summary>Sets custom font.</summary>
        /// <param name="fontDefinition">Font type to be assigned.</param>
        public UISharp UnityFontDefinition(StyleFontDefinition fontDefinition)
        {
            if (visualElement == null || fontDefinition == null)
                throw new System.Exception("UTKSharp : VisualElement and it's parameter can't be null!");

            visualElement.style.unityFontDefinition = fontDefinition;
            return this;
        }

        /// <summary>Sets font's style and weight.</summary>
        /// <param name="fontStyle">FontStyle type to be assigned.</param>
        public UISharp UnityFontStyleAndWeight(StyleEnum<FontStyle> fontStyle)
        {
            if (visualElement == null || fontStyle == null)
                throw new System.Exception("UTKSharp : VisualElement and it's parameter can't be null!");

            visualElement.style.unityFontStyleAndWeight = fontStyle;
            return this;
        }

        /// <summary>Sets clipbox overflow mode.</summary>
        /// <param name="overflowClipbox">OverflowClipbox styleEnum to be assigned.</param>
        public UISharp UnityOverflowClipbox(StyleEnum<OverflowClipBox> overflowClipbox)
        {
            if (visualElement == null || overflowClipbox == null)
                throw new System.Exception("UTKSharp :VisualElement and it's parameter can't be null!");

            visualElement.style.unityOverflowClipBox = overflowClipbox;
            return this;
        }

        /// <summary>Sets paragraph spacing.</summary>
        /// <param name="styleLength">Paragraph spacing value to be assigned.</param>
        public UISharp UnityParagraphSpacing(StyleLength styleLength)
        {
            if (visualElement == null || styleLength == null)
                throw new System.Exception("UTKSharp : VisualElement and it's parameter can't be null!");

            visualElement.style.unityParagraphSpacing = styleLength;
            return this;
        }

        /// <summary>Sets left slice.</summary>
        /// <param name="value">Left slice value assigned.</param>
        public UISharp UnitySliceLeft(StyleInt value)
        {
            if (visualElement == null || value == null)
                throw new System.Exception("UTKSharp : VisualElement and it's parameter can't be null!");

            visualElement.style.unitySliceLeft = value;
            return this;
        }

        /// <summary>Sets right slice.</summary>
        /// <param name="value">Right slice value to be assigned.</param>
        public UISharp UnitySliceRight(StyleInt value)
        {
            if (visualElement == null || value == null)
                throw new System.Exception("UTKSharp : VisualElement and it's parameter can't be null!");

            visualElement.style.unitySliceRight = value;
            return this;
        }

        /// <summary>Sets top slice.</summary>
        /// <param name="value">Top slice value to be assigned.</param>
        public UISharp UnitySliceTop(StyleInt value)
        {
            if (visualElement == null || value == null)
                throw new System.Exception("UTKSharp : VisualElement and it's parameter can't be null!");

            visualElement.style.unitySliceLeft = value;
            return this;
        }

        /// <summary>Sets bottom slice.</summary>
        /// <param name="value">Bottom slice value to be assigned.</param>
        public UISharp UnitySliceBottom(StyleInt value)
        {
            if (visualElement == null || value == null)
                throw new System.Exception("UTKSharp : VisualElement and it's parameter can't be null!");

            visualElement.style.unitySliceBottom = value;
            return this;
        }

        /// <summary>Sets text alignment.</summary>
        /// <param name="alignment">Text alignment mode.</param>
        public UISharp UnityTextAlign(StyleEnum<TextAnchor> alignment)
        {
            if (visualElement == null || alignment == null)
                throw new System.Exception("UTKSharp : VisualElement and it's parameter can't be null!");

            visualElement.style.unityTextAlign = alignment;
            return this;
        }
        /// <summary>Sets text outline color.</summary>
        /// <param name="color">Color of the outline.</param>
        public UISharp UnityTextOutlineColor(StyleColor color)
        {
            if (visualElement == null || color == null)
                throw new System.Exception("UTKSharp : VisualElement and it's parameter can't be null!");

            visualElement.style.unityTextOutlineColor = color;
            return this;
        }

        /// <summary>Sets text outline color.</summary>
        /// <param name="widthSize">Outline width size.</param>
        public UISharp UnityTextOutlineWidth(StyleFloat widthSize)
        {
            if (visualElement == null || widthSize == null)
                throw new System.Exception("UTKSharp : VisualElement and it's parameter can't be null!");

            visualElement.style.unityTextOutlineWidth = widthSize;
            return this;
        }

        /// <summary>Sets bottom slice.</summary>
        /// <param name="overflowPosition">Position of the overflow.</param>
        public UISharp UnityTextOverflowPosition(StyleEnum<TextOverflowPosition> overflowPosition)
        {
            if (visualElement == null || overflowPosition == null)
                throw new System.Exception("UTKSharp : VisualElement and it's parameter can't be null!");

            visualElement.style.unityTextOverflowPosition = overflowPosition;
            return this;
        }

        /// <summary>Returns the VisualElement that's being instantiated. Must be used at the very end of the method chain.</summary>
        public VisualElement Return()
        {
            return visualElement;
        }
        /// <summary>Forces repaint the VisualElement.</summary>
        public UISharp MarkDirtyRepaint()
        {
            visualElement.MarkDirtyRepaint();
            return this;
        }
        /// <summary>Sets binding of a UIElement.</summary>
        /// <param name="name">Path.</param>
        public UISharp BindingPath(string bindingpath)
        {
            if(visualElement is Label lbl)
            {
                lbl.bindingPath = bindingpath;
            }
            else if(visualElement is RadioButton rdb)
            {
                rdb.bindingPath = bindingpath;
            }
            else if(visualElement is RadioButtonGroup rdbg)
            {
                rdbg.bindingPath = bindingpath;
            }
            else if(visualElement is DropdownField dropd)
            {
                dropd.bindingPath = bindingpath;
            }
            else if(visualElement is PopupWindow ppw)
            {
                ppw.bindingPath = bindingpath;
            }
            else if(visualElement is TextField txt)
            {
                txt.bindingPath = bindingpath;
            }
            else if(visualElement is MinMaxSlider mms)
            {
                mms.bindingPath = bindingpath;
            }
            else if(visualElement is Slider sld)
            {
                sld.bindingPath = bindingpath;
            }
            else if(visualElement is Toggle tgl)
            {
                tgl.bindingPath = bindingpath;
            }
            else if(visualElement is Button btn)
            {
                btn.bindingPath = bindingpath;
            }
            else if(visualElement is ListView lst)
            {
                lst.bindingPath = bindingpath;
            }
            else if(visualElement is ProgressBar pgb)
            {
                pgb.bindingPath = bindingpath;
            }
            else
            {
                throw new Exception("UTKSharp : The UIElement does not implement binding!");
            }
            return this;
        }
        /// <summary>Sets binding interface to the UIElement.</summary>
        /// <param name="ibind">IBinding interface of UIElement</param>
        public UISharp Binding(IBinding ibind)
        {
            if(visualElement is Label lbl)
            {
                lbl.binding = ibind;
            }
            else if(visualElement is RadioButton rdb)
            {
                rdb.binding = ibind;
            }
            else if(visualElement is RadioButtonGroup rdbg)
            {
                rdbg.binding = ibind;
            }
            else if(visualElement is DropdownField dropd)
            {
                dropd.binding = ibind;
            }
            else if(visualElement is PopupWindow ppw)
            {
                ppw.binding = ibind;
            }
            else if(visualElement is TextField txt)
            {
                txt.binding = ibind;
            }
            else if(visualElement is MinMaxSlider mms)
            {
                mms.binding = ibind;
            }
            else if(visualElement is Slider sld)
            {
                sld.binding = ibind;
            }
            else if(visualElement is Toggle tgl)
            {
                tgl.binding = ibind;
            }
            else if(visualElement is Button btn)
            {
                btn.binding = ibind;
            }
            else if(visualElement is ListView lst)
            {
                lst.binding = ibind;
            }
            else if(visualElement is ProgressBar pgb)
            {
                pgb.binding = ibind;
            }
            else
            {
                throw new Exception("UTKSharp : The UIElement does not implement binding!");
            }
            
            return this;
        }
    }
    public static class UTKSharpElement
    {
        private static VisualElement cachedElement;
        public static UISharp style { get { return new UISharp(cachedElement); } }

        public static VisualElement GetParent(VisualElement visualElement)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            cachedElement = visualElement;
            return visualElement.parent;
        }
        public static VisualElement GetChild(VisualElement visualElement, string childName, string utkId)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            if (visualElement.childCount == 0)
                return null;

            cachedElement = visualElement;

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
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            cachedElement = visualElement;
            return visualElement.childCount;
        }
        public static VisualElement[] GetChildren(VisualElement visualElement)
        {
            if (visualElement == null)
                throw new System.Exception("UTKSharp : VisualElement can't be null!");

            cachedElement = visualElement;
            return visualElement.Children().ToArray();
        }
        public static VisualElement.Hierarchy GetHierarchy(VisualElement visualElement)
        {
            return visualElement.hierarchy;
        }
    }
    public class UISharpCommonMethod : ISharpCommonMethod
    {
        public VisualElement visualElement { get; set; }

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
                throw new System.Exception("UTKSharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<KeyDownEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnMouseDown(Action<MouseDownEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UTKSharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<MouseDownEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnMouseOver(Action<MouseOverEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UTKSharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<MouseOverEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnFocusOut(Action<FocusOutEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UTKSharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<FocusOutEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnMouseEnter(Action<MouseEnterEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UTKSharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<MouseEnterEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnMouseExit(Action<MouseLeaveEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UTKSharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<MouseLeaveEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnFocusIn(Action<FocusInEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UTKSharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<FocusInEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnKeyUp(Action<KeyUpEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UTKSharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<KeyUpEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnMouseMove(Action<MouseMoveEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UTKSharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<MouseMoveEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnMouseLeaveWindow(Action<MouseLeaveWindowEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UTKSharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<MouseLeaveWindowEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnMouseLeave(Action<MouseLeaveEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UTKSharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<MouseLeaveEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnFocus(Action<FocusEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UTKSharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<FocusEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnBlur(Action<BlurEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UTKSharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<BlurEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnLeftClick(Action<ClickEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UTKSharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<ClickEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnRightClick(Action<ContextClickEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UTKSharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<ContextClickEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnMouseWheel(Action<WheelEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UTKSharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<WheelEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnDragEnter(Action<DragEnterEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UTKSharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<DragEnterEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnDragLeave(Action<DragLeaveEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UTKSharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<DragLeaveEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnPointerOut(Action<PointerOutEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UTKSharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<PointerOutEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnPointerEnter(Action<PointerEnterEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UTKSharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<PointerEnterEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent SetOnPointerLeave(Action<PointerLeaveEvent> evt)
        {
            if (cachedVisualElement == null || evt == null)
                throw new System.Exception("UTKSharp : VisualElement and callback can't be null!");

            cachedVisualElement.RegisterCallback<PointerLeaveEvent>(x =>
            {
                evt.Invoke(x);
            });
            return this;
        }
        public UIEvent ScheduleExecute(VisualElement visualElementToBeWaited, Action callback, int delay = 0)
        {
            if (cachedVisualElement == null || visualElementToBeWaited == null)
                throw new System.Exception("UTKSharp : VisualElements can't be null!");

            cachedVisualElement.schedule.Execute(x =>
            {
                callback.Invoke();
            }).ExecuteLater(delay);
            return this;
        }
    }
    public static class UTKTween
    {
        public static void UTKMove(VisualElement visualElement, Vector2 destination, float duration, float delay, EasingMode ease = EasingMode.Linear)
        {
            //Create a list that contains the move property, and use it to set transitionProperty.
            visualElement.style.transitionProperty = new List<StylePropertyName> { "move" };
            visualElement.style.transitionTimingFunction = new List<EasingFunction> { ease };

            //Duration
            visualElement.style.transitionDuration = new List<TimeValue> { duration };

            //Delays
            visualElement.style.transitionDelay = new List<TimeValue> { delay };
        }
        public static void UTKRotate(VisualElement visualElement, Vector2 destination, float duration, float delay, EasingMode ease = EasingMode.Linear)
        {
            //Create a list that contains the move property, and use it to set transitionProperty.
            visualElement.style.transitionProperty = new List<StylePropertyName> { "rotate" };
            visualElement.style.transitionTimingFunction = new List<EasingFunction> { ease };

            //Duration
            visualElement.style.transitionDuration = new List<TimeValue> { duration };

            //Delays
            visualElement.style.transitionDelay = new List<TimeValue> { delay };
        }
        public static void UTKScale(VisualElement visualElement, Vector2 destination, float duration, float delay, EasingMode ease = EasingMode.Linear)
        {
            //Create a list that contains the move property, and use it to set transitionProperty.
            visualElement.style.transitionProperty = new List<StylePropertyName> { "scale" };
            visualElement.style.transitionTimingFunction = new List<EasingFunction> { ease };

            //Duration
            visualElement.style.transitionDuration = new List<TimeValue> { duration };

            //Delays
            visualElement.style.transitionDelay = new List<TimeValue> { delay };
        }
    }
    //TODO Inline layout construction with fluent api. Still testing what's the best way to do thius 
    public class UTKMakeSplit
    {
        private bool uDatNotAvailable;
        private VisualElement root;
        public UTKMakeSplit(VisualElement customRoot = null, float width = 100, float height = 100, float margin = 5, bool dynamicSize = false)
        {
            root = customRoot;

            if(customRoot == null)
            {
                root = new VisualElement();
            }

            root.name = "root";
            UTKSharp.style(root).Width(width, true).Height(height, true).AlignItems(Align.Center).Margin(margin, margin, margin, margin);
            root.userData = (new List<VisualElement>(), new List<VisualElement>());
        }
        private List<VisualElement> GetUData(bool getMainContainer)
        {
            if(!uDatNotAvailable)
            {
                if(getMainContainer)
                {
                    var tmp = ((List<VisualElement>, List<VisualElement>))root.userData;
                    
                    if(tmp.Item1 != null && tmp.Item2 != null)
                    {
                        return tmp.Item1;
                    }
                    else
                    {
                        return tmp.Item2;
                    }
                }
            }
            else
            {
                if(getMainContainer)
                {
                    var getMainCon = GetUData(true);

                    if(getMainCon != null)
                        return getMainCon;
                }
                else
                {
                    var getMainCon = GetUData(false);
                    
                    if(getMainCon != null)
                        return getMainCon;
                }
            }
            return null;
        }
        public UTKMakeSplit AddPanel(float width, float height, int? id = null)
        {
            VisualElement vis = new VisualElement();

            if(id.HasValue)
                vis.name = id.Value.ToString();

            UTKSharp.style(vis).Width(width, true).Height(height, true);
            GetUData(true).Add(vis);
            return this;
        }
        public UTKMakeSplit SplitPanel(int pieces, string prefix, bool horizontal = true)
        {
            var udat = GetUData(true);
            var con = GetUData(false);

            if(udat != null && udat.Count > 0)
            {
                float total = 100 / pieces;

                for(int i = 0; i < udat.Count; i++)
                {
                    if(udat[i] == null)
                        continue;

                    if(horizontal)
                    {
                        UTKSharp.style(udat[i]).FlexDirection(FlexDirection.Row);
                    }

                    for(int j = 0; j < pieces; j++)
                    {
                        var viscon = new VisualElement();
                        viscon.style.width = new StyleLength(new Length(total, LengthUnit.Percent));
                        viscon.name = prefix + j;
                        udat[i].Add(viscon);
                        con.Add(viscon);
                    }
                }
            }
            return this;
        }
        public VisualElement ReturnRoot()
        {
            return root;
        }
        public VisualElement[] ReturnPanels()
        {
            return GetUData(true).ToArray();
        }
        public VisualElement[] ReturnSubPanels()
        {
            return GetUData(false).ToArray();
        }
    }
}