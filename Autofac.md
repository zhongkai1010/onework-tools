# Autofac

## 注册组件

### 容器

- var builder = new ContainerBuilder()
- using(var scope = container.BeginLifetimeScope())

### 注册概念

- 通过类型注册

	- builder.RegisterType<ConsoleLogger>().As<ILogger>();
	- builder.RegisterType(typeof(ConfigReader)).As<ILogger>();

- 指定构造函数

	- builder.RegisterType(typeof(MyComponent)).UsingConstructor(typeof(ILogger), typeof(IConfigReader));

- 实例组件

	- var output = new StringWriter();
builder.RegisterInstance(output).As<TextWriter>();
	- RegisterInstance 
	- ExternallyOwned 

- Lambda表达式组件

	- builder.Register(c => new A(c.Resolve<B>()));

- 复杂参数

	- builder.Register(c => new UserSession(DateTime.Now.AddMinutes(25)));

- 参数注入

	- builder.Register(c => new A(){ MyB = c.ResolveOptional<B>() });

- 通过参数值选择具体的实现
- 开放泛型组件

	- builder.RegisterGeneric(typeof(NHibernateRepository<>))
       .As(typeof(IRepository<>))
       .InstancePerLifetimeScope();
	- RegisterGeneric()

- 服务 vs. 组件
- 默认注册

	- Autofac将使用最后注册的组件作为服务的提供方
	- PreserveExistingDefaults()

	  builder.RegisterType<ConsoleLogger>().As<ILogger>();
	  builder.RegisterType<FileLogger>().As<ILogger>().PreserveExistingDefaults();
	  上例中, ConsoleLogger 将会作为 ILogger 默认的服务提供方因为最后注册的 FileLogger 使用了 PreserveExistingDefaults().

- 有条件的注册
- 注册的配置
- 动态提供的注册

### 程序集扫描

- RegisterAssemblyTypes()

	- 过滤类型

		- .PublicOnly()

		  仅注册公开的类型

		- .Where(t => t.Name.EndsWith("Repository"));
		- .Except<MyUnwantedType>();

	- 指定服务

		- builder.RegisterAssemblyTypes(asm)
       .Where(t => t.Name.EndsWith("Repository"))
       .As<IRepository>();
		- AsImplementedInterfaces()
		- AsClosedTypesOf(open)
		- AsSelf()	

- RegisterAssemblyModules()

  public class AModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.Register(c => new AComponent()).As<AComponent>();
    }
  }
  
  public class BModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.Register(c => new BComponent()).As<BComponent>();
    }
  }

### IIS 托管的 Web 应用

- var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();

## 解析服务

### Resolve()

### 服务是否被注册

- ResolveOptional()
- TryResolve()

### DependencyResolutionException

- 解析服务时, Autofac 自动链接起服务所需的整个依赖链上不同层级并解析所有的依赖来完整地构建服务. 如果你有处理不当的 循环依赖 或缺少了必需的依赖, 你将得到一个

### 直接依赖 (B)

- public class A
{
  public A(B dependency) { ... }
}

### 延迟实例化 (Lazy<B>)

### 可控生命周期 (Owned<B>)

### 动态实例化 (Func<B>)

## 生命周期

### 作用域

- 创建一个新的生命周期作用域

	- BeginLifetimeScope()

	  using(var scope = container.BeginLifetimeScope())
	  {
	    // Resolve services from a scope that is a child
	    // of the root container.
	    var service = scope.Resolve<IService>();
	  
	    // You can also create nested scopes...
	    using(var unitOfWorkScope = scope.BeginLifetimeScope())
	    {
	      var anotherService = unitOfWorkScope.Resolve<IOther>();
	    }
	  }

- 给生命周期作用域打标签

	- .InstancePerMatchingLifetimeScope()

	  // Register your transaction-level shared component
	  // as InstancePerMatchingLifetimeScope and give it
	  // a "known tag" that you'll use when starting new
	  // transactions.
	  var builder = new ContainerBuilder();
	  builder.RegisterType<EmailSender>()
	         .As<IEmailSender>()
	         .InstancePerMatchingLifetimeScope("transaction");
	  
	  // Both the order processor and the receipt manager
	  // need to send email notifications.
	  builder.RegisterType<OrderProcessor>()
	         .As<IOrderProcessor>();
	  builder.RegisterType<ReceiptManager>()
	         .As<IReceiptManager>();
	  
	  var container = builder.Build();
	  
	  
	  // Create transaction scopes with a tag.
	  using(var transactionScope = container.BeginLifetimeScope("transaction"))
	  {
	    using(var orderScope = transactionScope.BeginLifetimeScope())
	    {
	      // This would resolve an IEmailSender to use, but the
	      // IEmailSender would "live" in the parent transaction
	      // scope and be shared across any children of the
	      // transaction scope because of that tag.
	      var op = orderScope.Resolve<IOrderProcessor>();
	      op.ProcessOrder();
	    }
	  
	    using(var receiptScope = transactionScope.BeginLifetimeScope())
	    {
	      // This would also resolve an IEmailSender to use, but it
	      // would find the existing IEmailSender in the parent
	      // scope and use that. It'd be the same instance used
	      // by the order processor.
	      var rm = receiptScope.Resolve<IReceiptManager>();
	      rm.SendReceipt();
	    }
	  }

- 向生命周期作用域内添加注册

  using(var scope = container.BeginLifetimeScope(
    builder =>
    {
      builder.RegisterType<Override>().As<IService>();
      builder.RegisterModule<MyModule>();
    }))
  {
    // The additional registrations will be available
    // only in this lifetime scope.
  }

### 实例作用域

- 每个依赖一个实例(Instance Per Dependency)

	- .InstancePerDependency();

- 单一实例(Single Instance)

	- .SingleInstance();

- 每个生命周期作用域一个实例(Instance Per Lifetime Scope)

	- .InstancePerLifetimeScope();

- 每个匹配的生命周期作用域一个实例(Instance Per Matching Lifetime Scope)

	- .InstancePerMatchingLifetimeScope()

	  var builder = new ContainerBuilder();
	  builder.RegisterType<Worker>().InstancePerMatchingLifetimeScope("myrequest");

- 每个请求一个实例(Instance Per Request)

	- .InstancePerRequest()

	  var builder = new ContainerBuilder();
	  builder.RegisterType<Worker>().InstancePerRequest();

- 每次被拥有一个实例(Instance Per Owned)

	- .InstancePerOwned<MessageHandler>();

	  var builder = new ContainerBuilder();
	  builder.RegisterType<MessageHandler>();
	  builder.RegisterType<ServiceForHandler>().InstancePerOwned<MessageHandler>();

- 线程作用域(Thread Scope)

	- InstancePerLifetimeScope

## 集成

### ASP.NET Core 3.0+

- .UseServiceProviderFactory(new AutofacServiceProviderFactory())

  public class Program
  {
    public static void Main(string[] args)
    {
      // ASP.NET Core 3.0+:
      // The UseServiceProviderFactory call attaches the
      // Autofac provider to the generic hosting mechanism.
      var host = Host.CreateDefaultBuilder(args)
          .UseServiceProviderFactory(new AutofacServiceProviderFactory())
          .ConfigureWebHostDefaults(webHostBuilder => {
            webHostBuilder
              .UseContentRoot(Directory.GetCurrentDirectory())
              .UseIISIntegration()
              .UseStartup<Startup>();
          })
          .Build();
  
      host.Run();
    }
  }

- public void ConfigureContainer(ContainerBuilder builder)
- AddControllersAsServices()

  public class Startup
  {
    // Omitting extra stuff so you can see the important part...
    public void ConfigureServices(IServiceCollection services)
    {
      // Add controllers as services so they'll be resolved.
      services.AddMvc().AddControllersAsServices();
    }
  
    public void ConfigureContainer(ContainerBuilder builder)
    {
      // If you want to set up a controller for, say, property injection
      // you can override the controller registration after populating services.
      builder.RegisterType<MyController>().PropertiesAutowired();
    }
  }

*XMind - Trial Version*