using ErpSystem_Services.Implementation;
using ErpSystem_Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddTransient<ICourseFeesService, CourseFeesService>();
builder.Services.AddTransient<ICourseService, CourseService>();
builder.Services.AddTransient<ICourseTopicsService, CourseTopicsService>();
builder.Services.AddTransient<IInterviewQuestionAnswersService, InterviewQuestionAnswersService>();
builder.Services.AddTransient<IInterviewQuestionsService, InterviewQuestionsService>();
builder.Services.AddTransient<IMcqsQuestionsService, McqsQuestionsService>();
builder.Services.AddTransient<IProgramQuestionServices, ProgramQuestionServices>();
builder.Services.AddTransient<IProgramQuestionAnswersService, ProgramQuestionAnswersService>();
builder.Services.AddTransient<ITopicContentsService, TopicContentsService>();
builder.Services.AddTransient<ITopicService, TopicService>();
builder.Services.AddTransient<IVideoService, VideoService>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapAreaControllerRoute(
    name: "DeveloperArea",
    areaName: "Developer",
    pattern: "Developer/{controller=Course}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Course}/{action=Index}/{id?}",
    defaults: new { area = "Developer" });

app.Run();
