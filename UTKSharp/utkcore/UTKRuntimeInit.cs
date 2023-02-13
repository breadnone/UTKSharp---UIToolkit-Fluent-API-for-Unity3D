using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

namespace UITKsharp
{
    public static class UTKManager
    {
        private static SharpStyleClass templates;
        public static void InitTemplates()
        {
            var ins = Resources.Load<SharpStyleClass>("utk--global-templates");
            
            if(ins != null)
            templates = ins;
        }
        public static (IStyle style, SharpStyleClass sharpStyle) GetTemplate(string templateName)
        {
            var ins = templates.templates.Find(x => x.templateName == templateName);

            if(templates == null || templates.templates.Count == 0 || ins == null)
                throw new Exception("UTKSharp : Templates are empty! Create templates first!");
            
            return (ins.styleInterface, templates);
        }
        public static bool IsRuntime(){return templates != null;}
    }
    class UTKInitClass
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void OnRuntimeMethodLoad()
        {
            UTKManager.InitTemplates();
        }
    }
}