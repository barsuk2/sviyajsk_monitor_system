using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.TagHelpers
{
    public class UnityTagHelper : TagHelper
    {
        public string unitytitle { get; set; }
        public string unityfolder { get; set; }
        public string unityname { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "collapse");
            output.Attributes.Add("id", "Unity");
            output.Content.SetHtmlContent(CreateCanvas());
            Dictionary<string, string> attr = new Dictionary<string, string>();
            attr.Add("class", "logo");
            output.Content.AppendHtml(BuildDiv(attr, ""));
            attr.Clear();
            attr.Add("class", "fullscreen");
            output.Content.AppendHtml(BuildDivImage(attr, "/TemplateData/fullscreen.png"));
            attr.Clear();
            attr.Add("class", "title");
            output.Content.AppendHtml(BuildDiv(attr, unitytitle));
            output.PostContent.AppendHtml(BuildUnityScript());
            output.PostContent.AppendHtml(BuildScriptFromsrc($"~/{unityfolder}/UnityLoader.js"));
            //TagBuilder builder2 = new TagBuilder("div");

           
            //output.Content.SetHtmlContent()
            //output.Content.SetHtmlContent($"<canvas class=\"emscripten\" id=\"canvas\" oncontextmenu=\"event.preventDefault()\" height=\"600\" width=\"960\"></canvas><div class=\"logo\"></div><div class=\"fullscreen\"><img src = \"/TemplateData/fullscreen.png\" width=\"38\" height=\"38\" alt=\"Fullscreen\" title=\"Fullscreen\" onclick=\"SetFullscreen(1);\" /></div><div class=\"title\">Отметить образец</div>");
            
        }

        TagBuilder CreateCanvas()
        {
            TagBuilder builder = new TagBuilder("canvas");
            builder.TagRenderMode = TagRenderMode.Normal;
            builder.Attributes.Add("class", "emscripten");
            builder.Attributes.Add("oncontextmenu", "event.preventDefault()");
            builder.Attributes.Add("height", "600");
            builder.Attributes.Add("width", "960");
            return builder;
        }

        TagBuilder BuildDiv(Dictionary<string,string> attributes,string content)
        {
            TagBuilder builder = new TagBuilder("div");
            foreach(var item in attributes)
            {
                builder.Attributes.Add(item.Key, item.Value);
            }
            builder.InnerHtml.Append(content);
            return builder;
        }
        
        TagBuilder BuildDivImage(Dictionary<string, string> attributes,string src)
        {
            TagBuilder builder = new TagBuilder("div");
            foreach (var item in attributes)
            {
                builder.Attributes.Add(item.Key, item.Value);
            }
            TagBuilder image = new TagBuilder("img");
            image.TagRenderMode = TagRenderMode.SelfClosing;
            image.Attributes.Add("src", src);
            image.Attributes.Add("width", "38");
            image.Attributes.Add("height", "38");
            image.Attributes.Add("alt", "Fullscreen");
            image.Attributes.Add("title", "Fullscreen");
            image.Attributes.Add("onclick", "SetFullscreen(1);");
            builder.InnerHtml.AppendHtml(image);
            return builder;
        }

        TagBuilder BuildUnityScript()
        {
            TagBuilder builder = new TagBuilder("script");
            builder.Attributes.Add("type", "text/javascript");
            builder.InnerHtml.Append(" var Module = {");
            builder.InnerHtml.Append(" TOTAL_MEMORY: 268435456,");
            builder.InnerHtml.Append("errorhandler: null,");
            builder.InnerHtml.Append(" compatibilitycheck: null,");
            builder.InnerHtml.Append("doNotCaptureKeyboard: true,");
            builder.InnerHtml.Append($" dataUrl: \" / {unityfolder} / {unityname}.data\",");
            builder.InnerHtml.Append($"codeUrl: \" / {unityfolder} / {unityname}.js\"");
            builder.InnerHtml.Append($"asmUrl: \" / {unityfolder} / {unityname}.asm.js\",");
            builder.InnerHtml.Append($"memUrl: \" / {unityfolder} / {unityname}.mem\",");
            builder.InnerHtml.Append("};");
            return builder;
        }


        TagBuilder BuildScriptFromsrc(string src)
        {
            TagBuilder builder = new TagBuilder("script");
            builder.Attributes.Add("src", src);
            return builder;
        }
    }
}
