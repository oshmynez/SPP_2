using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GatherData
{
    public class Collector: INotifyPropertyChanging
    {
        
        public Type type;
        

        public List<string> listData;
        public List<Collector> subListTypes = new List<Collector>();
        
        public bool haveExtendedMethods = false;
        public List<string> nameExtendedMethods;
        public event PropertyChangingEventHandler PropertyChanging;

        public Collector(Type type)
        {
            nameExtendedMethods = new List<string>();
            subListTypes = new List<Collector>();
            this.type = type;            
            listData = new List<string>();
            CheckType(type);
           
        }
        public void CheckType(Type t)
        {
            
            if (t.IsEnum)
                SearchEnum();
            else // Interface, Class, Struct
            {                
                SearchFields(t);
                SearchProperties(t);
                SearchMethodsConstructors(t);
                SearchEvents(t);                
            }                            
        }


        public void SearchFields(Type t)
        {
            foreach (FieldInfo fieldInfo in t.GetFields())            
                listData.Add(fieldInfo.FieldType.Name + " " + fieldInfo.Name);            
        }

        public void SearchProperties(Type t)
        {
            foreach (PropertyInfo propertyInfo  in t.GetProperties())            
                listData.Add(propertyInfo.PropertyType.Name + " " + propertyInfo.Name);            
        }

        public void SearchMethodsConstructors(Type t)
        {
            foreach (ConstructorInfo constructorInfo in t.GetConstructors())
            {
                StringBuilder signature = new StringBuilder();
                foreach (ParameterInfo parameterInfo in constructorInfo.GetParameters())                
                    signature.Append(parameterInfo.ParameterType.Name + " " + parameterInfo.Name + ", ");                    
                                              
                listData.Add(constructorInfo.Name + "(" + signature + ")");

            }

            if (t.IsSealed && !t.IsGenericType && !t.IsNested)
            {

            }
            
            foreach (MethodInfo methodInfo in t.GetMethods())
            {
                if (methodInfo.IsDefined(typeof(ExtensionAttribute), false))
                {
                    haveExtendedMethods = true;
                    nameExtendedMethods.Add(methodInfo.Name);
                }
                
                if (methodInfo.IsVirtual) continue;
                StringBuilder signature = new StringBuilder();
                foreach (ParameterInfo parameterInfo in methodInfo.GetParameters())                
                    signature.Append(parameterInfo.ParameterType.Name + " " + parameterInfo.Name + ", ");                    
                               
                listData.Add(methodInfo.ReturnType.Name + " " + methodInfo.Name + "(" + signature + ")");
                                             
            }
        }

        public void SearchEvents(Type t)
        {
            foreach (EventInfo eventInfo in t.GetEvents())            
                listData.Add(eventInfo.EventHandlerType.ToString() + " " + eventInfo.Name );            
        }

        public void SearchEnum()
        {
            List<int> list = new List<int>();
            foreach (int value in Enum.GetValues(type))            
                list.Add(value);
            
            StringBuilder signature = new StringBuilder();
            int i = 0;
            foreach (var value in Enum.GetNames(type))            
                signature.Append(value  + " = "+ list[i++] + ",");
          
            
            listData.Add(signature.ToString());
            
        }
    }
}
