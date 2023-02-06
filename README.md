# UTKSharp-UIToolkit-Fluent-API-for-Unity3D
Fluent api for UIToolkit completely written in c#. No USS/UXML needed!  


<br>Still on-progress, most likely it will break on every update due to api style changes(currently the naming convention is a bit long)</br>

# How-To:
Add a refernce to UITKSharp namespace `using UITKsharp;`

**Styling**<br>`UTKSharp.style(visualElement).SetBcgColor(Color.blue).SetParent(parentVisualElement);`<br/>  
**Event**<br>`UTKSharp.addEvent(visualElement).SetOnMouseDown((x)=> Debug.Log("Mouse Pressed!"));`<br/>  
**UIElement**<br>`UTKSharp.boxElement(new Box()).SetWidth(100, dynamic: true).SetHeight(50, true).SetWidth(100, true);`<br/>  

**Constructing layout with `UTKSharp.construct() & UTKSharp.customSplitView()` methods**
```
            //Constructing layout based on the method chain
            UTKSharp.construct().Parent(parentOne).Child(childOne).Child(childOne).Parent(parentTwo).Child(childTwo);
            
            //Returns root of a hierarchy
            var getRoot = UTKSharp.construct().Parent(parentOne).Child(childTwo).ReturnRoot();

            //Parent as root, or else the default will be created
            UTKSharp.construct().Parent(parentOne, asRoot: true).Child(childTwo);
            
            //GetElement method to retrieve VisualElement tagged by id/name in the current chain
            
            var childOne = new VisualElement();
            var childTwo = new VisualElement();
            
            UTKSharp.construct().Parent(new VisualElement(), "parent").Child(childOne).GetElementAsParent("parent").Child(childTwo);
            
            //Generate custom splitView in single line.
            var custom = UTKSharp.customSplitView(50, 50, 5, true).AddPanel(100, 100, id:1).SplitPanel(3, "custom-no", true);

            //Returns sub-panels from custom splitView
            VisualElement[] customSView = custom.ReturnSubContainers();
```

# Supported UIElements
VisualElement  
DropDownField  
ListView  
ScrollView  
Label  
Box  
Slider  
MinMaxSlider  
TextField  
PopUpWindow  
Toggle  
Button  
Image  
RadioButton  
(More to come)  

# Installation  
Download from release page(UTKSharp-v1.zip)  
Unpack/unzip it, then copy to your project's Asset folder  

# Note:
Common functionality related to USS/UXML class was intentionaly not added for obvious reason.  
Not fully tested!  

# TODO  
Custom editor support  
Transitions  
Expose more apis. Curently it's limited to common ones(Most that I often work with)  
Implement IResolvedStyle  
