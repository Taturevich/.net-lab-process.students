using System.Collections.Generic;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace WebService.Api.Filters
{
    public class AuthTokenFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            swaggerDoc.paths.Add("/token", new PathItem
            {
                post = new Operation
                {
                    tags = new[] { "Authentication" },
                    consumes = new[] { "application/x-www-form-url-encoded" },
                    produces = new[] { "application/json" },
                    parameters = new List<Parameter>
                    {
                        new Parameter
                        {
                            type = "string",
                            name = "grant_type",
                            @default = "password",
                            required = false,
                            @in = "formData"
                        },
                        new Parameter
                        {
                            type = "string",
                            name = "username",
                            required = false,
                            @in = "formData"
                        },
                        new Parameter
                        {
                            type = "string",
                            format = "password",
                            name = "password",
                            required = false,
                            @in = "formData"
                        }
                    }
                }
            });
        }
    }
}