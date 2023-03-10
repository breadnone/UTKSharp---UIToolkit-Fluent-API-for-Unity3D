# UTKSharp-UIToolkit-Fluent-API-for-Unity3D
Fluent api for UIToolkit completely written in c#.

<br>Requirement : Unity 2022.2+.</br>

# How-To:
Runtime : Add a refernce to UITKSharp namespace `using UITKsharp;`  
Edit-mode(Custom editor) : UITKSharp.Editor  


**Styling**<br>`UTKSharp.style(visualElement).BackgroundColor(Color.blue).SetParent(parentVisualElement);`<br/>  
**Event**<br>`UTKSharp.addEvent(visualElement).SetOnMouseDown((x)=> Debug.Log("Mouse Pressed!"));`<br/>  
**UIElement**<br>`UTKSharp.boxElement(new Box()).Width(100, dynamic: true).Height(50, true);`<br/>  
**Making Templates**(experimental)   
```
        //Create in Edit-mode
        var template = UTKSharp.style(new VisualElement()).Height(100, true).Width(200);
        template.CreateTemplate("myTemplate");
        
        //Use in runtime
        template.UseTemplate("myTemplate");
        
        //Use in Edit-mode (for custom editor)
        //Use the template as shown below by finding the name of the VisualElement.
        UTKSharp.style(new VisualElement()).CopyTemplate("myTemplate");
        
        //NOTE: Nesting templating aren't supported. Must be single instance without parent/child.
```

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

            //Returns panels/sub-panels from custom splitView
            VisualElement[] subPanels = custom.ReturnSubPanels();
            VisualElement[] panels = custom.ReturnSubPanels();
             
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
ProgressBar  
Custom SplitView  
(More to come)  

# Installation  
Download the source code as zip. Unpack/unzip it to your project's Asset folder.  

# Note:
Common functionality related to USS/UXML class was intentionaly not added for obvious reason.  
Not fully tested!  

# TODO  
Transitions  
Expose more apis. Curently it's limited to common ones(Most I often work with)  
