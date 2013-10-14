﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using SmartElk.Antler.Common.Extensions;

namespace SmartElk.Antler.Common.Reflection
{
    public static class From
    {
        public static IEnumerable<Assembly> ThisAssembly
        {
            get
            {
                return Assembly.GetCallingAssembly().AsEnumerable();
            }
        }

        public static IEnumerable<Assembly> ExecutingAssembly
        {
            get
            {
                return Assembly.GetExecutingAssembly().AsEnumerable();
            }
        }

        public static IEnumerable<Assembly> AllAssemblies() //todo: rename to AllAppDomainAssemblies ?
        {
            return AppDomain.CurrentDomain.GetAssemblies();
        }
       
        public static IEnumerable<FileInfo> AllFilesIn(string path, bool recursively = false)
        {
            return new DirectoryInfo(path)
                .EnumerateFiles("*.*", recursively ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        }

        public static IEnumerable<FileInfo> AllFilesInApplicationFolder()
        {
            var uri = new Uri(Assembly.GetExecutingAssembly().CodeBase);
            return AllFilesIn(Path.GetDirectoryName(uri.LocalPath));
        }
    }
}