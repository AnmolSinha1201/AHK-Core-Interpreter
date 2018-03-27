using static AHKCore.Nodes;
using System;
using System.Runtime.Loader;
using System.Reflection;
using System.IO;
using System.Linq;

namespace AHKCore
{
	class InterpreterNodeIndexer: NodeIndexer
	{
		public InterpreterAssemblyMapping assemblyMap;

		public InterpreterNodeIndexer(InterpreterAssemblyMapping assemblyMap)
		{
			this.assemblyMap = assemblyMap;
		}

		public override BaseAHKNode othersFilter(BaseAHKNode context)
		{
			if (context is directiveClass d && d.directiveName.ToLower() == "include")
			{
				LoadAssembly(d.directiveParam);
			}
			return context;
		}

		void LoadAssembly(string fileName)
		{
			var assembly =  AssemblyLoadContext.Default.LoadFromAssemblyPath(
				Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), fileName));
			assemblyMap.mapTypes(assembly);
		}
	}
}