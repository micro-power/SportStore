using FluentAssertions;
using NUnit.Framework;
using SportStore.HtmlHelpers;
using SportStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SportStore.Tests
{
    [TestFixture]
    class PagingTests
    {
        [Test]
        public void Can_Generate_Page_Links()
        {
            // przygotowanie — definiowanie metody pomocniczej HTML — potrzebujemy tego,
            // aby użyć metody rozszerzającej
            HtmlHelper myHelper = null;
            // przygotowanie — tworzenie danych PagingInfo
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            // przygotowanie — konfigurowanie delegatu z użyciem wyrażenia lambda
            Func<int, string> pageUrlDelegate = i => "Strona" + i;
            // działanie
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);


            // asercje
            result.ToString().Should().Be(@"<a class=""btn btn-default"" href=""Strona1"">1</a>"
            + @"<a class=""btn btn-default btn-primary selected"" href=""Strona2"">2</a>"
            + @"<a class=""btn btn-default"" href=""Strona3"">3</a>");
        }
    }
}
