 /*****
 * -- LogHelper: Used as a tiny helper to process messages in one place.  --
 *
 * Copyright (C) 2015 False_Chicken
 * Contact: jmdevsupport@gmail.com
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, Get it here: https://www.gnu.org/licenses/gpl-2.0.html
 *****/

using System;
using Rocket.Core.Logging;

namespace FC.Libs.Subspace
{
	internal class LogHelper
	{
		#region VARS
		
		internal const byte
			MESSAGELEVEL_DEBUG = 0,
			MESSAGELEVEL_INFO = 1,
			MESSAGELEVEL_WARNING = 2,
			MESSAGELEVEL_ERROR = 3;
		
		private  bool debugMode;
		
		#endregion

		#region INTERNAL METHODS
		
		internal LogHelper()
		{
			debugMode = false;
		}

		internal void LogMessage(byte _messageLevel, string _message)
		{
			switch (_messageLevel)
			{
				case MESSAGELEVEL_DEBUG: PrintDebugMessage(_message); break;
				case MESSAGELEVEL_INFO: Logger.Log(_message); break;
				case MESSAGELEVEL_WARNING: Logger.LogWarning(_message); break;
				case MESSAGELEVEL_ERROR: Logger.LogError(_message); break;
			}
		}
		
		internal void SetDebugMode(bool _debug)
		{
			debugMode = _debug;
		}
		
		#endregion
		
		#region PRIVATE METHODS
		
		private void PrintDebugMessage(string _message)
		{
			if (debugMode) Logger.Log(_message);
		}
		
		#endregion
	}
}
