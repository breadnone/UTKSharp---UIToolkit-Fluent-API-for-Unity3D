# UTKSharp-UIToolkit-Fluent-API-for-Unity3D
Fluent api for UIToolkit completely written in c#. No USS/UXML needed!

# How-To:
Add a refernce to UITKSharp namespace `using UITKsharp;`

Styling `UTKSharp.style(new VisualElement()).SetBcgColor(Color.blue).SetParent(parentVisualElement);`  
Event `UTKSharp.addEvent(new VisualElement()).SetOnMouseDown((x)=> Debug.Log("Mouse Pressed!"));`  
UIElement `UTKSharp.boxElement(new Box()).SetWidth(100, dynamic: true).SetHeight(50, dynamic: true).SetAlignContent(Align.Center);`  

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
(More to come)  

# Installation  
Download from release page(UTKSharp-v1.zip)  
Unpack/unzip it, then copy to your project's Asset folder  

# Note:
Common functionality related to USS/UXML class was intentionaly not added for obvious reason.  
Not fully tested!  

# TODO  
Custom editor support  

