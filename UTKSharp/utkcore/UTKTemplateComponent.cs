using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UITKsharp;
using System;

public class UTKTemplateComponent : MonoBehaviour
{
    [SerializeField] private List<UTKStyleTemplate> templates = new List<UTKStyleTemplate>();
    public List<UTKStyleTemplate> Template{get{return templates;}}
    public void InsertTemplate(UTKStyleTemplate utkStyle)
    {
        if(utkStyle == null)
            return;

        if(!templates.Exists(x => x.templateId == utkStyle.templateId))
        {
            templates.Add(utkStyle);
        }
    }
    public UTKStyleTemplate GetStyleTemplate(string templateName)
    {
        var t = templates.Find(x => x.templateName == templateName);

        if(t == null)
            throw new Exception("UTKSharp : Template can't be found!. Make sure templateName is coorect (case sensitive)");
        return t;
    }
    public void RemoveTemplate(string name)
    {
        if(String.IsNullOrEmpty(name))
            return;

        var t = templates.Find(x=> x.templateName == name);

        if(t != null)
            templates.Remove(t);
    }
    public void ClearTemplates()
    {
        templates.Clear();
    }
}
