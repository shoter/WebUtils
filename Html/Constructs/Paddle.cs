using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebUtils.Html.Constructs
{
    public static class Paddle
    {
        public static MvcHtmlString Generate(string id, string enabledText = "On", string disabledText = "Off", bool initialValue = false, object inputAttributes = null, object paddleAttributes = null)
        {

            TagBuilder input = createInput(id, inputAttributes, initialValue);

            TagBuilder paddle = createPaddle(id, enabledText, disabledText, initialValue, paddleAttributes);

            return MvcHtmlString.Create(input.ToString() + paddle.ToString());
        }

        private static TagBuilder createPaddle(string id, string enabledText, string disabledText, bool initialValue, object paddleAttributes)
        {
            var paddle = new TagBuilder("div");
            paddle.Attributes["data-paddle"] = "";
            paddle.Attributes["data-paddle-linkedid"] = id;
            paddle.Attributes["data-paddle-disable-auto"] = "true";
            paddle.AddCssClass("paddle");
            paddle.AddCssClass(initialValue ? "activated" : "disabled");

            var attributes = new HtmlAttributes(paddleAttributes);
            foreach (var pair in attributes)
            {
                paddle.Attributes[pair.Key] = pair.Value;
            }




            var active = new TagBuilder("div");
            active.AddCssClass("paddle-active");
            active.AddCssClass("paddle-state");
            active.SetInnerText(enabledText);


            var disabled = new TagBuilder("div");
            disabled.AddCssClass("paddle-inactive");
            disabled.AddCssClass("paddle-state");
            disabled.SetInnerText(disabledText);

            var block = new TagBuilder("div");
            block.AddCssClass("paddle-block");

            var builder = new StringBuilder();
            builder.Append(active.ToString(TagRenderMode.Normal));
            builder.Append(disabled.ToString(TagRenderMode.Normal));
            builder.Append(block.ToString(TagRenderMode.Normal));

            paddle.InnerHtml = builder.ToString();
            return paddle;
        }

        private static TagBuilder createInput(string id, object inputAttributes, bool initialValue)
        {
            var input = new TagBuilder("input");
            input.Attributes["id"] = id;
            input.Attributes["type"] = "hidden";
            input.Attributes["value"] = initialValue.ToString();

            var attributes = new HtmlAttributes(inputAttributes);
            foreach (var pair in attributes)
            {
                input.Attributes[pair.Key] = pair.Value;
            }

            return input;
        }
    }
}
