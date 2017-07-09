//
//  Subspace.cs : An event driven library for RocketMod providing plugin communication.
//
//  Author: False_Chicken
//  Contact: jmdevsupport@gmail.com
//
//  Copyright (c) 2015 False_Chicken
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
using Rocket.Core.Plugins;

namespace FC.Libs.Subspace
{
	/**
	 * An event driven library for RocketMod providing plugin communication. This is the main API class.
	 */
	public static class Subspace {

		#region PUBLIC FUNCTIONS

		/**
		 * Subscribes an interface to the specified channel. Returns true if the interface
		 * is not already subscribed.
		 */
		public static Boolean SubscribeToChannel(string _channelName, ISubspaceInterface _subspaceInterface) {
			if (ChannelDB.DoesChannelExist (_channelName)) {
				if (ChannelDB.IsSubscribedToChannel (_channelName, _subspaceInterface))
					return false;
				else {
					ChannelDB.GetInterfaceList (_channelName).Add (_subspaceInterface);
					return true;
				}

			} else {
				ChannelDB.CreateChannel (_channelName);
				ChannelDB.GetInterfaceList (_channelName).Add (_subspaceInterface);
				return true;
			}
		}

		/**
		 * Un-Subscribes an interface from the specified channel. Returns true if the interface
		 * was un-subscribed. Returns false if the channel doesnt exist or the interface was
		 * not subscribed in the first place.
		 */
		public static Boolean UnSubscribeFromChannel(string _channelName, ISubspaceInterface _subspaceInterface) {
			if (ChannelDB.DoesChannelExist (_channelName) && ChannelDB.IsSubscribedToChannel (_channelName, _subspaceInterface)) {
				ChannelDB.GetInterfaceList (_channelName).Remove (_subspaceInterface);
				return true;
			} else {
				return false;
			}
		}

		/**
		 * Sends a message along a channel in Subspace. Returns true if the message was sent.
		 */
		public static Boolean SendSubspaceMessage(SubspaceMessage _message) {
			if (ChannelDB.DoesChannelExist (_message.GetMessageChannel())) {
				foreach (var i in ChannelDB.GetInterfaceList(_message.GetMessageChannel())) {
					if (i.ReceiveMessage (_message))
						return true;
				}
				return true;
			} else {
				return false;
			}
		}
		
		#endregion
	
	}
}

