using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtils.Html;

namespace WebUtilsTests.Html
{
    [TestClass]
    public class ClassFieldTests
    {
        //class="{0}"
        string classTemplate = "class=\"{0}\"";
        [TestMethod]
        public void EmptyClassesTest()
        {
            var field = new ClassField();

            
            Assert.AreEqual(string.Format(classTemplate, ""), field.ToString());
        }

        [TestMethod]
        public void OneClassTest()
        {
            var field = new ClassField()
                .AddClass("test");


            Assert.IsTrue(field.hasClass("test"));
            Assert.AreEqual(string.Format(classTemplate, "test"), field.ToString());
        }

        [TestMethod]
        public void RemoveClassTest()
        {
            var field = new ClassField()
                .AddClass("test")
                .RemoveClass("test");

            Assert.IsFalse(field.hasClass("test"));
            Assert.AreEqual(string.Format(classTemplate, ""), field.ToString());
        }

        [TestMethod]
        public void NoDuplicateTest()
        {
            var field = new ClassField()
                .AddClass("test")
                .AddClass("test");


            Assert.IsTrue(field.hasClass("test"));
            Assert.AreEqual(string.Format(classTemplate, "test"), field.ToString());
        }

        [TestMethod]
        public void TwoClassesTest()
        {
            var field = new ClassField()
                .AddClass("test")
                .AddClass("test2");


            Assert.IsTrue(field.hasClass("test"));
            Assert.IsTrue(field.hasClass("test2"));
            Assert.AreEqual(string.Format(classTemplate, "test test2"), field.ToString());
        }
    }
}
