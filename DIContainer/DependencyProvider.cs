﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DIContainer
{
    public class DependencyProvider
    {

        DependenciesConfiguration configuration;

        public DependencyProvider(DependenciesConfiguration configuration)
        {
            validateConfiguration(configuration);
            this.configuration = configuration;         
        }

        public void validateConfiguration(DependenciesConfiguration configuration)
        {
            // Iterate over registered dependencies
            foreach (Type tDependency in configuration.dependenciesContainer.Keys)
            {
                // Checks if TDependency is a reference type
                if (tDependency.IsValueType)
                {
                    throw new ArgumentException("TDependency must be a reference type");
                }

                // Iterate over registred dependency implementations
                foreach (Type tImplementation in configuration.dependenciesContainer[tDependency])
                {
                    // Checks if TImplementation inherits from/implements TDependency
                    if (!tDependency.IsAssignableFrom(tImplementation))
                    {
                        throw new ArgumentException("TImplementation must be inherited from/implement Dependency type.");
                    }

                    // Checks if TImplementation is a not abstract class
                    if (tImplementation.IsAbstract || !tImplementation.IsClass)
                    {
                        throw new ArgumentException("TImplementation must be a non-abstract class");
                    }
                }
            }
        }

        public List<TDependency> Resolve<TDependency>()
        {

            // Need to check for generics.

            // For interface simplicity, IEnumerable is handled the same as basic resolve.
            // Methods returns List of registered implementations regardless of their amount
            Type tDependency = typeof(TDependency);
            if (tDependency.IsGenericType && tDependency.GetGenericTypeDefinition().Equals(typeof(IEnumerable<>)))
            {
                tDependency = tDependency.GenericTypeArguments[0];
            }

            // First, check if the dependency is registered at all
            if (!configuration.dependenciesContainer.ContainsKey(tDependency))
            {
                throw new KeyNotFoundException($"Dependency {tDependency.ToString()} is not registered.");
            }

            List<TDependency> result = new List<TDependency>();

            foreach(var implementation in configuration.dependenciesContainer[tDependency])
            {
                result.Add((TDependency)GetInstance(implementation));
            }

            return result;

        }

        // Invoke generic method.
        public object Resolve(Type t)
        {
            var resolveMethod = typeof(DependencyProvider).GetMethod("Resolve");
            var resolveType = resolveMethod.MakeGenericMethod(t);

            var resolved =  resolveType.Invoke(this, null) as List<object>;
            if (resolved.Count > 1)
            {
                return resolved;
            } else
            {
                return resolved[0];
            }
        }

        private object GetInstance(Type t)
        {

            // Do something with generic type


            // Get object contructor with max params
            ConstructorInfo constructor = t.GetConstructors().OrderBy(x => x.GetParameters().Length).Last();

            if (constructor != null)
            {
                // Get and recursively create object parameters

                ParameterInfo[] parameters = constructor.GetParameters();
                object[] parameterInstances =  new object[parameters.Length];

                int index = 0;
                foreach (var param in parameters)
                {

                    Type paramType = param.ParameterType;

                    // Process IEnumerables equally.
                    if (paramType.IsGenericType && paramType.GetGenericTypeDefinition().Equals(typeof(IEnumerable<>)))
                    {
                        paramType = paramType.GenericTypeArguments[0];
                    }

                    // Implementation for generic type parameters (Not IEnums)
                    if (paramType.IsGenericType)
                    {
                        throw new NotImplementedException();
                    } else
                    {
                        // Recursively create dependencies
                        if (configuration.dependenciesContainer.ContainsKey(paramType))
                        {
                            parameterInstances[index] = Resolve(paramType);
                        }
                    }
                }

                var instance = constructor.Invoke(parameterInstances);
                return instance;

            } else
            {
                throw new InvalidOperationException($"No public constructors available for {t}");
            }
            
        }


    }
}
