using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq.Expressions;
using System.Reflection;
using UnityEngine.UIElements;
using System.Linq;

namespace UITKsharp
{
    [System.Serializable]
    public class UTKStyleTemplate
    {
        public UISharp templateStyle;
        public string name;
        public string templateId;
        public VisualElement visualElement;
    }
    public static class UISharpUtil
    {
        public static void CreateUTKTemplate(UISharp utkstyle)
        {
            if (utkstyle == null)
                return;

            var tmp = GetUTKTemplateObject();

            if (tmp == null)
            {
                CreateSaveAsset();
                tmp = GetUTKTemplateObject();
            }

            var tmpl = new UTKStyleTemplate
            {
                templateStyle = utkstyle,
                visualElement = utkstyle.Return(),
                name = utkstyle.Return().name,
                templateId = Guid.NewGuid().ToString()
            };

            tmp.InsertTemplate(tmpl);
        }
        public static IStyle GetTemplate(string templateName)
        {
            if (String.IsNullOrEmpty(templateName))
                return null;

            return GetUTKTemplateObject().GetStyleTemplate(templateName).visualElement.style;
        }
        private static void CreateSaveAsset()
        {
            var template = GetUTKTemplateObject();

            if (template == null)
            {
                var obj = new GameObject();
                obj.name = "UTKTemplateManager";
                obj.AddComponent<UTKTemplateComponent>();
            }
        }
        private static UTKTemplateComponent GetUTKTemplateObject()
        {
            var obj = Resources.FindObjectsOfTypeAll<UTKTemplateComponent>();

            if (obj == null)
            {
                return null;
            }

            return obj[0];
        }
        private static bool UTKtemplateExists()
        {
            return GetUTKTemplateObject() != null;
        }
        public static void TestDebug()
        {
            var t = GetUTKTemplateObject().Template;

            if (t.Count == 0)
            {
                Debug.Log("Templates are empty");
                return;
            }

            for (int i = 0; i < t.Count; i++)
            {
                if (t[i] == null)
                    continue;

                Debug.Log("Width is : " + t[i].visualElement.style.width + "  Height is : " + t[i].visualElement.style.height);
            }
        }
        public static void CloneStyle(IStyle toCopy, IStyle copy)
        {
            CopyProperties<IStyle>(toCopy, copy);
        }
        public static void CopyProperties<T>(T source, T target)
        {
            CopyProp<T>.CopyProperties(source, target);
        }
        private static class CopyProp<T>
        {
            private static readonly Action<T, T>[] _copyProps = Prepare();

            private static Action<T, T>[] Prepare()
            {
                Type type = typeof(T);
                ParameterExpression source = Expression.Parameter(type, "source");
                ParameterExpression target = Expression.Parameter(type, "target");

                var copyProps = from prop in type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                                where prop.CanRead && prop.CanWrite
                                let getExpr = Expression.Property(source, prop)
                                let setExpr = Expression.Call(target, prop.GetSetMethod(true), getExpr)
                                select Expression.Lambda<Action<T, T>>(setExpr, source, target).Compile();

                return copyProps.ToArray();
            }

            public static void CopyProperties(T source, T target)
            {
                foreach (Action<T, T> copyProp in _copyProps)
                    copyProp(source, target);
            }
        }
    }
}