using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebUtils.Html
{
    public class ClassField
    {
        private List<string> classes = new List<string>();

        public ClassField()
        {}
        
        public ClassField(params string[] classes)
        {
            foreach (var c in classes)
                AddClass(c);
        }

        public ClassField AddClass(string @class)
        {
            if (hasClass(@class) == false)
                classes.Add(@class);

            return this;
        }

        public ClassField RemoveClass(string @class)
        {
            classes.Remove(@class);
            return this;
        }

        public bool hasClass(string @class)
        {
            return classes.Any(c => c == @class);
        }

        public MvcHtmlString ToHtml(bool renderClassAttribute = true)
        {
            return MvcHtmlString.Create(ToString(renderClassAttribute));
        }

        public override string ToString()
        {
            return ToString(renderClassAttribute: true);
        }

        public string ToString(bool renderClassAttribute)
        {
            StringBuilder ret = new StringBuilder();
            if (renderClassAttribute)
                ret.Append("class=\"");

            foreach (var @class in classes)
            {
                ret.Append(@class);
                ret.Append(" ");
            }
            //It will delete non needed space
            if (classes.Count > 0)
                ret.Length--;
            if(renderClassAttribute)
            ret.Append("\"");

            return ret.ToString();
        }
    }
}
