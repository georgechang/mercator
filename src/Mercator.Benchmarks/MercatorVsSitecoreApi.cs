using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using Mercator.Benchmarks;
using Mercator.Helpers;
using Sitecore.Data.Fields;
using Sitecore.FakeDb;

namespace Mercator.Benchmarks
{
    [ClrJob(baseline: true)]
    public class MercatorVsSitecoreApi
    {
        private Db database;

        [GlobalSetup]
        public void Setup()
        {
            database = new Db();
            var dbItem = new DbItem("Home");

            var titleField = new DbField("Title") {Value = "Home"};
            dbItem.Add(titleField);

            var descriptionField = new DbField("Description") {Value = "<h1>Test Description</h1><p>This is the description to the item</p>"};
            dbItem.Add(descriptionField);

            var linkField = new DbField("Link") {Value = "<link linktype=\"external\" url=\"http://google.com\" />"};
            dbItem.Add(linkField);
        }

        [Benchmark]
        public void Mercator()
        {
            var item = database.GetItem("/sitecore/content/Home").Map<BenchmarkViewModel>();
            Console.WriteLine($"Title: { item.Title }");
            Console.WriteLine($"Description: { item.Description.GetPlainText() }");
            Console.WriteLine($"Link: { item.Link.LinkType }");
        }

        [Benchmark]
        public void SitecoreApi()
        {
            var item = database.GetItem("/sitecore/content/Home");
            Console.WriteLine($"Title: { item["Title"] }");
            Console.WriteLine($"Description: { ((HtmlField)item.Fields["Description"]).GetPlainText() }");
            Console.WriteLine($"Link: { ((LinkField)item.Fields["Link"]).LinkType }");
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            database.Dispose();
        }
    }
}