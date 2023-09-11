using Chapter.Contexts;
using Chapter.Interfacies;
using Chapter.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//AddCors=> verifica se as requisiçoes estao vindo do lugar certo na conexao do banco
builder.Services.AddCors(Options =>
    {
        Options.AddPolicy("CorsPolicy", builder =>
        {
            builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
        });
});

//Incluir metodo de Atualização e autenticação das tabelas para configurar o token
//===========================================================================================
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer"; //Autentica a tabela

}).AddJwtBearer(options =>

    {

        options.TokenValidationParameters = new TokenValidationParameters

        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chapter-chave-autenticacao")), //passa a chave simetrica que está codifiacda
            ClockSkew = TimeSpan.FromMinutes(60), //tempo para fazer a autenticação, toda hora fica caindo o seu logim
            ValidIssuer = "chapter.webapi",
            ValidAudience = "chapter.webapi",
        };
    }

);
//================================================================================================================

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ChapterContext, ChapterContext>(); //Adiciona na program o que foi feito na classe ChapterContext para chamar o banco 
builder.Services.AddTransient<LivroRepository, LivroRepository>(); //Adiciona na program o que foi feito na classe LivroRepository
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//chama a politica do CorsPolicy
app.UseCors("CorsPolicy");

//Faz a autenticação do token
app.UseAuthentication();


app.UseAuthorization();

app.MapControllers();

app.Run(); //Chama a pagina Fake Front do Swagger 
