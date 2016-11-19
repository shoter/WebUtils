using Common.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebUtils.Helpers
{
    public static class FoundationHelper
    {

        public static MvcHtmlString DropDownListFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, int>> expression, List<ImageSelectListItem> options, IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            string expressionText = ExpressionHelper.GetExpressionText(expression);

            TagBuilder linkDropDownButton = new TagBuilder("a");
            linkDropDownButton.MergeAttribute("data-dropdown", expressionText);

            throw new NotImplementedException();
        }
    }
}
