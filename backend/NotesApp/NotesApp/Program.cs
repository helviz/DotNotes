using NotesApp.Data;
using NotesApp.Repository;
using NotesApp.Repository.Impl;
using NotesApp.Service;
using NotesApp.Service.Impl;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddDbContext<NotesContext>();

/*Repository*/
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<INoteBookRepository, NoteBookRespository>();
builder.Services.AddScoped<IAttachmentRepository, AttachmentRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IAttachmentRepository, AttachmentRepository>();
builder.Services.AddScoped<IUserRepository, UserRespository > ();

/*Services*/
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<INoteBookService, NoteBookService>();
builder.Services.AddScoped<IAttachmentService, AttachmentService>();
builder.Services.AddScoped<ITagService, TagService>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

