using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logger.Interfaces
{
	public interface ILogingManager
	{
		void LogError(string message);
		void LogWarning(string message);
		void LogDebug(string message);
		void LogInfo(string message);
	}

}
