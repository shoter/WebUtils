using Common.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebUtils.Forms.Select2
{
    public class Select2AjaxViewModel
    {
        /// <summary>
        /// This name will be passed as variable name in form
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// ID of select element which will be used
        /// </summary>
        public string ID { get; set; }

        public string ActionName { get; private set; }
        public string ControllerName { get; private set; }

        /// <summary>
        /// The number of milliseconds to wait for the user to stop typing before issuing the ajax request.
        /// </summary>
        public int Delay { get; set; } = Select2AjaxDefaultProvider.Current.DefaultDelay;
        /// <summary>
        /// Time between consecutive ajax requests
        /// </summary>
        public int QuietMillis { get; set; } = Select2AjaxDefaultProvider.Current.DefaultQuietMillis;
        /// <summary>
        /// Number of characters necessary to start a search.
        /// </summary>
        public int MinimumInputLength { get; set; } = Select2AjaxDefaultProvider.Current.DefaultMinimumInputLength;
        /// <summary>
        /// Javascript function used to render single item in search box. 1 argument is passed which is item
        /// </summary>
        public string TemplateResult { get; set; } = Select2AjaxDefaultProvider.Current.DefaultTemplateResult;
        /// <summary>
        /// Javascript used to render selected item from search box. 1 argument is passed which is item.
        /// </summary>
        public string TemplateSelection { get; set; } = Select2AjaxDefaultProvider.Current.DefaultTemplateSelection;
        /// <summary>
        /// If set to false, it will force requested pages not to be cached by the browser. Default is true.
        /// </summary>
        public bool Cache { get; set; } = true;
        /// <summary>
        /// How many results per page when searching.
        /// </summary>
        public int PageSize { get; set; } = Select2AjaxDefaultProvider.Current.DefaultPageSize;
        /// <summary>
        /// Value of start selection
        /// </summary>

        public int? SelectedValue { get; set; }
        /// <summary>
        /// Text name of start selection
        /// </summary>
        public string SelectedValueName { get; set; }

        /// <summary>
        /// Css class that will be added to select2's container tag.
        /// </summary>
        public string ContainerCssClass { get; set; } = string.Empty;

        /// <summary>
        /// Css class that will be added to select2's dropdown container.
        /// </summary>
        public string DropdownCssClass { get; set; } = string.Empty;


        /// <summary>
        /// Function name which configures what data is going to be sent by ajax.
        /// </summary>
        public string Data { get; set; } = Select2AjaxDefaultProvider.Current.DefaultData;

        /// <summary>
        /// What function to call when data was changed. first parameter will be select
        /// </summary>
        public string OnChange { get; set; }


        /// <typeparam name="TController">Controller where there is an action for searching values</typeparam>
        /// <param name="actionExpression">expression which points to action for search purpose</param>
        /// <param name="name">This will be passed as form parameter. There will be value of selection</param>
        /// <param name="selectedValue">(nullable)Starting value</param>
        /// <param name="selectedValueName">(nullable)Name of the starting value</param>
        /// <returns></returns>
        /// 
        public Dictionary<string, string> AdditionalData { get; set; } = new Dictionary<string, string>();
        public static Select2AjaxViewModel Create<TController>(Expression<Func<TController, JsonResult>> actionExpression,
            string name, int? selectedValue, string selectedValueName)
            where TController : Controller
        {
            var actionName = ExpressionExtractor.ExtractMethodName(actionExpression);
            var controllerName = typeof(TController).Name;

            controllerName = controllerName.Substring(0, controllerName.IndexOf("Controller"));

            var vm = new Select2AjaxViewModel(controllerName, actionName, name, selectedValue, selectedValueName);

            return vm;
        }

        public Select2AjaxViewModel AddAdditionalData(string key, object obj)
        {
            AdditionalData.Add(key, obj.ToString());
            return this;
        }

        /// <summary>
        /// Do NOT use Explicitly.
        /// </summary>
        public Select2AjaxViewModel()
        {

        }

        private Select2AjaxViewModel(string actionName, string controllerName, string name, int? selectedValue, string selectedValueName)
        {
            ActionName = actionName;
            ControllerName = controllerName;
            SelectedValue = selectedValue;
            SelectedValueName = selectedValueName;
            Name = name;

            if (Select2AjaxDefaultProvider.Current.AutoGiveIDSameAsName)
                ID = Name;
        }

    }
}
