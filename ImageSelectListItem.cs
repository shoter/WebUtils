using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebUtils
{
    public class ImageSelectListItem : SelectListItem
    {
        /// <summary>
        /// Path to image. It should display image when used in src attribute of <img> tag
        /// </summary>
        public string ImagePath { get; set; }
    }
}
