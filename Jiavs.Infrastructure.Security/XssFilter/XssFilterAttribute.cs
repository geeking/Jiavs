using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Jiavs.Infrastructure.Security.XssFilter
{
    public class XssFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //获取Action参数集合
            var ps = context.ActionDescriptor.Parameters;
            //遍历参数集合
            foreach (var p in ps)
            {
                if (context.ActionArguments[p.Name] != null)
                {
                    //参数为字符串，直接进入过滤；参数为复杂类型，则使用反射递归拆解，过滤其字符串类型的属性
                    if (p.ParameterType.Equals(typeof(string)))
                    {
                        context.ActionArguments[p.Name] = Filter(context.ActionArguments[p.Name].ToString());
                    }
                    else if (p.ParameterType.IsClass)
                    {
                        ModelFieldFilter(p.ParameterType, context.ActionArguments[p.Name]);
                    }
                }
            }
        }

        private string Filter(string html)
        {
            var sanitizer = HtmlSanitizerFactory.GetHtmlSanitizer();
            return sanitizer.Sanitize(html);
        }

        /// <summary>
        /// 遍历修改类的字符串属性
        /// </summary>
        /// <param name="type">数据类型</param>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        private object ModelFieldFilter(Type type, object obj)
        {
            if (obj != null)
            {
                //获取类的属性集合
                var properties = type.GetProperties();

                foreach (var propertie in properties)
                {
                    if (propertie.GetValue(obj) != null)
                    {
                        if (propertie.PropertyType.Equals(typeof(string)))
                        {
                            string value = propertie.GetValue(obj).ToString();
                            propertie.SetValue(obj, Filter(value));
                        }
                        else if (propertie.PropertyType.IsClass)
                        {
                            propertie.SetValue(obj, ModelFieldFilter(propertie.PropertyType, propertie.GetValue(obj)));
                        }
                    }
                }
            }

            return obj;
        }
    }
}