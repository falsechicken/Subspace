//
//  ChannelDB.cs : Manages the channels used by Subspace.
//
//  Author: False_Chicken
//  Contact: jmdevsupport@gmail.com
//
//  Copyright (c) 2017 False_Chicken
//
//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
//

using System;
using System.Collections.Generic;

namespace FC.Libs.Subspace
{
	/**
	 * Manages the Dictionary of channels containing the list of subscribed interfaces.
	 */
	internal static class ChannelDB
	{
		#region VARS	

			#region STORAGE VARS

		//Dictionary containing the active channels and a list of interfaces that are subscribed to them.
		private static Dictionary<string, List<ISubspaceInterface>> ChannelMap = new Dictionary<string, List<ISubspaceInterface>>();

			#endregion

		#endregion

		#region PUBLIC FUNCTIONS

			#region CHANNEL OPERATIONS

		/**
		 * Creates a channel. Returns true if the channel didnt already exist.
		 */
		internal static Boolean CreateChannel(string _channelName) {
			if (ChannelMap.ContainsKey (_channelName)) {
				return false;
			} else {
				ChannelMap.Add (_channelName, new List<ISubspaceInterface> ());
				return true;
			}
		}

		/**
		 * Removes a channel from the database. Returns true if the channel existed.
		 * Obviously this will stop all interfaces from receiving messages on this channel.
		 */
		internal static Boolean RemoveChannel(string _channelName) {
			if (ChannelMap.ContainsKey (_channelName)) {
				ChannelMap.Remove (_channelName);
				return true;
			} else {
				return false;
			}

		}

		#endregion

			#region CHANNEL QUERY

		internal static Boolean DoesChannelExist(string _channelName) {
			if (ChannelMap.ContainsKey (_channelName))
				return true;
			return false;
		}
			
		internal static List<ISubspaceInterface> GetInterfaceList(string _channelName) {
			return ChannelMap[_channelName];
		}

		internal static Boolean IsSubscribedToChannel (string _channelName, ISubspaceInterface _interface) {
			if (DoesChannelExist (_channelName)) {
				foreach (var i in ChannelMap[_channelName]) {
					if (i == _interface)
						return true;
				}
				return false;
			}
			return false;
		}

			#endregion

		#endregion
	}
}

