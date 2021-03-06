﻿using Topshelf;

namespace OwinTopshelf
{
    internal static class Program
    {
        public static void Main()
        {
            // C:\app>OwinTopshelf.exe install start
            HostFactory.Run(x =>
            {
                x.Service<App>(s =>
                {
                    s.ConstructUsing(name => new App());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
                x.SetDescription("Owin Sample Service with Topshelf, Static Files and Dependency Injection");
                x.SetDisplayName("OwinTopshelf");
                x.SetServiceName("OwinTopshelf");
                x.StartAutomatically();
                x.EnableServiceRecovery(r =>
                {
                    r.RestartService(0);
                    r.OnCrashOnly();
                    r.SetResetPeriod(1);
                });
            });
        }
    }
}