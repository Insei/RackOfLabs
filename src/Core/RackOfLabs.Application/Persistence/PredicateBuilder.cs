﻿using System.Linq.Expressions;

namespace RackOfLabs.Application.Persistence;

public class PredicateBuilder
{
    public static Expression<Func<T, bool>> True<T>()
    {
        return _ => true;
    }

    public static Expression<Func<T, bool>> False<T>()
    {
        return _ => false;
    }

    public static Expression<Func<T, bool>> PredicateSearchInAllFields<T>(string keyword)
    {
        var predicate = False<T>();
        var properties = typeof(T).GetProperties();
        // TODO: Add search in enums properties
        foreach (var propertyInfo in properties.Where(p => p.GetGetMethod()?.IsVirtual is false && !p.PropertyType.IsEnum))
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, propertyInfo);
            var propertyAsObject = Expression.Convert(property, typeof(object));
            var nullCheck = Expression.NotEqual(propertyAsObject, Expression.Constant(null, typeof(object)));
            var propertyAsString = Expression.Call(property, "ToString", null, null);
            var keywordExpression = Expression.Constant(keyword);
            var contains = propertyInfo.PropertyType == typeof(string) ? Expression.Call(property, "Contains", null, keywordExpression) : Expression.Call(propertyAsString, "Contains", null, keywordExpression);
            var lambda = Expression.Lambda(Expression.AndAlso(nullCheck, contains), parameter);
            predicate = Or(predicate, (Expression<Func<T, bool>>)lambda);
        }

        return predicate;
    }
    
    public static Expression<Func<T, object>>? ToLambda<T>(string propertyName)
    {
        // Property not found
        if(!typeof(T)
           .GetProperties().Any(p => p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase)))
            return null;
        // Property is Virtual
        if (typeof(T)
            .GetProperties().Any(p => p.GetGetMethod()?.IsVirtual is true &&
                                      p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase)))
            return null;
        
        var parameter = Expression.Parameter(typeof(T));
        var property = Expression.Property(parameter, propertyName);
        var propAsObject = Expression.Convert(property, typeof(object));

        return Expression.Lambda<Func<T, object>>(propAsObject, parameter);
    }
    
    public static Expression<Func<T, bool>> Or<T>(Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
    {
        var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
        return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
    }
    
    public static Expression<Func<T, bool>> And<T>(Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
    {
        var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
        return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
    }
}