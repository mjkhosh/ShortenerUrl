using Microsoft.EntityFrameworkCore;
using ShortenerUrl.Infra.Data.Sql.Command.Common;
using ShortenerUrl.Infra.Data.Sql.Query.Common;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager Configuration = builder.Configuration;
builder.Services.AddDbContext<ShortenerUrlSqlCommandDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("ShortenerUrlSqlCommand")));
builder.Services.AddDbContext<ShortenerUrlSqlQueryDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("ShortenerUrlSqlQuery")));

var app = builder.Build();


app.Run();