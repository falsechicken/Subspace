//
//  Subspace.cs
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
	public static class Subspace
	{
		#region STORAGE VARIABLES

		private static Dictionary<short, List<ISubspaceInterface>> ChannelMap = new Dictionary<short, List<ISubspaceInterface>>(); //Dictionary to keep track of the channels and a list of interfaces subscribed to them.

		#endregion

		#region UTILITY VARIABLES

		private static LogHelper logHelper = new LogHelper();

		#endregion

		#region PUBLIC FUNCTIONS

		/**
		 * Subscribes an interface to the specified channel. Returns true if the interface
		 * is not already subscribed.
		 */
		public static Boolean SubscribeToChannel(short _channel, ISubspaceInterface _subspaceInterface) 
		{
			if (IsInterfaceSubscribedToChannel(_channel, _subspaceInterface)) return false;

			if (ChannelMap.ContainsKey(_channel))
			{
				ChannelMap[_channel].Add(_subspaceInterface);

			}
			else 
			{
				ChannelMap.Add(_channel, new List<ISubspaceInterface>());
				ChannelMap[_channel].Add(_subspaceInterface);
			}

			return true;
		}

		/**
		 * Sends a message along a channel in Subspace. Returns true if the message was sent.
		 */
		public static Boolean SendSubspaceMessage(SubspaceMessage _message)
		{
			if (ChannelMap.ContainsKey(_message.GetMessageChannel()) == false) return false;

			foreach (ISubspaceInterface sSI in ChannelMap[_message.GetMessageChannel()])
			{
				sSI.ReceiveMessage(_message);
			}

			return true;
		}
		
		#endregion

		#region PRIVATE FUNCTIONS

		private static Boolean IsInterfaceSubscribedToChannel(short _channel, ISubspaceInterface _subspaceInterface)
		{
			if (ChannelMap.ContainsKey(_channel) == false) return false; //If the channel key does not exist then no interfaces have subscribed.

			if (ChannelMap[_channel].Contains(_subspaceInterface) == false) return false; //If the channel has been created but the interface has not subscribed yet.
			else return true; //The interface is subscribed.
		}

		#endregion
	}
}

