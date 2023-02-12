using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using UnityEngine.UIElements;

namespace UITKsharp.Editor
{
    public static class UISharpEditorUtil
    {
        private static string upath = "Assets/UTKSharp/Resources/utk--global-templates.asset";
        public static void UTKCreateInstance()
        {
            if(InstanceExists())
                return;

            var styleAsset = ScriptableObject.CreateInstance<SharpStyleClass>();
            AssetDatabase.CreateAsset(styleAsset, upath);
            AssetDatabase.SaveAssets();
        }
        private static bool InstanceExists()
        {
            if(File.Exists(upath))
                return true;

            return false;
        }
        public static SharpStyleClass GetScriptableTemplate()
        {
            var tmp = AssetDatabase.LoadAssetAtPath<SharpStyleClass>(upath);

            if(tmp != null)
                return tmp;

            return null;
        }
        public static void SaveTemplate(UISharp template)
        {
            UTKCreateInstance();
            var tmp = GetScriptableTemplate();            
            
            if(!tmp.templates.Exists(x => x.templateName == template.Return().name))
            {
                var instance = new UTKStyleTemplate
                {
                    templateName = template.Return().name,
                    styleInterface = template.Return().style,
                    templateStyle = template,
                    templateId = UnityEngine.Random.Range(1, int.MaxValue).ToString()
                };

                tmp.templates.Add(instance);
            }
        }
        private static (IStyle style, SharpStyleClass sharpStyle) GetTemplate(string templateName)
        {
            var tmp = GetScriptableTemplate();
            var ins = tmp.templates.Find(x => x.templateName == templateName);

            if(tmp == null || ins == null)
                return (null, null);
            
            return (ins.styleInterface, tmp);
        }

        public static UISharp CopyTemplate(this UISharp targetElement, string templateName, bool repaint = false)
        {
            if(String.IsNullOrEmpty(templateName) || targetElement == null)
                return null;

            var source = GetTemplate(templateName);
            var target = targetElement.visualElement.style;
            UISharpUtil.CopyStyle(source.style, target);

            if(repaint)
            {
                targetElement.visualElement.MarkDirtyRepaint();
            }

            return targetElement;
        }
        public static UISharp CreateTemplate(this UISharp targetElement, string templateName)
        {
            if(String.IsNullOrEmpty(templateName) || targetElement == null)
                return null;
            
            if(!String.IsNullOrEmpty(targetElement.visualElement.name))
                throw new Exception("UTKSharp : Make sure it's a new/freshly created VisualElement to be used as a template");

            UISharpEditorUtil.SaveTemplate(targetElement.Name(templateName));
            var t = UISharpEditorUtil.GetScriptableTemplate();
            EditorUtility.SetDirty(t);
            return targetElement;
        }
        private static void Test()
        {
            //Create a template
            var test = new UISharp(new VisualElement()).Height(200, true).Width(400, false).CreateTemplate("myTemplateId");

            //Copy the template to another VisualElement
            var newUI = new UISharp(new VisualElement()).CopyTemplate("myTemplateId");
        }
    }
}