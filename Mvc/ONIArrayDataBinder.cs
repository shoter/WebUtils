using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.Web;

namespace WebUtils.Mvc
{
    public class ONIArrayDataBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var arrayName = bindingContext.ModelName;
            Type elementType = bindingContext.ModelType.GetElementType();

            List<object> items = getArrayItems(controllerContext, bindingContext, arrayName, elementType);
            if (items.Count == 0)
                return Activator.CreateInstance(bindingContext.ModelType);

            Array array = Array.CreateInstance(elementType, items.Count);
            (items as IList).CopyTo(array, 0);
            return array;
        }

        private List<object> getArrayItems(ControllerContext controllerContext, ModelBindingContext bindingContext, string arrayName, Type elementType)
        {
            List<object> items = new List<object>();

            Regex regex = createKeyRegexp(arrayName);
            List<int> keys = getKeysInAscendingOrder(controllerContext.HttpContext.Request, regex);

            IModelBinder elementBinder = Binders.GetBinder(elementType);

            foreach (var key in keys)
            {
                ModelBindingContext innerContext = new ModelBindingContext()
                {
                    ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, elementType),
                    ModelName = $"{arrayName}[{key}]",
                    ModelState = bindingContext.ModelState,
                    PropertyFilter = bindingContext.PropertyFilter,
                    ValueProvider = bindingContext.ValueProvider
                };

                object element = elementBinder.BindModel(controllerContext, innerContext);
                items.Add(element);
            }

            return items;
        }

        private static Regex createKeyRegexp(string arrayName)
        {
            var regexp = arrayName + @"\[([0-9]+)\]";
            var regex = new Regex(regexp);
            return regex;
        }

        private static List<int> getKeysInAscendingOrder(HttpRequestBase request, Regex regex)
        {
            return request.Form.AllKeys.Where(key => regex.Match(key).Success)
                            .Select(key => int.Parse(regex.Match(key).Groups[1].Value))
                            .Distinct()
                            .OrderBy(k => k)
                            .ToList();
        }
    }
}
