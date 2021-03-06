﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebUtils.Extensions;
using WebUtils.Forms.Select2;
using WebUtils.Html;
using WebUtils.Html.Constructs;
using WebUtils.Scripts;

namespace WebUtils.Helpers
{
    public static class HtmlHelper
    {
        public static MvcHtmlString ToJavascriptString(this object obj)
        {
            return MvcHtmlString.Create($"\"{obj.ToString()}\"");
        }

        public static MvcHtmlString ToJavascript(this bool obj)
        {
            return MvcHtmlString.Create(obj == true ?
                "true" : "false");
        }

        public static MvcHtmlString ToJavascriptArray<T>(this ICollection<T> array, params Func<T, object>[] members)
        {
            StringBuilder output = new StringBuilder("[");

            output.Append(string.Join(",",
                array.Select(element => getJavascriptArrayElement(element, members))));
            output.Append("]");
            return MvcHtmlString.Create(output.ToString());
        }

        private static string getJavascriptArrayElement<T>(T element, Func<T, object>[] members)
        {
            if (members.Length == 0)
                return $"{element}";
            else if(members.Length == 1)
                return $"{members[0](element)}";
            return $"[{string.Join(",", members.Select(m => m(element).ToString()))}]";
        }

        public static MvcHtmlString RenderPaddle(this System.Web.Mvc.HtmlHelper helper, string id, string enabledText = "On", string disabledText = "Off", bool initialValue = false, object inputAttributes = null, object paddleAttributes = null)
        {
            return Paddle.Generate(id, enabledText, disabledText, initialValue, inputAttributes, paddleAttributes);
        }

        public static MvcHtmlString Render(this System.Web.Mvc.HtmlHelper helper, Select2AjaxViewModel select2, string prefix = "", params string[] classes)
        {
            var urlHelper = helper.GetUrlHelper();

            TagBuilder select = new TagBuilder("select");
            select.AddCssClass("customSelect");
            foreach (var @class in classes)
                select.AddCssClass(@class);

            select.Attributes["data-Select2AjaxViewModel"] = "true";
            select.Attributes["name"] = prefix + select2.Name;
            select.Attributes["data-select2-url"] = urlHelper.Action(select2.ControllerName, select2.ActionName);
            select.Attributes["data-select2-delay"] = select2.Delay.ToString();
            select.Attributes["data-select2-quietMillis"] = select2.QuietMillis.ToString();
            select.Attributes["data-select2-cache"] = select2.Cache.ToString();
            select.Attributes["data-select2-pageSize"] = select2.PageSize.ToString();
            select.Attributes["data-select2-minimumInputLength"] = select2.MinimumInputLength.ToString();
            select.Attributes["data-select2-templateResult"] = select2.TemplateResult;
            select.Attributes["data-select2-templateSelection"] = select2.TemplateSelection;
            select.Attributes["data-select2-data"] = select2.Data;
            select.Attributes["data-select2-onchange"] = select2.OnChange;

            foreach (var data in select2.AdditionalData)
            {
                var key = $"data-select2-add-{data.Key}";
                select.Attributes[key] = data.Value;
            }

            if (string.IsNullOrWhiteSpace(select2.ID) == false)
                select.Attributes["id"] = select2.ID;
            if (string.IsNullOrWhiteSpace(select2.ContainerCssClass))
                select.Attributes["data-select2-containercssclass"] = select2.ContainerCssClass;
            if (string.IsNullOrWhiteSpace(select2.DropdownCssClass))
                select.Attributes["data-select2-dropdowncssclass"] = select2.DropdownCssClass;


            TagBuilder option = new TagBuilder("option");
            option.Attributes["value"] = select2.SelectedValue.ToString();
            option.Attributes["selected"] = "selected";
            option.InnerHtml = select2.SelectedValueName;
            select.InnerHtml = option.ToString(TagRenderMode.Normal);

            if (string.IsNullOrWhiteSpace(Select2AjaxDefaultProvider.Current?.JavascriptFile) == false)
                ScriptInjector.AddScript(Select2AjaxDefaultProvider.Current.JavascriptFile);
            if (string.IsNullOrWhiteSpace(Select2AjaxDefaultProvider.Current?.StyleFile) == false)
                StyleInjector.AddStyle(Select2AjaxDefaultProvider.Current.StyleFile);

            return new MvcHtmlString(select.ToString(TagRenderMode.Normal));
        }
    }
}
