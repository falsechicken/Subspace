//
// LogHelper.cs : Used as a tiny helper to process messages in one place.
// 
// Copyright (C) 2015 False_Chicken
// Contact: jmdevsupport@gmail.com
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, Get it here: https://www.gnu.org/licenses/gpl-2.0.html
//

using System;
using Rocket.Core.Logging;

namespace FC.Libs.Subspace
{
	internal static class LogHelper
	{
		#region VARS
		
		internal const byte
			DEBUG = 0,
			INFO = 1,
			WARNING = 2,
			ERROR = 3;
		
		private static bool debugMode = false;
		
		#endregion

		#region INTERNAL METHODS

		internal static void LogMessage(byte _messageLevel, string _message)
		{
			switch (_messageLevel)
			{
				case DEBUG:
					PrintDebugMessage(_message); break;
				case INFO:
					PrintMessage(_message); break;
				case WARNING:
					PrintWarningMessage(_message); break;
				case ERROR:
					PrintErrorMessage(_message); break;
			}
		}
		
		internal static void SetDebugMode(bool _debug)
		{
			debugMode = _debug;
		}
		
		#endregion
		
		#region PRIVATE METHODS
		
		private static void PrintDebugMessage(string _message)
		{
			if (debugMode) Logger.Log(_message);
		}

		private static void PrintMessage(string _message)
		{
			Logger.Log(_message);
		}
		
		private static void PrintWarningMessage(string _message)
		{
			Logger.LogWarning(_message);
		}
		
		private static void PrintErrorMessage(string _message)
		{
			Logger.LogError(_message);
		}

		#endregion
	}
}
