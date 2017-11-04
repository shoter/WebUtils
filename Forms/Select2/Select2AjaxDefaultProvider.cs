using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtils.Forms.Select2
{
    public class Select2AjaxDefaultProvider
    {
        /// <summary>
        /// How many results per page when searching.
        /// </summary>
        public int DefaultPageSize { get; set; } = 30;
        /// <summary>
        /// Javascript function used to render single item in search box. 1 argument is passed which is item
        /// </summary>
        public string DefaultTemplateResult { get; set; } = "Common.Select2.formatDataDefault";
        /// <summary>
        /// Javascript used to render selected item from search box. 1 argument is passed which is item.
        /// </summary>
        public string DefaultTemplateSelection { get; set; } = "Common.Select2.formatDataSelectionDefault";
        /// <summary>
        /// Time between consecutive ajax requests
        /// </summary>
        public int DefaultQuietMillis { get; set; } = 250;
        /// <summary>
        /// The number of milliseconds to wait for the user to stop typing before issuing the ajax request.
        /// </summary>
        public int DefaultDelay { get; set; } = 250;
        /// <summary>
        /// Number of characters necessary to start a search.
        /// </summary>
        public int DefaultMinimumInputLength { get; set; } = 2;
        /// <summary>
        /// Function name which configures what data is going to be sent by ajax.
        /// </summary>
        public string DefaultData { get; set; } = "Common.Select2.dataDefault";
        public string JavascriptFile { get; set; } = string.Empty;
        public string StyleFile { get; set; } = string.Empty;
        /// <summary>
        /// If set to true then ID will be the same as Name at create time.
        /// </summary>
        public bool AutoGiveIDSameAsName { get; set; } = false;


        public static Select2AjaxDefaultProvider Current { get; protected set; }

        static Select2AjaxDefaultProvider()
        {
            //We always need some default behaviour
            Current = new Select2AjaxDefaultProvider();
        }

        public Select2AjaxDefaultProvider()
        {
            Current = this;
        }
    }
}
