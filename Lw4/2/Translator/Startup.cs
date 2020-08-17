using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Translator.Data.Models;

namespace Translator
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.MapWhen(context =>
            {
                return context.Request.Query.ContainsKey("word");
            }, TranslateWord);

            app.Run(async context =>
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("the parameter 'word' is missing or is set incorrectly");
            });

        }

        private static void TranslateWord(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                List<Word> wordList = new List<Word>();
                string[] file = File.ReadAllLines("Data/Dictionary.txt");
                for (int i = 0; i < file.Length; i++)
                    file[i].ReadPair(wordList);
                string inWord = context.Request.Query["word"];

                foreach (Word word in wordList)
                {
                    if (word.RusTrans == inWord)
                    {
                        context.Response.ContentType = "text/html; charset=utf-8";
                        await context.Response.WriteAsync(word.EngTrans);
                        return;
                    }
                    else if (word.EngTrans == inWord)
                    {
                        context.Response.ContentType = "text/html; charset=utf-8";
                        await context.Response.WriteAsync(word.RusTrans);
                        return;
                    }
                }
                context.Response.ContentType = "text/html; charset=utf-8";
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Word was not found");
            });

        }
    }
}
