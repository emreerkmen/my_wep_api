using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using my_wep_api.Models;
using Microsoft.AspNetCore.Http;

namespace my_wep_api.Formatter
{
    public class VCardOutputFormatter : TextOutputFormatter
    {
        public VCardOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/vcard"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);

        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;

            var stringBuilder = new StringBuilder();

            if (context.Object is List<ContactModel>)
            {
                foreach (ContactModel model in context.Object as List<ContactModel>)
                {
                    FormatVcard(stringBuilder, model);
                }
            }
            else
            {
                var model = context.Object as ContactModel;
                FormatVcard(stringBuilder,model);
            }

            return response.WriteAsync(stringBuilder.ToString());
        }

        private static void FormatVcard(StringBuilder stringBuilder, ContactModel model)
        {
            stringBuilder.AppendLine("BEGIN:VCARD");
            stringBuilder.AppendLine("VERSOIN:2.1");
            stringBuilder.AppendLine($"N:{model.FisrtName};{model.LastName}");
            stringBuilder.AppendLine($"FN:{model.FisrtName};{model.LastName}");
            stringBuilder.AppendLine($"UID:{model.Id}\r\n");
            stringBuilder.AppendLine($"END:VCARD");
        }

        //Formatter'a gelen datanın gerçekten contact model olduğunu burdan test ediyoruz.
        protected override bool CanWriteType(Type type)
        {
            if (typeof(ContactModel).IsAssignableFrom(type)||typeof(List<ContactModel>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }
    }
}
