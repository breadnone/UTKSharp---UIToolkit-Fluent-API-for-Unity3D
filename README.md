# UTKSharp-UIToolkit-Fluent-API-for-Unity3D
Fluent api for UIToolkit completely written in c#. No USS/UXML needed!  


<br>Still on-progress, most likely it will break on every update due to api style changes(currently the naming convention is a bit long)</br>

# How-To:
Add a refernce to UITKSharp namespace `using UITKsharp;`

**Styling**<br>`UTKSharp.style(visualElement).SetBcgColor(Color.blue).SetParent(parentVisualElement);`<br/>  
**Event**<br>`UTKSharp.addEvent(visualElement).SetOnMouseDown((x)=> Debug.Log("Mouse Pressed!"));`<br/>  
**UIElement**<br>`UTKSharp.boxElement(new Box()).SetWidth(100, dynamic: true).SetHeight(50, true).SetWidth(100, true);`<br/>  

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
