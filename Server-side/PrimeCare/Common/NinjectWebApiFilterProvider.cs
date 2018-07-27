﻿// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file= NinjectWebApiFilterProvider.cs company="Perimatics Inc.">
// //   Copyright (C) 2018 Perimatics Inc. All rights reserved.
// // </copyright>
// // --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Ninject;

public class NinjectWebApiFilterProvider : IFilterProvider
{
    private readonly IKernel _kernel;

    public NinjectWebApiFilterProvider(IKernel kernel)
    {
        _kernel = kernel;
    }

    public IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
    {
        var controllerFilters = actionDescriptor.ControllerDescriptor.GetFilters()
            .Select(instance => new FilterInfo(instance, FilterScope.Controller));
        var actionFilters = actionDescriptor.GetFilters()
            .Select(instance => new FilterInfo(instance, FilterScope.Action));

        var filters = controllerFilters.Concat(actionFilters);

        foreach (var f in filters)
            // Injection
            _kernel.Inject(f.Instance);

        return filters;
    }
}