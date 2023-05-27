using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Consul
{
    public static class ConsulRegisterExtensions
    {
        public static IApplicationBuilder RegisterConsul(this IApplicationBuilder app, IConfiguration con) 
        {
            var port = int.Parse(con["Port"]);
            var consulIP = con["Consul:ConsulIP"];
            var consulPort = con["Consul:ConsulPort"];
            var consulServiceName = con["Consul:ServiceName"];

            var consulClient = new ConsulClient(x => x.Address = new Uri($"http://{consulIP}:{consulPort}"));//请求注册的 Consul 地址
            var httpCheck = new AgentServiceCheck()
            {
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),//服务启动多久后注册
                Interval = TimeSpan.FromSeconds(10),//健康检查时间间隔，或者称为心跳间隔
                HTTP = $"http://localhost:{port}/Health",//健康检查地址
                Timeout = TimeSpan.FromSeconds(5)
            };

            // Register service with consul
            var registration = new AgentServiceRegistration()
            {
                Checks = new[] { httpCheck },
                ID = Guid.NewGuid().ToString(),
                Name = consulServiceName,
                Address = "localhost",
                Port = port,
                Tags = new[] { $"urlprefix-/{consulServiceName}" }//添加 urlprefix-/servicename 格式的 tag 标签，以便 Fabio 识别
            };

            consulClient.Agent.ServiceRegister(registration).Wait();//服务启动时注册，内部实现其实就是使用 Consul API 进行注册（HttpClient发起）
                                                                   
            return app;
        }
    }
    
}
