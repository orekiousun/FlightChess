﻿using System.Collections.Generic;
using System.Reflection;

namespace QxFramework.Utilities
{
    /// <summary>
    /// 类型相关的实用函数。
    /// </summary>
    internal static class TypeUtilities
    {
        /// <summary>
        /// 运行时程序集。
        /// </summary>
        public static readonly string[] AssemblyNames = { "Assembly-CSharp" };

        /// <summary>
        /// 编辑器程序集。
        /// </summary>
        public static readonly string[] EditorAssemblyNames = { "Assembly-CSharp-Editor" };

        /// <summary>
        /// 获取指定基类的所有子类的名称。
        /// </summary>
        /// <param name="typeBase">基类类型。</param>
        /// <returns>指定基类的所有子类的名称。</returns>
        internal static string[] GetTypeNames(System.Type typeBase)
        {
            return GetTypeNames(typeBase, AssemblyNames);
        }

        /// <summary>
        /// 获取编辑器下指定基类的所有子类的名称。
        /// </summary>
        /// <param name="typeBase">基类类型。</param>
        /// <returns>指定基类的所有子类的名称。</returns>
        internal static string[] GetEditorTypeNames(System.Type typeBase)
        {
            return GetTypeNames(typeBase, EditorAssemblyNames);
        }

        /// <summary>
        /// 获取指定程序程序集中基类的所有子类名称。
        /// </summary>
        /// <param name="typeBase">基类类型。</param>
        /// <param name="assemblyNames">程序集名称。</param>
        /// <returns></returns>
        private static string[] GetTypeNames(System.Type typeBase, string[] assemblyNames)
        {
            List<string> typeNames = new List<string>();
            foreach (string assemblyName in assemblyNames)
            {
                Assembly assembly = Assembly.Load(assemblyName);
                if (assembly == null)
                {
                    continue;
                }

                System.Type[] types = assembly.GetTypes();
                foreach (System.Type type in types)
                {
                    if (type.IsClass && !type.IsAbstract && typeBase.IsAssignableFrom(type))
                    {
                        typeNames.Add(type.FullName);
                    }
                }
            }

            typeNames.Sort();
            return typeNames.ToArray();
        }
    }
}