```
单个consul测试 到consul.exe在的文件夹 cmd运行
consul agent -dev
```

```
//启动Consul集群
cd D:\worker\Consul 
consul agent –-server --ui --bootstrap-expect=3 --data-dir D:\worker\Consul\ConsulData --node=consul-Server1 -–client=0.0.0.0 --bind=127.0.0.1 –datacenter=dc1 --config-dir D:\worker\Consul\ConsulData\config.json

consul agent –server -ui -bootstrap-expect=3 -data-dir D:\worker\Consul\ConsulData2 -node=consul-Server2 –client=0.0.0.0 -bind=127.0.0.1 -config-dir D:\worker\Consul\ConsulData2\config.json –datacenter=dc1 –join 127.0.0.1:6301

consul agent –server -ui -bootstrap-expect=3 -data-dir D:\worker\Consul\ConsulData3 -node=consul-Server3 –client=0.0.0.0 -bind=127.0.0.1 -config-dir D:\worker\Consul\ConsulData3\config.json –datacenter=dc1 –join 127.0.0.1:6301

consul agent -ui –client=0.0.0.0 –bind=127.0.0.1  -data-dir=D:\worker\Consul\ConsulData\Client -node=consul-Client -config-dir=D:\worker\Consul\Client\config.json –datacenter=dc1  -join 127.0.0.1:6301
```

```
//启动Nginx 对Consul进行负载均衡
cd D:\worker\Nginx\nginx-1.24.0
start nginx
```

```
//到所在项目目录下
//启动IdentityServer4
dotnet run 

//启动服务1
//通过不同json配置环境 根据环境调不同端口 
//appsetting.test1.json 
dotnet run --urls http://localhost:1001
dotnet run --urls --environment test1 http://localhost:1002

//启动服务2
dotnet run --urls http://localhost:1003
dotnet run --urls --environment test2 http://localhost:1004

//启动网关
dotnet run 
```



```
通过批处理启动所有服务
乱码-->另存为-ANSI编码
命令前面要两个--
```

