//
//  SubspaceMessage.cs
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
using Rocket.Unturned.Player;

namespace FC.Libs.Subspace
{
	public class SubspaceMessage
	{
		private short channel;

		private int messageCode;

		public List<UnturnedPlayer> playerList;

		public SubspaceMessage (short _channel, int _messageCode)
		{
			channel = _channel;

			messageCode = _messageCode;

			playerList = new List<UnturnedPlayer>();
		}

		/**
		 * Returns the channel the message was sent on.
		 */
		public short GetMessageChannel()
		{
			return channel;
		}

		/**
		 * Returns the message code for the message. Used by plug-ins to determine what
		 * action to take.
		 */
		public int GetMessageCode()
		{
			return messageCode;
		}
	}
}

