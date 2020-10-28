using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GatherData
{
    public class Handler : INotifyPropertyChanging
    {
        public string NameAssembly;
        private static Type[] types;
        Assembly assembly;


        public  Collector collector;
        public  Collector collectroSub;

        public List<Collector> listTypes;
        

        public event PropertyChangingEventHandler PropertyChanging;

        public Handler(string AssemblyPath)
        {
            listTypes = new List<Collector>();
            assembly = Assembly.LoadFrom(AssemblyPath);
            NameAssembly = assembly.ManifestModule.Name;
            types = assembly.GetTypes();
            GatherData();
            
        }

        public void GatherData()
        {
            foreach(Type type in types)            
                AddType(type);
            SearchSubClass();
        }

        public void AddType(Type t)
        {                               
            collector = new Collector(t);
            listTypes.Add(collector);
        }
        public void SearchSubClass()
        {
            foreach (Type type in types)
            {
              
                foreach (Type t in type.GetNestedTypes())
                {
                    foreach (Collector collector in listTypes)
                    {
                        if (collector.type.Name == t.Name)
                        {
                            foreach (Collector collector1 in listTypes)
                            {
                                if (collector1.type.Name == type.Name)
                                {
                                    collector1.subListTypes.Add(collector);
                                    listTypes.Remove(collector);
                                    goto a1;
                                }
                            }
                        }

                    }
                    a1:;
                }
            }

          /*  foreach (Type type in types)
            {
                foreach(FieldInfo memberInfo in type.GetFields())
                {
                    foreach (MethodInfo method in GetExtensionMethods(assembly,typeof(string)))
                    {
                        foreach(Collector collector in listTypes)
                        {
                            if (collector.type.Name == type.Name)
                            {
                                foreach (MethodInfo methodInfo in type.GetMethods())
                                {
                                    if (methodInfo.IsDefined(typeof(ExtensionAttribute), false) && (memberInfo.Name == method.Name))
                                    {
                                        foreach (Collector collector2 in listTypes)
                                        {
                                            if (collector2.type.Name == type.Name)
                                            {
                                                collectroSub = collector2;
                                                listTypes.Remove(collector2);
                                                break;
                                            }
                                        }

                                    }

                                }
                                collector.subListTypes.Add(collectroSub);
                                collectroSub = null;
                                
                            }
                        }
                    }                    
                }
                
            }*/          
        }
       /* static IEnumerable<MethodInfo> GetExtensionMethods(Assembly assembly,Type extendedType)
        {
            var query = from type in assembly.GetTypes()
                        where type.IsSealed && !type.IsGenericType && !type.IsNested
                        from method in type.GetMethods(BindingFlags.Static
                            | BindingFlags.Public | BindingFlags.NonPublic)
                        where method.IsDefined(typeof(ExtensionAttribute), false)
                        where method.GetParameters()[0].ParameterType == extendedType
                        select method;
            return query;
        }*/
    }

}


