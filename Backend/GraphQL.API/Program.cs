using GraphQL.API.Data;
using GraphQL;

var builder = WebApplication.CreateBuilder(args);
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var AllowedOriginsList = builder.Configuration.GetSection("AllowedOriginsList").Exists() ? builder.Configuration.GetSection("AllowedOriginsList").Value.Split(',') : new string[] { "https://localhost:44321", "http://localhost:4200" };
var AllowedHeadersList = builder.Configuration.GetSection("AllowedHeadersList").Exists() ? builder.Configuration.GetSection("AllowedHeadersList").Value.Split(',') : new string[] { "Authorization" };
var AllowedMethodsList = builder.Configuration.GetSection("AllowedMethodsList").Exists() ? builder.Configuration.GetSection("AllowedMethodsList").Value.Split(',') : new string[] { "GET" };

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
             policy =>
             {
                 policy.WithOrigins(AllowedOriginsList);
                 policy.WithHeaders(AllowedHeadersList);
                 policy.WithMethods(AllowedMethodsList);
             });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGraphQL(b => b
    .AddAutoSchema<Query>()  // schema
    .AddSystemTextJson());   // serializer

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.UseGraphQL("/graphql");            // url to host GraphQL endpoint
app.UseGraphQLPlayground(
    "/",                               // url to host Playground at
    new GraphQL.Server.Ui.Playground.PlaygroundOptions
    {
        GraphQLEndPoint = "/graphql",         // url of GraphQL endpoint
        SubscriptionsEndPoint = "/graphql",   // url of GraphQL endpoint
    });
app.Run();
