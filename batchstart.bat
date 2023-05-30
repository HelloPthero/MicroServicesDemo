start cmd /k "cd/d D:\worker\Consul && consul agent --server --ui --bootstrap-expect=3 --data-dir D:\worker\Consul\ConsulData --node=consul-Server1 --client=0.0.0.0 --bind=127.0.0.1 --datacenter=dc1 --config-dir D:\worker\Consul\ConsulData\config.json"
start cmd /k "cd/d D:\worker\Consul && consul agent --server --ui --bootstrap-expect=3 --data-dir D:\worker\Consul\ConsulData2 --node=consul-Server2 --client=0.0.0.0 --bind=127.0.0.1 --datacenter=dc1 --config-dir D:\worker\Consul\ConsulData2\config.json --datacenter=dc1 --join 127.0.0.1:6301"
start cmd /k "cd/d D:\worker\Consul && consul agent --server --ui --bootstrap-expect=3 --data-dir D:\worker\Consul\ConsulData3 --node=consul-Server3 --client=0.0.0.0 --bind=127.0.0.1 --datacenter=dc1 --config-dir D:\worker\Consul\ConsulData3\config.json --datacenter=dc1 --join 127.0.0.1:6301"
start cmd /k "cd/d D:\worker\Consul && consul agent --ui --client=0.0.0.0 --bind=127.0.0.1 --data-dir=D:\worker\Consul\ConsulData\Client --node=consul-Client --config-dir=D:\worker\Consul\Client\config.json --datacenter=dc1 --join 127.0.0.1:6301"
start cmd /k "cd/d D:\worker\Nginx\nginx-1.24.0 && start nginx"
TIMEOUT /T 10

start cmd /k "cd/d C:\Users\wangchengjian\source\repos\OcelotDemo\IdentityServer && dotnet run"
start cmd /k "cd/d C:\Users\wangchengjian\source\repos\OcelotDemo\OcelotDemo && dotnet run"
start cmd /k "cd/d C:\Users\wangchengjian\source\repos\OcelotDemo\Test1Api && dotnet run --urls http://localhost:1001"
start cmd /k "cd/d C:\Users\wangchengjian\source\repos\OcelotDemo\Test1Api && dotnet run --environment test1 --urls http://localhost:1002"
start cmd /k "cd/d C:\Users\wangchengjian\source\repos\OcelotDemo\Test2Api && dotnet run --urls http://localhost:1003"
start cmd /k "cd/d C:\Users\wangchengjian\source\repos\OcelotDemo\Test2Api && dotnet run --environment test2 --urls http://localhost:1004"



