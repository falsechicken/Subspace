//  SubspaceMessage.cs : Represents a message to send through Subspace.
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
	/**
	 * Represents a message sent through Subspace.
	 */
	public class SubspaceMessage {

		private string channel { get; }

		private string messageCode { get; }

		private string action { get; }

		private string argument { get; }

		private List<UnturnedPlayer> playerList;

		public SubspaceMessage (string _channel, string _messageCode, string _action, string _argument, List<UnturnedPlayer> _playerList ) {

			channel = _channel;

			messageCode = _messageCode;

			action = _action;

			argument = _argument;

			playerList = _playerList;
		}

		/**
		 * Returns the channel the message was sent on.
		 */
		public string GetMessageChannel() {
			return channel;
		}

		/**
		 * Returns the message code for the message. Used by plug-ins to determine what
		 * type of message this is.
		 */
		public string GetMessageCode() {
			return messageCode;
		}

		/**
		 * Returns the action sent with the message. A command to tell the receiver what to do.
		 */
		public string GetAction() {
			return action;
		}

		/**
		 * Returns the extra arguments for the message. Extra bits for developers to use.
		 */
		public string GetArgument() {
			return argument;
		}

		/**
		 * Returns the list of players sent with the message. Could be used to preform a batch operation 
		 * on multiple players.
		 */
		public List<UnturnedPlayer> GetPlayerList() {
			return playerList;
		}
	}
}