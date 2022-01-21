﻿using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OnlineShop.Web.Filters;

internal class ValidationExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ValidationException validationException)
        {
            var errors = validationException.Errors
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(errorGroup => errorGroup.Key, errorGroup => errorGroup.ToArray());

            var details = new ValidationProblemDetails(errors);

            context.Result = new BadRequestObjectResult(details);
            context.ExceptionHandled = true;
        }
    }
}