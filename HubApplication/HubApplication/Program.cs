
using HubApplication.Hubs;

namespace HubApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSignalR();
            //               ^^^^^^^^^^ -> SignalRni ro'yxatdan o'tkazish

            builder.Services.AddCors(policy =>
            {
                policy.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                    //     [AllowCredentials()] ishlashi uchun origin aniq bolishi lozim
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials();
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapHub<NotificationHub>("/notificationHub");
            //  ^^^^^^                         ^^^^^^^^^^^^^^^^^^ -> rout yozish (agar yozish shart bo'lmasa "" qilish kerak)
            //     |
            //     |-> Hubni middlewarega qoshish

            app.Run();
        }
    }
}
