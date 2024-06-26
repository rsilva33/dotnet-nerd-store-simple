﻿using NerdStore.Core.Messages.CommomMessages.Notifications;
using NerdStore.Sales.Application.Commands.Order;
using NerdStore.Sales.Application.Events;
using NerdStore.Sales.Application.Queries.Order;
using NerdStore.Sales.Data;
using NerdStore.Sales.Data.Repository;
using NerdStore.Sales.Domain.Abstractions;

namespace NerdStore.WebApp.MVC.Configurations;

public static class DependencyInjection
{
    public static void RegisterServices(this IServiceCollection services)
    {
        //Domain Bus (mediatork)
        services.AddScoped<IMediatorHandler, MediatorHandler>();

        //Catalog
        services.AddScoped<CatalogContext>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductAppService, ProductAppService>();
        services.AddScoped<IStockService, StockService>();

        services.AddScoped<INotificationHandler<ProductBelowStockEvent>, ProductEventHandler>();

        //Sales
        services.AddScoped<SalesContext>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderQueries, OrderQueries>();
        services.AddScoped<IRequestHandler<AddItemOrderCommand, bool>, OrderCommandHandler>();

        services.AddScoped<INotificationHandler<OrderItemAddedEvent>, OrderHandlerEvent>();
        services.AddScoped<INotificationHandler<DraftOrderStartedEvent>, OrderHandlerEvent>();
        services.AddScoped<INotificationHandler<UpdateOrderEvent>, OrderHandlerEvent>();



        //Notifications
        services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
    }
}
