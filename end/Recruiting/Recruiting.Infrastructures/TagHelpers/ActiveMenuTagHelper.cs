using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recruiting.Infrastructures.TagHelpers
{
    [HtmlTargetElement("li", Attributes = "active-url-contains")]
    public class ActiveMenuTagHelper : TagHelper
    {
        public string ActiveUrlContains {get; set;}

        private readonly IHttpContextAccessor _httpService;

        public ActiveMenuTagHelper(IHttpContextAccessor httpService)
        {
            _httpService = httpService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (_httpService.HttpContext.Request.Path.ToString().Contains(ActiveUrlContains))
            {
                var currentAttributes = output.Attributes["class"]?.Value;
                output.Attributes.SetAttribute("class", 
                    currentAttributes.ToString() + " active");
            }
        }
    }
}
