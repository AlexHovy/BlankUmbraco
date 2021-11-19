﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using BlankUmbraco.ViewModels;

namespace BlankUmbraco
{
    public class NewsController : RenderController
    {
        private readonly IVariationContextAccessor _variationContextAccessor;
        private readonly ServiceContext _serviceContext;
        public NewsController(ILogger<NewsController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor, IVariationContextAccessor variationContextAccessor, ServiceContext context)
            : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _variationContextAccessor = variationContextAccessor;
            _serviceContext = context;
        }

        public override IActionResult Index()
        {
            // you are in control here!
            // create our ViewModel based on the PublishedContent of the current request:
            // set our custom properties
            var newsViewModel = new NewsViewModel(CurrentPage, new PublishedValueFallback(_serviceContext, _variationContextAccessor));

            // return our custom ViewModel
            return CurrentTemplate(newsViewModel);
        }
    }
}